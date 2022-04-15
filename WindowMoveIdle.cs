using DG.Tweening;
using UnityEngine;

namespace Iida
{
    public class WindowMoveIdle : MonoBehaviour
    {
        [SerializeField] private float durationTime = 1f;
        [SerializeField] private Vector3 targetPos = Vector3.up;
        [SerializeField] private Ease moveEase;
        private Tweener _tween;

        private void Start()
        {
            _tween = transform.DOMove(targetPos, durationTime)
                                .SetRelative(true)
                                .SetEase(moveEase)
                                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StopLoopMove()
        {
            _tween.Pause();
        }
    }
}
