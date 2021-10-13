using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WizLibModel.Models;

namespace WizLibModel.ViewModels
{
    public class BookAuthorViewModel
    {
        public BookAuthor BookAuthor { get; set; }
        public Book Book { get; set; }
        public IEnumerable<BookAuthor> BookAuthorList { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
