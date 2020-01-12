using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class ControllCreateAsset
{
	/// <summary>
	/// Creates the asset.
	/// </summary>
	/// <param name="pathJson">Path json.</param>
	/// <param name="pathSave">Path save.</param>
	/// <param name="fieldName">Field name.</param>
	/// <param name="nameAsset">Name asset.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static void CreateAsset<T> (string pathJson, string pathSave, string fieldName, string nameAsset) where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T> ();
		string path = "Assets/" + pathSave;
		if (File.Exists (Application.dataPath + "/" + pathSave + "/" + nameAsset + ".asset")) {
			AssetDatabase.DeleteAsset (path + "/" + nameAsset + ".asset");
		}
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + nameAsset + ".asset");
        
        string json = File.ReadAllText(pathJson);
        //json = json.Replace("\n", "");
        Debug.LogError(json);
        FromJsonOverwriteArr (json, fieldName, asset);
		AssetDatabase.CreateAsset (asset, assetPathAndName);
		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh();
	}

	/// <summary>
	/// From the json overwrite arr.
	/// </summary>
	/// <param name="json_array">Json array.</param>
	/// <param name="fieldName">Field name.</param>
	/// <param name="obj">Object.</param>
	public static void FromJsonOverwriteArr(string json_array, string fieldName, object obj)
	{
		json_array = WrapArray(json_array, fieldName);
		JsonUtility.FromJsonOverwrite(json_array, obj);
	}

	/// <summary>
	/// Wraps the array.
	/// </summary>
	/// <returns>The array.</returns>
	/// <param name="json_array">Json array.</param>
	/// <param name="fieldName">Field name.</param>
	private static string WrapArray(string json_array, string fieldName)
	{
       
       // json_array = json_array.Replace("<symb_n>", "");
       // Debug.LogError(json_array);
        return "{\"" + fieldName + "\":" + json_array + "}";
	}
}