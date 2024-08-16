using UnityEngine;
namespace Connect4
{
    public class BlockGrid : MonoBehaviour
    {
        [SerializeField] private GameObject blockPrefab;
        [SerializeField] private float discOffset = 1.1f;
        private Connect4 connect4;
        private void Start()
        {
            connect4 = GetComponent<Connect4>();
            CreateGrid();
        }
        public bool MakeMove(byte column, byte player, bool firstTurn)
        {
            if (DropDisc(column, player))
            {
                if (connect4.CheckWin(player))
                {
                    Debug.Log("Player " + player + " wins!");
                }
                firstTurn = !firstTurn;
            }
            else
            {
                Debug.Log("Column is full!");
            }
            return firstTurn;
        }
        public bool DropDisc(byte column, byte player)
        {
            if (column < 0 || column >= connect4.MaxColumns) return false;

            for (byte row = 0; row < connect4.MaxRows; row++)
            {
                if (connect4.grid[row, column] == 0)
                {
                    connect4.grid[row, column] = player;
                    UpdateBlockVisual(row, column, player);
                    return true;
                }
            }
            return false; // Column is full
        }
        void UpdateBlockVisual(byte row, byte column, byte player)
        {
            Transform block = transform.GetChild(row * connect4.MaxColumns + column);
            block.GetComponent<SpriteRenderer>().color = (player == 1) ? Color.red : Color.yellow;
        }
        private void CreateGrid()
        {
            for(byte row = 0; row < connect4.MaxRows; row++)
            {
                for (int column = 0; column < connect4.MaxColumns; column++)
                {
                    Vector3 position = GetWorldPosition(row, column, discOffset);
                    Instantiate(blockPrefab, position, Quaternion.identity, transform);
                }
            }
        }
        public Vector3 GetWorldPosition(int row, int column, float offset)
        {
            float x = column * offset;
            float y = row * offset;
            return new Vector3(transform.position.x + x, transform.position.y + y, 0);
        }
    }
}