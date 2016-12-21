using SesLock.Helpers;
using System;

namespace SesLock.ViewModels
{
    public class SesLockViewModel : ViewModelBase
    {
        private bool _IsWindowActive = false;
        public bool IsWindowActive
        {
            get { return _IsWindowActive; }
            set
            {
                _IsWindowActive = value;
                OnPropertyChanged();
            }
        }

        private bool _IsNotifyIconActive = true;
        public bool IsNotifyIconActive
        {
            get { return _IsNotifyIconActive; }
            set
            {
                _IsNotifyIconActive = value;
                OnPropertyChanged();
            }
        }

        public bool IsStartupApp
        {
            get { return SettingsProvider.IsStartUpApplication; }
            set
            {
                SettingsProvider.IsStartUpApplication = value;
                OnPropertyChanged();
            }
        }

        # region Commands
        public RelayCommand DoubleClickCommand { get; set; }
        private void DoubleClickCommandExecute(object parameter)
        {
            LockPc();
        }

        public RelayCommand LockCommand { get; set; }
        private void LockCommandExecute(object parameter)
        {
            LockPc();
        }

        public RelayCommand SwitchUserCommand { get; set; }
        private void SwitchUserCommandExecute(object parameter)
        {
            SwitchUser();
        }

        public RelayCommand StartUpCommand { get; set; }
        private void StartUpCommandExecute(object parameter)
        {
            SwitchStartupState();
        }

        public RelayCommand ExitCommand { get; set; }
        private void ExitCommandExecute(object parameter)
        {
            ExitProgram();
        }
        # endregion

        private void LockPc()
        {
            SessionLock.LockPc();
        }

        private void SwitchUser()
        {
            SessionLock.SwitchUser();
        }

        private void SwitchStartupState()
        {
            IsStartupApp = !IsStartupApp;
        }

        private void ExitProgram()
        {
            SingleAppHandler.ClosingApp();
            Environment.Exit(0);
        }

        public SesLockViewModel()
        {
            SingleAppHandler.VerifyIsSingleApp();

            DoubleClickCommand = new RelayCommand(DoubleClickCommandExecute);
            LockCommand = new RelayCommand(LockCommandExecute);
            SwitchUserCommand = new RelayCommand(SwitchUserCommandExecute);
            StartUpCommand = new RelayCommand(StartUpCommandExecute);
            ExitCommand = new RelayCommand(ExitCommandExecute);
        }
    }
}
