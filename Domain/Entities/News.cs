using System;
using Domain.Common;

namespace Domain.Entities
{
    public class News:BaseEntity
    {
        public News(string title, string text, string author, DateTime date)
        {
            Title = title;
            Text = text;
            Author = author;
            Date = date;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public string Author{ get; set; }
        public DateTime  Date { get; set; }
    }
}
