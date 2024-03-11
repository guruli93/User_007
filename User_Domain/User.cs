using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Domain
{

    public class User
    {
        [Key]
        public int primaryKey { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "datetimeoffset")]
        public  DateTimeOffset JoinedOn { get; set; }= TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Georgian Standard Time"));
        public Gender CustoGenderMap { get; set; }
    }
}