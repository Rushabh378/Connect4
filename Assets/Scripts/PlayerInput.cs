using Unity.Netcode;
using UnityEngine;

namespace Connect4
{
    public class PlayerInput : NetworkBehaviour
    {
        private BlockGrid blockGrid;
        private byte player1 = 1;
        private byte player2 = 2;
        private bool firstTurn = true;

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            
            blockGrid = FindFirstObjectByType<BlockGrid>();
            if(blockGrid != null)
            {
                Debug.Log("Block grid found");
            }
        }
        private void Update()
        {
            if (!IsOwner) return;

            MakeMove(player1);
            /*if (firstTurn)
            {
                MakeMove(player1);
            }
            else
            {
                MakeMove(player2);
            }*/
        }
        private void MakeMove(byte player)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) firstTurn = blockGrid.MakeMove(0, player, firstTurn);
            if (Input.GetKeyDown(KeyCode.Alpha2)) firstTurn = blockGrid.MakeMove(1, player, firstTurn);
            if (Input.GetKeyDown(KeyCode.Alpha3)) firstTurn = blockGrid.MakeMove(2, player, firstTurn);
            if (Input.GetKeyDown(KeyCode.Alpha4)) firstTurn = blockGrid.MakeMove(3, player, firstTurn);
            if (Input.GetKeyDown(KeyCode.Alpha5)) firstTurn = blockGrid.MakeMove(4, player, firstTurn);
            if (Input.GetKeyDown(KeyCode.Alpha6)) firstTurn = blockGrid.MakeMove(5, player, firstTurn);
            if (Input.GetKeyDown(KeyCode.Alpha7)) firstTurn = blockGrid.MakeMove(6, player, firstTurn);
        }
    }
}
