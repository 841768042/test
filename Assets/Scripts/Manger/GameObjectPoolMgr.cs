
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 使用例子：
///  public GameObject pool;//场景中的一个空物体
///  public GameObject prefab;//克隆对象
///  private GameObjectPool poolScript;
///  poolScript=pool.AddComponent<GameObjectPool>();
///  poolScript.InitPool(6, prefab);
///  GameObject cur=poolScript.Spawn();
///  StartCoroutine(Recycle(cur))
///  private IEnumerator Recycle(GameObject go)
///  yield return new WaitForSeconds(5);
///  poolScript.Recycle(go);
/// 
/// 
/// </summary>
public class GameObjectPoolMgr : MonoBehaviour
{
    private Stack<GameObject> pool = new Stack<GameObject>();
    private int maxCount;//池子最大大小
    private GameObject gamePrefab;//预制件
    public void InitPool(int maxCount, GameObject prefab)
    {
        GameObject go;
        this.maxCount = maxCount;
        gamePrefab = prefab;
        //初始化池子容量为最大容量的1/2
        for (int i = 0; i < 0.5 * maxCount; i++)
        {
            go = Instantiate(gamePrefab, this.transform);
            pool.Push(go);
            go.SetActive(false);
        }
    }

    /// <summary>
    /// 从池里面取类对象
    /// </summary>
    public GameObject Spawn()
    {
        if (pool.Count > 0)
        {
            GameObject go = pool.Pop();
            go.SetActive(true);
            return go;
        }
        else
        {
            return Instantiate(gamePrefab, this.transform);
        }
    }

    /// <summary>
    /// 回收类对象
    /// </summary>
    public void Recycle(GameObject go)
    {
        if (pool.Count >= maxCount)
        {
            Destroy(go.gameObject);
        }
        else
        {
            pool.Push(go);
            go.SetActive(false);
        }
    }

    public void ClearPool()
    {
        pool.Clear();
        Destroy(this.gameObject);
    }
}
