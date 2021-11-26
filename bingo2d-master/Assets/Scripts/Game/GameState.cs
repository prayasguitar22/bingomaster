using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        public static int MyIndex;
        public static int CurrentTurn;
        public static bool IsOnline;
        public static int NumberOfPlayers;
        public static Player[] Players;
        public static List<int> AllPositions;
        public static bool GameFinished;
        public static Player Winner;
    }
}
