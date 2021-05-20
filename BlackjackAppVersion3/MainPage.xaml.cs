using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;


namespace BlackjackAppVersion3
{
    
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();        
            this.DataContext =  new GameController();
            this.BtnSpace3.Visibility = Visibility.Visible;
        }

        
        public GameController gameController_ = new GameController();
        
        private void New_Game(object sender, RoutedEventArgs e)
        {
            gameController_.NewGame();
            
            this.StickBtn.IsEnabled = true;
            this.HitBtn.IsEnabled = true;
            this.NewGameBtn.IsEnabled = false;
        }

        private void Stick(object sender, RoutedEventArgs e)
        {
            gameController_.Stick();
            this.NewGameBtn.IsEnabled = true;
            this.StickBtn.IsEnabled = false;
            this.HitBtn.IsEnabled = false;
        }

        private void Hit(object sender, RoutedEventArgs e)
        {
            gameController_.Hit();
            if(gameController_.stick == true)
            {
                this.NewGameBtn.IsEnabled = true;
                this.StickBtn.IsEnabled = false;
                this.HitBtn.IsEnabled = false;
            }
        }

        



    }
}
