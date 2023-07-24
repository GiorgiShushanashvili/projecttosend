using ProjectToSend.DataAccess.Contracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using TheProjectToSend.Models;

namespace TheProjectToSend.DTOs
{
	public class PersonUpdateDTO
	{
        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "PersonalNumber is required")]
        public string PersonalNumber { get; set; }

        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public int GenderId { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}

