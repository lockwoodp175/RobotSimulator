using RobotSimulator;
using RobotSimulator.Instructions;
using Xunit;

namespace RobotSimulatorTests
{
    public class InstructionTests
    {
        [Theory]
        [InlineData('N', 'W')]
        [InlineData('E', 'N')]
        [InlineData('S', 'E')]
        [InlineData('W', 'S')]
        public void TestLeftInstruction(char input, char expected)
        {
            // Arrange
            RobotState state = new RobotState
            {
                Orientation = input
            };
            var sut = new LeftInstruction();

            // Act
            var result = sut.Execute(state);

            // Assert
            Assert.Equal(expected, result.Orientation);
        }

        [Theory]
        [InlineData('N', 'E')]
        [InlineData('E', 'S')]
        [InlineData('S', 'W')]
        [InlineData('W', 'N')]
        public void TestRightInstruction(char input, char expected)
        {
            // Arrange
            RobotState state = new RobotState
            {
                Orientation = input
            };
            var sut = new RightInstruction();

            // Act
            var result = sut.Execute(state);

            // Assert
            Assert.Equal(expected, result.Orientation);
        }

        [Theory]
        [InlineData('N', 2, 3)]
        [InlineData('E', 3, 2)]
        [InlineData('S', 2, 1)]
        [InlineData('W', 1, 2)]
        public void TestForwardInstruction(char orientation, sbyte expX, sbyte expY)
        {
            // Arrange
            RobotState state = new RobotState
            {
                X = 2,
                Y = 2,
                Orientation = orientation,
            };
            var sut = new ForwardInstruction();

            // Act
            var result = sut.Execute(state);

            // Assert
            Assert.Equal(expX, result.X);
            Assert.Equal(expY, result.Y);
        }
    }
}

