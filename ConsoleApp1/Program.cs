using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BE.GameBoard gameBoard = new GameBoard();
            gameBoard.ResetBoard();
            Piece a = new Piece(Players.player_1, 5, 5);
            Piece b = new Piece(Players.player_1, 5, 5);
            Console.WriteLine(a.Equals(b));
            //Console.WriteLine(a.IsCanEat(gameBoard,Players.player_2));


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (gameBoard.board[i, j] != null)
                    {
                        if (gameBoard.board[i, j].player == Players.player_1)
                        {
                            Console.Write("1    ");
                        }
                        else if (gameBoard.board[i, j].player == Players.player_2)
                        {
                            Console.Write("2    ");

                        } 
                    }
                    else
                    {
                        Console.Write("*    ");

                    }

                }

                Console.WriteLine();
            }
        }
    }
}
