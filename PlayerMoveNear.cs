using DG.Tweening;
using UnityEngine;

namespace Iida
{
    public class PlayerMoveNear : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Transform nearTarget;
        [SerializeField] private float takeTime = 1f;
        [SerializeField] private Ease moveEase;
        
        public void GoNear()
        {
            player.transform.DOMove(nearTarget.position,takeTime).SetEase(moveEase);
        }
    }
}
