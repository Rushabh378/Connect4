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

            Debug.Log("Your Client id is " + OwnerClientId.ToString());
        }
        private void Update()
        {
            if (!IsOwner) return;

            if (Input.GetKeyDown(KeyCode.Alpha1)) blockGrid.MakeMoveSeverRpc(0, player);
            if (Input.GetKeyDown(KeyCode.Alpha2)) blockGrid.MakeMoveSeverRpc(1, player);
            if (Input.GetKeyDown(KeyCode.Alpha3)) blockGrid.MakeMoveSeverRpc(2, player);
            if (Input.GetKeyDown(KeyCode.Alpha4)) blockGrid.MakeMoveSeverRpc(3, player);
            if (Input.GetKeyDown(KeyCode.Alpha5)) blockGrid.MakeMoveSeverRpc(4, player);
            if (Input.GetKeyDown(KeyCode.Alpha6)) blockGrid.MakeMoveSeverRpc(5, player);
            if (Input.GetKeyDown(KeyCode.Alpha7)) blockGrid.MakeMoveSeverRpc(6, player);
        }
    }
}
