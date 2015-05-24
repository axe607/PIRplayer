using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace PlayerWPF.Code
{
    class ShapeAnimations: UserAnimation
    {
        private  int r_flag = 0;
        private  int z_flag = 0;
        private  bool Flag = true;
        public Image _shape_Up { private get; set; }
        public Image _shape_Down { private get; set; }
        public Image _shape_Left { private get; set; }
        public Image _shape_Right { private get; set; }


        public ShapeAnimations()
        { }

        public  void  Round_Animation(double bassLevel, double miniBassLevel)
        {
            switch (r_flag)
            {
                case 7:
                    UserAnimation.AnimateShape(_shape_Up, miniBassLevel * 1.4);
                    UserAnimation.AnimateShapeToStandart(_shape_Left, 75, 140);
                    break;
                case 14:
                    UserAnimation.AnimateShape(_shape_Right, miniBassLevel * 1.4);
                    UserAnimation.AnimateShapeToStandart(_shape_Up, 140, 75);
                    break;
                case 21:
                    UserAnimation.AnimateShape(_shape_Down, miniBassLevel * 1.4);
                    UserAnimation.AnimateShapeToStandart(_shape_Right, 75, 140);
                    break;
                case 28:
                    UserAnimation.AnimateShape(_shape_Left, miniBassLevel * 1.4);
                    UserAnimation.AnimateShapeToStandart(_shape_Down, 140, 75);
                    break;
            }
            r_flag++;
            if (r_flag > 28) { r_flag = 0; }
        }

        public  void Scale_Animation(double bassLevel, double miniBassLevel)
        {
            if (z_flag % 16 == 0)
            {
                if (Flag == true)
                {
                    UserAnimation.AnimateShapeToStandart(_shape_Down, 140, 75);
                    UserAnimation.AnimateShapeToStandart(_shape_Up, 140, 75);
                    UserAnimation.AnimateShapeToStandart(_shape_Left, 75, 140);
                    UserAnimation.AnimateShapeToStandart(_shape_Right, 75, 140);

                    Flag = false;

                }
                else if (Flag == false)
                {
                    if (Math.Abs(miniBassLevel) >= 20)
                    {
                        UserAnimation.AnimateShape(_shape_Left, miniBassLevel);
                        UserAnimation.AnimateShape(_shape_Right, miniBassLevel);

                    }
                    if (Math.Abs(miniBassLevel) < 20)
                    {
                        UserAnimation.AnimateShape(_shape_Up, miniBassLevel * 1.5);
                        UserAnimation.AnimateShape(_shape_Down, miniBassLevel * 1.5);

                    }
                    if (Math.Abs(miniBassLevel) >= 41)
                    {
                        UserAnimation.AnimateShape(_shape_Left, miniBassLevel);
                        UserAnimation.AnimateShape(_shape_Right, miniBassLevel);
                        UserAnimation.AnimateShape(_shape_Up, miniBassLevel);
                        UserAnimation.AnimateShape(_shape_Down, miniBassLevel);

                    }
                    Flag = true;
                }

            }

            z_flag += 2;
        }
    }
}
