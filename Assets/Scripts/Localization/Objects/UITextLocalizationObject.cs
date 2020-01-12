using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LocalizationSpace{
	public class UITextLocalizationObject : LocalizationObject
{
		public string key; 


		private Text localizationText { get { 
				if (GetComponent<Text> ()) {	
					return GetComponent<Text> ();
				} else {
					return null;
				}
		} 
	}

		void Start(){
			Localization.AddLocalizationObject (GetComponent<LocalizationObject>());
			UpdateLocalization ();
		}
   
		public override void UpdateLocalization ()
		{
			if (localizationText != null) {
                localizationText.text = Localization.GetText(key).Replace("<\\n>", "\n");
			}
			base.UpdateLocalization ();
		}

	}
}
