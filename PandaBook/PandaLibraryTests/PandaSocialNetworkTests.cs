using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaLibrary;

namespace SocialNetworkLibrary.Tests
{
	[TestClass()]
	public class PandaSocialNetworkTests
	{
		[TestMethod()]
		public void AddPandaTest()
		{
			PandaSocialNetwork b = new PandaSocialNetwork();
				//Panda, List<Panda>>();<Panda, List<Panda>> testcontainer = new Dictionary<Panda, List<Panda>>();
			Panda a = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);


			b.AddPanda(a);

			Assert.IsTrue((b.HasPanda(a)));
		}
	
		/*
		[TestMethod()]
		public void HasPandaTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void MakeFriendsTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void AreFriendsTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void FriendsOfTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ConnectionLevelTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void AreConnectedTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void HowManyGenderInNetworkTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetObjectDataTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PandaSocialNetworkTest1()
		{
			Assert.Fail();
		}*/
	}
}