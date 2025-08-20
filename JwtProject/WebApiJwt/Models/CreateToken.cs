using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes = Encoding.UTF8.GetBytes("jsonwebtokensuperapijsonwebtokensuperapi"); // şifreleme anahtarını belirleyin
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes); // Anahtar oluşturma
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // İmzalama kimlik bilgilerini oluşturma ve algoritmasını belirleme
            JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost", notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(33), signingCredentials: credentials);
            // Token oluşturma alıcı ve verici bilgilerini, geçerlilik süresini ve imzalama kimlik bilgilerini belirleme ne zaman geçerli olacağını belirleme ve ne zaman sona ereceğini belirleme 

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler(); // Token işleyici oluşturma
          return  handler.WriteToken(token); // Token'ı yazma
        }





        public string AdminToken()
        {
            var bytes = Encoding.UTF8.GetBytes("jsonwebtokensuperapijsonwebtokensuperapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visitor"),
            };

            JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost", notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(33), signingCredentials: signing,claims:claims);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);

        }
    }
}
