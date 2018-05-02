Imports VB = Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Class Window
    'Global Private variable declarations
    Private profMode As Boolean
    Private tempID As Integer
    Private oneSelected As Boolean = False
    Private selectedID As Integer
    Private hoveredID As Integer
    Private prevValue As Integer
    Private prevID As Integer
    Private loopCount As Integer
    Private loopCount2 As Integer
    Private prevLoopID As Integer = Nothing

    'Graphics object declarations
    Private comicSansFont As New Font("Comic Sans MS", 9, FontStyle.Regular)
    Private corbelFont As New Font("Corbel", 10, FontStyle.Regular)
    Private g As Graphics
    Private blackPen As New Pen(Color.Black, 4)
    Private bluePen As New Pen(Color.Blue, 4)
    Private redPen As New Pen(Color.Red, 4)
    Private clockTime As Integer = 0
    Private ValidPB As Boolean
    'Image Declarations for the gate PBs
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
    'Object Declarations
    Protected WithEvents GatePB As New List(Of PictureBox)
    Protected connections(199, 199, 1) As Connection
    Protected Gates() As MultiGate


    Public Property windowProf As Boolean
        Get
            Return profMode
        End Get
        Set(value As Boolean)
            profMode = value
        End Set
    End Property
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function
    Private Sub WindowCloser(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        End
    End Sub
    Private Sub WindowLoader(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowStart()                   'Calls the sub that redims gate arrays and constructs gate objects using these arrays
    End Sub
    Private Sub WindowStart()      'Sets initial values for gate variables
        g = CreateGraphics()       'Required for graphics to appear
        ModeSwitch()               'Checks which mode it is starting in and loads appropriate assets
        prevValue = 2
        hoveredID = -1
        ClockTimer.Interval = 1
        ClockTimer.Start()                       'Starts timer ticking every ms for clocks
        ReDim Gates(199)                          'Gates() and connections(,,) must be redimmed and then recreated as objects... A VB quirk
        ReDim connections(199, 199, 1)
        For i As Integer = 0 To 199            'All gate and connection objects are instantiated and set to a null state
            Gates(i) = New MultiGate(i)
        Next
        For k = 0 To 1
            For i = 0 To 199
                For j = 0 To 199
                    connections(i, j, k) = New Connection
                Next
            Next
        Next
        progress_bar.Hide()                      'For graphical and UI elements \/ \/
        SendMessage(Me.custom_gate_input.Handle, &H1501, 0, "Custom Number of Gates")
        SendMessage(Me.custom_gate_name.Handle, &H1501, 0, "Custom Gate Name")
        SendMessage(Me.clock_interval_input.Handle, &H1501, 0, "Interval...")
    End Sub
    Private Sub ClockTimerTick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        clockTime += 1                'Ticks over every millisecond
        If clockTime >= 10000 Then    'Stops value overflowing
            clockTime = 0
        End If
        For Each Gate In Gates
            If Gate.gateType = "clock" Then                          'Checks the gates to see if any clocks exist and
                If clockTime Mod Gate.gateClockInterval = 0 Then     'if they do, check if they need to change value
                    If Gate.gateValue = 1 Then
                        Gate.gateValue = 0
                    Else
                        Gate.gateValue = 1
                    End If
                    RecalculateConnections(Gate.gateID)
                    RefreshGraphics()                    'Refreshes all elements to show change
                    Try
                        If Gates(hoveredID).gateType = "clock" Then
                            displayGateInfo(hoveredID)
                        End If
                    Catch
                    End Try
                End If
            End If
        Next
    End Sub
    Private Sub ModeSwitch()                                 'Assignment of images en mass to PB variables depending on mode
        If profMode = True Then
            inputImageTrue = My.Resources.INPUTTRUEP1
            inputImageFalse = My.Resources.INPUTFALSEP1
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
                If Gates(PB.Name).gateType = "input" And Gates(PB.Name).gateValue = 1 Then
                    PB.Image = inputImageTrue
                ElseIf Gates(PB.Name).gateType = "input" And Gates(PB.Name).gateValue = 0 Then
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
    Private Sub RefreshGraphics()
        For Each PB In GatePB
            If Gates(PB.Name).gateType = "output" And Gates(PB.Name).gateValue = 1 Then          'Refreshes gate PBs with dynamic states pictures
                PB.Image = outputImageTrue
            ElseIf Gates(PB.Name).gateType = "output" And Gates(PB.Name).gateValue = 0 Then
                PB.Image = outputImageFalse
            ElseIf Gates(PB.Name).gateType = "output" And Gates(PB.Name).gateValue = 2 Then
                PB.Image = outputImageNull
            ElseIf Gates(PB.Name).gateType = "input" And Gates(PB.Name).gateValue = 1 Then
                PB.Image = inputImageTrue
            ElseIf Gates(PB.Name).gateType = "input" And Gates(PB.Name).gateValue = 0 Then
                PB.Image = inputImageFalse
            ElseIf Gates(PB.Name).gateType = "clock" And Gates(PB.Name).gateValue = 1 Then
                PB.Image = inputImageTrue
            ElseIf Gates(PB.Name).gateType = "clock" And Gates(PB.Name).gateValue = 0 Then
                PB.Image = inputImageFalse
            End If
        Next
        Me.Refresh()
        For k = 0 To 1                                      '          || ||
            For i = 0 To 199                                'This mess \/ \/  is responsible for assigning connection graphics to the correct part of each gate
                For j = 0 To 199
                    If connections(i, j, k).connectionExists = True And k = 0 Then
                        If (Gates(j).gateType = "not" Or Gates(j).gateType = "output") And Gates(i).gateValue = 1 Then                   'Anchors are specific coordinates of points on the PB, that represent where connects connect differ from gate to gate as they are all different

                            g.DrawLine(bluePen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput1Anchor))

                        ElseIf (Gates(j).gateType = "not" Or Gates(j).gateType = "output") And Gates(i).gateValue = 0 Then

                            g.DrawLine(blackPen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput1Anchor))

                        ElseIf (Gates(j).gateType = "not" Or Gates(j).gateType = "output") And Gates(i).gateValue = 2 Then

                            g.DrawLine(redPen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput1Anchor))

                        Else

                            If Gates(i).gateValue = 1 Then

                                g.DrawLine(bluePen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput1Anchor))

                            ElseIf Gates(i).gateValue = 0 Then

                                g.DrawLine(blackPen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput1Anchor))

                            Else

                                g.DrawLine(redPen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput1Anchor))

                            End If
                        End If
                    ElseIf connections(i, j, k).connectionExists = True And k = 1 Then
                        If Gates(i).gateValue = 1 Then

                            g.DrawLine(bluePen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput2Anchor))

                        ElseIf Gates(i).gateValue = 0 Then

                            g.DrawLine(blackPen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput2Anchor))

                        Else

                            g.DrawLine(redPen, (Gates(i).gateOutputAnchor), (Gates(j).gateInput2Anchor))

                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub PBs_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)            'Called when a gate has the mouse down on it
        Dim PB As PictureBox = DirectCast(sender, PictureBox)
        Dim ID = PB.Name
        Point = e.Location
        If e.Button = MouseButtons.Left Then                               'If it is a left click then the gate is 'selected' and details are shown
            If PB.Location.X >= 0 Or PB.Location.X <= Me.Width Or PB.Location.Y >= 0 Or PB.Location.Y <= Me.Height Then
                ValidPB = True
            End If
            selectedID = ID
        End If
        If e.Button = MouseButtons.Right Then                         'If it is a right click then the gate is being attached and the AttachGate sub is run.
            selectedID = ID
            If ID = prevID And oneSelected = True And profMode = True Then
                DeleteGate(PB)
                oneSelected = False
                message_output.Text = ""
            Else
                AttachGate(oneSelected, prevValue, prevID, ID)
            End If
        End If
    End Sub
    Private Sub PBs_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)                'Called when the mouse moves
        Dim PB As PictureBox = DirectCast(sender, PictureBox)
        RecalculateConnections(PB.Name)
        If e.Button = MouseButtons.Left And ValidPB Then               'If mouse is down, moving and the mouse is in valid bounds then the gate moves
            RefreshGraphics()
            PB.Left += e.Location.X - Point.X
            PB.Top += e.Location.Y - Point.Y
            Gates(PB.Name).gatePos = PB.Location
            If PB.Left < 0 Then                                        'If gate is out of bounds, x/y coords are reset to valid ones
                PB.Left = 0
                ValidPB = False
            ElseIf PB.Left > (Me.Width - 130) Then
                PB.Left = (Me.Width - 140)
                ValidPB = False
            ElseIf PB.Top < 190 Then
                PB.Top = 190
                ValidPB = False
            ElseIf PB.Top > (Me.Height - 90) Then
                PB.Top = (Me.Height - 100)
                ValidPB = False
            End If                                                     'The anchors have to be refreshed every time the gate is moved.
            If Gates(PB.Name).gateType = "and" Or Gates(PB.Name).gateType = "nand" Then
                Gates(PB.Name).gateInput1AnchorX = PB.Location.X
                Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 15
                Gates(PB.Name).gateInput2AnchorX = PB.Location.X
                Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 37
                Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
                Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 27
            ElseIf Gates(PB.Name).gateType = "or" Or Gates(PB.Name).gateType = "nor" Or Gates(PB.Name).gateType = "xor" Then
                Gates(PB.Name).gateInput1AnchorX = PB.Location.X
                Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 8
                Gates(PB.Name).gateInput2AnchorX = PB.Location.X
                Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 31
                Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
                Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 20
            ElseIf Gates(PB.Name).gateType = "not" Then
                Gates(PB.Name).gateInput1AnchorX = PB.Location.X
                Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 23
                Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
                Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 23
            ElseIf Gates(PB.Name).gateType = "input" Then
                Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 30
                Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 30
            Else
                Gates(PB.Name).gateInput1AnchorX = PB.Location.X + 30
                Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 30
                Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 30
                Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 30
            End If
        End If
    End Sub
    Private Sub PBMouseEnter(sender As Object, e As EventArgs)           'Called when the mouse enters a gate
        Dim PB As PictureBox = DirectCast(sender, PictureBox)
        hoveredID = PB.Name
        displayGateInfo(PB.Name)
    End Sub
    Private Sub PBMouseLeave(sender As Object, e As EventArgs)             'Called when the mouse leaves a gate
        selected_gate.Text = ""
        hoveredID = -1
    End Sub
    Private Sub displayGateInfo(ByVal ID As Integer)                'Displays all info on a gate, provided with the ID of said gate
        Dim value As String
        If ID <> -1 Then                                          'being passed an ID of -1 means "Don't display anything"
            If Gates(ID).gateValue = 2 Then
                value = "NULL"
            ElseIf Gates(ID).gateValue = 1 Then
                value = "TRUE"
            ElseIf Gates(ID).gateValue = 0 Then
                value = "FALSE"
            End If
            If Gates(ID).gateType <> "clock" Then
                selected_gate.Text = "Selected Gate ID: " & ID & " 
