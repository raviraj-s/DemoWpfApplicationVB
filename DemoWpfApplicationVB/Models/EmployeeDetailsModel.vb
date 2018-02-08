Public Class EmployeeDetailsModel

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

  Public Sub CalculateEligibility()
    If DateOfJoining > DateTime.Now.AddYears(-1) Then
      _ElgibleForIncResult = "Not Eligible"
      _StkFilledMBOs = "Red"
    Else
      _ElgibleForIncResult = "Eligible"
      _StkFilledMBOs = "Green"
    End If
  End Sub



End Class
