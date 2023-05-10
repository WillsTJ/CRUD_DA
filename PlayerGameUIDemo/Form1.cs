using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// These namespaces are needed for SQL conections.
using System.Configuration;
using System.Data.SqlClient;

// Reference the CRUD API.
using CRUD_DA;

namespace PlayerGameUIDemo
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controller.GetRecordData(new CRUD()));
        }
    }
}
