using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OwinConfiguration
{
	class Program
	{
		static void Main()
		{
			const string serverUrl = "http://localhost:8080";
			using (WebApplication.Start<Startup>(serverUrl))
			{
				Thread.Sleep(Timeout.Infinite);
			}
		}
	}
}
