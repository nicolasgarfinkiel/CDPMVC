using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Contracts
{
    public class Response
    {
        public bool HasErrors { get; set; }
        public List<string> Messages { get; set; }
    }
}
