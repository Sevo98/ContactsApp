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
    }
}
