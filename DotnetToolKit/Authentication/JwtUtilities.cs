using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Switchfully.DotNetToolkit.Authentication
{
    public static class JwtUtilities
    {
        public const string PrivateKey = "MIIEogIBAAKCAQEA5MeVblDfaHYUs4JKzu1HrNZDBlbG8ndCvBbwfSZUPpcEuKkPxo30awZUhZkPb6dpGm + wRYEwvyGAhIVpqWZpRQ76lIbdbm / hNbFfFs / 6LCt1Bw+xj7wN0ctgCNyOIcNsCxeIjALGWDrxn5Z8EV6Yry/fd/ZEKUXRaDWYrw5qxjpNA/Ppudc2dPsil5t44dtRUDX5YShi92pQTwd93wt6csBQXgsqInNp6l9ceJ15ixyDs+b0RRkOz/Huw4eQB862C2UKSSRKN6wetqVEkjt3DJg8HoNte7nfADCqP4VoG0DMZJDQ86cdzPIwRfBrZg3hBws0kZ+deCPYhSpK8x0nqQIDAQABAoIBAESjFFPqc3xVoNRSTLtUOOLDzYwDUODBowXnI/OIIlI84K++GPuK7z+EwKrsRtNKuJ+zzoCrx8Iv/OzFUfP+w6pyWf9hjuFpM3n2Yv7nGrlRuGSL8suasdK1X3SJJyM+DBYv00meM3+Y/5DPhx128fvtMvA8tCplxfOr0MkEXEhn+CBCuaSKo8G3JZSuhl9kcqcBnwCHUg8aJpuFLqgOHE7sV5n9gwtbP0bo49MLJLIwrQzG+XhpdcqW5HguYFcnFoNikTiApS3uzpF5rEGam8QuMSfhqdY5gYIKIkfwpeqP2PE6CT0NQhy6kasUsLC+VCeFbRRKtZunWRmxmntZ2zkCgYEA7PGjMbufaiWA0tZM7OCtZsrU7wPjiB+tmDuTSD+JQz+OSVRA5pqmMeEM9T4dbDeOk1o0nd+si5UNLbMCmTbdkUSwbFOrW4dUufxKHZfN2NbQhRQmiPtkdToBKnkb5TzZtRv1GfUUXfEyhlZ44ZTq7cPdgchlvQWeQ2n6/7PNLBsCgYEA9y3ayNMQ3UIHgo/ATWEZrrAiIKcWoEXo9wTmeJUBKAFR+Mo84PUdNKzZ9VSAa4WjP+JGyer/UuzRBy0tsnDp4gDWxhKc7IUdcqEyvdZ7TBhu+qO6bqU3ByPoj9CU7AC6Ak6wW8m0lh3HBynYGRIeiav+ytnKUoYyFpBbHfor74sCgYBD5rdqwCbeB2NUiF9BHt3ycDv3RvkEgHeCAciiUrrmT6dZ8lArBbSM5L6O5T8PTRiJt7cOaxQKaCt/piYffC6gu7uHP68CqtSn+9nNgzxVYLIfAPhOFyThxz6gSlapKfgFw75IswgkJ8Pf5ZX8p21vt8qZr7EgKyUAkrWAY6lvcwKBgCgwrII6z2MqeU4hUYNDZomg2eu1P1iQBXEkutSgZa+7hziMqZlqQXVvJYFeXAMfl4urnxb1vs4c81/XWLbK5Tx6JnHOVPWgL0mULEvxs9qLnn/iX03eTzQ6AnZf09cLxzLY2JQUF+jQrqvbgeeRqqV38dXJ07vXVg2VKzuUkdBBAoGAL//d/FQwliKQbDhd7hIJgr5r9LmFk8JLyuA4lih3qW5pHtDUnlZSRgL2LKUq8L8eUYjqmjz2NcQxfkIqOhpAo3m0BMoDQfzSHjW5E8M9XdlrQdJsMFeNV4xAEjHUqc9Y8VKt1QFIeH9zWfg4uyb5vhU+t6caQvCi9Bsf+mV0Leo=";
        public const string PublicKey = "MIIBCgKCAQEA5MeVblDfaHYUs4JKzu1HrNZDBlbG8ndCvBbwfSZUPpcEuKkPxo30awZUhZkPb6dpGm+wRYEwvyGAhIVpqWZpRQ76lIbdbm/hNbFfFs/6LCt1Bw+xj7wN0ctgCNyOIcNsCxeIjALGWDrxn5Z8EV6Yry/fd/ZEKUXRaDWYrw5qxjpNA/Ppudc2dPsil5t44dtRUDX5YShi92pQTwd93wt6csBQXgsqInNp6l9ceJ15ixyDs+b0RRkOz/Huw4eQB862C2UKSSRKN6wetqVEkjt3DJg8HoNte7nfADCqP4VoG0DMZJDQ86cdzPIwRfBrZg3hBws0kZ+deCPYhSpK8x0nqQIDAQAB";

        /// <summary>
        /// Serializes the token to a string which can be returned to the client application
        /// </summary>
        public static string Serialize(this JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static Action<JwtBearerOptions> JwtBearerConfigurationOptions = options =>
        {
            string publicKey = JwtUtilities.PublicKey;

            RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new RsaSecurityKey(rsa),
                ValidIssuer = "SwitchFullyAuthenticator",
                ValidAudience = "SwitchfullyAudience",
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ClockSkew = TimeSpan.FromMinutes(3)
            };
        };

        /// <summary>
        /// Options class for creating JWTs
        /// </summary>
        public class JwtTokenOptions
        {
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public List<string> Audiences { get; set; } = new List<string>();
            public string UserName { get; set; }
            public List<Claim> Claims { get; set; } = new List<Claim>();
            public string SigningKey { get; set; }
            public int MinutesToExpiration { get; set; } = 120;
        }

        /// <summary>
        /// Generates a JWT signed with a asymmetric key
        /// </summary>
        public static JwtSecurityToken GenerateJwtSecurityTokenWithAsymmetricSigning(JwtTokenOptions options)
        {
            if (string.IsNullOrEmpty(options.SigningKey)) throw new ArgumentException("Secret SigningKey is required");

            RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(options.SigningKey), out _);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

            return GenerateJwtSecurityToken(options, signingCredentials); ;
        }

        /// <summary>
        /// Generic function to create a JWT
        /// </summary>
        private static JwtSecurityToken GenerateJwtSecurityToken(JwtTokenOptions options, SigningCredentials signingCredentials)
        {
            if (string.IsNullOrEmpty(options.Issuer)) throw new ArgumentException("Issuer is required");
            if (string.IsNullOrEmpty(options.Audience) && options.Audiences.Count() == 0) throw new ArgumentException("Audience is required");

            // add audiences
            if (!string.IsNullOrEmpty(options.Audience)) options.Claims.Add(new Claim(JwtRegisteredClaimNames.Aud, options.Audience));
            if (options.Audiences.Count() > 0) options.Audiences.ForEach(x => options.Claims.Add(new Claim(JwtRegisteredClaimNames.Aud, x)));

            // always add Registered Subject/Username claim
            if (!string.IsNullOrEmpty(options.UserName)) options.Claims.Add(new Claim(JwtRegisteredClaimNames.Sub, options.UserName));

            // make sure JWT is unique
            options.Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                claims: options.Claims.ToArray(),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(options.MinutesToExpiration),
                signingCredentials: signingCredentials
            );

            return jwt;
        }
    }
}