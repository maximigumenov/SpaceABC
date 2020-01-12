using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationSpace{
public static class Localization {
		private static List<LocalizationObject> listLocalizationObject = new List<LocalizationObject> ();
		private static LanguageDataObject languageObject;
		public static List<LocalizationSetting.SettingObject> localizationSetting = new List<LocalizationSetting.SettingObject>();
		public static event System.Action onTranslate;

		//Active Localization when you run application
		static Localization(){
			LocalizationSetting.InitSetting ();
			InitLanguage (SetLanguage(LocalizationSetting.startId));
		}


		public class LanguageDataObject
		{
			private GameObject prefab;
			private LanguagePrefab languagePrefab;
			private LocalizationSetting.SettingObject settingObject;
			public LanguageDataObject(GameObject _prefab, LocalizationSetting.SettingObject _settingObject){
				prefab = _prefab;
				settingObject = _settingObject;
				languagePrefab = prefab.GetComponent<LanguagePrefab>();
				languagePrefab.InitLanguages();
			}

			public string GetText(string key){
				return languagePrefab.GetText (key);
			}

			public string GetNameLanguage(){
				return settingObject.GetName ();
			}

			public int GetIdLanguage(){
				return settingObject.GetID ();
			}

			public int GetTotalWord(){
				return languagePrefab.GetTotalWord ();
			}
		}

		/// <summary>
		/// Gets the total word in dictionary
		/// </summary>
		/// <returns>The total word</returns>
		public static int GetTotalWord(){
			return languageObject.GetTotalWord ();
		}

		/// <summary>
		/// Adds the localization setting.
		/// </summary>
		/// <param name="_localizationSetting">Localization setting.</param>
		public static void AddLocalizationSetting(LocalizationSetting.SettingObject _localizationSetting){
			localizationSetting.Add (_localizationSetting);
		}

		/// <summary>
		/// Inits the language.
		/// </summary>
		/// <param name="_settingObject">Setting object.</param>
		private static void InitLanguage(LocalizationSetting.SettingObject _settingObject){
			GameObject language = Resources.Load (_settingObject.GetPath()) as GameObject;
			languageObject = new LanguageDataObject (language, _settingObject);
		}

		/// <summary>
		/// Selects the language with ID
		/// </summary>
		/// <param name="_id">Identifier.</param>
		public static void SelectLanguage(int _id){
			
			InitLanguage (SetLanguage (_id));
			UpdateLocalization ();

		}

		/// <summary>
		/// Set the language.
		/// </summary>
		/// <returns>The language.</returns>
		/// <param name="_id">Identifier.</param>
		private static LocalizationSetting.SettingObject SetLanguage(int _id){
			LocalizationSetting.nowId = _id;
			for (int i = 0; i < localizationSetting.Count; i++) {
				if (localizationSetting[i].GetID() == _id) {
					return localizationSetting [i];
				}
			}
			return null;
		}

		/// <summary>
		/// Adds the localization object when LocalizationObject start
		/// </summary>
		/// <param name="_localizationObject">Localization object.</param>
		public static void AddLocalizationObject(LocalizationObject _localizationObject){
			listLocalizationObject.Add (_localizationObject);
		}

		/// <summary>
		/// Removes the localization object when LocalizationObject destroy
		/// </summary>
		/// <param name="_localizationObject">Localization object.</param>
		public static void RemoveLocalizationObject(LocalizationObject _localizationObject){
			listLocalizationObject.Remove (_localizationObject);
		}

		/// <summary>
		/// Updates the localization objects and subscribed objects
		/// </summary>
		public static void UpdateLocalization(){
			for (int i = 0; i < listLocalizationObject.Count; i++) {
				listLocalizationObject [i].UpdateLocalization ();
			}
			onTranslate?.Invoke();
		}

		/// <summary>
		/// Return text with this key
		/// </summary>
		/// <returns>The text.</returns>
		/// <param name="key">Key.</param>
		public static string GetText(string key){
            //try {
            //    return languageObject.GetText(key);
            //} catch     

            try
            {
                return languageObject.GetText(key).Replace("<\\n>", "\n");
            }
            catch (System.Exception)
            {
                return key;
                throw;
            }
		}

}

	public class LocalizationObject : MonoBehaviour {

		public virtual void UpdateLocalization(){
		}

		//If object destroy - Remove LocalizationObject
		void OnDestroy(){
			Localization.RemoveLocalizationObject (GetComponent<LocalizationObject> ());
		}
	}

}
