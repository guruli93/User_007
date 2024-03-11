using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Infrastructure.User_Validation
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            IsValid = true;
            ValidationMessage = new List<string>();
        }
        public bool IsValid { get; set; }
        public List<string> ValidationMessage { get; set; }
    }
}
