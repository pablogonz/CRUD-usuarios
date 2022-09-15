using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploDB
{
    public partial class SelectCrud : Form
    {
        public SelectCrud()
        {
            InitializeComponent();
        }

        private void btclient_Click(object sender, EventArgs e)
        {
      
          
            {
                this.Hide();
                var client = new Client();
                client.FormClosed += (s, args) => this.Close();
                client.Show();
            }

     
        }

        private void SelectCrud_Load(object sender, EventArgs e)
        {

        }

        private void btpeople_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                var people = new People();
                people.FormClosed += (s, args) => this.Close();
                people.Show();
            }
        }

        private void btcontact_Click(object sender, EventArgs e)
        {
            
            {
                this.Hide();
                var contact = new Contact();
                contact.FormClosed += (s, args) => this.Close();
                contact.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btclient_Click_1(object sender, EventArgs e)
        {
            {
                this.Hide();
                var client = new Client();
                client.FormClosed += (s, args) => this.Close();
                client.Show();
            }
        }
    }
}
