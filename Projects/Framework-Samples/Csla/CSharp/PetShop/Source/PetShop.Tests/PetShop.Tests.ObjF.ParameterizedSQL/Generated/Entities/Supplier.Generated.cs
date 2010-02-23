﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1413, CSLA Framework: v3.8.2.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Supplier.cs'.
//
//     Template path: EditableRoot.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Data;
using Csla.Validation;

#endregion

namespace PetShop.Tests.ObjF.ParameterizedSQL
{
    [Serializable]
    [Csla.Server.ObjectFactory(FactoryNames.SupplierFactoryName)]
    public partial class Supplier : BusinessBase< Supplier >
    {
        #region Contructor(s)

        private Supplier()
        { /* Require use of factory methods */ }

        internal Supplier(System.Int32 suppId)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_suppIdProperty, suppId);
            }
        }
        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            if(AddBusinessValidationRules())
                return;

            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_nameProperty, 80));
            ValidationRules.AddRule(CommonRules.StringRequired, _statusProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_statusProperty, 2));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_addr1Property, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_addr2Property, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_cityProperty, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_stateProperty, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_zipProperty, 5));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_phoneProperty, 40));
        }

        #endregion

        #region Properties

        private static readonly PropertyInfo< System.Int32 > _suppIdProperty = RegisterProperty< System.Int32 >(p => p.SuppId);
		[System.ComponentModel.DataObjectField(true, false)]
        public System.Int32 SuppId
        {
            get { return GetProperty(_suppIdProperty); }
            set{ SetProperty(_suppIdProperty, value); }
        }

        private static readonly PropertyInfo< System.Int32 > _originalSuppIdProperty = RegisterProperty< System.Int32 >(p => p.OriginalSuppId);
        /// <summary>
        /// Holds the original value for SuppId. This is used for non identity primary keys.
        /// </summary>
        internal System.Int32 OriginalSuppId
        {
            get { return GetProperty(_originalSuppIdProperty); }
            set{ SetProperty(_originalSuppIdProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _nameProperty = RegisterProperty< System.String >(p => p.Name);
        public System.String Name
        {
            get { return GetProperty(_nameProperty); }
            set{ SetProperty(_nameProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _statusProperty = RegisterProperty< System.String >(p => p.Status);
        public System.String Status
        {
            get { return GetProperty(_statusProperty); }
            set{ SetProperty(_statusProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _addr1Property = RegisterProperty< System.String >(p => p.Addr1);
        public System.String Addr1
        {
            get { return GetProperty(_addr1Property); }
            set{ SetProperty(_addr1Property, value); }
        }

        private static readonly PropertyInfo< System.String > _addr2Property = RegisterProperty< System.String >(p => p.Addr2);
        public System.String Addr2
        {
            get { return GetProperty(_addr2Property); }
            set{ SetProperty(_addr2Property, value); }
        }

        private static readonly PropertyInfo< System.String > _cityProperty = RegisterProperty< System.String >(p => p.City);
        public System.String City
        {
            get { return GetProperty(_cityProperty); }
            set{ SetProperty(_cityProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _stateProperty = RegisterProperty< System.String >(p => p.State);
        public System.String State
        {
            get { return GetProperty(_stateProperty); }
            set{ SetProperty(_stateProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _zipProperty = RegisterProperty< System.String >(p => p.Zip);
        public System.String Zip
        {
            get { return GetProperty(_zipProperty); }
            set{ SetProperty(_zipProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _phoneProperty = RegisterProperty< System.String >(p => p.Phone);
        public System.String Phone
        {
            get { return GetProperty(_phoneProperty); }
            set{ SetProperty(_phoneProperty, value); }
        }



        //AssociatedOneToMany
        private static readonly PropertyInfo< ItemList > _itemsProperty = RegisterProperty<ItemList>(p => p.Items, Csla.RelationshipTypes.Child);
        public ItemList Items
        {
            get
            {
                if(!FieldManager.FieldExists(_itemsProperty))
                {
                    if(IsNew || !PetShop.Tests.ObjF.ParameterizedSQL.ItemList.Exists(new PetShop.Tests.ObjF.ParameterizedSQL.ItemCriteria {Supplier = SuppId}))
                        LoadProperty(_itemsProperty, PetShop.Tests.ObjF.ParameterizedSQL.ItemList.NewList());
                    else
                        LoadProperty(_itemsProperty, PetShop.Tests.ObjF.ParameterizedSQL.ItemList.GetBySupplier(SuppId));
                }

                return GetProperty(_itemsProperty);
            }
        }

        #endregion

        #region Factory Methods 

        public static Supplier NewSupplier()
        {
            return DataPortal.Create< Supplier >();
        }

        public static Supplier GetBySuppId(System.Int32 suppId)
        {
            return DataPortal.Fetch< Supplier >(
                new SupplierCriteria {SuppId = suppId});
        }

        public static void DeleteSupplier(System.Int32 suppId)
        {
            DataPortal.Delete(new SupplierCriteria {SuppId = suppId});
        }

        #endregion

        #region Exists Command

        public static bool Exists(SupplierCriteria criteria)
        {
            return ExistsCommand.Execute(criteria);
        }

        #endregion

        #region Overridden properties

        /// <summary>
        /// Returns true if the business object or any of its children properties are dirty.
        /// </summary>
        public override bool IsDirty
        {
            get
            {
                if (base.IsDirty) return true;
                if (FieldManager.FieldExists(_itemsProperty) && Items.IsDirty) return true;

                return false;
            }
        }

        #endregion


    }
}