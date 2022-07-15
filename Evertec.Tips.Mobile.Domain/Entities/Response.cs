using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Domain.Entities
{
    public class Response
    {
        public string CodeMessage { get; set; }

        public bool Result { get; set; }

        public List<string> Errors { get; set; }


        public Response()
        {
            this.Result = true;
        }

        public Response(string codeMessage, bool result)
        {
            this.CodeMessage = codeMessage;
            this.Result = result;
        }

        public Response(bool result, List<string> errors)
        {
            this.Errors = errors;
            this.Result = result;
        }
    }
}
