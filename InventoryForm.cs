using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        
        }//form add product load
    }
}
