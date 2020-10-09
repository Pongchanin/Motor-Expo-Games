using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using Mirror;

public class lobby : NetworkLobbyManager
{
    // Start is called before the first frame update
    /*void Start()
    {
        MMstart();
        MMlistmatches();
    }

    void MMstart()
    {
        Debug.Log("@MMstart");
        this.StartMatchMaker();

    }

    void MMlistmatches()
    {
        Debug.Log("@MMlistmatch");
        this.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
    }

    public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        Debug.Log("@OnMatchList");
        base.OnMatchList(success, extendedInfo, matchList);

        if (!success)
            Debug.Log("list failed: " + extendedInfo);
        else
        {
            if (matchList.Count > 0)
            {
                Debug.Log("Successfully listed matches. 1st match: " + matchList[0]);
                MMjoinmatch(matchList[0]);
            }
            else
            {
                MMcreatematch();
            }
        }
    }

    void MMjoinmatch(MatchInfoSnapshot firstMatch)
    {
        Debug.Log("@MMstart");

        this.matchMaker.JoinMatch(firstMatch.networkId, "", NetworkManager.singleton.networkAddress, "", 0, 0, OnMatchJoined);
    }

    public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        Debug.Log("@OnMatchJoined");

        base.OnMatchJoined(success, extendedInfo, matchInfo);

        if (!success)
            Debug.Log("Failed to join match: " + extendedInfo);
        else
        {
            //Success
            Debug.Log("Successfully joined match: " + matchInfo.networkId);
        }
    }

    void MMcreatematch()
    {
        Debug.Log("@MMstart");
        this.matchMaker.CreateMatch("MM", 4, true, "", NetworkManager.singleton.networkAddress, "", 0, 0, OnMatchCreate);
    }

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        Debug.Log("@OnMatchCreate");
        base.OnMatchCreate(success, extendedInfo, matchInfo);

        if(!success)
            Debug.Log("failed to create match: " + matchInfo.networkId);
        else
        {
            Debug.Log("Successfully created match: " + matchInfo.networkId);
        }
    }
    */
}
