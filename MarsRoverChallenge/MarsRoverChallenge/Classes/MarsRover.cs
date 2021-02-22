using System;
using System.Collections.Generic;
using System.Text;
using static MarsRoverChallenge.Classes.Directions;
using static MarsRoverChallenge.Classes.Instructions;

namespace MarsRoverChallenge.Classes
{
    public class MarsRover : Plateau
    {
        public int RoverX { get; set; }
        public int RoverY { get; set; }
        public Direction RoverDirection { get; set; }
        public Plateau _Plateau { get; set; }

        public MarsRover(string properties, Plateau plat) // Initialise
        {
            string[] propList = properties.Split(' ');
            RoverX = int.Parse(propList[0]);
            RoverY = int.Parse(propList[1]);
            _Plateau = plat;
            try
            {
                RoverDirection = Directions.ParseDirection(propList[2]);
            }catch(Exception e)
            {
                throw new InvalidOperationException(ExceptionMessages.DirectionParseError);
            }
        }

        public void SendRoverCommand(string command)
        {
            foreach (char i in command)
            {
                Instruction ins;
                try
                {
                    ins = ParseInstruction(i.ToString());
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(ExceptionMessages.InstructionParseError);
                }

                if (ins == Instruction.M)
                {
                    MoveForward();
                }
                else
                {
                    RotateRover(ins);
                }
            }
        }

        public void MoveForward()
        {
            switch (RoverDirection)
            {
                case Direction.N:
                    {
                        RoverY += 1;
                        CheckRoverOutOfBounds(RoverX,RoverY);
                        CheckRoverCrash(RoverX, RoverY);
                        break;
                    }
                case Direction.S:
                    {
                        RoverY -= 1;
                        CheckRoverOutOfBounds(RoverX, RoverY);
                        CheckRoverCrash(RoverX, RoverY);
                        break;
                    }
                case Direction.E:
                    {
                        RoverX += 1;
                        CheckRoverOutOfBounds(RoverX, RoverY);
                        CheckRoverCrash(RoverX, RoverY);
                        break;
                    }
                case Direction.W:
                    {
                        RoverX -= 1;
                        CheckRoverOutOfBounds(RoverX, RoverY);
                        CheckRoverCrash(RoverX, RoverY);
                        break;
                    }
            }
        }

        public void RotateRover(Instruction instruction)
        {
            switch (RoverDirection)
            {
                case Direction.N:
                    {
                        if (instruction == Instructions.Instruction.R)
                        {
                            RoverDirection = Direction.E;
                            break;
                        }
                        else
                        {
                            RoverDirection = Direction.W;
                            break;
                        }
                    }
                case Direction.W:
                    {
                        if (instruction == Instructions.Instruction.R)
                        {
                            RoverDirection = Direction.N;
                            break;
                        }
                        else
                        {
                            RoverDirection = Direction.S;
                            break;
                        }
                    }
                case Direction.S:
                    {
                        if (instruction == Instructions.Instruction.R)
                        {
                            RoverDirection = Direction.W;
                            break;
                        }
                        else
                        {
                            RoverDirection = Direction.E;
                            break;
                        }
                    }
                case Direction.E:
                    {
                        if (instruction == Instructions.Instruction.R)
                        {
                            RoverDirection = Direction.S;
                            break;
                        }
                        else
                        {
                            RoverDirection = Direction.N;
                            break;
                        }
                    }
            }
        }

        public void CheckRoverOutOfBounds(int x, int y) // Checks if the rover exited the specified Plateau area;
        {
            if (x > _Plateau.PlatX || y > _Plateau.PlatY)
            {
                throw new InvalidOperationException(ExceptionMessages.RoverExitPlateauError);
            }
        }

        public void CheckRoverCrash(int x, int y)
        {
            foreach (MarsRover rover in _Plateau.Rovers)
            {
                if (x == rover.RoverX && y == rover.RoverY)
                {
                    throw new InvalidOperationException(ExceptionMessages.RoverCrashError);
                }
            }
        }
    }
}
