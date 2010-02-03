//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Item.cs'.
//
//     Template: Criteria.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Csla;

#endregion

namespace PetShop.Tests.StoredProcedures
{
    [Serializable]
    public partial class ItemCriteria : CriteriaBase, IGeneratedCriteria
    {
        #region Private Read-Only Members
        
        private readonly Dictionary<string, object> _bag = new Dictionary<string, object>();
        
        #endregion
        
        #region Constructors

        public ItemCriteria() : base(typeof(Item)){}

        public ItemCriteria(System.String itemId) : base(typeof(Item))
        {
            ItemId = itemId;
        }

        
        #endregion
        
        #region Public Properties
        
        #region Read-Write

        public System.String ItemId
        {
            get { return GetValue< System.String >("ItemId"); }
            set { _bag["ItemId"] = value; }
        }

        public System.String ProductId
        {
            get { return GetValue< System.String >("ProductId"); }
            set { _bag["ProductId"] = value; }
        }

        public System.Decimal? ListPrice
        {
            get { return GetValue< System.Decimal? >("ListPrice"); }
            set { _bag["ListPrice"] = value; }
        }

        public System.Decimal? UnitCost
        {
            get { return GetValue< System.Decimal? >("UnitCost"); }
            set { _bag["UnitCost"] = value; }
        }

        public System.Int32? Supplier
        {
            get { return GetValue< System.Int32? >("Supplier"); }
            set { _bag["Supplier"] = value; }
        }

        public System.String Status
        {
            get { return GetValue< System.String >("Status"); }
            set { _bag["Status"] = value; }
        }

        public System.String Name
        {
            get { return GetValue< System.String >("Name"); }
            set { _bag["Name"] = value; }
        }

        public System.String Image
        {
            get { return GetValue< System.String >("Image"); }
            set { _bag["Image"] = value; }
        }

        #endregion
        
        #region Read-Only

        /// <summary>
        /// Returns a list of all the modified properties and values.
        /// </summary>
        public Dictionary<string, object> StateBag
        {
            get
            {
                return _bag;
            }
        }

        /// <summary>
        /// Returns a list of all the modified properties and values.
        /// </summary>
        public string TableName
        {
            get
            {
                return "[dbo].Item";
            }
        }

        #endregion

        #endregion

        #region Overrides
        
        public override string ToString()
        {
            if (_bag.Count == 0)
                return "No criterion was specified";

            var result = string.Empty;
            foreach (KeyValuePair<string, object> key in _bag)
            {
                result += string.Format("[{0}] = '{1}' AND ", key.Key, key.Value);
            }

            return result.Remove(result.Length - 5, 5);
        }

        #endregion

        #region Private Methods
        
        private T GetValue<T>(string name)
        {
            object value;
            if (_bag.TryGetValue(name, out value))
                return (T) value;
        
            return default(T);
        }
        
        #endregion
    }
}