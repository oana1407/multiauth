using System.Collections.Generic;
namespace multiauth
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;

	using AuthenticationModule;

	public class AuthenticationHandler
	{
		private List<ICanAuthenticateUsers> authenticationModules;

		public AuthenticationHandler()
		{
			this.authenticationModules = new List<ICanAuthenticateUsers>();
			RegisterAuthenticationModules();

		}

		//private FormsAuthentication formsAuthentication;

		public List<ICanAuthenticateUsers> Modules => this.authenticationModules;

		public void RegisterAuthenticationModules()
		{
			if (authenticationModules.Count == 0)
			{
				var authFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
										.Where(file => file.EndsWith("AuthenticationModule.dll"))
										;

				foreach (var authFile in authFiles)
				{
					//Console.WriteLine("AuthenticationModule: {0}", authFile);

					var assembly = Assembly.LoadFrom(authFile);

					var authModules = assembly.GetTypes()
											.Where( type => !type.IsAbstract
														 && typeof( ICanAuthenticateUsers ).IsAssignableFrom(type)
												);

					foreach (var authModule in authModules)
					{
						Console.WriteLine( "--> registered module: {0}", Path.GetFileNameWithoutExtension( authFile ) );

						var iAuthModule = Activator.CreateInstance(authModule) as ICanAuthenticateUsers;

						this.authenticationModules.Add(iAuthModule);
					}
				}

				//var formsAuthentication = new FormsAuthentication();
				//var windowsAuthentication = new WindowsAuthentication();
				//var googleAuthentication = new GoogleAuthentication();

				////formsAuthentication.NextModule = windowsAuthentication;
				////windowsAuthentication.NextModule = googleAuthentication;


				//this.authenticationModules.Add( formsAuthentication );
				//this.authenticationModules.Add( googleAuthentication );
				//this.authenticationModules.Add( windowsAuthentication );
			}
		}

		//public ICanAuthenticateUsers StartAuthenticationModule()
		//{
		//	return this.formsAuthentication;
		//}

		public bool TryAll(string userName, string password)
		{
			bool login = false;
			foreach (var module in this.authenticationModules)
			{
				login = module.LogIn(userName, password);
				if (login) return login;
				//{
				//	if (module.NextModule != null) login = module.NextModule.LogIn(userName, password);
				//}
			}

			return login;
		}
	}
}