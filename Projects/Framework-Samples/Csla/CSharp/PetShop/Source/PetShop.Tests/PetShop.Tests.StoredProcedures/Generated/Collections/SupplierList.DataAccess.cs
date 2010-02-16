//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'SupplierList.cs'.
//
//     Template: EditableChildList.DataAccess.StoredProcedures.cst
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

namespace PetShop.Tests.StoredProcedures
{
    public partial class SupplierList
    {
        private void Child_Fetch(SupplierCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return;

            RaiseListChangedEvents = false;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_Supplier_Select]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_NameHasValue", criteria.NameHasValue);
					command.Parameters.AddWithValue("@p_Addr1HasValue", criteria.Addr1HasValue);
					command.Parameters.AddWithValue("@p_Addr2HasValue", criteria.Addr2HasValue);
					command.Parameters.AddWithValue("@p_CityHasValue", criteria.CityHasValue);
					command.Parameters.AddWithValue("@p_StateHasValue", criteria.StateHasValue);
					command.Parameters.AddWithValue("@p_ZipHasValue", criteria.ZipHasValue);
					command.Parameters.AddWithValue("@p_PhoneHasValue", criteria.PhoneHasValue);
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                            do
                            {
                                this.Add(new Supplier(reader));
                            } while(reader.Read());
                        }
                        else
                            throw new Exception(string.Format("The record was not found in 'Supplier' using the following criteria: {0}.", criteria));
                    }
                }
            }

            RaiseListChangedEvents = true;

            OnFetched();
        }

        #region Data access partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(SupplierCriteria criteria, ref bool cancel);
        partial void OnFetched();

        #endregion
    }
}