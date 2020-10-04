using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    /*
     * This class instantiates any necessary objects up front
     * to save processing power later on.
     * There can only be 1 ObjectPooler per scene
     * Spawned Objects likely come from this class, and 
     * Dead Objects are likely returned to this class
     * To "Despawn" a Pooled Object, deactivate it, maybe put it somewhere like the origin.
     */

    public static System.Exception unknownPool =
        new System.Exception("Unknown Pool: Queue Not Found");
    public static System.Exception emptyPool =
        new System.Exception("The Pool is Empty, Can't Spawn Object");

    public static ObjectPooler Instance { get; private set; }

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField]
    private Pool[] pools;

    private Dictionary<string, Queue<GameObject>> poolBook;
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        if (pools == null) return;

        poolBook = new Dictionary<string, Queue<GameObject>>();
        for(int i = 0; i < pools.Length; i++)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for(int j = 0; j < pools[i].size; j++)
            {
                GameObject g = Instantiate(pools[i].prefab, Vector3.zero, Quaternion.identity);
                g.SetActive(false);
                poolQueue.Enqueue(g);
            }
            poolBook.Add(pools[i].tag, poolQueue);
        }
    }

    private void TestContains(string tag)
    {
        if (!poolBook.ContainsKey(tag))
            throw unknownPool;
    }

    public GameObject SpawnObject(string tag, Vector3 position, Quaternion rotation)
    {
        TestContains(tag);

        GameObject g = poolBook[tag].Dequeue();
        if (g.activeInHierarchy) throw emptyPool;

        g.transform.position = position;
        g.transform.rotation = rotation;
        g.SetActive(true);
        poolBook[tag].Enqueue(g);
        return g;
    }
}
