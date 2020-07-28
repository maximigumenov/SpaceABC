using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FastScriptingSpace
{
    public class FastScriptingManager : MonoBehaviour
    {
        public FastScripting_Code fastScripting_Code;

        [ContextMenu("Test")]
        public void Test() {
            fastScripting_Code.CreateCode();
        }
    }
}
