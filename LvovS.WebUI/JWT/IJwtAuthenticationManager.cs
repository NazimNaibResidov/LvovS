namespace LvovS.WebUI.JWT
{
    public interface IJwtAuthenticationManager
    {
        string Authentication(string name, string password);
    }
}