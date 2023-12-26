namespace XynokGUI.Enums
{
    public enum XynokGuiEvent
    {
        /// <summary>
        /// emit when start load scene,  [emit data]: class LoadSceneEventData - data này gôm các action sẽ được thực hiện sau khi load scene completed
        /// </summary>
        StartLoadScene,
        
        /// <summary>
        /// emit when load scene completed,
        /// </summary>
        LoadSceneCompleted,
        
        /// <summary>
        /// emit when swap input map, [emit data]: ko có data, truy cập `InputManager.Instance.CurrentMap` để lấy tên map hiện tại
        /// </summary>
        SwapInputMap,
    }
}