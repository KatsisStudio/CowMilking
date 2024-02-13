using CowMilking.Character.Player;
using CowMilking.SO;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

namespace CowMilking.Questing
{
    public class QuestEvents : MonoBehaviour
    {
        public static QuestEvents Instance { private set; get; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(this);
            }
        }

        public delegate void CowMilked(CowInfo cowInfo);
        public static event CowMilked OnCowMilked;

        public void MilkedACow(CowInfo cowInfo)
        {
            if (OnCowMilked != null)
                OnCowMilked(cowInfo);
        }

        public delegate void AlienKilled(CowInfo cowInfo);
        public static event AlienKilled OnAlienKilled;

        public void KilledAnAlien(CowInfo cowInfo)
        {
            if (OnAlienKilled != null)
                OnAlienKilled(cowInfo);
        }
    }
}