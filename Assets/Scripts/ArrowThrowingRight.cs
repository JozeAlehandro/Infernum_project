using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowThrowingRight : MonoBehaviour
{
    public GameObject arrow, SpawnArrow;
    public float startDelay, repeatRate;
    public AudioClip arrowSound;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        Vector3 pos = new Vector3(SpawnArrow.transform.position.x, SpawnArrow.transform.position.y);
        Instantiate(arrow, pos, gameObject.transform.rotation);
        AudioSource.PlayClipAtPoint(arrowSound, gameObject.transform.position, volumeSlider.value);
    }  
}
