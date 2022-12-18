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

    Queue<Transform> pool = new Queue<Transform>();
    private void Start()
    {
        
    }
    public static Transform TakeEmitter() => Instance.TakeEmitterInnerMethod();
    public static void PlaceEmitter(Transform emitter) => Instance.PlaceEmitterInnerMethod(emitter);
    private Transform TakeEmitterInnerMethod()
    {
        Transform obj;
        if (pool.Count == 0)
            obj = Instantiate(AssetHolder.Instance.EmitterPrefab).transform;
        else
            obj = pool.Dequeue();

        obj.parent = FreeEmittersHolder.Instance.transform;
        obj.gameObject.SetActive(true);
        SimulationController.Instance.OnEmitterAdded(obj);

        return obj;
    }
    private void PlaceEmitterInnerMethod(Transform emitter)
    {
        pool.Enqueue(emitter);

        emitter.GetComponent<Emitter>().CloseGameUIWindow();
        emitter.parent = transform;
        emitter.gameObject.SetActive(false);
        SimulationController.Instance.OnEmitterRemoved(emitter);
    }
}
