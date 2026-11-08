# Bench Free

A client-side BepInEx mod for Valheim: build, remove and repair without the workbench, forge or stonecutter nearby, for stations you already know.

Mod para Valheim (BepInEx, client-side): construir, remover e consertar sem a bancada, a forja ou o cortador de pedra por perto, para estações que você já conhece.

For players, see [package/README.md](package/README.md). That file is also the Thunderstore page.
Para jogadores, veja [package/README.md](package/README.md).

Download: [Thunderstore](https://thunderstore.io/c/valheim/p/DJAventuras/BenchFree/) · [Nexus Mods](https://www.nexusmods.com/valheim/mods/4901) · [GitHub Releases](https://github.com/Felihens/BenchFree/releases)

Sister mods / mods irmãos: [Build Tweaks](https://github.com/Felihens/BuildTweaks), [DigForHoe](https://github.com/Felihens/DigForHoe), [Gather Tweaks](https://github.com/Felihens/GatherTweaks), [Resource Scanner](https://github.com/Felihens/ResourceScanner), [Ore Weak Spots](https://github.com/Felihens/OreWeakSpots), [Tree Weak Spots](https://github.com/Felihens/TreeWeakSpots).

## How it works

The game checks for a station in range when you build (`Player.HaveRequirements` for a piece) and when you remove or repair (`Player.CheckCanRemovePiece`). Both ask `CraftingStation.HaveBuildStationInRange`. While one of these checks runs for your own character, the mod answers "no station in range" with the piece's own station, so the check passes. Placing a piece is done by your own game, so nothing else needs the mod.

## Building

`sh build.sh` compiles `src/*.cs` against the game's assemblies and installs the dll into `BepInEx/plugins/BenchFree/` (`sh build.sh nocopy` only compiles). Then `powershell -File pack.ps1` builds `dist/BenchFree-<version>.zip` from `package/`.

## License

MIT
