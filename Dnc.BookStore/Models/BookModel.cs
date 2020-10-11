﻿
using Dnc.BookStore.Helpers;
using Dnc.BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dnc.BookStore.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [StringLength(300, ErrorMessage ="Description should not be more than 300 characters")]
        public string Description { get; set; }
        //[Required]
        public string Language { get; set; }
        [Required]
        [Display(Name ="Choose applicable languages")]
        public List<string> MultiLanguage { get; set; }
        [Required]
        [Range(1,1000)]
        [Display(Name ="No of pages")]
        public int? Pages { get; set; }
        [Required]
        public string Category { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Choose Published Date")]
        [DateValidate(UpperDate ="11/10/2012")]
        public string DtFieldGeneratedUsingDataType { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name ="Author Email Address")]
        public string EmailFieldGeneratedUsingDataType { get; set; }
        public string MultiLanguageText { get; set; }
        [Required]
        [Display(Name ="Please upload book cover image")]
        public IFormFile BookCover { get; set; }
        public string BookCoverUrl { get; set; }
        [Required]
        [Display(Name ="Please upload book pdf")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
        public IEnumerable<IFormFile> BookGallery { get; set; }
        public List<BookGalleryModel> BookGalleries { get; set; }
    }
}
