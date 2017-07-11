using UnityEngine;

namespace GameObjectExtension {

    /// <summary>
    /// TestComponent に関する GameObject 用拡張クラス
    /// </summary>
    public static class ComponentExtension {

        /// <summary>
        /// TestComponent がアタッチされているかどうかを返す
        /// </summary>
        /// <param name="gameObject">対象 GameObject</param>
        /// <typeparam name="T">対象の型</typeparam>
        /// <returns>アタッチされているなら真</returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : UnityEngine.Component {
            return gameObject.GetComponent<T>() != null;
        }

        /// <summary>
        /// 未アタッチならば AddComponent してからインスタンスを返す
        /// </summary>
        /// <param name="gameObject">対象 GameObject</param>
        /// <typeparam name="T">対象の型</typeparam>
        /// <returns>インスタンス</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : UnityEngine.Component {
            return gameObject.HasComponent<T>() ? gameObject.GetComponent<T>() : gameObject.AddComponent<T>();
        }

    }

}