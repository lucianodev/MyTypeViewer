using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MyTypeViewer
{
    class Program
    {
        static void ListarMetodos(Type t)
        {
            Console.WriteLine("****** Metodos ******");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo  i in mi)
                Console.WriteLine($"->{i.Name}");
            Console.WriteLine();
        }

        static void ListarCampos(Type t)
        {
            Console.WriteLine("****** Campos ******");
            FieldInfo[] fi = t.GetFields();
            foreach (FieldInfo i in fi)
                Console.WriteLine($"->{i.Name}");
            Console.WriteLine();
        }

        static void ListarProp(Type t)
        {
            Console.WriteLine("****** Propriedades ******");
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo i in pi)
                Console.WriteLine($"->{i.Name}");
            Console.WriteLine();
        }

        static void ListarIterfaces(Type t)
        {
            Console.WriteLine("****** Interfaces ******");
            Type[] ii = t.GetInterfaces();
            foreach (Type i in ii)
                Console.WriteLine($"->{i.Name}");
            Console.WriteLine();
        }

        static void ListarOutrasInformaceos(Type t)
        {
            Console.WriteLine("****** Várias Estatísticas ******");
            Console.WriteLine($"Classe Base é:{t.BaseType}");
            Console.WriteLine($"É Abstrato?:{t.IsAbstract}");
            Console.WriteLine($"É Selado?:{t.IsSealed}");
            Console.WriteLine($"É Genérico?:{t.IsGenericTypeDefinition}");
            Console.WriteLine($"É uma Tipo de Classe?:{t.IsClass}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*********** Visualizador de tipos *********");
            string nome = "";
            bool terminou = false;

            do
            {
                Console.WriteLine("\nEntre com o nome do tipo para nalisar:");
                Console.Write("Ou S para sair: ");

                nome = Console.ReadLine();
                if (nome.ToUpper()=="S")
                {
                    terminou = true;
                    break; 
                }

                try
                {
                    Type t = Type.GetType(nome);
                    Console.WriteLine("");
                    ListarOutrasInformaceos(t);
                    ListarCampos(t);
                    ListarProp(t);
                    ListarMetodos(t);
                    ListarIterfaces(t);

                }
                catch (Exception)
                {
                    Console.Beep();
                    Console.WriteLine("Não foi encontrado o tipo.");
                }
            } while (!terminou);

            
        }
    }
}
