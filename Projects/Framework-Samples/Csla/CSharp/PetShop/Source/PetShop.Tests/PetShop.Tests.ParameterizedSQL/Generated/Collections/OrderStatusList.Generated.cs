//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'OrderStatusList.cs'.
//
//     Template: EditableRootList.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Tests.ParameterizedSQL
{
    [Serializable]
    public partial class OrderStatusList : BusinessListBase< OrderStatusList, OrderStatus >
    {    
        #region Contructor(s)
        
        private OrderStatusList()
        { 
            AllowNew = true;
        }
        
        #endregion

        #region Factory Methods 
        
        public static OrderStatusList NewList()
        {
            return DataPortal.Create< OrderStatusList >();
        }

        public static OrderStatusList GetByOrderIdLineNum(System.Int32 orderId, System.Int32 lineNum)
        {
            return DataPortal.Fetch< OrderStatusList >(
                new OrderStatusCriteria{OrderId = orderId, LineNum = lineNum});
        }

        public static OrderStatusList GetByOrderId(System.Int32 orderId)
        {
            return DataPortal.Fetch< OrderStatusList >(
                new OrderStatusCriteria{OrderId = orderId});
        }

        public static OrderStatusList GetAll()
        {
            return DataPortal.Fetch< OrderStatusList >(new OrderStatusCriteria());
        }

        #endregion

        #region Properties
        
        protected override object AddNewCore()
        {
            OrderStatus item = PetShop.Tests.ParameterizedSQL.OrderStatus.NewOrderStatus();
            Add(item);
            return item;
        }
        
        #endregion

        #region Exists Command

        public static bool Exists(OrderStatusCriteria criteria)
        {
            return PetShop.Tests.ParameterizedSQL.OrderStatus.Exists(criteria);
        }

        #endregion
    }
}