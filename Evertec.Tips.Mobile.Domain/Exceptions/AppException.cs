using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Domain.Exceptions
{
    public class AppException : Exception
    {
        public string Code;

        public AppException()
        {
        }

        public AppException(string code)
        {
            this.Code = code;
        }

        public AppException(string code, string messsage) : base(messsage)
        {
            this.Code = code;
        }


        public AppException(string code, string messsage, Exception exception) : base(messsage, exception)
        {
            this.Code = code;
        }
    }
}
