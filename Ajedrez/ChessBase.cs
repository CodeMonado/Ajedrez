using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez {
    internal class ChessBase {
        readonly int[,] _newBoard = new int[8, 8] {
            { 8, 9,10,11,12,10, 9, 8 },
            { 7, 7, 7, 7, 7, 7, 7, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 3, 4, 5, 6, 4, 3, 2 }
        };
    }
}
