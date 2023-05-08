﻿using System.ComponentModel.DataAnnotations;

namespace WomensTechForum.Models;

public class Post
{
    public int Id { get; set; }
    [Display(Name = "Rubrik")]
    [Required] public string Header { get; set; }
    
    [Display(Name = "Inlägg")]
    [Required] public string Text { get; set; }
    public DateTime Date { get; set; }
    public bool Offensive { get; set; }
    public string? ImageSrc { get; set; }
    public string UserId { get; set; }
    public virtual SubCategory? SubCategory { get; set; }
    public int SubCategoryId { get; set; }

}
