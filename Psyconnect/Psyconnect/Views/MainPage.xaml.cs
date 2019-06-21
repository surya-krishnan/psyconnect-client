using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Psyconnect.Client;

namespace Psyconnect
{
    public partial class MainPage : ContentPage
    {
        public static string _username;
        private string _password;
        private bool _areCredentialsInvalid;

        public MainPage()
        {
            InitializeComponent();

            AuthenticateCommand = new Command(() =>
            {
                AreCredentialsInvalid = !UserAuthenticated(Username, Password);
                if (AreCredentialsInvalid) { DisplayAlert("Login failed", "Incorrect username and password", "OK"); return; };

                //Navigation.PopModalAsync();

            });

            AreCredentialsInvalid = false;
        }

        private bool UserAuthenticated(string username, string password)
        {
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
            {
                return false;
            }


            return Client.Client.Verify(username, password);
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand AuthenticateCommand { get; set; }

        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                if (value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                OnPropertyChanged(nameof(AreCredentialsInvalid));
            }
        }
    }
}
