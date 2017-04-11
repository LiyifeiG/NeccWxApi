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
                    .UseUrls("http://localhost:4888/api/Home")
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();

            }

            private static bool GetConnectionString()
            {
                var text = File.ReadAllText("WebApi.config");

                //text = Regex.Replace(text, "[\\s\\n]", "");

                DBLink.Log("读取不到连接字符串 , 配置文件内容为 : " + text);

                var re = new Regex("<connectionstring string = \"(.*)\"/>");

                var m = re.Match(text);

                if (!m.Success) return false;

                DBLink.SqlConString = m.Groups[1].Value;

                DBLink.Log("读取到连接字符串 : " + DBLink.SqlConString);

                return true;

            }

        }
    }
