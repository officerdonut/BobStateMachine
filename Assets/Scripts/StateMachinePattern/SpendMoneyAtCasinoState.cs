﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendMoneyAtCasinoState : IState
{
    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() == Location.Casino) return;
        Debug.Log("Time to spend some of my hard-earned cash.");
        player.SetLocation(Location.Restaurant);
    }

    public void Update(Player player)
    {
        if (player.WinMoney())
        {
            player.AddToGoldCarried(3);
            Debug.Log("w00t. time to cash out");
            player.ChangeState(new VisitBankAndDepositGoldState());
        }

        else
        {
            player.SetGoldCarried(0);
            Debug.Log("Dangit, now my moneys gone. Only got " + player.GetMoneyInBank() + " nugz");
            player.ChangeState(new GoHomeAndSleepTilRestedState());
        }
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Leavin' casino");
    }
}
