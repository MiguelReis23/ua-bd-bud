using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUD
{
    public sealed class AuthenticatedUser
    {
        private static User authenticatedUser = null;
        private static readonly object lockObject = new object();

        private AuthenticatedUser() { }

        public static User GetAuthenticatedUser()
        {
            if (authenticatedUser == null)
            {
                lock (lockObject)
                {
                    if (authenticatedUser == null)
                    {
                        authenticatedUser = new User();
                    }
                }
            }
            return authenticatedUser;
        }

        public static void Logout()
        {
            authenticatedUser = null;
        }
    }
}
