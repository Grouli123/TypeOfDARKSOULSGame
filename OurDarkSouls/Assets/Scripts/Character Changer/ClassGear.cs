using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [System.Serializable]
    public class ClassGear
    {
        [Header("Class Name")]
        public string className;

        [Header("Weapons")]
        public WeaponItem primaryWeapon;
        public WeaponItem offHandWeapon;

        [Header("Armor")]
        public HelmetEquipment helmetEquipment;
        public BodyEquipment bodyEquipment;
        public LegEquipment legEquipment;
        public HandEquipment handEquipment;
    }
}
