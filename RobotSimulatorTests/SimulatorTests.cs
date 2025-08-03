using RobotSimulator;
using Xunit;

namespace RobotSimulatorTests
{
    public class SimulatorTests
    {
        [Fact]
        public void TestSampleSimulation()
        {
            // Arrange
            var sut = new Simulator(5, 3);

            // Act
            var robot1 = sut.ExecuteCommands(1, 1, 'E', "RFRFRFRF");
            var robot2 = sut.ExecuteCommands(3, 2, 'N', "FRRFLLFFRRFLL");
            var robot3 = sut.ExecuteCommands(0, 3, 'W', "LLFFFLFLFL");

            // Assert
            Assert.Equal(1, robot1.X);
            Assert.Equal(1, robot1.Y);
            Assert.Equal('E', robot1.Orientation);
            Assert.False(robot1.Lost);

            Assert.Equal(3, robot2.X);
            Assert.Equal(3, robot2.Y);
            Assert.Equal('N', robot2.Orientation);
            Assert.True(robot2.Lost);

            Assert.Equal(2, robot3.X);
            Assert.Equal(3, robot3.Y);
            Assert.Equal('S', robot3.Orientation);
            Assert.False(robot3.Lost);
        }
    }
}
