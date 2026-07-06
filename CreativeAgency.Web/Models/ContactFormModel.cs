using System.ComponentModel.DataAnnotations;

namespace CreativeAgency.Web.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "First name is required.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please choose an enquiry type.")]
    public string? EnquiryType { get; set; }

    [Required(ErrorMessage = "Please provide a summary.")]
    [StringLength(500, ErrorMessage = "Summary cannot exceed 500 characters.")]
    public string? Summary { get; set; }
}
