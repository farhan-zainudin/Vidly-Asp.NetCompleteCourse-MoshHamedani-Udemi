using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Birthdate = customer.Birthdate;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            IsSuscribedToNewsLetter = customer.IsSuscribedToNewsLetter;
        }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSuscribedToNewsLetter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        [Min18YearsIfMember]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public string Tittle => Id != 0 ? "Edit Customer" : "New Customer";
    }
}