using FluentValidation;

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(cliente => cliente.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.");

        RuleFor(cliente => cliente.Celular)
            .Matches(@"^\d{10}$").WithMessage("El celular debe tener 10 dígitos.");

        RuleFor(cliente => cliente.Documento)
            .NotEmpty().WithMessage("El documento es obligatorio.")
            .MinimumLength(7).WithMessage("El documento debe tener al menos 7 caracteres.")
            .Must(BeUnique).WithMessage("El documento no debe estar repetido.");

        RuleFor(cliente => cliente.Mail)
            .EmailAddress().WithMessage("El mail debe tener un formato correcto.");

        RuleFor(cliente => cliente.Estado)
            .Equal("Activo").WithMessage("El cliente debe estar activo para obtener datos.");
    }

    private bool BeUnique(string documento)
    {
        // Lógica para verificar que el documento sea único
        // Implementa esto de acuerdo a tu lógica de negocios y base de datos.
        return true; // Placeholder
    }
}

