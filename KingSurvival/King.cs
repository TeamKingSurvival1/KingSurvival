﻿namespace KingSurvival
{
    using System;

    internal class King
    {
        private int x;
        private int y;

        public King()
        {
            // TODO: The King initially is located at row 7 and column 3 -> extract constants.
            this.x = 0;
            this.y = 0;
        }

        public King(int initialXCoordinate, int initialYCoordinate)
        {
            this.x = initialXCoordinate;
            this.y = initialYCoordinate;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // TODO: Reduce number of parameters that MoveTheKing() method takes.
        public static void MoveTheKing(King theKing, Pawn pawnA, Pawn pawnB, Pawn pawnC, Pawn pawnD, int horizontalDirection, int verticalDirection, char[,] gameBoard, ref bool isKingsTurn)
        {

            if (theKing.X + horizontalDirection < 0 || theKing.X + horizontalDirection > gameBoard.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingsTurn = true;
                return;
            }

            if (theKing.Y + verticalDirection < 0 || theKing.Y + verticalDirection > gameBoard.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingsTurn = true;
                return;
            }

            if (gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] == 'A')
            {
                gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] = 'K';
                gameBoard[pawnA.Y, pawnA.X] = '-';
            }

            if (gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] == 'B')
            {
                gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] = 'K';
                gameBoard[pawnB.Y, pawnB.X] = '-';
            }

            if (gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] == 'C')
            {
                gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] = 'K';
                gameBoard[pawnC.Y, pawnC.X] = '-';
            }

            if (gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] == 'D')
            {
                gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] = 'K';
                gameBoard[pawnD.Y, pawnD.X] = '-';
            }

            gameBoard[theKing.Y, theKing.X] = '-';
            gameBoard[theKing.Y + verticalDirection, theKing.X + horizontalDirection] = 'K';

            theKing.Y += verticalDirection;
            theKing.X += horizontalDirection;

            return;
        }
    }
}