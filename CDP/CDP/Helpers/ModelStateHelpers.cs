using CDP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDP.Helpers
{
    public static class ModelStateHelpers
    {
        public static void FillErrorMessages(this ModelStateDictionary helper, ref Response response)
        {
            response.HasErrors = true;
            response.Messages = new List<string>();

            foreach (var key in helper.Keys)
            {
                var error = helper[key].Errors.FirstOrDefault();
                if (error != null)
                {
                    response.Messages.Add(error.ErrorMessage);
                }
            }

        }
    }
}