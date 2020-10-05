using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Ball_Hurdles
{
    /// <summary>
    /// Interaction logic for Level1.xaml
    /// </summary>
    public partial class Level1 : Window 
    {
        DispatcherTimer levelTimer = new DispatcherTimer();
        DispatcherTimer secondTimer = new DispatcherTimer();
        readonly int rollspeed = 1;
        double height;
        int timeremaining = 16;
        bool isHit = false;
        public Level1()
        {
            InitializeComponent();
            levelTimer.Tick += Mechanics;
            levelTimer.Interval = TimeSpan.FromMilliseconds(20);
            secondTimer.Tick += Countdown;
            secondTimer.Interval = TimeSpan.FromMilliseconds(1000);
            Initialize();
        }
        private void Mechanics(object sender, EventArgs e)
        {
            Canvas.SetLeft(GameBall, Canvas.GetLeft(GameBall) + rollspeed);
        }
        private void Countdown(object sender, EventArgs e)
        {
            timeremaining--;
            timeleft.Content = timeremaining;
            if (timeremaining <= 0)
            {
                if (Canvas.GetTop(GameBall) <= 40) //height of the hurdle. This makes it so that if the time is out and the hurdle is surpassed in height, the game is won.
                {
                    timeleft.Content = "You Win!!";
                    if (timeremaining <= -3)
                    {
                        this.Close();
                    }
                }
                else
                {
                    timeleft.Content = "Better luck next time!";
                    if (timeremaining <= -3) //roundabout, but for some reason, Thread.Sleep(3000) completely bricks the screen. Not sure why- I'll look into it.
                    {
                        this.Close();
                    }
                }
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Space)
            {
                while (!isHit) //isHit logic makes it so that hitting the key once causes one change in height. Otherswise, if inserted in a loop, simply holding down the key would win the game. No fun!
                {
                    height += 0.07; //for some odd reason, adding integer values of "height" causes the ball to launch higher by a large amount. I find it unclear why, but using doubles is better and actually makes the game challenging. 
                    isHit = true;
                    Canvas.SetTop(GameBall, Canvas.GetTop(GameBall) - height); 
                }
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            isHit = false;
        }
        private void Initialize()
        {
            GameCanvas.Focus(); 
            levelTimer.Start();
            secondTimer.Start();
        }
    }
}