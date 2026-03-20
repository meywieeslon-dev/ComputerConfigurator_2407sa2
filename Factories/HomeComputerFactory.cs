using ComputerConfigurator.Models;
using ComputerConfigurator.Builders;

namespace ComputerConfigurator.Factories
{
    public class HomeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i5")
                .WithRAM(16)
                .WithGPU("NVIDIA GTX 1650")
                .WithComponent("WiFi Adapter")
                .WithComponent("Bluetooth")
                .Build();
        }
    }
}