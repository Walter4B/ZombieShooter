using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    /*
    [System.Serializable]
    public struct AudioSettings
    {
        public string Name;
        public GameObject AudioClip;
    }
    public Dictionary<string, GameObject> AudioSettingsDict = new Dictionary<string, GameObject>();

    public List<AudioSettings> AudioList = new List<AudioSettings>();
    */

    public bool active = false;


    public List<GameObject> PossiblePrefabsToSpawn = new List<GameObject>();
    //public float SpawnInterval = 1.0f;

    void Start()
    {
            StartCoroutine(SpawnCoroutine());
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);
        
    }

    private IEnumerator SpawnCoroutine()
    {
        
        while (GameManager.GM._currentState == GameManager.GameState.Playing)
        {
         int randomIndex = Random.Range(0, PossiblePrefabsToSpawn.Count);
            if (active == true)
            {
                SpawnObject(PossiblePrefabsToSpawn[randomIndex]);
            }



            Debug.Log("PRIJE YIELDA: " + GameManager.GM.SpawnInterval);
            yield return new WaitForSeconds(GameManager.GM.SpawnInterval);
            
            Debug.Log("POSLE YIELDA: " + GameManager.GM.SpawnInterval);
        }
    }
}
