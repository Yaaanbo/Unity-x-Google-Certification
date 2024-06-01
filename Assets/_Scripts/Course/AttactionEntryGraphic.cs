using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Incomplete
{
    public class AttactionEntryGraphic : MonoBehaviour
    {
        [Header("Attracion Config SO")]
        private AttractionSO configSO;

        [Header("Attraction Data")]
        [SerializeField] private Image attractionThumbnailImg;
        [SerializeField] private TMP_Text attractionTitleText;
        [SerializeField] private TMP_Text attractionLocationText;

        [Header("Star Rating")]
        [SerializeField] private Image[] starsImg;
        [SerializeField] private Color activeStarColor;
        [SerializeField] private Color inactiveStarColor;

        [Header("Screen Parameters")]
        [SerializeField] private AttractionScreenParameters screenParametersPrefab;

        public void SetUpConfigSO(AttractionSO _configSO)
        {
            configSO = _configSO;

            attractionTitleText.text = configSO.title;
            attractionLocationText.text = configSO.location;

            SetUpThumbnail();

            if(PlayerPrefs.HasKey(configSO.id))
                SetUpStarRating(PlayerPrefs.GetInt(configSO.id));
            else
                SetUpStarRating(configSO.starRating);
        }

        private void SetUpThumbnail()
        {
            attractionThumbnailImg.sprite = configSO.image;

            var rectTransform = attractionThumbnailImg.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = configSO.thumbnailPosition;
            rectTransform.sizeDelta = configSO.thumbnailSize;
        }

        private void SetUpStarRating(int _starRating)
        {
            for (int i = 0; i < starsImg.Length; i++)
            {
                starsImg[i].color = i < _starRating ? activeStarColor : inactiveStarColor;
            }
        }

        public void OnClick()
        {
            var screenParameter = Instantiate(screenParametersPrefab);
            screenParameter.attractionSO = configSO;
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
