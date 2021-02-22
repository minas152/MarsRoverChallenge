using MarsRoverChallenge.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Classes
{
    public class Plateau
    {
        public  int PlatX { get; set; }  
        public  int PlatY { get; set; }  
        public  List<MarsRover> Rovers { get; set; }


        public  void InitialisePlateau(string input)
        {
            string[] platSize = input.Split(' ');

            int platX = int.Parse(platSize[0]);
            int platY = int.Parse(platSize[1]);

            PlatX = platX;
            PlatY = platY;
            Rovers = new List<MarsRover>();
        }
    }
}
