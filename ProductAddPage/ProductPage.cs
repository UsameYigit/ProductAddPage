using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductAddPage
{
    public partial class ProductPage : Form
    {
        List<Book> books = new List<Book>();
        List<Accessory> accessories = new List<Accessory>();
        List<Technology> technologies = new List<Technology>();

        public ProductPage()
        {
            InitializeComponent();
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        void AddProduct()
        {
            bool isFilled = IsFilled();
            try
            {
                if(isFilled)
                {
                    AddToLists();
                    ClearTextFields();
                    AddToView();
                }
                else
                {
                    MessageBox.Show("You have to fill each area besides Product Description to add a Product.");
                    ClearTextFields();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ClearTextFields()
        {
            rtxtDescription.Text = "";
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
        }

        #region Add Methods

        void AddToView()
        {
            string productInfoToString = "";
            if (rdAccessory.Checked)
            {
                productInfoToString = "Type: " + accessories[accessories.Count - 1].Type + " ID: " + accessories[accessories.Count - 1].ID + ", Price: " + accessories[accessories.Count - 1].Price + ", Size: " + accessories[accessories.Count - 1].Size + ", Brand: " + accessories[accessories.Count - 1].Brand + ", MadeIn: " + accessories[accessories.Count - 1].MadeIn + ", Color: " + accessories[accessories.Count - 1].Color;
                AddingListBoxAndComboBox(productInfoToString);
            }
            else if (rdBook.Checked)
            {
                productInfoToString = "Type: " + books[books.Count - 1].Type + " ID: " + books[books.Count - 1].ID + ", Price: " + books[books.Count - 1].Price + ", Page: " + books[books.Count - 1].Page + ", Writer: " + books[books.Count - 1].Writer + ", Language: " + books[books.Count - 1].Language + ", Publisher: " + books[books.Count - 1].Publisher + ", PublishDate: " + books[books.Count - 1].PublishDate;
                AddingListBoxAndComboBox(productInfoToString);
            }
            else
            {
                productInfoToString = "Type: " + technologies[technologies.Count - 1].Type + " ID: " + technologies[technologies.Count - 1].ID + ", Price: " + technologies[technologies.Count - 1].Price + ", ScreenSize: " + technologies[technologies.Count - 1].ScreenSize + ", Brand: " + technologies[technologies.Count - 1].Brand + ", Model: " + technologies[technologies.Count - 1].Model + ", MadeIn: " + technologies[technologies.Count - 1].MadeIn + ", Color: " + technologies[technologies.Count - 1].Color;
                AddingListBoxAndComboBox(productInfoToString);
            }
        }

        void AddingListBoxAndComboBox(string infoToAdd)
        {
            cbPrdoucts.Items.Add(infoToAdd);
            lbProducts.Items.Add(infoToAdd);
        }

        void AddToLists()
        {
            if (rdAccessory.Checked)
            {
                AddAccessoryToLists(ref accessories, txtId.Text, txtName.Text, rtxtDescription.Text, Convert.ToDouble(txtPrice.Text), Convert.ToInt32(txtScreenSize_Page_Size.Text), txtBrand_Publisher_Brand.Text, txtMadeIn_Language_MadeIn.Text, txtColor_PublishDate_Color.Text);
            }
            else if (rdBook.Checked)
            {
                AddBookToLists(ref books, txtId.Text, txtName.Text, rtxtDescription.Text, Convert.ToDouble(txtPrice.Text), Convert.ToInt32(txtScreenSize_Page_Size.Text), txtModel_Writer_.Text, txtMadeIn_Language_MadeIn.Text, txtBrand_Publisher_Brand.Text, txtColor_PublishDate_Color.Text);
            }
            else
            {
                AddTechnologyToLists(ref technologies, txtId.Text, txtName.Text, rtxtDescription.Text, Convert.ToDouble(txtPrice.Text), txtScreenSize_Page_Size.Text, txtBrand_Publisher_Brand.Text, txtMadeIn_Language_MadeIn.Text, txtColor_PublishDate_Color.Text, txtModel_Writer_.Text);
            }
        }

        void AddBookToLists(ref List<Book> books, string ID, string name, string description, double price, int page, string writer, string language, string publisher, string publishDate)
        {
            if (IsIDUnique(ID))
            {
                books.Add(new Book(ID, name, description, price, page, writer, language, publisher, publishDate));
            }
            else
            {
                MessageBox.Show("Please put a new Id. This one is used.");
            }
            
        }
        void AddAccessoryToLists(ref List<Accessory> accessories, string ID, string name, string description, double price, int size, string brand, string madeIn, string color)
        {
            if (IsIDUnique(ID))
            {
                accessories.Add(new Accessory(ID, name, description, price, size, brand, madeIn, color));
            }
            else
            {
                MessageBox.Show("Please put a new Id. This one is used.");
            }
        }
        void AddTechnologyToLists(ref List<Technology> technologies, string ID, string name, string description, double price, string screenSize, string brand, string madeIn, string color, string model)
        {
            if (IsIDUnique(ID))
            {
                technologies.Add(new Technology(ID, name, description, price, screenSize, model, brand, madeIn, color));
            }
            else
            {
                MessageBox.Show("Please put a new Id. This one is used.");
            }
        }
        #endregion

        #region Is Questions
        bool IsIDUnique(string id)
        {
            bool isIDUnique = IsIDUniqueForBooks(id);

            if (!isIDUnique)
            {
                isIDUnique = IsIDUniqueForAccessories(id);
                if (!isIDUnique)
                    isIDUnique = IsIDUniqueForTechnologies(id);
            }

            return isIDUnique;
        }
        bool IsIDUniqueForBooks(string id)
        {
            bool isIDUniqueForBooks = true;
            foreach (Accessory accessory in accessories)
            {
                if (accessory.ID == id)
                    isIDUniqueForBooks = false;
            }
            return isIDUniqueForBooks;
        }
        bool IsIDUniqueForAccessories(string id)
        {
            bool isIDUniqueForAccessories = true;
            foreach (Book book in books)
            {
                if (book.ID == id)
                    isIDUniqueForAccessories = false;
            }
            return isIDUniqueForAccessories;
        }
        bool IsIDUniqueForTechnologies(string id)
        {
            bool isIDUniqueForTechnologies = true;
            foreach (Book book in books)
            {
                if (book.ID == id)
                    isIDUniqueForTechnologies = false;
            }
            return isIDUniqueForTechnologies;
        }

        bool IsFilled()
        {
            bool isFilled = true;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text == "" || control.Text == null)
                    {
                        isFilled = false;
                    }
                }
            }
            return isFilled;
        }
        #endregion

        #region Radio Buttons UI Change
        private void rdTechnology_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTechnology.Checked)
            {
                UIChange("Brand", "Color", "Made In", "Model", "Screen Size", true);
            }

        }

        private void rdBook_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBook.Checked)
            {
                UIChange("Publisher", "Publish Date", "Language", "Writer", "Page", true);
            }
        }

        private void rdAccessory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAccessory.Checked)
            {
                UIChange("Brand", "Color", "Made In", "", "Size", false);
            }
        }
        private void ProductPage_Load(object sender, EventArgs e)
        {
            UIChange("Brand", "Color", "Made In", "Model", "Screen Size", true);
        }

        void UIChange(string setLblBrand_Publisher_Brand, string setLblColor_PublishDate_Color, string setLblMadeIn_Language_MadeIn, string setLblModel_Writer_, string setLblScreenSize_Page_Size, bool adjustTextBox)
        {
            lblBrand_Publisher_Brand.Text = setLblBrand_Publisher_Brand;
            lblColor_PublishDate_Color.Text = setLblColor_PublishDate_Color;
            lblMadeIn_Language_MadeIn.Text = setLblMadeIn_Language_MadeIn;
            lblModel_Writer_.Text = setLblModel_Writer_;
            lblScreenSize_Page_Size.Text = setLblScreenSize_Page_Size;

            txtModel_Writer_.Enabled = adjustTextBox;
        }
        #endregion


    }
}
