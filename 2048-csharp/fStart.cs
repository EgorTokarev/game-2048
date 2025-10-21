using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class fStart : Form
    {
        public Boolean isPlay = false;
        public string UserName;
        public int Bill = 0;

        List<string> users = new List<string>();
        public fStart()
        {
            InitializeComponent();
        }

        private void UpdateUsersShow()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var user in users)
            {
                Button btn = new Button();
                btn.Click += Btn_Click;
                string[] spl_user = user.Split(new char[] { ';' });
                btn.Width = flowLayoutPanel1.Width - 2;
                btn.Height = 50;
                if (spl_user.Length == 2)
                {
                    btn.Text = spl_user[0];
                    btn.Tag = spl_user[1];
                }

                flowLayoutPanel1.Controls.Add(btn);

            }
            

            Button btnNew = new Button();
            btnNew.Text = "<добавить>";
            btnNew.Width = flowLayoutPanel1.Width - 2;
            btnNew.BackColor = Color.Green;
            btnNew.Height = 50;

            btnNew.Click += BtnNew_Click;

            flowLayoutPanel1.Controls.Add(btnNew);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            isPlay = true;
            UserName = ((Button)sender).Text;
            Bill = Convert.ToInt32((((Button)sender).Tag).ToString());
            Close();
        }

        private void fStart_Load(object sender, EventArgs e)
        {

            //Animal pervonah = new Animal("Слон", 30);
            
            //Human human = new Human();
            
            
            ////pervonah.Name = "Зебра";

            //MessageBox.Show("Спросил у животного: " + pervonah.Answer("Ты чо?"));

            //MessageBox.Show("Спросил у человека: " + human.Answer("Ты чо?"));

            try
            {
                users.AddRange(File.ReadAllLines("users.txt", Encoding.GetEncoding(1251)));
            }
            catch
            {

            }
            UpdateUsersShow();



        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            fName fn = new fName();
            fn.ShowDialog();
            users.Add(fn.UserName + ";0");

            UpdateUsersShow();
            File.WriteAllLines("users.txt", users, Encoding.GetEncoding(1251));
        }
    }
}
