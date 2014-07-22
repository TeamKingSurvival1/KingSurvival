namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using KingSurvival.GameplayClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestBoardDimension0SizeInitialization()
        {
            Board sampleBoard = new Board();
            Assert.AreEqual(sampleBoard.GameField.GetLength(0), Board.BoardSize);
        }

        [TestMethod]
        public void TestBoardDimension1SizeInitialization()
        {
            Board sampleBoard = new Board();
            Assert.AreEqual(sampleBoard.GameField.GetLength(1), Board.BoardSize);
        }

        [TestMethod]
        public void TestBoardInitialization()
        {
            Board sampleBoard = new Board();
            bool isCorrectFilled = true;
            char currentColor = '+';

            for (int i = 0; i < sampleBoard.GameField.GetLength(0); i++)
            {
                for (int j = 0; j < sampleBoard.GameField.GetLength(1); j++)
                {
                    if (sampleBoard.GameField[j, i] != currentColor)
                    {
                        isCorrectFilled = false;
                        break;
                    }

                    currentColor = this.ExchangeBoardCellSymbols(currentColor);
                }

                if (isCorrectFilled == false)
                {
                    break;
                }
                else
                {
                    currentColor = this.ExchangeBoardCellSymbols(currentColor);
                }
            }

            Assert.AreEqual(true, isCorrectFilled);
        }

        [TestMethod]
        public void TestPlacingASymbolOnTheBoardViaMethod()
        {
            var sampleBoard = new Board();
            sampleBoard.PlacePieceOnBoard(0, 7, '7');

            Assert.AreEqual('7', sampleBoard[0, 7]);
        }

        [TestMethod]
        public void TestClearingASymbolOfTheBoard()
        {
            var sampleBoard = new Board();
            sampleBoard.PlacePieceOnBoard(0, 7, '7');

            sampleBoard.ClearBoardCell(0, 7);

            Assert.AreEqual('+', sampleBoard[0, 7]);
        }

        private char ExchangeBoardCellSymbols(char currentColor)
        {
            var exchangedSymbol = '\0';

            if (currentColor == '-')
            {
                exchangedSymbol = '+';
            }
            else
            {
                exchangedSymbol = '-';
            }

            return exchangedSymbol;
        }
    }
}