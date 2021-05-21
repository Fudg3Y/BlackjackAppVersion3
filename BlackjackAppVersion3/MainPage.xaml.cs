using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;

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

        private void ChangeCardColour_Click(object sender, RoutedEventArgs e)
        {
            if(gameController_.Player.iter != 9)
            {
                gameController_.Player.iter++;
                gameController_.Dealer.iter++;
            }
            else
            {
                gameController_.Player.iter = 0;
                gameController_.Dealer.iter = 0;
            }
            
            New_Game(this, new RoutedEventArgs());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void CommandBar_Closing(object sender, object e)
        {
            CommandBar.IsOpen = true;
        }

    }
}
