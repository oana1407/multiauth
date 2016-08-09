namespace multiauth
{
	public interface ICanAuthenticationUsers
	{
		bool LogIn(string UserName, string Password);
		bool LogOut(string UserName);

		ICanAuthenticationUsers NextModule { get; set; }

	}
}