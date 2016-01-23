using System;
using System.Collections.Generic;
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

		public Panda(string name, string email, GenderType gender)
		{
			Regex a = new Regex(@"@\.");
			Name = name;
			//if (a.IsMatch(email))
			{
				Email = email;
			}
			Gender = gender;
		}

		public override string ToString()
		{
			string result = "Panda name: " + Name + ", email:" + Email + "gender: " + Gender.ToString();
			return result;
		}

		//public override int GetHashCode()
		//{
		//	unchecked
		//	{
		//		int hash = 17;
		//		hash = Name.GetHashCode() + Email.GetHashCode();
		//		return hash;
		//	}
		//}

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
