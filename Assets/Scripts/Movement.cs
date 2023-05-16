using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] public float mainthrust;
    [SerializeField] public float rotationthrust;
    [SerializeField] AudioClip mainEngine;

    AudioSource audioSource;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainthrust * Time.deltaTime);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
        }else{
            audioSource.Stop();
        }
        
        
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            ApplyRotation(rotationthrust);
        }else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationthrust);
        }
    }

    void ApplyRotation(float rotationThisFrame){
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //freezing rotation so phisics system can take over
    }
}
