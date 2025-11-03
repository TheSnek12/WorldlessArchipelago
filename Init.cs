using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UniverseLib.UI;

namespace WorldlessArchipelago;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log;

    public override void Load()
    {
        float startupDelay = 1f;
        UniverseLib.Config.UniverseLibConfig config = new()
        {
            Disable_EventSystem_Override = false,
            Force_Unlock_Mouse = true,
        };
        UniverseLib.Universe.Init(startupDelay, CreateUI, LogHandler, config);
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }

    void CreateUI()
    {
        UIManager.InitUI();
        ItemPatcher.Patch();
        Behaviour.Setup();
    }

    void LogHandler(string message, UnityEngine.LogType logType)
    {
        
        switch (logType)
        {
            case UnityEngine.LogType.Log:
                Log.LogInfo(message);
                break;
            case UnityEngine.LogType.Warning:
                Log.LogWarning(message);
                break;
            case UnityEngine.LogType.Error:
                Log.LogError(message);
                break;
            case UnityEngine.LogType.Assert:
                Log.LogError(message);
                break;
            case UnityEngine.LogType.Exception:
                Log.LogError(message);
                break;

            default:
                break;
        }
    }
}
