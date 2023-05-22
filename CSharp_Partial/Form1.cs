using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Partial
{
    public partial class Form1 : Form
    {
        CData _data = new CData();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            EnumItem[] itemArray = (EnumItem[])Enum.GetValues(typeof(EnumItem));

            foreach(EnumItem ei in itemArray)
            {
                cboxItem.Items.Add(ei.ToString());
            }
            
            EnumRate[] rateArray = (EnumRate[])Enum.GetValues(typeof(EnumRate));

            foreach(EnumRate er in rateArray)
            {
                cboxRate.Items.Add(er.ToString());
            }

            cboxItem.Items.Add(EnumItem.계란.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _data.DataInit();

            _data.StrItem = cboxItem.Text;
            _data.IRate = (int)Enum.Parse(typeof(EnumRate), cboxRate.Text);
            _data.ICount = (int)numCount.Value;

            if(!String.IsNullOrEmpty(_data.StrErrorName))
            {
                tboxErrorMsg.Text = _data.StrErrorName;
                return;
            }

            double dPrice = _data.ItemPrice();
            lboxItem.Items.Add(_data.Result(dPrice));

            _data.TotalPrice = dPrice;
            tboxResult.Text = _data.TotalPrice.ToString() + "원";
        }
    }
}
