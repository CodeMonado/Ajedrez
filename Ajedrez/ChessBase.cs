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

        public int[,] WhitePawnMovement(int row, int column) {
            int[,] allowedMovement;
            if (row == 1) {
                allowedMovement = new int[,]{
                    { 1},
                    { 1}
                };
            }
            else
                allowedMovement = new int[,]{
                    { 0},
                    { 1}
                };

            return allowedMovement;
        }

        public int[,] WhiteKnightMovement(int row, int col) {
            int[,] allowedMovement;

            allowedMovement = new int[,]{
                { 0, 1, 0, 1, 0 },
                { 1, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 1 },
                { 0, 1, 0, 1, 0 },
            };

            return allowedMovement;
        }

        public int[,] WhiteRookMovement(int row, int col) {
            int[,] allowedMovement = new int[8,8];
            int check = 1;
            //Movimiento abajo-derecha
            for(int i = row; i < 8; i++) {
                for (int j = col; j < 8; j++) {
                    if (i == row + check && j == col + check) {
                        allowedMovement[i, j] = 1;
                        check++;
                    }
                }
            }
            //Movimiento abajo-izquierda
            for (int i = row; i < 8; i++) {
                for (int j = col; j > 0; j--) {
                    if (i == row + check && j == col + check) {
                        allowedMovement[i, j] = 1;
                        check++;
                    }
                }
            }

            return allowedMovement;
        }
    }
}
