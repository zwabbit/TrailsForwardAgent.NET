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
            Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
            User userData = new User();
            userData.Name = "u1-0@example.com";
            userData.Password = "letmein";
            HttpWebRequest request = WebRequest.Create("http://trails_forward.dev.mirerca.com/users/authenticate_for_token") as HttpWebRequest;
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "post";
            Stream jsonStream = request.GetRequestStream();
            Console.WriteLine(userData.ToString());
            DataContractJsonSerializer jsonSerial = new DataContractJsonSerializer(typeof(User));
            jsonSerial.WriteObject(jsonStream, userData);
            jsonStream.Flush();
            //jsonStream.Close();
            
            HttpWebResponse response = null;
            StreamReader readStream = null;
            
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Stream recStream = response.GetResponseStream();
            
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                string str = new string(read, 0, count);
                Console.Write(str);
                count = readStream.Read(read, 0, 256);
            }
            response.Close();
        }
    }
}
