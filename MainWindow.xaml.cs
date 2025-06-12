using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace JohnJustLoad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Enable dragging window by clicking anywhere on title bar area
            this.MouseLeftButtonDown += (s, e) => {
                if (e.GetPosition(this).Y < 40) // Title bar height
                {
                    this.DragMove();
                }
            };

            // Show welcome content initially
            ShowWelcomeContent();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowWelcomeContent()
        {
            WelcomeContent.Visibility = Visibility.Visible;
            ContentArea.Content = null;
        }

        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            // Reset button states
            ResetButtonStates();

            // Set active button
            if (HomeButton != null)
                HomeButton.Background = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(80, 255, 255, 255));

            // Hide welcome content and show page
            WelcomeContent.Visibility = Visibility.Collapsed;
            var homePage = new HomePage();
            ContentArea.Content = homePage;
        }

        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {
            ResetButtonStates();

            if (SettingsButton != null)
                SettingsButton.Background = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(80, 255, 255, 255));

            WelcomeContent.Visibility = Visibility.Collapsed;
            var settingsPage = new SettingPage();
            ContentArea.Content = settingsPage;
        }

        private void NavigateToAbout(object sender, RoutedEventArgs e)
        {
            ResetButtonStates();

            if (AboutButton != null)
                AboutButton.Background = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(80, 255, 255, 255));

            WelcomeContent.Visibility = Visibility.Collapsed;
            var aboutPage = new AboutPage();
            ContentArea.Content = aboutPage;
        }

        private void ResetButtonStates()
        {
            HomeButton.Background = System.Windows.Media.Brushes.Transparent;
            SettingsButton.Background = System.Windows.Media.Brushes.Transparent;
            AboutButton.Background = System.Windows.Media.Brushes.Transparent;
        }
    }
}