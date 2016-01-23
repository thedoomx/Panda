using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    public class JSONPandaSerializer : IPandaSocialNetworkStorageProvider
    {
        private const string FILE_NAME_PATTERN = @"D:\json.txt";

        public JSONPandaSerializer()
        {

        }

        public PandaSocialNetwork Load()
        {
            string networkAsString = File.ReadAllText(FILE_NAME_PATTERN);
         
            return JsonConvert.DeserializeObject<PandaSocialNetwork>(networkAsString);
        }

        public void Save(PandaSocialNetwork network)
        {
            string serializedNetwork = JsonConvert.SerializeObject(network);

            using (var sw = File.CreateText(FILE_NAME_PATTERN))
            {
                sw.Write(serializedNetwork);
            }

        }
    }
}
