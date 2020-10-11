using Dnc.BookStore.Model;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.BookStore.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string Email { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml($"<a href='mailto:{Email}'>{Email}</a>");
            output.TagName = "mailto-custom";
        }
    }

    public class CustomTitleTagHelper : TagHelper
    {
        public BookModel bookModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "book-title";
            output.TagMode = TagMode.StartTagAndEndTag;
            var sb = new StringBuilder();
            sb.Append($"<span class='card-text text-muted'><b>({bookModel.Title} - {Enum.GetName(typeof(Dnc.BookStore.Enums.CategoryEnum), Convert.ToInt32(bookModel.Category))})</b></span>");
            output.Content.AppendHtml(sb.ToString());
        }
    }
}
