using System.Numerics;
using Noname;
using UnityEngine;
using UniverseLib.Input;

namespace WorldlessArchipelago;
public class KeyManager
{
    static internal void Update()
    {
        if (UniverseLib.Input.InputManager.GetKeyDown(KeyCode.F8))
        {
            UIManager.ShowUI = !UIManager.ShowUI;
        }
    }
}