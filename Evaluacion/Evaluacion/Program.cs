using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion
{
    internal class Program
    {
        static bool Validar_datos(double precio, double cantidad)
        {
            if (precio > 0 || cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("EL precio y cantidad tienen que ser mayor a 0");
                return false;
            }
        }
        static void Buscar(string Codigo_Encontrado, string[] codigos, string[] proveedores, double[,] datos)
        {
            bool encontrado = false;
            for (int i = 0; i < codigos.Length; i++)
            {
                if (codigos[i] == Codigo_Encontrado)
                {
                    double monto = datos[i, 0] * datos[i, 1];
                    Console.WriteLine("Encontrado");
                    Console.WriteLine("Proveedor:" + proveedores[i], "Monto:" + monto);
                    encontrado = true;
                    break;

                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No encontrado");
            }
        }
        static void Main()
        {
            string[] codigos =
            {
                "OC-001","OC-002","OC-003","OC-004","OC-005","0C-006"
            };
            string[] proveedores =
            {
                "Proveedor 1","Proveedor 2","Proveedor 3","Proveedor 4","Proveedor 5","Proveedor 6"
            };
            double[,] datos =
            {
                {150.0,10 },{450.0,2 },{80.0,50},{1200.0,1},{25.0,100},{600.0,3}
            };
            double[] montos = new double[6];
            double Total_Acumulado = 0;
            int Contador = 0;
            for (int i = 0; i < 6; i++)
            {
                double precio = datos[i, 0];
                int cantidad = (int)datos[i, 1];
                if (Validar_datos(precio, cantidad))
                {
                    montos[i] = precio * cantidad;
                    Total_Acumulado += montos[i];
                    if (montos[i] > 1000)
                    {
                        Contador++;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        double tempMonto = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = tempMonto;

                        string tempCodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tempCodigo;

                        string tempProveedor = proveedores[j];
                        proveedores[j] = proveedores[j + 1];
                        proveedores[j + 1] = tempProveedor;

                        for (int k = 0; k < 2; k++)
                        {
                            double tempDato = datos[j, k];
                            datos[j, k] = datos[j + 1, k];
                            datos[j + 1, k] = tempDato;
                        }
                    }
                }
            }
            Console.WriteLine("==============================");
            Console.WriteLine("CONTROL ORDENES DE COMPRA");
            Console.WriteLine("==============================");
            Console.WriteLine("\n---REPORTE ORDENADO POR MONTO NETO---");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((i + 1) + ".Codigo:" + codigos[i] + "|Proveedor:" + proveedores[i] + "|Monto:$" + montos[i].ToString("N2"));
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("RESUMEN");
            Console.WriteLine("Gran total acumulado:$" + Total_Acumulado.ToString("N2"));
            Console.WriteLine("Compras(>$1000):" + Contador + "ordenes");
            Console.WriteLine("\n==============================");
            Console.WriteLine("PROCESO DE BUSQUEDA");
            Console.Write("Ingrese el codigo que desea buscar:");
            string Codigo_Encontrado = Console.ReadLine();
            Buscar(Codigo_Encontrado, codigos, proveedores, datos);
            Console.WriteLine("\n==============================");
        }
        static void Main(string[] args)
        {


        }
    }
}