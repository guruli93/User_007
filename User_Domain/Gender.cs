using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Domain
{
    public class Gender
    {
        [Key]
        public int ForeignKey { get; set; }

        public string GenderStatus { get; set; }
    }
}
