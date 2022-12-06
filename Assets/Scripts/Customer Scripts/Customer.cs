using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMeshMovement), typeof(PathFollower))]
public class Customer : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public Movement movement;
    [SerializeField] public PathFollower pathFollower;

    [Header("Aesthetics")]
    [SerializeField] bool randomizeColor = false;
    [SerializeField] List<Material> colors;

    [Header("State Transitions")]
    public BoolRef walk;
    public BoolRef idle;

    public StateMachine stateMachine = new StateMachine();
    private GameObject dest;

    private void Awake()
    {
        if (randomizeColor) RandomizeMaterial(colors);
    }

    private void Start()
    {
        stateMachine.AddState(new IdleState(this, typeof(IdleState).Name));
        stateMachine.AddState(new PatrolState(this, typeof(PatrolState).Name));

        stateMachine.AddTransition(typeof(IdleState).Name, new Transition(new Condition[] { new BoolCondition(walk, true) }), typeof(PatrolState).Name);
        stateMachine.AddTransition(typeof(PatrolState).Name, new Transition(new Condition[] { new BoolCondition(idle, true) }), typeof(IdleState).Name);

        stateMachine.SetState(stateMachine.StateFromName(typeof(PatrolState).Name));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void RandomizeMaterial(List<Material> materials)
    {
        if (materials.Count > 0)
        {
            int random = Random.Range(0, materials.Count - 1);
            gameObject.GetComponent<MeshRenderer>().material = materials[random];
        }
    }

    private void OnGUI()
    {
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 300, 20), stateMachine.GetStateName());
    }
}