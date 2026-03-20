using ComputerConfigurator.Builders;
using ComputerConfigurator.Factories;
using ComputerConfigurator.Models;

namespace ComputerConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа №4 ===");
            Console.WriteLine("Порождающие паттерны: Builder, Prototype, Singleton\n");

            Console.WriteLine(">>> ЭТАП 1: Паттерн Строитель + Фабричный метод\n");

           
            IComputerFactory officeFactory = new OfficeComputerFactory();
            Computer officePC = officeFactory.Construct();
            Console.WriteLine("Офисный ПК (через фабрику):");
            officePC.Display();

            IComputerFactory gamingFactory = new GamingComputerFactory();
            Computer gamingPC = gamingFactory.Construct();
            Console.WriteLine("Игровой ПК (через фабрику):");
            gamingPC.Display();

            IComputerFactory homeFactory = new HomeComputerFactory();
            Computer homePC = homeFactory.Construct();
            Console.WriteLine("Домашний ПК (через фабрику):");
            homePC.Display();

          
            Console.WriteLine("ПК через Builder (напрямую):");
            Computer customPC = new ComputerBuilder()
                .WithCPU("Intel Core i9")
                .WithRAM(64)
                .WithGPU("NVIDIA RTX 4090")
                .WithComponent("4K Monitor")
                .WithComponent("Mechanical Keyboard")
                .Build();
            customPC.Display();

            Console.WriteLine("=== ЭТАП 1 завершён ===\n");
            Console.WriteLine("Нажмите Enter для продолжения к Этапу 2 (Prototype)...");
            Console.ReadLine();
        }
    }
}