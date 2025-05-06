using FCMPushNotificationsSample.Services;
using Plugin.Firebase.CloudMessaging;

namespace FCMPushNotificationsSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var service = new NotificationPermissionService();
            var status = await service.CheckAndRequestNotificationPermissionAsync();

            if (status == PermissionStatus.Granted)
            {
                await DisplayAlert("Erfolg", "Benachrichtigungserlaubnis erteilt!", "OK");
            }
            else
            {
                await DisplayAlert("Hinweis", "Benachrichtigungserlaubnis wurde nicht erteilt.", "OK");
            }
            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        }
        private async void OnCounterClicked2(object sender, EventArgs e)
        {
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            Console.WriteLine($"FCM token: {token}");
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = token,
                Title = "FCM Token"
            });
        }
        private async void OnCounterClicked3(object sender, EventArgs e)
        {
            await CrossFirebaseCloudMessaging.Current.SubscribeToTopicAsync(topicEntry.Text);
            await Shell.Current.DisplayAlert("Subscribed", $"Subscribed to {topicEntry.Text}", "OK");
        }
    }

}
