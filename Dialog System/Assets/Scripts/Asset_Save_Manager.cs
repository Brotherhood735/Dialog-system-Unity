using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class Asset_Save_Manager : MonoBehaviour
{
    public static Asset_Save_Manager instance;
    public UnityEngine.Object defualt_folder;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;

        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void CreateAsset(UnityEngine.Object _asset, string _name)
    {
        var _path = AssetDatabase.GetAssetPath(defualt_folder);
        _path = _path.Replace(defualt_folder.name+".asset", "");
        AssetDatabase.CreateAsset(_asset, $"{_path}{_name}.asset");
    }
}
