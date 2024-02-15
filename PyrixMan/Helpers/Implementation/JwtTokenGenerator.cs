using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using PyrixMan.Helpers.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PyrixMan.Helpers.Implementation;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private string SigningKey { set; get; }

    public void SetSigningKey(string key)
    {
        SigningKey = key;
    }

    public string GenerateToken(string name)
    {
        Claim nameClaim = new Claim(ClaimTypes.Name, name);
        DateTime expiry = DateTime.UtcNow.AddHours(5);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes256Encryption);
        var token = new JwtSecurityToken("", "", new[] { nameClaim }, expires: expiry, signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}