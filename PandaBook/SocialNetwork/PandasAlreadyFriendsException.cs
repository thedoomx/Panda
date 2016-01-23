using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    public class PandasAlreadyFriendsException: Exception
    {
        public PandasAlreadyFriendsException()
        {

        }

        public PandasAlreadyFriendsException(string message) : base (message)
        {

        }

        public PandasAlreadyFriendsException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
