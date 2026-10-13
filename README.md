# Dialog System for Unity

A branching dialogue system for Unity, built on ScriptableObjects.

## What it is

Conversations are written as data assets instead of code. Each NPC's conversation is split into segments, and each segment holds a few lines of dialogue. At the end of a segment the player gets choice buttons that branch to other segments.

It also supports:

- **Triggers** — a specific line can fire an event, for example to give an item or start a quest.
- **Changing start points** — a choice can change where the NPC's next conversation starts, so NPCs can "remember" what you talked about.
- **Event channels** — any script can start a conversation by raising an event, without needing a direct reference to the dialogue UI.

## Why I made it

Dialogue with choices is in a lot of the games I like, and I was curious how it's put together behind the scenes. I wanted to work out how to store branching conversations as data, how to move between branches, and how to keep the dialogue system separate from the rest of the game so it's easy to reuse.

## License

Licensed under the [GNU General Public License v3.0](LICENSE).
