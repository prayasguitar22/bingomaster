using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BoardState : MonoBehaviour
    {
        private static BoardState _instance;
        public static BoardState GetInstance()
        {
            return (_instance == null) ? FindObjectOfType<BoardState>() : _instance;
        }

        private void Start()
        {
            _instance = this;
        }
        
        public void ClickAButton(int index)
        {
            var item = gameObject.transform.GetChild(index).gameObject;
            ChangeButtonState(item);
        }

        public void ChangeButtonState(GameObject item)
        {
            item.GetComponent<Button>().interactable = false;
            item.GetComponent<Button>().enabled = false;
            item.GetComponentInChildren<Text>().text = "x";
        }

        public void SetInteractable(bool status)
        {
            var item = gameObject.transform;
            for (int i = 0; i < item.childCount; i++)
            {
                var child = item.GetChild(i).GetComponent<Button>();
                child.interactable = status;
            }
        }
    }
}
