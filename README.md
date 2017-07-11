# What?

* `UnityEngine.GameObject` の拡張クラスです。
* 主に GameObject に対する Component 関連の操作を拡張します。

# Why?

* 毎回 `if (gameObject.GetComponent<Hoge>() != null)` とか書くのが面倒だったのが発端。
* 「未追加なら追加」的な操作も何回書いたか分からんレベルだったので、同じく拡張する。

# Install

```shell
$ npm install @umm/game-object-extension-component
```

# Usage

```c#
using UnityEngine;
using GameObjectExtension;

public class Hoge : MonoBehaviour {
    
    public void Start() {
        if (this.gameObject.HasComponent<Fuga>()) {
            Debug.Log("Hoge has component: Fuga");
        }
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
}
```

# License

Copyright (c) 2017 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

