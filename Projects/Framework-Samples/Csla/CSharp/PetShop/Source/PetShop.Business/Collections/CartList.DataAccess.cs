//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'CartList.cs'.
//
//     Template: EditableChildList.DataAccess.ParameterizedSQL.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Business
{
    public partial class CartList
    {
        private void Child_Fetch(CartCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return;

            RaiseListChangedEvents = false;

            string commandText = string.Format("SELECT [CartId], [UniqueID], [ItemId], [Name], [Type], [Price], [CategoryId], [ProductId], [IsShoppingCart], [Quantity] FROM [dbo].[Cart] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                            do
                            {
                                this.Add(new Cart(reader));
                            } while(reader.Read());
                        }
                        else
                            throw new Exception(string.Format("The record was not found in 'Cart' using the following criteria: {0}.", criteria));
                    }
                }
            }

            RaiseListChangedEvents = true;

            OnFetched();
        }

        #region Data access partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(CartCriteria criteria, ref bool cancel);
        partial void OnFetched();

        #endregion
    }
}