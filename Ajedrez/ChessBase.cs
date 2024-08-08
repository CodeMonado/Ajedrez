using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez {
    internal class ChessBase {
        public readonly int[,] _newBoard = new int[8, 8] {
            { 8, 9,10,11,12,10, 9, 8 },
            { 7, 7, 7, 7, 7, 7, 7, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 3, 4, 5, 6, 4, 3, 2 }
        };

        int[,] moveBoard = new int[8, 8];

        public int[,] WhitePawnMovement(int row, int column) {

            if (row == 6) {
                for (int i = 0; i < 3; i++) {
                    moveBoard[row - i, column] = 1;
                }
            }
            else {
                moveBoard[row, column] = 1;
                moveBoard[row - 1, column] = 1;
            }
            return moveBoard;
        }

        public int[,] KnightMovement(int row, int col) {
            int[,] allowedMovement;

            allowedMovement = new int[,]{
                { 0, 1, 0, 1, 0 },
                { 1, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 0 },
                { 1, 0, 0, 0, 1 },
                { 0, 1, 0, 1, 0 },
            };

            return allowedMovement;
        }

        public int[,] RookMovement(int row, int col) {
            int check = 1;
            //Movimiento abajo-derecha
            for(int i = 0; i < 8; i++) { 
                moveBoard[row, i] = 1;
                check++;      
            }
            //Movimiento abajo-izquierda

            for (int j = 0; j < 8; j++) {
                moveBoard[j, col] = 1;
                check++;  
            }

            return moveBoard;
        }
    }
}
