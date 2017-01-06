<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UsernameInput = New System.Windows.Forms.TextBox()
        Me.PasswordInput = New System.Windows.Forms.TextBox()
        Me.RegisterBtn = New System.Windows.Forms.Button()
        Me.SubmitBtn = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LogInDBDataSet1 = New SecureLogin.LogInDBDataSet()
        Me.TableTableAdapter = New SecureLogin.LogInDBDataSetTableAdapters.TableTableAdapter()
        Me.LogInDBDataSet = New SecureLogin.LogInDBDataSet()
        Me.LogInDBDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Message = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogInDBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogInDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogInDBDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'UsernameInput
        '
        Me.UsernameInput.Location = New System.Drawing.Point(67, 10)
        Me.UsernameInput.Name = "UsernameInput"
        Me.UsernameInput.Size = New System.Drawing.Size(250, 20)
        Me.UsernameInput.TabIndex = 2
        '
        'PasswordInput
        '
        Me.PasswordInput.Location = New System.Drawing.Point(67, 39)
        Me.PasswordInput.Name = "PasswordInput"
        Me.PasswordInput.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.PasswordInput.Size = New System.Drawing.Size(250, 20)
        Me.PasswordInput.TabIndex = 3
        '
        'RegisterBtn
        '
        Me.RegisterBtn.Location = New System.Drawing.Point(66, 91)
        Me.RegisterBtn.Name = "RegisterBtn"
        Me.RegisterBtn.Size = New System.Drawing.Size(75, 23)
        Me.RegisterBtn.TabIndex = 4
        Me.RegisterBtn.Text = "Register"
        Me.RegisterBtn.UseVisualStyleBackColor = True
        '
        'SubmitBtn
        '
        Me.SubmitBtn.Location = New System.Drawing.Point(243, 91)
        Me.SubmitBtn.Name = "SubmitBtn"
        Me.SubmitBtn.Size = New System.Drawing.Size(75, 23)
        Me.SubmitBtn.TabIndex = 5
        Me.SubmitBtn.Text = "Submit"
        Me.SubmitBtn.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Table"
        Me.BindingSource1.DataSource = Me.LogInDBDataSet1
        '
        'LogInDBDataSet1
        '
        Me.LogInDBDataSet1.DataSetName = "LogInDBDataSet"
        Me.LogInDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableTableAdapter
        '
        Me.TableTableAdapter.ClearBeforeFill = True
        '
        'LogInDBDataSet
        '
        Me.LogInDBDataSet.DataSetName = "LogInDBDataSet"
        Me.LogInDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LogInDBDataSetBindingSource
        '
        Me.LogInDBDataSetBindingSource.DataSource = Me.LogInDBDataSet
        Me.LogInDBDataSetBindingSource.Position = 0
        '
        'Message
        '
        Me.Message.AutoSize = True
        Me.Message.Location = New System.Drawing.Point(8, 73)
        Me.Message.Name = "Message"
        Me.Message.Size = New System.Drawing.Size(50, 13)
        Me.Message.TabIndex = 6
        Me.Message.Text = "Message"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 119)
        Me.Controls.Add(Me.Message)
        Me.Controls.Add(Me.SubmitBtn)
        Me.Controls.Add(Me.RegisterBtn)
        Me.Controls.Add(Me.PasswordInput)
        Me.Controls.Add(Me.UsernameInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Secure log in"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogInDBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogInDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogInDBDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents UsernameInput As TextBox
    Friend WithEvents PasswordInput As TextBox
    Friend WithEvents RegisterBtn As Button
    Friend WithEvents SubmitBtn As Button
    Friend WithEvents LogInDBDataSet1 As LogInDBDataSet
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents TableTableAdapter As LogInDBDataSetTableAdapters.TableTableAdapter
    Friend WithEvents LogInDBDataSetBindingSource As BindingSource
    Friend WithEvents LogInDBDataSet As LogInDBDataSet
    Friend WithEvents Message As Label
End Class
