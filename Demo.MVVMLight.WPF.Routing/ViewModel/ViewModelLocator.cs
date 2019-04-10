namespace Demo.MVVMLight.WPF.Routing.ViewModel
{
    using System;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Views;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ContactViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register(() => CreateNavigationService());
        }

        #endregion Constructors

        #region Properties

        public AboutViewModel About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        public ContactViewModel Contact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContactViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        #endregion Properties

        #region Methods

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("About", new Uri("/Demo.MVVMLight.WPF.Routing;component/View/About.xaml", UriKind.Relative));
            navigationService.Configure("Contact", new Uri("/Demo.MVVMLight.WPF.Routing;component/View/Contact.xaml", UriKind.Relative));
            navigationService.Configure("Home", new Uri("/Demo.MVVMLight.WPF.Routing;component/View/Home.xaml", UriKind.Relative));
            return navigationService;
        }

        #endregion Methods
    }
}