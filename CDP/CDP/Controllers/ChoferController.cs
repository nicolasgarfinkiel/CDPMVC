using CDP.Common;
using CDP.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDP.Contracts;
using CDP.Helpers;
using CDP.Models;
using System.ComponentModel.DataAnnotations;

namespace CDP.Controllers
{
    public class ChoferController : Controller
    {
        //
        // GET: /Chofer/      
        //public ActionResult Index()
        //{
        //    ChoferModel ChoferModel = new ChoferModel();
        //    return View(ChoferModel);
        //}

        //[HttpPost]
        //public ActionResult GetChoferes(string Llega, string ChoferModel)
        //{
        //    bool asd = ModelState.IsValid;

        //    if (ChoferModel != null)
        //        asd = true;
        //    var Choferes = new ChoferAdmin().GetChoferes();
        //    //var list = new SelectList(Choferes, "IdChofer", "NombreApellido");
        //    //ViewData["Choferes"] = Choferes;
        //    //return Json(new { Choferes = Choferes }, JsonRequestBehavior.AllowGet); // View(Choferes);
        //    var response = new Response { HasErrors = false, Messages = new List<string>() };
        //    var serviceResponse = new ChoferResponse();

        //    serviceResponse.Response = response;

        //    try
        //    {
        //        serviceResponse.GetChoferes = Choferes;
        //    }
        //    catch (ValidationException ex)
        //    {
        //        response.HasErrors = true;
        //        response.Messages.Add(ex.Message);
        //        serviceResponse.Response = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.HasErrors = true;
        //        response.Messages.Add(ResourceApplication.GeneralError);
        //        serviceResponse.Response = response;
        //    }
        //    return Json(serviceResponse, JsonRequestBehavior.AllowGet);
        //}
        
        [AcceptVerbs("OPTIONS")]
        [HttpPost]
        public ActionResult Give(int id)
        {
            var response = "some response" + id.ToString();
            return Json(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(response));
        }


        public ActionResult Index(ChoferModel ChoferModel1)
        {
            IList<ChoferModel> ChoferModel = new List<ChoferModel>();
            var Get = new ChoferAdmin().GetChoferes(SearchChofer);

            foreach (var item in Get)
            {
                ChoferModel.Add(new ChoferModel
                {
                    IdChofer = item.IdChofer,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Cuit = item.Cuit,
                    Camion = item.Camion,
                    Acoplado = item.Acoplado,
                    FechaCreacion = item.FechaCreacion,
                    UsuarioCreacion = item.UsuarioCreacion,
                    FechaModificacion = item.FechaModificacion,
                    UsuarioModificacion = item.UsuarioModificacion,
                    Activo = item.Activo,
                    EsChoferTransportista = item.EsChoferTransportista,
                    IdGrupoEmpresa = item.IdGrupoEmpresa,
                    Domicilio = item.Domicilio,
                    Marca = item.Marca
                });

                ChoferModel1 = ChoferModel.FirstOrDefault();
            }

            return View(ChoferModel1);
        }
        [HttpPost] // Esta acción acepta la data enviada al servidor
        public ActionResult GetChoferes(ChoferModel ChoferModel)
        {
            // model.Attribute será ahora "algo"
            return View(ChoferModel);
        }
    }
}
