using UnityEngine;

namespace Iida
{
    public class SwitchHistoryModel : MonoBehaviour
    {
        [SerializeField] private GameObject naraPrefab, kamakuraPrefab, gendaiPrefab;

        public void ActiveNara()
        {
            AllHideHistory();
            naraPrefab.SetActive(true);
        }
        public void ActiveKamakura()
        {
            AllHideHistory();
            kamakuraPrefab.SetActive(true);
        }
        public void ActiveGendai()
        {
            AllHideHistory();
            gendaiPrefab.SetActive(true);
        }

        private void AllHideHistory()
        {
            naraPrefab.SetActive(false);
            kamakuraPrefab.SetActive(false);
            gendaiPrefab.SetActive(false);
        }
    }
}
