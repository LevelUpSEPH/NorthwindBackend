using System;
using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(message: Messages.UserAdded);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(filter: u => u.Email == mail);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Remove(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult(message: Messages.UserRemoved);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult(message: Messages.UserUpdated);
        }
    }
}

