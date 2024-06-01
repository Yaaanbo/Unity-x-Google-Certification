using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Incomplete
{
    public class AttractionScreenParameters : MonoBehaviour
    {
        public AttractionSO attractionSO { get; set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}

