using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Settings;

namespace FoodManager.Infrastructure.Security
{
    public static class Hmac
    {     
        public static string GeneratePrivateKey()
        {
            if (SessionSettings.RetrieveWorkerId.IsGreaterThanZero() || SessionSettings.RetrieveUserId.IsGreaterThanZero())
            {
                var securityMessage = ResolveSecurityMessage();
                var privateKey = EncodingHash(securityMessage);
                return privateKey;
            }
            return String.Empty;
        }

        private static string ResolveSecurityMessage()
        {
            var securityMessage = String.Empty;
            if (SessionSettings.RetrieveUserId.IsGreaterThanZero())
                securityMessage = String.Concat(SessionSettings.RetrieveUserName, SessionSettings.RetrievePassword, SessionSettings.RetrieveTicks);
            if (SessionSettings.RetrieveWorkerId.IsGreaterThanZero())
                securityMessage = String.Concat(SessionSettings.RetrieveBadge, SessionSettings.RetrieveTicks);
            return securityMessage;
        }

        private static string EncodingHash(string securityMessage)
        {
            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(SystemConstants.Key);
            var messageBytes = encoding.GetBytes(securityMessage);

            var hmacsha256 = new HMACSHA256(keyByte);
            var hash256Message = hmacsha256.ComputeHash(messageBytes);
            return ByteToString(hash256Message);
        }

        private static string ByteToString(IEnumerable<byte> buff)
        {
            var sbinary = buff.Aggregate("", (current, t) => current + t.ToString("X2"));
            return (sbinary);
        }
    }
}