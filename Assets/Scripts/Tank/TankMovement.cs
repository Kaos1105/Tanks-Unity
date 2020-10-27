using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;         
    public float m_Speed = 12f;            
    public float m_TurnSpeed = 180f;       
    public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;       
    public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f;
    private Transform chokePoint;
    private string m_MovementAxisName;     
    private string m_TurnAxisName;
    private string m_RotateAxisName;
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private float m_TurnInputValue;
    private float m_RotateInputValue;
    private float m_OriginalPitch;
    public Rigidbody turrerRigidbody;

    private void Awake()
    { 
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
        m_RotateInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
        m_RotateAxisName = "Rotate" + m_PlayerNumber;
        m_OriginalPitch = m_MovementAudio.pitch;
    }
    

    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        m_RotateInputValue = Input.GetAxis(m_RotateAxisName);
        EngineAudio();
    }


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
        if(Mathf.Abs(m_MovementInputValue)<0.1 && Mathf.Abs(m_TurnInputValue)<0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
                //Debug.Log(m_MovementAudio.pitch);
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
                //Debug.Log(m_MovementAudio.pitch);
            }

        }
    }


    private void FixedUpdate()
    {

        //Move();
        //if (m_MovementInputValue < 0)
        //{
        //    Turn(m_MovementInputValue);
        //}
        //else Turn();
        Turn();
        //Rotate();
    }
    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
    private void Turn()
    {
        Vector3 movement = Vector3.zero;
        if (m_MovementInputValue > 0)
        {
            movement += transform.forward * m_MovementInputValue;
            m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(0, 60, 0), m_TurnSpeed * Time.deltaTime);
        }
        else if (m_MovementInputValue < 0)
        {
            movement += transform.forward * -m_MovementInputValue;
           m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(0, 240, 0), m_TurnSpeed * Time.deltaTime);
        }
        if (m_TurnInputValue > 0)
        {
            movement += transform.forward * m_TurnInputValue;
            m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(0, 150, 0), m_TurnSpeed * Time.deltaTime);
        }
        else if (m_TurnInputValue < 0)
        {
            movement += transform.forward * -m_TurnInputValue;
            m_Rigidbody.rotation = Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.Euler(0, 340, 0), m_TurnSpeed * Time.deltaTime);
        }
        movement = Vector3.Normalize(movement) * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    //private void Turn(float direction = 0)
    //{
    //    float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
    //    if (direction < 0)
    //        turn *= -1;
    //    Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
    //    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    //}
    //private void Rotate()
    //{
    //    float turn = m_RotateInputValue * m_TurnSpeed*40 * Time.deltaTime;
    //    Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
    //    turrerRigidbody.MoveRotation(turrerRigidbody.rotation * turnRotation);
    //}
}