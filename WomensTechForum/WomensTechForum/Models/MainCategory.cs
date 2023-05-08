using System.ComponentModel.DataAnnotations;

namespace WomensTechForum.Models;

public class MainCategory
{
    public int Id { get; set; }
    [Required]
    [Display(Name="Huvudkategori")]
    public string Name { get; set; }
}
