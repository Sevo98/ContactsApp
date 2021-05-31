using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {

        private Contact _contact;
        public ContactForm()
        {
            InitializeComponent();
        }

        public Contact Contact
        {
            get { return _contact; }

            set
            {
                _contact = new Contact(value.PhoneNumber, value.Surname, value.Name, value.Email, value.VKID,
                    value.Birthday);
            }
    }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want close this form? Data will not save.", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            if (_contact == null)
            {
                _contact = new Contact();
                _contact.Birthday = DateTime.Now;
                birthdayDateTimePicker.Value = DateTime.Now;
            }
            //else
            //{
            //    surnameBox.Text = _contact.Surname;
            //    nameBox.Text = _contact.Name;
            //    birthdayDateTimePicker.Value = _contact.Birthday;
            //    phoneBox.Text = _contact.PhoneNumber.ToString();
            //    emailBox.Text = _contact.Email;
            //    vkBox.Text = _contact.VKID;
            //}
        }

        private void surnameBox_TextChanged(object sender, EventArgs e)
        {
            surnameBox.BackColor = Color.LightGreen;
            try
            {
                _contact.Surname = surnameBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                surnameBox.BackColor = Color.Brown;
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.BackColor = Color.LightGreen;
            try
            {
                _contact.Name = nameBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                nameBox.BackColor = Color.Brown;
            }
        }

        private void birthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            birthdayDateTimePicker.BackColor = Color.LightGreen;
            try
            {
                _contact.Birthday = birthdayDateTimePicker.Value;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                birthdayDateTimePicker.BackColor = Color.Brown;
                birthdayDateTimePicker.Invalidate();
            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            phoneBox.BackColor = Color.LightGreen;
            if ((phoneBox.Text.All(char.IsDigit)) && (phoneBox.Text != ""))
            {
                try
                {
                    PhoneNumber value = new PhoneNumber();
                    value.Number = long.Parse(phoneBox.Text);
                    _contact.PhoneNumber = value;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception);
                    phoneBox.BackColor = Color.Brown;
                }
            }
            else
            {
                phoneBox.BackColor = Color.Brown;
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            emailBox.BackColor = Color.LightGreen;
            try
            {
                _contact.Email = emailBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                emailBox.BackColor = Color.Brown;
            }
        }

        private void vkTextBox_TextChanged(object sender, EventArgs e)
        {
            vkBox.BackColor = Color.LightGreen;
            try
            {
                _contact.VKID = vkBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                vkBox.BackColor = Color.Brown;
            }
        }
    }
}
