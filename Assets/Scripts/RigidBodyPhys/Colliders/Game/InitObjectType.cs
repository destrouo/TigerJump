using UnityEngine;

namespace RigidBodyPhys.Colliders.Game
{
    public class InitObjectType : Appps
    {
        public void Initialize()
        {
            UniWebView.SetAllowInlinePlay(true);

            var qefoafpfl = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (var dohse in qefoafpfl)
            {
                dohse.Stop();
            }

            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}