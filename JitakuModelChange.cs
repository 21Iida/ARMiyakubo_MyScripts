using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Iida
{
    public class JitakuModelChange : MonoBehaviour
    {
        [SerializeField] private List<Toggle> toggles;
        private bool _toggleCash = false;
        [SerializeField] private List<GameObject> models;

        private void Start()
        {
            if (toggles.Count != models.Count)
            {
                Debug.LogError("トグルとモデルの対応を1:1にしてください");
            }
            
            ModelUpdate();

            foreach (var t in toggles)
            {
                t.onValueChanged.AddListener(CashUpdate);
            }
        }

        private void Update()
        {
            if (!_toggleCash) return;
            ModelUpdate();
            _toggleCash = false;
        }

        private void CashUpdate(bool state)
        {
            _toggleCash = true;
        }

        private void ModelUpdate()
        {
            for (var i = 0; i < toggles.Count; i++)
            {
                if (toggles[i].isOn) ModelActive(i);
                else ModelHide(i);
            }
        }
        private void ModelActive(int index)
        {
            models[index].SetActive(true);
        }
        private void ModelHide(int index)
        {
            models[index].SetActive(false);
        }
    }
}
