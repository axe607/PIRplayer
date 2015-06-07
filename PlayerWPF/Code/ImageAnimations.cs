using System.Windows.Controls;

namespace PlayerWPF.Code
{
    class ImageAnimations:UserAnimation
    {
        public static void SimpleImageAnimation(Image _image,int X, int Y, int timeInMilliseconds, bool reverse)
        {
            UserAnimation.AnimateImage(_image, X, Y, timeInMilliseconds, reverse);
        }
        public static void SimpleImageAnimationToStandart(Image image, double standartW, double standartH, int _time)
        {
            UserAnimation.AnimateImageToStandart(image, standartW, standartH, _time);
        }
    }
}
