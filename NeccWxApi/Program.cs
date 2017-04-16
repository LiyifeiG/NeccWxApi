using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;

namespace NeccWxApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!GetConnectionString())
            {
                return;
            }

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(args[0])
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }

        /// <summary>
        /// 获得连接字符串
        /// </summary>
        /// <returns></returns>
        private static bool GetConnectionString()
        {
            var text = File.ReadAllText("WebApi.config");

            var re = new Regex("<connectionstring string = \"(.*)\"/>");

            var m = re.Match(text);

            if (!m.Success) return false;

            Server.SqlConString = m.Groups[1].Value;

            Server.Log("读取到连接字符串 : " + Server.SqlConString);

            return true;
        }
    }
}
