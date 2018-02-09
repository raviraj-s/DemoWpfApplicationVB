Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DemoWpfApplicationVB

Public Class EmployeeViewModel
  Implements INotifyPropertyChanged, IDataErrorInfo
  Private Event INotifyPropertyChanged_PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
  Private objEmployee As EmployeeDetailsModel = New EmployeeDetailsModel()
  Private objCommand As ButtonCommand
  Private validProperties As Dictionary(Of String, Boolean)
  Private _allPropertiesValid As Boolean = False

#Region "Properties"
  Private _TxtFirstName As String
  Public Property TxtFirstName() As String
    Get
      Return objEmployee.FirstName
    End Get
    Set(ByVal value As String)
      objEmployee.FirstName = value
      RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("TxtFirstName"))
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

  Private _departments As ObservableCollection(Of DepartmentModel)
  Public Property Departments() As ObservableCollection(Of DepartmentModel)
    Get
      Return _departments
    End Get
    Set(ByVal value As ObservableCollection(Of DepartmentModel))
      _departments = value
    End Set
  End Property

  Private _selectedDepartment As DepartmentModel
  Public Property SelectedDepartment() As DepartmentModel
    Get
      Return _selectedDepartment
    End Get
    Set(ByVal value As DepartmentModel)
      _selectedDepartment = value
    End Set
  End Property


  Public Property AllPropertiesValid As Boolean
    Get
      Return AllPropertiesValid
    End Get
    Set(ByVal value As Boolean)
      If _allPropertiesValid <> value Then
        _allPropertiesValid = value
        RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("AllPropertiesValid"))
      End If
    End Set
  End Property
#End Region

#Region "Methods"
  Public Sub CalculateEligibility()
    objEmployee.CalculateEligibility()
    RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("LblElgibleForIncResult"))
    RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("StkFilledMBOs"))
    RaiseEvent INotifyPropertyChanged_PropertyChanged(Me, New PropertyChangedEventArgs("ChkHasFilledMBOs"))
  End Sub
#End Region

  Public Sub New()
    objCommand = New ButtonCommand(Me)
    Me.validProperties = New Dictionary(Of String, Boolean)
    Me.validProperties.Add("TxtFirstName", False)
    Me.validProperties.Add("TxtLastName", False)
    Me.validProperties.Add("DtDateOfJoining", False)
    'Me.validProperties.Add("Height", False)
    'Me.validProperties.Add("Width", False)
    _departments = New ObservableCollection(Of DepartmentModel)() From {New DepartmentModel() With {.DepartmentID = 1, .DepartmentDesc = "Human Resource"}, New DepartmentModel() With {.DepartmentID = 2, .DepartmentDesc = "Admin"}, New DepartmentModel() With {.DepartmentID = 3, .DepartmentDesc = "Networking"}, New DepartmentModel() With {.DepartmentID = 4, .DepartmentDesc = "Development"}}
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

#Region "IDataErrorInfo"
  Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
    Get
      Dim [error] As String = (TryCast(objEmployee, IDataErrorInfo))(columnName)
      If validProperties(columnName) = String.IsNullOrEmpty([error]) Then
        validProperties(columnName) = True
      Else
        validProperties(columnName) = False
      End If
      ValidateProperties()
      CommandManager.InvalidateRequerySuggested()
      Return [error]
    End Get
  End Property

  Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
    Get
      Throw New NotImplementedException()
    End Get
  End Property
#End Region

#Region "private helpers"
  Private Sub ValidateProperties()
    For Each isValid As Boolean In validProperties.Values
      If Not isValid Then
        Me.AllPropertiesValid = False
        Return
      End If
    Next

    Me.AllPropertiesValid = True
  End Sub
#End Region
End Class
