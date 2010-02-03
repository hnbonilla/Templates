//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Supplier.cs'.
//
//     Template: EditableRoot.DataAccess.ParameterizedSQL.cst
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
    public partial class Supplier
    {
        [RunLocal]
        protected override void DataPortal_Create()
        {
            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return;

            ValidationRules.CheckRules();

            OnCreated();
        }

        protected void DataPortal_Fetch(SupplierCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("SELECT [SuppId], [Name], [Status], [Addr1], [Addr2], [City], [State], [Zip], [Phone] FROM [dbo].[Supplier] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if (reader.Read())
                            Map(reader);
                        else
                            throw new Exception(String.Format("The record was not found in 'Supplier' using the following criteria: {0}.", criteria));
                    }
                }
            }

            OnFetched();
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            bool cancel = false;
            OnInserting(ref cancel);
            if (cancel) return;

            const string commandText = "INSERT INTO [dbo].[Supplier] ([SuppId], [Name], [Status], [Addr1], [Addr2], [City], [State], [Zip], [Phone]) VALUES (@p_SuppId, @p_Name, @p_Status, @p_Addr1, @p_Addr2, @p_City, @p_State, @p_Zip, @p_Phone)";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_SuppId", SuppId);
					command.Parameters.AddWithValue("@p_Name", Name);
					command.Parameters.AddWithValue("@p_Status", Status);
					command.Parameters.AddWithValue("@p_Addr1", Addr1);
					command.Parameters.AddWithValue("@p_Addr2", Addr2);
					command.Parameters.AddWithValue("@p_City", City);
					command.Parameters.AddWithValue("@p_State", State);
					command.Parameters.AddWithValue("@p_Zip", Zip);
					command.Parameters.AddWithValue("@p_Phone", Phone);

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                            using (BypassPropertyChecks)
                            {
                            }
                        }
                    }
                }
            }

            OnInserted();

            FieldManager.UpdateChildren(this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            bool cancel = false;
            OnUpdating(ref cancel);
            if (cancel) return;

            const string commandText = "UPDATE [dbo].[Supplier]  SET [SuppId] = @p_SuppId, [Name] = @p_Name, [Status] = @p_Status, [Addr1] = @p_Addr1, [Addr2] = @p_Addr2, [City] = @p_City, [State] = @p_State, [Zip] = @p_Zip, [Phone] = @p_Phone WHERE [SuppId] = @p_SuppId";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_SuppId", SuppId);
					command.Parameters.AddWithValue("@p_Name", Name);
					command.Parameters.AddWithValue("@p_Status", Status);
					command.Parameters.AddWithValue("@p_Addr1", Addr1);
					command.Parameters.AddWithValue("@p_Addr2", Addr2);
					command.Parameters.AddWithValue("@p_City", City);
					command.Parameters.AddWithValue("@p_State", State);
					command.Parameters.AddWithValue("@p_Zip", Zip);
					command.Parameters.AddWithValue("@p_Phone", Phone);

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnUpdated();

            FieldManager.UpdateChildren(this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SupplierCriteria(SuppId));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(SupplierCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("DELETE FROM [dbo].[Supplier] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnDeleted();
        }

        private void Map(SafeDataReader reader)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_suppIdProperty, reader.GetInt32("SuppId"));
                LoadProperty(_nameProperty, reader.GetString("Name"));
                LoadProperty(_statusProperty, reader.GetString("Status"));
                LoadProperty(_addr1Property, reader.GetString("Addr1"));
                LoadProperty(_addr2Property, reader.GetString("Addr2"));
                LoadProperty(_cityProperty, reader.GetString("City"));
                LoadProperty(_stateProperty, reader.GetString("State"));
                LoadProperty(_zipProperty, reader.GetString("Zip"));
                LoadProperty(_phoneProperty, reader.GetString("Phone"));
            }

            MarkOld();
        }

        #region Data access partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(SupplierCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(SupplierCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion
    }
}