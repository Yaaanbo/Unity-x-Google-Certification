using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Incomplete
{
    public class SignInPopUp : MonoBehaviour
    {
        [Header("Username Input Fields")]
        [SerializeField] private TMP_InputField userNameInputField;
        [SerializeField] private int usernameMinChar;
        [SerializeField] private Image userNameImg;

        [Header("Password Input Fields")]
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private int passwordMinChar;
        [SerializeField] private Image passwordImg;

        [Header("Others")]
        [SerializeField] private Color invalidInputFieldColor;
        public bool isLoggedIn { get; private set; }

        public void SubmitSignUp()
        {
            var isUsernameValid = IsInputValid(userNameInputField, usernameMinChar);
            var isPasswordValid = IsInputValid(passwordInputField, passwordMinChar);

            userNameImg.color = isUsernameValid ? Color.white : invalidInputFieldColor;
            passwordImg.color = isPasswordValid ? Color.white : invalidInputFieldColor;

            if (!isUsernameValid || !isPasswordValid) return;

            SaveLogInData();

            SceneManager.UnloadSceneAsync("PopUpExample");
        }

        private void SaveLogInData()
        {
            isLoggedIn = true;

            PlayerData playerData = new PlayerData(userNameInputField.text, passwordInputField.text, isLoggedIn);
            string dataToSave = JsonUtility.ToJson(playerData);

            if(File.Exists(Application.persistentDataPath + "/PlayerData.json"))
                File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", dataToSave);
            else
                File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", dataToSave);

            Debug.Log(playerData.isLoggedIn);
        }

        private bool IsInputValid(TMP_InputField _input, int _inputMinLength)
        {
            return !string.IsNullOrEmpty(_input.text) && _input.text.Length >= _inputMinLength;
        }
    }
}

