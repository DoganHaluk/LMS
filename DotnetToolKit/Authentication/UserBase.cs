using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Switchfully.DotNetToolkit.Authentication.JwtUtilities;

namespace Switchfully.DotNetToolkit.Authentication
{
    public abstract class UserBase
    {
        public virtual int UserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual List<Claim> Claims { get; set; }

        public virtual string GenerateJwtToken()
        {
            // set user audience
            var userAudiences = new List<string> { "SwitchfullyAudience" };

            // set user claims
            var userClaims = new List<Claim> { new Claim("name", Name) };

            // add permissions
            foreach (var claim in Claims)
            {
                userClaims.Add(new Claim("scope", claim.Value));
            }

            // create JWT for user to access ContentApi
            JwtSecurityToken userToken = GenerateJwtSecurityTokenWithAsymmetricSigning(new JwtTokenOptions() { Issuer = "SwitchFullyAuthenticator", Audiences = userAudiences, UserName = Email, Claims = userClaims, SigningKey = PrivateKey, MinutesToExpiration = 120 });

            return userToken.Serialize();
        }
    }
}
