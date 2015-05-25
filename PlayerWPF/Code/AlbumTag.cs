using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PlayerWPF.Code
{
    class AlbumTag
    {
        private TagLib.File audioTag;

        public double TimeDuration { get { return audioTag.Properties.Duration.TotalSeconds; } }

        internal AlbumTag(string fullPath)
        {
            audioTag = TagLib.File.Create(fullPath);
            
        }

        private void SetStandartArt(Image albumIMG)
        {
            albumIMG.Source = new BitmapImage(new Uri("pack://application:,,,/res1/herb.png"));
        }

        internal void SetAlbumArt(Image albumIMG)
        {
            
            if (audioTag.Tag.Pictures.Length > 0)
            {
                MemoryStream albumArtworkMemStream = new MemoryStream(audioTag.Tag.Pictures[0].Data.Data);
                BitmapImage albumImage = new BitmapImage();
                albumImage.BeginInit();
                albumImage.CacheOption = BitmapCacheOption.OnLoad;
                albumImage.StreamSource = albumArtworkMemStream;
                albumImage.EndInit();
                albumIMG.Source = (ImageSource)albumImage;
                albumArtworkMemStream.Close();

            }
            else
            {
                SetStandartArt(albumIMG);
            }



        }
    }
}
