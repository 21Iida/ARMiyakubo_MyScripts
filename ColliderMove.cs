using UnityEngine;

namespace Iida
{
    public class ColliderMove : MonoBehaviour
    {
        [SerializeField] private Transform playerOrigin;

        public void SetParentPlayer()
        {
            this.gameObject.transform.SetParent(playerOrigin);
        }
    }
}
