using ComputerConfigurator.Models;

namespace ComputerConfigurator.Factories
{
    public interface IComputerFactory
    {
        Computer Construct();
    }
}