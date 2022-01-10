using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
        public string AppuserId { get; set; }
        public string Fullname { get; set; }
        public string CourseName { get; set; }
        public DateTime OrderTime { get; set; }
        public string Email { get; set; }
    }
}
