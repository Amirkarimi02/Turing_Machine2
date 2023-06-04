using System;

class TuringMachine
{
    private string tape;  // The tape of the Turing machine
    private int head;               // The position of the head on the tape
    private string currentState;    // The current state of the Turing machine

    public TuringMachine(string input)
    {
        tape = input;               // Initialize the tape with the input string
        head = 0;                   // Initialize the head to the leftmost position
        currentState = "q0";        // Initialize the current state to q0
    }

    public bool Run()
    {
        int counterAq1 = 0;          // A counter for the number of 'a' symbols seen in state q1
        int xcount = 0;
        int ycount = 0;
        while (true)
        {
            char symbol = tape[head];       // Get the symbol at the current head position

            switch (currentState)
            {
                case "q0":
                    if (symbol == 'a')
                    {
                        // Replace the 'a' with 'x', move the head right, and transition to state q1
                        tape = ReplaceSymbol(tape, head, 'x');
                        head++;
                        currentState = "q1";
                    }
                    else if (symbol == 'b')
                    {
                        return false;  // Reject
                    }
                    else if (symbol == '_')
                    {
                        return false;  // Reject
                    }
                    break;

                case "q1":
                    if (symbol == 'a')
                    {
                        if (counterAq1 >= 1)
                        {
                            // If we have seen at least one 'a' in state q1 before, and the symbol to the left is 'y',
                            // move the head left. If the symbol to the left is 'x', replace it with 'x' and move the head right.
                            // Otherwise, move the head right.
                            if (tape[head - 1] == 'y')
                                head--;
                            else if (tape[head - 1] == 'x')
                            {
                                for(int i=0; i<tape.Length; i++)
                                {
                                    if (tape[i] == 'x')
                                    {
                                        xcount++;
                                    }else if (tape[i] == 'y')
                                    {
                                        ycount++;
                                    }

                                }
                                if(xcount == ycount)
                                {
                                    tape = ReplaceSymbol(tape, head, 'x');
                                    head++;
                                }else /*if(xcount == ycount + 1)*/
                                {
                                    head++;
                                }
                                xcount = 0;
                                ycount = 0;
                            }
                            else
                            {
                                head++;
                            }
                        }
                        else
                            head++;
                        counterAq1++;
                    }
                    else if (symbol == 'b')
                    {
                        // Replace the 'b' with 'y', move the head left, and transition to state q2
                        tape = ReplaceSymbol(tape, head, 'y');
                        head--;
                        currentState = "q2";
                    }
                    else if (symbol == 'x')
                    {
                        head++;
                        currentState = "q1";
                    }
                    else if (symbol == 'y')
                    {
                        for (int n = 0; n < tape.Length; n++)
                        {
                            if (tape[n] == 'x')
                            {
                                xcount++;
                            }
                            else if (tape[n] == 'y')
                            {
                                ycount++;
                            }
                        }
                        if (xcount == ycount)
                        {
                            head++;
                            currentState = "q1";
                        }
                        else
                        {
                            head++;
                            currentState = "q2";
                        }
                        xcount = 0;
                        ycount = 0;
                    }
                    else if (symbol == '_')
                    {
                        currentState= "qf";
                    }
                    break;

                case "q2":
                    if (symbol == 'a')
                    {
                        // Move the head left and remain in state q2
                        head--;
                        currentState = "q2";
                    }
                    else if (symbol == 'x')
                    {
                        // Move the head right and transition to state q1
                        head++;
                        currentState = "q1";
                    }
                    else if (symbol == 'y')
                    {
                        for (int z = 0; z < tape.Length; z++)
                        {
                            if (tape[z] == 'x')
                            {
                                xcount++;
                            }
                            else if (tape[z] == 'y')
                            {
                                ycount++;
                            }
                        }
                        if (xcount == ycount)
                        {
                            // Move the head Left and remain in state q2
                            head--;
                            currentState = "q2";
                        }
                        else
                        {
                            // Move the head right and remain in state q2
                            head++;
                            currentState = "q2";
                        }
                        xcount = 0;
                        ycount = 0;
                    }
                    else if (symbol == 'b')
                    {
                        if (tape[head - 1] == 'y')
                        {
                            for (int j = 0; j < tape.Length; j++)
                            {
                                if (tape[j] == 'x')
                                {
                                    xcount++;
                                }
                                else if (tape[j] == 'y')
                                {
                                    ycount++;
                                }

                            }
                            if (xcount != ycount)
                            {
                                tape = ReplaceSymbol(tape, head, 'y');
                                head--;
                            }
                            else
                            {
                                head--;
                            }
                            xcount = 0;
                            ycount = 0;
                        }
                        

                        // Replace the 'b' with 'y', move the head left, and remain in state q2
                        tape = ReplaceSymbol(tape, head, 'y');
                        head--;
                        currentState = "q2";
                    }
                    else if (symbol == '_')
                    {
                        currentState = "qf";
                    }
                    break;
            }

            // Visualize each step
            VisualizeStep();

            if (currentState == "qf")
            {
                break;      // Exit the loop if the final state qf is reached
            }

            if (head < 0 || head >= tape.Length)
            {
                break;      // Exit the loop if the head goes out of bounds
            }
        }

        return CheckFinalState();       // Check if the final state is acceptable
    }




