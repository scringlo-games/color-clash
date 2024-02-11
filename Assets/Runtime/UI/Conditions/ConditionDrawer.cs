using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using TMPro;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.Conditions
{
    public class ConditionDrawer : MonoBehaviour
    {
        [SerializeField]
        private ConditionBank bank;
        [SerializeField]
        [Tooltip("Should be a list of 3 indicators. 0 = Yellow, 1 = Red, 2 = Blue")]
        private List<GameObject> indicatorList;
        private int[] condStacks;

        private void Awake()
         {
             this.condStacks = new int[this.indicatorList.Count];
         }

        private void OnEnable()
        {
            this.bank.Applied += this.ConditionAdded;
            this.bank.Expired += this.ConditionRemoved;
        }

        private void OnDisable()
        {   
            this.bank.Applied -= this.ConditionAdded;
            this.bank.Expired -= this.ConditionRemoved;
        }
        private void ConditionAdded(Condition cond)
        {
            switch(cond)
            {
                case TakeDamageOnTickCondition:
                    this.condStacks[1]++;
                    this.indicatorList[1].SetActive(true);
                    this.indicatorList[1].GetComponentInChildren<TMP_Text>().text = this.condStacks[1].ToString();
                    break;
                case SlowMovementSpeedCondition:
                    this.condStacks[2]++;
                    this.indicatorList[2].SetActive(true);
                    this.indicatorList[2].GetComponentInChildren<TMP_Text>().text = this.condStacks[2].ToString();
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
                case TakeDamageOnTickCondition:
                this.condStacks[1] --;
                    if(this.condStacks[1] <= 0)
                    {
                        this.indicatorList[1].SetActive(false);
                    }
                    else
                    {
                        this.indicatorList[1].GetComponentInChildren<TMP_Text>().text = this.condStacks[1].ToString();
                    }
                    break;
                case SlowMovementSpeedCondition:
                this.condStacks[2] --;
                    if(this.condStacks[2] <= 0)
                    {
                        this.indicatorList[2].SetActive(false);
                    }
                    else
                    {
                        this.indicatorList[2].GetComponentInChildren<TMP_Text>().text = this.condStacks[2].ToString();
                    }
                    break;
            }
        }
    }
}
