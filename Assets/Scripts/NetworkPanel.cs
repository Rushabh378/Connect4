using Unity.Netcode;
using UnityEngine;
using TMPro;
namespace Connect4
{
    public class NetworkPanel : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button host;
        [SerializeField] private UnityEngine.UI.Button client;
        private NetworkManager networkManager;
        private void Awake()
        {
            host.onClick.AddListener(() => 
            {
                NetworkManager.Singleton.StartHost();
            });
            client.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartClient();
            });
        }
    }
}
