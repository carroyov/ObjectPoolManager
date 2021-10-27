using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject objPrefab;
    public int poolSize;
    public Queue<GameObject> objPool;
    public static PoolManager sharedInstance;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        objPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPrefab);
            objPool.Enqueue(newObj);
            newObj.SetActive(false);
            
        }
    }

    public GameObject GetObjectFromPool(Vector3 newPosition, Quaternion newRotation)
    {
        GameObject newObj = objPool.Dequeue();
        newObj.SetActive(true);
        newObj.transform.SetPositionAndRotation(newPosition, newRotation);
        return newObj;
    }

    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);
        objPool.Enqueue(go);
    }
}
