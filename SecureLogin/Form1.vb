Imports System.Security.Cryptography
Imports System.Text

Public Class Form1

    'Register subroutine:
    'Gets user inputs and hashes the password with a salt. Stores the username, hashed pass+salt, and salt
    'in the DB together.
    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles RegisterBtn.Click
        Try
            'Check if both fields are filled
            If UsernameInput.Text.Replace(" ", "") = Nothing OrElse PasswordInput.Text.Replace(" ", "") = Nothing Then
                Throw New ApplicationException("All fields must be filled")
            End If
            'Fetch user inputs
            Dim UsernameInputStr As String = UsernameInput.Text
            Dim PasswordInputStr As String = PasswordInput.Text
            'Check DB for username to stop multiples of same user
            Dim expression As String = "Username = '" & UsernameInputStr & "'"
            Dim LogIn As DataRow() = LogInDBDataSet1.Table.Select(expression)
            If LogIn.Length <> 0 Then
                Throw New ApplicationException("Username in use")
            End If
            'Generate 25 length salt
            Dim rngCSP As New RNGCryptoServiceProvider()
            Dim saltyArray = New Byte(25) {}
            rngCSP.GetNonZeroBytes(saltyArray)
            'Convert password input into byte array so it can be hashed, hashing only accepts byte arrays
            Dim passByteArray As Byte() = Encoding.UTF8.GetBytes(PasswordInputStr)
            'Create one array to combine password array and salt array together for hashing
            Dim hashingArray As Byte() = New Byte(passByteArray.Length + saltyArray.Length) {}
            Dim i As Integer
            For i = 0 To PasswordInputStr.Length - 1
                hashingArray(i) = passByteArray(i)
            Next i
            For i = 0 To saltyArray.Length - 1
                hashingArray(passByteArray.Length + i) = saltyArray(i)
            Next i
            'Create MD5CryptoServiceProvider() object to hash the array
            Dim hasher As HashAlgorithm = New MD5CryptoServiceProvider()
            hashingArray = hasher.ComputeHash(hashingArray)
            'Begin inputing the hashed array, salt array and username into a tablerow so they can be put into
            'the DB. Converted to strings first as DB only accepts strings
            Dim newLogIn As LogInDBDataSet.TableRow
            newLogIn = LogInDBDataSet1.Table.NewRow
            newLogIn.PaswordHash = Convert.ToBase64String(hashingArray)
            newLogIn.Username = UsernameInputStr
            newLogIn.Salt = Convert.ToBase64String(saltyArray)
            LogInDBDataSet1.Table.Rows.Add(newLogIn)
            TableTableAdapter.Update(LogInDBDataSet1.Table)
            'Show message to confirm a new user has been registered
            Message.ForeColor = Color.Green
            Message.Text = UsernameInputStr & " has been registered!"
            Message.Visible = True
        Catch ex As ApplicationException
            'Show error message to user
            Message.Text = ex.Message
            Message.ForeColor = Color.Red
            Message.Visible = True
        End Try
    End Sub

    'Log in subroutine:
    'Gets the username and uses it to look the correct row up in the DB. Hashes the password input with the salt
    'from the the DB row and checks it against the stored hashed password + salt.
    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Try
            'Checks fields are filled
            If UsernameInput.Text.Replace(" ", "") = Nothing Or PasswordInput.Text.Replace(" ", "") = Nothing Then
                Throw New ApplicationException("All fields must be filled")
            End If
            'Looks up username in DB and returns the correct row
            Dim LogIn As DataRow()
            Dim UsernameInputStr As String = UsernameInput.Text
            Dim expression As String = "Username = '" & UsernameInputStr & "'"
            LogIn = LogInDBDataSet1.Table.Select(expression)
            'If no row found then throw an exception
            If LogIn.Length = 0 Then
                Throw New ApplicationException("Login failed")
            End If
            'Gets password input and converts to byte array as hashing only supports this
            Dim passwordInputStr As String = PasswordInput.Text
            Dim passByteArray As Byte() = Encoding.UTF8.GetBytes(passwordInputStr)
            'Get salt from DB and convert back to byte array from string
            Dim Salt As String = LogIn(0).Item(3)
            Dim saltyArray As Byte() = Convert.FromBase64String(Salt)
            'Combine arrays ready for hashing
            Dim hashingArray As Byte() = New Byte(passByteArray.Length + saltyArray.Length) {}
            Dim i As Integer
            For i = 0 To passwordInputStr.Length - 1
                hashingArray(i) = passByteArray(i)
            Next i
            For i = 0 To saltyArray.Length - 1
                hashingArray(passByteArray.Length + i) = saltyArray(i)
            Next i
            'Create MD5CryptoServiceProvider() object in order to hash the new array
            Dim hasher As HashAlgorithm = New MD5CryptoServiceProvider()
            hashingArray = hasher.ComputeHash(hashingArray)
            'Convert hashed array into a string and compare it with the one in the DB
            Dim hashedPass As String = Convert.ToBase64String(hashingArray)
            If hashedPass = LogIn(0).Item(2) Then
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LogInDBDataSet1.Table' table. You can move, or remove it, as needed.
        TableTableAdapter.Fill(LogInDBDataSet1.Table)
        Message.Text = ""
        Message.Visible = False
    End Sub
End Class
