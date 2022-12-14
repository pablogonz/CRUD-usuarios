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
    public partial class Contact : Form
    {
        INTEC_AGU_OCT22Entities db = new INTEC_AGU_OCT22Entities();
        ContactType contactType = new ContactType();
        int contactId = 0;
        public Contact()
        {
            InitializeComponent();
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            ClearaData();
            SetDataGridInView();
        }

        private void SetDataGridInView()
        {
            var contact = (from a in db.ContactTypes
                           select new
                           {
                               a.Id,
                               FullName = a.Name,
                               a.Description,
                               a.CreatedDate,
                               a.Enabled
                           }).ToList();
            dataGridView1.DataSource = contact;
        }

        private void ClearaData()
        {
            txtname.Text = txtDate.Text = txtDate.Text = string.Empty;
            btndelete.Enabled = false;
            btnsave.Text = "Save";
            contactId = 0;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            contactType.Name = txtname.Text.Trim();
            contactType.Description = cmbdesc.Text.Trim();
            contactType.CreatedDate = Convert.ToDateTime(txtDate.Text.Trim());

            if (contactId > 0)
            {
                db.Entry(contactType).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.ContactTypes.Add(contactType);
            }
            db.SaveChanges();
            ClearaData();
            SetDataGridInView();
            MessageBox.Show("Record guardado");
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell.RowIndex != -1)
            {
                contactId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                contactType = db.ContactTypes.Where(x => x.Id == contactId).FirstOrDefault();
                txtname.Text = contactType.Name;
                txtDate.Text = contactType.CreatedDate.ToString();
                cmbdesc.Text = contactType.Description;
            }
            btnsave.Text = "Update";
            btndelete.Enabled = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Quiere eliminar este record?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.ContactTypes.Remove(contactType);
                db.SaveChanges();
                ClearaData();
                SetDataGridInView();
                MessageBox.Show("Record delete");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearaData();
        }

        
    }
}
