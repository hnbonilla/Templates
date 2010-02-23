'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.2.
'     Changes to this template will not be lost.
'
'     Template: ObjectFactoryList.DataAccess.ParameterizedSQL.cst
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

Imports PetShop.Tests.OF.ParameterizedSQL

#End Region

Public Partial Class SupplierListFactory
    Inherits ObjectFactory

    #Region "Create"

    ''' <summary>
    ''' Creates New SupplierList with default values.
    ''' </summary>
    ''' <Returns>New SupplierList.</Returns>
    <RunLocal()> _
    Public Function Create() As SupplierList
        Dim item As SupplierList = CType(Activator.CreateInstance(GetType(SupplierList), True), SupplierList)

        Dim cancel As Boolean = False
        OnCreating(cancel)
        If (cancel) Then
            Return item
        End If

        CheckRules(item)
        MarkNew(item)
        MarkAsChild(item)

        OnCreated()

        Return item
    End Function

    #End Region

    #Region "Fetch

    ''' <summary>
    ''' Fetch SupplierList.
    ''' </summary>
    ''' <param name="criteria">The criteria.</param>
    ''' <Returns></Returns>
    Public Function Fetch(ByVal criteria As SupplierCriteria) As SupplierList
        Dim item As SupplierList = CType(Activator.CreateInstance(GetType(SupplierList), True), SupplierList)

        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return item
        End If

        ' Fetch Child objects.
        Dim commandText As String = String.Format("SELECT [SuppId], [Name], [Status], [Addr1], [Addr2], [City], [State], [Zip], [Phone] FROM [dbo].[Supplier] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Do
                            item.Add(new SupplierFactory().Map(reader))
                        Loop While reader.Read()
                    Else
                        Throw New Exception(String.Format("The record was not found in 'Supplier' using the following criteria: {0}.", criteria))
                    End If
                End Using
            End Using
        End Using

        MarkOld(item)
        MarkAsChild(item)

        OnFetched()

        Return item
    End Function

    #End Region

    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As SupplierCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnFetched()
    End Sub
    Partial Private Sub OnMapping(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnMapped()
    End Sub
    
    #End Region
End Class