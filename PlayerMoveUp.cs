using UnityEngine;
using DG.Tweening;

namespace Iida
{
    public class PlayerMoveUp : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Transform upTarget;
        [SerializeField] private float takeTime = 1f;
        [SerializeField] private Ease moveEase;
        
        public void GoUp()
        {
            player.transform.DOMoveY(upTarget.position.y,takeTime).SetEase(moveEase);
        }
    }
}
