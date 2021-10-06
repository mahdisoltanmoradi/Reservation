using Microsoft.AspNetCore.Http;
using Practies.Core.DTOs;
using Practies.DataLayer.Entities.FoodPrograms;
using Practies.DataLayer.Entities.Users;
using Practies.DataLayer.Entities.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practies.Core.Services.Interface
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User IsExistEmailAndPassword(LoginViewModel login);
        User GetUserByEmail(string email);
        User IsExistUserByUserEmail(string email);
        void UpdateUser(User user);
        User GetUserByUserName(string userName);
        int GetUserIdByUserName(string userName);
        bool ActiveAccount(string activeCode);
        User GetUserByUserId(int userId);
        void DeleteUser(int userId);
        List<User> GetAllUsers();
        List<User> GetAllDeleteUser();
        List<Factor> GetFoodUser(int userId);
        
        #region User Panel
        //InformationViewModel GetUserInformation(int userId);
        InformationViewModel GetUserInformation(int userId);
        SideBarUserPanelViewModel GetSideBarPanelDate(string userName);
        EditProfileViewModel GetDataForEditProfileUser(string userName);
        void EditProfile(string userName, EditProfileViewModel edit);
        void UplodeFile(int userId, IFormFile formFile);
       
        #endregion

        #region Wallet
        int BalanceUserWallet(string userName);
        List<WalletViewModel> GetWalletUser(string userName);
        int ChargeWallet(string userName,int amount,string description,bool isPay=false);
        int AddWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);
        #endregion

        #region Admin Panel
        UserForAdminViewModel GetUsers(int pageId=1,string filterName="",string filterEmail = "");
        UserForAdminViewModel GetDeleteUser(int pageId = 1, string filterName = "", string filterEmail = "");
        int AddUserFromAdmin(CreateUserViewModel create);
        EditUserViewModel GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(EditUserViewModel editUser, int? id = null);
        #endregion

       

    }
}
