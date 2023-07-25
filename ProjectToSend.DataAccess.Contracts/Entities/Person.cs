using ProjectToSend.DataAccess.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace TheProjectToSend.Models
{
    public class Person
	{
		public int PersonId { get; set; }
		[Required(ErrorMessage = "Firstname is required")]
		public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "PersonalNumber is required")]
        public string PersonalNumber { get; set; }
		public DateTime DateofBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public Status Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string Usermail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}


