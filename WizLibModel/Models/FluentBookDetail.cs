﻿namespace WizLibModel.Models
{
    public class FluentBookDetail
    {
        public int BookDetail_Id { get; set; }

        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public double Weight { get; set; }
        public FluentBook Book { get; set; }
    }
}
