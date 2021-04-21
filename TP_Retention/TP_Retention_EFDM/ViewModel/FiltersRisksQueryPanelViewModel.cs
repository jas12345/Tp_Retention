using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// Sirve para establecer el modelo en el panel de busqueda del modulo de Risks
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(FiltersRisksQueryPanelViewModel))]
    public class FiltersRisksQueryPanelViewModel
    {
        public DateTime QueryDate { get; set; }
        public string Location { get; set; }
        public string Positions { get; set; }
        public string Managers { get; set; }
    }

    /// <summary>
    /// FluentValidation para las propiedades del viewmodel FiltersRisksQueryPanelViewModel
    /// </summary>
    public class FiltersRisksQueryPanelValidation : AbstractValidator<FiltersRisksQueryPanelViewModel>
    {
        public FiltersRisksQueryPanelValidation()
        {
            RuleFor(filter => filter.Location).NotEmpty().WithMessage("Required");
            RuleFor(filter => filter.Positions).NotEmpty().WithMessage("Required");
            RuleFor(filter => filter.Managers).NotEmpty().WithMessage("Required");
        }
    }
}