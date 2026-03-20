using ComputerConfigurator.Builders;
using ComputerConfigurator.Factories;
using ComputerConfigurator.Models;
using ComputerConfigurator.Registry;

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

            
            Console.WriteLine("\n>>> ЭТАП 2: Паттерн Прототип\n");

            Computer original = new ComputerBuilder()
                .WithCPU("AMD Ryzen 5")
                .WithRAM(16)
                .WithGPU("NVIDIA RTX 3060")
                .WithComponent("SSD 512GB")
                .WithComponent("WiFi Card")
                .Build();

            Console.WriteLine("Оригинал:");
            original.Display();

            Console.WriteLine("Поверхностное копирование (Shallow Copy):");
            Computer shallowClone = original.ShallowCopy();
            shallowClone.CPU = "AMD Ryzen 7";
            shallowClone.AdditionalComponents.Add("RGB Lighting");

            Console.WriteLine("Клон (после изменений):");
            shallowClone.Display();
            Console.WriteLine("Оригинал (после изменений клона):");
            original.Display();
            Console.WriteLine("⚠️  Оригинал изменился! (Shallow Copy)\n");

            Console.WriteLine("Глубокое копирование (Deep Copy):");
            Computer deepClone = original.DeepCopy();
            deepClone.CPU = "Intel Core i7";
            deepClone.AdditionalComponents.Add("Water Cooling");

            Console.WriteLine("Глубокий клон (после изменений):");
            deepClone.Display();
            Console.WriteLine("Оригинал (после изменений глубокого клона):");
            original.Display();
            Console.WriteLine("✅ Оригинал НЕ изменился! (Deep Copy)\n");

            Console.WriteLine("=== ЭТАП 2 завершён ===\n");
            Console.WriteLine("Нажмите Enter для продолжения к Этапу 3 (Singleton)...");
            Console.ReadLine();

            
            Console.WriteLine("\n>>> ЭТАП 3: Паттерн Одиночка (Singleton)\n");

           
            Console.WriteLine("1. Получаем доступ к PrototypeRegistry через Instance:");
            PrototypeRegistry registry1 = PrototypeRegistry.Instance;
            registry1.ShowRegistryInfo();

            
            Console.WriteLine("2. Получаем второй доступ к реестру:");
            PrototypeRegistry registry2 = PrototypeRegistry.Instance;

           
            Console.WriteLine("3. Проверяем, что это один экземпляр (ReferenceEquals):");
            bool isSameInstance = ReferenceEquals(registry1, registry2);
            Console.WriteLine($"  registry1 == registry2: {isSameInstance}");

            if (isSameInstance)
                Console.WriteLine("  ✅ Singleton работает! Это один и тот же объект.\n");
            else
                Console.WriteLine("  ❌ Ошибка! Это разные объекты.\n");

           
            Console.WriteLine("4. Получаем прототип 'gaming' из реестра и модифицируем:");
            Computer gamingFromRegistry = registry1.GetPrototype("gaming");
            gamingFromRegistry.Display();

            Console.WriteLine("Модифицируем полученный прототип:");
            gamingFromRegistry.CPU = "AMD Ryzen 9";
            gamingFromRegistry.RAM = 64;
            gamingFromRegistry.AdditionalComponents.Add("Custom Water Cooling");
            gamingFromRegistry.Display();

           
            Console.WriteLine("5. Получаем прототип 'gaming' повторно (должен быть оригинал):");
            Computer gamingFromRegistry2 = registry1.GetPrototype("gaming");
            gamingFromRegistry2.Display();

            Console.WriteLine("✅ Прототип в реестре НЕ изменился! (возвращается DeepCopy)\n");

            Console.WriteLine("=== ЭТАП 3 завершён ===\n");
            Console.WriteLine("=== ВСЕ ПАТТЕРНЫ ПРОДЕМОНСТРИРОВАНЫ ===\n");
            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}