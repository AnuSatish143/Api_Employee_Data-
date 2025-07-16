namespace WebApiCoreCruds1.Interfaces
{
    public interface IAuth
    {
        string GenerateJwtToken(string username);
    }
}
