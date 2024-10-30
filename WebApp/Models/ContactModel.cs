using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać imię")]
    [MaxLength(length:20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    [MinLength(length:2, ErrorMessage = "Imię musi mieć co najmniej 2 znaki")]
    [Display(Name = "Imię", Order = 1)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać nazwisko")]
    [MaxLength(length:20, ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków")]
    [MinLength(length:2, ErrorMessage = "Nazwisko musi mieć co najmniej 2 znaki")]
    [Display(Name = "Nazwisko", Order = 2)]
    public string LastName { get; set; }
    
    [EmailAddress]
    [Display(Name = "Adres Email", Order = 4)]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    [Display(Name = "Telefon", Order = 3)]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia")]
    public DateOnly Birth { get; set; }

    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
}