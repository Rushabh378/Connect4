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
        public bool CheckWin(byte player)
        {
            // Check horizontal
            for (byte row = 0; row < MaxRows; row++)
            {
                for (byte col = 0; col <= MaxColumns - 4; col++)
                {
                    if (grid[row, col] == player && grid[row, col + 1] == player &&
                        grid[row, col + 2] == player && grid[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check vertical
            for (byte col = 0; col < MaxColumns; col++)
            {
                for (byte row = 0; row <= MaxRows - 4; row++)
                {
                    if (grid[row, col] == player && grid[row + 1, col] == player &&
                        grid[row + 2, col] == player && grid[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal (bottom left to top right)
            for (byte row = 0; row <= MaxRows - 4; row++)
            {
                for (int col = 0; col <= MaxColumns - 4; col++)
                {
                    if (grid[row, col] == player && grid[row + 1, col + 1] == player &&
                        grid[row + 2, col + 2] == player && grid[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal (top left to bottom right)
            for (byte row = 3; row < MaxRows; row++)
            {
                for (byte col = 0; col <= MaxColumns - 4; col++)
                {
                    if (grid[row, col] == player && grid[row - 1, col + 1] == player &&
                        grid[row - 2, col + 2] == player && grid[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}