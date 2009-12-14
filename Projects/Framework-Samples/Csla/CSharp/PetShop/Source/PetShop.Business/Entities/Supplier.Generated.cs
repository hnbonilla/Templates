//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CSLA 3.7.X CodeSmith Templates.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Supplier.cs'.
//
//     Template path: EditableRoot.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region using declarations

using System;

using Csla;
using Csla.Data;
using Csla.Validation;

#endregion

namespace PetShop.Business
{
	[Serializable]
	public partial class Supplier : BusinessBase< Supplier >
	{
        #region Contructor(s)

		private Supplier()
		{ /* Require use of factory methods */ }
        
        internal Supplier(SafeDataReader reader)
        {
            Fetch(reader);
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
		
		#region Business Methods


		private static readonly PropertyInfo< int > _suppIdProperty = RegisterProperty< int >(p => p.SuppId);
		[System.ComponentModel.DataObjectField(true, false)]
		public int SuppId
		{
			get { return GetProperty(_suppIdProperty); }				
            set
            {
                SetProperty(_suppIdProperty, value);
            }
		}
		
		private static readonly PropertyInfo< string > _nameProperty = RegisterProperty< string >(p => p.Name);
		public string Name
		{
			get { return GetProperty(_nameProperty); }				
            set
            {
                SetProperty(_nameProperty, value);
            }
		}
		
		private static readonly PropertyInfo< string > _statusProperty = RegisterProperty< string >(p => p.Status);
		public string Status
		{
			get { return GetProperty(_statusProperty); }				
            set
            {
                SetProperty(_statusProperty, value);
            }
		}
		
		private static readonly PropertyInfo< string > _addr1Property = RegisterProperty< string >(p => p.Addr1);
		public string Addr1
		{
			get { return GetProperty(_addr1Property); }				
            set
            {
                SetProperty(_addr1Property, value);
            }
		}
		
		private static readonly PropertyInfo< string > _addr2Property = RegisterProperty< string >(p => p.Addr2);
		public string Addr2
		{
			get { return GetProperty(_addr2Property); }				
            set
            {
                SetProperty(_addr2Property, value);
            }
		}
		
		private static readonly PropertyInfo< string > _cityProperty = RegisterProperty< string >(p => p.City);
		public string City
		{
			get { return GetProperty(_cityProperty); }				
            set
            {
                SetProperty(_cityProperty, value);
            }
		}
		
		private static readonly PropertyInfo< string > _stateProperty = RegisterProperty< string >(p => p.State);
		public string State
		{
			get { return GetProperty(_stateProperty); }				
            set
            {
                SetProperty(_stateProperty, value);
            }
		}
		
		private static readonly PropertyInfo< string > _zipProperty = RegisterProperty< string >(p => p.Zip);
		public string Zip
		{
			get { return GetProperty(_zipProperty); }				
            set
            {
                SetProperty(_zipProperty, value);
            }
		}
		
		private static readonly PropertyInfo< string > _phoneProperty = RegisterProperty< string >(p => p.Phone);
		public string Phone
		{
			get { return GetProperty(_phoneProperty); }				
            set
            {
                SetProperty(_phoneProperty, value);
            }
		}
		
		private static readonly PropertyInfo< ItemList > _itemsProperty = RegisterProperty<ItemList>(p => p.Items, Csla.RelationshipTypes.LazyLoad);
		public ItemList Items
		{
			get
            {
                if(!FieldManager.FieldExists(_itemsProperty))
                    SetProperty(_itemsProperty, ItemList.GetBySupplier(SuppId));

                return GetProperty(_itemsProperty); 
            }
		}

		#endregion
		
		#region Factory Methods 
		
		public static Supplier NewSupplier()
		{
			return DataPortal.Create< Supplier >();
		}
		
		public static Supplier GetSupplier(int suppId)
		{
			return DataPortal.Fetch< Supplier >(
                new SupplierCriteria(suppId));
		}

        public static void DeleteSupplier(int suppId)
		{
                DataPortal.Delete(new SupplierCriteria(suppId));
		}

        #endregion
        
	}
}