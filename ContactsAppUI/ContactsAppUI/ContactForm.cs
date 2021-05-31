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
    }
}
