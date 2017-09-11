using Windows.Foundation;
using Windows.System;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace Northwind.NET.Services
{
    public class ToastNotificationService
    {
        private ToastNotificationService() { }

        private static ToastNotificationService current;

        public static ToastNotificationService Current => current ?? (current = new ToastNotificationService());

        public void FireToastNotification(string message)
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);

            var textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode(message));

            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
}
