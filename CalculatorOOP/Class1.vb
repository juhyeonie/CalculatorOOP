Public Class Calculator
    Private currentInput As String = "0"
    Private result As Double = 0
    Private lastOperator As String = ""
    Private isNewInput As Boolean = True

    Public ReadOnly Property GetInput As String
        Get
            Return currentInput
        End Get
    End Property

    Public Sub EnterNumber(num As String)
        If isNewInput Or currentInput = "0" Then
            currentInput = num
        Else
            currentInput &= num
        End If
        isNewInput = False
    End Sub

    Public Sub EnterDecimal()
        If Not currentInput.Contains(".") Then
            currentInput &= "."
        End If
    End Sub

    Public Sub Backspace()
        If currentInput.Length > 1 Then
            currentInput = currentInput.Substring(0, currentInput.Length - 1)
        Else
            currentInput = "0"
        End If
    End Sub

    Public Sub Clear()
        currentInput = "0"
        result = 0
        lastOperator = ""
        isNewInput = True
    End Sub

    Public Sub SetOperator(op As String)
        Compute()
        lastOperator = op
        isNewInput = True
    End Sub

    Public Sub Compute()
        Dim number As Double = Double.Parse(currentInput)
        Select Case lastOperator
            Case "+"
                result += number
            Case "-"
                result -= number
            Case "×"
                result *= number
            Case "÷"
                If number <> 0 Then
                    result /= number
                Else
                    Throw New DivideByZeroException("Cannot divide by zero!")
                End If
            Case Else
                result = number
        End Select
        currentInput = result.ToString()
    End Sub
End Class
