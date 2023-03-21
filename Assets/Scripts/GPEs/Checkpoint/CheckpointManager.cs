using System.Collections;
using System.Collections.Generic;
using GPEs.Checkpoint;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    #region SINGLETON

    public static CheckpointManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    
    public Checkpoint CurrentCheckpoint;

    public Transform GetRespawnPoint()
    {
        if (CurrentCheckpoint == null)
        {
            return transform;
        }

        return CurrentCheckpoint.TargetRespawnTransform;
    }
}
