using System;
using System.IO;
using UnityEngine;
using Ebac.core.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;
    public SaveSetup Setup 
    {
        get { return _saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void CreatenNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Yan";
    }

    private void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    #region Save
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        SaveFile(setupToJson);
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItems();
        Save();
    }

    private void SaveFile(string json)
    {
        File.WriteAllText(_path, json);
    }

    public void SaveItems()
    {
        _saveSetup.coins = Item.ItemManager.Instance.GetItemByType(Item.ItemType.COIN).soInt.value;
        _saveSetup.health = Item.ItemManager.Instance.GetItemByType(Item.ItemType.LIFE_PACK).soInt.value;
    }

    public void SaveCheckpoint(int key)
    {
        _saveSetup.checkPointKey = key;
        Debug.Log("Salvou");
        Save();
    }

    #endregion

    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }

    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";
        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreatenNewSave();
            Save();
        }

        FileLoaded.Invoke(_saveSetup);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public int coins;
    public int health;
    public int checkPointKey;
    public string playerName;
}
