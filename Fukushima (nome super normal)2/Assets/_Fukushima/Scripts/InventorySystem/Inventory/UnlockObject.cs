using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class UnlockObject : InteractableBase
{
    [Header("Acoes")]
    public bool hasKey;



    public ItemObject item;

    private bool loop;

    //Animator anim; //gambiarra rapida
    //public bool hasAnimator; //gambiarra rapida
    //public GameObject final; //gambiarra rapida

    private void Start()
    {
        //if (hasAnimator) anim = gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        
    }

    public override void OnInteract()
    {
    
        if (item.hasObjectItem)
        {
            if (base.HasMission && !loop)
            {
                GameObject obj = GameObject.Find("Mission Controller");
                obj.GetComponent<MissionContoller>().MissaoCompleta();
                loop = false;
            }

            //if(hasAnimator)//gambiarra rapida
            //{
            //    anim.SetTrigger("AtivarAnim");//gambiarra rapida
            //    final.SetActive(true);//gambiarra rapida

            //}
            //else//gambiarra rapida
            //{
            //    Destroy(gameObject);//gambiarra rapida

            //}
        }
        else
        {
            base.Without();
        }

    
    }

}
