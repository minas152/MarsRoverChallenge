using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Classes
{
    public static class ExceptionMessages
    {
        public static string DirectionParseError { get; } = "Error parsing Direction Command, Please only use the following commands { N,S,W,E }";
        public static string InstructionParseError { get; } = "Error parsing Instruction Command, Please only use the following commands { M,L,R }";
        public static string RoverExitPlateauError { get; } = "Error Occured, The rover commands will cause the rover to exit the plateau.";
        public static string RoverCrashError { get; } = "Error Occured, The rover commands will cause one rover to crash with another rover on the plateau.";
    }
}
