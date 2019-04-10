using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.MVVMLight.WPF.Routing.ViewModel
{
    public class HomeViewModel: ViewModelBase
    {
        #region Fields

        private string _viewTitle;

        #endregion Fields

        #region Constructors

        public HomeViewModel()
        {
            ViewTitle = "Home View";
        }

        #endregion Constructors

        #region Properties

        public string ViewTitle
        {
            get => _viewTitle;
            set => Set(() => ViewTitle, ref _viewTitle, value);
        }

        #endregion Properties
    }
}
