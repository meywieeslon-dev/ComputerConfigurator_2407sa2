using ComputerConfigurator.Models;
using ComputerConfigurator.Builders;

namespace ComputerConfigurator.Factories
{
    public class OfficeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i3")
                .WithRAM(8)
                .WithGPU("Intel UHD Graphics")
                .WithComponent("Office Package")
                .WithComponent("Webcam")
                .Build();
        }
    }
}