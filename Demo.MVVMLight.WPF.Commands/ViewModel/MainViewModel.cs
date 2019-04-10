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
            // ��������
            ApplicationTitle = "ReactiveUI Winforms Demo - Commands";

            // �����޲�������
            ParameterlessCommand = new RelayCommand(() => Parameterless());

            // ʹ�ò�����������
            WithParameterCommand = new RelayCommand<string>(msg => WithParameter(msg));

            // ���ж�ִ�д�������
            WithCanExecuteCommand = new RelayCommand<string>(msg => WithCanExecute(msg), msg=> !string.IsNullOrWhiteSpace(msg));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// ����
        /// </summary>
        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => Set(() => ApplicationTitle, ref _applicationTitle, value);
        }

        /// <summary>
        /// �޲�������
        /// </summary>
        public RelayCommand ParameterlessCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// ��������ִ������
        /// </summary>
        public RelayCommand<string> WithCanExecuteCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// ����������
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