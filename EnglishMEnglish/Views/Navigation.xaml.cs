using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace EnglishMEnglish.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Navigation : Page
    {
        public ObservableCollection<int> NavigationStackSize { get; set; } =
            new ObservableCollection<int>();
        public Navigation()
        {
            this.InitializeComponent();
            NavigationStackSize.Add(ContentFrame.BackStack.Count);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DynamicPanel.Visibility = Visibility.Collapsed;
            DynamicPanelVisibilityButton.Visibility = Visibility.Visible;
        }

        private void DynamicPanelVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Visibility = Visibility.Collapsed;
            DynamicPanel.Visibility = Visibility.Visible;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e) =>
            ContentFrame.Navigate(typeof(Home));

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        private void ClearNavigationStack_Click(object sender, RoutedEventArgs e) =>
            ContentFrame.BackStack.Clear();
    }
}
