using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string CourseName { get; set; }
        public DateTime OrderTime { get; set; }
        public double Price { get; set; }
        public string Email { get; set; }
        public string AppUserId { get; set; }

        public string Language { get; set; }
        public AppUser AppUser { get; set; }

    }
}
