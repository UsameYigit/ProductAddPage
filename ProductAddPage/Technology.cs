using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAddPage
{
    class Technology : Product
    {
        string _screenSize = "";
        public string ScreenSize
        {
            get => _screenSize;
            set => _screenSize = value;
        }
        string _madeIn = "";
        public string MadeIn
        {
            get => _madeIn;
            set => _madeIn = value;
        }
        string _model = "";
        public string Model
        {
            get => _model;
            set => _model = value;
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

        public Technology(string ID, string Name, string Description, double Price, string ScreenSize, string Model, string Brand, string MadeIn, string Color)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            Type = "Technology";
            this.ScreenSize = ScreenSize;
            this.Model = Model;
            this.Brand = Brand;
            this.MadeIn = MadeIn;
            this.Color = Color;

        }
    }
}
