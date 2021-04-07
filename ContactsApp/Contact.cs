using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// Email контакта
        /// </summary>
        private string _email;

        /// <summary>
        /// VK ID контакта
        /// </summary>
        private string _vkID;

        /// <summary>
        /// День рождения контакта
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// Номер телефона контакта
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Свойства фамилии контакта вместе с проверкой на длину
        /// и изменением регистра первого символа
        /// </summary>
        public string Surname
        {
            get { return _surname; }

            set
            {
                LengthCheck(Surname, 50);

                Surname = Surname.ToUpper()[0] + Surname.Substring(1);
            }
        }

        /// <summary>
        /// Свойства имени контакта вместе с проверкой на длину
        /// и изменением регистра первого символа
        /// </summary>
        public string Name
        {
            get { return _name; }

            set
            {
                LengthCheck(Name, 50);

                Name = Name.ToUpper()[0] + Name.Substring(1);
            }
        }

        /// <summary>
        /// Свойства Email контакта вместе с проверкой на длину
        /// </summary>
        public string Email
        {
            get { return _email; }

            set { LengthCheck(Email, 50); }
        }

        /// <summary>
        /// Свойства VK ID контакта вместе с проверкой на длину
        /// </summary>
        public string VKID
        {
            get { return _vkID; }

            set { LengthCheck(VKID, 15); }
        }

        /// <summary>
        /// Свойство день рождения контакта
        /// с проверкой на актуальность даты
        /// </summary>
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

        /// <summary>
        /// Проверка длины передаваемой строки на допустимый размер
        /// </summary>
        /// <param name="strings">Принимаемая строка</param>
        /// <param name="permissibleLength">Допустимая длина строки</param>
        private void LengthCheck(string strings, int permissibleLength)
        {
            if (strings.Length > permissibleLength)
            {
                throw new ArgumentException("Переменная не может содержать больше " + permissibleLength + " символов!");
            }
        }

        /// <summary>
        /// Пустой конструктор контакта
        /// </summary>
        Contact()
        {
        }

        /// <summary>
        /// Конструктор контакта
        /// </summary>
        /// <param name="phoneNumber">Инициализация поля _phoneNumber</param>
        /// <param name="surname">Инициализация поля _surname</param>
        /// <param name="name">Инициализация поля _name</param>
        /// <param name="email">Инициализация поля _email</param>
        /// <param name="vkId">Инициализация поля _vkId</param>
        /// <param name="birthday">Инициализация поля _birthday</param>
        Contact(PhoneNumber phoneNumber, string surname, string name, string email, string vkId, DateTime birthday)
        {
            PhoneNumber = phoneNumber;
            Surname = name;
            Name = name;
            Email = email;
            VKID = vkId;
            Birthday = birthday;
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}