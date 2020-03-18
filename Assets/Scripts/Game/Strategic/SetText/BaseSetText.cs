using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EnterTextSpace;
using GameTextSpace;

namespace Strategic
{
    [System.Serializable]
    public class BaseSetText
    {
        public Action<string, string, TextJourneyObject> OnChange;
        public Action<string, TextJourneyObject> OnGood;
        public Action<string, TextJourneyObject> OnBed;

        public TextJourneyObject textJourney;

        public void Show(string types)
        {
            TextData textData = GameText.Get(types);
            Debug.LogError(textData.text);
            SetWork(textData.text, textData.type, textJourney);
        }

        protected void SetWork(string message, string type, TextJourneyObject textJourney)
        {


            Action<string> Change = (str) =>
            {
                WorkChange(message, str, textJourney);
            };

            Action Good = () =>
            {
                WorkGood(message, textJourney);
            };

            Action Bed = () =>
            {
                WorkBed(message, textJourney);
            };

            textJourney.targetText.SetText(message.GetColor(textJourney.targetText.notSelectColor));

            EnterTextController.Add(message, Change, Good, Bed);
        }

        public virtual void WorkChange(string message, string _text, TextJourneyObject textJourney)
        {
            textJourney.targetText.SetText(message.GetColor(_text, textJourney.targetText.selectColor, textJourney.targetText.notSelectColor));
            OnChange?.Invoke(message, _text, textJourney);
        }

        public virtual void WorkGood(string message, TextJourneyObject textJourney)
        {
            OnGood?.Invoke(message, textJourney);
        }
        
        public virtual void WorkBed(string message, TextJourneyObject textJourney)
        {
            textJourney.targetText.SetText(message.GetColor(textJourney.targetText.notSelectColor));
            OnBed?.Invoke(message, textJourney);
        }
    }
}
