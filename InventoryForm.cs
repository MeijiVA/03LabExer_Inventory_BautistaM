using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03LabExer_Inventory_BautistaM
{
    public partial class frmAddProduct : Form
    {
        //CHALLENGE EXER STEP 12
        public class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message)
            {

            }
        }
        public class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message)
            {

            }
        }
        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message)
            {

            }
        }


        //STEP 5
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        BindingSource showProductList = new BindingSource();
        public frmAddProduct()
        {
            InitializeComponent();
            //STEP 9
            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //CHALLENGE EXER 13
            try
            {
                //STEP 10
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            //STEP 6
            string[] ListofProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarrd Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };

            //STEP 7
            foreach (String list in ListofProductCategory) {
                cbCategory.Items.Add(list);
            }
        
        }//form add product load'

        //STEP 8
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                //Exception here
                throw new StringFormatException("Invalid Name Format");
                return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                //Exception here
                throw new NumberFormatException("Invalid Number Format");
            return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                //Exception here
                throw new CurrencyFormatException("Invalid Currency Format");
            return Convert.ToDouble(price);
        }




    }//partial class
}//namespace
