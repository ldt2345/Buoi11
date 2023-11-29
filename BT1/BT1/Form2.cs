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
    public partial class Form2 : Form
    {
        Ketnoi kn = new Ketnoi();
        SqlConnection connsql;
        SqlDataAdapter sv;
        DataSet ds_sv;
        DataColumn[] key = new DataColumn[1];
        string select = "select * from SINHVIEN";
        public Form2()
        {
            InitializeComponent();
            connsql = kn.conn;
            sv = new SqlDataAdapter(select, connsql);
            ds_sv = new DataSet();
            sv.Fill(ds_sv, "SINHVIEN");
            key[0] = ds_sv.Tables[0].Columns[0];
            ds_sv.Tables[0].PrimaryKey = key;
        }
        void KenoiDulieu(DataTable pDT)
        {
            txtMa.DataBindings.Clear();
            txtHoten.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", pDT, "MASV");
            txtHoten.DataBindings.Add("Text", pDT, "HOTEN");
        }
        void Load_grid()
        {

            dataGridView1.DataSource = ds_sv.Tables[0];
            KenoiDulieu(ds_sv.Tables[0]);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_sv.Tables[0].NewRow();
            dr["MASV"] = txtMa.Text;
            dr["HOTEN"] = txtHoten.Text;
            ds_sv.Tables[0].Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(sv);
            sv.Update(ds_sv, "SINHVIEN");
            txtMa.Clear();
            txtHoten.Clear();       
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_sv.Tables["SINHVIEN"].Rows.Find(txtMa.Text);
            if (dr != null)
            {
                dr.Delete();
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(sv);
            sv.Update(ds_sv, "SINHVIEN");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Load_grid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_sv.Tables["SINHVIEN"].Rows.Find(txtMa.Text);
            if(dr != null)
            {
                dr["HOTEN"] = txtHoten.Text;
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(sv);
            sv.Update(ds_sv, "SINHVIEN");
        }
    }
}
