namespace RobotSimulator.Instructions
{
    public interface IInstruction
    {
        RobotState Execute(RobotState state);
    }
}
