using Unity.Netcode;
using UnityEngine;

namespace Connect4
{
    public class PlayerInput : NetworkBehaviour
    {
        private BlockGrid blockGrid;
        private byte player;
        private bool firstTurn = true;

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            
            blockGrid = FindFirstObjectByType<BlockGrid>();
            
            player = (byte)(OwnerClientId + 1);
        }
        private void Update()
        {
            if (!IsOwner) return;

            if (Input.GetKeyDown(KeyCode.Alpha1)) MakeMoveServerRpc(0, player);
            if (Input.GetKeyDown(KeyCode.Alpha2)) MakeMoveServerRpc(1, player);
            if (Input.GetKeyDown(KeyCode.Alpha3)) MakeMoveServerRpc(2, player);
            if (Input.GetKeyDown(KeyCode.Alpha4)) MakeMoveServerRpc(3, player);
            if (Input.GetKeyDown(KeyCode.Alpha5)) MakeMoveServerRpc(4, player);
            if (Input.GetKeyDown(KeyCode.Alpha6)) MakeMoveServerRpc(5, player);
            if (Input.GetKeyDown(KeyCode.Alpha7)) MakeMoveServerRpc(6, player);

            //MakeMoveServerRpc(player);
            
            if (Input.GetKeyDown(KeyCode.T))
            {
                TestClientRpc();
            }
        }
        [Rpc(SendTo.ClientsAndHost)]
        private void TestClientRpc()
        {
            Debug.Log("sending data from " + OwnerClientId);
        }
        [Rpc(SendTo.Server, RequireOwnership = false)]
        private void MakeMoveServerRpc(byte column, byte player)
        {
            blockGrid.MakeMove(column, player);
        }
    }
}
