using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleListener
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: program prefix file");
                Environment.Exit(1);
            }
            var prefix = args[0];
            var path = args[1];

            Console.WriteLine($"Serving file {path} on prefix {prefix}");
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(prefix);
                listener.Start();
                while (true)
                {
                    var ctx = listener.GetContext();
                    byte[] data;
                    try
                    {
                        data = File.ReadAllBytes(path);
                        
                    }
                    catch (Exception e)
                    {
                        ctx.Response.StatusCode = 500;
                        data = Encoding.UTF8.GetBytes(e.ToString());
                    }
                    ctx.Response.ContentType = "text/plain";
                    ctx.Response.OutputStream.Write(data, 0, data.Length);
                    ctx.Response.Close();
                }
            }
        }
    }
}
