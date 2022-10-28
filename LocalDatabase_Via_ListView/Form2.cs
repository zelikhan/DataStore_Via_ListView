using System;
using System.Runtime.InteropServices;          //Library
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LocalDatabase_Via_ListView
{
    public partial class Form2 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form2()
        {
            InitializeComponent();
           
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in Form1.list_view.Items)
            {
                listView1.Items.Add((ListViewItem)item.Clone());
                show_btn.Visible = false;
            }
            
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (ListViewItem item in Form1.list_view.Items)
            {
                string[] str = item.SubItems[0].Text.Split(' ');
                { 
                    if(str.Length >= 2)
                    {
                        if (str[1].ToUpper() == txt_box.Text.ToUpper())
                        {
                            listView1.Items.Add((ListViewItem)item.Clone());
                        }
                    }    
                    
                }
                

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
           
        }
    }
}
