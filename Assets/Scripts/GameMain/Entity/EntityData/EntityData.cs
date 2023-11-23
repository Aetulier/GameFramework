using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameMain
{
    [Serializable]
    public abstract class EntityData
    {
        private int m_Id = 0;

        private int m_TypeId = 0;

        private Vector3 m_Position = Vector3.zero;


        public EntityData(int entityId,int typeId)
        {
            m_Id = entityId;
            m_TypeId = typeId;
        }

        ///<summary>
        /// 实体编号
        /// </summary>
        public int Id
        {
            get
            {
                return m_Id;
            }
        }

        ///<summary>
        /// 实体类型编号
        /// </summary> 
        public int TypeId
        {
            get
            {
                return m_TypeId;
            }
        }
        ///<summary>
        ///实体位置
        ///</summary>
        public Vector3 Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
            }
        }
        /////<summary>
        /////实体旋转
        /////</summary>
        //public Quaternion Rotation
        //{
        //    get
        //    {
        //        return m_Rotation;
        //    }
        //    set
        //    {
        //        m_Rotation = value;
        //    }
        //}

        
    }
}

