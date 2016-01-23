using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace PandaLibrary
{
    [DataContract]
    public enum GenderType
    {
        [EnumMember]
        Male,
        [EnumMember]
        Female,
    };

    [Serializable]
    [DataContract]
	public class Panda : IComparable
	{
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private string Email { get; set; }

        [DataMember]
        public GenderType Gender { get; set; }

  

		public Panda()
		{
			Name = "";
			Email = "";
			Gender = GenderType.Male;
		}

		public static bool ValidEmail(string str)
		{
			//"[a-z]"
			var a = new Regex(@"@\.");
			return Regex.IsMatch(str, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
		}

		public Panda(string name, string email, GenderType gender)
		{
			Name = name;
			if (ValidEmail(email))
			{
				Email = email;
			}
			Gender = gender;
		}

		public override string ToString()
		{
			string result = "Panda name: " + Name + ", email: " + Email + " gender: " + Gender.ToString();
			return result;
		}

		

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

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + Name.GetHashCode();
				hash = hash * 23 + Email.GetHashCode();
				hash = hash * 23 + Gender.GetHashCode();
				return hash;
			}
		}

		public override bool Equals(object obj)
		{
			Panda p = obj as Panda;
			if (p == null)
			{
				return false;
			}

			return (this.Name == p.Name && this.Email == p.Email && this.Gender == p.Gender) ? true : false;
		}

		public static bool operator ==(Panda p1, Panda p2)
		{
			return object.Equals(p1, p2);
		}

		public static bool operator !=(Panda p1, Panda p2)
		{
			return !(p1 == p2);
		}
	}
}
