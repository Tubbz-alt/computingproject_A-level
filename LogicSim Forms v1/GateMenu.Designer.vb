<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GateMenu
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
        Me.addAnd = New System.Windows.Forms.Button()
        Me.addNand = New System.Windows.Forms.Button()
        Me.addOr = New System.Windows.Forms.Button()
        Me.addXor = New System.Windows.Forms.Button()
        Me.addNor = New System.Windows.Forms.Button()
        Me.addNot = New System.Windows.Forms.Button()
        Me.gateName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.addOutput = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lastID = New System.Windows.Forms.TextBox()
        Me.addInputOff = New System.Windows.Forms.Button()
        Me.addInputOn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'addAnd
        '
        Me.addAnd.Location = New System.Drawing.Point(104, 92)
        Me.addAnd.Name = "addAnd"
        Me.addAnd.Size = New System.Drawing.Size(83, 41)
        Me.addAnd.TabIndex = 4
        Me.addAnd.Text = "AND"
        Me.addAnd.UseVisualStyleBackColor = True
        '
        'addNand
        '
        Me.addNand.Location = New System.Drawing.Point(193, 92)
        Me.addNand.Name = "addNand"
        Me.addNand.Size = New System.Drawing.Size(83, 41)
        Me.addNand.TabIndex = 5
        Me.addNand.Text = "NAND"
        Me.addNand.UseVisualStyleBackColor = True
        '
        'addOr
        '
        Me.addOr.Location = New System.Drawing.Point(282, 92)
        Me.addOr.Name = "addOr"
        Me.addOr.Size = New System.Drawing.Size(83, 41)
        Me.addOr.TabIndex = 6
        Me.addOr.Text = "OR"
        Me.addOr.UseVisualStyleBackColor = True
        '
        'addXor
        '
        Me.addXor.Location = New System.Drawing.Point(104, 151)
        Me.addXor.Name = "addXor"
        Me.addXor.Size = New System.Drawing.Size(83, 41)
        Me.addXor.TabIndex = 7
        Me.addXor.Text = "XOR"
        Me.addXor.UseVisualStyleBackColor = True
        '
        'addNor
        '
        Me.addNor.Location = New System.Drawing.Point(193, 151)
        Me.addNor.Name = "addNor"
        Me.addNor.Size = New System.Drawing.Size(83, 41)
        Me.addNor.TabIndex = 8
        Me.addNor.Text = "NOR"
        Me.addNor.UseVisualStyleBackColor = True
        '
        'addNot
        '
        Me.addNot.Location = New System.Drawing.Point(282, 151)
        Me.addNot.Name = "addNot"
        Me.addNot.Size = New System.Drawing.Size(83, 41)
        Me.addNot.TabIndex = 9
        Me.addNot.Text = "NOT"
        Me.addNot.UseVisualStyleBackColor = True
        '
        'gateName
        '
        Me.gateName.Location = New System.Drawing.Point(15, 34)
        Me.gateName.Name = "gateName"
        Me.gateName.Size = New System.Drawing.Size(107, 20)
        Me.gateName.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Optional Gate Name"
        '
        'addOutput
        '
        Me.addOutput.Location = New System.Drawing.Point(371, 92)
        Me.addOutput.Name = "addOutput"
        Me.addOutput.Size = New System.Drawing.Size(83, 100)
        Me.addOutput.TabIndex = 12
        Me.addOutput.Text = "OUTPUT"
        Me.addOutput.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Previous Gate ID"
        '
        'lastID
        '
        Me.lastID.Location = New System.Drawing.Point(151, 34)
        Me.lastID.Name = "lastID"
        Me.lastID.Size = New System.Drawing.Size(125, 20)
        Me.lastID.TabIndex = 15
        '
        'addInputOff
        '
        Me.addInputOff.Location = New System.Drawing.Point(15, 153)
        Me.addInputOff.Name = "addInputOff"
        Me.addInputOff.Size = New System.Drawing.Size(83, 41)
        Me.addInputOff.TabIndex = 16
        Me.addInputOff.Text = "INPUT OFF"
        Me.addInputOff.UseVisualStyleBackColor = True
        '
        'addInputOn
        '
        Me.addInputOn.Location = New System.Drawing.Point(15, 92)
        Me.addInputOn.Name = "addInputOn"
        Me.addInputOn.Size = New System.Drawing.Size(83, 41)
        Me.addInputOn.TabIndex = 17
        Me.addInputOn.Text = "INPUT ON"
        Me.addInputOn.UseVisualStyleBackColor = True
        '
        'GateMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 206)
        Me.Controls.Add(Me.addInputOn)
        Me.Controls.Add(Me.addInputOff)
        Me.Controls.Add(Me.lastID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.addOutput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gateName)
        Me.Controls.Add(Me.addNot)
        Me.Controls.Add(Me.addNor)
        Me.Controls.Add(Me.addXor)
        Me.Controls.Add(Me.addOr)
        Me.Controls.Add(Me.addNand)
        Me.Controls.Add(Me.addAnd)
        Me.Name = "GateMenu"
        Me.Text = "Add Gate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents addAnd As Button
    Friend WithEvents addNand As Button
    Friend WithEvents addOr As Button
    Friend WithEvents addXor As Button
    Friend WithEvents addNor As Button
    Friend WithEvents addNot As Button
    Friend WithEvents gateName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents addOutput As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lastID As TextBox
    Friend WithEvents addInputOff As Button
    Friend WithEvents addInputOn As Button
End Class
