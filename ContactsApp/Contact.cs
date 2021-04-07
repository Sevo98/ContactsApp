using System;

namespace ContactsApp
{
    public class Contact : ICloneable
    {
        private PhoneNumber _phoneNumber;
        private string _surname;
        private string _name;
        private string _email;
        private string _vkID;
        private DateTime _birthday;

        public PhoneNumber PhoneNumber
        {
            get { return _phoneNumber; }

            set
            {
                if (!PhoneNumber.ToString().StartsWith("7"))
                {
                    throw new ArgumentException("Номер должен начинаться с 7!");
                }

                if (PhoneNumber.ToString().Length != 11)
                {
                    throw new ArgumentException("Номер должен состоять из 11 цифр!");
                }
            }
        }

        public string Surname
        {
            get { return _surname; }

            set
            {
                if (Surname.Length > 50)
                {
                    throw new ArgumentException("Фамилия не может содержать больше 50 символов!");
                }

                Surname = Surname.ToUpper()[0] + Surname.Substring(1);
            }
        }

        public string Name
        {
            get { return _name; }

            set
            {
                if (Name.Length > 50)
                {
                    throw new ArgumentException("Имя не может содержать больше 50 символов!");
                }

                Name = Name.ToUpper()[0] + Name.Substring(1);
            }
        }

        public string email
        {
            get { return _email; }

            set
            {
                if (Name.Length > 50)
                {
                    throw new ArgumentException("Email не может содержать больше 50 символов!");
                }
            }
        }

        public string VKID
        {
            get { return _vkID; }

            set
            {
                if (VKID.Length > 15)
                {
                    throw new ArgumentException("VK ID не может содержать больше 15 символов!");
                }
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }

            set
            {
                if (Birthday.Year < 1900)
                {
                    throw new ArgumentException("Год рождения не может быть меньше 1900 года!");
                }

                if (Birthday > DateTime.Today)
                {
                    throw new ArgumentException("День рождения не может быть больше сегодняшней даты!");
                }
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}