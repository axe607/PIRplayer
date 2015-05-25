using System.Windows.Controls;

namespace PlayerWPF.Code
{
    class ImageAnimations:UserAnimation
    {
        public static void SimpleAnimation(Image _image,int _X, int _Y, int timeInMilliseconds, bool reverse)
        {
            UserAnimation.AnimateImage(_image, _X, _Y, timeInMilliseconds, reverse);
        }
        public static void SimpleAnimationToStandart(Image image, double standartW, double standartH, int _time)
        {
            UserAnimation.AnimateImageToStandart(image, standartW, standartH, _time);
        }
    }
}
