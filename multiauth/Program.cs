using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

namespace multiauth
{
	public class Program
	{
		readonly static ILog log = LogManager.GetLogger( typeof( Program ) );
		static void Main( string[] args )
		{
			XmlConfigurator.Configure();

			var reply = 0;
			var authHandlers = new AuthenticationHandler();
			//var authModule = authHandlers.StartAuthenticationModule();

			if (args.Length != 2)
			{
				Console.WriteLine("no credentials. exiting");
				Console.ReadLine();
				log.ErrorFormat( "no credentials. exiting" );
				return;
			}
			
			
			var userName = args[0];
			var password = args[1];

			bool login;

			login = authHandlers.TryAll(userName, password);
			

			if (login)
			{
				Console.WriteLine( "user {0} has logged in successfully.", userName );
			}

			Console.ReadLine();
		}
	}
}

