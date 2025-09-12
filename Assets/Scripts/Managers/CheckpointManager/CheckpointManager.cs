using System;
using System.Collections;
using System.Collections.Generic;
using Cloth;
using UnityEngine;
using Core.Singleton;
using UnityEngine.Serialization;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckpointKey = 0;
    public List<CheckpointBase> checkpoints;

    private void Start()
    {
        CheckpointLoad();
    }

    public bool HasCheckpoint()
    {
        return lastCheckpointKey > 0;
    }
    public void SaveCheckpoint(int checkpoint)
    {
        if (checkpoint > lastCheckpointKey)
        {
            lastCheckpointKey = checkpoint;
            SaveManager.Instance.SaveCheckpoint(lastCheckpointKey);
            if (Cloth.ClothManager.Instance.clothBaseSo != null)
            {
                SaveManager.Instance.SaveCloth(Cloth.ClothManager.Instance.
                    ConvertClothData(Cloth.ClothManager.Instance.clothBaseSo));
            }
        }
    }

    public Vector3 GetPositionLastCheckpoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckpointKey);
        return checkpoint.transform.position;
    }

    public void CheckpointLoad()
    {
        int checkpointId = SaveManager.Instance.SaveSetup.checkpointId;
        if (checkpointId >= 0)
        {
            bool checkpointFound = false;
            for (int i = 0; i < checkpoints.Count; i++)
            {
                if (checkpoints[i].key == checkpointId)
                {
                    lastCheckpointKey = checkpointId;
                    Player.Instance.transform.position = GetPositionLastCheckpoint();
                    checkpointFound = true;
                    break;
                }
            }

            if (!checkpointFound)
            {
                Debug.Log("Checkpoint not founded " + checkpointId);
            }
        }
    }
    
}
