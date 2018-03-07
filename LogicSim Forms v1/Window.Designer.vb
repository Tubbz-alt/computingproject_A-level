<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Window
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Window))
        Me.loader = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonCheck = New System.Windows.Forms.Timer(Me.components)
        Me.add_and = New System.Windows.Forms.Button()
        Me.add_nand = New System.Windows.Forms.Button()
        Me.add_or = New System.Windows.Forms.Button()
        Me.add_nor = New System.Windows.Forms.Button()
        Me.add_xor = New System.Windows.Forms.Button()
        Me.add_not = New System.Windows.Forms.Button()
        Me.add_input_true = New System.Windows.Forms.Button()
        Me.selected_gate = New System.Windows.Forms.Label()
        Me.add_output = New System.Windows.Forms.Button()
        Me.message_output = New System.Windows.Forms.Label()
        Me.add_input_false = New System.Windows.Forms.Button()
        Me.delete_all_gates = New System.Windows.Forms.Button()
        Me.custom_gate_input = New System.Windows.Forms.TextBox()
        Me.custom_gate_name = New System.Windows.Forms.TextBox()
        Me.loading_bar = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'add_and
        '
        Me.add_and.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_and.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_and.Location = New System.Drawing.Point(12, 4)
        Me.add_and.Name = "add_and"
        Me.add_and.Size = New System.Drawing.Size(125, 60)
        Me.add_and.TabIndex = 0
        Me.add_and.Text = "    AND"
        Me.add_and.UseVisualStyleBackColor = True
        '
        'add_nand
        '
        Me.add_nand.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_nand.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_nand.Location = New System.Drawing.Point(143, 4)
        Me.add_nand.Name = "add_nand"
        Me.add_nand.Size = New System.Drawing.Size(125, 60)
        Me.add_nand.TabIndex = 1
        Me.add_nand.Text = "     NAND"
        Me.add_nand.UseVisualStyleBackColor = True
        '
        'add_or
        '
        Me.add_or.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_or.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_or.Location = New System.Drawing.Point(274, 4)
        Me.add_or.Name = "add_or"
        Me.add_or.Size = New System.Drawing.Size(125, 60)
        Me.add_or.TabIndex = 2
        Me.add_or.Text = "        OR"
        Me.add_or.UseVisualStyleBackColor = True
        '
        'add_nor
        '
        Me.add_nor.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_nor.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_nor.Location = New System.Drawing.Point(405, 4)
        Me.add_nor.Name = "add_nor"
        Me.add_nor.Size = New System.Drawing.Size(125, 60)
        Me.add_nor.TabIndex = 3
        Me.add_nor.Text = "         NOR"
        Me.add_nor.UseVisualStyleBackColor = True
        '
        'add_xor
        '
        Me.add_xor.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_xor.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_xor.Location = New System.Drawing.Point(536, 4)
        Me.add_xor.Name = "add_xor"
        Me.add_xor.Size = New System.Drawing.Size(125, 60)
        Me.add_xor.TabIndex = 4
        Me.add_xor.Text = "         XOR"
        Me.add_xor.UseVisualStyleBackColor = True
        '
        'add_not
        '
        Me.add_not.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_not.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_not.Location = New System.Drawing.Point(667, 4)
        Me.add_not.Name = "add_not"
        Me.add_not.Size = New System.Drawing.Size(125, 60)
        Me.add_not.TabIndex = 5
        Me.add_not.Text = "   NOT"
        Me.add_not.UseVisualStyleBackColor = True
        '
        'add_input_true
        '
        Me.add_input_true.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_input_true.Location = New System.Drawing.Point(798, 2)
        Me.add_input_true.Name = "add_input_true"
        Me.add_input_true.Size = New System.Drawing.Size(64, 64)
        Me.add_input_true.TabIndex = 6
        Me.add_input_true.UseVisualStyleBackColor = True
        '
        'selected_gate
        '
        Me.selected_gate.AutoSize = True
        Me.selected_gate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selected_gate.Location = New System.Drawing.Point(465, 85)
        Me.selected_gate.Name = "selected_gate"
        Me.selected_gate.Size = New System.Drawing.Size(0, 22)
        Me.selected_gate.TabIndex = 7
        '
        'add_output
        '
        Me.add_output.Location = New System.Drawing.Point(936, 2)
        Me.add_output.Name = "add_output"
        Me.add_output.Size = New System.Drawing.Size(64, 64)
        Me.add_output.TabIndex = 11
        Me.add_output.UseVisualStyleBackColor = True
        '
        'message_output
        '
        Me.message_output.AutoSize = True
        Me.message_output.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.message_output.Location = New System.Drawing.Point(782, 81)
        Me.message_output.Name = "message_output"
        Me.message_output.Size = New System.Drawing.Size(0, 22)
        Me.message_output.TabIndex = 12
        '
        'add_input_false
        '
        Me.add_input_false.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_input_false.Location = New System.Drawing.Point(867, 2)
        Me.add_input_false.Name = "add_input_false"
        Me.add_input_false.Size = New System.Drawing.Size(64, 64)
        Me.add_input_false.TabIndex = 14
        Me.add_input_false.UseVisualStyleBackColor = True
        '
        'delete_all_gates
        '
        Me.delete_all_gates.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.delete_all_gates.Font = New System.Drawing.Font("Corbel", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delete_all_gates.Location = New System.Drawing.Point(12, 72)
        Me.delete_all_gates.Name = "delete_all_gates"
        Me.delete_all_gates.Size = New System.Drawing.Size(78, 45)
        Me.delete_all_gates.TabIndex = 15
        Me.delete_all_gates.Text = "RESET"
        Me.delete_all_gates.UseVisualStyleBackColor = True
        '
        'custom_gate_input
        '
        Me.custom_gate_input.Location = New System.Drawing.Point(270, 85)
        Me.custom_gate_input.Name = "custom_gate_input"
        Me.custom_gate_input.Size = New System.Drawing.Size(168, 20)
        Me.custom_gate_input.TabIndex = 16
        '
        'custom_gate_name
        '
        Me.custom_gate_name.Location = New System.Drawing.Point(96, 85)
        Me.custom_gate_name.Name = "custom_gate_name"
        Me.custom_gate_name.Size = New System.Drawing.Size(168, 20)
        Me.custom_gate_name.TabIndex = 17
        '
        'loading_bar
        '
        Me.loading_bar.Location = New System.Drawing.Point(12, 123)
        Me.loading_bar.Name = "loading_bar"
        Me.loading_bar.Size = New System.Drawing.Size(426, 20)
        Me.loading_bar.TabIndex = 18
        '
        'Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.delete_all_gates
        Me.ClientSize = New System.Drawing.Size(1014, 459)
        Me.Controls.Add(Me.loading_bar)
        Me.Controls.Add(Me.custom_gate_name)
        Me.Controls.Add(Me.custom_gate_input)
        Me.Controls.Add(Me.delete_all_gates)
        Me.Controls.Add(Me.add_input_false)
        Me.Controls.Add(Me.message_output)
        Me.Controls.Add(Me.add_output)
        Me.Controls.Add(Me.selected_gate)
        Me.Controls.Add(Me.add_input_true)
        Me.Controls.Add(Me.add_not)
        Me.Controls.Add(Me.add_xor)
        Me.Controls.Add(Me.add_nor)
        Me.Controls.Add(Me.add_or)
        Me.Controls.Add(Me.add_nand)
        Me.Controls.Add(Me.add_and)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1030, 500)
        Me.MinimumSize = New System.Drawing.Size(1030, 500)
        Me.Name = "Window"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LogicSim"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCheck As Timer
    Friend WithEvents loader As Timer
    Friend WithEvents add_and As Button
    Friend WithEvents add_nand As Button
    Friend WithEvents add_or As Button
    Friend WithEvents add_nor As Button
    Friend WithEvents add_xor As Button
    Friend WithEvents add_not As Button
    Friend WithEvents add_input_true As Button
    Friend WithEvents selected_gate As Label
    Friend WithEvents add_output As Button
    Friend WithEvents message_output As Label
    Friend WithEvents add_input_false As Button
    Friend WithEvents delete_all_gates As Button
    Friend WithEvents custom_gate_input As TextBox
    Friend WithEvents custom_gate_name As TextBox
    Friend WithEvents loading_bar As ProgressBar
End Class
