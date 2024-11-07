# Lunar Rework
## A rework of Lethal Company's Moon system.

This mod aims to make visiting different planets during gameplay more rewarding by adding a new scrap spawning mechanic as well as other misc changes.

## Scrap Gain
# (Accessed by typing 'gain' in the Terminal)
- After leaving a moon, every single moon except the last one you've been to will **gain scrap**.
- Depending on the moon, the amount of scrap in each moon will increase from 1 to 3 per **day not visiting said moon**.
- This effect *stacks* until you reach a **hard cap**, which varies depending on the moon.
- This effect is fully customizable, and as of 0.1.0 it works with Modded (LLL) moons! (For modded moons, the default cap is 10 with a gain of +1)

## Rebirth
# (Accessed by typing 'rebirth' in the Terminal)
- For an initial 8000 credits, you may purchase a Rebirth by typing 'rebirth' into the Terminal.
- Once purchased, your Profit Quota will **loop back to 130** next quota fulfill.
- The Scrap Gain and cap of each moon will also be **doubled**.
- The cost of Rebirth will increase by 5000 credits after each purchase.

## Major Changes

- After visiting a moon, the ship will automatically reroute to the Company. This means **you must pay again in order to re-visit high-tier moons**.
**(This can be disabled in the configuration file after launching the game and going into a save file once)**
- Moon prices have been slightly altered.

## Misc changes

- Selling early will now return the full value of the items in credits. However, the amount of quota fulfilled will increase the same way.

## Notes

This mod depends on StaticNetcodeLib by xilophor, TerminalAPI by NotAtomicBomb, Interactive_Terminal_API by WhiteSpike, and LethalLevelLoader by IAmBatby.

As of 0.0.3, many of this mods' values can be configured. **(Many values can only be configured before starting a new save file. To create a configuration file, open any save file, then close the game to edit the values)**

This mod will likely break with:
- Mods that tamper with scrap amounts in base moons.

This mod is currently in **Beta**. Numbers are subject to change and bugs remain to be found.
