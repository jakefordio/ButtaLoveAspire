using System.ComponentModel.DataAnnotations;
using Ganss.Xss;
using HtmlAgilityPack;

namespace API.Validators;

public class ValidHtmlAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string htmlInput || string.IsNullOrWhiteSpace(htmlInput))
        {
            return ValidationResult.Success; // [Required] handles nulls
        }

        // 1. Structural Validation (Is it valid HTML?)
        var doc = new HtmlDocument();
        doc.LoadHtml(htmlInput);

        if (doc.ParseErrors.Any())
        {
            return new ValidationResult("The provided HTML contains structural errors.");
        }

        // 2. Security Validation (Does it contain XSS/Malicious scripts?)
        var sanitizer = new HtmlSanitizer();
        var sanitized = sanitizer.Sanitize(htmlInput);

        if (htmlInput != sanitized)
        {
            return new ValidationResult("The HTML contains forbidden or unsafe elements.");
        }

        return ValidationResult.Success;
    }
}