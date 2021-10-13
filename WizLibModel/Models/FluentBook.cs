using System.Collections.Generic;

namespace WizLibModel.Models
{
    public class FluentBook
    {
        public int Book_Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public double Price { get; set; }

        public int BookDetail_Id { get; set; }

        public FluentBookDetail BookDetail { get; set; }

        public int Publisher_Id { get; set; }

        public FluentPublisher Publisher { get; set; }

        public ICollection<FluentBookAuthor> BookAuthors { get; set; }
    }
}
