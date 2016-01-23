using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PandaLibrary
{
	public class Panda
	{
		private string Name;
		private string Email;

		private GenderType Gender;

		public enum GenderType
		{
			Male,
			Female,
		};

		public Panda()
		{
			Name = "";
			Email = "";
			Gender = GenderType.Male;
		}

		public Panda(string name,string email, GenderType gender)
		{
			Regex a = new Regex(@"@\.");
			Name = name;
			if (a.IsMatch(email))
			{
			Email = email;
			}
			else throw new InvalidComObjectException();
			Gender = gender;
		}

		public override string ToString()
		{
			string result = "Panda name: " + Name + ", email:" + Email + "gender: " + Gender.ToString();
            return result;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23*Name.Length + Email.Length.GetHashCode()+ Gender.GetHashCode();
				return hash/4;
			}
		}

		public override bool Equals(object obj)
		{
		
		}
	}
}
