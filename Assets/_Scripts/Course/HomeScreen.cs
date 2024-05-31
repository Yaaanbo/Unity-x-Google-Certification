using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Incomplete
{
    public class HomeScreen : MonoBehaviour
    {
        [Header("Spawning Attraction Data")]
        [SerializeField] private RectTransform attractionEntryParent;
        [SerializeField] private AttactionEntryGraphic attractionPrefab;

        private void Awake()
        {
            InstantiateAttractionGraphics();
        }

        private void InstantiateAttractionGraphics()
        {
            var attractionObj = Instantiate(attractionPrefab, attractionEntryParent);
        }

        public void SignUp()
        {
            SceneManager.LoadScene("PopUpExample", LoadSceneMode.Additive);
        }
    }
}

