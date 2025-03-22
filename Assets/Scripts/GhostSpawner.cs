using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawntimer =3;
    public float timer;
    public float minEdgeDistance = .3f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset;
    public int spawnTrials = 1000;
    public Data killCountData; 

    void Start()
    {
        killCountData.ResetKillCount(); // Reset score when the game starts
    }
    void Update()
    {
        if(!MRUK.Instance && !MRUK.Instance.IsInitialized)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer > spawntimer)
        {
            Spawn();
            timer = 0;
        }
    }
    void Spawn()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom(); 
        int currentTry = 0;
        while(currentTry < spawnTrials)
        {
            bool hasFoundPos = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 normal);
            if(hasFoundPos)
            {
                Vector3 randomPositionNormalOffset = pos + normal * normalOffset;
                // randomPositionNormalOffset.y = 0;
                randomPositionNormalOffset.y = Random.Range(0f, 1.25f);
                Instantiate(prefab, randomPositionNormalOffset, Quaternion.identity);
                return;
            }
            else
            {
                currentTry++;
            }
        }
        
        
    }
}
