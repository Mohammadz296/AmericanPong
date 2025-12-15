using System.Collections.Generic;
using UnityEngine;
public static class GunPooler
{
    public static Dictionary<string, BallMovement> poolLookUp = new Dictionary<string, BallMovement>();
    public static Dictionary<string, Queue<BallMovement>> pooldic = new Dictionary<string, Queue<BallMovement>>();
    public static void EnqueueObject(BallMovement item, string name)
    {
        if (!item.gameObject.activeSelf)
        {
            return;
        }
        item.transform.position = Vector2.zero;
        pooldic[name].Enqueue(item);
        item.gameObject.SetActive(false);

    }
  
    public static BallMovement DeQueueObject(string key)
    {
        if (pooldic[key].TryDequeue(out var item))
            return item;

        return EnqueueNewInstance(poolLookUp[key], key);
    }
    public static BallMovement EnqueueNewInstance(BallMovement item, string key)
    {
        BallMovement newInstance = Object.Instantiate(item);
        newInstance.gameObject.SetActive(false);
        newInstance.transform.position = Vector3.zero;
        pooldic[key].Enqueue(newInstance);
        return newInstance;
    }
    public static void QueueClear(string name)
    {
        pooldic[name].Clear();  
}
    public static void Setup(BallMovement pooledItemPrefab, int poolsize, string dicname)
    {
        if (!pooldic.ContainsKey(dicname))
        {
            pooldic.Add(dicname, new Queue<BallMovement>());
            poolLookUp.Add(dicname, pooledItemPrefab);
        }
        for (int i = 0; i < poolsize; i++)
            {
                BallMovement Pooledinstance = Object.Instantiate(pooledItemPrefab);
                Pooledinstance.gameObject.SetActive(false);
                pooldic[dicname].Enqueue(Pooledinstance);

            }

    }
    
   
}
