//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Profile.cs'.
//
//     Template: SwitchableObject.DataAccess.ParameterizedSQL.cst
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
    public partial class Profile
    {
        #region Root Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return;

            ValidationRules.CheckRules();

            OnCreated();
        }

        private void DataPortal_Fetch(ProfileCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("SELECT [UniqueID], [Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate] FROM [dbo].[Profiles] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
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
                            throw new Exception(String.Format("The record was not found in 'Profiles' using the following criteria: {0}.", criteria));
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

            const string commandText = "INSERT INTO [dbo].[Profiles] ([Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]) VALUES (@p_Username, @p_ApplicationName, @p_IsAnonymous, @p_LastActivityDate, @p_LastUpdatedDate); SELECT [UniqueID] FROM [dbo].[Profiles] WHERE UniqueID = SCOPE_IDENTITY()";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_Username", Username);
					command.Parameters.AddWithValue("@p_ApplicationName", ApplicationName);
					command.Parameters.AddWithValue("@p_IsAnonymous", IsAnonymous);
					command.Parameters.AddWithValue("@p_LastActivityDate", LastActivityDate);
					command.Parameters.AddWithValue("@p_LastUpdatedDate", LastUpdatedDate);

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                            using (BypassPropertyChecks)
                            {
                                LoadProperty(_uniqueIDProperty, reader.GetInt32("UniqueID"));
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

            const string commandText = "UPDATE [dbo].[Profiles]  SET [Username] = @p_Username, [ApplicationName] = @p_ApplicationName, [IsAnonymous] = @p_IsAnonymous, [LastActivityDate] = @p_LastActivityDate, [LastUpdatedDate] = @p_LastUpdatedDate WHERE [UniqueID] = @p_UniqueID";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_UniqueID", UniqueID);
					command.Parameters.AddWithValue("@p_Username", Username);
					command.Parameters.AddWithValue("@p_ApplicationName", ApplicationName);
					command.Parameters.AddWithValue("@p_IsAnonymous", IsAnonymous);
					command.Parameters.AddWithValue("@p_LastActivityDate", LastActivityDate);
					command.Parameters.AddWithValue("@p_LastUpdatedDate", LastUpdatedDate);

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
            DataPortal_Delete(new ProfileCriteria(UniqueID));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(ProfileCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("DELETE FROM [dbo].[Profiles] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
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

        #endregion

        #region Child Data Access

        protected override void Child_Create()
        {
            bool cancel = false;
            OnChildCreating(ref cancel);
            if (cancel) return;

            ValidationRules.CheckRules();

            OnChildCreated();
        }

        private void Child_Fetch(ProfileCriteria criteria)
        {
            bool cancel = false;
            OnChildFetching(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("SELECT [UniqueID], [Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate] FROM [dbo].[Profiles] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                            Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'Profiles' using the following criteria: {0}.", criteria));
                    }
                }
            }

            OnChildFetched();

            MarkAsChild();
        }

        private void Child_Insert()
        {
            bool cancel = false;
            OnChildInserting(ref cancel);
            if (cancel) return;

            const string commandText = "INSERT INTO [dbo].[Profiles] ([Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]) VALUES (@p_Username, @p_ApplicationName, @p_IsAnonymous, @p_LastActivityDate, @p_LastUpdatedDate); SELECT [UniqueID] FROM [dbo].[Profiles] WHERE UniqueID = SCOPE_IDENTITY()";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_Username", Username);
					command.Parameters.AddWithValue("@p_ApplicationName", ApplicationName);
					command.Parameters.AddWithValue("@p_IsAnonymous", IsAnonymous);
					command.Parameters.AddWithValue("@p_LastActivityDate", LastActivityDate);
					command.Parameters.AddWithValue("@p_LastUpdatedDate", LastUpdatedDate);

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                            LoadProperty(_uniqueIDProperty, reader.GetInt32("UniqueID"));
                        }
                    }
                }
            }

            OnChildInserted();
        }

        private void Child_Update()
        {
            bool cancel = false;
            OnChildUpdating(ref cancel);
            if (cancel) return;

            const string commandText = "UPDATE [dbo].[Profiles]  SET [Username] = @p_Username, [ApplicationName] = @p_ApplicationName, [IsAnonymous] = @p_IsAnonymous, [LastActivityDate] = @p_LastActivityDate, [LastUpdatedDate] = @p_LastUpdatedDate WHERE [UniqueID] = @p_UniqueID";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_UniqueID", UniqueID);
					command.Parameters.AddWithValue("@p_Username", Username);
					command.Parameters.AddWithValue("@p_ApplicationName", ApplicationName);
					command.Parameters.AddWithValue("@p_IsAnonymous", IsAnonymous);
					command.Parameters.AddWithValue("@p_LastActivityDate", LastActivityDate);
					command.Parameters.AddWithValue("@p_LastUpdatedDate", LastUpdatedDate);

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnChildUpdated();
        }

        private void Child_DeleteSelf()
        {
            DataPortal_Delete(new ProfileCriteria(UniqueID));
        }

        #endregion

        private void Map(SafeDataReader reader)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_uniqueIDProperty, reader.GetInt32("UniqueID"));
                LoadProperty(_usernameProperty, reader.GetString("Username"));
                LoadProperty(_applicationNameProperty, reader.GetString("ApplicationName"));
                LoadProperty(_isAnonymousProperty, reader.GetBoolean("IsAnonymous"));
                LoadProperty(_lastActivityDateProperty, reader.GetDateTime("LastActivityDate"));
                LoadProperty(_lastUpdatedDateProperty, reader.GetDateTime("LastUpdatedDate"));
            }

            MarkOld();
        }

        #region Data access partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(ProfileCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(ProfileCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion

        #region Child data access partial methods

        partial void OnChildCreating(ref bool cancel);
        partial void OnChildCreated();
        partial void OnChildFetching(ProfileCriteria criteria, ref bool cancel);
        partial void OnChildFetched();
        partial void OnChildInserting(ref bool cancel);
        partial void OnChildInserted();
        partial void OnChildUpdating(ref bool cancel);
        partial void OnChildUpdated();
        partial void OnChildSelfDeleting(ref bool cancel);
        partial void OnChildSelfDeleted();

        #endregion
    }
}