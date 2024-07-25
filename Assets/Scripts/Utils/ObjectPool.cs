
/// <summary>
/// 逻辑层对象池模板，不包含GameObject类型
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> where T : class, new()
{
    private Stack<T> pool = new Stack<T>();
    private int maxCount;//池子最大大小
    public ObjectPool(int maxCount)
    {
        this.maxCount = maxCount;
        //初始化池子容量为最大容量的1/2
        for (int i = 0; i < 0.5 * maxCount; i++)
        {
            pool.Push(new T());
        }
    }

    /// <summary>
    /// 从池里面取类对象
    /// </summary>
    public T Spawn()
    {
        if (pool.Count > 0)
        {
            return pool.Pop();
        }
        else
        {
            return new T();
        }
    }

    /// <summary>
    /// 回收类对象
    /// </summary>
    public void Recycle(T obj)
    {
        if (pool.Count >= maxCount)
        {
            obj = null;
        }
        else
        {
            pool.Push(obj);
        }
    }

    public void ClearPool()
    {
        pool.Clear();
    }
}
