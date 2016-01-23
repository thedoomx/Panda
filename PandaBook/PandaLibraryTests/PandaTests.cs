using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaLibrary.Tests
{

	[TestClass()]
	public class PandaTests
	{
		[TestMethod()]
		public void ValidEmailTest()
		{
			var email = "aaa@aaa.bg";
			if (Panda.ValidEmail(email))
			{

			}
			else
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void IvalidEmailTest()
		{
			var email = "aaaaaa.bg";
			if (Panda.ValidEmail(email))
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Panda a = new Panda("Gosho", "email@pesho.bg", Panda.GenderType.Male);
			Panda b = new Panda("Penka", "email2@pesho.bg", Panda.GenderType.Female);
			var result = a.ToString();
			//"Panda name: " + Name + ", email:" + Email + "gender: " + Gender.ToString()
			if (result != "Panda name: Gosho, email: email@pesho.bg gender: Male")
			// && b.ToString() != "Panda name: Penka, email: email2@pesho.bg gender: Female")
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			Panda a = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);
			Panda b = new Panda("Penka", "email2@pesho.bg", Panda.GenderType.Female);

			if (a.GetHashCode() == b.GetHashCode())
			{
				Assert.Fail();
			}
		}
		[TestMethod()]
		public void GetDifferentHashCodeTest()
		{
			Panda a = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);
			Panda b = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);

			if (a.GetHashCode() != b.GetHashCode())
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void CompareToTest()
		{
			Panda a = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);
			Panda b = new Panda("Penka", "email2@pesho.bg", Panda.GenderType.Female);
			Panda c = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);

			if (c.CompareTo(a) != 0)
			{
				Assert.Fail();
			}
			if (c.CompareTo(b) != -1)
			{
				Assert.Fail();
			}

		}

		[TestMethod()]
		public void EqualsTest()
		{
			Panda a = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);
			Panda b = new Panda("Penka", "email2@pesho.bg", Panda.GenderType.Female);
			Panda c = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);

			if (!(a.Equals(c)))
			{ 
				Assert.Fail();
			}
		}
		[TestMethod()]
		public void NotEqualsTest()
		{
			Panda a = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);
			Panda b = new Panda("Penka", "email2@pesho.bg", Panda.GenderType.Female);
			Panda c = new Panda("Gosho", "email1@pesho.bg", Panda.GenderType.Male);

			if ((a.Equals(b)))
			{
				Assert.Fail();
			}
		}

	}
}