Gate Type: " & (Gates(ID).gateType).ToUpper & "
Current Value: " & value & "
Gate Name: " & Gates(ID).gateName & "
Safe: " & Gates(ID).gateSafe
            Else
                selected_gate.Text = "Selected Gate ID: " & ID & " 
Gate Type: " & (Gates(ID).gateType).ToUpper & "
Current Value: " & value & "
Gate Name: " & Gates(ID).gateName & "
Clock Interval: " & Gates(ID).gateClockInterval & " ms"
            End If
        Else
        End If
    End Sub
    Private Sub AttachGate(ByRef oneSelected As Boolean, ByRef prevValue As Integer, ByRef prevID As Integer, ByVal ID As Integer)
        If oneSelected = True Then                                                     'This means the gate is having a value assigned to one of its inputs from another gates output
            If Gates(ID).gateType <> "input" Or Gates(ID).gateType <> "clock" Then
                If Gates(ID).gateType = "not" Or Gates(ID).gateType = "output" Then
                    If Gates(ID).gateInput1Exists = False Then
                        message_output.Text = "Assigned input 
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue                                         'The prevValue is assigned to an input
                        Gates(ID).gateInput1 = prevValue
                        connections(prevID, ID, 0).connectionValue = Gates(prevID).gateValue       'Connection is only created for k = 0 because some gates only have one input
                        connections(prevID, ID, 0).connectionExists = True                       'Connection become existent and value is assigned
                        Gates(ID).gateInput1Exists = True
                        Gates(ID).Calculate()
                    Else
                        message_output.Text = "The input is already occupied"
                    End If
                Else
                    If Gates(ID).gateInput1Exists = False Then
                        message_output.Text = "Assigned input (1) 
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue                                         'The prevValue is assigned to an input
                        Gates(ID).gateInput1 = prevValue
                        connections(prevID, ID, 0).connectionValue = Gates(prevID).gateValue        'Connection object for connecting to input 1
                        connections(prevID, ID, 0).connectionExists = True                      'Connection become existent and value is assigned
                        Gates(ID).gateInput1Exists = True
                        Gates(ID).Calculate()
                    ElseIf Gates(ID).gateInput2Exists = False Then
                        message_output.Text = "Assigned input (2)
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue
                        Gates(ID).gateInput2 = prevValue
                        connections(prevID, ID, 1).connectionValue = Gates(prevID).gateValue       'Connection object for connecting to input 2
                        connections(prevID, ID, 1).connectionExists = True                       'Connection become existent and value is assigned
                        Gates(ID).gateInput2Exists = True
                        Gates(ID).Calculate()
                    Else
                        message_output.Text = "Both inputs are 
