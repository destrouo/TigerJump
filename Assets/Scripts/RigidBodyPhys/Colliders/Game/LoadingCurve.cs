using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace RigidBodyPhys.Colliders.Game
{
    public class LoadingCurve : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void Awake()
        {
            dotTweenSmooothAnim();
        }

        private void dotTweenSmooothAnim()
        {
            Sequence Smooooooth = DOTween.Sequence();
            Smooooooth.Append(_image.DOFillAmount(0.4f, 3f));
            Smooooooth.Append(_image.DOFillAmount(0.4f, 1.2f));
            Smooooooth.Append(_image.DOFillAmount(0.65f, 0.3f));
            Smooooooth.Append(_image.DOFillAmount(0.8f, 1.2f));
            Smooooooth.Append(_image.DOFillAmount(1f, 0.8f));
        }
    }
}