using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace console_testing_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitalRoot(16));
            Console.WriteLine(DigitalRoot(942));
            Console.WriteLine(DigitalRoot(132189));

            Console.ReadLine();
        }


        public static int DigitalRoot(int num)
        {
            while (num / 10.0 >= 1) num = num.ToString().Sum(c => int.Parse(c.ToString()));
            return num;
        }

        public static string FindTheMissingLetter(List<string> lista)
        {
            for (var i = 0; i < lista.Count() - 1; i++)
                if (lista[i+1][0] - lista[i][0] > 1)
                    return ((char)(lista[i][0] + 1)).ToString();
            return "";
        }

        public static decimal MetricasDeExecucao(Func<long, int> funcao, long arg, int times)
        {
            var relogio = new Stopwatch();

            relogio.Start();
            for (int i = 0; i < times; i++)
            {
                funcao(arg);                
            }
            relogio.Stop();
            var totalTempo = relogio.ElapsedMilliseconds;
            var media = totalTempo / (times + 0.0m);

            var resultadoFuncao = funcao(arg);

            Console.WriteLine($"------------------{times} TESTES ------------------");
            Console.WriteLine($"[{arg}]: {resultadoFuncao}");
            Console.WriteLine($"Tempo total: {totalTempo / 1000m}s");
            Console.WriteLine($"Media: {media / 1000m}s");
            Console.WriteLine();

            return media;
        }

        public static int findNb(long total)
        {
            var n = 1;
            decimal cubo = 0;

            while(true)
            {
                cubo += (decimal) n*n*n;
                if (cubo == total) return n;
                else if (cubo > total) return -1;
                else n++;
            }
        }

        public static void OddNumberOfTimes(List<int> numbers)
        {
            var listasPorNumeros = numbers.GroupBy(n => n).ToList();

            var i = 0;
            listasPorNumeros.ForEach(lista => Console.WriteLine($"lista[{i++}] -> Key: {lista.Key} [ {string.Join(", ", lista)} ]"));

            var resposta = numbers.GroupBy(n => n).First(array => array.Count() % 2 != 0).Key;

            Console.WriteLine($"Numero: {resposta}");
        }

        public bool VerificaSeHaLetraRepetida(string entrada) => entrada.ToLower().Distinct().Count() < entrada.Length;

        public static int Persistence(int num)
        {
            var c = 0;
            for(; num / 10.0 >= 1; c++) num = num.ToString().Sum(c => int.Parse(c.ToString()));
            return c;
        }

        public static string ToCamelCase(string phrase)
        {
            var camel = "";

            for (var i = 0; i < phrase.Length; i++)
            {
                camel += (phrase[i] != '_' && phrase[i] != '-')
                        ? phrase[i].ToString()
                        : (i == phrase.Length - 1)
                            ? ""
                            : phrase[++i].ToString().ToUpper();
            }

            return camel.Trim();
        }

        public static string ToCamelCase2(string phrase)
        {
            string upperFirstLetter(List<string> words)
            {
                var final = words[0]; //sempre insere a primeira como estiver
                for (var i = 1; i < words.Count(); i++) //itera a partir da segunda
                    final += !string.IsNullOrEmpty(words[i])
                        ? char.ToUpper(words[i][0]) + words[i]?.Substring(1) //primeira letra maiuscula + resto da palavra
                        : "";

                return final;
            }

            var words1 = phrase.Split("-").ToList();
            var final1 = upperFirstLetter(words1);
            var words2 = final1.Split("_").ToList();
            return upperFirstLetter(words2);
        }

        public static string SpinWords(string phrase)
        {
            return string.Join(" ", phrase.Split(' ').Select(w => w.Length < 5 ? w : new string(w.Reverse().ToArray())).ToList());
        }

        public static int IntegerDiference(List<int> lista, int dif)
        {
            lista.Sort();
            var count = 0;
            for (var i = 0; i < lista.Count(); i++)
                for (var j = i + 1; j < lista.Count(); j++)
                    if (lista[j] - lista[i] == dif)
                        count++;

            return count;
        }
               

    }

}
