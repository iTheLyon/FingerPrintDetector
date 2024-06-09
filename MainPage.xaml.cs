using Plugin.Maui.Biometric;

namespace FingerPrintDetector
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var result = await BiometricAuthenticationService.Default.AuthenticateAsync(new AuthenticationRequest()
            {
                Title = "Por favor auntenticar para contar",
                NegativeText = "Autenticacion cancelada"
            }, CancellationToken.None);

            if (result.Status == BiometricResponseStatus.Success)
            {
                count++;

                if (count == 1)
                    CounterBtn.Text = $"Clicked {count} time";
                else
                    CounterBtn.Text = $"Clicked {count} times";

                SemanticScreenReader.Announce(CounterBtn.Text);
            }
            else
            {
                await DisplayAlert("Error", "no se pudo autenticar", "OK");
            }
        }
    }

}
