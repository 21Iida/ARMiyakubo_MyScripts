using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Iida
{
    public class ToggleSelect : MonoBehaviour
    {
        [SerializeField] private List<Toggle> toggles;
        private Queue<Toggle> _selected = new Queue<Toggle>();

        private void Start()
        {
            foreach (var t in toggles)
            {
                if(t.isOn) _selected.Enqueue(t);
            }
        }

        public void Selected(Toggle myToggle)
        {
            //オンなら2つだけオンになるように
            if (myToggle.isOn)
            {
                ToggleOn(myToggle);
            }
            //オフならQueueから自分を消しておく
            else
            {
                ToggleOff(myToggle);
            }
        }

        private void ToggleOn(Toggle myToggle)
        {
            if (_selected.Any(s => s == myToggle)) return;
            _selected.Enqueue(myToggle);
            
            //3つ以上トグルがオンになりそうなときのみ続行
            if (_selected.Count < 3) return;
            
            var unCheck = _selected.Dequeue();
            unCheck.isOn = false;
        }

        private void ToggleOff(Toggle myToggle)
        {
            if (_selected.All(s => s != myToggle)) return;
            
            _selected.Clear();
            foreach (var t in toggles)
            {
                if(t.isOn) _selected.Enqueue(t);
            }
        }
        
        //3D表示の負荷を見て追加実装する
        //もし切り替えが極端に重ければこれでインターバルを設ける
        private void ToggleInterval()
        {
            foreach (var t in toggles)
            {
                t.interactable = false;
            }
            //ここにディレイ処理
            foreach (var t in toggles)
            {
                t.interactable = true;
            }

        }
    }
}
