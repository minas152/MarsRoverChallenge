using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Classes
{

    public class Instructions 
    {
        public enum Instruction
        {
            L,  // Turn Left
            R, // Turn Right
            M   // Move Forward
        }

        public static Instruction ParseInstruction(string instruction)
        {
            return Enum.Parse<Instruction>(instruction);
        }
    }
}
