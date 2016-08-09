using multiauth;

public abstract class AuthenticationModule : ICanAuthenticateUsers
{
	public ICanAuthenticateUsers NextModule { get; set; }

	public abstract bool LogIn(string UserName, string Password);

	public abstract bool LogOut(string UserName);

}