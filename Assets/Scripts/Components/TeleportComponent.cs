using UnityEngine;

namespace Components
{
    public class TeleportComponent : MonoBehaviour
    {
        private Vector3 _newPosition;

        public void TeleportObject(GameObject gameObject)
        {
            RemoveBulletTarget();

            var characterController = gameObject.GetComponent<CharacterController>();
            characterController.enabled = false;

            gameObject.transform.position = _newPosition;

            characterController.enabled = true;
        }

        private void RemoveBulletTarget()
        {
            FollowComponent[] followComponents = FindObjectsOfType<FollowComponent>();
            foreach (FollowComponent followComponent in followComponents)
            {
                if (!followComponent.CompareTag("Enemy"))
                {
                    followComponent.Follow = false;
                }
            }
        }

        //Попробуем записать позиции врагов, условные квадраты вокруг позиции врагов?
        
        // {
        //     Vector3 positions = Vector3.zero;
        //     GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //     foreach (GameObject gameObject in gameObjects)
        //     {
        //     }
        // }
    }
}