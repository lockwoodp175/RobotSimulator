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

        List<RobotState> _LostRobots = new List<RobotState>();

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
        /// Execute instructions for a single robot
        /// </summary>
        /// <param name="x">start x co-ordinate</param>
        /// <param name="y">start y co-ordinate</param>
        /// <param name="orientation">initial orientation</param>
        /// <param name="instructions">string of commands</param>
        /// <returns></returns>
        public RobotState Execute(sbyte x, sbyte y, char orientation, string instructions)
        {
            RobotState state = new RobotState(x, y, orientation, false);

            foreach (char instruction in instructions.ToUpperInvariant())
            {
                if (_Instructions.TryGetValue(instruction, out IInstruction instr))
                {
                    var newState = instr.Execute(state);
                    if (IsLost(newState))
                    {
                        var lostRobot = new RobotState(state.X, state.Y, state.Orientation, true);
                        _LostRobots.Add(lostRobot);
                        return lostRobot;
                    }
                }
            }
            return state;
        }

        /// <summary>
        /// Test if a robot has been lost ie has moved outside the grid
        /// </summary>
        /// <param name="state">Robot state</param>
        /// <returns>true/false</returns>
        private bool IsLost(RobotState state)
        {
            return (state.X < 0 || state.X > _width || state.Y < 0 || state.Y > _height);
        }
    }
}
