namespace Demo.MVVMLight.WPF.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Views;

    public class NavigationService : ViewModelBase, INavigationService
    {
        #region Fields

        private readonly List<string> _historic;
        private readonly Dictionary<string, Uri> _pagesByKey;

        private string _currentPageKey;

        #endregion Fields

        #region Constructors

        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new List<string>();
        }

        #endregion Constructors

        #region Properties

        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                Set(() => CurrentPageKey, ref _currentPageKey, value);
            }
        }

        public object Parameter
        {
            get; private set;
        }

        #endregion Properties

        #region Methods

        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }

        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);

                NavigateTo(_historic.Last(), "Back");
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

                if (frame != null)
                {
                    frame.Source = _pagesByKey[pageKey];
                }
                Parameter = parameter;
                if (parameter.ToString().Equals("Next"))
                {
                    _historic.Add(pageKey);
                }
                CurrentPageKey = pageKey;
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }

        #endregion Methods
    }
}