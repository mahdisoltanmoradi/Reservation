using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Practies.Core.Convertors;
using Practies.Core.DTOs;
using Practies.Core.Generator;
using Practies.Core.Security;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Context;
using Practies.DataLayer.Entities.FoodPrograms;
using Practies.DataLayer.Entities.Users;
using Practies.DataLayer.Entities.Wallets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Practies.Core.Services
{
    public class UserService : IUserService
    {
        private PractiesContext _context;

        public UserService(PractiesContext context)
        {
            this._context = context;
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;

        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public User IsExistEmailAndPassword(LoginViewModel login)
        {
            string FixeEmail = FixedText.FixeEmail(login.Email);
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            return _context.Users.SingleOrDefault(u => u.Email == login.Email&&u.Password==hashPassword);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();

        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }

     

        public SideBarUserPanelViewModel GetSideBarPanelDate(string userName)
        {
            return _context.Users.Where(u => u.UserName == userName)
                 .Select(u => new SideBarUserPanelViewModel
                 {
                     UserName = u.UserName,
                     RegisterDate = u.RegisterDate,
                     ImageName = u.UserAvatar
                 }).Single();

        }

        public EditProfileViewModel GetDataForEditProfileUser(string userName)
        {
            return _context.Users.Where(u => u.UserName == userName)
                .Select(u => new EditProfileViewModel
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    AvatarName = u.UserAvatar
                }).Single();
        }

        public void EditProfile(string userName, EditProfileViewModel edit)
        {
            if (edit.UserAvatar != null)
            {
                string imagePath = "";
                if (edit.AvatarName == "Defult.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", edit.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                edit.AvatarName = NameGenerator.GeneratorUniqCode() + Path.GetExtension(edit.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", edit.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    edit.UserAvatar.CopyTo(stream);
                }

            }
            var user = GetUserByUserName(userName);
            user.UserName = edit.UserName;
            user.Email = edit.Email;
            user.UserAvatar = edit.AvatarName;

            UpdateUser(user);
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public int BalanceUserWallet(string userName)
        {
            int userId = GetUserIdByUserName(userName);

            var deposit = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay)
                .Select(w => w.Amount).ToList();

            var harvest = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2)
                .Select(w => w.Amount).ToList();

            return (deposit.Sum() - harvest.Sum());

        }

        public List<WalletViewModel> GetWalletUser(string userName)
        {
            int userId = GetUserIdByUserName(userName);

            return _context.Wallets.Where(w => w.IsPay && w.UserId == userId)
                .Select(w => new WalletViewModel()
                {
                    Amount = w.Amount,
                    DateTime = w.CreateDate,
                    Description = w.Description,
                    Type = w.TypeId
                }).ToList();
        }

        public int ChargeWallet(string userName, int amount, string description, bool isPay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                IsPay = isPay,
                TypeId = 1,
                UserId = GetUserIdByUserName(userName)
            };

            return AddWallet(wallet);
        }

        public int AddWallet(Wallet wallet)
        {
            _context.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _context.Wallets.Find(walletId);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Update(wallet);
            _context.SaveChanges();

        }

        public UserForAdminViewModel GetUsers(int pageId = 1, string filterName = "", string filterEmail = "")
        {
            IQueryable<User> result = _context.Users;

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(u => u.UserName.Contains(filterName));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel List = new UserForAdminViewModel();
            List.CurrentPage = pageId;
            List.PageCount = result.Count() / take;
            List.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return List;
        }



        public UserForAdminViewModel GetDeleteUser(int pageId = 1, string filterName = "", string filterEmail = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(u => u.IsDelete); ;

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(u => u.UserName.Contains(filterName));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel List = new UserForAdminViewModel();
            List.CurrentPage = pageId;
            List.PageCount = result.Count() / take;
            List.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return List;
        }

        public int AddUserFromAdmin(CreateUserViewModel create)
        {
            User user = new User();
            user.Password = PasswordHelper.EncodePasswordMd5(create.Password);
            user.UserName = create.UserName;
            user.Email = create.Email;
            user.ActiveCode = NameGenerator.GeneratorUniqCode();
            user.IsActive = true;
            user.RegisterDate = DateTime.Now;

            #region Save Avatar
            if (create.UserAvatar != null)
            {
                string imagePath = "";

                user.UserAvatar = NameGenerator.GeneratorUniqCode() + Path.GetExtension(create.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    create.UserAvatar.CopyTo(stream);
                }
            }
            #endregion 
            return AddUser(user);

        }

        public EditUserViewModel GetUserForShowInEditMode(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId)
                .Select(u => new EditUserViewModel()
                {
                    UserId = u.UserId,
                    AvatarName = u.UserAvatar,
                    Email = u.Email,
                    UserName = u.UserName,
                    UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()
                }).Single();
        }

        public void EditUserFromAdmin(EditUserViewModel editUser,int? id=null)
        {
            User user = GetUserByUserId(id!=null?(int)id:editUser.UserId);
            user.UserName = editUser.UserName;
            user.Email = editUser.Email;

            if (editUser.UserAvatar != null)
            {
                if (editUser.AvatarName != "Defult.jpg")
                {
                    string deletPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUser.AvatarName);
                    if (File.Exists(deletPath))
                    {
                        File.Delete(deletPath);
                    }
                }

                user.UserAvatar = NameGenerator.GeneratorUniqCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }
            }
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void DeleteUser(int userId)
        {
            User user = GetUserByUserId(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public InformationViewModel GetUserInformation(int userId)
        {
            var user = GetUserByUserId(userId);

            InformationViewModel information = new InformationViewModel();

            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.TodayFood = GetFoodUser(userId);
            information.Wallet = BalanceUserWallet(user.UserName);

            return information;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User IsExistUserByUserEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GeneratorUniqCode();
            _context.SaveChanges();
            return true;
        }

        public List<Factor> GetFoodUser(int userId)
        {
            return _context.Factors.Include(f=>f.Food).Where(u => u.User_Id == userId && DateTime.Equals(u.dateTime.Date, DateTime.Now.Date)).ToList();
        }

        public void UplodeFile(int userId, IFormFile formFile)
        {
            var user = GetUserByUserId(userId);
            string imagePath = "";
            if (user.UserAvatar != "Defult.jpg")
            {
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar/", user.UserAvatar);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
            user.UserAvatar = NameGenerator.GeneratorUniqCode() + Path.GetExtension(formFile.FileName);
            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar/",user.UserAvatar);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<User> GetAllDeleteUser()
        {
            return _context.Users.IgnoreQueryFilters().Where(u => u.IsDelete).ToList();

        }
    }
}
