using UnityEngine;
using UnityEngine.UI;

namespace EnterTextSpace
{
    /// <summary>
    /// Объект отвечающий за ввод текста на сцене
    /// </summary>
    public class EnterTextBehaviour : MonoBehaviour
    {
        public InputField inputField;
        /// <summary>
        /// Текущий текст, который мы ввели
        /// </summary>
        private string currentText = "";

        // Start is called before the first frame update
        void Start()
        {
            inputField.onValueChanged.AddListener(EnterText);
            EnterTextController.OnClear = () => { inputField.text = ""; };
        }

        // Update is called once per frame
        void Update()
        {
            if (!inputField.isFocused)
            {
                inputField.Select();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log(currentText);
                Reload();
            }

        }

        /// <summary>
        /// Вызываем коллбек для текстов
        /// </summary>
        /// <param name="str"></param>
        private void EnterText(string str)
        {
            if (str == null)
            {
                str = string.Empty;
            }

            EnterTextController.isStep = false;
            currentText = str;
            EnterTextController.OnCall?.Invoke(currentText.ToUpper());
            if (EnterTextController.isStep == false && str != string.Empty)
            {
                inputField.text = "";
            }
        }

        /// <summary>
        /// Перегрузить текст, после того как ввели текст
        /// </summary>
        private void Reload()
        {
            inputField.interactable = false;
            inputField.interactable = true;
        }
    }
}