already occupied"
                    End If
                End If
                If connections(ID, prevID, 0).connectionExists Or connections(ID, prevID, 1).connectionExists = True Then
                    Gates(ID).gateSafe = prevID
                    Gates(prevID).gateSafe = ID
                End If
                RecalculateConnections(ID)                                 'Every time a connection is made, all gates are recalculated from that point onwards
            Else
                    message_output.Text = "Input nodes are 
fixed and cannot be 
assigned by another 
gate"
            End If
            oneSelected = False
            displayGateInfo(ID)
            RefreshGraphics()                                 'A graphics refresh to show the new connection in all its glory
        ElseIf oneSelected = False Then                         'This means the gate is before another gate in the circuit
            message_output.Text = (Gates(ID).gateType).ToUpper & " gate 1 selected...
Right-Click again to delete"
            prevValue = Gates(ID).gateValue             'The global variable prevValue is assigned this value
            prevID = ID
            oneSelected = True
        End If
    End Sub
    Private Sub NewGate(ByVal choice As String)
        Dim ID As Integer
        Dim gatecount As Integer = 0
        Dim multgate As Integer
        Dim valid As Boolean = True
        For Each Gate In Gates
            If Gate.gateIsNull = False Then          'Recounts gatecount every time, to always have an up to date number
                gatecount += 1
            End If
        Next
        Try                                            'Validation to ensure user has entered something valid in the input fields
            If custom_gate_input.Text = "" Then
                multgate = 1
            ElseIf Convert.ToInt32(custom_gate_input.Text) Then
                multgate = custom_gate_input.Text
            End If
        Catch
            valid = False
        End Try
        custom_gate_input.Text = ""
        If gatecount + multgate <= 200 And valid = True Then
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
                                Gates(i).gateType = "input"
                            ElseIf choice = "inputf" Then
                                Gates(i).gateValue = 0
                                Gates(i).gateType = "input"
                            ElseIf choice = "output" Then
                                Gates(i).gateValue = 2
                                Gates(i).gateInput1 = 2
                            ElseIf choice = "clock" Then
                                Gates(i).gateValue = 0
                                Try
                                    Gates(i).gateClockInterval = clock_interval_input.Text         'Clocks have their interval assigned from the input box
                                Catch
                                    Gates(i).gateClockInterval = 30
                                End Try
                            Else
                                Gates(i).gateValue = 2
                                Gates(i).gateInput1 = 2
                                Gates(i).gateInput2 = 2
                            End If
                            ID = i
                            AddGatePB(Gates(i).gateType, ID)                         'Calls sub which creates the gate PB, passes the ID and type as argument
                            Exit For
                        End If
                    Next
                End If
            Next
        Else
            message_output.Text = "Erroneous
