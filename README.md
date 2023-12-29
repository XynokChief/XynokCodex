![Static Badge](https://img.shields.io/badge/ynok_Codex-009ECE?logo=x)  ![Static Badge](https://img.shields.io/badge/version_-v0.3.0-00CE2D)  [![Discord](https://img.shields.io/discord/1088559270456459314?logo=discord&label=discord&labelColor=B6BBC4)](https://discord.gg/4nMcX9pXDq)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)  ![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54)
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)  ![Steam](https://img.shields.io/badge/steam-%23000000.svg?style=for-the-badge&logo=steam&logoColor=white) ![Google Drive](https://img.shields.io/badge/Google%20Drive-4285F4?style=for-the-badge&logo=googledrive&logoColor=white)
![PyCharm](https://img.shields.io/badge/pycharm-143?style=for-the-badge&logo=pycharm&logoColor=black&color=black&labelColor=green)  ![rider](https://img.shields.io/badge/jetbrains_rider-3670A0?style=for-the-badge&logo=rider&logoColor=orange&color=black)  ![Obsidian](https://img.shields.io/badge/Obsidian-%23483699.svg?style=for-the-badge&logo=obsidian&logoColor=white)


# Install Guide
```cs
// chỉnh sửa file manifest.json
“com.yourusername.yourpackage”: “git+https://x-oauth-basic:<token>@<repo>?path=<folder>"

// Example:
“com.dasannikov.superlib”: “git+https://x-oauth-basic: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@github.com/dasannikov/unity-package-superlib?path=/Assets/SuperLib"

// Detail Examle:
"com.xynok.convention": "git+https://x-oauth-basic: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@github.com/XynokChief/XynokCodex?path=Packages/XynokConvention#release/v0.3.0",
```

# Overview
---
Tập hợp codebase, tools,... của Xynok Studio. Mục đích hiện tại, sử dụng cho dự án UJ.
Để gia tăng hiệu quả sử dụng, bảo trì, nâng cấp bộ codebase này, sau đây là danh sách các tool, đối tượng,... phù hợp:

- Game Genre Target: Action - RPG
- Platform: Window, MacOS
- Store: Steam
- Game Engine: Unity
- External Tools: Google Sheet, Github, Draw.io
- IDE: Jetbrain Rider, Pycharm
- Language: C#, Python, Markdown

Hiện tại có tổng cộng 10 packages.


# Xynok Convention
---
Bao gồm các qui ước chung về:
- Data
	- Binding
	- Collection
	- Primitives
- Design Pattern
	- Singleton
	- Factory
	- Dependency Injection
- Keywords
- Procedural
	- Time
	- Event Manager

# Xynok Source Generator
---
Chứa .Dll của Roslyn. Có nhiệm vụ triển khai các qui ước phức tạp của Xynok Codex.

Nhằm gia tăng hiệu quả công việc, tiết kiệm thời gian và đảm bảo chất lượng `code convention` của các dự án trong nội bộ Xynok Studio.

# Xynok Entity
---
Là *Source Guide* cho  **Xynok Source Generator**. Cụ thể:

- định nghĩa data flow của một entity
- định nghĩa các kiểu quan hệ giữa:
	- data & data
	- data & entity
	- data & logic
## AnimPhasing
---
### Overview
Hệ thống xử lý animation cho các game fighting game - Frame Data Management.

Nguồn tham khảo:
- Elden Ring
- SkullGirls
- StreetFighter 3rd Strike

**Note:** Hiện tại chỉ đang
- hỗ trợ 1 layer của animator.
- override anim MaxQueue = 1.
- Các detect event và reset event đều ignored transition của animation.
- Chỉ hỗ trợ 1 overrider cho các ability của entity. (build-in, auto included)

### How to use

**Step 1:** implement Attribute `EntityStateMachineBehavior` for an entity enum.

```csharp
// example:
    [EntityStateMachineBehavior(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType),"Assets/Scripts/Core/Generated/Character")]
public enum CharacterID
{
    Superman,
    Batman
}
```


**Step 2:** Add Component `{EntityName}AnimatorFrameDataContainer` for animator gameobject.

**Step 3:** Kế thừa  `XynokEntity.APIs.IActionAnimOverrider` để trở thành 1 overrider.

**Step 4:** Add `{EntityName}AbilityInitAnimActionOverrider` vào Ability của entity.



# Xynok Input
---
Chịu trách nhiệm lưu trữ các map và action đã được define của Input. Là một wrapper của `com.unity.inputsystem`.

**Note:** *package này ko chứa logic hay service nào cả. Chỉ là dạng Data Convention và Data Container của input mà thôi.*

# Xynok GUI
---
Quản lý các tính năng của UI và Input. Các class quan trọng:
- `XynokGUI.Manager.InputManager`:  Quản lý các API của input. Muốn sử dụng action gì thì gọi tới đây.


# Xynok Dialogue
---
xynok Dialogue là một wrapper của [Yarn Dialogue](https://docs.yarnspinner.dev/using-yarnspinner-with-unity/installation-and-setup)

> Install from git Url: [https://github.com/YarnSpinnerTool/YarnSpinner-Unity.git#current](https://github.com/YarnSpinnerTool/YarnSpinner-Unity.git#current)

# Xynok Utils
---
Gồm rất nhiều các phương thức tiện ích, extensions dành cho nhiều case khác nhau.

# Xynok Plugin
---
Bao gồm những plugin cơ bản phục vụ cho việc quản lý code và tool creation. Cụ thể gồm:

- Odin Inspector and Serializer v3.2.1.0 (cracked) // todo: mua khi có thể
- DOTween (HOTween v2) Version 1.2.745


# Xynok T4 Template
---
Một thư viện xử lý việc gen code của các file .tt. Hỗ trợ mapping tới ScriptableObject của Unity.

# Xynok 3d Prototype Asset
---
Tập hợp các asset như:

- 3d model + basic animation
- Vfx
- Sound
- Font

Nhằm tối giản quá trình setup một dự án mới.