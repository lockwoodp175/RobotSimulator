using RobotSimulator.Instructions;
using System.Collections.Generic;

namespace RobotSimulator
{
    /// <summary>
    /// Class to run robot commands
    /// </summary>
    public class Simulator
    {
        private readonly sbyte _width;
        private readonly sbyte _height;

        Dictionary<char, IInstruction> _Instructions = new Dictionary<char, IInstruction>
        {
            { 'L', new LeftInstruction() },
            { 'R', new RightInstruction() },
            { 'F', new ForwardInstruction() }
        };

        /// <summary>
        /// Sets the size of the board for this simulation
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Simulator(sbyte width, sbyte height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Execute commands for a single robot
        /// </summary>
        /// <param name="x">start x co-ordinate</param>
        /// <param name="y">start y co-ordinate</param>
        /// <param name="orientation">initial orientation</param>
        /// <param name="commands">string of commands</param>
        /// <returns></returns>
        public RobotState ExecuteCommands(sbyte x, sbyte y, char orientation, string commands)
        {
            RobotState state = new RobotState
            {
                X = x,
                Y = y,
                Orientation = orientation,
                Lost = false
            };

            foreach (char instruction in commands.ToUpperInvariant())
            {
                if (_Instructions.TryGetValue(instruction, out IInstruction instr))
                {
                    state = instr.Execute(state);
                }
            }
            return state;
        }
    }
}
