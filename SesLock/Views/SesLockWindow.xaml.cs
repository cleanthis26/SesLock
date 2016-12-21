using SesLock.ViewModels;
using System.Windows;

namespace SesLock
{
    /// <summary>
    /// Interaction logic for SesLockWindow.xaml
    /// </summary>
    public partial class SesLockWindow : Window
    {
        public SesLockWindow()
        {
            this.DataContext = new SesLockViewModel();
            InitializeComponent();
        }
    }
}
