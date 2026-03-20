using ComputerConfigurator.Models;
using ComputerConfigurator.Builders;

namespace ComputerConfigurator.Factories
{
    public class GamingComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 7")
                .WithRAM(32)
                .WithGPU("NVIDIA RTX 4070")
                .WithComponent("RGB Keyboard")
                .WithComponent("Gaming Mouse")
                .WithComponent("Liquid Cooling")
                .Build();
        }
    }
}