using System;
using UnityEngine;

namespace Triconomy.UI
{
    [Serializable]
    public class UIView : MonoBehaviour
    {
        [SerializeField]
        private UIStack uiStack;

        public UIStack UIStack
        {
            get
            {
                return uiStack;
            }
            set
            {
                uiStack = value;
            }
        }
    }
}
