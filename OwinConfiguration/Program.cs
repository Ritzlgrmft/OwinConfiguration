using Microsoft.Owin.Hosting;
using System.Threading;

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
