using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Xsl;

namespace Whac_A_Mole
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private int increment;
        int number;
        int numberAux;
        int numberSplash;
        int games;
        int timerGames;
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            AddMole();
            AddButtons();
            LlenarSplash();
            Clock();
        }

        // LISTS
        List<Image> listMole = new List<Image>();
        public void AddMole()
        {
            listMole.Add(Mole1);
            listMole.Add(Mole2);
            listMole.Add(Mole3);
            listMole.Add(Mole4);
            listMole.Add(Mole5);
            listMole.Add(Mole6);
        }
        List<Button> buttons = new List<Button>();
        public void AddButtons()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
        }
        List<Image> Splash = new List<Image>();
        public void LlenarSplash()
        {
            Splash.Add(Splash1);
            Splash.Add(Splash2);
            Splash.Add(Splash3);
            Splash.Add(Splash4);
            Splash.Add(Splash5);
            Splash.Add(Splash6);
        }
        DispatcherTimer timer = new DispatcherTimer();
        
        public void Clock()
        {
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += dtTicker;
        }
        public void RandomMole()
        {
            if (increment == 3)
            {
                increment = 1;
                do
                {
                    Random rnd = new Random();
                    number = rnd.Next(0, 6);
                } while (numberAux == number);
            }
        }
        private void dtTicker(object sender, EventArgs e)
        {
            games++;
            timerGames--;
            GameTimer.Content = timerGames.ToString();
                
            numberAux = number;
            increment++;
            RandomMole();
                 // UP
                if (increment != 2)
                {
                    listMole[number].Visibility = Visibility.Visible;
                    buttons[number].IsEnabled = true;
                    listMole[number].RenderTransform = new TranslateTransform();
                    ((TranslateTransform)listMole[number].RenderTransform).BeginAnimation(TranslateTransform.YProperty,
                        new DoubleAnimation(120, 20, TimeSpan.FromMilliseconds(300)));
                }
                // DOWN
                if (increment == 2)
                {
                    ((TranslateTransform)listMole[number].RenderTransform).BeginAnimation(TranslateTransform.YProperty,
                                    new DoubleAnimation(20, 135, TimeSpan.FromMilliseconds(300)));
                    buttons[number].IsEnabled = false;
                    Splash[numberSplash].Visibility = Visibility.Hidden;
                    numberSplash = 0;
                }
                // END GAME
                if (games == 20)
                {
                    games = 0;
                    btnStart.IsEnabled = true;
                    increment = 0;
                    timer.Stop();

                }
        }
        
        // BUTTON START
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            labelCount.Content = count.ToString();
            number = 0;
            numberSplash = 0;
            games = 0;
            timerGames = 20;
            GameTimer.Content = timerGames.ToString();
            increment = 0;
            timer.Start();
            btnStart.IsEnabled = false;
            
        }
        // BUTONS MOLE'S
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Splash1.Visibility = Visibility.Visible;
            numberSplash = 0;
            count++;
            labelCount.Content = count.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Splash2.Visibility = Visibility.Visible;
            numberSplash = 1;
            count++;
            labelCount.Content = count.ToString();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Splash3.Visibility = Visibility.Visible;
            numberSplash = 2;
            count++;
            labelCount.Content = count.ToString();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Splash4.Visibility = Visibility.Visible;
            numberSplash = 3;
            count++;
            labelCount.Content = count.ToString();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Splash5.Visibility = Visibility.Visible;
            numberSplash = 4;
            count++;
            labelCount.Content = count.ToString();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Splash6.Visibility = Visibility.Visible;
            numberSplash = 5;
            count++;
            labelCount.Content = count.ToString();
        }
       
    }
   
}
