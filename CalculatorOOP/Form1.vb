Public Class Form1
    Dim firstNumber As Double
    Dim secondNumber As Double
    Dim operation As String
    Dim isOperationPerformed As Boolean = False

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click,
        btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btnDecimal.Click

        If txtDisplay.Text = "0" Or isOperationPerformed Then
            txtDisplay.Clear()
        End If

        isOperationPerformed = False
        Dim button As Button = CType(sender, Button)

        If button.Text = "." Then
            If Not txtDisplay.Text.Contains(".") Then
                txtDisplay.Text = txtDisplay.Text + button.Text
            End If
        Else
            txtDisplay.Text = txtDisplay.Text + button.Text
        End If
    End Sub

    Private Sub operator_Click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnSub.Click, btnMul.Click, btnDiv.Click
        Dim button As Button = CType(sender, Button)

        If operation <> "" AndAlso Not isOperationPerformed Then
            btnEqual.PerformClick()
        End If

        operation = button.Text
        If operation = "×" Then operation = "*"
        If operation = "÷" Then operation = "/"


        Double.TryParse(txtDisplay.Text, firstNumber)

        isOperationPerformed = True
    End Sub


    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        If Not Double.TryParse(txtDisplay.Text, secondNumber) Then
            txtDisplay.Text = "0"
            Return
        End If

        Dim result As Double

        Select Case operation
            Case "+"
                result = firstNumber + secondNumber
            Case "-"
                result = firstNumber - secondNumber
            Case "*"
                result = firstNumber * secondNumber
            Case "/"
                If secondNumber = 0 Then
                    txtDisplay.Text = "Cannot divide by zero"
                    isOperationPerformed = True
                    operation = ""
                    Return
                Else
                    result = firstNumber / secondNumber
                End If
            Case Else
                Return
        End Select

        txtDisplay.Text = result.ToString()
        isOperationPerformed = True
        operation = ""
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDisplay.Text = "0"
        firstNumber = 0
        secondNumber = 0
        operation = ""
        isOperationPerformed = False
    End Sub

    Private Sub btnBackspace_Click(sender As Object, e As EventArgs) Handles btnBackspace.Click
        ' If error message, reset like Clear
        If txtDisplay.Text = "Cannot divide by zero" Then
            txtDisplay.Text = "0"
            firstNumber = 0
            secondNumber = 0
            operation = ""
            isOperationPerformed = False
            Return
        End If

        ' Normal backspace behavior
        If txtDisplay.Text.Length > 1 Then
            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1)
        Else
            txtDisplay.Text = "0"
        End If
    End Sub

    ' Form Load (initialize display)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDisplay.Text = "0"
    End Sub
End Class
