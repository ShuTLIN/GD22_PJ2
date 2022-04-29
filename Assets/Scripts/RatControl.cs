using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RatControl : MonoBehaviour
{

    [SerializeField] private Transform m_NavTargetPos;
    private NavMeshAgent m_navMeshAgent;
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();

        if (!m_NavTargetPos) 
        {
            GameObject Pos=GameObject.Find("TargetPoint");
            m_NavTargetPos = Pos.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //m_navMeshAgent.SetDestination(m_NavTargetPos.position);
        m_navMeshAgent.destination = m_NavTargetPos.position;
        m_Animator.SetFloat("speed", m_navMeshAgent.velocity.magnitude);
        Debug.Log(m_navMeshAgent.velocity.magnitude);
    }
}
