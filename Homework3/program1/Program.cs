using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program4
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Square(5,"Square #1 "),
                new Circle (3,"Circle #1 "),
                new Rectangle(4,5,"Rectangle #1 "),
                new Triangle(4,4,4,"Triangle #1 ")
            };
            System.Console.WriteLine("Shapes Collection");
            foreach(Shape s in shapes)
            {
                System.Console.WriteLine(s);
            }
        }
    }
    public abstract class Shape
    {
        private string myId;
        public Shape(string s)    //不同字符串（不同的部分）
        {
            Id = s;
        }
        public string Id
        {
            get
            {
                return myId;
            }
            set
            {
                myId = value;
            }
        }
        public abstract double Area
        {
            get;
        }
        public virtual void Draw()
        {
            Console.WriteLine("Draw shape Icon");
        }
        public override string ToString()        //输出的模板（相同的部分）
        {
            return Id + "Area=" + string.Format("{0:F2}", Area);
        }
    }
    //正方形类
    public class Square : Shape
    {
        private int mySide;
        public Square(int side, string id) : base(id)
        {
            mySide = side;
        }
        public override double Area
        {
            get
            {
                return mySide * mySide;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw 4 Side:" + mySide);
        }
    }
    //圆类
    public class Circle : Shape
    {
        private int myRadius;
        public Circle(int radius, string id) : base(id)
        {
            myRadius = radius;
        }
        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Circle:" + myRadius);
        }
    }
    //矩形类
    public class Rectangle : Shape
    {
        private int myWidth;
        private int myHeight;
        public Rectangle(int width, int height, string id) : base(id)
        {
            myWidth = width;
            myHeight = height;
        }
        public override double Area
        {
            get
            {
                return myWidth * myHeight;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }
    //三角形类
    public class Triangle:Shape
    {
        private double mySide1,mySide2,mySide3;
        public Triangle(double Side1, double Side2, double Side3,string id) : base(id)
        {
            mySide1 = Side1;
            mySide2 = Side2;
            mySide3 = Side3;
        }
        public override double Area
        {
            get
            {
                return Math.Sqrt(((mySide1 + mySide2 + mySide3) / 2) * 
                    (((mySide1 + mySide2 + mySide3) / 2) - mySide1) *
                    (((mySide1 + mySide2 + mySide3) / 2) - mySide2) *
                    (((mySide1 + mySide2 + mySide3) / 2) - mySide3)); 
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Triangle");
        }
    }

}