using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Incomplete
{
    public class AttractionScreen : MonoBehaviour
    {
        [Header("UIs")]
        [SerializeField] private Image headerImg;
        [SerializeField] private TMP_Text attractionTitleTxt;
        [SerializeField] private TMP_Text attractionDescTxt;
        [SerializeField] private TMP_Text attractionLocationTxt;

        [Header("Stars")]
        [SerializeField] private Image[] starsImg;
        [SerializeField] private Color activeStarColor;
        [SerializeField] private Color inactiveStarColor;

        private AttractionScreenParameters attractionScreenParameters;

        private void Start()
        {
            attractionScreenParameters = FindObjectOfType<AttractionScreenParameters>();
            var newAttractionSO = attractionScreenParameters.attractionSO;

            SetUpAttractionInfo(newAttractionSO);
            SetUpAttractionImage(newAttractionSO);

            if (PlayerPrefs.HasKey(attractionScreenParameters.attractionSO.id))
                SetUpStarRating(PlayerPrefs.GetInt(attractionScreenParameters.attractionSO.id));
            else
                SetUpStarRating(attractionScreenParameters.attractionSO.starRating);
        }

        private void SetUpAttractionImage(AttractionSO _attractionSO)
        {
            headerImg.sprite = _attractionSO.image;
            var rectTransform = headerImg.GetComponent<RectTransform>();

            rectTransform.anchoredPosition3D = _attractionSO.headerImagePosition;
            rectTransform.sizeDelta = _attractionSO.headerImageSize;
        }

        private void SetUpAttractionInfo(AttractionSO _attractionSO)
        {
            attractionTitleTxt.text = _attractionSO.title;
            attractionDescTxt.text = _attractionSO.description;
            attractionLocationTxt.text = _attractionSO.location;
        }

        private void SetUpStarRating(int _starRating)
        {
            for (int i = 0; i < starsImg.Length; i++)
            {
                starsImg[i].color = i < _starRating ? activeStarColor : inactiveStarColor;
            }
        }

        public void OnClickStar(int _starIndex)
        {
            PlayerPrefs.SetInt(attractionScreenParameters.attractionSO.id, _starIndex);
            SetUpStarRating(_starIndex);
        }

        public void OnClickBack()
        {
            Destroy(attractionScreenParameters.gameObject);
            SceneManager.LoadScene("HomeScreen", LoadSceneMode.Single);
        }
    }
}

