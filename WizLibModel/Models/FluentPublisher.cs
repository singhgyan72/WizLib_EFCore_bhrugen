using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLibModel.Models
{
    public class FluentPublisher
    {
        public int Publisher_Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public List<FluentBook> Books { get; set; }
    }
}
