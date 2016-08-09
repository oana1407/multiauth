namespace multiauth
{
	using System;

	public class WindowsAuthentication : AuthenticationModule
	{
		public override bool LogIn(string UserName, string Password)
		{
			Console.WriteLine( "{0}: ", this.GetType().Name );
			var logIn = UserName == "gigel" && Password == "g!g3l3";

			if (!logIn)
			{
				Console.WriteLine("user {0} is unknown.", UserName );
			}

			return logIn;
		}

		public override bool LogOut(string UserName)
		{
			Console.WriteLine( "user {0} was logged out", UserName );
			return true;
		}
	}
}