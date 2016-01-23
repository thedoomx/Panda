using PandaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    public class PandaSocialNetwork
    {
        Dictionary<Panda, List<Panda>> container = new Dictionary<Panda, List<Panda>>();
        
        public PandaSocialNetwork()
        {

        }

        public void AddPanda(Panda panda)
        {
            if(container.ContainsKey(panda))
            {
                //throw 
            }
        }
    }
}
