using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//на 4
//Объявите класс «Окружность», с полями: x1, y1, R(координаты центра и радиус),
//методами: вывода на экран координат центра и радиуса;- проверки, попадает ли точка в данную окружность;+
//проверки, пересекается ли с другой окружностью;+ масштабирования;------ передвижения,+ свойствами, позволяющими получить 
//и установить площадь и длину окружности.+Переопределить любую операцию-------

//скрытые поля, конструкторы с параметрами и без параметров, методы, свойства.Методы и свойства должны обеспечивать непротиворечивый,
//полный, минимальный и удобный интерфейс класса.Проверяйте допустимость значений параметров перед выполнением кода методов.
namespace Laba2._2
{
    class Circle
    {
        public double X1;
        public double Y1;
        public double R;

        double squareOfCircle;
        double circleLength;

        public double SquareOfCircle
        {
            get
            {
                return squareOfCircle;
            }
            set
            {
                squareOfCircle = Math.PI * R * R;
            }
        }

        public double CircleLength
        {
            get
            {
                return circleLength;
            }
            set
            {
                circleLength = 2 * Math.PI * R;
            }
        }

        public Circle()
        {
            X1 = 0;
            Y1 = 0;
            R = 3;
        }

        public Circle(double x1, double y1, double r)
        {
            X1 = x1;
            Y1 = y1;
            R = r;
        }

        public void OutputCircle() //--------
        {

        }

        Point point = new Point();
        public bool CheckPointInCircle()
        {
            if (Math.Pow(X1 - point.X, 2) + Math.Pow(Y1 - point.Y, 2) < Math.Pow(R, 2))
            {
                return true;
            }
            return false;
        }

        public bool CheckIsIntersect(Circle secondCircle)
        {
            double distance = Math.Sqrt(Math.Pow(Math.Abs(secondCircle.X1 - X1), 2) + Math.Pow(Math.Abs(secondCircle.Y1 - Y1), 2));

            return distance <= R + secondCircle.R && distance >= R - secondCircle.R;
        }

        public void MoveCircle(int numberMove)
        {
            X1 += numberMove;
            Y1 += numberMove;
        }


    }
}
