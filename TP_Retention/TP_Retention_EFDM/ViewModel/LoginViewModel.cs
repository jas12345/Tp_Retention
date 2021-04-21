using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Mvc;


namespace TP_Retention_EFDM.ViewModel
{
    [FluentValidation.Attributes.Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {

        public string userID { get; set; }

        public string pass { get; set; }

    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {

        public LoginViewModelValidator()
        {

            RuleFor(login => login.userID).Length(1, 100).WithMessage("Characters must be between 1 and 100").NotEmpty().WithMessage("Required");

            RuleFor(login => login.pass).Length(1, 25).WithMessage("Characters must be between 1 and 25").NotEmpty().WithMessage("Required");

            RuleFor(login => login.userID).Matches(@"^[a-z A-Z]+(\.)?\d*$").WithMessage("Invalid");

        }

    }
}