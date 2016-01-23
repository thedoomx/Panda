using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PandaLibrary
{
	public class Panda : IComparable
	{
		private string Name;
		private string Email;

		public GenderType Gender { get; }

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

		public static bool ValidEmail(string str)
		{
			var a = new Regex(@"@\.");
			return Regex.IsMatch(str,"@.");
		}

		public Panda(string name, string email, GenderType gender)
		{
			Name = name;
			if (ValidEmail(email))
			{
				Email = email;
			}
			else throw new DriveNotFoundException();
			Gender = gender;
		}

		public override string ToString()
		{
			string result = "Panda name: " + Name + ", email: " + Email + " gender: " + Gender.ToString();
			return result;
		}

		/*public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash*23*Name.Length + Email.Length.GetHashCode() + Gender.GetHashCode();
				return hash/4;
			}
		}*/

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException();
			}
			Panda p = obj as Panda;
			if ((System.Object)p == null)
			{
				throw new CustomAttributeFormatException();
			}

			return (this.Name == p.Name && this.Email == p.Email) ? 0 : -1;
		}
	}
}
