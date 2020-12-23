
using UnityEngine;

namespace Assets.Script.Play_Game
{
    public class Human_Name_Follow : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        void Update()
        {
            transform.LookAt(cam.transform);
        }
    }
}
