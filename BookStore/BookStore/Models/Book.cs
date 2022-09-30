﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore.Enums;
using BookStore.Helpers;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Please Enter The Title of Your Book")]
        //[MyCustomValidadtion("Azue")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter The Author Name of Your Book")]
        public string Author { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Language of Your Book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        
        [Required(ErrorMessage = "Please Enter The Total Pages of Your Book")]
        [Display(Name ="Total Pages")]
        public int? TotalPages { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Choose Date and Time")]
        public string MyField { get; set; }
        [Display(Name = "Choose The Cover Photo of Your Book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
    }
}
