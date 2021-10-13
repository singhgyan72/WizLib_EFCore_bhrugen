using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WizLibModel.Models;

namespace WizLibModel.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
