using System;
using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel.Design;


namespace ScringloGames.ColorClash.Runtime
{
    public class ConditionDrawer : MonoBehaviour
    {
        [SerializeField] 
        ConditionBank bank;
        [SerializeField]
        [Tooltip("Should be a list of 3 indicators. 0 = Yellow, 1 = Red, 2 = Blue")]
        private List<GameObject> indicatorList;
        private int[] condStacks;
        void Awake()
         {
             condStacks = new int[indicatorList.Count];
         }
        void OnEnable()
        {
            bank.Applied += ConditionAdded;
            bank.Expired += ConditionRemoved;
        }
        void OnDisable()
        {   
            bank.Applied -= ConditionAdded;
            bank.Expired -= ConditionRemoved;
        }
        private void ConditionAdded(Condition cond)
        {
            switch(cond)
            {
                case AOECondition:
                    condStacks[0]++;
                    indicatorList[0].SetActive(true);
                    indicatorList[0].GetComponentInChildren<TMP_Text>().text = condStacks[0].ToString();
                    Debug.Log($"active yellow conditions: {condStacks[0]}");
                    break;
                case DOTCondition:
                    condStacks[1]++;
                    indicatorList[1].SetActive(true);
                    indicatorList[1].GetComponentInChildren<TMP_Text>().text = condStacks[1].ToString();
                    break;
                case SlowCondition:
                    condStacks[2]++;
                    indicatorList[2].SetActive(true);
                    indicatorList[2].GetComponentInChildren<TMP_Text>().text = condStacks[2].ToString();
                    break;
            }
        }

        public void BindTo(ConditionBank targetBank)
        {
            this.bank = targetBank; 
        }
        private void ConditionRemoved(Condition cond)
        {
            Debug.Log($"{cond} removed");
            switch(cond)
            {
                case AOECondition:
                    condStacks[0] --;
                    if(condStacks[0] <= 0)
                    {
                        indicatorList[0].SetActive(false);
                    }
                    else
                    {
                        indicatorList[0].GetComponentInChildren<TMP_Text>().text = condStacks[0].ToString();
                    }
                    break;
                case DOTCondition:
                condStacks[1] --;
                    if(condStacks[1] <= 0)
                    {
                        indicatorList[1].SetActive(false);
                    }
                    else
                    {
                        indicatorList[1].GetComponentInChildren<TMP_Text>().text = condStacks[1].ToString();
                    }
                    break;
                case SlowCondition:
                condStacks[2] --;
                    if(condStacks[2] <= 0)
                    {
                        indicatorList[2].SetActive(false);
                    }
                    else
                    {
                        indicatorList[2].GetComponentInChildren<TMP_Text>().text = condStacks[2].ToString();
                    }
                    break;
                
            }
        }
    }
}
