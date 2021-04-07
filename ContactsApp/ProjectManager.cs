using System;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Сериализация Project
    /// </summary>
    public static class ProjectManager
    {
        private static JsonSerializer serializer = new JsonSerializer();

        /// <summary>
        /// Путь до папки "Мои документы" пользователя
        /// </summary>
        private static string _myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Сохранение данных контактов в JSON-файл
        /// </summary>
        /// <param name="project">сериализуемый объект(список контактов)</param>
        /// <param name="fileName">Имя сохраняемого файла</param>
        public static void SaveToFile(Project project, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(_myDocPath + @fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Считывание данных контактов из файла
        /// Файл берется из папки "Мои документы"
        /// </summary>
        /// <param name="fileName">Имя JSON-файла с данными</param>
        /// <returns></returns>
        public static Project LoadFromFile(string fileName)
        {
            Project project = null;
            using (StreamReader sr = new StreamReader(_myDocPath + @fileName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project) serializer.Deserialize<Project>(reader);
            }

            return project;
        }
    }
}