Imports System.ComponentModel

Public Class EmployeeDetailsModel
  Implements IDataErrorInfo

  Private _EmployeeID As Integer
  Public Property EmployeeID() As Integer
    Get
      Return _EmployeeID
    End Get
    Set(ByVal value As Integer)
      _EmployeeID = value
    End Set
  End Property

  Private _FirstName As String
  Public Property FirstName() As String
    Get
      Return _FirstName
    End Get
    Set(ByVal value As String)
      _FirstName = value
    End Set
  End Property

  Private _LastName As String
  Public Property LastName() As String
    Get
      Return _LastName
    End Get
    Set(ByVal value As String)
      _LastName = value
    End Set
  End Property

  Private _Age As Integer
  Public Property Age() As Integer
    Get
      Return _Age
    End Get
    Set(ByVal value As Integer)
      _Age = value
    End Set
  End Property

  Private _HasFilledMBOs As Boolean
  Public Property HasFilledMBOs() As Boolean
    Get
      Return _HasFilledMBOs
    End Get
    Set(ByVal value As Boolean)
      _HasFilledMBOs = value
    End Set
  End Property

  Private _DateOfJoining As DateTime
  Public Property DateOfJoining() As DateTime
    Get
      Return _DateOfJoining
    End Get
    Set(ByVal value As DateTime)
      _DateOfJoining = value
    End Set
  End Property

  Private _StkFilledMBOs As String
  Public ReadOnly Property StkFilledMBOs() As String
    Get
      Return _StkFilledMBOs
    End Get
    'Set(ByVal value As String)

    'End Set
  End Property

  Private _ElgibleForIncResult As String
  Public ReadOnly Property ElgibleForIncResult() As String
    Get
      Return _ElgibleForIncResult
    End Get
    'Set(ByVal value As String)
    'End Set
  End Property

  Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
    Get
      Dim ValidationResult As String = Nothing
      Select Case columnName
        Case "TxtFirstName"
          ValidationResult = ValidateName()
        Case "TxtLastName"
          ValidationResult = ValidateName()
        Case "DtDateOfJoining"
          ValidationResult = ValidateDate()
        Case Else
          Throw New ApplicationException("Unknown Property being validated on Product.")
      End Select
      Return ValidationResult
    End Get
  End Property

  Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
    Get
      Throw New NotImplementedException()
    End Get
  End Property

  Public Sub CalculateEligibility()
    Dim DtIncDate As DateTime = Convert.ToDateTime("31/08/2017")
    If DateOfJoining < DtIncDate AndAlso HasFilledMBOs = True Then
      _ElgibleForIncResult = "Eligible"
      _StkFilledMBOs = "Green"
    Else
      _ElgibleForIncResult = "Not Eligible"
      _StkFilledMBOs = "Red"
    End If
  End Sub

  Private Function ValidateName() As String
    If String.IsNullOrEmpty(Me.FirstName) Then
      Return "First Name needs to be entered."
    ElseIf Me.FirstName.Length < 3 Then
      Return "First Name should have more than 3 letters."
    ElseIf String.IsNullOrEmpty(Me.LastName) Then
      Return "Last Name needs to be entered."
    ElseIf Me.LastName.Length < 3 Then
      Return "Last Name should have more than 3 letters."
    Else
      Return String.Empty
    End If
  End Function

  Private Function ValidateDate() As String
    If String.IsNullOrEmpty(Me.DateOfJoining) Then
      Return "Date of joining needs to be entered."
    ElseIf Me.DateOfJoining > DateTime.Now Then
      Return "Date of joining cannot be a future date."
    Else
      Return String.Empty
    End If
  End Function

End Class
