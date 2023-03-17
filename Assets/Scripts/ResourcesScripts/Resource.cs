using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ResourcesEnum _resource;
    private const float _timeStepMining = 3;
    private const float _timeMining = 1;
    private const int _amountStepMining = 4;
    private int _step;
    private Vector3 _scaleInStep;
    private Coroutine _coroutine;
    private GameObject _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            _coroutine = StartCoroutine(MiningResource());
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventSystem.SendPlayerMining(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventSystem.SendPlayerMining(false);
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator MiningResource()
    {
        if (_scaleInStep == Vector3.zero)
        {
           _scaleInStep = transform.localScale / (_amountStepMining - 1);
        }
        
        while (_step < _amountStepMining)
        {
            yield return new WaitForSeconds(_timeStepMining);
            transform.DOScale(transform.localScale - _scaleInStep,_timeMining);
            DropItem();
            _step++;
        }
        DOTween.KillAll();
        _scaleInStep = Vector3.zero;
        _step = 0;
        StopCoroutine(_coroutine);
        gameObject.SetActive(false);
    }

    private void DropItem()
    {
        GameObject resourceItem = Instantiate((GameObject)Resources.Load("PrefabesResources/" + _resource + "Item"), GetComponentInParent<Transform>().position,
            new Quaternion());
        resourceItem.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(_player.transform.position.x - resourceItem.transform.position.x,50,_player.transform.position.z - resourceItem.transform.position.z),_player.transform.position);
    }
}
