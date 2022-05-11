using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class TempChangeSkinPlayer : MonoBehaviour
    {
        PlayerManager player;
        public TempPlayerSkin tempPlayerSkin;
        
        void Awake()
        {
            player = GetComponent<PlayerManager>();

            player.playerInventoryManager.currentHelmetEquipment =  tempPlayerSkin.tempHelmetEquipment;
            player.playerInventoryManager.currentBodyEquipment =  tempPlayerSkin.tempBodyEquipment;
            player.playerInventoryManager.currentLegEquipment =  tempPlayerSkin.tempLegEquipment;
            player.playerInventoryManager.currentHandEquipment =  tempPlayerSkin.tempHandEquipment;

            player.playerStatsManager.healthLevel = tempPlayerSkin.healthLevel;
            player.playerStatsManager.focusLevel = tempPlayerSkin.focusLevel;
            player.playerStatsManager.staminaLevel = tempPlayerSkin.staminaLevel;
        }
    }
}
