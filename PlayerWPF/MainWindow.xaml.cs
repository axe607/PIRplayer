using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PlayerWPF.Code;
using Un4seen.Bass;
using System.Windows.Threading;

namespace PlayerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        ShapeAnimations animator;
        private byte firstPlay = 0;
        private int seconds_pos = 0;
        private int stream;
        private double bassLevel = 0;
        private double miniBassLevel = 0;
        private double rotateRatio = 0.2;
        private bool _animationFlag = true;
        private bool _keyPausePlay = false;
        private bool _stopFlag = false;
        private bool _playFlag = false;
        private bool _folderFlag = false;
        private bool _visTypeFlag = false;
        private string PathToFile;
        private string FullPathToFile;
        private DispatcherTimer AnimationTimer;
        private AlbumTag albumTag;
        private Microsoft.Win32.OpenFileDialog File_open;
        #endregion

        #region Initializers


        public MainWindow()
        {
            InitializeComponent();
            animator = new ShapeAnimations()
            { _shape_Down = Shape_Down, _shape_Left = Shape_Left, _shape_Right = Shape_Right, _shape_Up = Shape_Up };
        }
        
        private void Bass_Initialize()
        {
            Bass.BASS_Stop();
            Bass.BASS_Free();

            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            Bass.BASS_PluginLoad("bass_aac.dll");
            Bass.BASS_PluginLoad("bassflac.dll");
            stream = Bass.BASS_StreamCreateFile(FullPathToFile, 0, 0,
                    BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);


        }

        private void AnimationTimerInitialize()
        {
            AnimationTimer = new DispatcherTimer();
            AnimationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            AnimationTimer.Interval = TimeSpan.FromMilliseconds(10);

        }
        #endregion

        public bool isRightFileName(string name)
        {
            if (name != "")
            { return true; }
            else { return false; }            
        }

        
        private void image_folder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _folderFlag = true;
        }

        private void image_folder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _folderFlag = true;
            File_open = new Microsoft.Win32.OpenFileDialog();
            File_open.Filter = "Music files (.mp3;.flac)|*.mp3;*.flac" + "|Все файлы ()|*.* ";
            File_open.ShowDialog();


            if(isRightFileName(File_open.SafeFileName)==true)

            { 
                try { AnimationTimer.Stop(); }
                catch (System.NullReferenceException)
                { }
                PathToFile = File_open.SafeFileName;
                FullPathToFile = File_open.FileName;
                SongName.Text = PathToFile;
                albumTag = new AlbumTag(FullPathToFile);
                albumTag.SetAlbumArt(AlbumIMGLeft);
                albumTag.SetAlbumArt(AlbumIMGRight);
                progressBar.Maximum = albumTag.TimeDuration;
                progressBar.Value = 0;
                _keyPausePlay = false;
                image_play.Source = new BitmapImage(new Uri("pack://application:,,,/res1/pause1.png"));
                Bass_Initialize();
                AnimationTimerInitialize();
            }
            else
            { MessageBox.Show("Не выбран аудиофайл", "ERROR"); }

        }

        private void image_play_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _playFlag = true;
        }

        private void image_play_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {


                if (_playFlag == true)
                {


                    if (PathToFile != string.Empty & _keyPausePlay != true)
                    {
                        Bass.BASS_ChannelPlay(stream, false);
                        AnimationTimer.Start();
                        _keyPausePlay = true;
                        image_play.Source = new BitmapImage(new Uri("pack://application:,,,/res1/play3.png"));
                    }
                    else if (_keyPausePlay == true)
                    {
                        Bass.BASS_ChannelPause(stream);
                        AnimationTimer.Stop();
                        _keyPausePlay = false;
                        image_play.Source = new BitmapImage(new Uri("pack://application:,,,/res1/pause1.png"));
                    }


                    _playFlag = false;
                }
            }
            catch (System.NullReferenceException)
            {


            }
        }

        private void image_stop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _stopFlag = true;
        }

        private void image_stop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimationTimer.Stop();
            Bass.BASS_ChannelStop(stream);
            Bass.BASS_ChannelSetPosition(stream, 0);
            Parametars_audio.Text = "0:00:00";
            firstPlay = 0;
            progressBar.Value = 0;
            _keyPausePlay = false;
            _stopFlag = false;
        }









        private void VolumeS_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Bass.BASS_SetVolume((float)VolumeS.Value);
        }


        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            ProgressBarPosition(AudioPosition);
            RotateShapes(IMG_Round, 58, 58);
            bassLevel = Bass.BASS_ChannelGetLevel(stream);
            miniBassLevel = bassLevel / 50000000;
            switch (_animationFlag)
            {
                case true:
                    animator.Scale_Animation( miniBassLevel);
                    break;
                case false:
                    animator.Round_Animation( miniBassLevel);
                    break;
            }
        }

        private void RotateShapes(Image shape, int centerX, int centerY)
        {
            rotateRatio = rotateRatio + Bass.BASS_GetVolume();
            shape.RenderTransform = new RotateTransform(rotateRatio, centerX, centerY);
        }



        private void ProgressBarPosition(long position)
        {
            long _pos = position;
            int s = (int)Bass.BASS_ChannelBytes2Seconds(stream, _pos);
            int h = s / 3600;
            int m = (s - (h * 3600)) / 60;
            s = s - (h * 3600 + m * 60);
            Parametars_audio.Text = String.Format("{0:D}:{1:D2}:{2:D2}", h, m, s);
        }



        private long AudioPosition
        {
            get
            {
                long position = Bass.BASS_ChannelGetPosition(stream, BASSMode.BASS_POS_BYTES);
                if (progressBar.Value != progressBar.Maximum)
                { progressBar.Value += 0.019; }
                else
                {
                    AnimationTimer.Stop();
                    Bass.BASS_ChannelStop(stream);
                    Bass.BASS_ChannelSetPosition(stream, 0);
                    Parametars_audio.Text = "0:00:00";
                    firstPlay = 0;
                    progressBar.Value = 0;
                    _keyPausePlay = false;

                }
                return position;
            }


        }





        private void rewindRight_Click(object sender, RoutedEventArgs e)
        {
            if (progressBar.Maximum - progressBar.Value > 5)
            {
                long pos = AudioPosition;
                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelBytes2Seconds(stream, pos) + 5);
                progressBar.Value += 5;
            }
        }

        private void rewindLeft_Click(object sender, RoutedEventArgs e)
        {
            if (progressBar.Value > 5)
            {
                long pos = AudioPosition;
                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelBytes2Seconds(stream, pos) - 5);
                progressBar.Value -= 5;
            }
        }

        private void VisualisationType_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _visTypeFlag = true;
        }

        private void VisualisationType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_visTypeFlag == true)
            {
                if (_animationFlag == true)
                {
                    _animationFlag = false;
                    VisualisationType.Source = new BitmapImage(new Uri("pack://application:,,,/res1/VisType2.png"));
                }
                else
                {
                    _animationFlag = true;
                    VisualisationType.Source = new BitmapImage(new Uri("pack://application:,,,/res1/VisType1.png"));

                }
            }


        }




    }

}
