using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using NeccWxApi.Servers;

namespace NeccWxApi
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 主方法
        /// </summary>
        /// <param name="args">启动参数</param>
        public static void Main(string[] args)
        {
            IWebHost host;

            if (args.Length > 0)
            {
                host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(args[0])
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseSetting("detailedErrors", "true")
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .Build();
            }
            else
            {
                host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseSetting("detailedErrors", "true")
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .Build();
            }

            host.Run();
        }
    }
}
