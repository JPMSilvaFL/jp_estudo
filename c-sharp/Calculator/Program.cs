using System;

namespace Calculator {
    class Program {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Calculadora ----");
            Console.WriteLine("Escolha uma das opções: ");
            Console.WriteLine("1- Soma.");
            Console.WriteLine("2- Subtração.");
            Console.WriteLine("3- Multiplicação.");
            Console.WriteLine("4- Divisão.");
            Console.WriteLine("9- Para encerrar aplicação.");

            int x = 0;
            while(x == 0)
            {
                x = int.Parse(Console.ReadLine());
                if (x == 1) {
                    Console.WriteLine("Valor 1:");
                    float v1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Valor 2:");
                    float v2 = float.Parse(Console.ReadLine());
                    Console.WriteLine(Soma(v1, v2));
                    x = 0;
                } else if (x == 2) {
                    Console.WriteLine("Valor 1:");
                    float v1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Valor 2:");
                    float v2 = float.Parse(Console.ReadLine());
                    Console.WriteLine(Subtracao(v1, v2));
                    x = 0;
                } else if (x == 3) {
                    Console.WriteLine("Valor 1:");
                    float v1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Valor 2:");
                    float v2 = float.Parse(Console.ReadLine());
                    Console.WriteLine(Multiplicacao(v1, v2));
                    x = 0;
                } else if (x == 4) {
                    Console.WriteLine("Valor 1:");
                    float v1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Valor 2:");
                    float v2 = float.Parse(Console.ReadLine());
                    Console.WriteLine(Divisao(v1, v2));
                    x = 0;
                } else if (x == 9)
                {
                    Console.WriteLine("Aplicação encerrada!!!");
                }
                else
                {
                    Console.WriteLine("Escolha uma opção válida!!!");
                    x = 0;
                }
            }
            
            static double Soma(double valor1, double valor2) {
                return valor1 + valor2;
            }
            
            static double Subtracao(double valor1,double valor2) {
                return valor1 - valor2;
            }
            static double Divisao(double valor1,double valor2) {
                return valor1 / valor2;
            }
            static double Multiplicacao(double valor1,double valor2) {
                return valor1 * valor2;
            }
        }
    }
}

