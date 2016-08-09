namespace multiauth
{
	public interface ICanAuthenticateUsers
	{
		bool LogIn(string UserName, string Password);
		bool LogOut(string UserName);

		ICanAuthenticateUsers NextModule { get; set; }

	}
}