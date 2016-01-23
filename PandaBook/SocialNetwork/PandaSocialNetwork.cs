using PandaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    [Serializable]
    public class PandaSocialNetwork: ISerializable
    {
        Dictionary<Panda, List<Panda>> container = new Dictionary<Panda, List<Panda>>();
        
        public PandaSocialNetwork()
        {

        }

        public PandaSocialNetwork(PandaSocialNetworkDTO dto)
        {
            foreach(Panda panda in dto.Pandas)
            {
                int pandaHashCode = panda.GetHashCode();
                List<Panda> pandaFriends = dto.Pandas.Where(p => {
                    return dto.Friendships.Keys.Contains(pandaHashCode) ? dto.Friendships[pandaHashCode].Contains(p.GetHashCode())
                                                                        : false;
                                                                 }).ToList();
                container.Add(panda, pandaFriends);
            }
        }

        public PandaSocialNetworkDTO ConvertToDTO()
        {
            Dictionary<int, List<int>> friendships = new Dictionary<int, List<int>>();

            foreach(var pandaWithFriends in container.Select(i => new {
                                                                        Panda = i.Key.GetHashCode(),
                                                                        Friends = i.Value.Select(f => f.GetHashCode())
                                                                                         .ToList()
                                                                      }))
            {
                friendships.Add(pandaWithFriends.Panda, pandaWithFriends.Friends);
            }

            return new PandaSocialNetworkDTO() { Pandas = container.Keys.ToList(), Friendships = friendships };
        }

        public void AddPanda(Panda panda)
        {
            if(container.ContainsKey(panda))
            {
                throw new PandaAlreadyThereException();
            }
            else
            {
                container.Add(panda, new List<Panda>());
            }
        }

        public bool HasPanda(Panda panda)
        {
            if(container.ContainsKey(panda))
            {
                return true;
            }

            return false;
        }

        public void MakeFriends(Panda panda1, Panda panda2)
        {
            if(!HasPanda(panda1))
            {
                AddPanda(panda1);
            }
            
            if(!HasPanda(panda2))
            {
                AddPanda(panda2);
            }

            if(container[panda1].Contains(panda2))
            {
                throw new PandasAlreadyFriendsException();
            }
            else
            {
                container[panda1].Add(panda2);
                container[panda2].Add(panda1);
            }
        }

        public bool AreFriends(Panda panda1, Panda panda2)
        {
            if(container[panda1].Contains(panda2))
            {
                return true;
            }

            return false;
        }

        public List<Panda> FriendsOf(Panda panda)
        {
            if (!container.ContainsKey(panda))
            {
                return null;
            }
            else
            {
                return container[panda];
            }

        }

        public int ConnectionLevel(Panda panda1, Panda panda2)
        {
            if (AreFriends(panda1, panda2))
            {
                return 1;
            }
            else
            {
                return FindConnectionLevel(panda1, panda2);
            }
        }

        public bool AreConnected(Panda panda1, Panda panda2)
        {
            if(ConnectionLevel(panda1, panda2) > 0)
            {
                return true;
            }

            return false;
        }

        public int HowManyGenderInNetwork(int level, Panda panda, GenderType gender)
        {
            List<Panda> visited = new List<Panda>();
            Queue<PandaWithLevel> queue = new Queue<PandaWithLevel>();

            int counter = 0;

            visited.Add(panda);
            queue.Enqueue(new PandaWithLevel()
            {
                Panda = panda,
                Level = 0
            });

            while (queue.Count > 0)
            {
                PandaWithLevel temp = queue.Dequeue();

                if ((temp.Level == level) && (temp.Panda.Gender == gender))
                {
                    counter++;
                }

                foreach (Panda p in FriendsOf(temp.Panda))
                {
                    if (!visited.Contains(p))
                    {
                        visited.Add(p);
                        queue.Enqueue(new PandaWithLevel()
                        {
                            Panda = p,
                            Level = temp.Level + 1
                        });
                    }
                }
            }

            return counter;
        }

        private int FindConnectionLevel(Panda startPanda, Panda endPanda)
        {
            List<Panda> visited = new List<Panda>();
            Queue<PandaWithLevel> queue = new Queue<PandaWithLevel>();
            
            visited.Add(startPanda);
            queue.Enqueue(new PandaWithLevel()
            {
                Panda = startPanda,
                Level = 0
            });

            while(queue.Count > 0)
            {
                PandaWithLevel temp = queue.Dequeue();

                if(temp.Panda.Equals(endPanda))
                {
                    return temp.Level;
                }

                foreach (Panda panda in FriendsOf(temp.Panda))
                {
                    if(!visited.Contains(panda))
                    {
                        visited.Add(panda);
                        queue.Enqueue(new PandaWithLevel()
                        {
                            Panda = panda,
                            Level = temp.Level + 1
                        });
                    }
                }
            }

            return -1;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("container", this.container, typeof(Dictionary<Panda, List<Panda>>));
        }

        public PandaSocialNetwork(SerializationInfo info, StreamingContext context)
        {
            container = (Dictionary<Panda, List<Panda>>)info.GetValue("container", typeof(Dictionary<Panda, List<Panda>>));
        }


        private class PandaWithLevel
        {
            public Panda Panda { get; set; }
            public int Level { get; set; }
        }
    }

    [DataContract]
    public class PandaSocialNetworkDTO
    {
        [DataMember]
        public List<Panda> Pandas { get; set; }
        [DataMember]
        public Dictionary<int, List<int>> Friendships { get; set; }
    }
}
