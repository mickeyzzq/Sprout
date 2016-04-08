using System;

namespace Sprout.Launcher
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// 根据配置决定本机要启动哪些服务
			ServerLauncher launcher = new ServerLauncher();
		}
	}
}
