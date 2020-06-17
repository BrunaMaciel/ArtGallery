using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CGSLibrary;

namespace ArtGallery
{
    public partial class SellPiece : Form
    {
        private Gallery gal;
        Regex rvalue = new Regex(@"^[0-9]+$");

        public SellPiece()
        {
            InitializeComponent();
            
        }

        internal Gallery Gal
        {
            get
            {
                return gal;
            }

            set
            {
                gal = value;
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (sellpieceID.Text == null || sellingPrice.Text == null)
                MessageBox.Show("Art Piece ID and Selling Price required!");
            else
            {
                if (sellpieceID.Text.Length != 5)
                {
                    MessageBox.Show("Invalid ID!\nID should have 5 characteres.");
                    return;
                }
                if (!rvalue.IsMatch(sellingPrice.Text))
                {
                    MessageBox.Show("Invalid Estimate Value!\nValue must be a number.");
                    return;
                }

                int sold = gal.SellPiece(sellpieceID.Text, double.Parse(sellingPrice.Text));
                switch (sold)
                {
                    case 0:
                        MessageBox.Show("Art Piece not registred!");
                        break;
                    case 1:
                        MessageBox.Show("Art Piece already sold!");
                        break;
                    case 2:
                        MessageBox.Show("Art Piece not avaliable for selling!");
                        break;
                    case 3:
                        MessageBox.Show("Art Piece sold!");
                        this.Close();
                        break;
                }
            }               
                
        }
    }
}
