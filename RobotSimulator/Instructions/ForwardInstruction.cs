using System.Collections.Generic;

namespace RobotSimulator.Instructions
{
    public class ForwardInstruction : IInstruction
    {
        static Dictionary<char, (sbyte, sbyte)> Adjustments = new Dictionary<char, (sbyte, sbyte)>
    {
        { 'N', (0, 1) },
        { 'E', (1, 0) },
        { 'S', (0, -1) },
        { 'W', (-1, 0) }
    };
        public RobotState Execute(RobotState state)
        {
            (var xa, var ya) = Adjustments[state.Orientation];
            return new RobotState((sbyte)(state.X + xa), (sbyte)(state.Y + ya), state.Orientation, state.Lost);
        }
    }
}
