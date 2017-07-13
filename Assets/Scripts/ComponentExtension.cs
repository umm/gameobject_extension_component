using System;
using UnityEngine;

namespace GameObjectExtension {

    /// <summary>
    /// TestComponent に関する GameObject 用拡張クラス
    /// </summary>
    public static class ComponentExtension {

        /// <summary>
        /// 追加されたインスタンスを初期化時コールバックに渡せる AddComponent
        /// </summary>
        /// <param name="gameObject">対象 GameObject</param>
        /// <param name="onInitialize">初期化時コールバック</param>
        /// <typeparam name="T">対象の型</typeparam>
        /// <returns>インスタンス</returns>
        public static T AddComponent<T>(this GameObject gameObject, Action<T> onInitialize) where T : Component {
            T instance = gameObject.AddComponent<T>();
            if (onInitialize != null) {
                onInitialize(instance);
            }
            return instance;
        }

        /// <summary>
        /// TestComponent がアタッチされているかどうかを返す
        /// </summary>
        /// <param name="gameObject">対象 GameObject</param>
        /// <typeparam name="T">対象の型</typeparam>
        /// <returns>アタッチされているなら真</returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component {
            return gameObject.GetComponent<T>() != null;
        }

        /// <summary>
        /// 未アタッチならば AddComponent してからインスタンスを返す
        /// </summary>
        /// <param name="gameObject">対象 GameObject</param>
        /// <param name="onInitialize">初期化時コールバック</param>
        /// <typeparam name="T">対象の型</typeparam>
        /// <returns>インスタンス</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject, Action<T> onInitialize = null) where T : Component {
            // ReSharper disable once RedundantTypeArgumentsOfMethod
            return gameObject.HasComponent<T>() ? gameObject.GetComponent<T>() : gameObject.AddComponent<T>(onInitialize);
        }

    }

}