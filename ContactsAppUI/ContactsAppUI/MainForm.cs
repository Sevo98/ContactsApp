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
            ContactForm contactForm = new ContactForm();
            contactForm.ShowDialog();

            if (edited == false)
            {
                _project.Contacts.Add(contactForm.Contact);
                ProjectManager.SaveToFile(_project, ProjectManager.FileName);
                _contacts = new List<Contact>();

            }
            else
            {
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
    }
}