using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
	public interface IUserService
	{
		List<OperationClaim> GetClaims(User user);
		User GetByMail(string mail);

		IResult Add(User user);
		IResult Update(User user);
		IResult Remove(User user);
	}
}

