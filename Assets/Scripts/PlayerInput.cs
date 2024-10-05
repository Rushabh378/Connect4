using Unity.Netcode;
using UnityEngine;

namespace Connect4
{
    public class PlayerInput : NetworkBehaviour
    {
        private BlockGrid blockGrid;
        private byte player;

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            if (!IsOwner) return;

            player = (byte)(OwnerClientId + 1);
            blockGrid = FindFirstObjectByType<BlockGrid>();
        }
        private void Update()
        {
            if (!IsOwner) return;

            if (Input.GetKeyDown(KeyCode.Alpha1)) blockGrid.MakeMoveServerRpc(0, player);
            if (Input.GetKeyDown(KeyCode.Alpha2)) blockGrid.MakeMoveServerRpc(1, player);
            if (Input.GetKeyDown(KeyCode.Alpha3)) blockGrid.MakeMoveServerRpc(2, player);
            if (Input.GetKeyDown(KeyCode.Alpha4)) blockGrid.MakeMoveServerRpc(3, player);
            if (Input.GetKeyDown(KeyCode.Alpha5)) blockGrid.MakeMoveServerRpc(4, player);
            if (Input.GetKeyDown(KeyCode.Alpha6)) blockGrid.MakeMoveServerRpc(5, player);
            if (Input.GetKeyDown(KeyCode.Alpha7)) blockGrid.MakeMoveServerRpc(6, player);
        }
    }
}
