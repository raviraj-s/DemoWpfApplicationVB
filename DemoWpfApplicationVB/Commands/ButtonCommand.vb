Public Class ButtonCommand
  Implements ICommand
  Private objEmployee As EmployeeViewModel

  Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

  Public Sub New(_objEmployee As EmployeeViewModel)
    objEmployee = _objEmployee
  End Sub

  Public Sub Execute(parameter As Object) Implements ICommand.Execute
    objEmployee.CalculateEligibility()
  End Sub

  Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
    Return True
  End Function
End Class
