﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkLibrary;
using PandaLibrary;
using System.IO;

namespace PandaConsoleInterface
{
    class ConsoleInterface
    {
        static void Main(string[] args)
        {
            Panda panda1 = new Panda("Pesho", "pesho@abv.bg", GenderType.Male);
            Panda panda2 = new Panda("Mariika", "mariika@abv.bg", GenderType.Female);
            Panda panda3 = new Panda("Stoyanka", "stoyanka@abv.bg", GenderType.Female);
            Panda panda4 = new Panda("Ivancho", "ivancho@abv.bg", GenderType.Male);
            PandaSocialNetwork a = new PandaSocialNetwork();
            a.MakeFriends(panda1, panda2);
            a.MakeFriends(panda1, panda3);
            a.MakeFriends(panda2, panda3);
            a.MakeFriends(panda3, panda4);
            Console.WriteLine(a.HowManyGenderInNetwork(2, panda1, GenderType.Male));

            JSONPandaSerializer serializer = new JSONPandaSerializer();
            serializer.Save(a);
            PandaSocialNetwork deserializedNetwork = serializer.Load();

            //BinaryPandaSerializer binSerializer = new BinaryPandaSerializer();
            //binSerializer.Save(a);
            //PandaSocialNetwork temp = binSerializer.Load();

        }
    }
}
