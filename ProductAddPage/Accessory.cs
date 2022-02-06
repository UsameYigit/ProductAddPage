using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAddPage
{
    class Accessory : Product
    {
        int _size = 0;
        public int Size
        {
            get => _size;
            set => _size = value;
        }
        string _madeIn = "";
        public string MadeIn
        {
            get => _madeIn;
            set => _madeIn = value;
        }
        string _color = "";
        public string Color
        {
            get => _color;
            set => _color = value;
        }
        string _brand = "";
        public string Brand
        {
            get => _brand;
            set => _brand = value;
        }
        public Accessory(string ID, string Name, string Description, double Price, int Size, string Brand, string MadeIn, string Color)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            Type = "Accessory";
            this.Size = Size;
            this.Brand = Brand;
            this.MadeIn = MadeIn;
            this.Color = Color;

        }
    }
}
