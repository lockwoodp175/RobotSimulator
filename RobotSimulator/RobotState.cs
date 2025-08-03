namespace RobotSimulator
{
    public struct RobotState
    {
        public sbyte X { get; set; }
        public sbyte Y { get; set; }
        public char Orientation { get; set; }
        public bool Lost { get; set; }
    }
}
