using System;
using System.Collections;
using System.Collections.Generic;

namespace Sprout.Launcher
{
	public class Config
	{
		public string SproutRootPath;
		public List<Service> serviceList;
	}

	public class Service
	{
		public string Name;
		public string PathName;
		public string IPAddr;
		public ushort Port;
	}
}

