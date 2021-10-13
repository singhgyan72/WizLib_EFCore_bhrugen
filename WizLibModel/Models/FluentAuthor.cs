using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLibModel.Models
{
    public class FluentAuthor
    {
        public int Author_Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public ICollection<FluentBookAuthor> BookAuthors { get; set; }
    }
}
