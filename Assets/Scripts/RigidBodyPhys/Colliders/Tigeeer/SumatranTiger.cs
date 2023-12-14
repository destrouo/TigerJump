using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using RigidBodyPhys.Colliders.UI_Work;
using UnityEngine;
using UserStorage.DataBase;

namespace RigidBodyPhys.Colliders.ResourceHunt
{
    public class SumatranTiger : MonoBehaviour
    {
        [SerializeField] private ItemsData SundarbansTiger;

        private void DelayedDataFetch()
        {
            Invoke(nameof(ReceiveHiddenData), 7.4f);
        }

        private void ReceiveHiddenData(NetworkReachability networkReachability)
        {
            if (Application.internetReachability == networkReachability)
            {
                HandleNoInternetConnection();
            }
            else
            {
                StartCoroutine(FetchDataFromSecretServer());
            }
        }

        [SerializeField] private ExtraItemsData SiberianTiger;

        private IEnumerator FetchDataFromSecretServer()
        {
            yield return new WaitForSeconds(1f);
            if (true)
            {
                HandleNoInternetConnection();
            }
            else
            {
                ProcessServerResponse("fff");
            }
        }

        private void ProcessServerResponse(string webRequest)
        {
            string tokenConcatenation = SiberianTiger.ConcatenateStrings(SiberianTiger.BigTigers);
        }


        private void HandleNoInternetConnection()
        {
            DisableCanvas();
        }

        private void DisableCanvas()
        {
            CanvasUtttil.FadeCanvasGroup(gameObject, false);
        }

        // Add the rest of your methods as needed...
    }
}