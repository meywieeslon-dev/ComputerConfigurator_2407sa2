using System;
using System.Collections.Generic;
using ComputerConfigurator.Models;
using ComputerConfigurator.Factories;

namespace ComputerConfigurator.Registry
{
    public sealed class PrototypeRegistry
    {
       
        private static readonly Lazy<PrototypeRegistry> _instance =
            new Lazy<PrototypeRegistry>(() => new PrototypeRegistry());

       
        private Dictionary<string, Computer> _prototypes;

       
        private PrototypeRegistry()
        {
            _prototypes = new Dictionary<string, Computer>();

           
            _prototypes["office"] = new OfficeComputerFactory().Construct();
            _prototypes["gaming"] = new GamingComputerFactory().Construct();
            _prototypes["home"] = new HomeComputerFactory().Construct();

            Console.WriteLine(">>> PrototypeRegistry создан (Singleton)");
        }

        // 
        public static PrototypeRegistry Instance => _instance.Value;

        // 
        public Computer GetPrototype(string key)
        {
            if (_prototypes.TryGetValue(key, out Computer prototype))
            {
                Console.WriteLine($"  Получен прототип: {key}");
                return prototype.DeepCopy(); 
            }

            Console.WriteLine($"  Прототип '{key}' не найден!");
            return null;
        }

        
        public void ShowRegistryInfo()
        {
            Console.WriteLine("\n=== Доступные прототипы в реестре ===");
            foreach (var key in _prototypes.Keys)
            {
                Console.WriteLine($"  - {key}");
            }
            Console.WriteLine("======================================\n");
        }
    }
}