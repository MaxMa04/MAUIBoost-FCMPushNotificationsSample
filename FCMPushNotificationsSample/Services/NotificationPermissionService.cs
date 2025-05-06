using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMPushNotificationsSample.Services
{
    public class NotificationPermissionService
    {
        public async Task<PermissionStatus> CheckAndRequestNotificationPermissionAsync()
        {
            // Prüfe, ob die Plattform Berechtigungen unterstützt
          
                var status = await Permissions.CheckStatusAsync<Permissions.PostNotifications>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.PostNotifications>();
                }

                return status;
        }
    }
}
