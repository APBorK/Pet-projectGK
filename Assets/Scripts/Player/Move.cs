using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject _pointLook;
    [SerializeField] private GameObject _pointGo;
    private const float _distantionHandler = 5;
    private NavMeshAgent _navMeshAgent;
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        EventSystem.OnMovePlayer += MovePlayer;
        EventSystem.OnStopPlayer += ActivePoint;
    }

    private void MovePlayer(float positionX,float positionZ)
    {
        if (positionX > _distantionHandler ||positionZ > _distantionHandler|| positionX < -_distantionHandler || positionZ < -_distantionHandler)
        {
            _pointLook.transform.localPosition = new Vector3(positionX,_pointLook.transform.localPosition.y,positionZ);
            _pointGo.transform.localPosition = new Vector3(_pointGo.transform.localPosition.x,_pointGo.transform.localPosition.y,1);
            transform.LookAt(_pointLook.transform);
            _navMeshAgent.SetDestination(_pointGo.transform.position);
        }
    }

    private void ActivePoint(bool active)
    {
        _pointLook.SetActive(!active);
        _pointGo.SetActive(!active);
    }
}
