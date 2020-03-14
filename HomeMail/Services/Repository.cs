using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HomeMail.Services
{
    class Repository
    {
        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HomeMail");
        private readonly string path;

        public Repository()
        {
                path = Path.Combine(directoryPath, "repository");
        }

        public IEnumerable<string> GetAll()
        {
            return JsonConvert.DeserializeObject<string[]>(File.ReadAllText(path)) ?? new string[0];
        }

        public void Add(string address)
        {
            ChangeSource(source => source.Add(address));
        }

        public void Remove(string address)
        {
            ChangeSource(source => source.Remove(address));
        }

        private void ChangeSource(Action<IList<string>> changeSource)
        {
            var source = GetAll().ToList();
            changeSource(source);
            File.WriteAllText(path, JsonConvert.SerializeObject(source));
        }
    }
}
