using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using AuthenticationModule;
using log4net.Config;
using Dapper;

namespace FormsAuthenticationModule
{
	public class FormsAuthentication : AuthenticationModule.AuthenticationModule
	{
		private string connectionString;

		public FormsAuthentication()
		{
			XmlConfigurator.Configure();
			connectionString = ConfigurationManager.ConnectionStrings["cs2"]
													.ConnectionString;

		}
		public override bool LogIn(string UserName, string Password)
		{
			Console.WriteLine("{0}: ", this.GetType().Name);

			bool logIn;

			using (var conn = new SqlConnection(connectionString) )
			{
				var user = conn.Query<User>("select UserName=@UserName, Password=@Password",
								new {UserName = UserName, Password = Password})
								.SingleOrDefault();

				logIn = user != null;
			}

			if (!logIn)
			{
				Console.WriteLine("user {0} is unknown.", UserName);
			}
			return logIn;
		}

		public override bool LogOut(string UserName)
		{
			Console.WriteLine("user {0} was logged out", UserName);
			return true;
		}

		public ICanAuthenticateUsers NextModule { get; set; }
	}
}