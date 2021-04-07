using System;

namespace ContactsApp
{
    public class Contact : ICloneable
    {
        private string _surname;
        private string _name;
        private string _email;
        private string _vkID;
        private DateTime _birthday;


        public PhoneNumber PhoneNumber { get; set; }


        public string Surname
        {
            get { return _surname; }

            set
            {
                LengthCheck(Surname, 50);

                Surname = Surname.ToUpper()[0] + Surname.Substring(1);
            }
        }

        public string Name
        {
            get { return _name; }

            set
            {
                LengthCheck(Name, 50);

                Name = Name.ToUpper()[0] + Name.Substring(1);
            }
        }

        public string Email
        {
            get { return _email; }

            set { LengthCheck(Email, 50); }
        }

        public string VKID
        {
            get { return _vkID; }

            set { LengthCheck(VKID, 15); }
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

        private void LengthCheck(string strings, int permissibleLength)
        {
            if (strings.Length > permissibleLength)
            {
                throw new ArgumentException("Переменная не может содержать больше " + permissibleLength + " символов!");
            }
        }

        Contact()
        {
        }

        Contact(PhoneNumber phoneNumber, string surname, string name, string email, string vkId, DateTime birthday)
        {
            PhoneNumber = phoneNumber;
            Surname = name;
            Name = name;
            Email = email;
            VKID = vkId;
            Birthday = birthday;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}