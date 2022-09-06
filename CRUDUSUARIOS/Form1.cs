using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CRUDUSUARIOS
{
    public partial class Form1 : Form
    {
        INTEC_AGU_OCT22Entities db = new INTEC_AGU_OCT22Entities();
        List<string> Msg = new List<string>();
        string PeopleId = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("F");
            GetClientTypes();
            GetContactTypes();
            GetPermissions();
            GetRestrictions();
            GetPeoples();
        }
        private void GetPermissions()
        {
            var permissions = db.Permissions.ToList();
            foreach (var item in permissions)
            {
                cblpermissions.Items.Add(item.Name);
            }
        }
        private void SaveForm()
        {
            var people = new Person();
            people.Id = Guid.NewGuid().ToString();
            people.FirstName = txtname.Text;
            people.MiddleName = txtmiddlename.Text;
            people.LastName = txtlastname.Text;
            people.ClientTypeId = Convert.ToInt32(cmbclienttype.SelectedValue);

            if (cmbcontactype.SelectedIndex != 0)
            {
                people.ContactTypeId = Convert.ToInt32(cmbcontactype.SelectedValue);
            }

            people.SupportStaff = chksupportstaff.Checked;
            people.PhoneNumber = txtphonenumber.Text;
            people.EmailAddress = txtemailaddress.Text;
            people.Enabled = true;
            people.CreatedDate = DateTime.Now;

            db.People.Add(people);
            var peopleSaved = db.SaveChanges() > 0;

            if (peopleSaved)
            {
                var user = new User();
                user.Id = Guid.NewGuid().ToString();
                user.Username = txtusername.Text;
                user.Password = txtpassword.Text;
                user.LicenseTypeId = Convert.ToInt32(cmblicensetype.SelectedValue);
                user.PeopleId = people.Id;
                user.Enabled = true;
                user.CreatedDate = DateTime.Now;

                db.Users.Add(user);
                var userSaved = db.SaveChanges() > 0;

                if (userSaved)
                {
                    MessageBox.Show("The people has been added.");

                    GetPeoples();
                    DefaultControls();


                    btadd.Enabled = true;
                    btsave.Enabled = false;
                    btsave.ForeColor = Color.Black;
                    btcancel.Enabled = false;
                }
            }
        }
        private void GetContactTypes()
        {
            var ContactTypes = db.ContactTypes.ToList();
            cmbcontactype.DataSource = ContactTypes;
            cmbcontactype.DisplayMember = "Name";
            cmbcontactype.ValueMember = "Id";
        }
        private void GetClientTypes()
        {
            var ClientTypes = db.ClientTypes.ToList();
            cmbclienttype.DataSource = ClientTypes;
            cmbclienttype.DisplayMember = "Name";
            cmbclienttype.ValueMember = "Id";
        }
        private void GetRestrictions()
        {
            var restrictions = db.Restrictions.ToList();
            foreach (var item in restrictions)
            {
                cblrestrictions.Items.Add(item.Name);
            }
        }
        private void GetPeoples()
        {
            var peoples = (from a in db.People
                           select new { a.Id, FullName = a.FirstName + " " + a.LastName, a.PhoneNumber, a.EmailAddress, a.Enabled, a.CreatedDate }).ToList();


           dgvusers.DataSource = peoples;
            dgvusers.Columns[0].Visible = false;

        }
        private bool ValidateForm()
        {
            Msg = new List<string>();

            label2.Visible = false;
            label4.Visible = false;
            label8.Visible = false;
            label11.Visible = false;
            label10.Visible = false;

            bool result = true;

            if (string.IsNullOrEmpty(txtname.Text))
            {
                Msg.Add("The field (First Name) is required.");
                label2.Visible = true;
                result = false;
            }

            if (string.IsNullOrEmpty(txtlastname.Text))
            {
                Msg.Add("The field (Last Name) is required.");
                label4.Visible = true;
                result = false;
            }

            if (cmbclienttype.SelectedIndex == 0)
            {
                Msg.Add("The field (Client Type) is required.");
                result = false;
            }

            if (string.IsNullOrEmpty(txtphonenumber.Text))
            {
                Msg.Add("The field (Phone Number) is required.");
                label8.Visible = true;
                result = false;
            }

            if (string.IsNullOrEmpty(txtname.Text))
            {
                Msg.Add("The field (User Name) is required.");
                label2.Visible = true;
                result = false;
            }

            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                Msg.Add("The field (Password) is required.");
                label10.Visible = true;
                result = false;
            }

            return result;
        }
        private void DefaultControls()
        {
            {
                txtname.Text = string.Empty;
                txtmiddlename.Text = string.Empty;
                txtlastname.Text = string.Empty;
                cmbclienttype.SelectedIndex = 0;
                cmbcontactype.SelectedIndex = 0;
                chksupportstaff.Checked = false;
                chksupportstaff.Text = "NO";
                txtphonenumber.Text = string.Empty;
                txtemailaddress.Text = string.Empty;
                txtCreatedDate.Text = string.Empty;
                txtusername.Text = string.Empty;
                txtpassword.Text = string.Empty;
                cmblicensetype.SelectedIndex = 0;
            }

        }
        private void btadd_Click(object sender, EventArgs e)
        {
            btadd.Enabled = false;
            btsave.Enabled = true;
            btcancel.Enabled = true;
            if (ValidateForm())
            {
                SaveForm();
            }
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            GetPeoples();
            DefaultControls();


            btadd.Enabled = true;
            btsave.Enabled = false;
            btsave.ForeColor = Color.Black;
            btcancel.Enabled = false;
        }

        private void dgvusers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PeopleId = String.Empty;

            if (!string.IsNullOrEmpty(dgvusers.SelectedRows[0].Cells["Id"].Value.ToString()))
            {
                PeopleId = dgvusers.SelectedRows[0].Cells["Id"].Value.ToString();
                btupdate.Visible = true;
                btDelete.Visible = true;
            }
            else
            {
                btupdate.Visible = false;
                btDelete.Visible = false;
            }
        }
        private void GetPeopleById(string peopleId)
        {
            DefaultControls();

            var people = db.People.FirstOrDefault(x => x.Id == peopleId);
            if (people != null)
            {
                txtname.Text = people.FirstName;
                txtmiddlename.Text = people.MiddleName;
                txtlastname.Text = people.LastName;
                chksupportstaff.Checked = people.SupportStaff;
                chksupportstaff.Text = people.SupportStaff ? "SI" : "NO";
                txtphonenumber.Text = people.PhoneNumber;
                txtemailaddress.Text = people.EmailAddress;
                txtCreatedDate.Text = people.CreatedDate.ToString("MM/dd/yyyy");

                var user = db.Users.FirstOrDefault(x => x.PeopleId == peopleId);
                if (user != null)
                {
                    txtname.Text = user.Username;
                }
            }
        }
        private void btupdate_Click(object sender, EventArgs e)
        {
            GetPeopleById(PeopleId);

          
            btadd.Enabled = false;
            btsave.Enabled = true;
            btcancel.Enabled = true;
            btupdate.Visible = false;
            btDelete.Visible = false;
        }

        private void chksupportstaff_CheckedChanged(object sender, EventArgs e)
        {
           chksupportstaff.Text = chksupportstaff.Checked ? "SI" : "NO";
        }
    }

}
