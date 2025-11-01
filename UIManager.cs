using Cpp2IL.Core.Utils;
using UniverseLib.UI;

namespace WorldlessArchipelago;
public class UIManager
{
    internal static UIBase UiBase { get; private set; }
    internal static Ui Ui { get; private set; }
    internal static void InitUI()
    {
        UiBase = UniversalUI.RegisterUI(Ui.GUID, Ui.UpdateUI);
        Ui = new(UiBase);
    }
    internal static bool ShowUI
    {
        get => UiBase != null && UiBase.Enabled;

        set
        {
            if (UiBase == null || !UiBase.RootObject || UiBase.Enabled == value)
                return;
            UniversalUI.SetUIActive(Ui.GUID, value);
        }
    } 
}