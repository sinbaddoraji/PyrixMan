namespace PyrixMan.Helpers.Interface;

public interface IJwtTokenGenerator
{
    void SetSigningKey(string key);
    string GenerateToken(string name);
}