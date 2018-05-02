# What?

* `UnityEngine.GameObject` の拡張クラスです。
* 主に GameObject に対する Component 関連の操作を拡張します。

# Why?

* 毎回 `if (gameObject.GetComponent<Hoge>() != null)` とか書くのが面倒だったのが発端。
* 「未追加なら追加」的な操作も何回書いたか分からんレベルだったので、同じく拡張する。
* AddComponent 後にインスタンスフィールドを初期化したくなる衝動に駆られることも多かったので、それも追加。

# Install

```shell
yarn add "umm-projects/gameobject_extension_component#^1.0.0"
```

# Usage

```c#
using UnityEngine;
// ココがポイント
using GameObjectExtension;

public class Hoge : MonoBehaviour {
    
    public void Start() {
        // コンポーネントの有無をチェック
        if (this.gameObject.HasComponent<Fuga>()) {
            Debug.Log("Hoge has component: Fuga");
        }
        // AddComponent 直後 (= Awake() 直後) に呼び出される処理を記述
        this.gameObject.AddComponent<Piyo>(
            (piyoInstance) => {
                piyoInstance.isPonyo = true;
            }
        );
    }

}

public class Fuga : MonoBehaviour {
    
    public void Start() {
        Piyo piyo;
        // 未追加のハズなので、追加される
        piyo = this.gameObject.GetOrAddComponent<Piyo>();
        // 上で追加済なので、そのインスタンスを取得
        piyo = this.gameObject.GetOrAddComponent<Piyo>();
    }

}

public class Piyo : MonoBehaviour {

    public bool isPonyo = false;

}
```

* `GameObjectExtension` namespace を `using` するコトで拡張が有効になります。

# License

Copyright (c) 2017 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

