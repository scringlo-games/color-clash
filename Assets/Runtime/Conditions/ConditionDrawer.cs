using System;
using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace ScringloGames.ColorClash.Runtime
{
    public class ConditionDrawer : MonoBehaviour
    {
        [SerializeField] 
        ConditionBank bank;
        [SerializeField]
        [Tooltip("Should be a list of 3 indicators. 0 = Yellow, 1 = Red, 2 = Blue")]
         private List<GameObject> indicatorList;
        private Dictionary<Condition,int> condStacks;
        void Awake()
        {
            condStacks = new Dictionary<Condition,int>();
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
                case AOECondition cond1:
                    if(condStacks.TryGetValue(cond1, out var value))
                    {
                        value++;
                        indicatorList[0].SetActive(true);
                        indicatorList[0].GetComponent<TextMeshPro>().text = value.ToString();
                    }
                    else
                    {
                        condStacks.Add(cond1,1);
                        indicatorList[0].SetActive(true);
                        indicatorList[0].GetComponent<TextMeshPro>().text = value.ToString();
                    }
                    break;
                

            }
        }

        public void BindTo(ConditionBank targetBank)
        {
            this.bank = targetBank; 
        }
        private void ConditionRemoved(Condition cond)
        {

        }
    }
}
