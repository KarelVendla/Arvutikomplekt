using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArvutikomplektUL.Models
{
    public class Arvutikomplekt
    {
        public int Id { get; set; }
        public String Kirjeldus { get; set; }
        [Range(0,1)]
        [Required]
        public int Korpus { get; set; }
        [Range(0,1)] //Sisestada saab vaid 0 ja 1
        [Required] //Välja täitmine on kohustuslik
        public int Kuvar { get; set; }
        public int Pakitud { get; set; }
        public int Tellimused { get; set; }
    }
}