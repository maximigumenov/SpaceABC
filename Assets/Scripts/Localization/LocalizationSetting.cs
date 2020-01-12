using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationSpace{
	public static class LocalizationSetting {
		public static int startId = 0;
		public static int nowId = 0;

		//Start data all languages
		public static void InitSetting(){
			new SettingObject (0, "EN", "Languages/EN");
			new SettingObject (1, "RU", "Languages/RU");
		}

		#region Setting Object

		public class SettingObject{
			private int id;
			private string nameLanguage;
			private string pathToPrefab;

			/// <summary>
			/// Enter the language data
			/// </summary>
			/// <param name="_id">ID language</param>
			/// <param name="_nameLanguage">Name language (for debug)</param>
			/// <param name="_pathToPrefab">Path to prefab</param>
			public SettingObject(int _id, string _nameLanguage, string _pathToPrefab){
				id = _id;
				nameLanguage = _nameLanguage;
				pathToPrefab = _pathToPrefab;
				Localization.AddLocalizationSetting(this);
			}

			/// <summary>
			/// Get ID language
			/// </summary>
			/// <returns>ID language</returns>
			public int GetID(){
				return id;
			}

			/// <summary>
			/// Gets the path to prefab
			/// </summary>
			/// <returns>Path to prefab</returns>
			public string GetPath(){
				return pathToPrefab;
			}

			/// <summary>
			/// Gets the name language
			/// </summary>
			/// <returns>The name language</returns>
			public string GetName(){
				return nameLanguage;
			}
		}

		#endregion
	}
}
