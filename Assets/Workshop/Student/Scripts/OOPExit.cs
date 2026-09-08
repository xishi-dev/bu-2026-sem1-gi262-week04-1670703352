using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{
    public class OOPExit : Identity
    {
        public GameObject YouWin;
        // กำหนดชื่อไอเท็มและจำนวนที่ต้องการใช้ในการเปิดทางออก

        public string requiredItem = "Key";
        public int requiredAmount = 2;

        public override bool Hit()
        {
            // ตรวจสอบว่าผู้เล่นมีไอเท็มที่ต้องการหรือไม่
            if (mapGenerator.player.inventory.HasItem(requiredItem, requiredAmount))
            {
                YouWin.SetActive(true);
                Debug.Log("You win");
            }
            else
            {
                int currentAmount = mapGenerator.player.inventory.GetItemCount(requiredItem);

                Debug.Log(
                    "You need " + requiredAmount + " " + requiredItem +
                    ". You have " + currentAmount + "."
                );
            }

            return true;
        }
    }
}