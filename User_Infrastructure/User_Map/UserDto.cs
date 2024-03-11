using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Domain;

namespace User_Infrastructure.User_Map
{
    public class UserDto
    {
     


        public int primaryKey { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset JoinedOn { get; set; } =  TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Georgian Standard Time"));

     
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        public Gender CustoGenderMap { get; set; }
    }
}
