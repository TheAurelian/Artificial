using UnityEngine;

namespace sergeyiwanski.effectspack
{
    public class AutoRotate : MonoBehaviour
    {
        public Vector3 speed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(speed);
        }
    }
}
