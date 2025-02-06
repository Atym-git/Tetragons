namespace TetragonsCP
{
    internal class Program
    {
        

        private static float aS = 3;
        private static float bS = 5;
        private static float cS = 6;
        private static float dS = 7;

        static void Main(string[] args)
        {
            Tetragon tetragon = new Tetragon(aS, bS, 0.523599f, cS, dS, 1.05f);
            ConvexTetragon convex = new ConvexTetragon(aS, bS, 0.523599f, cS, dS, 10, 4);
            Parallelogram parallelogram = new Parallelogram(aS, bS, 0.523599f);
            Diamond diamond = new Diamond(aS, bS, 0.523599f, 3, 5);
            Square square = new Square(aS, bS, 0.523599f);

            Console.WriteLine("Random Tetragon:");
            Console.WriteLine(tetragon.CountPerimeter());
            Console.WriteLine(tetragon.CountArea());
            Console.WriteLine("Convex Tetragon:");
            Console.WriteLine(convex.CountPerimeter());
            Console.WriteLine(convex.CountArea());
            Console.WriteLine("Parallelogram:");
            Console.WriteLine(parallelogram.CountPerimeter());
            Console.WriteLine(parallelogram.CountArea());
            Console.WriteLine("Diamond:");
            Console.WriteLine(diamond.CountPerimeter());
            Console.WriteLine(diamond.CountArea());
            Console.WriteLine("Square:");
            Console.WriteLine(square.CountPerimeter());
            Console.WriteLine(square.CountArea());
        }
    }

    internal abstract class ATetragon
    {
        public float a { get; set; }
        public float b { get; set; }
        public float angle { get; set; }

        protected ATetragon(float A, float B, float Angle)
        {
            a = A;
            b = B;
            angle = Angle;
        }

        public abstract float CountPerimeter();

        public abstract float CountArea();
    }

    internal class Tetragon : ATetragon
    {
        public float c { get; set; }
        public float d { get; set; }
        public float angle2 { get; set; }

        public Tetragon(float A, float B, float Angle, float C, float D, float Angle2) : base (A, B, Angle)
        {
            c = C;
            d = D;
            angle2 = Angle2;
        }

        public override float CountPerimeter()
        {
            return a + b + c + d;
        }

        public override float CountArea()
        {
            return 0.5f * a * d * (float)Math.Sin(angle) + 0.5f * b * c * (float)Math.Sin(angle2);
        }
    }

    internal class ConvexTetragon : ATetragon
    {
        public float d1 { get; set; }
        public float d2 { get; set; }

        public float c { get; set; }
        public float d { get; set; }

        public ConvexTetragon(float A, float B, float Angle, float C, float D, float D1, float D2) : base(A, B, Angle)
        {
            d1 = D1;
            d2 = D2;
        }
        

        public override float CountPerimeter()
        {
            return (a + b) * 2;
        }
        public override float CountArea()
        {
            return d1 * d2 / 2 * MathF.Sin(angle);
        }
    }

    internal class Parallelogram : ATetragon
    {
        public Parallelogram(float A, float B, float Angle) : base(A, B, Angle)
        {

        }

        public override float CountPerimeter()
        {
            return (a + b) * 2;
        }
        public override float CountArea()
        {
            return a * b * MathF.Sin(angle);
        }
    }
    internal class Diamond : ATetragon
    {
        public float d1 { get; set; }
        public float d2 { get; set; }

        public Diamond(float A, float B, float Angle, float D1, float D2) : base(A, B, Angle)
        {
            d1 = D1;
            d2 = D2;
        }

        public override float CountPerimeter()
        {
            return 4 * a;
        }
        public override float CountArea()
        {
            return d1 * d2 / 2;
        }
    }
    internal class Rectangle : ATetragon
    {
        public Rectangle(float A, float B, float Angle) : base(A, B, Angle)
        {
        }

        public override float CountPerimeter()
        {
            return (a + b) * 2;
        }
        public override float CountArea()
        {
            return a * b;
        }
    }
    internal class Square : Rectangle
    {
        public Square(float A, float B, float Angle) : base(A, B, Angle)
        {
        }

        public override float CountPerimeter()
        {
            return 4 * a;
        }
        public override float CountArea()
        {
            return a * a;
        }
    }
}
