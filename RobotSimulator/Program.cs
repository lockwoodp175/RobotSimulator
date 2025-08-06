using System;
using System.Threading.Tasks;

namespace RobotSimulator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                InputFileParser p = new InputFileParser();
                await p.Parse(args[0]);

                Simulator rr = new Simulator(p.Width, p.Height);
                foreach (var i in p.Instructions)
                {
                    RobotState state = rr.Execute(i.StartX, i.StartY, i.Orientation, i.Instructions);

                    string lost = state.Lost ? "LOST" : "";
                    Console.WriteLine($"{state.X} {state.Y} {state.Orientation} {lost}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading input file: {ex.Message}");
            }
        }
    }
}
