// See https://aka.ms/new-console-template for more information
using Calculos;

Console.WriteLine("Digite um numero");
double numero1 = double.Parse(Console.ReadLine()!);
Console.WriteLine("Digite outro numero");
double numero2 = double.Parse(Console.ReadLine()!);

var resultado = Calculo.Somar(numero1, numero2);

Console.WriteLine(resultado);