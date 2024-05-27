using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Switchfully.DotNetToolkit.Authentication
{
    /// <summary>
    /// Can be used to check the specified claim for an authenticated user.
    /// 
    /// One of the values must be present in the specified claim
    ///	[AuthorizeClaim("MyClaim", "value1,value2,value3")]
    /// 
    /// Remark: Don't use this attribute to check for scope claims as these claims can have multiple claim types and multiple scope values can be joined in a space-separated string ! Use the AuthorizeScopeAttribute instead.
    /// </summary>
    public class AuthorizeClaimAttribute : TypeFilterAttribute
	{
		public AuthorizeClaimAttribute(string claimType, string allowedValues) : base(typeof(AuthorizeClaimFilter))
		{
			Arguments = new object[] { claimType, allowedValues };
		}

		public class AuthorizeClaimFilter : IAuthorizationFilter
		{
			private string _claimType;
			readonly string[] _allowedValues;

			public AuthorizeClaimFilter(string claimType, string allowedValues)
			{
				_claimType = claimType;
				_allowedValues = allowedValues.Split(',').Select(x => x.Trim()).ToArray();
			}

			public void OnAuthorization(AuthorizationFilterContext context)
			{
				// ClaimTypeMapping
				if (_claimType.Equals("name", StringComparison.OrdinalIgnoreCase)) _claimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
				else if (_claimType.Equals("role", StringComparison.OrdinalIgnoreCase)) _claimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
				else if (_claimType.Equals("sub", StringComparison.OrdinalIgnoreCase)) _claimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
				else if (_claimType.Equals("email", StringComparison.OrdinalIgnoreCase)) _claimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
				else if (_claimType.Equals("clientip", StringComparison.OrdinalIgnoreCase)) _claimType = "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-client-ip";

				// collect all claims
				var claims = context.HttpContext.User.Claims.Where(c => string.Equals(c.Type, _claimType, StringComparison.OrdinalIgnoreCase));

				// collect all values
				var values = claims.Select(c => c.Value);

				// check if one of the allowed values can be found in the user's claims
				var hasClaim = values.Any(s => _allowedValues.Contains(s, StringComparer.OrdinalIgnoreCase));

				if (!hasClaim)
				{
					context.Result = new ForbidResult();
				}
			}
		}
	}
}
