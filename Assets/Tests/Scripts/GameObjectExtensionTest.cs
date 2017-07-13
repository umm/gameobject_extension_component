using System.Collections;
using UnityEngine;
using GameObjectExtension;
using NUnit.Framework;
using UnityEngine.TestTools;

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

        [UnityTest]
        public IEnumerator AddComponentWithOnInitializeArgumentTest() {
            GameObject go = new GameObject();
            go.AddComponent<FixtureComponent>(
                (x) => {
                    Assert.IsFalse(x.boolField, "Begin: onInitialize");
                    x.boolField = true;
                    Assert.IsTrue(x.boolField, "End: onInitialize");
                }
            );
            Assert.IsTrue(go.GetComponent<FixtureComponent>().boolField, "Awake() コール後");
            yield return null;
            Assert.IsFalse(go.GetComponent<FixtureComponent>().boolField, "Start() コール後");
        }

    }

}
