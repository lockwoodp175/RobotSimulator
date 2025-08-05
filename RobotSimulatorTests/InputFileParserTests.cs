using RobotSimulator;
using RobotSimulator.Instructions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace RobotSimulatorTests
{
    public class InputFileParserTests
    {
        [Fact]
        public void MissingInputFileThrowsIOException()
        {
            // Arrange
            var sut = new InputFileParser();

            // Act
            _ = Assert.ThrowsAsync<IOException>(async () => { await sut.Parse("missingFile"); });
        }

        [Fact]
        public async Task TestTooManyGridSizeArgsThrowsException()
        {
            // Arrange
            var sut = new InputFileParser();
            using MemoryStream s = new MemoryStream();
            using StreamWriter w = new StreamWriter(s);
            w.WriteLine("x y n");
            w.Flush();
            s.Position = 0;
            StreamReader r = new StreamReader(s);

            // Act
            Exception ex = await Assert.ThrowsAsync<Exception>(async () => { await sut.Parse(r); });

            Assert.Equal("Incorrect grid size parameters x y n", ex.Message);
        }
    }
}
