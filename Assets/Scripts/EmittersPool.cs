using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object Pool for emitters
/// </summary>
public class EmittersPool : MonoBehaviour
{
    #region Instance
    static EmittersPool instance;
    public static EmittersPool Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    List<Transform> pool;
    private void Start()
    {
        pool = new List<Transform>();
    }
    public Transform TakeEmitter()
    {
        Transform obj;
        if (pool.Count == 0)
        {
            obj = Instantiate(AssetHolder.Instance.EmitterPrefab).transform;
            obj.gameObject.SetActive(true);
            return obj;
        }

        obj = pool[0];
        pool.RemoveAt(0);
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void PlaceEmitter(Transform emitter)
    {
        pool.Add(emitter);
        emitter.parent = transform;
        emitter.gameObject.SetActive(false);
    }
}
