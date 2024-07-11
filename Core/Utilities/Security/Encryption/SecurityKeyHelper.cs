using System;
using Core.Utilities.Security.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
	public class SecurityKeyHelper
	{
		public static SecurityKey CreateSecurityKey(string securityKey)
        {
			return new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey));
        }
	}
}

