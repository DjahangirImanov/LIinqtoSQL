using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp46
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AccauntDataContext db = new AccauntDataContext();
        int id = 0;
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USER us = new USER();

            us.NAME = textBox1.Text;
            us.SURNAME = textBox2.Text;
            us.USERNAME = textBox3.Text;
            us.PASSWORD = textBox4.Text;
            us.EMAIL = textBox5.Text;

            try
            {
                db.USERs.InsertOnSubmit(us);
                db.SubmitChanges();
                MessageBox.Show("SUCCESS");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            dataGridView1.DataSource = Operations.Doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = dataGridView1.CurrentRow;

            textBox1.Text = rw.Cells["NAME"].Value.ToString();
            textBox2.Text = rw.Cells["SURNAME"].Value.ToString();
            textBox3.Text = rw.Cells["USERNAME"].Value.ToString();
            textBox4.Text = rw.Cells["PASSWORD"].Value.ToString();
            textBox5.Text = rw.Cells["EMAIL"].Value.ToString();
            id = (int)rw.Cells["ID"].Value;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USER us = db.USERs.Where(u => u.ID == id).SingleOrDefault();
            try
            {
                db.USERs.DeleteOnSubmit(us);
                db.SubmitChanges();
                MessageBox.Show("SUCCESS");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = Operations.Doldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Operations.Doldur();
            textBox4.UseSystemPasswordChar = true;
        }

        private void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Operations.Doldur();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USER us = db.USERs.Where(u => u.ID == id).SingleOrDefault();

            us.NAME = textBox1.Text;
            us.SURNAME = textBox2.Text;
            us.USERNAME = textBox3.Text;
            us.PASSWORD = textBox4.Text;
            us.EMAIL = textBox5.Text;

            try
            {
                db.SubmitChanges();
                MessageBox.Show("UPDATED");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = Operations.Doldur();
        }
    }
}
