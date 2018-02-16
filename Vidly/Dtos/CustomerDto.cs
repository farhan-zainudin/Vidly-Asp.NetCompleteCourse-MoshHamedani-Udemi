using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSuscribedToNewsLetter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [DataType(DataType.Date)]
        //[Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}