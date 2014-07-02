using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    class Car

        // tova e carq
        //ima si koordinati
    {
        int x;
        int y;

        public Car()
        {
            this.x = 0;
            this.y = 0;
        }
        public Car(int x, int y)
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

        public static void KingMove(Car car, Peshka peshkaA, Peshka peshkaB, Peshka peshkaC, Peshka peshkaD, int dirX, int dirY, char[,] matrica, ref bool isKingTurn)
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
