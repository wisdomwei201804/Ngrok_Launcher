using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace NgrokLauncher
{
    internal class Ngrok
    {
        private static readonly string NgrokExecutable = "ngrok.exe";
        private static readonly string NgrokYaml = "ngrok.cfg";
        public static readonly string CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string FileNgrokExecutable = Path.Combine(CurrentDirectory, NgrokExecutable);
        public static readonly string FileConfig = Path.Combine(CurrentDirectory, NgrokYaml);
        private static string LocalHost = "localhost:4040";

        public class Config
        {
            public string authtoken { get; set; }
            public string server_addr { get; set; }
            public string region { get; set; }
            public bool console_ui { get; set; }
            public string log_level { get; set; }
            public string log_format { get; set; }
            public string log { get; set; }
            public string web_addr { get; set; }
            public bool run_website { get; set; }
            public bool run_tcp { get; set; }
            public Tunnel tunnels { get; set; }
        }

        public class Tunnel
        {
            public Protocol website { get; set; }
            public Protocol tcp { get; set; }
        }

        public class Protocol
        {
            public string subdomain { get; set; }
            public int remote_port { get; set; }
            public Proto proto { get; set; }
            public string auth { get; set; }
        }

        public class Proto
        {
            public int http { get; set; }
            public int tcp { get; set; }
        }

        public class Response
        {
            public JsonTunnel[] tunnels { get; set; }
        }

        public class JsonTunnel
        {
            public string name { get; set; }
            public string public_url { get; set; }
            public string proto { get; set; }
        }

        public Ngrok()
        {
            if (!File.Exists(FileConfig))
            {
                var config = new Config
                {
                    authtoken = string.Empty,
                    server_addr = string.Empty,
                    console_ui = true,
                    region = "us",
                    log_level = "info",
                    log_format = "logfmt",
                    log = "ngrok.log",
                    web_addr = LocalHost,
                    run_website = true,
                    run_tcp = true,
                    tunnels = new Tunnel
                    {
                        website = new Protocol
                        {
                            subdomain = "www",
                            proto = new Proto
                            {
                                http = 80
                            } 

                        },
                        tcp = new Protocol
                        {
                            remote_port = 2222,
                            proto = new Proto
                            {
                                tcp = 22
                            }
                        }
                    }
                };

                var serializer = new SerializerBuilder().Build();
                var yaml = serializer.Serialize(config);
                File.WriteAllText(FileConfig, yaml);
            }
        }

        public bool IsExists()
        {
            return File.Exists(FileNgrokExecutable);
        }

        public Response GetResponse()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    var content = web.DownloadString($"http://{LocalHost}/api/tunnels");
                    return JsonConvert.DeserializeObject<Ngrok.Response>(content);
                }
            }
            catch
            {
                return null;
            }
        }

        public Config Load()
        {
            var yaml = File.ReadAllText(FileConfig);
            var deserializer = new DeserializerBuilder().Build();
            var config = deserializer.Deserialize<Config>(yaml);

            LocalHost = config.web_addr;
            return config;
        }

        public void Save(string token, string server_addr, int http, string subdomain, int tcp, int lanport, bool run_website, bool run_tcp)
        {
            var config = Load();
            config.authtoken = token;
            config.server_addr = server_addr;
            config.tunnels.website.proto.http= http;
            config.tunnels.website.subdomain = subdomain;
            config.tunnels.tcp.remote_port = tcp;
            config.tunnels.tcp.proto.tcp = lanport;
            config.run_website = run_website;
            config.run_tcp = run_tcp;

            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(config);
            File.WriteAllText(FileConfig, yaml);
        }

        public async Task Start(int code = 0)
        {
            var exec = new ProcessStartInfo();
            exec.WorkingDirectory = CurrentDirectory;
            exec.FileName = NgrokExecutable;
            exec.CreateNoWindow = true;
            exec.UseShellExecute = false;
            exec.Arguments = $"-config \"{NgrokYaml}\" start ";

            switch (code)
            {
                case 1:
                    exec.Arguments += "website";
                    break;

                case 2:
                    exec.Arguments += "tcp";
                    break;

                default:
                    exec.Arguments += "website tcp";
                    break;
            }

            try
            {
                await Task.Run(() =>
                {
                    var proc = Process.Start(exec);
                    proc.WaitForExit();
                    proc.Dispose();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Stop()
        {
            await Task.Run(() =>
            {
                Process[] pList = Process.GetProcessesByName("Ngrok");
                foreach (Process p in pList)
                {
                    Console.WriteLine($"Kill: {p.Id}");
                    p.Kill();
                    p.WaitForExit();
                    p.Dispose();
                }
            });
        }
    }
}