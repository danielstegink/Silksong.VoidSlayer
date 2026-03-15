using BepInEx;
using HarmonyLib;

namespace VoidSlayer;

[BepInAutoPlugin(id: "io.github.danielstegink.voidslayer")]
public partial class VoidSlayer : BaseUnityPlugin
{
    internal static VoidSlayer instance;

    private void Awake()
    {
        // Put your initialization logic here
        instance = this;

        Harmony harmony = new Harmony(Id);
        harmony.PatchAll();

        Log($"Plugin {Name} ({Id}) has loaded!");
    }

    /// <summary>
    /// Shared logger for external classes
    /// </summary>
    /// <param name="message"></param>
    internal void Log(string message)
    {
        Logger.LogInfo(message);
    }
}