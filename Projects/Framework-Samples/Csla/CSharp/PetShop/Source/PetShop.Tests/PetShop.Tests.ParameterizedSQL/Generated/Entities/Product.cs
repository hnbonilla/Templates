//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//       Changes to this template will not be lost.
//
//     Template: SwitchableObject.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Security;
using Csla.Validation;

#endregion

namespace PetShop.Tests.ParameterizedSQL
{
    public partial class Product
    {
        #region Validation Rules

        /// <summary>
        /// All custom rules need to be placed in this method.
        /// </summary>
        /// <returns>Return true to override the generated rules; If false generated rules will be run.</returns>
        protected bool AddBusinessValidationRules()
        {
            // TODO: add validation rules
            //ValidationRules.AddRule(RuleMethod, "");

            return false;
        }

        #endregion

        #region Authorization Rules

        protected override void AddAuthorizationRules()
        {
            //// More information on these rules can be found here (http://www.devx.com/codemag/Article/40663/1763/page/2).

            //string[] canWrite = { "AdminUser", "RegularUser" };
            //string[] canRead = { "AdminUser", "RegularUser", "ReadOnlyUser" };
            //string[] admin = { "AdminUser" };

            // AuthorizationRules.AllowCreate(typeof(Product), admin);
            // AuthorizationRules.AllowDelete(typeof(Product), admin);
            // AuthorizationRules.AllowEdit(typeof(Product), canWrite);
            // AuthorizationRules.AllowGet(typeof(Product), canRead);

            //// ProductId
            // AuthorizationRules.AllowRead(_productIdProperty, canRead);

            //// CategoryId
            // AuthorizationRules.AllowRead(_categoryIdProperty, canRead);

            //// Name
            // AuthorizationRules.AllowRead(_nameProperty, canRead);

            //// Descn
            // AuthorizationRules.AllowRead(_descnProperty, canRead);

            //// Image
            // AuthorizationRules.AllowRead(_imageProperty, canRead);

            //// CategoryMember
            // AuthorizationRules.AllowRead(_categoryMemberProperty, canRead);

// NOTE: Many-To-Many support coming soon.
            //// Items
            // AuthorizationRules.AllowRead(_itemsProperty, canRead);

        }

        #endregion
    }
}