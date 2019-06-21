using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Threading;

namespace Psyconnect.Client{
    class Client {
        private static string ip = "http://99.240.226.177";

        public static string Get(string uri){
            using (var wb = new WebClient())
            {
                return wb.DownloadString(ip+uri);
            }
        }

        public static bool Verify (string uname, string pass){
            return !(Get(ip + "/login/email/" + uname + "/pass/" + pass) == null);
        }

    }
}