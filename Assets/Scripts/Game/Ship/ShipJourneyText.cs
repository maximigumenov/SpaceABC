using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnterTextSpace;
using GameTextSpace;

namespace ShipJourneySpace
{
    [System.Serializable]
    public class ShipJourneyText
    {
        public List<JourneyTargetText> listText;
        private List<JourneyPoint> listPoint = new List<JourneyPoint>();

        /// <summary>
        /// Показать тексты
        /// </summary>
        public void ShowMoveText()
        {
            EnterTextController.RemoveAll();
            GetPoints();
            for (int i = 0; i < listText.Count; i++)
            {
                listText[i].gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Скрыть тексты
        /// </summary>
        public void HideMoveText()
        {
            for (int i = 0; i < listText.Count; i++)
            {
                listText[i].gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Заполнить все данные
        /// </summary>
        public void GetPoints()
        {
            //Выключить все тексты
            HideMoveText();
            //Получаем доступные тексты для путешествия
            List<string> listData = ShipTypeTexts.GetActiveList(JourneyShipTypeTexts.GetTypeList());
            //Получаем количество активных текстов
            int count = listData.Count;
            //Получить несколько ближайших точек
            listPoint = JourneyManager.DB.NearestList(count);

            GameText.Initialization(listData);
            List<TextData> listUniq = GameText.GetOneType(listData);
            for (int i = 0; i < count; i++)
            {
                listText[i].gameObject.SetActive(true);
                listPoint[i].data.OnStartMove += HideMoveText;
                listPoint[i].data.ActiveName(listText[i], listUniq[i]);
            }


            for (int i = 0; i < count; i++)
            {
                listText[i].SetText(listPoint[i].data.message.GetColor(listText[i].notSelectColor));
            }
        }
    }
}
