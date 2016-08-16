namespace FormsAuthenticationModule
{
	using System;

	using AuthenticationModule;

	public class FormsAuthentication : ICanAuthenticateUsers
	{
		public bool LogIn(string UserName, string Password)
		{
			Console.WriteLine("{0}: ", this.GetType().Name);
			var logIn = UserName == "costel" && Password == "c0st3l3!";

			if (!logIn)
			{
				Console.WriteLine("user {0} is unknown.", UserName);
			}
			return logIn;
		}

		public bool LogOut(string UserName)
		{
			Console.WriteLine("user {0} was logged out", UserName);
			return true;
		}

		public ICanAuthenticateUsers NextModule { get; set; }
	}
}