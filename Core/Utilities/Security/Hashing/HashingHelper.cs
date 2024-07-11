using System;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
	public class HashingHelper
	{
		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = GetHmac())
			{
				passwordSalt = hmac.Key;
				passwordHash = ConvertToHash(hmac, password);
			}
		}

		public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = GetHmac(passwordSalt))
			{
				var computedHash = ConvertToHash(hmac, password);

                for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != passwordHash[i])
					{
						return false;
					}
				}

				return true;
			}
		}

		private static System.Security.Cryptography.HMACSHA512 GetHmac(byte[] passwordSalt = null)
		{
			if(passwordSalt != null)
				return new System.Security.Cryptography.HMACSHA512(passwordSalt);

			return new System.Security.Cryptography.HMACSHA512();
        }

		private static byte[] ConvertToHash(System.Security.Cryptography.HMACSHA512 hmac, string password)
		{
			return hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));
		}
	}
}

