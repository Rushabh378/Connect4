using UnityEngine;
using TMPro;

namespace Connect4
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text message;

        public void PopUp(string title, string message)
        {
            this.title.text = title;
            this.message.text = message;

            gameObject.SetActive(true);
        }
    }
}
