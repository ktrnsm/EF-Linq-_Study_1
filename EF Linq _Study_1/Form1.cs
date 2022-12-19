using EF_Linq__Study_1.DesignPatterns.SingltonPattern;
using EF_Linq__Study_1.DTOClasses;
using EF_Linq__Study_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Linq__Study_1
{
    public partial class Form1 : Form
    {
        NorthwindEntities _db;
        public Form1()
        {
            InitializeComponent();
            _db = DBTool.DBInstance;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Products.Where(x => x.UnitPrice > 25 && x.UnitPrice < 35).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Products.OrderBy(x => x.UnitPrice).Where(x => x.UnitPrice < 15).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Products.OrderByDescending(x => x.UnitPrice).Take(1).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Products.OrderByDescending(x => x.UnitPrice).Skip(2).Take(2).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = _db.Products.Find(Convert.ToInt32(textBox1.Text));
                List<Product> products = new List<Product>
                {
                    p
                };

                dataGridView1.DataSource = products;
                
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Product p = _db.Products.Single(x => x.ProductName == "Chai");

            Product p2 = _db.Products.FirstOrDefault(x => x.ProductName.StartsWith("c"));
            MessageBox.Show(p2.ProductName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Categories.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Categories.Where(x => x.CategoryName.Contains("a")).ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Products.Where(x => x.Category.CategoryName == textBox2.Text).ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryID = Convert.ToInt32(textBox3.Text);
                dataGridView1.DataSource = _db.Products.Where(x => x.CategoryID == categoryID).ToList();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (_db.Employees.Any(x => x.FirstName == textBox3.Text && x.LastName == textBox2.Text)) MessageBox.Show("You're Welcome");
            else MessageBox.Show("User cannot be found");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Products.Where(x => x.ProductName.Contains(textBox2.Text)).ToList();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Categories.Select(x => new CategoryDTO
            {
                CategoryName=x.CategoryName,
                Information=x.Description
            }).ToList();        }
    }
}
