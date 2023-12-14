using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RigidBodyPhys.Colliders.UI_Work
{
    public class CanvasElementReference : MonoBehaviour
    {
        private Transform textTransform;

        public void ShowAndScale()
        {
            CanvasUtttil.FadeCanvasGroup(gameObject, true);
            ScaleElement();
        }

        private void ScaleElement()
        {
            textTransform.localScale = new Vector3(1, 0.8f, 1);
            textTransform.DOScale(Vector3.one, 0.5f);
        }


        private void DisableCanvas()
        {
            CanvasUtttil.FadeCanvasGroup(gameObject, false);
            FindObjectOfType<CanvasUtttil>().ActivateNextCanvasElement();
        }
    }
}