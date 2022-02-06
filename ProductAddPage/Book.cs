using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAddPage
{
    class Book : Product
    {
        int _page = 0;
        public int Page
        {
            get => _page;
            set => _page = value;
        }
        string _writer = "";
        public string Writer
        {
            get => _writer;
            set => _writer = value;
        }
        string _publisher = "";
        public string Publisher
        {
            get => _publisher;
            set => _publisher = value;
        }
        string _language = "";
        public string Language
        {
            get => _language;
            set => _language = value;
        }
        string _publishDate = "";
        public string PublishDate
        {
            get => _publishDate;
            set => _publishDate = value;
        }

        public Book(string ID, string Name, string Description, double Price, int Page, string Writer, string Language, string Publisher, string PublishDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            Type = "Book";
            this.Page = Page;
            this.Writer = Writer;
            this.Language = Language;
            this.Publisher = Publisher;
            this.PublishDate = PublishDate;

        }

    }
}
