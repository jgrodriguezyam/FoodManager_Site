using System;
using System.Web;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exceptions.Session;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Security;

namespace FoodManager.Infrastructure.Settings
{
    public static class SessionSettings
    {
        #region Assign

        public static void AssignAllSessions()
        {
            if (!ExistsUserId && !ExistsWorkerId)
            {
                AssignTicks();
                AssignUserId(0);
                AssignDealerId(0);
                AssignUserName(String.Empty);
                AssignPublicKey(String.Empty);
                AssignWorkerId(0);
                AssignBranchId(0);
                AssignFirstName(String.Empty);
                AssignBadge(String.Empty);
                AssignLimitEnergy(0);
                AssignPassword(String.Empty);
                AssignContextModel(String.Empty);
                AssignIdCreated(0);
            }

            if (!ExistsLoginType)
            {
                AssignLoginType(LoginType.User);
            }
        }

        public static void AssignTicks()
        {
            HttpContext.Current.Session.Add(SessionConstants.Ticks, DateTimeExtensions.GetTicksNow());
        }

        public static void AssignLoginType(LoginType loginType)
        {
            HttpContext.Current.Session.Add(SessionConstants.LoginType, loginType);
        }

        public static void AssignUserName(string userName)
        {
            HttpContext.Current.Session.Add(SessionConstants.UserName, userName);
        }

        public static void AssignPublicKey(string publicKey)
        {
            HttpContext.Current.Session.Add(SessionConstants.PublicKey, Cryptography.Encrypt(publicKey));
        }

        public static void AssignWorkerId(int workerId)
        {
            HttpContext.Current.Session.Add(SessionConstants.WorkerId, workerId);
        }

        public static void AssignBranchId(int branchId)
        {
            HttpContext.Current.Session.Add(SessionConstants.BranchId, branchId);
        }

        public static void AssignFirstName(string firstName)
        {
            HttpContext.Current.Session.Add(SessionConstants.FirstName, firstName);
        }

        public static void AssignBadge(string badge)
        {
            HttpContext.Current.Session.Add(SessionConstants.Badge, Cryptography.Encrypt(badge));
        }

        public static void AssignLimitEnergy(int limitEnergy)
        {
            HttpContext.Current.Session.Add(SessionConstants.LimitEnergy, limitEnergy);
        }

        public static void AssignUserId(int userId)
        {
            HttpContext.Current.Session.Add(SessionConstants.UserId, userId);
        }

        public static void AssignDealerId(int dealerId)
        {
            HttpContext.Current.Session.Add(SessionConstants.DealerId, dealerId);
        }

        public static void AssignPassword(string password)
        {
            HttpContext.Current.Session.Add(SessionConstants.Password, Cryptography.Encrypt(password));
        }

        public static void AssignContextModel(object contextModel)
        {
            HttpContext.Current.Session.Add(SessionConstants.ContextModel, contextModel);
        }

        public static void AssignIdCreated(int id)
        {
            HttpContext.Current.Session.Add(SessionConstants.IdCreated, id);
        }

        #endregion

        #region Retrieve

        public static string RetrieveTicks
        {
            get { return HttpContext.Current.Session[SessionConstants.Ticks].ToString(); }
        }

        public static LoginType RetrieveLoginType
        {
            get
            {
                return (LoginType)HttpContext.Current.Session[SessionConstants.LoginType];
            }
        }

        public static string RetrieveUserName
        {
            get { return HttpContext.Current.Session[SessionConstants.UserName].ToString(); }
        }

        public static string RetrievePublicKey
        {
            get
            {
                try
                {
                    return Cryptography.Decrypt(HttpContext.Current.Session[SessionConstants.PublicKey].ToString());
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static int RetrieveWorkerId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.WorkerId]); }
        }

        public static int RetrieveDealerId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.DealerId]); }
        }

        public static int RetrieveBranchId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.BranchId]); }
        }

        public static string RetrieveFirstName
        {
            get { return HttpContext.Current.Session[SessionConstants.FirstName].ToString(); }
        }

        public static string RetrieveBadge
        {
            get { return Cryptography.Decrypt(HttpContext.Current.Session[SessionConstants.Badge].ToString()); }
        }

        public static int RetrieveLimitEnergy
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.LimitEnergy]); }
        }

        public static int RetrieveUserId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.UserId]); }
        }

        public static string RetrievePassword
        {
            get { return Cryptography.Decrypt(HttpContext.Current.Session[SessionConstants.Password].ToString()); }
        }

        public static string RetrieveContextModel
        {
            get { return HttpContext.Current.Session[SessionConstants.ContextModel].ToString(); }
        }

        public static int RetrieveIdCreated
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.IdCreated]); }
        }

        #endregion

        #region Remove

        public static void RemoveAllSessions()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        #endregion

        #region Exists

        public static bool ExistsWorkerId
        {
            get {
                try
                {
                    return RetrieveWorkerId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ExistsBranchId
        {
            get
            {
                try
                {
                    return RetrieveBranchId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ExistsDealerId
        {
            get
            {
                try
                {
                    return RetrieveDealerId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ExistsUserId
        {
            get
            {
                try
                {
                    return RetrieveUserId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ExistsLoginType
        {
            get
            {
                try
                {
                    return RetrieveLoginType.IsNotNull();
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion


    }
}