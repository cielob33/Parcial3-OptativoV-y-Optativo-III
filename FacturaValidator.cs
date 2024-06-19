using FluentValidation;

namespace WebApiProject
{

    public class FacturaValidator : AbstractValidator<Factura>
    {
        public FacturaValidator()
        {
            RuleFor(factura => factura.NroFactura)
                .Matches(@"^\d{3}-\d{3}-\d{6}$").WithMessage("El número de factura debe seguir el patrón especificado.");

            RuleFor(factura => factura.Total)
                .NotEmpty().WithMessage("El total es obligatorio.")
                .Must(BeNumeric).WithMessage("El total debe ser numérico.");

            RuleFor(factura => factura.Total_iva5)
                .NotEmpty().WithMessage("El total IVA 5% es obligatorio.")
                .Must(BeNumeric).WithMessage("El total IVA 5% debe ser numérico.");

            RuleFor(factura => factura.Total_iva10)
                .NotEmpty().WithMessage("El total IVA 10% es obligatorio.")
                .Must(BeNumeric).WithMessage("El total IVA 10% debe ser numérico.");

            RuleFor(factura => factura.Total_iva)
                .NotEmpty().WithMessage("El total IVA es obligatorio.")
                .Must(BeNumeric).WithMessage("El total IVA debe ser numérico.");

            RuleFor(factura => factura.TotalEnLetras)
                .NotEmpty().WithMessage("El total en letras es obligatorio.")
                .MinimumLength(6).WithMessage("El total en letras debe tener al menos 6 caracteres.");
        }

        private bool BeNumeric(string value)
        {
            return decimal.TryParse(value, out _);
        }
    }
