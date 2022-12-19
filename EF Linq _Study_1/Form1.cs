using EF_Linq__Study_1.DesignPatterns.SingltonPattern;
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
    }
}
