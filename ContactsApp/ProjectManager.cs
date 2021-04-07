using System;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace ContactsApp
{
    public static class ProjectManager
    {
        private static JsonSerializer serializer = new JsonSerializer();
        private static string _myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void SaveToFile(Project project, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(_myDocPath + @fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

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