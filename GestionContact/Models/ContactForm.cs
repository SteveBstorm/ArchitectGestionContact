﻿using System.ComponentModel.DataAnnotations;

namespace GestionContact.Models
{
    public class ContactForm
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string? Phone { get; set; }
        [EmailAddress] //a@a.a
        public string Email { get; set; }

    }
}
