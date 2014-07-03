namespace KingSurvival
{
    using System;

    internal class King
    {
        private int xCoord;
        private int yCoord;

        public King()
        {
            this.xCoord = 0;
            this.yCoord = 0;
        }

        public King(int x, int y)
        {
            this.xCoord = x;
            this.yCoord = y;
        }

        public int X
        {
            get { return xCoord; }
            set { xCoord = value; }
        }

        public int Y
        {
            get { return yCoord; }
            set { yCoord = value; }
        }

        public static void KingMove(King car, Peshka peshkaA, Peshka peshkaB, Peshka peshkaC, Peshka peshkaD, int dirX, int dirY, char[,] matrica, ref bool isKingTurn)
        {

            if (car.X + dirX < 0 || car.X + dirX > matrica.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (car.Y + dirY < 0 || car.Y + dirY > matrica.GetLength(0) - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (matrica[car.Y + dirY, car.X + dirX] == 'A')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaA.Y, peshkaA.X] = '-';
            }

            if (matrica[car.Y + dirY, car.X + dirX] == 'B')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaB.Y, peshkaB.X] = '-';
            }

            if (matrica[car.Y + dirY, car.X + dirX] == 'C')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaC.Y, peshkaC.X] = '-';
            }

            if (matrica[car.Y + dirY, car.X + dirX] == 'D')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaD.Y, peshkaD.X] = '-';
            }

            matrica[car.Y, car.X] = '-';
            matrica[car.Y + dirY, car.X + dirX] = 'K';

            car.Y += dirY;
            car.X += dirX;

            return;
        }
    }
}