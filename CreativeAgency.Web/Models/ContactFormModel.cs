using System.ComponentModel.DataAnnotations;

namespace CreativeAgency.Web.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "First name is required.")]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email Address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please choose an enquiry type.")]
    [Display(Name = "Enquiry Type")]
    public string? EnquiryType { get; set; }

    [Required(ErrorMessage = "Please provide a summary.")]
    [StringLength(1000, ErrorMessage = "Summary cannot exceed 1000 characters.")]
    [Display(Name = "Summary")]
    public string? Summary { get; set; }
}
