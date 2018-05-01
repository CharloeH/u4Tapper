using System;
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
using Tapper;

namespace u4Tapper
{
    enum Gamestate {SplashScreen, GameOn, GameOver}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle playerRectangle = new Rectangle();
        
        Player player;
        Point point;
        Point pointHorizontal;
        Point pointVertical;
        Background background;
        System.Windows.Media.MediaPlayer mediaPlayer = new MediaPlayer();
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        TimeSpan time = new TimeSpan();
        int counter = 0;
        Gamestate gameState;
        int lives = 0;
        int level = 0;
        int i = 0;
        int z = 0;
        
        public MainWindow()

        {
            
            InitializeComponent();
            player = new Player(myCanvas, this);
            mediaPlayer.Open(new Uri("TrueArt.mp3", UriKind.Relative));
            background = new Tapper.Background(myCanvas, this);
            
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 100 / 60);
            gameState = Gamestate.SplashScreen;
            gameTimer.Start();
            mediaPlayer.Play();
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == Gamestate.SplashScreen)
            {
                this.Title = "Splash Screen";
                if(Keyboard.IsKeyDown(Key.Enter))
                {
                    setUpGame();
                }
            }
            else if(gameState == Gamestate.GameOn)
            {
                this.Title = "Game On! Lives: " + lives.ToString() + ", Level: " + level.ToString();
                
                ControlCharacter();
            }
            else if(gameState == Gamestate.GameOver)
            {
                this.Title = "Game Over!";
            }
        }

        private void ControlCharacter()
        {
            pointHorizontal = new Point(i, 0);
            pointVertical = new Point(0, z);
            if (Keyboard.IsKeyDown(Key.S))
            {

                Canvas.SetTop(playerRectangle, pointVertical.Y);

                z++;
            }
            if (Keyboard.IsKeyDown(Key.W))
            {

                Canvas.SetTop(playerRectangle, pointVertical.Y);
                z--;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {

                Canvas.SetLeft(playerRectangle, pointHorizontal.X);
                i--;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {


                Canvas.SetLeft(playerRectangle, pointHorizontal.X);
                i++;
            }
        }
        private void setUpGame()
        {
            lives = 3;
            level = 0;
            gameState = Gamestate.GameOn;
            playerRectangle = new Rectangle();
            myCanvas.Children.Add(playerRectangle);
            playerRectangle.Fill = Brushes.White;
            playerRectangle.Height = 100;
            playerRectangle.Width = 100;
        }
    }
}
