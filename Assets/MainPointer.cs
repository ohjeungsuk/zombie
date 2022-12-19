using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPointer : MonoBehaviour
{
    public Image loadingimg;
    public AudioClip[] gun;
    public int maxB;
    public TextMeshProUGUI Btext;

    private int nowB;
    private AudioSource _audioS;
    
    void Start()
    {
        maxB = 2;
        nowB = maxB;
        _audioS = GetComponent<AudioSource>();
        Btext.text = nowB + "/" + maxB;
        
    }

    
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position , transform.forward,out hit, 500f))
        {
            if(hit.collider.CompareTag("Zombie")&& nowB > 0)
            {
                loadingimg.fillAmount += 1.0f / 2 * Time.deltaTime;
                if(loadingimg.fillAmount == 1 )
                {
                    nowB--;
                    Btext.text = nowB + "/" + maxB;
                    _audioS.PlayOneShot(gun[0]);
                    hit.collider.GetComponent<Animator>().SetTrigger("Die");
                    hit.collider.GetComponent<ZombieMove>().Zspeed = 0;
                    hit.collider.GetComponent<CapsuleCollider>().radius = 0;
                    Destroy(hit.collider.gameObject, 2.0f);
                    loadingimg.fillAmount = 0;

                    if (nowB == 0) StartCoroutine(Reload());
                  }
            }
        }else
        {
            loadingimg.fillAmount = 0;
        }
    }

    IEnumerator Reload()
    {
        Btext.text = "Reloading.....";
        yield return new WaitForSeconds(1.8f);
        _audioS.PlayOneShot(gun[1]);                 
        nowB = maxB;
        Btext.text = nowB + "/ " + maxB;
            }

}
