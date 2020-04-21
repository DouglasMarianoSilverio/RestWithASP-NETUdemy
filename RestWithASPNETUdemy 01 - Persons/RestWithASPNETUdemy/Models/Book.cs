using RestWithASPNETUdemy.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestWithASPNETUdemy.Models
{
    public class Book :BaseEntity
    {
        public string Title  { get; set; }
        public string Author { get; set; }
        public Decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }

    }
}
