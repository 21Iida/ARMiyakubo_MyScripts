using System;
using UnityEngine;

namespace Iida
{
    public class JitakuARStart : MonoBehaviour
    {
        [SerializeField] private Transform mainCamTransform;
        [SerializeField] private GameObject worlds;
        [SerializeField] private Vector3 instancePos;
        [SerializeField] private float scalarValue = 1f;
        [SerializeField] private GameObject startDownTextPanel,startUpTextPanel;
        
        private void Start()
        {
            if (PlayerAngleUp())
            {
                ModelHide();
                ActiveDownPanel();
            }
            else if (PlayerAngleDown())
            {
                ModelHide();
                ActiveUpPanel();
            }
            else
            {
                ModelActive();
            }
            Debug.Log(PlayerAngleUp());
        }

        private void Update()
        {
            if (worlds.activeInHierarchy) return;
            
            if (PlayerAngleUp())
            {
                ModelHide();
                ActiveDownPanel();
            }
            else if (PlayerAngleDown())
            {
                ModelHide();
                ActiveUpPanel();
            }

            if (!(PlayerAngleUp() || PlayerAngleDown()))
            {
                ModelActive();
            }
        }

        private bool PlayerAngleUp()
        {
            //Debug.Log("CamTransRotate" + mainCamTransform.forward);
            if (mainCamTransform.forward.y > -0.2f) return true;
            return false;
        }

        private bool PlayerAngleDown()
        {
            //Debug.Log("CamTransRotate" + mainCamTransform.forward);
            if (mainCamTransform.forward.y < -0.4f) return true;
            return false;
        }

        private void ModelActive()
        {
            var f = mainCamTransform.forward;
            var targetPos = new Vector3(f.x + instancePos.x, f.y + instancePos.y, f.z + instancePos.z);
            targetPos *= scalarValue;
            targetPos += mainCamTransform.position;
            worlds.transform.position = targetPos;
            
            

            worlds.SetActive(true);
            
            HideDownPanel();
            HideUpPanel();
        }

        private void ModelHide()
        {
            worlds.SetActive(false);
        }

        private void ActiveDownPanel()
        {
            startUpTextPanel.SetActive(false);
            startDownTextPanel.SetActive(true);
        }
        private void HideDownPanel()
        {
            startDownTextPanel.SetActive(false);
        }
        
        private void ActiveUpPanel()
        {
            startDownTextPanel.SetActive(false);
            startUpTextPanel.SetActive(true);
        }
        private void HideUpPanel()
        {
            startUpTextPanel.SetActive(false);
        }
    }
}
