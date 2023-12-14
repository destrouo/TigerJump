using UnityEngine;

namespace RigidBodyPhys.Colliders.Game
{
    public class Appps:MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}