using Unity.Advertisement.IosSupport;
using UnityEngine;

namespace RigidBodyPhys.Colliders.ResourceHunt
{
    public class IDFAController : MonoBehaviour
    {
        private ATTrackingStatusBinding.AuthorizationTrackingStatus authorizedStatus =
            ATTrackingStatusBinding.AuthorizationTrackingStatus.AUTHORIZED;

        private ATTrackingStatusBinding.AuthorizationTrackingStatus notDeterminedStatus =
            ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED;

        public string RetrieveAdvertisingID()
        {
            string advertisingID = "";
#if UNITY_IOS
            ATTrackingStatusBinding.AuthorizationTrackingStatus currentStatus =
                ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
            if (currentStatus != authorizedStatus)
            {
                advertisingID = $"{currentStatus}";
            }
            else
            {
                Application.RequestAdvertisingIdentifierAsync((idfa, _, _) => { advertisingID = idfa; });
            }
#endif
            return advertisingID;
        }

        public void ExamineIDFA()
        {
#if UNITY_IOS
            ATTrackingStatusBinding.AuthorizationTrackingStatus currentStatus =
                ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
            if (currentStatus != notDeterminedStatus)
            {
                return;
            }

            ATTrackingStatusBinding.RequestAuthorizationTracking();
#endif
        }
    }
}