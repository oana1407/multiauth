using multiauth;

public abstract class AuthenticationModule : ICanAuthenticationUsers
{
	public ICanAuthenticationUsers NextModule { get; set; }

	public abstract bool LogIn(string UserName, string Password);

	public abstract bool LogOut(string UserName);

}