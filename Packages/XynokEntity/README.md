# Folder: AnimPhasing
Entity Animations Frame Data Handler, reference `framedata` system from:
- Elden Ring
- SkullGirls
- StreetFighter 3rd Strike


## How to use

**Step 1:** implement Attribute `EntityStateMachineBehavior` for an entity enum.

```csharp
// example:
    [EntityStateMachineBehavior(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType),"Assets/Scripts/Core/Generated/Character")]
public enum HeroID
{
    Superman,
    Batman
}
```

**Step 2:**
Add Component `{EntityName}AnimatorFrameDataContainer` for animator gameobject.