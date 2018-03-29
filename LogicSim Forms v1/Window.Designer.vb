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
        Me.switch_mode = New System.Windows.Forms.Button()
        Me.invert_input = New System.Windows.Forms.Button()
        Me.add_clock = New System.Windows.Forms.Button()
        Me.clock_interval_input = New System.Windows.Forms.TextBox()
        Me.change_clock_interval = New System.Windows.Forms.Button()
        Me.ClockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.save_current_layout = New System.Windows.Forms.Button()
        Me.browse_for_preset = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'add_and
        '
        Me.add_and.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_and.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.add_and.Location = New System.Drawing.Point(6, 19)
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
        Me.add_nand.Location = New System.Drawing.Point(137, 19)
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
        Me.add_or.Location = New System.Drawing.Point(268, 19)
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
        Me.add_nor.Location = New System.Drawing.Point(399, 19)
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
        Me.add_xor.Location = New System.Drawing.Point(530, 19)
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
        Me.add_not.Location = New System.Drawing.Point(661, 19)
        Me.add_not.Name = "add_not"
        Me.add_not.Size = New System.Drawing.Size(125, 60)
        Me.add_not.TabIndex = 5
        Me.add_not.Text = "   NOT"
        Me.add_not.UseVisualStyleBackColor = True
        '
        'add_input_true
        '
        Me.add_input_true.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_input_true.Location = New System.Drawing.Point(6, 19)
        Me.add_input_true.Name = "add_input_true"
        Me.add_input_true.Size = New System.Drawing.Size(64, 64)
        Me.add_input_true.TabIndex = 6
        Me.add_input_true.UseVisualStyleBackColor = True
        '
        'selected_gate
        '
        Me.selected_gate.AutoSize = True
        Me.selected_gate.Font = New System.Drawing.Font("Corbel", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selected_gate.Location = New System.Drawing.Point(12, 190)
        Me.selected_gate.Name = "selected_gate"
        Me.selected_gate.Size = New System.Drawing.Size(0, 24)
        Me.selected_gate.TabIndex = 7
        '
        'add_output
        '
        Me.add_output.Location = New System.Drawing.Point(6, 19)
        Me.add_output.Name = "add_output"
        Me.add_output.Size = New System.Drawing.Size(64, 64)
        Me.add_output.TabIndex = 11
        Me.add_output.UseVisualStyleBackColor = True
        '
        'message_output
        '
        Me.message_output.AutoSize = True
        Me.message_output.Font = New System.Drawing.Font("Corbel", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.message_output.Location = New System.Drawing.Point(180, 190)
        Me.message_output.Name = "message_output"
        Me.message_output.Size = New System.Drawing.Size(0, 24)
        Me.message_output.TabIndex = 12
        '
        'add_input_false
        '
        Me.add_input_false.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_input_false.Location = New System.Drawing.Point(76, 19)
        Me.add_input_false.Name = "add_input_false"
        Me.add_input_false.Size = New System.Drawing.Size(64, 64)
        Me.add_input_false.TabIndex = 14
        Me.add_input_false.UseVisualStyleBackColor = True
        '
        'delete_all_gates
        '
        Me.delete_all_gates.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.delete_all_gates.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delete_all_gates.Location = New System.Drawing.Point(136, 14)
        Me.delete_all_gates.Name = "delete_all_gates"
        Me.delete_all_gates.Size = New System.Drawing.Size(78, 45)
        Me.delete_all_gates.TabIndex = 15
        Me.delete_all_gates.Text = "RESET"
        Me.delete_all_gates.UseVisualStyleBackColor = True
        '
        'custom_gate_input
        '
        Me.custom_gate_input.Location = New System.Drawing.Point(129, 19)
        Me.custom_gate_input.Name = "custom_gate_input"
        Me.custom_gate_input.Size = New System.Drawing.Size(117, 20)
        Me.custom_gate_input.TabIndex = 16
        '
        'custom_gate_name
        '
        Me.custom_gate_name.Location = New System.Drawing.Point(6, 19)
        Me.custom_gate_name.Name = "custom_gate_name"
        Me.custom_gate_name.Size = New System.Drawing.Size(117, 20)
        Me.custom_gate_name.TabIndex = 17
        '
        'loading_bar
        '
        Me.loading_bar.Location = New System.Drawing.Point(285, 181)
        Me.loading_bar.Name = "loading_bar"
        Me.loading_bar.Size = New System.Drawing.Size(387, 20)
        Me.loading_bar.TabIndex = 18
        '
        'switch_mode
        '
        Me.switch_mode.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.switch_mode.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.switch_mode.Location = New System.Drawing.Point(6, 14)
        Me.switch_mode.Name = "switch_mode"
        Me.switch_mode.Size = New System.Drawing.Size(124, 45)
        Me.switch_mode.TabIndex = 19
        Me.switch_mode.Text = "SWITCH MODE"
        Me.switch_mode.UseVisualStyleBackColor = True
        '
        'invert_input
        '
        Me.invert_input.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.invert_input.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invert_input.Location = New System.Drawing.Point(220, 14)
        Me.invert_input.Name = "invert_input"
        Me.invert_input.Size = New System.Drawing.Size(78, 45)
        Me.invert_input.TabIndex = 20
        Me.invert_input.Text = "INVERT INPUT"
        Me.invert_input.UseVisualStyleBackColor = True
        '
        'add_clock
        '
        Me.add_clock.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.add_clock.Location = New System.Drawing.Point(7, 89)
        Me.add_clock.Name = "add_clock"
        Me.add_clock.Size = New System.Drawing.Size(133, 45)
        Me.add_clock.TabIndex = 21
        Me.add_clock.Text = "CLOCK"
        Me.add_clock.UseVisualStyleBackColor = True
        '
        'clock_interval_input
        '
        Me.clock_interval_input.Location = New System.Drawing.Point(7, 140)
        Me.clock_interval_input.Name = "clock_interval_input"
        Me.clock_interval_input.Size = New System.Drawing.Size(58, 20)
        Me.clock_interval_input.TabIndex = 22
        '
        'change_clock_interval
        '
        Me.change_clock_interval.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.change_clock_interval.Location = New System.Drawing.Point(71, 139)
        Me.change_clock_interval.Name = "change_clock_interval"
        Me.change_clock_interval.Size = New System.Drawing.Size(69, 23)
        Me.change_clock_interval.TabIndex = 23
        Me.change_clock_interval.Text = "CHANGE"
        Me.change_clock_interval.UseVisualStyleBackColor = True
        '
        'ClockTimer
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.add_and)
        Me.GroupBox1.Controls.Add(Me.add_nand)
        Me.GroupBox1.Controls.Add(Me.add_or)
        Me.GroupBox1.Controls.Add(Me.add_nor)
        Me.GroupBox1.Controls.Add(Me.add_xor)
        Me.GroupBox1.Controls.Add(Me.add_not)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 88)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Logic Gates"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.add_input_true)
        Me.GroupBox2.Controls.Add(Me.add_input_false)
        Me.GroupBox2.Controls.Add(Me.change_clock_interval)
        Me.GroupBox2.Controls.Add(Me.add_clock)
        Me.GroupBox2.Controls.Add(Me.clock_interval_input)
        Me.GroupBox2.Location = New System.Drawing.Point(800, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(150, 180)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inputs"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.add_output)
        Me.GroupBox3.Location = New System.Drawing.Point(718, 91)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(76, 92)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Output"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.switch_mode)
        Me.GroupBox4.Controls.Add(Me.invert_input)
        Me.GroupBox4.Controls.Add(Me.delete_all_gates)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 96)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(304, 68)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tools"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.save_current_layout)
        Me.GroupBox5.Controls.Add(Me.browse_for_preset)
        Me.GroupBox5.Controls.Add(Me.custom_gate_name)
        Me.GroupBox5.Controls.Add(Me.custom_gate_input)
        Me.GroupBox5.Location = New System.Drawing.Point(313, 104)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(399, 60)
        Me.GroupBox5.TabIndex = 28
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Extra Options"
        '
        'save_current_layout
        '
        Me.save_current_layout.Location = New System.Drawing.Point(263, 31)
        Me.save_current_layout.Name = "save_current_layout"
        Me.save_current_layout.Size = New System.Drawing.Size(130, 23)
        Me.save_current_layout.TabIndex = 32
        Me.save_current_layout.Text = "Save Current Layout"
        Me.save_current_layout.UseVisualStyleBackColor = True
        '
        'browse_for_preset
        '
        Me.browse_for_preset.Location = New System.Drawing.Point(263, 9)
        Me.browse_for_preset.Name = "browse_for_preset"
        Me.browse_for_preset.Size = New System.Drawing.Size(130, 23)
        Me.browse_for_preset.TabIndex = 31
        Me.browse_for_preset.Text = "Browse for Preset"
        Me.browse_for_preset.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.loading_bar)
        Me.GroupBox6.Location = New System.Drawing.Point(-15, 180)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1039, 10)
        Me.GroupBox6.TabIndex = 29
        Me.GroupBox6.TabStop = False
        '
        'Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.delete_all_gates
        Me.ClientSize = New System.Drawing.Size(964, 559)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.message_output)
        Me.Controls.Add(Me.selected_gate)
        Me.Controls.Add(Me.GroupBox6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(980, 600)
        Me.MinimumSize = New System.Drawing.Size(980, 600)
        Me.Name = "Window"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LogicSim"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents switch_mode As Button
    Friend WithEvents invert_input As Button
    Friend WithEvents add_clock As Button
    Friend WithEvents clock_interval_input As TextBox
    Friend WithEvents change_clock_interval As Button
    Friend WithEvents ClockTimer As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents browse_for_preset As Button
    Friend WithEvents save_current_layout As Button
End Class
