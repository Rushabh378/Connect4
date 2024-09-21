using Unity.Netcode;
using UnityEngine;
namespace Connect4
{
    public class BlockGrid : NetworkBehaviour
    {
        [SerializeField] private GameObject blockPrefab;
        [SerializeField] private float discOffset = 1.1f;
        private Connect4 connect4;
        private int lastRow, lastCol;
        private void Start()
        {
            connect4 = GetComponent<Connect4>();
            CreateGrid();
        }
        public bool MakeMove(byte column, byte player, bool firstTurn)
        {
            if (!IsOwner) return false;

            DropDiscServerRpc(column, player);

            return firstTurn;
        }
        [Rpc(SendTo.Server, RequireOwnership = false)]
        public void DropDiscServerRpc(byte column, byte player)
        {
            if (column < 0 || column >= connect4.MaxColumns) return;

            for (byte row = 0; row < connect4.MaxRows; row++)
            {
                if (connect4.grid[row, column] == 0)
                {
                    connect4.grid[row, column] = player;
                    lastCol = column;
                    lastRow = row;
                    UpdateBlockVisual(row, column, player);
                    Debug.Log("Droped disc by " + OwnerClientId);

                    if (connect4.CheckWin(player, lastRow, lastCol))
                    {
                        Debug.Log("player " + player + " win");
                    }
                    return;
                }
            }
            Debug.Log("Column is full");
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