﻿using PresenceConnectionManager.Handler.Buddy.SendBlockList;
using PresenceConnectionManager.Handler.Buddy.SendBuddies;
using System;
using System.Collections.Generic;

namespace PresenceConnectionManager.Handler.General.SDKExtendFeature
{
    public static class SDKRevision
    {
        /// <summary>
        /// Extended message support
        /// </summary>
        public const int GPINewAuthNotification = 1;
        
        public const int GPINewRevokeNotification = 2;
        /// <summary>
        /// New Status Info support
        /// </summary>
        public const int GPINewStatusNotification = 4;
        /// <summary>
        /// Buddy List + Block List retrieval on login
        /// </summary>
        public const int GPINewListRetrevalOnLogin = 8;
        /// <summary>
        /// Remote Auth logins now return namespaceid/partnerid on login
        /// </summary>
        public const int GPIRemoteAuthIDSNotification = 16;
        /// <summary>
        /// New CD Key registration style as opposed to using product ids
        /// </summary>
        public const int GPINewCDKeyRegistration = 32;

        public const int Crysis2SDKRevision =
            Type3;


        public const int Type1 =
            GPINewAuthNotification +
            GPINewRevokeNotification +
            GPINewListRetrevalOnLogin;

        public const int Type2 =
            GPINewAuthNotification +
            GPINewRevokeNotification +
            GPINewStatusNotification +
            GPINewListRetrevalOnLogin;

        public const int Type3 =
            GPINewAuthNotification +
            GPINewRevokeNotification +
            GPINewListRetrevalOnLogin +
            GPINewCDKeyRegistration;

        public const int Type4 =
            GPINewAuthNotification +
            GPINewRevokeNotification +
            GPINewListRetrevalOnLogin +
            GPIRemoteAuthIDSNotification +
            GPINewCDKeyRegistration;
        /// <summary>
        /// Tell server send back extra information according to the number of  sdkrevision
        /// </summary>
        public static void Switch(GPCMSession session, Dictionary<string, string> recv)
        {
            switch (Convert.ToInt32(session.PlayerInfo.SDKRevision))
            {
                case Type1:
                    SendBuddiesHandler.SendBuddyList(session);
                    SendBlockListHandler.SendBlockList(session);
                    break;
                case Type2:
                    SendBuddiesHandler.SendBuddyList(session);
                    SendBlockListHandler.SendBlockList(session);
                    break;
                case Type3:
                    SendBuddiesHandler.SendBuddyList(session);
                    break;
                case Type4:
                    SendBuddiesHandler.SendBuddyList(session);
                    break;
                default:
                    session.ToLog("No sdkrevision found");
                    break;
            }
        }
    }
}
