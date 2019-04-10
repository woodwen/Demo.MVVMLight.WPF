namespace Demo.MVVMLight.WPF.Commands.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows;

    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationTitle;
        private string _withCanExecuteParameter;

        #endregion Fields

        #region Constructors

        public MainViewModel()
        {
            // 设置属性
            ApplicationTitle = "ReactiveUI Winforms Demo - Commands";

            // 创建无参数命令
            ParameterlessCommand = new RelayCommand(() => Parameterless());

            // 使用参数创建命令
            WithParameterCommand = new RelayCommand<string>(msg => WithParameter(msg));

            // 带判断执行创建命令
            WithCanExecuteCommand = new RelayCommand<string>(msg => WithCanExecute(msg), msg=> !string.IsNullOrWhiteSpace(msg));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 标题
        /// </summary>
        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => Set(() => ApplicationTitle, ref _applicationTitle, value);
        }

        /// <summary>
        /// 无参数命令
        /// </summary>
        public RelayCommand ParameterlessCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// 带参数可执行命令
        /// </summary>
        public RelayCommand<string> WithCanExecuteCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// 带参数命令
        /// </summary>
        public RelayCommand<string> WithParameterCommand
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        private void Parameterless()
        {
            MessageBox.Show("You pressed the button!", ApplicationTitle, MessageBoxButton.OK);
        }

        private void WithCanExecute(string message)
        {
            MessageBox.Show(message, ApplicationTitle, MessageBoxButton.OK);
        }

        private void WithParameter(string message)
        {
            MessageBox.Show(message, ApplicationTitle, MessageBoxButton.OK);
        }

        #endregion Methods
    }
}