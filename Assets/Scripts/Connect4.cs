using System.Collections;
using UnityEngine;

namespace Connect4
{
    public class Connect4 : MonoBehaviour
    {
        public byte MaxRows = 6;
        public byte MaxColumns = 7;
        internal byte[,] grid;
        private void Start()
        {
            grid = new byte[MaxRows, MaxColumns];
            InitializeGrid();
        }

        void InitializeGrid()
        {
            for (byte row = 0; row < MaxRows; row++)
            {
                for (byte column = 0; column < MaxColumns; column++)
                {
                    grid[row, column] = 0; // 0 means empty
                }
            }
        }
        public bool CheckWin(byte player, int lastRow, int lastCol)
        {
            return CheckDirection(player, lastRow, lastCol, 1, 0) ||  // Horizontal
              CheckDirection(player, lastRow, lastCol, 0, 1) ||  // Vertical
              CheckDirection(player, lastRow, lastCol, 1, 1) ||  // Diagonal bottom-left to top-right
              CheckDirection(player, lastRow, lastCol, 1, -1);   // Diagonal top-left to bottom-right
        }
        private bool CheckDirection(int player, int startRow, int startCol, int deltaRow, int deltaCol)
        {
            int count = 0;

            // Check in the negative direction
            for (int i = -3; i <= 3; i++)
            {
                int newRow = startRow + i * deltaRow;
                int newCol = startCol + i * deltaCol;

                if (newRow >= 0 && newRow < MaxRows && newCol >= 0 && newCol < MaxColumns && grid[newRow, newCol] == player)
                {
                    count++;
                    if (count == 4)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0; // Reset count if a sequence is broken
                }
            }

            return false;
        }
    }
}