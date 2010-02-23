﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1413, CSLA Framework: v3.8.2.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'CategoryList.cs'.
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

namespace PetShop.Tests.ObjF.ParameterizedSQL
{
    [Serializable]
    [Csla.Server.ObjectFactory(FactoryNames.CategoryListFactoryName)]
    public partial class CategoryList : BusinessListBase< CategoryList, Category >
    {    
        #region Contructor(s)
        
        private CategoryList()
        { 
            AllowNew = true;
        }
        
        #endregion

        #region Factory Methods 
        
        public static CategoryList NewList()
        {
            return DataPortal.Create< CategoryList >();
        }

        public static CategoryList GetByCategoryId(System.String categoryId)
        {
            return DataPortal.Fetch< CategoryList >(
                new CategoryCriteria{CategoryId = categoryId});
        }

        public static CategoryList GetAll()
        {
            return DataPortal.Fetch< CategoryList >(new CategoryCriteria());
        }

        #endregion

        #region Properties
        
        protected override object AddNewCore()
        {
            Category item = PetShop.Tests.ObjF.ParameterizedSQL.Category.NewCategory();
            Add(item);
            return item;
        }
        
        #endregion

        #region Property overrides

        /// <summary>
        /// Returns true if any children are dirty
        /// </summary>
        public new bool IsDirty
        {
            get
            {
                foreach(Category item in this.Items)
                {
                    if(item.IsDirty) return true;
                }
                
                return false;
            }
        }

        #endregion


        #region Exists Command

        public static bool Exists(CategoryCriteria criteria)
        {
            return PetShop.Tests.ObjF.ParameterizedSQL.Category.Exists(criteria);
        }

        #endregion
    }
}