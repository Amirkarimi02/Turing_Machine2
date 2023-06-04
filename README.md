## Turing Machine

This code implements a Turing machine that processes an input string according to certain rules and transitions between states. The Turing machine is designed to recognize a specific language pattern defined by the following rules:

1. The input string must start with one or more 'a' symbols, followed by one or more 'b' symbols.
2. The number of 'x' symbols encountered after the first 'a' must be less than the number of 'y' symbols encountered.
3. The input string must end with an underscore symbol '_'.

### How to Use

To use the Turing machine implementation, follow these steps:

1. Provide an input string that matches the language pattern described above. The input string is defined in the `Main` method of the `Program` class.
2. Run the program.
3. The Turing machine will process the input string, applying the defined transitions and rules.
4. The program will display the current state of the Turing machine and the tape after each step.
5. Once the Turing machine reaches the final state, it will determine whether the input string is accepted or rejected based on the language requirements.
6. The program will display whether the input string is accepted or rejected.

### Implementation Details

The `TuringMachine` class represents the Turing machine and contains the following components:

- `tape`: A string representing the tape of the Turing machine.
- `head`: An integer representing the position of the head on the tape.
- `currentState`: A string representing the current state of the Turing machine.

The `TuringMachine` class has a `Run` method that executes the Turing machine by applying the defined transitions and rules until it reaches the final state. The method returns a boolean value indicating whether the input string is accepted or rejected.

The `VisualizeStep` method is responsible for displaying the current state and the tape after each step. It uses the `Console` class to clear the console, format and print the necessary information.

The `ReplaceSymbol` method replaces a symbol at a specific index in the tape with a given symbol.

The `CheckFinalState` method checks if the final state of the Turing machine satisfies the language requirements. It counts the occurrences of 'a', 'b', 'x', and 'y' symbols on the tape and checks if the counts satisfy the defined pattern.

The `Main` method in the `Program` class initializes the input string and creates an instance of the `TuringMachine` class. It then runs the Turing machine and displays whether the input string is accepted or rejected.

### Limitations

This implementation has the following limitations:

- It assumes that the input string provided in the `Main` method matches the language pattern.
- It does not provide input validation for the user-provided input string.
- The code lacks modularity and could benefit from refactoring into separate methods to improve readability and maintainability.
- The visualization of each step is limited to the console output. A graphical user interface (GUI) or visualization library could enhance the user experience.

Please note that this code is designed to demonstrate the basic functionality of a Turing machine and may not cover all possible edge cases or optimal design practices.
