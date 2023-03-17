using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ResourcesItem : MonoBehaviour
{
   [SerializeField] private ResourcesEnum _resource;
   private int _indexLog;
   private bool _upItem;

   private void Start()
   {
      for (int i = 0; i < HUDResources.instance.ResourceLog.Count; i++)
      {
         if (HUDResources.instance.ResourceLog[i].name == _resource.ToString())
         {
            _indexLog = i;
         }
      }
   }

   private async void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.tag == "Land")
      {
         await Task.Delay(2000);
         _upItem = true;
      }
      
      if (other.gameObject.tag == "Player" && _upItem)
      {
         Destroy(GetComponent<Rigidbody>());
         GetComponent<Collider>().isTrigger = true;
         transform.DOScale(Vector3.zero, 0.5f);
         transform.DOMove(HUDResources.instance.ResourceLog[_indexLog].transform.position,0.5f);
         await Task.Delay(500);
         DOTween.KillAll();
         Destroy(gameObject);
      }
   }
}
