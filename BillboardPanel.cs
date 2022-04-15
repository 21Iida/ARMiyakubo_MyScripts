using UnityEngine;

namespace Iida
{
    public class BillboardPanel : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private void Update()
        {
            transform.LookAt(player.transform.position);
        }
    }
}
