using System;
using System.Text;

namespace BuildPractice{
    public class Computer{
        private string? CPU;
        private string? RAM;
        private string? storage;
        private string? GPU;

        public Computer(string? _CPU, string? _RAM, string? _storage, string? _GPU){
            CPU = _CPU;
            RAM = _RAM;
            storage = _storage;
            GPU = _GPU;
        }

        public void DisplaySystem(){
            StringBuilder output = new StringBuilder();
            if (CPU != null)
                output.Append($"CPU: {CPU}, ");

            if (RAM != null)
                output.Append($"RAM: {RAM}, ");

            if (storage != null)
                output.Append($"Storage: {storage}, ");

            if (GPU != null)
                output.Append($"GPU: {GPU}, ");

            Console.WriteLine(output.ToString());
        }
    }

    public class ComputerBuilder{
        private string? CPU;
        private string? RAM;
        private string? storage;
        private string? GPU;

        public ComputerBuilder(){
            CPU = null;
            RAM = null;
            storage = null;
            GPU = null;
        }

        public ComputerBuilder SetStorage(string? _storage){
            storage = _storage;
            return this;
        }

        public ComputerBuilder SetGPU(string? _GPU){
            GPU = _GPU;
            return this;
        }

        public ComputerBuilder SetRAM(string? _RAM){
            RAM = _RAM;
            return this;
        }

        public ComputerBuilder SetCPU(string? _CPU){
            CPU = _CPU;
            return this;
        }

        public Computer Build(){
            return new Computer(CPU, RAM, storage, GPU);
        }
    }

    class Test{
        static void Main(string[] args){
            Computer basicComputer = new ComputerBuilder().SetRAM("Dell").SetCPU("Intel").SetStorage("200GB").Build();
            basicComputer.DisplaySystem();

            Computer otherComputer = new ComputerBuilder().SetRAM("Dell").SetCPU("AMD").SetStorage("400GB").SetGPU("NVIDIA").Build();
            otherComputer.DisplaySystem();
        }
    }
}