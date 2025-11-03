using BepInEx;
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Panels;
using UnityEngine;
using UnityEngine.UI;
using Noname.Worldless.Navigation;

namespace WorldlessArchipelago;
public class Ui : PanelBase
{
    public Ui(UIBase owner) : base(owner) { }
    public override string Name => "Cheat Panel";
    public override int MinWidth => 100;
    public override int MinHeight => 100;
    public override Vector2 DefaultAnchorMin => new(0.25f, 0.25f);
    public override Vector2 DefaultAnchorMax => new(0.75f, 0.75f);
    public override bool CanDragAndResize => true;

    protected override void ConstructPanelContent()
    {
      
    }

    internal static string GUID = "moff.archipelago";
    internal static void UpdateUI()
    {
        

    }

}
