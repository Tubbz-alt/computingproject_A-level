<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Me.start_prof = New System.Windows.Forms.Button()
        Me.start_nonprof = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'start_prof
        '
        Me.start_prof.Font = New System.Drawing.Font("Corbel", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_prof.Location = New System.Drawing.Point(10, 19)
        Me.start_prof.Name = "start_prof"
        Me.start_prof.Size = New System.Drawing.Size(260, 54)
        Me.start_prof.TabIndex = 0
        Me.start_prof.Text = "PROFESSIONAL MODE"
        Me.start_prof.UseVisualStyleBackColor = True
        '
        'start_nonprof
        '
        Me.start_nonprof.Font = New System.Drawing.Font("Comic Sans MS", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_nonprof.Location = New System.Drawing.Point(2, 112)
        Me.start_nonprof.Name = "start_nonprof"
        Me.start_nonprof.Size = New System.Drawing.Size(280, 31)
        Me.start_nonprof.TabIndex = 2
        Me.start_nonprof.Text = "Child Mode (Fun Icons Mode)"
        Me.start_nonprof.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.start_prof)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 94)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 155)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.start_nonprof)
        Me.Name = "SplashScreen"
        Me.Text = "LogicSim"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents start_prof As Button
    Friend WithEvents start_nonprof As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
