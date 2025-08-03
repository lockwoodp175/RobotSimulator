namespace RobotSimulator
{
    /// <summary>
    /// Class to run robot commands
    /// </summary>
    public class Simulator
    {
        private readonly sbyte _width;
        private readonly sbyte _height;

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
            return new RobotState
            {
                X = x,
                Y = y,
                Orientation = orientation,
                Lost = false
            };
        }
    }
}
