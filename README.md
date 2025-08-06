# Robot Simulator

### Requirements

You will need Visual Studio with .net 8.0 installed for compilation.

### Installation

Download the src code and compile with Visual Studio.

### Running the simulator

The simulator requires an input file with the robot instructions

An example is:

```
5 3
1 1 E
RFRFRF
```

Where "5 3" is the grid size,
"1 1 E" means start at 1,1 pointing East and "RFRFRF" are the instructions:

- R = turn right
- L = turn left
- F = move forward

The input file cannot include any blank lines; there is a sample file in the repo for reference.

To run the sample file, type this from the command line in the project root folder

```
RobotSimulator\bin\debug\net8.0\RobotSimulator.exe SampleInput.txt
```

### Enhancments

You can create your own instruction handlers by writing classes that implement the `IInstruction` interface.

The new handlers and their file character are defined in the Simulator class variable \_instructionHandlers:

```c#
Dictionary<char, IInstruction> _instructionHandlers = new Dictionary<char, IInstruction>
{
    { 'L', new LeftInstruction() },
    { 'R', new RightInstruction() },
    { 'F', new ForwardInstruction() }
};
```
