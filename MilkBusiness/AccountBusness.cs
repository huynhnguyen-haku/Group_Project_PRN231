using MilkBusiness.Utils;
using MilkData.DTOs.Account;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class AccountBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        #region Authentization
        public async Task<IMilkResult> Login(string email, string password)
        {
            Account account = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.Email.Equals(email) && a.Password.Equals(password));

            MilkResult result = new MilkResult();

            if (account == null)
            {
                result.Status = -1;
                result.Message = "Incorrect Email or Password";
                return result;
            }

            if (!(bool)account.IsActive)
            {
                result.Status = -1;
                result.Message = "Your account is currently inactive (banned)";
                return result;
            }

            result.Data = JwtUtil.GenerateJwtToken(account);
            result.Status = 1;
            result.Message = "Login successfully";
            return result;
        }

        public async Task<IMilkResult> Register(string email, string password)
        {
            Account account = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.Email.Equals(email) && a.Password.Equals(password));

            MilkResult result = new MilkResult();

            if (account != null)
            {
                result.Status = -1;
                result.Message = "Email has already used";
                return result;
            }

            Account newAccount = new Account
            {
                AccountId = 0,
                FullName = email,
                Password = password,
                Email = email,
                Phone = String.Empty,
                Address = String.Empty,
                Point = 0,
                AvatarUrl = String.Empty,
                Role = "Custmer",
                IsActive = true,
                UserName = String.Empty
            };

            await _unitOfWork.GetRepository<Account>().InsertAsync(newAccount);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Create unsuccessfully";
            }
            else
            {
                result.Data = JwtUtil.GenerateJwtToken(newAccount);
                result.Status = 1;
                result.Message = "Register successfully";
            }

            return result;
        }
        #endregion

        #region Account
        public async Task<IMilkResult> GetAllAccount()
        {
            var accList = await _unitOfWork.GetRepository<Account>()
                .GetListAsync(predicate: a => (bool)a.IsActive,
                              selector: a => new GetAccountDTO
                              {
                                  AccountId = a.AccountId,
                                  Address = a.Address,
                                  AvatarUrl = a.AvatarUrl,
                                  IsActive = a.IsActive,
                                  UserName = a.UserName,
                                  Email = a.Email,
                                  FullName = a.FullName,
                                  Password = a.Password,
                                  Phone = a.Phone,
                                  Point = a.Point,
                                  Role = a.Role
                              });
            return new MilkResult(accList);
        }

        public async Task<IMilkResult> GetAccountInfo(int accountId)
        {
            var acc = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.AccountId == accountId && (bool)a.IsActive,
                                      selector: a => new GetAccountDTO
                                      {
                                          AccountId = a.AccountId,
                                          Address = a.Address,
                                          AvatarUrl = a.AvatarUrl,
                                          IsActive = a.IsActive,
                                          UserName = a.UserName,
                                          Email = a.Email,
                                          FullName = a.FullName,
                                          Password = a.Password,
                                          Phone = a.Phone,
                                          Point = a.Point,
                                          Role = a.Role
                                      });
            if (acc != null) return new MilkResult(acc);
            return new MilkResult();
        }

        public async Task<IMilkResult> GetAccountInfoByEmail(string email)
        {
            var acc = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.Email.Equals(email) && (bool)a.IsActive,
                                      selector: a => new GetAccountDTO
                                      {
                                          AccountId = a.AccountId,
                                          Address = a.Address,
                                          AvatarUrl = a.AvatarUrl,
                                          IsActive = a.IsActive,
                                          UserName = a.UserName,
                                          Email = a.Email,
                                          FullName = a.FullName,
                                          Password = a.Password,
                                          Phone = a.Phone,
                                          Point = a.Point,
                                          Role = a.Role
                                      });
            if (acc != null) return new MilkResult(acc);
            return new MilkResult();
        }

        public async Task<IMilkResult> CreateAccount(AccountDTO inputedAccount)
        {
            Account account = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.Email.Equals(inputedAccount.Email));

            MilkResult result = new MilkResult();

            if (account != null)
            {
                result.Status = -1;
                result.Message = "Email has already used";
                return result;
            }

            Account newAccount = new Account
            {
                FullName = inputedAccount.FullName,
                Password = inputedAccount.Password,
                Email = inputedAccount.Email,
                Phone = inputedAccount.Phone,
                Address = inputedAccount.Address,
                Point = inputedAccount.Point,
                AvatarUrl = inputedAccount.AvatarUrl,
                Role = inputedAccount.Role,
                IsActive = true,
                UserName = inputedAccount.UserName,
            };

            await _unitOfWork.GetRepository<Account>().InsertAsync(newAccount);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Create unsuccessfully";
            }
            else
            {
                result = new MilkResult(1, "Create Susscessfull");
            }

            return result;
        }

        public async Task<IMilkResult> UpdateAccountInfo(int id, AccountDTO accInfo)
        {
            Account currentAcc = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.AccountId == id);
            if (currentAcc == null) return new MilkResult(-1, "Account cannot be found");
            else
            {
                currentAcc.FullName = String.IsNullOrEmpty(accInfo.FullName) ? currentAcc.FullName : accInfo.FullName;
                currentAcc.Role = String.IsNullOrEmpty(accInfo.Role) ? currentAcc.Role : accInfo.Role;
                currentAcc.Email = String.IsNullOrEmpty(accInfo.Email) ? currentAcc.Email : accInfo.Email;
                currentAcc.Password = String.IsNullOrEmpty(accInfo.Password) ? currentAcc.Password : accInfo.Password;
                currentAcc.Address = String.IsNullOrEmpty(accInfo.Address) ? currentAcc.Address : accInfo.Address;
                currentAcc.Phone = String.IsNullOrEmpty(accInfo.Phone) ? currentAcc.Phone : accInfo.Phone;
                currentAcc.AvatarUrl = String.IsNullOrEmpty(accInfo.AvatarUrl) ? currentAcc.AvatarUrl : accInfo.AvatarUrl;
                currentAcc.UserName = String.IsNullOrEmpty(accInfo.UserName) ? currentAcc.UserName : accInfo.UserName;
                currentAcc.Point = accInfo.Point;
                currentAcc.IsActive = accInfo.IsActive;

                _unitOfWork.GetRepository<Account>().UpdateAsync(currentAcc);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(accInfo);
        }

        public async Task<IMilkResult> DeleteAccount(int id)
        {
            Account currentAcc = await _unitOfWork.GetRepository<Account>()
               .SingleOrDefaultAsync(predicate: a => a.AccountId == id);
            if (currentAcc == null) return new MilkResult(-1, "Account cannot be found");
            else
            {
                _unitOfWork.GetRepository<Account>().DeleteAsync(currentAcc);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult("Delete Successfull");
        }

        public async Task<IMilkResult> BanAccount(int accountId)
        {
            Account account = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.AccountId == accountId);
            if (account == null) return new MilkResult();
            else
            {
                account.IsActive = false;

                _unitOfWork.GetRepository<Account>().UpdateAsync(account);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult("Banned");
        }
        #endregion
    }
}
