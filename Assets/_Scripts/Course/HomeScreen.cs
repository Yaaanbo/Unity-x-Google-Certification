using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Incomplete
{
    public class HomeScreen : MonoBehaviour
    {
        [Header("Attraction SO")]
        [SerializeField] private AttractionSO[] configSO;

        [Header("Spawning Attraction Data")]
        [SerializeField] private RectTransform attractionEntryParent;
        [SerializeField] private AttactionEntryGraphic attractionPrefab;

        [Header("UIs")]
        [SerializeField] private Image avatarImg;
        [SerializeField] private TMP_Text userNameTxt;

        private void Awake()
        {
            InstantiateAttractionGraphics();
        }

        private void Start()
        {
            LoadLoginData(); 
        }

        private void InstantiateAttractionGraphics()
        {
            for (int i = 0; i < configSO.Length; i++)
            {
                var attractionObj = Instantiate(attractionPrefab, attractionEntryParent);
                attractionObj.SetUpConfigSO(configSO[i]);
            }
        }

        private void LoadLoginData()
        {
            PlayerData playerData = new PlayerData();
            Debug.Log("IsLoggedIn : " + playerData.isLoggedIn);

            if(!playerData.isLoggedIn)
            {
                avatarImg.gameObject.SetActive(true);
                userNameTxt.gameObject.SetActive(false);
                return;
            }

            string dataToLoad = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");
            var loadedData = JsonUtility.FromJson<PlayerData>(dataToLoad);

            avatarImg.gameObject.SetActive(false);
            userNameTxt.gameObject.SetActive(true);

            userNameTxt.text = loadedData.username;


        }

        public void SignUp()
        {
            SceneManager.LoadScene("PopUpExample", LoadSceneMode.Additive);
        }
    }
}

