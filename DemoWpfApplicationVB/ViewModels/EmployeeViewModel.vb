Imports System.ComponentModel
Imports DemoWpfApplicationVB

Public Class EmployeeViewModel
  Implements INotifyPropertyChanged
  Private Event INotifyPropertyChanged_PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
  Private objEmployee As EmployeeDetailsModel = New EmployeeDetailsModel()
  Private objCommand As ButtonCommand

  Private _TxtFirstName As String
  Public Property TxtFirstName() As String
    Get
      Return objEmployee.FirstName
    End Get
    Set(ByVal value As String)
      objEmployee.FirstName = value
    End Set
  End Property
  Private _TxtLastName As String
  Public Property TxtLastName() As String
    Get
      Return objEmployee.LastName
    End Get
    Set(ByVal value As String)
      objEmployee.LastName = value
    End Set
  End Property
  Private _SldAge As Integer
  Public Property SldAge() As Integer
    Get
      Return objEmployee.Age
    End Get
    Set(ByVal value As Integer)
      objEmployee.Age = value
    End Set
  End Property

  Private _ChkHasFilledMBOs As Boolean
  Public Property ChkHasFilledMBOs() As Boolean
    Get
      Return objEmployee.HasFilledMBOs
    End Get
    Set(ByVal value As Boolean)
      objEmployee.HasFilledMBOs = value
    End Set
  End Property

  Private _DtDateOfJoining As DateTime
  Public Property DtDateOfJoining() As DateTime
    Get
      Return objEmployee.DateOfJoining
    End Get
    Set(ByVal value As DateTime)
      objEmployee.DateOfJoining = value
    End Set
  End Property

  Private _StkFilledMBOs As String
  Public ReadOnly Property StkFilledMBOs() As String
    Get
      Return objEmployee.StkFilledMBOs
    End Get
    'Set(ByVal value As String)
    '  _StkFilledMBOs = value
    '  NotifyPropertyChanged("StkFilledMBOs")
    'End Set
  End Property

  Private _LblElgibleForIncResult As String
  Public ReadOnly Property LblElgibleForIncResult() As String
    Get
      Return objEmployee.ElgibleForIncResult
    End Get
    'Set(ByVal value As String)
    '  _LblElgibleForIncResult = value
    '  NotifyPropertyChanged("LblElgibleForIncResult")
    'End Set
  End Property

  Public Sub CalculateEligibility()
    objEmployee.CalculateEligibility()
    RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("LblElgibleForIncResult"))
    RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("StkFilledMBOs"))
  End Sub

  Public Sub New()
    objCommand = New ButtonCommand(Me)
  End Sub

  Dim _btnClick As New ButtonCommand(Me)

  Public Property BtnClick As ButtonCommand
    Get
      Return _btnClick
    End Get
    Set(value As ButtonCommand)
      _btnClick = value
    End Set
  End Property
End Class
