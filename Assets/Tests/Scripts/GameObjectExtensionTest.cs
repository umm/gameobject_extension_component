using UnityEngine;
using GameObjectExtension;
using NUnit.Framework;

namespace Tests {

    public class GameObjectExtensionTest {

        [Test]
        public void HasComponentTest() {
            GameObject go = new GameObject();
            Assert.IsFalse(go.HasComponent<FixtureComponent>(), "FixtureComponent がない");
            go.AddComponent<FixtureComponent>();
            Assert.IsTrue(go.HasComponent<FixtureComponent>(), "FixtureComponent がある");
        }

        [Test]
        public void GetOrAddComponentTest() {
            GameObject go = new GameObject();
            Assert.IsNull(go.GetComponent<FixtureComponent>(), "GetOrAddComponent 前は Component が null");
            FixtureComponent fixtureComponent = go.GetOrAddComponent<FixtureComponent>();
            Assert.IsNotNull(go.GetComponent<FixtureComponent>(), "GetOrAddComponent 後は Component が存在する");
            Assert.AreSame(go.GetOrAddComponent<FixtureComponent>(), fixtureComponent, "追加済の場合に同じインスタンスを返す");
        }

    }

}