data has been input
please try again"
        End If
        custom_gate_name.Text = ""
        clock_interval_input.Text = ""
    End Sub
    Private Sub AddGatePB(ByVal choice As String, ByVal ID As Integer)
        oneSelected = False
        message_output.Text = ""
        Dim PB As New PictureBox
        PB.Left = 515 - (PB.Width / 2)
        PB.Top = Me.ClientRectangle.Height - PB.Height - 10
        PB.Name = ID             '---IMPORTANT---Gate name is set as the gate ID so the gate object can be referenced from the gate PB
        AddHandler PB.MouseDown, AddressOf PBs_MouseDown                  'Handlers are created for each PB to call respective subroutines when mouse interacts with them
        AddHandler PB.MouseMove, AddressOf PBs_MouseMove
        AddHandler PB.MouseEnter, AddressOf PBMouseEnter
        AddHandler PB.MouseLeave, AddressOf PBMouseLeave
        PB.Parent = Me
        If choice = "input" And Gates(ID).gateValue = 1 Then            'Depending on type of gate, picture is assigned, size is assigned, and anchors are assigned.
            PB.Height = 58
            PB.Width = 58
            PB.Image = inputImageTrue
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 30
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 30
        ElseIf choice = "input" And Gates(ID).gateValue = 0 Then
            PB.Height = 58
            PB.Width = 58
            PB.Image = inputImageFalse
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 30
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 30
        ElseIf choice = "clock" Then
            PB.Height = 58
            PB.Width = 58
            PB.Image = inputImageTrue
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 30
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 30
        ElseIf choice = "output" Then
            PB.Height = 60
            PB.Width = 60
            PB.Image = outputImageNull
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X + 30
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 30
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 30
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 30
        ElseIf choice = "and" Then
            PB.Image = andImage
            PB.Height = 52
            PB.Width = 125
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 37
            Gates(PB.Name).gateInput2AnchorX = PB.Location.X
            Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 15
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 27
        ElseIf choice = "nand" Then
            PB.Image = nandImage
            PB.Height = 52
            PB.Width = 125
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 37
            Gates(PB.Name).gateInput2AnchorX = PB.Location.X
            Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 15
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 27
        ElseIf choice = "or" Then
            PB.Image = orImage
            PB.Height = 39
            PB.Width = 125
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 31
            Gates(PB.Name).gateInput2AnchorX = PB.Location.X
            Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 8
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 20
        ElseIf choice = "nor" Then
            PB.Image = norImage
            PB.Height = 39
            PB.Width = 125
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 31
            Gates(PB.Name).gateInput2AnchorX = PB.Location.X
            Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 8
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 20
        ElseIf choice = "xor" Then
            PB.Image = xorImage
            PB.Height = 39
            PB.Width = 125
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 31
            Gates(PB.Name).gateInput2AnchorX = PB.Location.X
            Gates(PB.Name).gateInput2AnchorY = PB.Location.Y + 8
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 20
        ElseIf choice = "not" Then
            PB.Image = notImage
            PB.Height = 46
            PB.Width = 125
            Gates(PB.Name).gateInput1AnchorX = PB.Location.X
            Gates(PB.Name).gateInput1AnchorY = PB.Location.Y + 23
            Gates(PB.Name).gateOutputAnchorX = PB.Location.X + 125
            Gates(PB.Name).gateOutputAnchorY = PB.Location.Y + 23
        End If
        GatePB.Add(PB)               'Gate PB is added to PB list
    End Sub
    Private Sub delete_all_gates_Click(sender As Object, e As EventArgs) Handles delete_all_gates.Click
        DeleteAllGates()
    End Sub
    Private Sub DeleteGate(ByRef PB As PictureBox)
        Dim ID As Integer = PB.Name
        hoveredID = -1
        tempID = ID
        NullifyConnections(ID)       'Ensures all connections from that gate are updated to be null
        selected_gate.Text = ""
        Gates(PB.Name).Finalize()    'Destructs gate object
        GatePB.Remove(PB)            'Removes gate PB from PB list
        PB.Dispose()                 'makes PB disappear
        RefreshGraphics()            'Graphics Refresh
    End Sub
    Private Sub DeleteAllGates()                       'Basically just calls DeleteGate() in a for loop and adds a loading bar
        progress_bar.Value = 0
        progress_bar.Maximum = Convert.ToInt32(GatePB.Count)
        progress_bar.Show()
        While GatePB.Count <> 0
            Try
                For Each PB In GatePB
                    DeleteGate(PB)
                    progress_bar.Value += 1
                    If GatePB.Count = 0 Then
                        Exit For
                    End If
                Next
            Catch
            End Try
        End While
        selected_gate.Text = ""
        message_output.Text = ""
        progress_bar.Hide()
    End Sub
    Private Sub LoadPreset(ByVal strFileName As String)
        Dim readString As String
        Dim gateSequence(300) As String
        Dim connectionSequence(2) As String
        Dim gateRead As Boolean = True
        Dim x As Integer = 0

        DeleteAllGates()                                             'Clears the form, so that it can create its own connections once gates are input
        readString = My.Computer.FileSystem.ReadAllText(strFileName)     'Reads file into string variable

        For Each letter As String In readString                            'BNF definition for file presets is in documentation
            If letter = "!" Then                                          'Algorithm reads the string character by character and then creates the gates and connections accordingly
                gateRead = False
                x = 0
                For i = 0 To gateSequence.Length - 1
                    If gateSequence(i) <> "" Then
                        NewGate(gateSequence(i))
                    Else
                    End If
                Next
            Else
                If letter <> "/" And gateRead = True Then
                    gateSequence(x) = gateSequence(x) & letter
                ElseIf gateRead = True Then
                    x += 1
                End If
                If letter <> "/" And gateRead = False Then
                    If letter <> "." Then
                        connectionSequence(x) = letter
                    Else
                        x += 1
                    End If
                ElseIf letter = "/" And gateRead = False Then
                    x = 0
                    connections(connectionSequence(0), connectionSequence(1), connectionSequence(2)).connectionExists = True
                End If
            End If
        Next

        For Each Gate In Gates
            If Gate.gateType = "input" Then
                RecalculateConnections(Gate.gateID)
            End If
        Next

        RefreshGraphics()
    End Sub
    Private Sub SavePreset(ByVal strFileName As String)
        Dim writeString As String

        For Each Gate In Gates                                           'Runs through Gates() list and creates a string of gates
            If Gate.gateIsNull = False Then
                If Gate.gateType = "input" And Gate.gateValue = 1 Then
                    writeString &= "inputt/"
                ElseIf Gate.gateType = "input" And Gate.gateValue = 0 Then
                    writeString &= "inputf/"
                Else
                    writeString &= Gate.gateType & "/"
                End If
            End If
        Next

        writeString &= "!"

        For k = 0 To 1                                                  'Runs through connections(,,) array and creates a string of connections
            For i = 0 To 199
                For j = 0 To 199
                    If connections(i, j, k).connectionExists = True Then
                        writeString = writeString & i & "." & j & "." & k & "/"
                    End If
                Next
            Next
        Next

        My.Computer.FileSystem.WriteAllText(strFileName, writeString, False)
    End Sub
    Private Sub NullifyConnections(ByVal ID As Integer)
        For i = 0 To 199                                                   'Searches array of connections and looks for connections connected to and from gate to be deleted
            If connections(i, ID, 0).connectionExists = True And ID = tempID Then        'nullifies any gates that have had connections deprived
                connections(i, ID, 0).connectionExists = False
                connections(i, ID, 0).connectionValue = 2
            End If
            If connections(i, ID, 1).connectionExists = True And ID = tempID Then
                connections(i, ID, 1).connectionExists = False                                                'Recursive subroutine that nullifies connections. If there are more gates after that gate, it is called again with that gates ID as the argument
                connections(i, ID, 1).connectionValue = 2                                                     'Continues until all relevant connecitons have been nullified
            End If
            If connections(ID, i, 0).connectionExists = True And ID = tempID Then
                connections(ID, i, 0).connectionExists = False
                Gates(i).gateInput1Exists = False
                connections(ID, i, 0).connectionValue = 2
                Gates(i).gateInput1 = 2
                Gates(i).Calculate()
                If loopCount > 1 Then
                    loopCount = 0
                ElseIf (connections(ID, prevLoopID, 0).connectionExists = True Or connections(ID, prevLoopID, 1).connectionExists = True) _
                    Or (connections(prevLoopID, ID, 0).connectionExists = True Or connections(prevLoopID, ID, 1).connectionExists = True) Then
                    loopCount += 1
                    prevLoopID = ID
                    NullifyConnections(i)
                Else
                    NullifyConnections(i)
                End If
            ElseIf connections(ID, i, 0).connectionExists = True Then
                connections(ID, i, 0).connectionValue = 2
                Gates(i).gateInput1 = 2
                Gates(i).Calculate()
                NullifyConnections(i)
            End If
            If connections(ID, i, 1).connectionExists = True And ID = tempID Then
                connections(ID, i, 1).connectionExists = False
                Gates(i).gateInput2Exists = False
                connections(ID, i, 1).connectionValue = 2
                Gates(i).gateInput2 = 2
                Gates(i).Calculate()
                If loopCount > 1 Then
                    loopCount = 0
                ElseIf (connections(ID, prevLoopID, 0).connectionExists = True Or connections(ID, prevLoopID, 1).connectionExists = True) _
                    Or (connections(prevLoopID, ID, 0).connectionExists = True Or connections(prevloopID, ID, 1).connectionExists = True) Then
                    loopCount += 1
                    prevLoopID = ID
                    NullifyConnections(i)
                Else
                    NullifyConnections(i)
                End If
            ElseIf connections(ID, i, 1).connectionExists = True Then
                connections(ID, i, 1).connectionValue = 2
                Gates(i).gateInput2 = 2
                Gates(i).Calculate()
                NullifyConnections(i)
            End If
        Next
    End Sub
    Private Sub RecalculateConnections(ID)
        For i = 0 To 199
            If connections(ID, i, 0).connectionExists = True And (Gates(ID).gateSafe = i And Gates(i).gateSafe = ID) Then
                connections(ID, i, 0).connectionValue = Gates(ID).gateValue                           'Recursive subroutine that recalculates connections and gate values. If there are more gates after that gate, it is called again with that gates ID as the argument
                Gates(i).gateInput1 = Gates(ID).gateValue                                             'Continues until there are no gates left which haven't been recalculated
                Gates(i).Calculate()
                RecalculateConnections2(i)

            ElseIf connections(ID, i, 0).connectionExists = True Then
                connections(ID, i, 0).connectionValue = Gates(ID).gateValue                           'Recursive subroutine that recalculates connections and gate values. If there are more gates after that gate, it is called again with that gates ID as the argument
                Gates(i).gateInput1 = Gates(ID).gateValue                                             'Continues until there are no gates left which haven't been recalculated
                Gates(i).Calculate()
                RecalculateConnections(i)
            End If

            If connections(ID, i, 1).connectionExists = True And (Gates(ID).gateSafe = i And Gates(i).gateSafe = ID) Then
                connections(ID, i, 1).connectionValue = Gates(ID).gateValue                           'Recursive subroutine that recalculates connections and gate values. If there are more gates after that gate, it is called again with that gates ID as the argument
                Gates(i).gateInput2 = Gates(ID).gateValue                                             'Continues until there are no gates left which haven't been recalculated
                Gates(i).Calculate()
                RecalculateConnections2(i)

            ElseIf connections(ID, i, 1).connectionExists = True Then
                connections(ID, i, 1).connectionValue = Gates(ID).gateValue                           'Recursive subroutine that recalculates connections and gate values. If there are more gates after that gate, it is called again with that gates ID as the argument
                Gates(i).gateInput2 = Gates(ID).gateValue                                             'Continues until there are no gates left which haven't been recalculated
                Gates(i).Calculate()
                RecalculateConnections(i)
            End If
        Next
    End Sub
    Private Sub RecalculateConnections2(ID)
        For i = 0 To 199
            If Gates(ID).gateSafe <> i Then
                If connections(ID, i, 0).connectionExists = True Then
                    connections(ID, i, 0).connectionValue = Gates(ID).gateValue                           'Recursive subroutine that recalculates connections and gate values. If there are more gates after that gate, it is called again with that gates ID as the argument
                    Gates(i).gateInput1 = Gates(ID).gateValue                                             'Continues until there are no gates left which haven't been recalculated
                    Gates(i).Calculate()
                    RecalculateConnections2(i)
                End If
                If connections(ID, i, 1).connectionExists = True Then
                    connections(ID, i, 1).connectionValue = Gates(ID).gateValue                           'Recursive subroutine that recalculates connections and gate values. If there are more gates after that gate, it is called again with that gates ID as the argument
                    Gates(i).gateInput2 = Gates(ID).gateValue                                             'Continues until there are no gates left which haven't been recalculated
                    Gates(i).Calculate()
                    RecalculateConnections2(i)
                End If
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
    Private Sub add_clock_Click(sender As Object, e As EventArgs) Handles add_clock.Click
        Dim choice As String = "clock"
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
    Private Sub invert_input_Click(sender As Object, e As EventArgs) Handles invert_input.Click
        If Gates(selectedID).gateType = "input" Then
            If Gates(selectedID).gateValue = 1 Then         'If input is this, input becomes NOT(this)
                Gates(selectedID).gateValue = 0
            Else
                Gates(selectedID).gateValue = 1
            End If
            RecalculateConnections(selectedID)         'Recalculates to show changes
            RefreshGraphics()                          'Graphics update to show effect of recalculation and inversion
        End If
    End Sub
    Private Sub change_clock_interval_Click(sender As Object, e As EventArgs) Handles change_clock_interval.Click
        If Gates(selectedID).gateType = "clock" Then
            Try
                Gates(selectedID).gateClockInterval = clock_interval_input.Text          'Re assigns interval value to whatever is in the input box
            Catch
            End Try
        Else
        End If
        clock_interval_input.Text = ""
    End Sub
    Private Sub browse_for_preset_Click(sender As Object, e As EventArgs) Handles browse_for_preset.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Select a Preset to Open"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Text Files (*.txt)|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            loadPreset(strFileName)
        End If
    End Sub
    Private Sub save_current_layout_Click(sender As Object, e As EventArgs) Handles save_current_layout.Click
        Dim fd As SaveFileDialog = New SaveFileDialog()
        Dim strFileName As String

        fd.Title = "Select a Location to Save the Preset"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Text Files (*.txt)|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            savePreset(strFileName)
        End If
    End Sub
    Class MultiGate
        Inherits Window
        Private name1 As String
        Private ID As Integer
        Private isNull As Boolean
        Private Type As String
        Private clockInterval As Integer
        Private pos As Point
        Private value As Integer
        Private input1 As Integer
        Private input2 As Integer
        Private input1Exists As Boolean
        Private input2Exists As Boolean
        Private input1Anchor As Point
        Private input2Anchor As Point
        Private outputAnchor As Point
        Private safe As Integer
        Sub New(ByVal givenID As Integer)
            ID = givenID
            isNull = True
            input1Exists = False
            input2Exists = False
            clockInterval = Nothing
            safe = False
        End Sub
        Protected Overrides Sub Finalize()
            isNull = True
            name1 = ""
            input1Exists = False
            input2Exists = False
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
        Public Property gateClockInterval As Integer
            Get
                Return clockInterval
            End Get
            Set(value As Integer)
                clockInterval = value
            End Set
        End Property
        Public Property gatePos As Point
            Get
                Return pos
            End Get
            Set(ByVal value As Point)
                pos = value
            End Set
        End Property
        Public Property gatePosX As Integer
            Get
                Return pos.X
            End Get
            Set(ByVal value As Integer)
                pos.X = value
            End Set
        End Property
        Public Property gatePosY As Integer
            Get
                Return pos.Y
            End Get
            Set(ByVal value As Integer)
                pos.Y = value
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
        Public Property gateInput1Anchor As Point
            Get
                Return input1Anchor
            End Get
            Set(value As Point)
                input1Anchor = value
            End Set
        End Property
        Public Property gateInput1AnchorX As Integer
            Get
                Return input1Anchor.X
            End Get
            Set(value As Integer)
                input1Anchor.X = value
            End Set
        End Property
        Public Property gateInput1AnchorY As Integer
            Get
                Return input1Anchor.Y
            End Get
            Set(value As Integer)
                input1Anchor.Y = value
            End Set
        End Property
        Public Property gateInput2Anchor As Point
            Get
                Return input2Anchor
            End Get
            Set(value As Point)
                input2Anchor = value
            End Set
        End Property
        Public Property gateInput2AnchorX As Integer
            Get
                Return input2Anchor.X
            End Get
            Set(value As Integer)
                input2Anchor.X = value
            End Set
        End Property
        Public Property gateInput2AnchorY As Integer
            Get
                Return input2Anchor.Y
            End Get
            Set(value As Integer)
                input2Anchor.Y = value
            End Set
        End Property
        Public Property gateOutputAnchor As Point
            Get
                Return outputAnchor
            End Get
            Set(value As Point)
                outputAnchor = value
            End Set
        End Property
        Public Property gateOutputAnchorX As Integer
            Get
                Return outputAnchor.X
            End Get
            Set(value As Integer)
                outputAnchor.X = value
            End Set
        End Property
        Public Property gateOutputAnchorY As Integer
            Get
                Return outputAnchor.Y
            End Get
            Set(value As Integer)
                outputAnchor.Y = value
            End Set
        End Property
        Public Property gateSafe As Integer
            Get
                Return safe
            End Get
            Set(value As Integer)
                safe = value
            End Set
        End Property
        Public Sub Calculate()
            If gateType = "not" Then
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
                If gateType = "and" Then
                    If input1 <> 2 Or input2 <> 2 Then
                        If input1 = 1 And input2 = 1 Then
                            value = 1
                        ElseIf (input1 = 1 And input2 = 2) Or (input1 = 2 And input2 = 1) Then
                            value = 2
                        Else
                            value = 0
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "nand" Then
                    If input1 <> 2 Or input2 <> 2 Then
                        If (input1 = 1 And input2 = 2) Or (input1 = 2 And input2 = 1) Then
                            value = 2
                        ElseIf input1 = 1 And input2 = 1 Then
                            value = 0
                        Else
                            value = 1
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "or" Then
                    If input1 <> 2 Or input2 <> 2 Then
                        If input1 = 1 Or input2 = 1 Then
                            value = 1
                        ElseIf (input1 = 0 And input2 = 2) Or (input1 = 2 And input2 = 0) Then
                            value = 2
                        Else
                            value = 0
                        End If
                    Else
                        value = 2
                    End If
                ElseIf gateType = "nor" Then
                    If input1 <> 2 Or input2 <> 2 Then
                        If input1 = 1 Or input2 = 1 Then
                            value = 0
                        ElseIf (input1 = 0 And input2 = 2) Or (input1 = 2 And input2 = 0) Then
                            value = 2
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
        Private value1 As Integer
        Private exists As Boolean
        Sub New()
            value1 = 2
            exists = False
        End Sub
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