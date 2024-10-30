using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family,
    [Display(Name = "Znajomi", Order = 2)]
    Friend,
    [Display(Name = "Kontakt zawodowy", Order = 3)]
    Business,
}