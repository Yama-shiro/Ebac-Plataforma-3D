using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Cloth;
using Collectables;
using UnityEngine;
using NaughtyAttributes;
using Core.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    public int lastLevel;
    public Action<SaveSetup> fileLoadedAction;
    public float loadDelay = 0.1f;
    [SerializeField]private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";
    private string _pathCloth = Application.streamingAssetsPath + "/saveCloth.txt";
    public SaveSetup SaveSetup
    {
        get
        {
            return _saveSetup;
        }
    }

    private ClothBaseData _clothBaseDataSaved = null;

    public ClothBaseData ClothSaved
    {
        get
        {
            return _clothBaseDataSaved;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
        Invoke(nameof(Load),loadDelay);
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.coins = 0;
        _saveSetup.health = 0;
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "player";
    }
    #region Save
    [Button]
        private void Save()
        {
            var setupToJson = JsonUtility.ToJson(_saveSetup,true);
            Debug.Log(setupToJson);
            SaveFile(setupToJson,_path);
            
            setupToJson = JsonUtility.ToJson(_clothBaseDataSaved,true);
            Debug.Log(setupToJson);
            SaveFile(setupToJson,_pathCloth);
        }
        public void SaveName(string text)
        {
            _saveSetup.playerName = text;
            Save();
        }
        public void SaveLastLevel(int level)
        {
            _saveSetup.lastLevel = level;
            SaveItems();
            Save();
        }

        private void SaveFile(string json,string path)
        {
            //string path = Application.persistentDataPath + "/save.txt";
            //string path = Application.streamingAssetsPath + "/save.txt";
            
            /*string fileLoaded = "";
            if (File.Exists(path))
            {
                fileLoaded = File.ReadAllText(path);
                File.WriteAllText(path,json);
            }*/
            Debug.Log(path);
            File.WriteAllText(path,json);
        }

        public void SaveItems()
        {
            _saveSetup.coins = Collectables.CollectableManager.Instance.
                GetCollectableByType(Collectables.CollectablesType.Coin).soInt.value;
            _saveSetup.health = Collectables.CollectableManager.Instance.
                GetCollectableByType(Collectables.CollectablesType.LifePack).soInt.value;
        }

        public void SaveCheckpoint(int id)
        {
            _saveSetup.checkpointId = id;
            Save();
            Debug.Log("Checkpoint Saved: " + id);
        }

        public void SaveCloth(ClothBaseData clothBaseData)
        {
            _clothBaseDataSaved = clothBaseData;
            Save();
            Debug.Log("Save Cloth");
        }
        [Button]
        private void SaveLevelOne()
        { 
            SaveLastLevel(1);
        } 
        [Button]
        private void SaveLevelFive()
        { 
            SaveLastLevel(5);
        }
    #endregion

    #region Load

        [Button]
        private void Load()
        { 
            var fileLoaded = "";
            if (File.Exists(_path))
            {
                fileLoaded = File.ReadAllText(_path);
                _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
                lastLevel = _saveSetup.lastLevel;
            }
            else
            {
                CreateNewSave();
                Save();
            }

            if (File.Exists(_pathCloth))
            {
                fileLoaded = File.ReadAllText(_pathCloth);
                _clothBaseDataSaved = JsonUtility.FromJson<ClothBaseData>(fileLoaded);
            }
            fileLoadedAction?.Invoke(_saveSetup);
        }

    #endregion
}
[Serializable]
public class SaveSetup
{
    public int coins;
    public int health;
    public int lastLevel;
    public string playerName;
    public int checkpointId = -1;
}

