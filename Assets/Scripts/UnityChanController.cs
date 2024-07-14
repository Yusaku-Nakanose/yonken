using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションをつけて動かすための準備
    private Animator anim;
    //音を鳴らすための準備
    AudioSource audioSource;
    public AudioClip jumpsound; //ジャンプの時の音
    public AudioClip runningsound; //走っている間の音
    // Start is called before the first frame update
    void Start()
    {
        //音を鳴らす準備その2
        audioSource = GetComponent<AudioSource>();
        //用意されているアニメーションをとってくる
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //FixedUpadate = 一定時間ごと、Update = 毎フレーム、らしい
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.SetBool("Jump", false);
        Vector3 vector = new Vector3(0, 0, v);
        vector = transform.TransformDirection(vector) * 5f;
        transform.localPosition += vector * Time.fixedDeltaTime;
        transform.Rotate(0, h, 0);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up);
            anim.SetBool("Jump", true);
            audioSource.PlayOneShot(jumpsound);
        }
        
        
    }
}