    private void VisualizeStep()
    {
        Console.Clear();
        Console.WriteLine("╔═════════════════════════════════════╗");
        Console.WriteLine("║            Turing Machine           ║");
        Console.WriteLine("╠═════════════════════════════════════╣");
        Console.WriteLine("║ Current State: " + currentState.PadRight(37 - currentState.Length - 14) + "║");
        Console.WriteLine("║ Tape: " + GetTapeWithBrackets().PadRight(39) + "║");
        Console.WriteLine("╠═════════════════════════════════════╣");
        Console.WriteLine("║         Tracing and Replacing       ║");
        Console.WriteLine("║       Designed by Kariminezhad      ║");
        Console.WriteLine("╚═════════════════════════════════════╝");
        Thread.Sleep(500); // Delay for 500 milliseconds (0.5 seconds)
    }

    private string GetTapeWithBrackets()
    {
        string tapeWithBrackets = tape.Substring(0, head) + "[\u001b[32m" + tape[head] + "\u001b[0m]" + tape.Substring(head + 1);
        return tapeWithBrackets;
    }

    private string ReplaceSymbol(string input, int index, char symbol)
    {
        char[] chars = input.ToCharArray();
        chars[index] = symbol;
        return new string(chars);
    }

    private bool CheckFinalState()
    {
        bool check = false;

        // Check if the final state is qf and the tape ends with an underscore '_'
        if (currentState == "qf" && head+1 == tape.Length)
        {
            int countA = 0;
            int countB = 0;
            int countx = 0;
            int county = 0;

            // Count the number of 'a', 'b', 'x', and 'y' symbols on the tape
            foreach (char symbol in tape)
            {
                if (symbol == 'a')
                {
                    countA++;
                }
                else if (symbol == 'b')
                {
                    countB++;
                }
                else if (symbol == '_')
                {
                    break;
                }
            }
            foreach (char symbol in tape)
            {
                if (symbol == 'x')
                {
                    countx++;
                }
                else if (symbol == 'y')
                {
                    county++;
                }
                else if (symbol == '_')
                {
                    break;
                }
            }
            // Check if the counts satisfy the language requirements: countA = 0, countB > countA, countX < countY
            if (countA == 0 && countB == 0 && (countx < county))
                check= true; // Accept
        }
        else
        {
        check = false;  // Reject
        }
        return check;
    }
}

class Program
{
    static void Main()
    {
        string input = "aaaabbbb";
        // Validate the input string to ensure it matches the pattern of the language
        bool isMatch = true;
        try
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'b')
                {
                    if (input[i + 1] != 'b')
                    {
                        isMatch = false;
                        break;
                    }
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            // Handle any out-of-range exceptions
        }
        if (isMatch)
        {
            TuringMachine tm = new TuringMachine(input + '_');
            bool accepted = tm.Run();

            Console.WriteLine("Accepted: " + accepted);
        }
        /*else
        {
            Console.WriteLine("Accepted: " + "false");
        }*/
    }
}
