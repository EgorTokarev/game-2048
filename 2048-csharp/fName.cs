using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
        public partial class fName : Form
    {
        List<string> users = new List<string>();

        public string UserName = "Игрок";

        public fName()
        {
            InitializeComponent();
            textBox1.Text = UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
            UserName = textBox1.Text;
            Close();
        }
    }
}
