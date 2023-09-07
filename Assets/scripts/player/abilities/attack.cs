using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] private GameObject attackObject; 
    [SerializeField] private float attackDuration;
    [SerializeField] private float timeBetweenAttacks;
    public bool canAttack = true; 
    private bool canAttackAgain = true; 
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack") && canAttack && canAttackAgain){
            StartCoroutine(attackCoroutine());
        }
    }
    IEnumerator attackCoroutine(){
        canAttackAgain = false;
        attackObject.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttackAgain = true;

    }
}
