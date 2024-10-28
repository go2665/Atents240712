using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test13_EnemyHitAndAttack : TestBase
{
    private void Start()
    {
        Player player = GameManager.Instance.Player;
        player.InventoryData.AddItem(ItemCode.IronSword);   // 칼 추가
        player.PlayerInventory.EquipItem(EquipType.Weapon, player.InventoryData[0]);    // 추가한 칼 장비

        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.ToggleMoveMode();  // 걷기 모드로 변경
    }
}
