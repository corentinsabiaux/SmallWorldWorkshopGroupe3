using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board 
{
    public Board(){
        boardCases = new Dictionary<int, BoardCase>();
    }
    public Dictionary<int,BoardCase> boardCases {get;}

    public void AddCase(int pos, BoardCase c){

        boardCases.Add(pos,c);
    }

}
