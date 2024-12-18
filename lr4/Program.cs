using System;

namespace lr4
{
    struct Vector3D
    {
        public double X, Y, Z;

        public Vector3D(double x, double y, double z)
        {
            try
            {
                if (x < 0 || y < 0 || z < 0)
                    throw new ArgumentException("Координати не можуть бути від'ємними.");
                X = x;
                Y = y;
                Z = z;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                X = Y = Z = 0;
            }
            finally
            {
                
            }
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static double operator *(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Vector3D operator *(Vector3D v, double scalar)
        {
            return new Vector3D(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static bool CompareLength(Vector3D v1, Vector3D v2)
        {
            return v1.Length() == v2.Length();
        }

        public override string ToString()
        {
            return $"Vector3D({X}, {Y}, {Z})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3D)
            {
                Vector3D v = (Vector3D)obj;
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X, Y, Z).GetHashCode();
        }
    }

    class Program
    {
        public static Vector3D[] ReadVectors(int n)
        {
            Vector3D[] vectors = new Vector3D[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть координати для вектора {i + 1} (X, Y, Z):");
                try
                {
                    double x = Convert.ToDouble(Console.ReadLine());
                    double y = Convert.ToDouble(Console.ReadLine());
                    double z = Convert.ToDouble(Console.ReadLine());
                    vectors[i] = new Vector3D(x, y, z);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некоректне значення.");
                    i--; 
                }
            }
            return vectors;
        }

        public static void PrintVector(Vector3D v)
        {
            Console.WriteLine(v.ToString());
        }

        public static void SortVectors(ref Vector3D[] vectors)
        {
            Array.Sort(vectors, (v1, v2) => v1.Length().CompareTo(v2.Length()));
        }

        public static void ModifyVector(ref Vector3D v)
        {
            try
            {
                Console.WriteLine("Введіть нові координати для вектора (X, Y, Z):");
                v.X = Convert.ToDouble(Console.ReadLine());
                v.Y = Convert.ToDouble(Console.ReadLine());
                v.Z = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректне значення.");
            }
        }

        static void Main(string[] args)
        {
            Vector3D[] vectors = ReadVectors(3);
            Console.WriteLine("Вектори до сортування:");
            foreach (var v in vectors)
            {
                PrintVector(v);
            }

            SortVectors(ref vectors);
            Console.WriteLine("Вектори після сортування:");
            foreach (var v in vectors)
            {
                PrintVector(v);
            }

            Vector3D vector = vectors[0];
            ModifyVector(ref vector);
            PrintVector(vector);
        }
    }
}
