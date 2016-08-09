namespace multiauth
{
	using System.Collections.Generic;

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
				var formsAuthentication = new FormsAuthentication();
				var windowsAuthentication = new WindowsAuthentication();
				var googleAuthentication = new GoogleAuthentication();

				//formsAuthentication.NextModule = windowsAuthentication;
				//windowsAuthentication.NextModule = googleAuthentication;

				
				this.authenticationModules.Add( formsAuthentication );
				this.authenticationModules.Add( googleAuthentication );
				this.authenticationModules.Add( windowsAuthentication );
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