using System.Collections.Generic;

namespace RobotSimulator.Instructions
{
    public class RightInstruction : IInstruction
    {
        static Dictionary<char, char> MoveFromTo = new Dictionary<char, char>
    {
        { 'N', 'E' },
        { 'E', 'S' },
        { 'S', 'W' },
        { 'W', 'N' }
    };
        public RobotState Execute(RobotState state)
        {
            state.Orientation = MoveFromTo[state.Orientation];
            return state;
        }
    }
}
