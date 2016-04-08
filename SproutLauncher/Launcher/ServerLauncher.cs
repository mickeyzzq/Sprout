using System;
using System.IO;
using LitJson;

namespace Sprout.Launcher
{
	public class ServerLauncher
	{
		public string sproutRootPath;
		public string configFileName = "launcher.cfg";

		public ServerLauncher ()
		{
			this.sproutRootPath = Environment.CurrentDirectory;
			string configFilePath = this.sproutRootPath + this.configFileName;

			#if DEBUG
			if (!File.Exists(configFilePath))
			{
				CreateDefaultConfig (configFilePath);
			}
			#endif

			if (File.Exists (configFilePath))
			{
				Console.WriteLine(string.Format("Reading launcher config from file: {0}", configFileName));

				string jsonText = File.ReadAllText (this.sproutRootPath + this.configFileName);
				Config config = JsonMapper.ToObject<Config> (jsonText);

				Console.WriteLine (jsonText);
			}

		}

		public void CreateDefaultConfig (string configFilePath)
		{
			Console.WriteLine (string.Format("Launcher config file NOT FOUND, creating a default: {0}", configFilePath));

			Config defaultConfig = new Config ();
			defaultConfig.SproutRootPath = this.sproutRootPath;
			defaultConfig.serviceList = new System.Collections.Generic.List<Service> ();
			defaultConfig.serviceList.Add (new Service
				{ Name = "Gate001", PathName = "GateServer/GateServer.exe", IPAddr = "", Port = 10001 });

			string jsonText = JsonMapper.ToJson (defaultConfig);
			File.WriteAllText (configFilePath, jsonText);
		}
	}
}

