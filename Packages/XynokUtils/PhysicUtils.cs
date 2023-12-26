using UnityEngine;

namespace XynokUtils
{
    public partial class XynokUtility
    {
        public static class PhysicUtils
        {
            #region Layer Detection

            public static bool IsLayer(Transform transform, LayerMask layerMask)
            {
                return layerMask == (layerMask | (1 << transform.gameObject.layer));
            }

            public static bool IsLayer(GameObject gameObject, LayerMask layerMask)
            {
                return layerMask == (layerMask | (1 << gameObject.layer));
            }

            #region 2D

            public static bool IsLayer(Collider2D col, LayerMask layerMask)
            {
                return layerMask == (layerMask | (1 << col.gameObject.layer));
            }

            public static bool IsLayer(Collision2D col, LayerMask layerMask)
            {
                return layerMask == (layerMask | (1 << col.gameObject.layer));
            }

            public static bool HitLayer2D(LayerMask layerMask, Vector2 pos, Vector2 checkSize, float angle)
            {
                return Physics2D.OverlapBox(pos, checkSize, angle, layerMask);
            }

            #endregion

            #region 3D

            public static bool IsLayer(Collider col, LayerMask layerMask)
            {
                return layerMask == (layerMask | (1 << col.gameObject.layer));
            }

            public static bool IsLayer(Collision col, LayerMask layerMask)
            {
                return layerMask == (layerMask | (1 << col.gameObject.layer));
            }

            #endregion

            #endregion
        }
    }
}