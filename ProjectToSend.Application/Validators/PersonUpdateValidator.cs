using System;
using FluentValidation;
using TheProjectToSend.DTOs;

namespace TheProjectToSend.Validators
{
	public class PersonUpdateValidator:AbstractValidator<PersonUpdateDTO>
	{
        public PersonUpdateValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Firstname can't be empty")
                .MaximumLength(50).WithMessage("Firstname is too long");

            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Lastname can't be empty")
                .MaximumLength(50).WithMessage("LastName is too long");

            RuleFor(x => x.PersonalNumber).NotEmpty().WithMessage("Personal number can't be ampty");

            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Mail can't be empty").EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(8).WithMessage("Password is too short").MaximumLength(50)
                .WithMessage("Password is too long");

            RuleFor(x => x.DateofBirth).LessThanOrEqualTo(DateTime.Now);
        }
    }
}

