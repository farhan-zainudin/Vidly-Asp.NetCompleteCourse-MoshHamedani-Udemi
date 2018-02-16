﻿using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public int DiscountRate { get; set; }

        public enum MembershipTypeValidation : byte
        {
            Unknow,
            PayAsYouGo
        }
    }
}