using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayfabManager : MonoBehaviour
{

    public static PlayfabManager instance;
    public AudioSource buttonAudio;
    public TMPro.TMP_Text messageText;
    public TMPro.TMP_InputField emailInput;
    public TMPro.TMP_InputField passwordInput;
    public GameObject menu;
    public GameObject login;
    public GameObject leaderboard;
    public GameObject display;
    public TMPro.TMP_InputField usernameInput;
    


    public void LoginScreenActive()
    {
        login.SetActive(true);
    }
    void Start()
    {
         Login(); 
    }

    public void RegisterButton()
    {
        if(passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
        


    }
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "5E0F9"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }

        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/Account create!");
        messageText.text = "Logged in!";
        GetTitleData();
        string name = null;
        if(result.InfoResultPayload.PlayerProfile !=null)
             name = result.InfoResultPayload.PlayerProfile.DisplayName;
        if(!PlayerPrefs.HasKey("Displayname"))
        {
            Invoke("Display", 2f);
        }
    }
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = usernameInput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        buttonAudio.Play();
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        display.SetActive(false);
        PlayerPrefs.SetString("Displayname", result.DisplayName);
    }
    void Display()
    {
        display.SetActive(true);
        login.SetActive(false);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/ creating account!");
        Debug.Log(error.GenerateErrorReport());
        messageText.text = error.ErrorMessage;
    }
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
    }
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
        buttonAudio.Play();
        Invoke("LeaderboardScreen", 2f);
    }
    public GameObject prefab;
    public GameObject parent;
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log((item.Position +1 ).ToString()+ " " + item.DisplayName + " " + item.StatValue);
            GameObject go = Instantiate(prefab, transform.position,Quaternion.identity);
            go.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = (item.Position+1).ToString();
            go.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = item.DisplayName.ToString();
            go.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text = item.StatValue.ToString();
            go.transform.SetParent(parent.transform, false);
        }
    }

    void LeaderboardScreen()
    {
        leaderboard.SetActive(true);
    }

    void GetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataRecieved, OnError);
    }

    void OnTitleDataRecieved(GetTitleDataResult result)
    {
        if(result.Data== null || result.Data.ContainsKey("Message") == false)
        {
            Debug.Log("No Message!");
            return;
        }
        //messageText.text = result.Data["Message"];
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        buttonAudio.Play();
    }
}
