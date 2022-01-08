using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class MemberProfileViewModel
    {
        [StringLength(maximumLength: 20)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Fullname { get; set; }
        [StringLength(maximumLength: 20)]
        public string Email { get; set; }
        [StringLength(maximumLength: 15)]
        public string PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }

    }
}
