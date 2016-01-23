using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SocialNetworkLibrary
{
    public class BinaryPandaSerializer : IPandaSocialNetworkStorageProvider
    {
        private const string FILE_NAME_PATTERN = @"D:\binary.txt";
        private IFormatter formatter = new BinaryFormatter();

        public BinaryPandaSerializer()
        {

        }

        public PandaSocialNetwork Load()
        {
            using (FileStream s = new FileStream(FILE_NAME_PATTERN, FileMode.Open))
            {
                IFormatter binary = new BinaryFormatter();
                return (PandaSocialNetwork)formatter.Deserialize(s);
            }
        }

        public void Save(PandaSocialNetwork network)
        {
            using (FileStream s = new FileStream(FILE_NAME_PATTERN, FileMode.Create))
            {
                formatter.Serialize(s, network);
            }
        }
    }
}
