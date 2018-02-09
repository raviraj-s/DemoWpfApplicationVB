Public Class DepartmentModel
  Private _DepartmentID As Integer
  Public Property DepartmentID() As Integer
    Get
      Return _DepartmentID
    End Get
    Set(ByVal value As Integer)
      _DepartmentID = value
    End Set
  End Property
  Private _DepartmentDesc As String
  Public Property DepartmentDesc() As String
    Get
      Return _DepartmentDesc
    End Get
    Set(ByVal value As String)
      _DepartmentDesc = value
    End Set
  End Property
End Class
