using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class OpenChest : Interactable
    {
        Animator animator;
        OpenChest openChest;
        public Transform playerStandingPosition;
        public GameObject itemSpawner;
        public WeaponItem itemInChest;
        public AudioSource openChestSound;

        private void Awake() 
        {
            animator = GetComponent<Animator>();
            openChest = GetComponent<OpenChest>();
        }

        private void Start() 
        {
            openChestSound.GetComponent<AudioSource>();    
        }

        public override void Interact(PlayerManager playerManager)
        {
           
            Vector3 rotatationDirection = transform.position - playerManager.transform.position;
            rotatationDirection.y = 0;
            rotatationDirection.Normalize();

            Quaternion tr = Quaternion.LookRotation(rotatationDirection);
            Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 300 * Time.deltaTime);
            playerManager.transform.rotation = targetRotation;

             Debug.Log("OpenChest");

             
            playerManager.OpenChestInteraction(playerStandingPosition);// tut

            animator.Play("Chest Open");
            openChestSound.Play();
            StartCoroutine(SpawnItemInChest());

            WeaponPickUp weaponPickUp = itemSpawner.GetComponent<WeaponPickUp>();

            if (weaponPickUp != null)
            {
                weaponPickUp.weapon = itemInChest;
            }
            
        }

        private IEnumerator SpawnItemInChest()
        {
            Debug.Log("spawn");
            yield return new WaitForSeconds(1f);
            Instantiate(itemSpawner, transform);
            Destroy(openChest);
        }
    }

}