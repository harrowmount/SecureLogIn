Imports System.Security.Cryptography
Imports System.Text

Public Class Form1

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Try
            If UsernameInput.Text.Replace(" ", "") = Nothing Or PasswordInput.Text.Replace(" ", "") = Nothing Then
                Throw New ApplicationException("All fields must be filled")
            End If
            Dim LogIn As DataRow()
            Dim UsernameInputStr As String = UsernameInput.Text
            Dim expression As String = "Username = '" & UsernameInputStr & "'"
            LogIn = LogInDBDataSet1.Table.Select(expression)
            If LogIn.Length = 0 Then
                Throw New ApplicationException("Login failed")
            End If
            Dim passwordInputStr As String = PasswordInput.Text
            Dim Salt As String = LogIn(0).Item(3)
            Dim SaltandPass As String = Salt & passwordInputStr
            Dim hashPass As String = SaltandPass.GetHashCode()
            If hashPass = LogIn(0).Item(2) Then
                Message.ForeColor = Color.Green
                Message.Text = "Log in successful!"
                Message.Visible = True
            Else
                Throw New ApplicationException("Login failed")
            End If
        Catch ex As ApplicationException
            Message.Text = ex.Message
            Message.ForeColor = Color.Red
            Message.Visible = True
        End Try
    End Sub

    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles RegisterBtn.Click
        Try
            If UsernameInput.Text.Replace(" ", "") = Nothing Or PasswordInput.Text.Replace(" ", "") = Nothing Then
                Throw New ApplicationException("All fields must be filled")
            End If
            Dim UsernameInputStr As String = UsernameInput.Text
            Dim PasswordInputStr As String = PasswordInput.Text
            Dim expression As String = "Username = '" & UsernameInputStr & "'"
            Dim LogIn As DataRow() = LogInDBDataSet1.Table.Select(expression)
            If LogIn.Length <> 0 Then
                Throw New ApplicationException("Username in use")
            End If
            Dim rngCSP As New RNGCryptoServiceProvider()
            Dim saltyArray = New Byte(25) {}
            rngCSP.GetNonZeroBytes(saltyArray)
            Dim passByteArray As Byte() = Encoding.UTF8.GetBytes(PasswordInputStr)
            Dim hashingArray As Byte() = New Byte(PasswordInputStr.Length + 25) {}
            Dim i As Integer
            For i = 0 To PasswordInputStr.Length - 1
                hashingArray(i) = passByteArray(i)
            Next i
            For i = 0 To saltyArray.Length - 1
                hashingArray(passByteArray.Length + i) = saltyArray(i)
            Next i
            Dim hasher As HashAlgorithm = New MD5CryptoServiceProvider()
            hasher.ComputeHash(hashingArray)
            Dim newLogIn As LogInDBDataSet.TableRow
            newLogIn = LogInDBDataSet1.Table.NewRow
            newLogIn.PaswordHash = hashingArray.ToString
            newLogIn.Username = UsernameInputStr
            Dim hashedPassString As String = ""
            For i = 0 To hashingArray.Length - 1
                hashedPassString = hashedPassString & hashingArray(i)
            Next i
            newLogIn.Salt = hashedPassString
            MessageBox.Show(hashedPassString)
            LogInDBDataSet1.Table.Rows.Add(newLogIn)
            TableTableAdapter.Update(LogInDBDataSet1.Table)
            Message.ForeColor = Color.Green
            Message.Text = UsernameInputStr & " has been registered!"
            Message.Visible = True
        Catch ex As ApplicationException
            Message.Text = ex.Message
            Message.ForeColor = Color.Red
            Message.Visible = True
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LogInDBDataSet1.Table' table. You can move, or remove it, as needed.
        TableTableAdapter.Fill(LogInDBDataSet1.Table)
        Message.Text = ""
        Message.Visible = False
    End Sub
End Class
