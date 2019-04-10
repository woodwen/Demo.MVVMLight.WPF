namespace Demo.MVVMLight.WPF.Bindings.ViewModel
{
    using System;

    using GalaSoft.MvvmLight;

    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationTitle;
        private string _valueOne;
        private long _valueTwo;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainViewModel()
        {
            //初始化属性
            ApplicationTitle = "MVVMLight WPF Demo - Bindings";
            ValueOne = "Type somthing";
            ValueTwo = DateTime.Now.Date.ToFileTime();
        }

        #endregion Constructors

        #region Properties

        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => Set(() => ApplicationTitle, ref _applicationTitle, value);
        }

        public string ValueOne
        {
            get => _valueOne;
            set => Set(() => ValueOne, ref _valueOne, value);
        }

        public long ValueTwo
        {
            get => _valueTwo;
            set => Set(() => ValueTwo, ref _valueTwo, value);
        }

        #endregion Properties
    }
}