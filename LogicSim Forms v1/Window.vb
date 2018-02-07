'NEXT WIPs: --Graphical--
'          -Maybe some proper gate icons
'          --Funcitonal--
'          -Ability to re-calculate all gates after gate/connection removal & Input inversion
Imports VB = Microsoft.VisualBasic
Class Window
    Public Shared Points(139) As String
    Private oneSelected As Boolean = False
    Private holdingCurrent As Integer
    Private prevValue As Integer
    Private prevID As Integer
    Private tempInputID As Integer
    Protected Point As Point
    Private ValidPB As Boolean
    Public GatePB As New List(Of PictureBox)
    Protected connections(199, 199, 1) As Connection
    Protected Gates() As MultiGate
    Public gatecount As Integer
    Protected nextpoint As Integer
    Protected LastID As Integer
    Public Property MousePoint As Point
        Get
            Return Point
        End Get
        Set(givenPoint As Point)
            Point = givenPoint
        End Set
    End Property
    Public Shared Function getGatePoints(ByVal o As Integer)
        Return Points(o)
    End Function
    Public Shared Sub setGatePoints(ByVal o As Integer, ByVal text As String)
        Points(o) = text
    End Sub
    Public Event GateDeleted(PB)
    Private Sub WindowLoader(sender As Object, e As EventArgs) Handles MyBase.Load
        loader.Enabled = True
        WindowStart()                   'Calls the sub that redims gate arrays and constructs gate objects using these arrays
        loader.Enabled = False
        ButtonCheck.Enabled = True
    End Sub
    Public Sub DrawLinePoint(ByVal prevID As Integer, ByVal ID As Integer)
        Dim g As Graphics
        g = CreateGraphics()
        Dim blackPen As New Pen(Color.Black, 3)
        ' Draw line to screen.
        g.DrawLine(blackPen, Gates(prevID).gateXpos + 60, ((Me.Height - Gates(prevID).gateYpos) + 30), Gates(ID).gateXpos, (Me.Height - Gates(ID).gateYpos))
    End Sub
    Public Sub RefreshGraphics()
        Dim g As Graphics
        g = CreateGraphics()
        Dim blackPen As New Pen(Color.Black, 3)
        Me.Refresh()
        For k = 0 To 1
            For i = 0 To 199
                For j = 0 To 199
                    If connections(i, j, k).connectionValue <> 2 And k = 0 Then
                        If Gates(i).gateType = "input" Then
                            g.DrawLine(blackPen, (Gates(i).gateXpos + 60), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                        Else
                            g.DrawLine(blackPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 20))
                        End If
                    End If
                    If connections(i, j, k).connectionValue <> 2 And k = 1 Then
                        If Gates(i).gateType = "input" Then
                            g.DrawLine(blackPen, (Gates(i).gateXpos + 60), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                        Else
                            g.DrawLine(blackPen, (Gates(i).gateXpos + 120), (Me.Height - Gates(i).gateYpos + 30), (Gates(j).gateXpos), (Me.Height - Gates(j).gateYpos + 40))
                        End If
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub WindowCloser(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        End
    End Sub
    Sub WindowStart()      'Sets initial values for gate variables
        ReDim Gates(199)
        ReDim connections(199, 199, 1)
        gatecount = 0
        prevValue = 2
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
        For i = 0 To 139
            Points(i) = "null"
        Next
    End Sub
    Sub PBs_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Point = e.Location
        If e.Button = MouseButtons.Left Then
            Dim PB As PictureBox = DirectCast(sender, PictureBox)
            RefreshGraphics()
            If Gates(PB.Name).gateType = "input" Then
                tempInputID = PB.Name
            Else
                tempInputID = -1
            End If
            If PB.Location.X >= 0 Or PB.Location.X <= Me.Width Or PB.Location.Y >= 0 Or PB.Location.Y <= Me.Height Then
                ValidPB = True
            End If
            displayGateInfo(PB.Name)
        End If
        If e.Button = MouseButtons.Right Then
            Dim PB As PictureBox = DirectCast(sender, PictureBox)
            Dim ID As Integer = PB.Name
            If ID = prevID And oneSelected = True Then
                DeleteGate(PB)
                oneSelected = False
                message_output.Text = ""
            Else
                displayGateInfo(PB.Name)
                AttachGate(oneSelected, prevValue, prevID, ID)
                If Gates(Convert.ToInt32(PB.Name)).gateType = "output" And Gates(Convert.ToInt32(PB.Name)).gateValue = 1 Then
                    PB.Image = My.Resources.OUTPUTTRUE
                ElseIf Gates(Convert.ToInt32(PB.Name)).gateType = "output" And Gates(Convert.ToInt32(PB.Name)).gateValue = 0 Then
                    PB.Image = My.Resources.OUTPUTFALSE
                End If
            End If
        End If
    End Sub
    Sub PBs_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        RefreshGraphics()
        If e.Button = MouseButtons.Left And ValidPB Then
            Dim PB As PictureBox = DirectCast(sender, PictureBox)
            PB.Left += e.Location.X - Point.X
            PB.Top += e.Location.Y - Point.Y
            Gates(PB.Name).gateXpos = PB.Left                      '---NOT QUITE ALIGNED YET---
            Gates(PB.Name).gateYpos = Me.Height - PB.Top
            message_output.Text = Gates(PB.Name).gateXpos & " " & Gates(PB.Name).gateYpos
            If PB.Left < 0 Then
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
Current Value: " & value
        Else
        End If
    End Sub
    Private Sub InvertInput(sender As Object, e As EventArgs) Handles invert_input.Click
        Try
            If tempInputID >= 0 Then
                If Gates(tempInputID).gateValue = 1 Then
                    Gates(tempInputID).gateValue = 0
                    GatePB(tempInputID).Image = My.Resources.INPUTFALSE
                ElseIf Gates(tempInputID).gateValue = 0 Then
                    Gates(tempInputID).gateValue = 1
                    GatePB(tempInputID).Image = My.Resources.INPUTTRUE
                End If
                RecalculateInputs(tempInputID)
                displayGateInfo(tempInputID)
            Else
                message_output.Text = "Selected gate is not an 
Input Node"
            End If
        Catch
            MsgBox("Error in 'InvertInput' Sub")
        End Try
    End Sub
    Private Sub RecalculateInputs(ByVal ID As Integer)
        For j = 0 To 199
            If connections(ID, j, 0).connectionOrigin = ID Then
                connections(ID, j, 0).connectionValue = Gates(ID).gateValue
            End If
            If connections(ID, j, 1).connectionOrigin = ID Then
                connections(ID, j, 1).connectionValue = Gates(ID).gateValue
            End If
        Next
        For i = 0 To 199
            For j = 0 To 199
                Gates(j).Calculate(i, j)
            Next
        Next
    End Sub
    Private Sub AttachGate(ByRef oneSelected As Boolean, ByRef prevValue As Integer, ByRef prevID As Integer, ByVal ID As Integer)
        If oneSelected = True Then                                                     'This means the gate is having a value assigned to one of its inputs from another gates output
            If Gates(ID).gateType <> "input" Then
                If Gates(prevID).gateValue <> 2 Then
                    If Gates(ID).gateType = "not" Or Gates(ID).gateType = "output" Then
                        If Gates(ID).gateInput1 = 2 Then
                            message_output.Text = "Assigned input 
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue                                         'The prevValue is assigned to an input
                            Gates(ID).gateInput1 = prevValue
                            connections(prevID, ID, 0).connectionOrigin = prevID
                            connections(prevID, ID, 0).connectionDestination = ID
                            connections(prevID, ID, 0).connectionValue = Gates(prevID).gateValue
                            Gates(ID).Calculate(prevID, ID)
                        Else
                            message_output.Text = "The input is already occupied"
                        End If
                    Else
                        If Gates(ID).gateInput1 = 2 Then
                            message_output.Text = "Assigned input (1) 
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue                                         'The prevValue is assigned to an input
                            Gates(ID).gateInput1 = prevValue
                            connections(prevID, ID, 0).connectionOrigin = prevID
                            connections(prevID, ID, 0).connectionDestination = ID
                            connections(prevID, ID, 0).connectionValue = Gates(prevID).gateValue
                            Gates(ID).Calculate(prevID, ID)
                        ElseIf Gates(ID).gateInput2 = 2 Then
                            message_output.Text = "Assigned input (2)
to " & (Gates(ID).gateType).ToUpper & " gate" & " 
with value: " & prevValue
                            Gates(ID).gateInput2 = prevValue
                            connections(prevID, ID, 1).connectionOrigin = prevID
                            connections(prevID, ID, 1).connectionDestination = ID
                            connections(prevID, ID, 1).connectionValue = Gates(prevID).gateValue
                            Gates(ID).Calculate(prevID, ID)
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
            DrawLinePoint(prevID, ID)
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
        Dim PB As New PictureBox
        PB.Height = 60
        PB.Width = 125
        PB.Left = Me.ClientRectangle.Width - PB.Width
        PB.Top = Me.ClientRectangle.Height - PB.Height
        AddHandler PB.MouseDown, AddressOf PBs_MouseDown
        AddHandler PB.MouseMove, AddressOf PBs_MouseMove
        PB.Parent = Me
        If choice = "input" Then
            PB.Image = My.Resources.INPUTTRUE
        ElseIf choice = "output" Then
            PB.Image = My.Resources.OUTPUTNULL
        ElseIf choice = "and" Then
            PB.Image = My.Resources._AND
        ElseIf choice = "nand" Then
            PB.Image = My.Resources.NAND
        ElseIf choice = "or" Then
            PB.Image = My.Resources._OR
        ElseIf choice = "nor" Then
            PB.Image = My.Resources.NOR
        ElseIf choice = "xor" Then
            PB.Image = My.Resources._XOR
        ElseIf choice = "not" Then
            PB.Image = My.Resources._NOT
        End If
        PB.Name = tempID
        GatePB.Add(PB)
    End Sub
    Private Sub newGate(ByVal choice As String)
        Dim tempID As Integer
        If gatecount < 200 Then
            For i As Integer = 0 To 199
                If Gates(i).gateIsNull = True Then                  'Cycles through the array of objects with a loop and finds an unused one
                    Gates(i).gateIsNull = False                     'Sets it to 'Not Null'
                    Gates(i).gateType = choice                      'Sets the 'Type' variable to the choice
                    If choice = "input" Then
                        Gates(i).gateValue = 1
                    ElseIf choice = "output" Then
                        Gates(i).gateValue = 2
                        Gates(i).gateInput1 = 2
                    Else
                        Gates(i).gateValue = 2
                        Gates(i).gateInput1 = 2
                        Gates(i).gateInput2 = 2
                    End If
                    tempID = i
                    i = 199
                    gatecount += 1
                    AddGatePB(choice, tempID)
                End If
            Next
        Else
            message_output.Text = "Too many gates placed (200 limit) Please delete some before adding more"
        End If
    End Sub
    Private Sub DeleteGate(ByRef PB As PictureBox)
        RecalculateInputs(PB.Name)
        GatePB.Remove(PB)
        For i = 0 To 199
            If connections(i, PB.Name, 0).connectionValue <> 2 Then
                connections(i, PB.Name, 0).connectionDestination = -1
                connections(i, PB.Name, 0).connectionOrigin = -1
                connections(i, PB.Name, 0).connectionValue = 2
            End If
            If connections(i, PB.Name, 1).connectionValue <> 2 Then
                connections(i, PB.Name, 1).connectionDestination = -1
                connections(i, PB.Name, 1).connectionOrigin = -1
                connections(i, PB.Name, 1).connectionValue = 2
            End If
            If connections(PB.Name, i, 0).connectionValue <> 2 Then
                connections(PB.Name, i, 0).connectionDestination = -1
                connections(PB.Name, i, 0).connectionOrigin = -1
                connections(PB.Name, i, 0).connectionValue = 2
                Gates(i).gateInput1 = 2
            End If
            If connections(PB.Name, i, 1).connectionValue <> 2 Then
                connections(PB.Name, i, 1).connectionDestination = -1
                connections(PB.Name, i, 1).connectionOrigin = -1
                connections(PB.Name, i, 1).connectionValue = 2
                Gates(i).gateInput2 = 2
            End If
        Next
        Gates(Convert.ToInt32(PB.Name)).Finalize()
        Me.Refresh()
        PB.Dispose()
    End Sub

    Private Sub AddInput(ByVal sender As Object, ByVal e As EventArgs) Handles add_input.Click
        Dim choice As String = "input"
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
    Class MultiGate
        Inherits Window
        Private ID As Integer
        Private isNull As Boolean
        Private Type As String
        Private xpos As Integer
        Private ypos As Integer
        Private value As Integer
        Private input1 As Integer
        Private input2 As Integer
        Private IsConnected As String
        Private FromConnected As String

        Sub New(ByVal givenID As Integer)
            ID = givenID
            isNull = True
        End Sub
        Protected Overrides Sub Finalize()
            isNull = True
        End Sub
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
        Public Sub Calculate(ByVal prevID As Integer, ByVal ID As Integer)  'function has to find the outputs of the gate objects which led to it
            If gateType = "not" Then
                Try
                    input1 = connections(prevID, ID, 0).connectionValue
                Catch
                End Try
                If input1 <> 2 Then
                    If input1 = 1 Then
                        value = 0
                    ElseIf input1 = 0 Then
                        value = 1
                    Else
                        value = 2
                    End If
                End If
            ElseIf gateType = "output" Then
                Try
                    input1 = connections(prevID, ID, 0).connectionValue
                Catch
                End Try
                If input1 <> 2 Then
                    If input1 = 1 Then
                        value = 1
                    ElseIf input1 = 0 Then
                        value = 0
                    Else
                        value = 2
                    End If
                End If
            Else
                Try
                    input1 = connections(prevID, ID, 0).connectionValue
                Catch
                End Try
                Try
                    input2 = connections(prevID, ID, 1).connectionValue
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
        Sub New()
            origin = 999
            destination = 999
            value1 = 2
        End Sub
        Property connectionOrigin As Integer
            Get
                Return origin
            End Get
            Set(value As Integer)
                origin = value
            End Set
        End Property
        Property connectionDestination As Integer
            Get
                Return destination
            End Get
            Set(value As Integer)
                destination = value
            End Set
        End Property
        Property connectionValue As Integer
            Get
                Return value1
            End Get
            Set(value As Integer)
                value1 = value
            End Set
        End Property
    End Class
End Class