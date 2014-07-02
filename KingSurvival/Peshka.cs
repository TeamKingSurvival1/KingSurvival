using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public class Peshka
    {
        //tova e klasa Peshka, koito zadava peshak s koordinati X i Y

        int x;
        int y;

        public Peshka()
        {
            this.x = 0;
            this.y = 0;
        }
        public Peshka(int x, int y)
        {
            this.x = x;
            this.y = y;
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


        //abe tuka sym gi napravil edni... ama raboti
        //kvo kat sa 4 metoda
        public static bool PawnAMove(Peshka peshkaA, int dirX, int dirY, char[,] matrix, ref bool isKingTurn)
        {
            //sledvat mnogo proverki
            if (peshkaA.X + dirX < 0 || peshkaA.X + dirX > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;

            }

            if (peshkaA.Y + dirY < 0 || peshkaA.Y + dirY > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'D' || matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'B'
                                                             || matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            //ako ne grymne do momenta znachi e validen hoda

            matrix[peshkaA.Y, peshkaA.X] = '-';
            matrix[peshkaA.Y + dirY, peshkaA.X + dirX] = 'A';
            peshkaA.Y += dirY;
            peshkaA.X += dirX;
            return false;
        }
        public static bool PawnBMove(Peshka peshkaB, int dirX, int dirY, char[,] matrix, ref bool isKingTurn)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaB.X + dirX < 0 || peshkaB.X + dirX > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (peshkaB.Y + dirY < 0 || peshkaB.Y + dirY > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'A' || matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'C'
                || matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            matrix[peshkaB.Y, peshkaB.X] = '-';
            matrix[peshkaB.Y + dirY, peshkaB.X + dirX] = 'B';
            peshkaB.Y += dirY;
            peshkaB.X += dirX;
            return false;
        }
        public static bool PawnCMove(Peshka peshkaC, int dirX, int dirY, char[,] matrix, ref bool isKingTurn)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaC.X + dirX < 0 || peshkaC.X + dirX > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (peshkaC.Y + dirY < 0 || peshkaC.Y + dirY > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'A' || matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'B'
                || matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[peshkaC.Y, peshkaC.X] = '-';
            matrix[peshkaC.Y + dirY, peshkaC.X + dirX] = 'C';
            peshkaC.Y += dirY;
            peshkaC.X += dirX;
            return false;
        }
        public static bool PawnDMove(Peshka peshkaD, int dirX, int dirY, char[,] matrix, ref bool isKingTurn)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaD.Y + dirY < 0 || peshkaD.Y + dirY > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (peshkaD.X + dirX < 0 || peshkaD.X + dirX > matrix.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'A' || matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'B'
                                                             || matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[peshkaD.Y, peshkaD.X] = '-';
            matrix[peshkaD.Y + dirY, peshkaD.X + dirX] = 'D';
            peshkaD.Y += dirY;
            peshkaD.X += dirX;
            return false;
        }

    }
}