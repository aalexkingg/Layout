﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Layout.Core;
using Layout.MVM.ViewModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;

namespace Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    // TODO: Create custom file (similar to .exe) which can store LayoutPreset's and when double-clicked opens windows - Software then only has to execute files rather than manually doing it everytime
    public partial class MainWindow : Window
    {

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int left, int top, int right, int bottom, int uFlags);

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;

        private bool darkTheme = true;
        public MainWindow()
        {
            UpdateManager.CheckForUpdates();

            InitializeComponent();

            LoadPresets();


            //lightButton.Click += Button_Click();
            
        }

        private void LoadPresets()
        {
            List<LayoutPreset> layouts = SaveSystem.LoadPresets();

            if (layouts != null)
            {
                foreach (LayoutPreset layout in layouts)
                {
                    CreateNewLayoutSection(layout);
                }
            }


        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            var point = Mouse.GetPosition(MainWindowGrid);

            // Check of left mouse button pressed
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                // Mouse clicked within first row
                if (point.Y <= MainWindowGrid.RowDefinitions[0].ActualHeight)
                {

                    // Check if close button pressed
                    if (this.CloseButton.Visibility.Equals(Visibility.Visible))
                    {
                        if ((point.X > (MainWindowGrid.ActualWidth - (CloseButton.ActualWidth + CloseButton.Margin.Right))) && (point.X < (MainWindowGrid.ActualWidth - CloseButton.Margin.Right)))
                        {
                            CloseButton_Clicked();
                            return;
                        }
                            
                    }
                    // Check if settings button pressed
                    else if (this.SettingsButton.Visibility.Equals(Visibility.Visible))
                    {
                        if ((point.X < (MainWindowGrid.ActualWidth - (CloseButton.ActualWidth + CloseButton.Margin.Right))) && (point.X > (MainWindowGrid.ActualWidth - (CloseButton.ActualWidth + CloseButton.Margin.Right + SettingsButton.ActualWidth + SettingsButton.Margin.Right))))
                        {
                            SettingsButton_Clicked();
                            return;
                        }
                        
                    }

                    // Else drag windiw
                    this.DragMove();
                    

                }
            }

        }

        private void CreateNewButton_Clicked(object sender, RoutedEventArgs e)
        {
            UncheckAllButtons();
        }

        public void CreateNewLayoutSection(LayoutPreset layout)
        {
            // Creates new button inside of stack panel
            // Sets button to is checked
            // attaches layout view model to button / activates layout view model which is filled with data from newLayout variable

            UncheckAllButtons();
            var newButton = new RadioButton();

            //newButton.IsChecked = isChecked;
            newButton.Content = layout.GetPresetName();
            newButton.Style = Application.Current.TryFindResource("MenuButtonTheme") as Style;
            newButton.Foreground = Brushes.White;
            newButton.Height = 50;
            newButton.FontSize = 14;
            //newButton.Command = MainViewModel.LayoutViewCommand;
            //newButton.Name = layout.GetPresetName() + "Button";
            //newButton.SetBinding(Button.CommandProperty, new Binding("LayoutViewCommand"));
            newButton.Checked += new RoutedEventHandler(ExecuteLayout);

            this.LayoutList.Children.Add(newButton);

            // Change display

            

        }

        public void UpdateExistingLayout(string newLayoutName, string oldLayoutName)
        {
            UncheckAllButtons();

            //this.LayoutList.Children.Select(element => element is RadioButton ? Console.WriteLine("true") : Console.WriteLine("fasle") );


            /*
            foreach (FrameworkElement element in this.LayoutList.Children)
            {

                if (element is RadioButton)
                {

                    if (((RadioButton)element).Content.Equals(oldLayoutName))
                    {
                        // Update radio button

                        ((RadioButton)element).Content = newLayoutName;
                        return;

                    }


                }

            }
            */

        }

        private void ExecuteLayout(object sender, EventArgs e)
        {

            // TODO: Close 'Other' windows before executing/opening new ones - Keeps desktop 'organised'

            string selectedOption = "";

            foreach (FrameworkElement element in this.LayoutList.Children)
            {

                if (element is RadioButton)
                {

                    if (((RadioButton)element).IsChecked == true)
                    {
                        selectedOption = ((RadioButton)element).Content.ToString();
                        break;
                    }


                }

            }

            List<LayoutPreset> apps = SaveSystem.LoadPresets();

            int count = apps.Count();

            for (int i = 0; i < count; i++)
            {
                if (selectedOption == apps[i].GetPresetName())
                {
                    LayoutPreset preset = apps[i];

                    for (int j = 0; j < preset.GetApps().Count; j++)
                    {

                        // TODO: Check if process is already open
                       


                        (string, string, WindowRectClass, string) app = preset.GetApps()[j];

                        Process.Start(@"" + app.Item2);
                        /*
                        if (app.Item3.Equals(null))
                        {
                            // File
                            Process.Start(@"" + app.Item2);
                        }
                        else
                        {
                            // Application
                            Process currentProcess = Process.GetProcessesByName(app.Item4).FirstOrDefault();

                            if (currentProcess == null)
                                continue;

                            // TODO: Set window position and size

                            SetWindowPos(currentProcess.MainWindowHandle, IntPtr.Zero, app.Item3.Left, app.Item3.Top, app.Item3.Right, app.Item3.Bottom, SWP_SHOWWINDOW);


                        }
                        */

                    }

                    break;
                }

            }
            


        }

        private void EditLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            UncheckAllButtons();

            // Disable all button commands

            foreach (FrameworkElement element in this.LayoutList.Children)
            {
                if (element is RadioButton)
                {
                    ((RadioButton)element).SetBinding(Button.CommandProperty, new Binding("LayoutViewCommand"));
                    ((RadioButton)element).Checked -= new RoutedEventHandler(ExecuteLayout);
                }
            }

            
        }

        public void AssignAllButtonCommands()
        {
            foreach (FrameworkElement element in this.LayoutList.Children)
            {
                if (element is RadioButton)
                {
                    ((RadioButton)element).Command = null;
                    ((RadioButton)element).Checked += new RoutedEventHandler(ExecuteLayout);
                }
            }
        }

        private void UncheckAllButtons()
        {
            foreach (FrameworkElement element in this.LayoutList.Children)
            {

                if (element is RadioButton)
                {

                    if (((RadioButton)element).IsChecked == true)
                    {
                        ((RadioButton)element).IsChecked = false;
                    }


                }

            }
        }
        private void ToggleTheme(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Change colours of main menu

            //((Border)MainWindow).Background = "white";

            // Change colours of sub menu's (Sub menu's may perform a check inside their objects)       

            if (darkTheme)
            {
                darkTheme = !darkTheme;

                // Activate light theme
                this.LightThemeLabel.Text = "Light";
                this.LightThemeLabel.Foreground = Brushes.Black;
                this.LightThemeBorder.Background = Brushes.White;

                this.MainWindowBorder.Background = Brushes.White;
                this.SoftwareTitle.Foreground = Brushes.Black;

                foreach (FrameworkElement element in this.LayoutList.Children)
                {
                    if (element is RadioButton)
                    {
                        ((RadioButton)element).Foreground = Brushes.Black;

                    }
                }

              
                //((MainWindow)System.Windows.Application.Current.).HomeButton.Command.Execute(this);

            }
            else
            {
                darkTheme = !darkTheme;

                // Active dark theme
                this.LightThemeLabel.Text = "Dark";
                this.LightThemeLabel.Foreground = Brushes.White;
                this.LightThemeBorder.Background = Brushes.Black;

            }
        }

        private void CloseButton_Clicked()
        {
            this.Close();

        }

        private void SettingsButton_Clicked()
        {

            // Display Settings Box

            if (this.SettingsMenu.Visibility.Equals(Visibility.Hidden))
            {
                this.SettingsMenu.Visibility = Visibility.Visible;

                AddHandler();

            }
            else
            {
                this.SettingsMenu.Visibility = Visibility.Hidden;
            }
            


        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddHandler()
        {
            AddHandler(Mouse.PreviewMouseDownOutsideCapturedElementEvent, new MouseButtonEventHandler(HandleClickOutsideOfControl), true);
        }

        private void HandleClickOutsideOfControl(object sender, MouseButtonEventArgs e)
        {

            Point point = Mouse.GetPosition(MainWindowGrid);

        }

        private void RefreshLayout(object sender, EventArgs e)
        {

        }

    }



}
