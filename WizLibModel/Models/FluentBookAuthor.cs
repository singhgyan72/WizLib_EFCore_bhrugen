using System.ComponentModel.DataAnnotations.Schema;

namespace WizLibModel.Models
{
    public class FluentBookAuthor
    {
        public int Book_Id { get; set; }

        public int Author_Id { get; set; }

        public FluentBook Book { get; set; }

        public FluentAuthor Author { get; set; }
    }
}
