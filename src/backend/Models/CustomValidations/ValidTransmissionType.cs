using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models.CustomValidations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ValidTransmissionType : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is TransmissionType transmissionType)
        {
            if (transmissionType != TransmissionType.Mechanics &&
                transmissionType != TransmissionType.Auto &&
                transmissionType != TransmissionType.Variator)
            {
                return new ValidationResult("Invalid TransmissionType. The value should be 1, 2, or 3.");
            }
        }

        return ValidationResult.Success;
    }
}
