//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Category.cs'.
//
//     Template: ReadOnlyRoot.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Tests.Collections.ReadOnlyRoot
{
    [Serializable]
    public partial class Category : ReadOnlyBase< Category >
    {
        #region Contructor(s)

        private Category()
        { /* Require use of factory methods */ }

        private Category(System.String categoryId)
        {
            LoadProperty(_categoryIdProperty, categoryId);
        }

        internal Category(SafeDataReader reader)
        {
            Map(reader);
        }
        #endregion

        #region Properties

        private static readonly PropertyInfo< System.String > _categoryIdProperty = RegisterProperty< System.String >(p => p.CategoryId);
		[System.ComponentModel.DataObjectField(true, false)]
        public System.String CategoryId
        {
            get { return GetProperty(_categoryIdProperty); }
        }

        private static readonly PropertyInfo< System.String > _nameProperty = RegisterProperty< System.String >(p => p.Name);
        public System.String Name
        {
            get { return GetProperty(_nameProperty); }
        }

        private static readonly PropertyInfo< System.String > _descnProperty = RegisterProperty< System.String >(p => p.Descn);
        public System.String Descn
        {
            get { return GetProperty(_descnProperty); }
        }


        #endregion

        #region Factory Methods 

        public static Category GetByCategoryId(System.String categoryId)
        {
            return DataPortal.Fetch< Category >(
                new CategoryCriteria{CategoryId = categoryId});
        }

        #endregion

        #region Exists Command

        public static bool Exists(CategoryCriteria criteria)
        {
            return ExistsCommand.Execute(criteria);
        }

        #endregion

    }
}