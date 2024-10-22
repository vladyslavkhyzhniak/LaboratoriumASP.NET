namespace LabProject.Models;

public class BirthModel
{
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Name) && BirthDate.HasValue && BirthDate.Value < DateTime.Now;
    }

    public int GetAge()
    {
        if (BirthDate == null) return 0;

        var today = DateTime.Today;
        int age = today.Year - BirthDate.Value.Year;

        if (BirthDate.Value.Date > today.AddYears(-age)) age--;

        return age;
    }
}