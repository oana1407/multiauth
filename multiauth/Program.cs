using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiauth
{

	public class Program
	{
		static void Main( string[] args )
		{
			var reply = 0;
			var authHandlers = new AuthenticationHandler();
			//var authModule = authHandlers.StartAuthenticationModule();

			if (args.Length != 2) return;

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

