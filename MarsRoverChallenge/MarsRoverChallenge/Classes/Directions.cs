using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Classes
{

    public class Directions
    {
        public enum Direction
        {
            N, // North
            S, // South
            W, // West
            E  // East
        }

        public static Direction ParseDirection(string direction)
        {
            return Enum.Parse<Direction>(direction);
        }

    }
}
