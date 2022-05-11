using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyWeaponSlotManager : CharacterWeaponSlotManager
    {
        public WeaponItem rightHandWeapon;
        public WeaponItem leftHandWeapon;

        public AudioSource attackSound;

        private void Awake() 
        {
            LoadWeaponHolderSlots();
        }

        private void Start() 
        {
            LoadWeaponsOnBothHands();
            attackSound.GetComponent<AudioSource>();
        }

        private void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.currentWeapon = weapon;
                leftHandSlot.LoadWeaponModel(weapon);
                LoadWeaponDamageCollider(true);
            }
            else
            {
               rightHandSlot.currentWeapon = weapon;
               rightHandSlot.LoadWeaponModel(weapon);
                LoadWeaponDamageCollider(false);
            }
        }

        private void LoadWeaponHolderSlots()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if(weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if(weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        private void LoadWeaponsOnBothHands()
        {
            if (rightHandWeapon != null)
            {
                LoadWeaponOnSlot(rightHandWeapon, false);
            }

            if (leftHandWeapon != null)
            {
                LoadWeaponOnSlot(leftHandWeapon, true);
            }
        }

        public void LoadWeaponDamageCollider(bool isLeft)
        {
            if (isLeft)
            {
                leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
                leftHandDamageCollider.characterManager = GetComponentInParent<CharacterManager>();
            }
            else
            {
                rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
                rightHandDamageCollider.characterManager = GetComponentInParent<CharacterManager>();
            }
        }

        public void OpenDamageCollider()
        {
            attackSound.Play();
            rightHandDamageCollider.EnableDamageColider();
        }

        public void CloseDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }
        
        public void DrainStaminaLightAttack()
        {

        }

        public void DrainStaminaHeavyAttack()
        {

        }

        public void EnableCombo()
        {
            // animator.SetBool("canDoCombo", true);
        }
        public void DisableCombo()
        {
            // animator.SetBool("canDoCombo", false);
        }
    }
}