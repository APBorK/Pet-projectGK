using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorResourse : MonoBehaviour
{
    //Важно чтобы при использовании скрипта прифабы в ресурсах были выключены!!!
    [SerializeField] private ResourcesEnum _name;
    [SerializeField] int _countBot; 
    private float _range; 
    private float _minTime = 0.1f; 
    private float _maxTime = 1f; 
    private Queue<GameObject> _resourse = new Queue<GameObject>();
    private Vector3 _startScale;
    private void Start() 
    { 
        _range = GetComponent<BoxCollider>().size.x;
        RecordListResourse(); 
        StartCoroutine(TimerSpawn()); 
    }
    private void RecordListResourse() 
    { 
        for (int i = 0; i < _countBot; i++)
        {
            GameObject resourse =
                Instantiate((GameObject)Resources.Load("PrefabesResources/" + _name),
                    transform);
            _startScale = resourse.transform.localScale;
            _resourse.Enqueue(resourse); 
        } 
    }
    private IEnumerator TimerSpawn() 
    { 
        while (true) 
        { 
            float randomTime = Random.Range(_minTime,_maxTime); 
            yield return new WaitForSeconds(randomTime); 
            SpawnActivityResource(Random.Range(1,_countBot)); 
        } 
    }
    
    private void SpawnActivityResource(int count) 
    { 
        for (int i = 0; i < count; i++) 
        { 
            Vector3 position = new Vector3(Random.Range(-_range,_range),transform.position.y,
                Random.Range(-_range,_range)); 
            GameObject resourse = _resourse.Dequeue(); 
            if (resourse.activeSelf == false) 
            { 
                Debug.Log(position);
                resourse.SetActive(true);
                resourse.transform.localPosition = position;
                resourse.transform.localScale = _startScale;
            }
            else if (count < _countBot) 
            { 
                count++; 
            } 
            _resourse.Enqueue(resourse); 
        } 
    }
}
