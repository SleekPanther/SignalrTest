using Microsoft.AspNet.SignalR;
using SignalrMessenger;
using System.Collections.Generic;

public static class NotificationsResourceHandler
{
    private static readonly IHubContext myContext;
    public static Dictionary<string, string> Groups;

    static NotificationsResourceHandler()
    {
        myContext = GlobalHost.ConnectionManager.GetHubContext<SignalrHub>();
        Groups = new Dictionary<string, string>();
    }

    //public static void BroadcastNotification(dynamic model, NotificationType notificationType, string userName)
    public static void BroadcastNotification(dynamic model, string userName)
    {
        //myContext.Clients.Group(userName).PushNotification(new { Data = model, Type = notificationType.ToString() });
        myContext.Clients.Group(userName).PushNotification(new { Data = model, });
    }
}