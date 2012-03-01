using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonPrototype
{
    class JsonUrlBuilder
    {
        public static string trailsURL = "http://trails_forward.dev.mirerca.com";
        public static string UserPlayerListUrl(User userData)
        {
            return String.Format("{0}/users/{1}/players.json?auth_token={2}", trailsURL, userData.ID, userData.AuthToken);
        }

        public static string UserTokenAuthenticateURL()
        {
            return String.Format("{0}/users/authenticate_for_token.json", trailsURL);
        }

        //Doesn't seem to work.
        public static string GetUsersURL(string token)
        {
            return String.Format("{0}/users.json?auth_token={1}", trailsURL, token);
        }
    }
}
