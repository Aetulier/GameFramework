using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameName
{
    [Serializable]
    public abstract class TargetableObjectData : EntityData
    {
        [SerializeField]
        private int m_HP = 0;



        [SerializeField]
        private int m_MaxHP = 0;



        public TargetableObjectData(int entityId, int typeId)
            : base(entityId, typeId)
        {

        }
        /// <summary>
        /// 当前生命。
        /// </summary>
        public int HP
        {
            get
            {
                return m_HP;
            }
            set
            {
                m_HP = value;
            }
        }

        /// <summary>
        /// 最大生命。
        /// </summary>
        public int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
            set
            {
                m_MaxHP = value;
            }
        }



        /// <summary>
        /// 生命百分比。
        /// </summary>
        public float HPRatio
        {
            get
            {
                return MaxHP > 0 ? (float)HP / MaxHP : 0f;
            }
        }

    }

}
