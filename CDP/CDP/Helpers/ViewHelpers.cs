using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace CDP.Helpers
{
    public static class ViewHelpers
    {
        public static string RenderViewToString<T>(this ControllerBase controller, String viewName, T model)
        {
            using (var writer = new StringWriter())
            {
                ViewEngineResult result = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);

                var viewPath = ((WebFormView)result.View).ViewPath;
                var view = new WebFormView(controller.ControllerContext, viewPath);
                var vdd = new ViewDataDictionary<T>(model);
                var viewCxt = new ViewContext(controller.ControllerContext, view, vdd, new TempDataDictionary(), writer);
                viewCxt.View.Render(viewCxt, writer);

                return writer.ToString();
            }
        }

        public static string RenderPartialToString<T>(this ControllerBase controller, string partialName, T model)
        {
            var vd = new ViewDataDictionary(controller.ViewData);
            var vp = new ViewPage
            {
                ViewData = vd,
                ViewContext = new ViewContext(),
                Url = new UrlHelper(controller.ControllerContext.RequestContext)
            };

            ViewEngineResult result = ViewEngines.Engines.FindPartialView(controller.ControllerContext, partialName);

            if (result.View == null)
            {
                throw new InvalidOperationException(string.Format("The partial view '{0}' could not be found", partialName));
            }

            var partialPath = ((WebFormView)result.View).ViewPath;

            vp.ViewData.Model = model;

            Control control = vp.LoadControl(partialPath);
            vp.Controls.Add(control);

            var sb = new StringBuilder();

            using (var sw = new StringWriter(sb))
            {
                using (var tw = new HtmlTextWriter(sw))
                {
                    vp.RenderControl(tw);
                }
            }
            return sb.ToString();
        }
    }
}