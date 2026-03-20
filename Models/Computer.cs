namespace ComputerConfigurator.Models
{
    public class Computer
    {
        public string CPU { get; set; }
        public int RAM { get; set; }
        public string GPU { get; set; }
        public List<string> AdditionalComponents { get; set; }

        public Computer()
        {
            AdditionalComponents = new List<string>();
        }

        public void Display()
        {
            Console.WriteLine("\n=== Конфигурация компьютера ===");
            Console.WriteLine($"Процессор: {CPU}");
            Console.WriteLine($"Оперативная память: {RAM} ГБ");
            Console.WriteLine($"Видеокарта: {GPU}");
            Console.WriteLine("Дополнительные компоненты:");

            if (AdditionalComponents.Count == 0)
                Console.WriteLine("  Нет");
            else
                foreach (var component in AdditionalComponents)
                    Console.WriteLine($"  - {component}");

            Console.WriteLine("===============================\n");
        }
    }
}