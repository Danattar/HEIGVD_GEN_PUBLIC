using Caliburn.Micro;

namespace GTTClientFrontend.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                NotifyOfPropertyChange(nameof(Username));
            }
        }
        public void Save()
        {
            TryClose(true);
        }
        public void Cancel()
        {
            TryClose(false);
        }

    }
}
