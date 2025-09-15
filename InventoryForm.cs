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
        //STEP 5
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        public frmAddProduct()
        {
            //STEP 9
            BindingSource showProductList = new BindingSource();
            InitializeComponent();
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
                return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                //Exception here
                return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                //Exception here
                return Convert.ToDouble(price);
        }




    }//partial class
}//namespace
