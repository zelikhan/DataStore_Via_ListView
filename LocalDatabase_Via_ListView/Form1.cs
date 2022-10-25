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
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace LocalDatabase_Via_ListView
{

    public partial class Form1 : Form
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

        public static ListView list_view = new ListView();


        public Form1()
        {
            InitializeComponent();
            


            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
           
            Form2 frm2 = new Form2();

            frm2.Show();


        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            
            String gender = "";
            if(radioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            ListViewItem list = new ListViewItem(f_name.Text + " " + l_name.Text);
            list.SubItems.Add(c_no.Text);
            list.SubItems.Add(gender);
            list.SubItems.Add(address.Text);
            list.SubItems.Add(w_no.Text);
            list.SubItems.Add(w_name.Text);
            list_view.Items.Add(list);
            f_name.Text = "";
            l_name.Text = "";
            address.Text = "";
            c_no.Text = "";
            w_no.Text = "";
            w_name.Text = "";
            MessageBox.Show("Record Saved Succesfully");




        }
    }
}
