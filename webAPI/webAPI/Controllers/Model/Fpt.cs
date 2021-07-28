using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Controllers.Model
{
    public class Fpt
    {
        [Key]
        public int FtpId { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string note { get; set; }


    }
}
