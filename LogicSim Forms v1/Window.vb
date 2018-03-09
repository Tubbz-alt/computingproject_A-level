Imports VB = Microsoft.VisualBasic
Imports System.Runtime.InteropServices
'BUG IN ATTACHGATE/DELTEGATE GATE INPUTS NOT UPDATED WHEN GATES ARE DELETED
Class Window
    Private profMode As Boolean
    Private oneSelected As Boolean = False
    Private tempID As Integer
    Private prevValue As Integer
    Private prevID As Integer
    Private tempInputID As Integer
    Private comicSansFont As New Font("Comic Sans MS", 9, FontStyle.Regular)
    Private corbelFont As New Font("Corbel", 10, FontStyle.Regular)
    Private g As Graphics
    Private blackPen As New Pen(Color.Black, 4)
    Private bluePen As New Pen(Color.Blue, 4)
    Private redPen As New Pen(Color.Red, 4)
    Private tempImage As Image
    Private inputImageTrue As Image
    Private inputImageFalse As Image
    Private outputImageNull As Image
    Private outputImageTrue As Image
    Private outputImageFalse As Image
    Private andImage As Image
    Private nandImage As Image
    Private orImage As Image
    Private norImage As Image
    Private xorImage As Image
    Private notImage As Image
    Protected Point As Point
    Private ValidPB As Boolean
    Protected GatePB As New List(Of PictureBox)
    Private connections(199, 199, 1) As Connection
    Protected Gates() As MultiGate
    Public gatecount As Integer
    Protected nextpoint As Integer
    Protected LastID As Integer
    Private Sub WindowCloser(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        End
    End Sub
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function
    Private Sub WindowStart()      'Sets initial values for gate variables
        g = CreateGraphics()
        ReDim Gates(199)
        ReDim connections(199, 199, 1)
        gatecount = 0
        prevValue = 2
        ModeSwitch()
        For i As Integer = 0 To 199
            Gates(i) = New MultiGate(i)
        Next
        For k = 0 To 1
            For i = 0 To 199
                For j = 0 To 199
                    connections(i, j, k) = New Connection
                Next
            Next
        Next
        loading_bar.Hide()
        SendMessage(Me.custom_gate_input.Handle, &H1501, 0, "Add a cutsom number of gates...")
        SendMessage(Me.custom_gate_name.Handle, &H1501, 0, "Add a cutsom gate name...")
    End Sub
    Private Sub ModeSwitch()
        If profMode = True Then
            inputImageTrue = My.Resources.INPUTTRUEP
            inputImageFalse = My.Resources.INPUTFALSEP
            add_input_true.Image = inputImageTrue
            add_input_false.Image = inputImageFalse
            outputImageNull = My.Resources.OUTPUTNULLP
            outputImageTrue = My.Resources.OUTPUTTRUEP
            outputImageFalse = My.Resources.OUTPUTFALSEP
            add_output.Image = outputImageFalse
            andImage = My.Resources._ANDP
            add_and.Image = andImage
            add_and.Text = "    AND"
            nandImage = My.Resources._NANDP
            add_nand.Image = nandImage
            add_nand.Text = "     NAND"
            orImage = My.Resources._ORP
            add_or.Image = orImage
            add_or.Text = "        OR"
            norImage = My.Resources.NORP
            add_nor.Image = norImage
            add_nor.Text = "         NOR"
            xorImage = My.Resources._XORP
            add_xor.Image = xorImage
            add_xor.Text = "         XOR"
            notImage = My.Resources._NOTP
            add_not.Image = notImage
            add_not.Text = "   NOT"
            delete_all_gates.Font = corbelFont
            message_output.Font = corbelFont
            selected_gate.Font = corbelFont
            switch_mode.Font = corbelFont
        Else
            inputImageTrue = My.Resources.INPUTTRUE
            inputImageFalse = My.Resources.INPUTFALSE
            add_input_true.Image = inputImageTrue
            add_input_false.Image = inputImageFalse
            outputImageNull = My.Resources.OUTPUTNULL
            outputImageTrue = My.Resources.OUTPUTTRUE
            outputImageFalse = My.Resources.OUTPUTFALSE
            add_output.Image = outputImageFalse
            andImage = My.Resources._AND
            add_and.Image = andImage
            add_and.Text = ""
            nandImage = My.Resources.NAND
            add_nand.Image = nandImage
            add_nand.Text = ""
            orImage = My.Resources._OR
            add_or.Image = orImage
            add_or.Text = ""
            norImage = My.Resources.NOR
            add_nor.Image = norImage
            add_nor.Text = ""
            xorImage = My.Resources._XOR
            add_xor.Image = xorImage
            add_xor.Text = ""
            notImage = My.Resources._NOT
            add_not.Image = notImage
            add_not.Text = ""
            delete_all_gates.Font = comicSansFont
            message_output.Font = comicSansFont
            selected_gate.Font = comicSansFont
            switch_mode.Font = comicSansFont
        End If
        If GatePB.Count <> 0 Then
            For Each PB In GatePB
                If Gates(PB.Name).gateType = "inputt" Then
                    PB.Image = inputImageTrue
                ElseIf Gates(PB.Name).gateType = "inputf" Then
                    PB.Image = inputImageFalse
                ElseIf Gates(PB.Name).gateType = "output" Then
                    If Gates(PB.Name).gateValue = 2 Then
                        PB.Image = outputImageNull
                    ElseIf Gates(PB.Name).gateValue = 1 Then
                        PB.Image = outputImageTrue
                    Else
                        PB.Image = outputImageFalse
                    End If
                ElseIf Gates(PB.Name).gateType = "and" Then
                    PB.Image = andImage
                ElseIf Gates(PB.Name).gateType = "nand" Then
                    PB.Image = nandImage
                ElseIf Gates(PB.Name).gateType = "or" Then
                    PB.Image = orImage
                ElseIf Gates(PB.Name).gateType = "nor" Then
                    PB.Image = norImage
                ElseIf Gates(PB.Name).gateType = "xor" Then
                    PB.Image = xorImage
                ElseIf Gates(PB.Name).gateType = "not" Then
                    PB.Image = notImage
                End If
            Next
        End If
    End Sub
    Public Function getWindowConnectionsValue(ByVal i As Integer, ByVal j As Integer, ByVal k As Integer)
        Return connections(i, j, k).connectionValue
    End Function
    Private Property MousePoint As Point
        Get
            Return Point
        End Get
        Set(givenPoint As Point)
            Point = givenPoint
        End Set
    End Property
    Public Property windowProf As Boolean
        Get
            Return profMode
        End Get
        Set(value As Boolean)
            profMode = value
        End Set
    End Property
    Private Sub WindowLoader(sender As Object, e As EventArgs) Handles MyBase.Load
        loader.Enabled = True
        WindowStart()                   'Calls the sub that redims gate arrays and constructs gate objects using these arrays
        loader.Enabled = False
        ButtonCheck.Enabled = True
    End Sub
    Private Sub RefreshGraphics()
        For Each PB In GatePB
            If Gates(PB.Name).gateType = "output" And Gates(PB.Name).gateValue = 1 Then          'Refreshes gate PBs with dynamic states pictures
                PB.Image = outputImageTrue
            ElseIf Gates(PB.Name).gateType = "output" And Gates(PB.Name).gateValue = 0 Then
                PB.Image = outputImageFalse
            ElseIf Gates(PB.Name).gateType = "output" And Gates(PB.Name).gateValue = 2 Then
                PB.Image = outputImageNull
            End If
        Next
        Me.Refresh()              'Graphics refresh
        For k = 0 To 1                                      '          || ||
            For i = 0 To 199                                'This mess \/ \/  is responsible for assigning connection graphics to the correct part of each gate
                For j = 0 To 199
                    If connections(i, j, k).connectionExists = True And k = 0 Then
                        If (Gates(j).gateType = "not" Or Gates(j).gateType = "output") And Gates(i).gateValue = 1 Then

                            If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                g.DrawLine(bluePen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 30))
                            Else
                                g.DrawLine(bluePen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 30))
                            End If

                        ElseIf (Gates(j).gateType = "not" Or Gates(j).gateType = "output") And Gates(i).gateValue = 0 Then

                            If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                g.DrawLine(blackPen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 30))
                            Else
                                g.DrawLine(blackPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 30))
                            End If

                        ElseIf (Gates(j).gateType = "not" Or Gates(j).gateType = "output") And Gates(i).gateValue = 2 Then

                            If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                g.DrawLine(redPen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 30))
                            Else
                                g.DrawLine(redPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 30))
                            End If

                        Else

                            If Gates(i).gateValue = 1 Then

                                If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                    g.DrawLine(bluePen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                                Else
                                    g.DrawLine(bluePen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                                End If

                            ElseIf Gates(i).gateValue = 0

                                If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                    g.DrawLine(blackPen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                                Else
                                    g.DrawLine(blackPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                                End If

                            Else

                                If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                    g.DrawLine(redPen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                                Else
                                    g.DrawLine(redPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                                End If

                            End If
                        End If
                    End If
                    If connections(i, j, k).connectionExists = True And k = 1 Then
                        If Gates(i).gateValue = 1 Then

                            If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                g.DrawLine(bluePen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                            Else
                                g.DrawLine(bluePen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                            End If

                        ElseIf Gates(i).gateValue = 0

                            If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                g.DrawLine(blackPen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                            Else
                                g.DrawLine(blackPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                            End If

                        Else

                            If Gates(i).gateType = "inputt" Or Gates(i).gateType = "inputf" Or Gates(i).gateType = "output" Then
                                g.DrawLine(redPen, (Gates(i).gateXpos + 30), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                            Else
                                g.DrawLine(redPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                            End If

                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub PBs_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim PB As PictureBox = DirectCast(sender, PictureBox)
        Dim ID = PB.Name
        Point = e.Location
        If e.Button = MouseButtons.Left Then                               'If it is a left click then the gate is 'selected' and details are shown
            If Gates(PB.Name).gateType = "inputt" Or Gates(PB.Name).gateType = "inputf" Then
                tempInputID = PB.Name
            Else
                tempInputID = -1
            End If
            If PB.Location.X >= 0 Or PB.Location.X <= Me.Width Or PB.Location.Y >= 0 Or PB.Location.Y <= Me.Height Then
                ValidPB = True
            End If
            displayGateInfo(PB.Name)
        End If
        If e.Button = MouseButtons.Right Then                         'If it is a right click then the gate is being attached and the AttachGate sub is run.
            If ID = prevID And oneSelected = True And profMode = True Then
                DeleteGate(PB)
                oneSelected = False
                message_output.Text = ""
            ElseIf ID = prevID And oneSelected = True And profMode = False Then
                message_output.Text = "To delete gates In child mode 
use the RESET button"
            Else
                AttachGate(oneSelected, prevValue, prevID, ID)
            End If
        End If
    End Sub
    Private Sub PBs_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim PB As PictureBox = DirectCast(sender, PictureBox)
        If e.Button = MouseButtons.Left And ValidPB Then               'If mouse is down, moving and the mouse is in valid bounds then the gate moves
            PB.Left += e.Location.X - Point.X
            PB.Top += e.Location.Y - Point.Y
            Gates(PB.Name).gateXpos = PB.Left
            Gates(PB.Name).gateYpos = Me.Height - PB.Top
            If PB.Left < 0 Then                                        'If gate is out of bounds, x/y coords are reset to valid ones
                PB.Left = 0
                ValidPB = False
            ElseIf PB.Left > (Me.Width - 130) Then
                PB.Left = (Me.Width - 140)
                ValidPB = False
            ElseIf PB.Top < 50 Then
                PB.Top = 60
                ValidPB = False
            ElseIf PB.Top > (Me.Height - 90) Then
                PB.Top = (Me.Height - 100)
                ValidPB = False
            End If
            RefreshGraphics()
        End If
    End Sub
    Private Sub displayGateInfo(ByVal ID As Integer)
        Dim value As String
        If ID <> -1 Then
            If Gates(ID).gateValue = 2 Then
                value = "NULL"
            ElseIf Gates(ID).gateValue = 1 Then
                value = "TRUE"
            ElseIf Gates(ID).gateValue = 0 Then
                value = "FALSE"
            End If
            selected_gate.Text = "Selected Gate ID: " & ID & " 
Gate Type: " & (Gates(ID).gateType).ToUpper & "
Current Value: " & value & "
Gate Name: " & (Gates(ID).gateName).ToUpper
        Else
        End If
    End Sub
    Private Sub RecalculateInputs(ByVal ID As Integer)
        For j = 0 To 199
            If connections(ID, j, 0).connectionValue <> 2 Or connections(ID, j, 1).connectionValue <> 2 Then
                If connections(ID, j, 0).connectionValue <> 2 Then
                    connections(ID, j, 0).connectionValue = Gates(ID).gateValue
                End If
                If connections(ID, j, 1).connectionValue <> 2 Then
                    connections(ID, j, 1).connectionValue = Gates(ID).gateValue
                End If
                Gates(j).Calculate(j)
            End If
        Next
    End Sub
    Private Sub AttachGate(ByRef oneSelected As Boolean, ByRef prevValue As Integer, ByRef prevID As Integer, ByVal ID As Integer)
        If oneSelected = True Then                                                     'This means the gate is having a value assigned to one of its inputs from another gates output
            If Gates(ID).gateType <> "inputt" Or Gates(ID).gateType <> "inputf" Then
                If Gates(prevID).gateValue <> 2 Then
                    If Gates(ID).gateType = "not" Or Gates(ID).gateType = "output" Then
                        If Gates(ID).gateInput1Exists = False Then
                            message_output.Text = "Assigned input 
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue                                         'The prevValue is assigned to an input
                            Gates(ID).gateInput1 = prevValue
                            connections(prevID, ID, 0).connectionOrigin = prevID
                            connections(prevID, ID, 0).connectionDestination = ID
                            connections(prevID, ID, 0).connectionValue = Gates(prevID).gateValue
                            connections(prevID, ID, 0).connectionExists = True
                            Gates(ID).gateInput1Exists = True
                            Gates(ID).Calculate(ID)
                        Else
                            message_output.Text = "The input is already occupied"
                        End If
                    Else
                        If Gates(ID).gateInput1Exists = False Then
                            message_output.Text = "Assigned input (1) 
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue                                         'The prevValue is assigned to an input
                            Gates(ID).gateInput1 = prevValue
                            connections(prevID, ID, 0).connectionOrigin = prevID
                            connections(prevID, ID, 0).connectionDestination = ID
                            connections(prevID, ID, 0).connectionValue = Gates(prevID).gateValue
                            connections(prevID, ID, 0).connectionExists = True
                            Gates(ID).gateInput1Exists = True
                            Gates(ID).Calculate(ID)
                        ElseIf Gates(ID).gateInput2Exists = False Then
                            message_output.Text = "Assigned input (2)
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue
                            Gates(ID).gateInput2 = prevValue
                            connections(prevID, ID, 1).connectionOrigin = prevID
                            connections(prevID, ID, 1).connectionDestination = ID
                            connections(prevID, ID, 1).connectionValue = Gates(prevID).gateValue
                            connections(prevID, ID, 1).connectionExists = True
                            Gates(ID).gateInput2Exists = True
                            Gates(ID).Calculate(ID)
                        Else
                            message_output.Text = "Both inputs are 
already occupied"
                        End If
                    End If
                Else
                    message_output.Text = "Gates cannot be 
assigned null 
values (yet)"
                End If
            Else
                message_output.Text = "Input values are 
fixed and cannot be 
assigned by another 
gate"
            End If
            oneSelected = False
            RefreshGraphics()
        ElseIf oneSelected = False Then                         'This means the gate is before another gate in the circuit
            message_output.Text = (Gates(ID).gateType).ToUpper & " gate 1 selected...
Right-Click again to delete"
            prevValue = Gates(ID).gateValue             'The global variable prevValue is assigned this value
            prevID = ID
            oneSelected = True
        End If
        displayGateInfo(ID)
    End Sub
    Private Sub AddGatePB(ByVal choice As String, ByVal tempID As Integer)
        oneSelected = False
        message_output.Text = ""
        Dim PB As New PictureBox
        PB.Height = 60                              'Sets dimensions and properties of gate PB
        PB.Width = 125
        PB.Left = 515 - (PB.Width / 2)
        PB.Top = Me.ClientRectangle.Height - PB.Height
        AddHandler PB.MouseDown, AddressOf PBs_MouseDown
        AddHandler PB.MouseMove, AddressOf PBs_MouseMove
        PB.Parent = Me
        If choice = "inputt" Then
            PB.Height = 60
            PB.Width = 60
            PB.Image = inputImageTrue
        ElseIf choice = "inputf" Then
            PB.Height = 60
            PB.Width = 60
            PB.Image = inputImageFalse
        ElseIf choice = "output" Then
            PB.Height = 60
            PB.Width = 60
            PB.Image = outputImageNull
        ElseIf choice = "and" Then
            PB.Image = andImage
        ElseIf choice = "nand" Then
            PB.Image = nandImage
        ElseIf choice = "or" Then
            PB.Image = orImage
        ElseIf choice = "nor" Then
            PB.Image = norImage
        ElseIf choice = "xor" Then
            PB.Image = xorImage
        ElseIf choice = "not" Then
            PB.Image = notImage
        End If
        PB.Name = tempID             '---IMPORTANT---Gate name is set as the gate ID so the gate object can be referenced from the gate PB
        GatePB.Add(PB)               'Gate PB is added to PB list
        Gates(PB.Name).gateXpos = PB.Left
        Gates(PB.Name).gateYpos = Me.Height - PB.Top
    End Sub
    Private Sub newGate(ByVal choice As String)
        Dim multgate As Integer
        Dim validName As Boolean = True
        Try
            multgate = custom_gate_input.Text
        Catch
            multgate = 1
        End Try
        custom_gate_input.Text = ""
        For i = 0 To 199
            If custom_gate_name.Text = Gates(i).gateName And Gates(i).gateName <> "" Then
                validName = False
                Exit For
            End If
        Next
        If gatecount + multgate <= 200 And validName = True Then
            For o = 0 To multgate - 1
                Dim tempID As Integer
                If gatecount < 200 Then
                    For i As Integer = 0 To 199
                        If Gates(i).gateIsNull = True Then                  'Cycles through the array of objects with a loop and finds an unused one
                            Gates(i).gateIsNull = False                     'Sets it to 'Not Null'
                            Gates(i).gateType = choice                      'Sets the 'Type' variable to the choice
                            Gates(i).gateName = custom_gate_name.Text       'Sets the optional gate name
                            If choice = "inputt" Then                       'Sets the preset value that the gate starts with
                                Gates(i).gateValue = 1
                            ElseIf choice = "inputf" Then
                                Gates(i).gateValue = 0
                            ElseIf choice = "output" Then
                                Gates(i).gateValue = 2
                                Gates(i).gateInput1 = 2
                            Else
                                Gates(i).gateValue = 2
                                Gates(i).gateInput1 = 2
                                Gates(i).gateInput2 = 2
                            End If
                            tempID = i
                            gatecount += 1
                            AddGatePB(choice, tempID)
                            Exit For
                        End If
                    Next
                End If
            Next
        ElseIf gatecount + multgate > 200
            message_output.Text = "Gate limit reached"
        Else
            message_output.Text = "Gate already exists with 
that name"
        End If
        custom_gate_name.Text = ""
    End Sub
    Private Sub delete_all_gates_Click(sender As Object, e As EventArgs) Handles delete_all_gates.Click
        loading_bar.Value = 0
        loading_bar.Maximum = Convert.ToInt32(GatePB.Count)
        loading_bar.Show()
        While GatePB.Count <> 0
            Try
                For Each PB In GatePB
                    DeleteGate(PB)
                    loading_bar.Value += 1
                    If GatePB.Count = 0 Then
                        Exit For
                    End If
                Next
            Catch
            End Try
        End While
        selected_gate.Text = ""
        message_output.Text = ""
        loading_bar.Hide()
    End Sub
    Private Sub DeleteGate(ByRef PB As PictureBox)
        Dim ID As Integer = PB.Name
        tempID = ID
        gatecount -= 1
        NullifyConnections(ID)
        selected_gate.Text = ""
        Gates(ID).gateName = ""
        Gates(ID).gateInput1Exists = False
        Gates(ID).gateInput2Exists = False
        Gates(PB.Name).Finalize()    'Destructs gate object
        GatePB.Remove(PB)            'Removes gate PB from PB list
        PB.Dispose()                 'makes PB disappear
        RefreshGraphics()            'Graphics Refresh
    End Sub
    Private Sub NullifyConnections(ByVal ID As Integer)
        For i = 0 To 199                                                   'Searches array of connections and looks for connections connected to and from gate to be deleted
            If connections(i, ID, 0).connectionExists = True And ID = tempID Then        'nullifies any gates that have had connections deprived
                connections(i, ID, 0).connectionExists = False
                connections(i, ID, 0).connectionValue = 2
                connections(i, ID, 0).connectionDestination = -1
                connections(i, ID, 0).connectionOrigin = -1
            End If
            If connections(i, ID, 1).connectionExists = True And ID = tempID Then
                connections(i, ID, 1).connectionExists = False
                connections(i, ID, 1).connectionValue = 2
                connections(i, ID, 1).connectionDestination = -1
                connections(i, ID, 1).connectionOrigin = -1
            End If
            If connections(ID, i, 0).connectionExists = True And ID = tempID Then
                connections(ID, i, 0).connectionExists = False
                Gates(i).gateInput1Exists = False
                connections(ID, i, 0).connectionValue = 2
                connections(ID, i, 0).connectionDestination = -1
                connections(ID, i, 0).connectionOrigin = -1
                Gates(i).gateInput1 = 2
                Gates(i).gateValue = 2
                NullifyConnections(i)
            ElseIf connections(ID, i, 0).connectionExists = True Then
                connections(ID, i, 0).connectionValue = 2
                connections(ID, i, 0).connectionDestination = -1
                connections(ID, i, 0).connectionOrigin = -1
                Gates(i).gateInput1 = 2
                Gates(i).gateValue = 2
                NullifyConnections(i)
            End If
            If connections(ID, i, 1).connectionExists = True And ID = tempID Then
                connections(ID, i, 1).connectionExists = False
                Gates(i).gateInput2Exists = False
                connections(ID, i, 1).connectionValue = 2
                connections(ID, i, 1).connectionDestination = -1
                connections(ID, i, 1).connectionOrigin = -1
                Gates(i).gateInput2 = 2
                Gates(i).gateValue = 2
                NullifyConnections(i)
            ElseIf connections(ID, i, 1).connectionExists = True Then
                connections(ID, i, 1).connectionValue = 2
                connections(ID, i, 1).connectionDestination = -1
                connections(ID, i, 1).connectionOrigin = -1
                Gates(i).gateInput2 = 2
                Gates(i).gateValue = 2
                NullifyConnections(i)
            End If
        Next
    End Sub
    Private Sub RecalculateConnections(ID)
        For i = 0 To 199                                                   'Searches array of connections and looks for connections connected to and from gate to be deleted
            If connections(ID, i, 0).connectionExists = True Then
                connections(ID, i, 0).connectionValue = 2
                connections(ID, i, 0).connectionDestination = -1
                connections(ID, i, 0).connectionOrigin = -1
                Gates(i).gateInput1 = 2
                Gates(i).gateValue = 2
                RecalculateConnections(i)
            End If
            If connections(ID, i, 1).connectionExists = True Then
                connections(ID, i, 1).connectionValue = 2
                connections(ID, i, 1).connectionDestination = -1
                connections(ID, i, 1).connectionOrigin = -1
                Gates(i).gateInput2 = 2
                Gates(i).gateValue = 2
                RecalculateConnections(i)
            End If
        Next
    End Sub
    Private Sub AddInputTrue(ByVal sender As Object, ByVal e As EventArgs) Handles add_input_true.Click
        Dim choice As String = "inputt"
        newGate(choice)
    End Sub
    Private Sub AddInputFalse(ByVal sender As Object, ByVal e As EventArgs) Handles add_input_false.Click
        Dim choice As String = "inputf"
        newGate(choice)
    End Sub
    Private Sub add_output_Click(sender As Object, e As EventArgs) Handles add_output.Click
        Dim choice As String = "output"
        newGate(choice)
    End Sub
    Private Sub AddAnd(ByVal sender As Object, ByVal e As EventArgs) Handles add_and.Click
        Dim choice As String = "and"
        newGate(choice)
    End Sub
    Private Sub AddNand(ByVal sender As Object, ByVal e As EventArgs) Handles add_nand.Click
        Dim choice As String = "nand"
        newGate(choice)
    End Sub
    Private Sub AddOr(ByVal sender As Object, ByVal e As EventArgs) Handles add_or.Click
        Dim choice As String = "or"
        newGate(choice)
    End Sub
    Private Sub AddNor(ByVal sender As Object, ByVal e As EventArgs) Handles add_nor.Click
        Dim choice As String = "nor"
        newGate(choice)
    End Sub
    Private Sub AddXor(ByVal sender As Object, ByVal e As EventArgs) Handles add_xor.Click
        Dim choice As String = "xor"
        newGate(choice)
    End Sub
    Private Sub AddNot(sender As Object, e As EventArgs) Handles add_not.Click
        Dim choice As String = "not"
        newGate(choice)
    End Sub
    Private Sub switch_mode_click(sender As Object, e As EventArgs) Handles switch_mode.Click
        profMode = Not profMode
        ModeSwitch()
    End Sub
    Class MultiGate
        Inherits Window
        Private name1 As String
        Private ID As Integer
        Private isNull As Boolean
        Private Type As String
        Private xpos As Integer
        Private ypos As Integer
        Private value As Integer
        Private input1 As Integer
        Private input2 As Integer
        Private input1Exists As Boolean
        Private input2Exists As Boolean
        Sub New(ByVal givenID As Integer)
            ID = givenID
            isNull = True
            input1Exists = False
            input2Exists = False
        End Sub
        Protected Overrides Sub Finalize()
            isNull = True
        End Sub
        Public Property gateName As String
            Get
                Return name1
            End Get
            Set(value As String)
                name1 = value
            End Set
        End Property
        Public Property gateID As Integer
            Get
                Return ID
            End Get
            Set(ByVal givenID As Integer)
                ID = givenID
            End Set
        End Property
        Public Property gateIsNull As String
            Get
                Return isNull
            End Get
            Set(ByVal givenValue As String)
                isNull = givenValue
            End Set
        End Property
        Public Property gateType As String
            Get
                Return Type
            End Get
            Set(value As String)
                Type = value
            End Set
        End Property
        Public Property gateXpos As Integer
            Get
                Return xpos
            End Get
            Set(ByVal givenXpos As Integer)
                xpos = givenXpos
            End Set
        End Property
        Public Property gateYpos As Integer
            Get
                Return ypos
            End Get
            Set(ByVal givenYpos As Integer)
                ypos = givenYpos
            End Set
        End Property
        Public Property gateValue As Integer
            Get
                Return value
            End Get
            Set(ByVal givenValue As Integer)
                value = givenValue
            End Set
        End Property
        Public Property gateInput1 As Integer
            Get
                Return input1
            End Get
            Set(value As Integer)
                input1 = value
            End Set
        End Property
        Public Property gateInput2 As Integer
            Get
                Return input2
            End Get
            Set(value As Integer)
                input2 = value
            End Set
        End Property
        Public Property gateInput1Exists As Boolean
            Get
                Return input1Exists
            End Get
            Set(value As Boolean)
                input1Exists = value
            End Set
        End Property
        Public Property gateInput2Exists As Boolean
            Get
                Return input2Exists
            End Get
            Set(value As Boolean)
                input2Exists = value
            End Set
        End Property
        Public Sub Calculate(ByVal ID As Integer)  'function has to find the outputs of the gate objects which led to it
            If gateType = "not" Then
                Try
                    For i = 0 To 199
                        If Window.getWindowConnectionsValue(i, ID, 0) <> 2 Then
                            input1 = Window.getWindowConnectionsValue(i, ID, 0)
                            Exit For
                        End If
                        If i = 199 And input1 <> 2 Then
                            input1 = 2
                        End If
                    Next
                Catch
                End Try
                If input1 <> 2 Then
                    If input1 = 1 Then
                        value = 0
                    ElseIf input1 = 0 Then
                        value = 1
                    End If
                Else
                    value = 2
                End If
            ElseIf gateType = "output" Then
                Try
                    For i = 0 To 199
                        If Window.connections(i, ID, 0).connectionValue <> 2 Then
                            input1 = Window.connections(i, ID, 0).connectionValue
                            Exit For
                        End If
                        If i = 199 And input1 <> 2 Then
                            input1 = 2
                        End If
                    Next
                Catch
                End Try
                If input1 <> 2 Then
                    If input1 = 1 Then
                        value = 1
                    ElseIf input1 = 0 Then
                        value = 0
                    End If
                Else
                    value = 2
                End If
            Else
                Try
                    For i = 0 To 199
                        If Window.connections(i, ID, 0).connectionValue <> 2 Then
                            input1 = Window.connections(i, ID, 0).connectionValue
                            Exit For
                        End If
                        If i = 199 And input1 <> 2 Then
                            input1 = 2
                        End If
                    Next
                Catch
                End Try
                Try
                    For i = 0 To 199
                        If Window.connections(i, ID, 1).connectionValue <> 2 Then
                            input2 = Window.connections(i, ID, 1).connectionValue
                            Exit For
                        End If
                        If i = 199 And input2 <> 2 Then
                            input2 = 2
                        End If
                    Next
                Catch
                End Try
                If gateType = "and" Then
                    If input1 <> 2 And input2 <> 2 Then
                        If input1 = 1 And input2 = 1 Then
                            value = 1
                        Else
                            value = 0
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "nand" Then
                    If input1 <> 2 And input2 <> 2 Then
                        If input1 = 1 And input2 = 1 Then
                            value = 0
                        Else
                            value = 1
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "or" Then
                    If input1 <> 2 And input2 <> 2 Then
                        If input1 = 1 Or input2 = 1 Then
                            value = 1
                        Else
                            value = 0
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "nor" Then
                    If input1 <> 2 And input2 <> 2 Then
                        If input1 = 1 Or input2 = 1 Then
                            value = 0
                        Else
                            value = 1
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "xor" Then
                    If input1 <> 2 And input2 <> 2 Then
                        If input1 = 1 Xor input2 = 1 Then
                            value = 1
                        Else
                            value = 0
                        End If
                    Else
                        value = 2
                    End If
                End If
            End If
        End Sub
    End Class
    Class Connection
        Private origin As Integer
        Private destination As Integer
        Private value1 As Integer
        Private exists As Boolean
        Sub New()
            origin = -1
            destination = -1
            value1 = 2
            exists = False
        End Sub
        Public Property connectionOrigin As Integer
            Get
                Return origin
            End Get
            Set(value As Integer)
                origin = value
            End Set
        End Property
        Public Property connectionDestination As Integer
            Get
                Return destination
            End Get
            Set(value As Integer)
                destination = value
            End Set
        End Property
        Public Property connectionValue As Integer
            Get
                Return value1
            End Get
            Set(value As Integer)
                value1 = value
            End Set
        End Property
        Public Property connectionExists As Boolean
            Get
                Return exists
            End Get
            Set(value As Boolean)
                exists = value
            End Set
        End Property
    End Class
End Class