using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace JsonPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            string contentType = "application/json; charset=utf-8";
            Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
            User userData = new User();
            HttpWebResponse response = null;
            userData.Email = "u1-0@example.com";
            userData.Password = "letmein";

            HttpWebRequest request = WebRequest.Create(JsonUrlBuilder.UserTokenAuthenticateURL()) as HttpWebRequest;
            request.ContentType = contentType;
            request.Method = "post";
            Stream jsonStream = request.GetRequestStream();
            DataContractJsonSerializer jsonSerial = new DataContractJsonSerializer(typeof(User));
            jsonSerial.WriteObject(jsonStream, userData);
            jsonStream.Flush();
            jsonStream.Close();
            
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Stream recStream = response.GetResponseStream();
            DataContractJsonSerializer authSerial = new DataContractJsonSerializer(typeof(AuthenticationToken));
            userData.Token = authSerial.ReadObject(recStream) as AuthenticationToken;

            Console.WriteLine(userData.Email);
            Console.WriteLine(userData.ID);
            Console.WriteLine(userData.AuthToken);

            HttpWebRequest userListRequest = WebRequest.Create(JsonUrlBuilder.UserPlayerListUrl(userData)) as HttpWebRequest;
            userListRequest.ContentType = contentType;
            userListRequest.Method = "get";
            //authSerial.WriteObject(userListRequest.GetRequestStream(), userData.Token);
            //userListRequest.GetRequestStream().Flush();
            //userListRequest.GetRequestStream().Close();

            try
            {
                response = userListRequest.GetResponse() as HttpWebResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            StreamReader userReadStream = new StreamReader(response.GetResponseStream());
            DataContractJsonSerializer playerSerial = new DataContractJsonSerializer(typeof(Player));
            Player player = playerSerial.ReadObject(response.GetResponseStream()) as Player;

            Char[] readUser = new Char[256];
            int countUser = userReadStream.Read(readUser, 0, 256);
            while (countUser > 0)
            {
                string str = new string(readUser, 0, countUser);
                Console.Write(str);
                countUser = userReadStream.Read(readUser, 0, 256);
            }
            /*
            readStream = new StreamReader(recStream);
            
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                string str = new string(read, 0, count);
                Console.Write(str);
                count = readStream.Read(read, 0, 256);
            }
             */
            response.Close();

            User userData2 = new User();
            //userData2.UserID = token.ID;
            HttpWebRequest playerRequest = WebRequest.Create("http://trails_forward.dev.mirerca.com/users/index.json") as HttpWebRequest;
            playerRequest.ContentType = "application/json; charset=utf-8";
            playerRequest.Method = "post";
            DataContractJsonSerializer jsonSerial2 = new DataContractJsonSerializer(typeof(User));
            Stream jsonStream2 = playerRequest.GetRequestStream();
            jsonSerial2.WriteObject(jsonStream2, userData2);
            jsonStream2.Flush();
            jsonStream2.Close();

            try
            {
                response = playerRequest.GetResponse() as HttpWebResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            recStream = response.GetResponseStream();

            StreamReader readStream = new StreamReader(recStream);

            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                string str = new string(read, 0, count);
                Console.Write(str);
                count = readStream.Read(read, 0, 256);
            }

            return;
        }
    }
}
