using System;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace WorldlessArchipelago;
public class Behaviour : MonoBehaviour
{
    internal static Behaviour Instance { get; private set; }
    public Behaviour(IntPtr ptr) : base(ptr) { }

    internal static void Setup()
    {
        ClassInjector.RegisterTypeInIl2Cpp<Behaviour>();

        GameObject obj = new("Behaviour");
        DontDestroyOnLoad(obj);
        obj.hideFlags = HideFlags.HideAndDontSave;
        Instance = obj.AddComponent<Behaviour>();
    }

    internal void Update()
    {
        KeyManager.Update();
    }

    internal void OnDestroy()
    {
        OnApplicationQuit();
    }
    internal void OnApplicationQuit()
    {
        Destroy(this.gameObject);
    }
}