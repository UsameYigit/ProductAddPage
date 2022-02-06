using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAddPage
{
    class Product
    {
        string _id = "";
        public string ID
        {
            get => _id;
            set => _id = value;
        }
        string _name = "";
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        string _description = "";
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        double _priceWithTaxes = 0;
        double _price = 0;
        public double Price
        {
            get => _price;
            set { _price = value; }
        }
        string _type = "";
        public string Type
        {
            get => _type;
            set => _type = value;
        }

    }
}
