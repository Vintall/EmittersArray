using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultSettingsFile", menuName = "ScriptableObjects")]
public class DefaultSettingsScriptableObject : ScriptableObject
{
    [System.Serializable]
    public struct SettingPage
    {
        [SerializeField] string name;
        [SerializeField] List<SettingNode> nodes;
        public List<SettingNode> Nodes => nodes;
        public string Name => name;
    }

    [System.Serializable]
    public struct SettingNode
    {
        [SerializeField] string key;
        [SerializeField] DataTypes type;
        [SerializeField] string value;

        public string Key => key;
        public DataTypes Type => type;
        public string Value => value;
    }

    public enum DataTypes
    {
        Int,
        String,
        Float,
        Bool
    }

    [SerializeField] List<SettingPage> settings;
    public List<SettingPage> SettingsList => settings;

    Dictionary<string, (DataTypes, string)> dictionary_view = null;
    public Dictionary<string, (DataTypes, string)> SettingsDictionary
    {
        get
        {
            if (dictionary_view != null)
                return dictionary_view; // This data can not be changed. So, we can initialize it only once.

            Dictionary<string, (DataTypes, string)> result = new Dictionary<string, (DataTypes, string)>();

            foreach(SettingPage page in settings)
                foreach(SettingNode node in page.Nodes)
                    result.Add(node.Key, (node.Type, node.Value));

            dictionary_view = result;

            return result;
        }
    }
}
