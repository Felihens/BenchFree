# Bench Free

**[English](#english) · [Português](#português)**

---

## English

Build where you are, not where your workbench is. Pieces that need a workbench, forge, stonecutter or another crafting station can be built, removed and repaired without that station nearby.

### Features

- **Client-side only.** The server and other players don't need the mod.
- **Build anywhere:** walls, floors, stone and iron pieces, furniture and everything else in the hammer menu, far from any station.
- **Remove and repair too:** the hammer removes and repairs pieces without their station nearby.
- **Keeps your progress:** by default it only works for stations you already know, the ones you have built or stood next to. No stonecutter yet means no stone pieces yet.
- Materials are still needed and wards still protect other players' bases.

### Requirements

- [BepInExPack Valheim](https://thunderstore.io/c/valheim/p/denikson/BepInExPack_Valheim/)

### Installation

**r2modman / Thunderstore Mod Manager:** click *Install*. To install a downloaded zip, go to Settings → *Import local mod*.

**Nexus Mods / Vortex:** also on [Nexus Mods](https://www.nexusmods.com/valheim/mods/4901).

**Manual:**
1. Extract the zip.
2. Copy the `plugins/BenchFree` folder into `Valheim/BepInEx/plugins/`.
   Result: `Valheim/BepInEx/plugins/BenchFree/BenchFree.dll`.
3. Launch the game.

To update, delete the old `BenchFree` folder before copying the new one.

### Configuration

Press **F1** in game (requires Configuration Manager) or edit `BepInEx/config/felih.BenchFree.cfg`.

| Option | Default | What it does |
|---|---|---|
| Enabled | on | Build without the crafting station nearby. |
| ToggleKey | none | Optional key that turns the mod on and off in game. |
| RequireKnownStation | on | Only for stations you already know. Off = every piece in the hammer menu can be built anywhere. |
| RemoveAndRepair | on | Also remove and repair pieces without their station nearby. |
| DetailedLog | off | Writes details to the BepInEx log (for bug reports). |

### Notes

- Works well with **Build Tweaks** and **DigForHoe** (same author).
- On servers with rules or anti-cheat, let the owner know: building without a station is not possible in the base game.

---

## Português

Construa onde você está, não onde está a sua bancada. Peças que pedem bancada, forja, cortador de pedra ou outra estação podem ser construídas, removidas e consertadas sem essa estação por perto.

### Recursos

- **Só no seu jogo.** O servidor e os outros jogadores não precisam ter o mod.
- **Construa em qualquer lugar:** paredes, pisos, peças de pedra e de ferro, móveis e tudo o mais do menu do martelo, longe de qualquer estação.
- **Remover e consertar também:** o martelo remove e conserta peças sem a estação delas por perto.
- **Respeita a sua progressão:** por padrão só vale para estações que você já conhece, as que você já construiu ou de que já chegou perto. Sem cortador de pedra, sem peças de pedra.
- Os materiais continuam sendo gastos e as áreas de proteção (wards) continuam protegendo as bases dos outros.

### Requisitos

- [BepInExPack Valheim](https://thunderstore.io/c/valheim/p/denikson/BepInExPack_Valheim/)

### Instalação

**r2modman / Thunderstore Mod Manager:** clique em *Install*. Para instalar um zip baixado, use Configurações → *Import local mod*.

**Nexus Mods / Vortex:** também está no [Nexus Mods](https://www.nexusmods.com/valheim/mods/4901).

**À mão:**
1. Extraia o zip.
2. Copie a pasta `plugins/BenchFree` para dentro de `Valheim/BepInEx/plugins/`.
   Resultado: `Valheim/BepInEx/plugins/BenchFree/BenchFree.dll`.
3. Abra o jogo.

Para atualizar, apague a pasta `BenchFree` antiga antes de copiar a nova.

### Configuração

Aperte **F1** no jogo (precisa do Configuration Manager) ou edite `BepInEx/config/felih.BenchFree.cfg`.

| Opção | Padrão | O que faz |
|---|---|---|
| Enabled | ligado | Constrói sem a estação por perto. |
| ToggleKey | nenhuma | Tecla opcional para ligar e desligar o mod no jogo. |
| RequireKnownStation | ligado | Só para estações que você já conhece. Desligado = qualquer peça do menu do martelo pode ser construída em qualquer lugar. |
| RemoveAndRepair | ligado | Também remove e conserta peças sem a estação delas por perto. |
| DetailedLog | desligado | Escreve detalhes no log do BepInEx (para relatar bugs). |

### Observações

- Combina com o **Build Tweaks** e o **DigForHoe** (mesmo autor).
- Em servidores com regras ou anti-cheat, avise o dono: construir sem estação não é possível no jogo normal.
