
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  //创建一个最大容量为10的Person类对象池
///  使用例子：
/// ObjectPool<Person> poolPerson = ObjectPoolManager.instance.GetObjectPool<Person>(10);
/// Person person1 = poolPerson.Spawn();//从Person对象池中取出元素
/// person1.PrintName();
/// ObjectPoolManager.instance.DestroyObjectPool<Person>();//销毁对象池
/// </summary>


public class ObjectPoolMgr : Singleton<ObjectPoolMgr>
{
    private Dictionary<Type, object> objectPools = new Dictionary<Type, object>();

    /// <summary>
    /// 生成对应类型的对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="maxCount"></param>
    /// <returns></returns>
    public ObjectPool<T> GetObjectPool<T>(int maxCount) where T : class, new()
    {
        Type poolType = typeof(T);
        if (!objectPools.ContainsKey(poolType))
        {
            ObjectPool<T> pool = new ObjectPool<T>(maxCount);
            objectPools.Add(poolType, pool);
        }
        return objectPools[poolType] as ObjectPool<T>;
    }

    /// <summary>
    /// 销毁对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void DestroyObjectPool<T>() where T : class, new()
    {
        Type poolType = typeof(T);
        if (objectPools.ContainsKey(poolType))
        {
            ObjectPool<T> pool = objectPools[poolType] as ObjectPool<T>;
            pool.ClearPool();
            objectPools.Remove(poolType);
        }
    }
}
