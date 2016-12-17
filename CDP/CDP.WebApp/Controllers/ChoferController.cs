using CDP.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDP.WebApp.Models;
using AutoMapper;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.UI;

namespace CDP.WebApp.Controllers
{
    public class ChoferController : Controller
    {
        public ActionResult Index()
        {
            Security.Config();
            if (!Security.IsUserInRole("Administracion"))
                Response.Redirect("");

            return View();
        }

        public JsonResult GetChoferesCombo(string ChoferSearch, string Page)
        {
            var holas = HttpContext;

            IList<ChoferViewModels> ChoferesView = new List<ChoferViewModels>();

            ChoferesView = Mapper.Map<IList<Domain.Chofer>, IList<ChoferViewModels>>(new ChoferAdmin().GetChoferesCombo(ChoferSearch));

            return Json(ChoferesView, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChoferesGrid(string IdChofer, object data)
        {
            try
            {
                var draw = Request.Form.GetValues("data[draw]").FirstOrDefault();
                var start = Request.Form.GetValues("data[start]").FirstOrDefault();
                var length = Request.Form.GetValues("data[length]").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("data[columns][" + Request.Form.GetValues("data[order][0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("data[order][0][dir]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                IList<ChoferViewModels> ChoferesList = Mapper.Map<IList<Domain.Chofer>, IList<ChoferViewModels>>(new ChoferAdmin().GetChoferes(Convert.ToInt32(IdChofer == string.Empty ? "0" : IdChofer), sortColumn, sortColumnDir));

                int totalRecords = ChoferesList.Count;
                int recFilter = ChoferesList.Count;

                return Json(new
                {
                    draw = draw,
                    recordsFiltered = recFilter,
                    recordsTotal = totalRecords,
                    data = ChoferesList.Skip(skip).Take(pageSize)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ChoferViewModels Chofer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Chofer.IdChofer == 0)
                    {
                        //if (!ValidarChofer(Chofer))
                        //    return RedirectToAction("Index");

                        Chofer.Activo = true;
                    }

                    SendMessageUser(new ChoferAdmin().Save(Mapper.Map<ChoferViewModels, Domain.Chofer>(Chofer)));
                }
                else
                {
                    Chofer.JavascriptToRun = "ShowChofer1()";
                    return PartialView("Index", Chofer);
                    //return Json(false, JsonRequestBehavior.AllowGet);

                    //return new ContentResult()
                    //{
                    //    Content = JsonConvert.SerializeObject(string.Empty, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }),
                    //    ContentType = "application/json",
                    //};


                    //if (Chofer.Nombre == null)
                    //    ModelState.AddModelError("Name", "Name is required.");

                    //return new ContentResult()
                    //{
                    //    Content = JsonConvert.SerializeObject("Error", new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }),
                    //    ContentType = "application/json",
                    //};
                    //return Json(new { result = false, responseText = "Something wrong!" });
                    //return JavaScript("AopenModal()");
                    //SendMessageUser("ValidacionSummary", "ErrorPopUp");
                    //return View(false);
                    //return View("Index", Chofer);
                    //return new HttpStatusCodeResult(404, "Can't find that");
                    //return Json(new { success = false });

                    //return PartialView("parcial");

                    //return new ContentResult()
                    //{
                    //    Content = JsonConvert.SerializeObject("Error", new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }),
                    //    ContentType = "application/json",
                    //};
                }
            }
            catch (Exception ex)
            {
                SendMessageUser(0);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        public ActionResult Habilitar(ChoferViewModels Chofer, string IdChofer)
        {
            try
            {
                SendMessageUser(new ChoferAdmin().Habilitar(Mapper.Map<ChoferViewModels, Domain.Chofer>(Chofer)));
            }
            catch (Exception ex)
            {
                SendMessageUser(0);
            }
            return RedirectToAction("Index");
        }

        public bool ValidarChofer(ChoferViewModels Chofer)
        {
            if (new ChoferAdmin().GetChoferByCuit(Chofer.Cuit).Where(ch => ch.EsChoferTransportista == Chofer.EsChoferTransportista).Count() > 0)
            {
                SendMessageUser("Ya existe un chofer o transportista con ese CUIT", "Error");
                return false;
            }

            return false;
        }

        public void SendMessageUser(int Save)
        {
            TempData["MessageUser"] = Save == 0 ? "Ocurrió un error al guardar el chofer o transportista" : "Chofer o transportista guardado con éxito";
            TempData["TypeMessage"] = Save == 0 ? "Error" : "Success";
        }

        public void SendMessageUser(string Message, string TypeMessage)
        {
            TempData["MessageUser"] = Message;
            TempData["TypeMessage"] = TypeMessage;
        }
    }
}
