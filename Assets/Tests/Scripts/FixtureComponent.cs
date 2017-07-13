using System.Collections;
using System.Collections.Generic;
using GameObjectExtension;
using UnityEngine;

namespace Tests {

    public class FixtureComponent : MonoBehaviour {

        public bool boolField = false;

        private void Awake() {
            Debug.Log("Awake");
            // 冗長だが初期値に上書きする
            this.boolField = false;
        }

        private void Start() {
            Debug.Log("Start");
            // 冗長だが初期値に上書きする
            this.boolField = false;
        }

    }

}