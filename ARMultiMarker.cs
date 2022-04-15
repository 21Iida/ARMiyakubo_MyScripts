using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Iida
{
    //参考
    //https://qiita.com/OKsaiyowa/items/29504242ec74cb5dfb04
    public class ARMultiMarker : MonoBehaviour
    {
        [SerializeField] private GameObject historyModels;
        [SerializeField] private Transform[] arPoints;
        //qrPositionRootがhistoryModelsと分離されている理由
        //historyModelsは表示のためのもので、qrPositionRootは位置合わせのためのもの
        [SerializeField] private Transform qrPositionRoot;
        [SerializeField] private ARTrackedImageManager imageManager;
        private int _nowIndex = 0;
    
        private void Start()
        {
            historyModels.SetActive(false);
        }

        private void OnEnable()
        {
            imageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        private void OnDisable()
        {
            imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    
        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            //現在取ったものがその瞬間だけ入るもの
            foreach (var trackedImage in eventArgs.added)
            {
                UpdateTrackAR(trackedImage);
            }
            //過去に取ったものが全部入ってる場所(シーンを切り替えても残る)
            foreach (var trackedImage in eventArgs.updated)
            {
                UpdateTrackAR(trackedImage);
            }
        }
    
        private void UpdateTrackAR(ARTrackedImage trackedImage)
        {
        
            if (trackedImage.trackingState == TrackingState.None) return;
            if (trackedImage.trackingState != TrackingState.Tracking) return;

            switch (trackedImage.referenceImage.name)
            {
                case "ARMarker1":
                    ActiveAndPositionSet(trackedImage.transform,0);
                    break;
                case "ARMarker2":
                    ActiveAndPositionSet(trackedImage.transform,1);
                    break;
                case "QRDebug":
                    //後々あると便利
                    break;
                    //ActiveAndPositionSet(trackedImage.transform,3);
                    //break;
                default:
                    break;
            }
        }

        private void ActiveAndPositionSet(Transform trackedTrans,int qrIndex)
        {
            //モデルの表示
            historyModels.SetActive(true);
            
            //オブジェクトを指定した位置に合わせる
            historyModels.transform.SetParent(arPoints[qrIndex]);
            historyModels.transform.localPosition = Vector3.zero;
            historyModels.transform.localRotation = Quaternion.identity;
            
            //ワールドの中心をマーカーに合わせる
            qrPositionRoot.position = trackedTrans.position;
            //todo
            //看板は垂直に立てる予定
            //なので今回はeulerAngles.yを素直に使えばいいわけではない
            var localAxis = trackedTrans.right.normalized;
            var angle = 90;
            var fixedDegree = Quaternion.AngleAxis(angle, localAxis);
            var rot = fixedDegree * trackedTrans.rotation;
            qrPositionRoot.rotation = Quaternion.Euler(0,rot.eulerAngles.y,0);

            _nowIndex = qrIndex;
        }

        private void UpdateArPosition(Transform trackedTrans, int qrIndex)
        {
            var tPos = trackedTrans.position;
            arPoints[qrIndex].position = new Vector3(tPos.x, arPoints[qrIndex].position.y, tPos.z);
            arPoints[qrIndex].rotation = Quaternion.Euler(0,trackedTrans.rotation.eulerAngles.y,0);
        }
    }
}
