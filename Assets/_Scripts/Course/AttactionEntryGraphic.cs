using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Incomplete
{
    public class AttactionEntryGraphic : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
