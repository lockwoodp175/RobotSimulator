namespace RobotSimulator
{
    public class RobotState
    {
        public RobotState(sbyte x, sbyte y, char orientation, bool lost)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            Lost = lost;
        }
        public sbyte X { get; }
        public sbyte Y { get; }
        public char Orientation { get; }
        public bool Lost { get; }
    }
}
