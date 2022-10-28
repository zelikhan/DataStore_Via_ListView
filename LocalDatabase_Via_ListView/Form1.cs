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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;
using System.Data.SqlClient;

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
            
            String gend = "";
            if(radioButton1.Checked)
            {
                gend = "Male";
            }
            else
            {
                gend = "Female";
            }
            ListViewItem list = new ListViewItem(f_name.Text + " " + l_name.Text);
            list.SubItems.Add(c_no.Text);
            list.SubItems.Add(gend);
            list.SubItems.Add(add.Text);
            list.SubItems.Add(w_no.Text);
            list.SubItems.Add(w_name.Text);
            list_view.Items.Add(list);
            f_name.Text ="";
            l_name.Text = "";
            add.Text = "";
            c_no.Text = "";
            w_no.Text = "";
            w_name.Text = "";
            MessageBox.Show("Record Saved Succesfully");    




        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\University Work\Visual Porgramming\Lab Tasks\LAB 6\LocalDatabase_Via_ListView\LocalDatabase_Via_ListView\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();

            string f_nm = f_name.Text;
            string l_nm = l_name.Text;
            string contact = c_no.Text;
            string address = add.Text;
            string w_number = w_no.Text;
            string w_na = w_name.Text;

            string query = "Insert into data Values ( '" + f_nm + "','" + l_nm + "','" + contact + "','" + address + "' , '" + w_number + "','" + w_na + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Saved");
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in list_view.Items)
            {
                string warehouse_no= itm.SubItems[4].Text.ToString();
                if(w_no.Text==warehouse_no)
                {
                    itm.SubItems[0].Text = f_name.Text ;
                    itm.SubItems[1].Text=l_name.Text ;
                    itm.SubItems[2].Text=c_no.Text ;
                    itm.SubItems[3].Text = add.Text;
                    itm.SubItems[4].Text = w_no.Text;
                    itm.SubItems[5].Text = w_name.Text;
                    f_name.Text = "";
                    l_name.Text = "";
                    add.Text = "";
                    c_no.Text = "";
                    w_no.Text = "";
                    w_name.Text = "";
                    MessageBox.Show("Data Updated"); 

                }
                
            }
            
        }
    }
}
