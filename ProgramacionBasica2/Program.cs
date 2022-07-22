using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProgramacionBasica2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] prueba = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ReverseWithQueue(prueba);
            ReverseWithList(prueba);
            ReverseWithDict(prueba);


            //Lista de numeros para las funciones lambda
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            // funcion que enlista numeros pares
            List<int> pairNumbers = numbers.FindAll(x => ((x % 2) == 0));
            Console.WriteLine("Numeros pares: ");
            foreach (int number in pairNumbers)
            {
                Console.WriteLine(number);
            }

            // funcion que enlista numeros impares
            List<int> impairNumbers = numbers.FindAll(x => ((x % 2) != 0));
            Console.WriteLine("Numeros impares: ");
            foreach (int number in impairNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");

            //funcion que ordene una lista en orden descendiente
            List<int> listaNumeros = new List<int> { 5, 6, 7, 8, 1, 2, 3, 4, 9, 8, 7, 6 };
            List<int> listaDesc = listaNumeros.OrderByDescending(x => x).ToList();
            foreach (int number in listaDesc)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");

            //funcion que ordene una lista en orden ascendente
            List<int> listaAsc = listaNumeros.OrderBy(x => x).ToList();
            foreach (int number in listaAsc)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------");

            //Funcion que revisa si un valor es multiplo de 3 
            Func<int, bool> esMultiplo = x =>
            {
                return x % 3 == 0;
            };
            Console.WriteLine(esMultiplo(6));
            Console.WriteLine("------------");

            // LINQ
            string[] nombresLinq = { "Juan", "Pablo", "Pepe", "Ana", "Esteban", "Daniel", "Mariano", "Carolina", "Silvia", "Roberto", "Juanito", "Juana" };

            //3.1.Funcion que recibe un arreglo de strings y retorna el arreglo ordenado de forma descendente.
            //DescendingNumbers(nombresLinq);
            DescendingNumbers(nombresLinq);
            Console.WriteLine("------------");

            //3.2.Funcion que recibe un arreglo de strings y un string objetivo, la funcion retorna trueen caso de encontrar el string objetivo dentro del arreglo de strings, falseencaso contrario
            var resultado = stringObjetivo(nombresLinq, "Carlitos");
            Console.WriteLine(resultado);
            Console.WriteLine("------------");

            //3.3.Funcion que recibe un arreglo de strings y retorna los elementos del arreglo que empiecen con “Juan”.
            stringJuan(nombresLinq);
            Console.WriteLine("------------");

            //3.4.Funcion que recibe un arreglo de strings y concatena a cada uno de los elementos dentro del string el prefijo “hola ”. (ex. “Hola Juan”).
            Saludos(nombresLinq);




        }
        static Queue<int> ReverseWithQueue(int[] integerArray)
        {
            var timer = new Stopwatch();
            timer.Start();
            Queue<int> result = new Queue<int>();
            int i;

            for (i = integerArray.Length - 1; i >= 0; i--)
            {
                result.Enqueue(integerArray[i]);

            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Tiempo de ejecucion: " + timeTaken.ToString() + ". Primer valor de la queue: " + result.ElementAt(0));
            return result;
        }

        static List<int> ReverseWithList(int[] arregloEnteros)
        {
            var timer = new Stopwatch();
            timer.Start();

            List<int> result = new List<int>();
            int i;

            for (i = arregloEnteros.Length; i >= 1; i--)
            {
                result.Add(i);
            }

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Tiempo de ejecucion: " + timeTaken.ToString() + ". Primer valor de la lista: " + result.ElementAt(0));
            return result;
        }
        static Dictionary<string, int> ReverseWithDict(int[] arregloEnteros)
        {
            var timer = new Stopwatch();
            timer.Start();

            Dictionary<string, int> result = new Dictionary<string, int>();
            int i;

            for (i = arregloEnteros.Length; i >= 1; i--)
            {
                result.Add($"Key {i}", i);
            }

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;

            Console.WriteLine("Tiempo de ejecucion: " + timeTaken.ToString() + ". Primer valor del diccionario: " + result.ElementAt(0).Value);
            return result;
        }

        static void DescendingNumbers(string[] strings)
        {
            Array.Sort<string>(strings,
               new Comparison<string>(
                       (i1, i2) => i2.CompareTo(i1)
               ));

            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }

        static bool stringObjetivo(string[] strings, string objetivo)
        {
            return strings.All(objetivo.Contains);
        }

        static void stringJuan(string[] strings)
        {
            string[] juanes = strings.Where(x => x.StartsWith("Juan")).ToArray();
            foreach(string s in juanes)
            {
                Console.WriteLine(s);
            }
            
        } 
        static void Saludos(string[] strings) 
        {
            string[] saludos = strings.Select(x => "Hola " + x).ToArray();
            foreach (string s in saludos)
            {
                Console.WriteLine(s);
            }
        }

    }
}


