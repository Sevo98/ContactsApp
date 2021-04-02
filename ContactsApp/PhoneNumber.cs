using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private int _number;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (!Number.ToString().StartsWith("7"))
                {
                    throw new ArgumentException("Номер должен начинаться с 7!");
                }

                if (Number.ToString().Length != 11)
                {
                    throw new ArgumentException("Номер должен состоять из 11 цифр!");
                }

            }
        }
    }
}
