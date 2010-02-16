'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to this template will not be lost.
'
'     Template: ObjectFactoryList.DataAccess.StoredProcedures.cst
'     Template website: http:'code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

#Region "Imports declarations"

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data
Imports Csla.Server

Imports PetShop.Tests.OF.StoredProcedures

#End Region

Public Partial Class LineItemListFactory
    Inherits ObjectFactory

    #Region "Create"

    ''' <summary>
    ''' Creates New LineItemList with default values.
    ''' </summary>
    ''' <Returns>New LineItemList.</Returns>
    <RunLocal()> _
    Public Function Create() As LineItemList
        Dim item As LineItemList = CType(Activator.CreateInstance(GetType(LineItemList), True), LineItemList)

        Dim cancel As Boolean = False
        OnCreating(cancel)
        If (cancel) Then
            Return item
        End If

        CheckRules(item)
        MarkNew(item)

        OnCreated()

        Return item
    End Function

    #End Region

    #Region "Fetch

    ''' <summary>
    ''' Fetch LineItemList.
    ''' </summary>
    ''' <param name="criteria">The criteria.</param>
    ''' <Returns></Returns>
    Public Function Fetch(ByVal criteria As LineItemCriteria) As LineItemList
        Dim item As LineItemList = CType(Activator.CreateInstance(GetType(LineItemList), True), LineItemList)

        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return item
        End If

        ' Fetch Child objects.
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_LineItem_Select]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Do
                            item.Add(new LineItemFactory().Map(reader))
                        Loop While reader.Read()
                    Else
                        Throw New Exception(String.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria))
                    End If
                End Using
            End Using
        End Using

        MarkOld(item)

        OnFetched()

        Return item
    End Function

    #End Region

    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As LineItemCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnFetched()
    End Sub
    
    #End Region
End Class