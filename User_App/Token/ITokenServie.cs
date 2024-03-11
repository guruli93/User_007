namespace User_App.Token
{
    public interface ITokenServie
    {
        Task<string> GetTokenByname(string UserName);
    }
}