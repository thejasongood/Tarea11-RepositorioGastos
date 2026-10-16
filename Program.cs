using System;
using System.Collections.Generic;

namespace RepositorioGastos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GastoRepositorio repo = new GastoRepositorio();
            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== CONTROL DE GASTOS =====");
                Console.WriteLine("1. Registrar gasto");
                Console.WriteLine("2. Listar gastos");
                Console.WriteLine("3. Salir");
                Console.Write("Elija una opción: ");

                string entrada = Console.ReadLine() ?? "";
                if (!int.TryParse(entrada, out opcion))
                {
                    opcion = -1;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarGasto(repo);
                        break;
                    case 2:
                        ListarGastos(repo);
                        break;
                    case 3:
                        Console.WriteLine("cerrando el sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta, intente de nuevo.");
                        break;
                }

            } while (opcion != 3);
        }

        private static void RegistrarGasto(GastoRepositorio repo)
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine() ?? "";

            Console.Write("Monto: ");
            string textoMonto = Console.ReadLine() ?? "";

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(categoria) ||
                !decimal.TryParse(textoMonto, out decimal monto) ||
                monto <= 0)
            {
                Console.WriteLine("Los datos no son válidos");
                return;
            }

            Gasto nuevo = new Gasto
            {
                Descripcion = descripcion .Trim(),
                Monto = monto,
                Categoria = categoria.Trim()
            };

            repo.Insertar(nuevo);
        }

        private static void ListarGastos(GastoRepositorio repo)
        {
            List<Gasto> gastos = repo.ListarTodos();

            if (gastos.Count == 0)
            {
                Console.WriteLine("No se encontraron gastos");
                return;
            }

            decimal total = 0;
            foreach (Gasto g in gastos)
            {
                Console.WriteLine(g.ToString());
                total += g.Monto;
            }

            Console.WriteLine($"Total de gastos: Q {total:N2}");
        }
    }
}