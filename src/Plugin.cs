using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace BenchFree
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "felih.BenchFree";
        public const string NAME = "Bench Free";
        public const string VERSION = "1.0.0";

        internal static ManualLogSource Log;
        internal static ConfigEntry<bool> Enabled;
        internal static ConfigEntry<KeyboardShortcut> ToggleKey;
        internal static ConfigEntry<bool> RequireKnownStation;
        internal static ConfigEntry<bool> RemoveAndRepair;
        internal static ConfigEntry<bool> DetailedLog;

        private void Awake()
        {
            Log = Logger;
            Enabled = Config.Bind("1 - General", "Enabled", true,
                "Build without the crafting station (workbench, forge, stonecutter...) nearby.");
            ToggleKey = Config.Bind("1 - General", "ToggleKey", new KeyboardShortcut(KeyCode.None),
                "Optional key that turns the mod on and off in game. None = no key.");
            RequireKnownStation = Config.Bind("2 - Rules", "RequireKnownStation", true,
                "Only for stations you already know (you have built or stood next to one). " +
                "Off = every piece in the hammer menu can be built anywhere.");
            RemoveAndRepair = Config.Bind("2 - Rules", "RemoveAndRepair", true,
                "Also remove and repair pieces without their station nearby.");
            DetailedLog = Config.Bind("9 - Debug", "DetailedLog", false, "Writes details to the BepInEx log.");
            new Harmony(GUID).PatchAll(typeof(Plugin).Assembly);
            Log.LogInfo(NAME + " " + VERSION + " loaded");
        }

        private void Update()
        {
            if (ToggleKey.Value.MainKey != KeyCode.None && ToggleKey.Value.IsDown())
            {
                Enabled.Value = !Enabled.Value;
                Player p = Player.m_localPlayer;
                if (p != null) p.Message(MessageHud.MessageType.TopLeft, NAME + ": " + (Enabled.Value ? "on" : "off"));
            }
        }

        internal static void Debug(string msg)
        {
            if (DetailedLog.Value) Log.LogInfo(msg);
        }
    }

    // The game checks for a station in range in three places: the build check (Player.HaveRequirements
    // for a piece), and removing and repairing (both go through Player.CheckCanRemovePiece).
    // Each one asks CraftingStation.HaveBuildStationInRange. While one of these checks runs for your own
    // character, a "no station in range" answer is replaced by the piece's own station, so the check passes.
    // Placing a piece is done by your own game, so the server and other players don't need the mod.
    [HarmonyPatch]
    internal static class StationCheck
    {
        private static Piece _piece;      // the piece being checked, while a check runs
        private static bool _removing;
        private static readonly HashSet<string> Logged = new HashSet<string>();
        // Stations you have discovered (built, or stood next to one), by name.
        private static readonly System.Reflection.FieldInfo KnownStationsField = AccessTools.Field(typeof(Player), "m_knownStations");

        private static bool KnowsStation(Player p, string name)
        {
            var known = KnownStationsField != null ? KnownStationsField.GetValue(p) as Dictionary<string, int> : null;
            return known != null && known.ContainsKey(name);
        }

        [HarmonyPatch(typeof(Player), "HaveRequirements", typeof(Piece), typeof(Player.RequirementMode))]
        [HarmonyPrefix]
        private static void BuildCheck(Player __instance, Piece piece)
        {
            _piece = __instance == Player.m_localPlayer ? piece : null;
            _removing = false;
        }

        [HarmonyPatch(typeof(Player), "HaveRequirements", typeof(Piece), typeof(Player.RequirementMode))]
        [HarmonyFinalizer]
        private static void BuildCheckDone() { _piece = null; }

        [HarmonyPatch(typeof(Player), "CheckCanRemovePiece")]
        [HarmonyPrefix]
        private static void RemoveCheck(Player __instance, Piece piece)
        {
            _piece = __instance == Player.m_localPlayer ? piece : null;
            _removing = true;
        }

        [HarmonyPatch(typeof(Player), "CheckCanRemovePiece")]
        [HarmonyFinalizer]
        private static void RemoveCheckDone() { _piece = null; }

        [HarmonyPatch(typeof(CraftingStation), "HaveBuildStationInRange")]
        [HarmonyPostfix]
        private static void InRange(string name, ref CraftingStation __result)
        {
            if (__result != null || _piece == null || !Plugin.Enabled.Value) return;
            CraftingStation station = _piece.m_craftingStation;
            if (station == null || station.m_name != name) return;
            if (_removing && !Plugin.RemoveAndRepair.Value) return;

            Player p = Player.m_localPlayer;
            if (Plugin.RequireKnownStation.Value && (p == null || !KnowsStation(p, name))) return;

            __result = station;
            if (Plugin.DetailedLog.Value && Logged.Add((_removing ? "remove " : "build ") + _piece.m_name))
                Plugin.Log.LogInfo("[" + (_removing ? "remove/repair" : "build") + "] " + _piece.m_name +
                    " allowed without " + name + " nearby");
        }
    }
}
