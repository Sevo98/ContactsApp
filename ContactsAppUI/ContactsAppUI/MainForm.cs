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
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса Project
        /// </summary>
        private Project _project = ProjectManager.LoadFromFile(ProjectManager.MyPath, ProjectManager.FileName);

        /// <summary>
        /// Список контактов
        /// </summary>
        private List<Contact> _contacts = new List<Contact>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _contacts = _project.Contacts;
            InsertToListBox();
            if (_contacts.Count > 0)
            {
                surnameListBox.SelectedIndex = 0;
                InputInformationOfContact(0);
            }
        }

        private void InsertToListBox()
        {
            _contacts = new List<Contact>();
            _contacts = _project.SearchContactByString(findBox.Text);
            _contacts = _contacts.OrderBy(t => t.Surname).ToList();

            for (int index = 0; index < _contacts.Count; index++)
            {
                surnameListBox.Items.Insert(index, _contacts[index].Surname);
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAddEditForm(false);
        }

        /// <summary>
        /// Метод открытия окна создания/редактирования контакта
        /// true - контакт редактируется
        /// false - контакт создается
        /// </summary>
        /// <param name="edited"></param>
        private void openAddEditForm(bool edited)
        {
            if (edited == false)
            {
                ContactForm contactForm = new ContactForm();
                contactForm.ShowDialog();

                if (contactForm.DialogResult == DialogResult.OK)
                {
                    _project.Contacts.Add(contactForm.Contact);
                    ProjectManager.SaveToFile(_project, ProjectManager.FileName);
                    _contacts = new List<Contact>();

                }
            }

            if (edited == true)
            {
                if (surnameListBox.SelectedItem == null)
                {
                    MessageBox.Show("Select contact");
                    return;
                }

                int index = surnameListBox.SelectedIndex;
                ContactForm contact = new ContactForm();
                contact.Contact = (Contact)_contacts[index].Clone();
                contact.ShowDialog();
                if (contact.DialogResult == DialogResult.OK)
                {
                    var contactIndex = _project.Contacts.IndexOf(
                        _contacts[index]);
                    _project.Contacts[contactIndex]
                        = (Contact)contact.Contact.Clone();
                }
                ProjectManager.SaveToFile(_project, ProjectManager.FileName);
                surnameListBox.Items.Clear();
                InsertToListBox();
                index = _contacts.IndexOf(contact.Contact);
            }
            
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAddEditForm(true);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            openAddEditForm(false);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            openAddEditForm(true);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void surnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void findBox_TextChanged(object sender, EventArgs e)
        {
            _contacts = new List<Contact>();
            string searchString = findBox.Text;
            _contacts = _project.SearchContactByString(searchString);
            surnameListBox.Items.Clear();
            InsertToListBox();
            if (_contacts.Count > 0)
            {
                surnameListBox.SelectedIndex = 0;
                InputInformationOfContact(0);
            }
        }

        /// <summary>
        /// Выводит информацию о контакте по индексу
        /// </summary>
        /// <param name="index">индекс контакта</param>
        private void InputInformationOfContact(int index)
        {
            if (index == -1) return;
            var contact = _contacts[index];
            surnameBox.Text = contact.Surname;
            nameBox.Text = contact.Name;
            birthdayDateTimePicker.Value = contact.Birthday;
            phoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            vkTextBox.Text = contact.VKID;
            emailTextBox.Text = contact.Email;
        }

        private void surnameListBox_Click(object sender, EventArgs e)
        {
            int index = surnameListBox.SelectedIndex;
            InputInformationOfContact(index);
        }

        private void birthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedIndex != -1)
            {
                birthdayDateTimePicker.Value = _contacts[surnameListBox.SelectedIndex].Birthday;
            }
            else
            {
                birthdayDateTimePicker.Value = DateTime.Now;
            }
        }
    }
}