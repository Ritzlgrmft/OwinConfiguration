using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OwinConfiguration
{
	public class Logger
	{
		private readonly Func<IDictionary<string, object>, Task> _next;

		public Logger(Func<IDictionary<string, object>, Task> next)
		{
			if (next == null)
			{
				throw new ArgumentNullException("next");
			}
			_next = next;
		}

		public Task Invoke(IDictionary<string, object> environment)
		{
			Console.WriteLine("Entry\t{0}\t{1}",
				GetValueFormEnvironment(environment, OwinConstants.RequestMethod), 
				GetValueFormEnvironment(environment, OwinConstants.RequestPath));

			Stopwatch stopWatch = Stopwatch.StartNew();
			return _next(environment).ContinueWith(t =>
			{
				Console.WriteLine("Exit\t{0}\t{1}\t{2}", 
					stopWatch.ElapsedMilliseconds,
					GetValueFormEnvironment(environment, OwinConstants.ResponseStatusCode), 
					GetValueFormEnvironment(environment, OwinConstants.ResponseReasonPhrase));
				return t;
			});
		}

		private static object GetValueFormEnvironment(IDictionary<string, object> environment, string key)
		{
			object value;
			environment.TryGetValue(key, out value);
			return value;
		}
	}
}
