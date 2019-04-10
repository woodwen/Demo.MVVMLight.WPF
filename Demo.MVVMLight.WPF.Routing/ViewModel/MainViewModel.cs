namespace Demo.MVVMLight.WPF.Routing.ViewModel
{
    using System.Windows.Input;

    using CommonServiceLocator;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationTitle;
        private INavigationService _navigationService;

        #endregion Fields

        #region Constructors

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ApplicationTitle = "MVVMLight WPF Demo - Routing!";
            GoBackCommand = new RelayCommand(GoBack);
            ShowAboutCommand = new RelayCommand(ShowAbout);
            ShowContactCommand = new RelayCommand(ShowContact);
            ShowHomeCommand = new RelayCommand(ShowHome);
        }

        #endregion Constructors

        #region Properties

        public string ApplicationTitle
        {
            get { return _applicationTitle; }
            set
            {
                Set(() => _applicationTitle, ref _applicationTitle, value);
            }
        }

        public ICommand GoBackCommand
        {
            get; private set;
        }

        public ICommand ShowAboutCommand
        {
            get; private set;
        }

        public ICommand ShowContactCommand
        {
            get; private set;
        }

        public ICommand ShowHomeCommand
        {
            get; private set;
        }

        #endregion Properties

        #region Methods

        private void GoBack()
        {
            _navigationService.GoBack();
        }

        private void ShowAbout()
        {
            // ������AboutViewModel
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            navigationService.NavigateTo("About");
        }

        private void ShowContact()
        {
            // ������ContactViewModel
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            navigationService.NavigateTo("Contact");
        }

        private void ShowHome()
        {
            // ������HomeViewModel
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            navigationService.NavigateTo("Home");
        }

        #endregion Methods
    }
}