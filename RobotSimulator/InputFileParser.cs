using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RobotSimulator
{
    public class InputFileParser
    {
        public sbyte Width { get; set; }
        public sbyte Height { get; set; }
        public List<RobotInstructions?> Instructions { get; set; } = new List<RobotInstructions?>();

        /// <summary>
        /// Parse the input instructions file
        /// </summary>
        /// <param name="path">input file name</param>
        /// <returns></returns>
        public async Task Parse(string path)
        {

            using StreamReader reader = new StreamReader(path);
            await Parse(reader);
        }

        /// <summary>
        /// Parse input StreamReader
        /// For simplicity, I throw exceptions if the parsing fails
        /// </summary>
        /// <param name="reader">input stream</param>
        /// <returns></returns>
        public async Task Parse(StreamReader reader)
        {
            // Catch stream reader exceptions in calling code.
            string sizeStr = await reader.ReadLineAsync();
            string[] parts = sizeStr.Split(new char[] { ' ', '\t' });
            if (parts.Length != 2)
            {
                throw new Exception($"Incorrect grid size parameters {sizeStr}");
            }
            (sbyte w, sbyte h) = ParseCoordinates(parts);
            Width = w;
            Height = h;

            RobotInstructions? instr = await ReadInputInstruction(reader);
            while (instr != null)
            {
                //store
                Instructions.Add(instr);
                instr = await ReadInputInstruction(reader);
            }
        }
        private (sbyte, sbyte) ParseCoordinates(string[] parts)
        {
            if (!sbyte.TryParse(parts[0], out sbyte x))
            {
                throw new Exception($"Error parsing X coordinate {parts[0]}");
            }
            if (!sbyte.TryParse(parts[1], out sbyte y))
            {
                throw new Exception($"Error parsing Y coordinate {parts[0]}");
            }

            if (x > 50 || x < 0 || y > 50 || y < 0)
            {
                throw new Exception($"Coordinates are out of range x:{parts[0]} y:{parts[1]}");
            }
            return (x, y);
        }
        private async Task<RobotInstructions?> ReadInputInstruction(StreamReader reader)
        {
            string startStr = await reader.ReadLineAsync();
            string instrStr = await reader.ReadLineAsync();
            if (startStr == null || instrStr == null)
            {
                return null;
            }

            string[] startParts = startStr.Split(new char[] { ' ', '\t' });
            if (startParts.Length != 3)
            {
                throw new Exception("Incorrect robot start position {startStr}");
            }
            (var x, var y) = ParseCoordinates(startParts);

            return new RobotInstructions
            {
                StartX = x,
                StartY = y,
                Orientation = startParts[2].ToUpperInvariant().First<char>(),
                Instructions = instrStr.ToUpperInvariant()
            };
        }
    }
}
