using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda
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
			Name = name;
			Email = email;
			Gender = gender;
		}

		public override string ToString()
		{
			string result = "Panda name: " + Name + ", email:" + Email + "gender: " + Gender.ToString();
            return result;
		}
	}
}
