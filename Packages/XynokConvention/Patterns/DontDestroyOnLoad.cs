using UnityEngine;

namespace XynokConvention.Patterns
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        public static DontDestroyOnLoad Instance;

        private void Awake()
        {
            if (Instance != null) // nếu đã có 1 bảo sao tồn tại trước đó thì tự xóa chính mình đi
            {
                Destroy(gameObject);
                return;
            }

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
        }
    }
}