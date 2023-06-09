﻿using System.ComponentModel.DataAnnotations;

namespace WomensTechForum.Models
{
    public class PostThread
    {
        public int Id { get; set; }

        [Display(Name = "Inlägg")]
        [Required] public string Text { get; set; }
        public DateTime? Date { get; set; }
        public bool Offensive { get; set; }
        public int NoOfReports { get; set; }

        [Display(Name = "Bild")]
        public string? ImageSrc { get; set; }
        public string UserId { get; set; }
        public virtual Post? Post { get; set; }
        public int PostId { get; set; }

    }
}
