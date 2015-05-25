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
        protected static void AnimateShape(Image shape, double miniBassLevel)
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
        protected static void AnimateShape(Image shape, double miniBassLevel,int time,bool reverse)
        {
            int _time = time;
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
        protected static void AnimateShapeToStandart(Image shape, double standartW, double standartH)
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

        protected static void AnimateImage(Image image,int _X,int _Y,int _time,bool reverse)
        {
            int time = _time;

            DoubleAnimation da1 = new DoubleAnimation();
            da1.From = image.ActualHeight;
            da1.To = image.ActualHeight + _Y;
            da1.Duration = TimeSpan.FromMilliseconds(time);
            da1.AutoReverse = reverse;

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = image.ActualWidth;
            da2.To = image.ActualWidth + _X;
            da2.Duration = TimeSpan.FromMilliseconds(time);
            da2.AutoReverse = reverse;

            image.BeginAnimation(Image.HeightProperty, da1);
            image.BeginAnimation(Image.WidthProperty, da2);
        }

        protected static void AnimateImageToStandart(Image image, double standartW, double standartH, int _time)
        {
            int time = _time;

            DoubleAnimation da1 = new DoubleAnimation();
            da1.From = image.ActualHeight;
            da1.To = standartH;
            da1.Duration = TimeSpan.FromMilliseconds(time);

            DoubleAnimation da2 = new DoubleAnimation();
            da2.From = image.ActualWidth;
            da2.To = standartW;
            da2.Duration = TimeSpan.FromMilliseconds(time);

            image.BeginAnimation(Image.HeightProperty, da1);
            image.BeginAnimation(Image.WidthProperty, da2);
        }


    }
}
