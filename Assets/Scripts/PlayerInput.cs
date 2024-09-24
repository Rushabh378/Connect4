using Unity.Netcode;
using UnityEngine;

namespace Connect4
{
    public class PlayerInput : NetworkBehaviour
    {
        private BlockGrid blockGrid;
        private byte player;
        private NetworkVariable<bool> firstTurn = new NetworkVariable<bool>(true);

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            if (!IsOwner) return;

            player = (byte)(OwnerClientId + 1);

            firstTurn.OnValueChanged += (bool previousValue, bool newValue) =>
            {
                if ((newValue && player == 1) || (!newValue && player == 2))
                {
                    Debug.Log("It's your turn");
                }
                else
                {
                    Debug.Log("Waiting for the other player...");
                }
            };
            
            blockGrid = FindFirstObjectByType<BlockGrid>();

            Debug.Log("Your Client id is " + OwnerClientId.ToString());
        }
        private void Update()
        {
            if (!IsOwner) return;

            if(firstTurn.Value == true && player == 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) MakeMoveServerRpc(0, player);
                if (Input.GetKeyDown(KeyCode.Alpha2)) MakeMoveServerRpc(1, player);
                if (Input.GetKeyDown(KeyCode.Alpha3)) MakeMoveServerRpc(2, player);
                if (Input.GetKeyDown(KeyCode.Alpha4)) MakeMoveServerRpc(3, player);
                if (Input.GetKeyDown(KeyCode.Alpha5)) MakeMoveServerRpc(4, player);
                if (Input.GetKeyDown(KeyCode.Alpha6)) MakeMoveServerRpc(5, player);
                if (Input.GetKeyDown(KeyCode.Alpha7)) MakeMoveServerRpc(6, player);
            }
            if(firstTurn.Value == false && player == 2)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) MakeMoveServerRpc(0, player);
                if (Input.GetKeyDown(KeyCode.Alpha2)) MakeMoveServerRpc(1, player);
                if (Input.GetKeyDown(KeyCode.Alpha3)) MakeMoveServerRpc(2, player);
                if (Input.GetKeyDown(KeyCode.Alpha4)) MakeMoveServerRpc(3, player);
                if (Input.GetKeyDown(KeyCode.Alpha5)) MakeMoveServerRpc(4, player);
                if (Input.GetKeyDown(KeyCode.Alpha6)) MakeMoveServerRpc(5, player);
                if (Input.GetKeyDown(KeyCode.Alpha7)) MakeMoveServerRpc(6, player);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("firsturn is " + firstTurn.Value.ToString());
            }
        }
        [Rpc(SendTo.Server, RequireOwnership = false)]
        private void MakeMoveServerRpc(byte column, byte player)
        {
            firstTurn.Value = !firstTurn.Value;
            blockGrid.MakeMove(column, player);
        }
    }
}
