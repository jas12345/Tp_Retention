using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using FluentValidation;
//using FluentValidation.Mvc;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// Sirve para establecer el modelo en el panel de busqueda del modulo de Head Counts
    /// </summary>
    //[FluentValidation.Attributes.Validator(typeof(FiltersHeadCountsQueryPanelViewModel))]
    public class FiltersHeadCountsQueryPanelViewModel
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("Date")]
        public DateTime QueryDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Site")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Positions { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Managers { get; set; }
    }

    ///// <summary>
    ///// FluentValidation para las propiedades del viewmodel FiltersHeadCountsQueryPanelViewModel
    ///// </summary>
    //public class FiltersHeadCountsQueryPanelValidation : AbstractValidator<FiltersHeadCountsQueryPanelViewModel>
    //{
    //    public FiltersHeadCountsQueryPanelValidation()
    //    {
    //        RuleFor(filter => filter.QueryDate).NotEmpty().WithMessage("Requiered");
    //        RuleFor(filter => filter.Location).NotEmpty().WithMessage("Required");
    //        RuleFor(filter => filter.Positions).NotEmpty().WithMessage("Required");
    //        RuleFor(filter => filter.Managers).NotEmpty().WithMessage("Required");            
    //    }
    //}
}