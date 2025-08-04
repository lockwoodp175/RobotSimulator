using System.Collections.Generic;

namespace RobotSimulator.Instructions
{
    public class LeftInstruction : IInstruction
    {
        static Dictionary<char, char> MoveFromTo = new Dictionary<char, char>
    {
        { 'N', 'W' },
        { 'E', 'N' },
        { 'S', 'E' },
        { 'W', 'S' }
    };
        public RobotState Execute(RobotState state)
        {
            return new RobotState(state.X, state.Y, MoveFromTo[state.Orientation], state.Lost);
        }
    }
}
