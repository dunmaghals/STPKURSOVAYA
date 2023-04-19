using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsAppSTP
{
    internal class Inet
    {
        static HttpListener _httpListener = new HttpListener();

        public static void StartServ() 
        {
            try
            {
                _httpListener.Prefixes.Add("http://localhost:5000/"); // add prefix "http://localhost:5000/"
                _httpListener.Start(); // start server (Run application as Administrator!)
                Thread _responseThread = new Thread(ResponseThread);
                _responseThread.Start(); // start the response thread
            }
            catch 
            {

            }
            
        }
        static void ResponseThread()
        {
            while (_httpListener.IsListening==true)
            {
                try
                {
                    HttpListenerContext context = _httpListener.GetContext(); // get a context
                    byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 5000</title></head>" +
                    "<body>Welcome to the <strong>Localhost server</strong> -- <em>port 5000! Parny, ya sdelal eto)</em></body></html>"); // get the bytes to response
                    context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); // write bytes to the output stream
                    context.Response.KeepAlive = false; // set the KeepAlive bool to false
                    context.Response.Close(); // close the connection
                }
                catch 
                { 

                }
            }
        }
        public static void StopServ() 
        {
            _httpListener.Stop();
        }
    }

}
