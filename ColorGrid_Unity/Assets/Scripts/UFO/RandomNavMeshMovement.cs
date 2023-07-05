using UnityEngine;
using UnityEngine.AI;

namespace UFO
{
    public class RandomNavMeshMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private readonly float _radius = 5f;
        
        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (_navMeshAgent.velocity == new Vector3(0, 0, 0))
            {
                AssignTargetPosition();
            }
            
            transform.position = _navMeshAgent.nextPosition;
        }
        
        void AssignTargetPosition()
        {
            Vector3 randomPosition = Grid.Grid.Instance.GetRandomPositionInGrid();
            randomPosition.y = 0;
            Vector3 targetPosition = transform.position + randomPosition;

            if(NavMesh.SamplePosition(targetPosition, out NavMeshHit navMeshHit, _radius, 1))
            {
                _navMeshAgent.SetDestination(navMeshHit.position);
            }
        }
    }
}
