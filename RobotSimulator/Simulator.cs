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

        Dictionary<char, IInstruction> _instructionHandlers = new Dictionary<char, IInstruction>
        {
            { 'L', new LeftInstruction() },
            { 'R', new RightInstruction() },
            { 'F', new ForwardInstruction() }
        };

        private HashSet<(sbyte, sbyte)> _lostCoordinates = new HashSet<(sbyte, sbyte)>();

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
                if (_instructionHandlers.TryGetValue(instruction, out IInstruction instr))
                {
                    var newState = instr.Execute(state);
                    bool ignoreMove = false;

                    if (IsLost(newState))
                    {
                        if (!LostOneHereBefore(state))
                        {
                            var lostRobot = new RobotState(state.X, state.Y, state.Orientation, true);
                            // store the coordinates of the lost robot
                            _lostCoordinates.Add((lostRobot.X, lostRobot.Y));
                            return lostRobot;
                        }
                        // Ignore this move as it would lose the robot and we've already lost one from here before
                        ignoreMove = true;
                    }

                    state = ignoreMove ? state : newState;
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

        /// <summary>
        /// Check if we have lost a previous robot from this position
        /// </summary>
        /// <param name="state"></param>
        /// <returns>true/false</returns>
        private bool LostOneHereBefore(RobotState state)
        {
            return _lostCoordinates.Contains((state.X, state.Y));
        }
    }
}
