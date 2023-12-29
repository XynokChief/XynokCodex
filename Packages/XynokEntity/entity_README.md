#XynokConvention #XynokEntity  
# Folder: AnimPhasing


Hệ thống xử lý animation cho các game fighting game - Frame Data Management.

Nguồn tham khảo:
- Elden Ring
- SkullGirls
- StreetFighter 3rd Strike

_Hiện tại chỉ:_
- hỗ trợ 1 layer của animator.
- override anim MaxQueue = 1.
- Các detect event và reset event đều ignored transition của animation.
- Chỉ hỗ trợ 1 overrider cho các ability của entity. (build-in, auto included)

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

**Step 3:** Kế thừa  `XynokEntity.APIs.IActionAnimOverrider` để trở thành 1 overrider.

**Step 4:** Add `{EntityName}AbilityInitAnimActionOverrider` vào Ability của entity.