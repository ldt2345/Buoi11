using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BT1
{
    public partial class Form1 : Form
    {
        Ketnoi kn = new Ketnoi();
        SqlConnection connsql;
        public Form1()
        {
            InitializeComponent();
            connsql = kn.conn;
        }
        


        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {

                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string them;
                them = "insert into SINHVIEN values('" + txtMa.Text + "',N'" + txtHoten.Text + "')";
                SqlCommand cmd = new SqlCommand(them, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Nhap thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string sua;
                sua = "Update SINHVIEN set HOTEN = '" + txtHoten.Text +"' where MASV = '"+txtMa.Text+"'";
                SqlCommand cmd = new SqlCommand(sua, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Sua thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string xoa;
                xoa = "Delete SINHVIEN where MASV = '" + txtMa.Text + "'";
                SqlCommand cmd = new SqlCommand(xoa, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnhien_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            
            
        }

        

        
    }
}
