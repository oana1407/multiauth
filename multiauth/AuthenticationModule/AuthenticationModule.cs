using log4net;

namespace AuthenticationModule
{
	public abstract class AuthenticationModule : ICanAuthenticateUsers
	{
		protected readonly static ILog log = LogManager.GetLogger(typeof(AuthenticationModule));
		public ICanAuthenticateUsers NextModule { get; set; }

		public abstract bool LogIn(string UserName, string Password);

		public abstract bool LogOut(string UserName);

	}
}