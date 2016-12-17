using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Contracts
{
    public class ChoferResponse
    {
        public IList<CDP.Common.Chofer> GetChoferes { get; set; }
        public Response Response { get; set; }
    }
}
