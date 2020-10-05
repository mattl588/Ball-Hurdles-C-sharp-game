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
using System.Windows.Threading; //Lots of libraries I didn't use. Doesn't change the program to include them though, does it? 

namespace Ball_Hurdles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //this class is primarily for the main menu and the fun stuff with messing around in it. If "yup!" is hit, a new instance of 
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        int gravity = 8;
        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            Initialize();
        }
        private void MainEventTimer(object sender, EventArgs e)
        {
            Canvas.SetTop(Ball, Canvas.GetTop(Ball) + gravity);
            if (Canvas.GetTop(Ball) >= 290)
            {
                gravity = -8;
            }
            if (Canvas.GetTop(Ball) <= 40)
            {
                gravity = 8;
            }

        }
        private void KeyIsDown(object sender, KeyEventArgs e) //made entirely for the sake of learning. Just makes the ball go up and down for no reason :)
        {
            if (e.Key == Key.Space)
            {
                gravity = -8;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            gravity = 8;
        }
        private void Initialize()
        {
            MyCanvas.Focus();
            Canvas.SetTop(Ball, 0);
            gameTimer.Start();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Level1 level = new Level1(); //I instantiate a case of "Level1", which is on another cs file. 
            level.Show();
            this.Close();
        }
    }
}