using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public bool IsSuscribeToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "MemberShip Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Day of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}