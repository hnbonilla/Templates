﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1845, CSLA Framework: v4.0.0.
'     Changes to Me file will be lost after each regeneration.
'     To extend the functionality of Me class, please modify the partial class 'Category.vb.
'
'     Template: EditableRoot.DataAccess.ParameterizedSQL.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On
#If Not SILVERLIGHT Then

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data
Imports Csla.Rules

Namespace PetShop.Business
    Public Partial Class Category
        <RunLocal()> _
        Protected Shadows Sub DataPortal_Create()
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            BusinessRules.CheckRules()
    
            OnCreated()
        End Sub
    
        Private Shadows Sub DataPortal_Fetch(ByVal criteria As CategoryCriteria)
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Dim commandText As String = String.Format("SELECT [CategoryId], [Name], [Descn], [TheVersion] FROM [dbo].[Category] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'Category' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            OnFetched()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Insert()
            Dim cancel As Boolean = False
            OnInserting(cancel)
            If (cancel) Then
                Return
            End If
    
            Const commandText As String = "INSERT INTO [dbo].[Category] ([CategoryId], [Name], [Descn]) VALUES (@p_CategoryId, @p_Name, @p_Descn); SELECT [TheVersion] FROM [dbo].[Category] WHERE CategoryId = @p_CategoryId"
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddWithValue("@p_CategoryId", Me.CategoryId)
				command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(Me.Name))
				command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(Me.Description))
    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                Using(BypassPropertyChecks)
                                TheVersion = ADOHelper.GetBytes(reader, "TheVersion")
                End Using
                        End If
                    End Using
                End Using
    
                LoadProperty(_originalCategoryIdProperty, Me.CategoryId)
    
    
                FieldManager.UpdateChildren(Me, connection)
            End Using
    
            OnInserted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Update()
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
    
            If Not OriginalCategoryId = CategoryId Then
                ' Insert new child.
                Dim item As New Category()
                item.CategoryId = CategoryId
			item.Name = Name
			item.Description = Description
                item = item.Save()
    
                ' Mark child lists as dirty. This code may need to be updated to one-to-one relationships.
                For Each itemToUpdate As Product In Products
    		itemToUpdate.CategoryId = CategoryId
                Next
    
                ' Create a new connection.
                Using connection As New SqlConnection(ADOHelper.ConnectionString)
                    connection.Open()
                    FieldManager.UpdateChildren(Me, connection)
                End Using
    
                ' Delete the old.
                Dim criteria As New CategoryCriteria()
                criteria.CategoryId = OriginalCategoryId
                DataPortal_Delete(criteria)
    
                ' Mark the original as the new one.
                OriginalCategoryId = CategoryId
                OnUpdated()
    
                Return
            End If
    
            Const commandText As String = "UPDATE [dbo].[Category]  SET [CategoryId] = @p_CategoryId, [Name] = @p_Name, [Descn] = @p_Descn WHERE [CategoryId] = @p_OriginalCategoryId AND [TheVersion] = @p_TheVersion; SELECT [TheVersion] FROM [dbo].[Category] WHERE CategoryId = @p_CategoryId"
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddWithValue("@p_OriginalCategoryId", Me.OriginalCategoryId)
				command.Parameters.AddWithValue("@p_CategoryId", Me.CategoryId)
				command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(Me.Name))
				command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(Me.Description))
                    command.Parameters.AddWithValue("@p_TheVersion", SqlDbType.Timestamp)
                    command.Parameters("@p_TheVersion").Value = Me.TheVersion
                    command.Parameters("@p_TheVersion").Direction = ParameterDirection.InputOutput
    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        'RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        If reader.RecordsAffected = 0 Then
                            Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                        End If
    
                        If reader.Read() Then
                            Using (BypassPropertyChecks)
                                TheVersion = ADOHelper.GetBytes(reader, "TheVersion")
                            End Using
                        End If
                    End Using
                End Using
                LoadProperty(_originalCategoryIdProperty, Me.CategoryId)
    
    
                FieldManager.UpdateChildren(Me, connection)
            End Using
    
            OnUpdated()
        End Sub
    
        Protected Overrides Sub DataPortal_DeleteSelf()
            Dim cancel As Boolean = False
            OnSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New CategoryCriteria (CategoryId))
        
            OnSelfDeleted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Shadows Sub DataPortal_Delete(ByVal criteria As CategoryCriteria)
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Dim commandText As String = String.Format("DELETE FROM [dbo].[Category] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
    
                    'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    Dim result As Integer = command.ExecuteNonQuery()
                    If (result = 0) Then
                        Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
                End Using
            End Using
    
            OnDeleted()
        End Sub
    
        Private Sub Map(ByVal reader As SafeDataReader)
            Dim cancel As Boolean = False
            OnMapping(reader, cancel)
            If (cancel) Then
                Return
            End If
    
            Using(BypassPropertyChecks)
                TheVersion = ADOHelper.GetBytes(reader, "TheVersion")
                LoadProperty(_categoryIdProperty, reader.Item("CategoryId"))
                LoadProperty(_originalCategoryIdProperty, reader.Item("CategoryId"))
                LoadProperty(_nameProperty, reader.Item("Name"))
                LoadProperty(_descriptionProperty, reader.Item("Descn"))
            End Using
    
            OnMapped()
    
            MarkOld()
        End Sub
    End Class
End Namespace
#End If
