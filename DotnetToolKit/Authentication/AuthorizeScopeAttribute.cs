using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Switchfully.DotNetToolkit.Authentication
{
    /// <summary>
    /// Can be used to check the scope claims for an authenticated user.
    /// 
    /// One of the listed scopes must be present
    ///	[AuthorizeScope("jobs.read,jobs.write")]
    /// 
    /// Both scopes must be present
    /// [AuthorizeScope("jobs.read")]
    /// [AuthorizeScope("jobs.write")]
    /// </summary>
    public class AuthorizeScopeAttribute : TypeFilterAttribute
	{
		public AuthorizeScopeAttribute(string allowedScopes) : base(typeof(AuthorizeScopeFilter))
		{
			Arguments = new object[] { allowedScopes };
		}

		public class AuthorizeScopeFilter : IAuthorizationFilter
		{
			readonly string[] _allowedScopes;

			public AuthorizeScopeFilter(string allowedScopes)
			{
				_allowedScopes = allowedScopes.Split(',');
			}

			public void OnAuthorization(AuthorizationFilterContext context)
			{
				// first, check if user is authenticated
				if (!context.HttpContext.User.Identity.IsAuthenticated)
				{
					context.Result = new UnauthorizedResult();
				}
				else
				{
					// collect all scope claims
					var scopeClaims = context.HttpContext.User.Claims.Where(c => _scopeClaimTypes.Contains(c.Type));

					// collect all values + split on space separator
					var scopeValues = scopeClaims.SelectMany(c => c.Value.Split(' '));

					// check if one of the allowed scopes can be found in the user's scopes
					var hasScope = scopeValues.Any(s => _allowedScopes.Contains(s, StringComparer.OrdinalIgnoreCase));

					if (!hasScope)
					{
						context.Result = new ForbidResult();
					}
				}
			}

			private static readonly IEnumerable<string> _scopeClaimTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
			{
				"http://schemas.microsoft.com/identity/claims/scope",
				"scope",
				"scp"
			};
		}
	}
}
