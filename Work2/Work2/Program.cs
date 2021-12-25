using System;

namespace Work2
{
    class Program
    {
        static void Main(string[] args)
        {
            double r;
            Console.Write("Введите радиус R (Стандартный радиус 2, при радусе = 0 будет точка в центре окружности:\n");
            r = Convert.ToDouble(Console.ReadLine());
            while (r < 0)
                {
                    Console.Write("Значение должно быть больше или равно 0.\n");
                    r = Convert.ToDouble(Console.ReadLine());
                }

            if (r < 2)
            {
                Console.Write("Радиус меньше 2, в функции будут разрывы.\n");
            }
            else if (r > 2)
            {
                Console.Write("Радиус больше 2, в функции в точках 1 и 5 должны появиться 2 значения y.\n");
            }
            else if (r == 2)
            {
                Console.Write("Радиус равен 2, в функции в точках 1 и 5 должно быть по 1 значения y - разрывов нет.\n");
            }
            else
            {
                Console.Write("Радиус равен 0, в функции при x=3, y будет равно =0, иных точек вокруг быть не должно.\n");
            }



            PrintingAllValues(r);
            PrintingOneValue(r);

        }

        private static void PrintingOneValue(double r)
        {
            Console.Write("\n-----------------------------------------\n Введите x, для получения значений y, при вводе 666 - произойдет завершение работы!\n");
            double x;
            do
            {
                Console.Write("Для x = ");
                x = Convert.ToDouble(Console.ReadLine());
                if (x < -3)
                {
                    Console.Write("\n На участке функция не существует;");
                }
                if (x >= -3 && x < -1)
                {
                    Console.Write("\n Функция принимает значение: y = {1:0.00};", x, segment1(x));
                }

                if (x >= -1 && x <= 1)
                {
                    Console.Write("\n Функция принимает значение: y = {1:0.00};", x, segment2(x));
                }
                if (x == 1 && r > 2 )
                {
                    Console.Write(" {1:0.00};", x, segment3(r, x));
                }
                    

                if (x > 1 && x < 5 && r != 0)
                {
                    Console.Write("\n Функция принимает значение: y = {1:0.00};", x, segment3(r, x));
                }
                else if (x == 3 && r == 0)
                {
                    Console.Write("\n Функция принимает значение: y = {1:0.00};", x, 0);
                }
                else if (x > 1 && x < 5 && r == 0 && x != 3)
                {
                    Console.Write("\n Функция принимает значение: y = {1:0.00}", x, segment3(r, x));
                }


                if (x >= 5 && x <= 7)
                {
                    Console.Write("\n Функция принимает значение: y = {1:0.00}", x, segment4(x));
                }
                if (x == 5 && r > 2)
                {
                    Console.Write(" {1:0.00}", x, segment3(r, x));
                }
                if (x > 7)
                {
                    Console.Write("\n На участке функция не существует");
                }
                Console.Write("\n ~~~~~~~~~~~~~~~~~~~~~~~~~ \n");
            }
            while
            (x !< 666);
        }

        private static double PrintingAllValues(double r)
        {
            Console.Write("Таблица зависимости y от x с шагом в 0.2: \n");
            double[] x = new double[51];
            //Вот ни в какую не хотел просто  for ( x = -3; x <= 7; i += 0.2)
            //в таком случае никогда не получалось ровно 5 или 1, чтобы сравнить, поэтому никогда не было двойного значения или точки при нуливом радиусе. 
            //Пришлось извращаться
            for (int i = 0; i <= 50; i += 1)   
            {
                x[i] = -3 + i * 0.2;
            }
                for (int i = 0; i <= 50; i += 1)
            {
                if (x[i] < -3)
                {
                    Console.Write("\n На участке функция не существует;");
                }
                if (x[i] >= -3 && x[i] < -1)
                {
                    Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], segment1(x[i]));
                }

                if (x[i] >= -1 && x[i] <= 1)
                {
                    Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], segment2(x[i]));
                }
                if (x[i] == 1 && r > 2)
                {
                    Console.Write(" {1:0.00};", x[i], segment3(r, x[i]));
                }


                if (r == 0)
                { if (x[i] == 3)
                    {
                        Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], 0);
                    }

                    else if (x[i] > 1 && x[i] < 3)
                    {
                        Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], segment3(r, x[i]));
                    }

                    else if (x[i] > 3 && x[i] < 5)
                    {
                        Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], segment3(r, x[i]));
                    }
                }
                else if (r > 0 && x[i] > 1 && x[i] < 5)
                {
                    Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], segment3(r, x[i]));
                }


                if (x[i] >= 5 && x[i] <= 7)
                {
                    Console.Write("\n y({0:0.00}) = {1:0.00};", x[i], segment4(x[i]));
                }
                if (x[i] == 5 && r > 2)
                {
                    Console.Write(" {1:0.00}", x, segment3(r, x[i]));
                }

                if (x[i] > 7)
                {
                    Console.Write("\n На участке функция не существует");
                }

            }

            return x[0];
        }

        static double segment1(double x)
        {
            double y;
            y = -1-x;
            return y;
        }


        static double segment2(double x)
        {
            double y;
            y = 0*x;
            return y;
        }

        static double segment3(double r, double x)
        {
                double y;
                y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow((x - 3), 2));
                return y;
        }


        static double segment4(double x)
        {
            double y;
            y = (5-x)/2;
            return y;
        }
    }
}