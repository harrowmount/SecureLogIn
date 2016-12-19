Imports System.Security.Cryptography

Public Class Form1

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click

    End Sub

    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles RegisterBtn.Click
        Dim UsernameInputStr As String = UsernameInput.Text
        Dim PasswordInputStr As String = PasswordInput.Text
        Dim rngCSP As New RNGCryptoServiceProvider()
        Dim Salt As String = rngCSP.GetHashCode()
        Dim SaltandPass As String = Salt & PasswordInputStr
        Dim hashPass As String = SaltandPass.GetHashCode()
        Dim newLogIn As LogInDBDataSet.TableRow
        newLogIn = LogInDBDataSet1.Table.NewRow
        newLogIn.PaswordHash = hashPass
        newLogIn.Username = UsernameInputStr
        newLogIn.Salt = Salt
        LogInDBDataSet1.Table.Rows.Add(newLogIn)
        TableTableAdapter.Update(LogInDBDataSet1.Table)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LogInDBDataSet1.Table' table. You can move, or remove it, as needed.
        Me.TableTableAdapter.Fill(Me.LogInDBDataSet1.Table)

    End Sub
End Class
