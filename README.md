# PIRplayer
WPF player
using System;
using System.Net;
using System.IO;
using System.Media;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using TagLib;
using NAudio;
using WPFSoundVisualizationLib;
using NAudio.Dsp;
using NAudio.Wave;
using PlayerWPF.Code;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.BassAsio;
using Un4seen.BassWasapi;

namespace PlayerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }
        private ushort firstPlay = 0;
        private double i = 0.2;
        System.Windows.Threading.DispatcherTimer timer1;
        int z_flag = 0;
        double bassLevel = 0;
        double miniBassLevel = 0;
        double maxLevel = 0;
        bool Flag = true;
        bool flag_animation = true;
        bool _keyPausePlay = false;
        string file_name;
        string full_file_name;
        int stream;

        private void file_button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog File_open = new Microsoft.Win32.OpenFileDialog();
            //File_open.DefaultExt = ".mp3";
            File_open.Filter = "Music files (.mp3;.flac)|*.mp3;*.flac" + "|Все файлы ()|.* ";
            File_open.ShowDialog();
            //if (TextBox1.Text != string.Empty)
            try
            {
                wmp.Source = new Uri(File_open.FileName);
            }
            catch (UriFormatException)
            { MessageBox.Show("Не выбран аудиофайл", "ERROR"); }

            file_name = File_open.SafeFileName;
            full_file_name = File_open.FileName;
            TextBox1.Text = file_name;
            wmp.Volume = VolumeS.Value;
            Bass_Initialize();


        }



        public void Bass_Initialize()
        {
            Bass.BASS_Stop();
            Bass.BASS_Free();

            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            Bass.BASS_PluginLoad("bass_aac.dll");
            Bass.BASS_PluginLoad("bassflac.dll");
            stream = Bass.BASS_StreamCreateFile(full_file_name, 0, 0,
                    BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);

        }





        public void ForTimer()
        {
            timer1 = new System.Windows.Threading.DispatcherTimer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = TimeSpan.FromMilliseconds(10);

        }
        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            if (firstPlay == 0)
            {
                ForTimer();

            }
            if (file_name != string.Empty & _keyPausePlay != true)
            {

                //wmp.Play();
                Bass.BASS_ChannelPlay(stream, false);
                timer1.Start();
                _keyPausePlay = true;
            }
            else if (_keyPausePlay == true)
            {

               // wmp.Pause();
                Bass.BASS_ChannelPause(stream);
                timer1.Stop();


                _keyPausePlay = false;
            }

            firstPlay++;
        }

        private void VolumeS_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //wmp.Volume = VolumeS.Value;
            Bass.BASS_SetVolume((float)VolumeS.Value);
                
                }

        private void Stop_button_Click(object sender, RoutedEventArgs e)
        {
            Bass.BASS_ChannelStop(stream);
            _keyPausePlay = false;
            firstPlay = 0;
            Parametars_audio.Text = "0:00:00";
            if (i != 0.2)
                timer1.Stop();
            //wmp.Stop();





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bass.BASS_Free();
            this.Close();
        }






        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }







        private void IMG_Round_MouseEnter(object sender, MouseEventArgs e)
        {

            //DoubleAnimation da = new DoubleAnimation();
            //da.From = IMG_Round.ActualWidth;
            //da.To = IMG_Round.ActualWidth - 100;           
            //da.Duration = TimeSpan.FromSeconds(5);
            //IMG_Round.BeginAnimation(Image.WidthProperty, da);

        }

        private void IMG_Round_MouseLeave(object sender, MouseEventArgs e)
        {
            //DoubleAnimation da = new DoubleAnimation();

            //da.From = IMG_Round.ActualWidth;
            //da.To = IMG_Round.ActualWidth + 100;
            //da.Duration = TimeSpan.FromSeconds(2);
            //IMG_Round.BeginAnimation(Image.WidthProperty, da);

        }





        private float[] mass=new float[101];
        public void level()
        {
            try
            {
                mass = Bass.BASS_ChannelGetLevel(stream, 100, BASSLevel.BASS_LEVEL_RMS);
                textBox.Text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", mass[0], mass[1], mass[2], mass[3], mass[4]);
            }
            catch (SystemException e)
            {
                textBox.Text = e.Message.ToString();

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


            i = i + Bass.BASS_GetVolume();


            level();




            if (wmp != null)
            {

                position_audio();


                bassLevel = Bass.BASS_ChannelGetLevel(stream);
                miniBassLevel = bassLevel / 50000000;

                /* Shape_Up.RenderTransform = new RotateTransform(i, 0, 84);
                Shape_Down.RenderTransform = new RotateTransform(i, 0, -84);

                DropShadowEffect shadow = new DropShadowEffect();
                shadow.Direction = 315 + i;
                shadow.ShadowDepth = 10;


                Shape_Up.Effect = shadow;
                Shape_Down.Effect = shadow;

                */
                switch (flag_animation)
                {
                    case true:
                        Scale_Animation(bassLevel, miniBassLevel);
                        break;
                    case false:
                        Round_Animation(bassLevel, miniBassLevel);
                        break;
                }
            }

            else
            {
                Parametars_audio.Text = "0:00:00";


            }


            

        }


        private int r_flag = 0;
        private void Round_Animation(double bassLevel, double miniBassLevel)
        {
            switch (r_flag)
            {
                case 7:
                    UserAnimation.ShapeAnimation(Shape_Up, miniBassLevel * 1.4);
                    UserAnimation.ShapeAnimationToStandart(Shape_Left, 66, 100);
                    break;
                case 14:
                    UserAnimation.ShapeAnimation(Shape_Right, miniBassLevel * 1.4);
                    UserAnimation.ShapeAnimationToStandart(Shape_Up, 100, 66);
                    break;
                case 21:
                    UserAnimation.ShapeAnimation(Shape_Down, miniBassLevel * 1.4);
                    UserAnimation.ShapeAnimationToStandart(Shape_Right, 66, 100);
                    break;
                case 28:
                    UserAnimation.ShapeAnimation(Shape_Left, miniBassLevel * 1.4);
                    UserAnimation.ShapeAnimationToStandart(Shape_Down, 100, 66);
                    break;
            }
            r_flag++;
            if (r_flag > 28) { r_flag = 0; }
        }

        private void Scale_Animation(double bassLevel, double miniBassLevel)
        {
            if (z_flag % 16 == 0)
            {
                if (Flag == true)
                {
                    UserAnimation.ShapeAnimationToStandart(Shape_Down, 100, 66);
                    UserAnimation.ShapeAnimationToStandart(Shape_Up, 100, 66);
                    UserAnimation.ShapeAnimationToStandart(Shape_Left, 66, 100);
                    UserAnimation.ShapeAnimationToStandart(Shape_Right, 66, 100);

                    Flag = false;

                }
                else if (Flag == false)
                {
                    if (Math.Abs(miniBassLevel) >= 20)
                    {
                        UserAnimation.ShapeAnimation(Shape_Left, miniBassLevel);                       
                        UserAnimation.ShapeAnimation(Shape_Right, miniBassLevel);

                    }
                    if (Math.Abs(miniBassLevel) < 20)
                    {
                        UserAnimation.ShapeAnimation(Shape_Up, miniBassLevel * 1.5);
                        UserAnimation.ShapeAnimation(Shape_Down, miniBassLevel * 1.5);

                    }
                    if (Math.Abs(miniBassLevel) >= 41)
                    {
                        UserAnimation.ShapeAnimation(Shape_Left, miniBassLevel);
                        UserAnimation.ShapeAnimation(Shape_Right, miniBassLevel);
                        UserAnimation.ShapeAnimation(Shape_Up, miniBassLevel);
                        UserAnimation.ShapeAnimation(Shape_Down, miniBassLevel);

                    }
                    Flag = true;
                }

            }
            
        z_flag += 2;
    }


        private int seconds_pos = 0;

        public void position_audio()
        {
            int seconds =wmp.Position.Seconds;
            int hours=wmp.Position.Hours;
            int minutes=wmp.Position.Minutes;

            Parametars_audio.Text = String.Format("{0:D}:{1:D2}:{2:#}", hours, minutes, seconds);
           

           
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (flag_animation == true) { flag_animation = false; }
            else { flag_animation = true; }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PlayerWPF.Code
{
    class UserAnimation
    {
        public static void ShapeAnimation(Image shape, double miniBassLevel)
        {
            int time = 35;
            miniBassLevel = Math.Abs(miniBassLevel);

            DoubleAnimation da1 = new DoubleAnimation();
            da1.From = shape.ActualHeight;
            da1.To = shape.ActualHeight + miniBassLevel;
            da1.Duration = TimeSpan.FromMilliseconds(time);

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = shape.ActualWidth;
            da2.To = shape.ActualWidth + miniBassLevel;
            da2.Duration = TimeSpan.FromMilliseconds(time);

            shape.BeginAnimation(Image.HeightProperty, da1);
            shape.BeginAnimation(Image.WidthProperty, da2);
        }
        public static void ShapeAnimation(Image shape, double miniBassLevel,bool reverse)
        {
            int time = 35;
            miniBassLevel = Math.Abs(miniBassLevel);

            DoubleAnimation da1 = new DoubleAnimation();
            da1.From = shape.ActualHeight;
            da1.To = shape.ActualHeight + miniBassLevel;
            da1.Duration = TimeSpan.FromMilliseconds(time);
            da1.AutoReverse = reverse;

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = shape.ActualWidth;
            da2.To = shape.ActualWidth + miniBassLevel;
            da2.Duration = TimeSpan.FromMilliseconds(time);
            da2.AutoReverse = reverse;

            shape.BeginAnimation(Image.HeightProperty, da1);
            shape.BeginAnimation(Image.WidthProperty, da2);
        }
        public static void ShapeAnimationToStandart(Image shape, double standartW, double standartH)
        {
            int time = 100;

            DoubleAnimation da1 = new DoubleAnimation();
            da1.From = shape.ActualHeight;
            da1.To = standartH;
            da1.Duration = TimeSpan.FromMilliseconds(time);

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = shape.ActualWidth;
            da2.To = standartW;
            da2.Duration = TimeSpan.FromMilliseconds(time);

            shape.BeginAnimation(Image.HeightProperty, da1);
            shape.BeginAnimation(Image.WidthProperty, da2);

        }



    }
}
