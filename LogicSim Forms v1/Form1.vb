Imports WpfApp1

'Class MainWindow


'    Sub Constructgate()
'        Dim dragDrop As New Image

'        dragDrop.Height = 50
'        dragDrop.Width = 70
'        dragDrop.Source = New BitmapImage(New Uri("AND.png", UriKind.Relative))
'        dragDrop.AllowDrop = True
'        dragDrop.RenderTransformOrigin = New Point(30, 30)


'        'AddHandler dragDrop.MouseDown, AddressOf gatemousedown
'        'AddHandler dragDrop.MouseUp, AddressOf dragDropmouseup
'        'AddHandler dragDrop.MouseMove, AddressOf dragDropmousemove



'    End Sub

'Private Sub gatemousedown(sender As Object)
'    coords.Y = Cursor.Y - sender.top
'    coords.X = MousePosition.X - sender.left
'End Sub

'Private Sub runGates(sender As Object, e As RoutedEventArgs)

'End Sub
'Private Sub createInput(sender As Object, e As RoutedEventArgs)
'    Dim input(gatecount) As Input
'    gatecount += 1
'    MsgBox("Input Created, ID: " & input(gatecount).GateID)
'End Sub
'Private Sub createAnd(sender As Object, e As RoutedEventArgs)
'    Dim gate(gatecount) As Andgate
'    gatecount += 1
'    MsgBox("AND Gate No. " & gatecount & " has been created , ID: " & gate(gatecount).GateID)
'End Sub

'Private Sub createNand(sender As Object, e As RoutedEventArgs)
'    Dim gate(gatecount) As Nandgate
'    gatecount += 1
'    MsgBox("NAND Gate No. " & gatecount & " has been created , ID: " & gate(gatecount).GateID)
'End Sub

'Private Sub createNot(sender As Object, e As RoutedEventArgs)
'    Dim gate(gatecount) As NotGate
'    gatecount += 1
'    MsgBox("NOT Gate No. " & gatecount & " has been created , ID: " & gate(gatecount).GateID)
'End Sub

'Private Sub createOr(sender As Object, e As RoutedEventArgs)
'    Dim gate(gatecount) As OrGate
'    gatecount += 1
'    MsgBox("OR Gate No. " & gatecount & " has been created , ID: " & gate(gatecount).GateID)
'End Sub

'Private Sub createXor(sender As Object, e As RoutedEventArgs)
'    Dim gate(gatecount) As OrGate
'    gatecount += 1
'    MsgBox("XOR Gate No. " & gatecount & " has been created , ID: " & gate(gatecount).GateID)
'End Sub

'Private Sub createNor(sender As Object, e As RoutedEventArgs)
'    Dim gate(gatecount) As OrGate
'    gatecount += 1
'    MsgBox("NOR Gate No. " & gatecount & " has been created , ID: " & gate(gatecount).GateID)
'End Sub

'Private Sub gateMode_Checked(sender As Object, e As RoutedEventArgs) Handles gateMode.Checked
'    If gateMode.IsChecked Then
'        drawMode.IsChecked = False
'    End If
'End Sub

'Private Sub drawMode_checked(sender As Object, e As RoutedEventArgs) Handles gateMode.Checked
'    If drawMode.IsChecked Then
'        gateMode.IsChecked = False
'    End If
'End Sub

'Private Sub canvasLayout_DragEnter(ByVal sender As Object, ByVal e As System.Windows.DragEventArgs)
'    e.Effects = DragDropEffects.Copy
'End Sub

'Private Sub canvasLayout_DragOver(ByVal sender As Object, ByVal e As System.Windows.DragEventArgs)

'End Sub
'End Class

'Interface Gate
'    Sub Formtable()
'    Function Calculate()
'End Interface
'Class Input
'    Protected value As Boolean
'    Public GateID As String
'    Sub New()
'        value = False
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub

'    Protected Sub switchValue()
'        If value = True Then
'            value = False
'        Else
'            value = True
'        End If
'    End Sub
'End Class
'Class Andgate
'    Implements Gate
'    Protected input1 As Boolean
'    Protected input2 As Boolean
'    Protected output As Boolean
'    Protected IsConnected As String
'    Protected FromConnected As String
'    Public GateID As String
'    Protected Truthtable(,) As Array
'    Sub New()
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub
'    Public Sub Formtable() Implements Gate.Formtable
'        Throw New NotImplementedException()
'    End Sub

'    Public Function GateCalculate() Implements Gate.Calculate    'function has to find the outputs of the gate objects which led to it
'        If input1 = True And input2 = True Then
'            output = True
'        Else
'            output = False
'        End If
'        Return output
'    End Function
'End Class
'Class Nandgate
'    Implements Gate
'    Protected input1 As Boolean
'    Protected input2 As Boolean
'    Protected output As Boolean
'    Protected IsConnected As String
'    Protected FromConnected As String
'    Public GateID As String
'    Protected Truthtable(,) As Array
'    Sub New()
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub

'    Public Sub Formtable() Implements Gate.Formtable
'        Throw New NotImplementedException()
'    End Sub

'    Private Function GateCalculate() Implements Gate.Calculate      'function has to find the outputs of the gate objects which led to it
'        If input1 = True And input2 = True Then
'            output = False
'        Else
'            output = True
'        End If
'        Return output
'    End Function
'End Class
'Class NotGate
'    Implements Gate
'    Protected input1 As Boolean
'    Protected input2 As Boolean
'    Protected output As Boolean
'    Protected IsConnected As String
'    Protected FromConnected As String
'    Public GateID As String
'    Protected Truthtable(,) As Array
'    Sub New()
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub

'    Public Sub Formtable() Implements Gate.Formtable
'        Throw New NotImplementedException()
'    End Sub

'    Private Function GateCalculate() Implements Gate.Calculate      'function has to find the outputs of the gate objects which led to it
'        If input1 = True Then
'            output = False
'        ElseIf input1 = False Then
'            output = True
'        End If
'        Return output
'    End Function
'End Class
'Class OrGate
'    Implements Gate
'    Protected input1 As Boolean
'    Protected input2 As Boolean
'    Protected output As Boolean
'    Protected IsConnected As String
'    Protected FromConnected As String
'    Public GateID As String
'    Protected Truthtable(,) As Array
'    Sub New()
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub

'    Public Sub Formtable() Implements Gate.Formtable
'        Throw New NotImplementedException()
'    End Sub

'    Private Function GateCalculate() Implements Gate.Calculate      'function has to find the outputs of the gate objects which led to it
'        If input1 = True Or input2 = True Then
'            output = True
'        Else
'            output = False
'        End If
'        Return output
'    End Function
'End Class
'Class XorGate
'    Implements Gate
'    Protected input1 As Boolean
'    Protected input2 As Boolean
'    Protected output As Boolean
'    Protected IsConnected As String
'    Protected FromConnected As String
'    Public GateID As String
'    Protected Truthtable(,) As Array
'    Sub New()
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub

'    Public Sub Formtable() Implements Gate.Formtable
'        Throw New NotImplementedException()
'    End Sub

'    Private Function GateCalculate() Implements Gate.Calculate      'function has to find the outputs of the gate objects which led to it
'        If input1 = True Xor input2 = True Then
'            output = True
'        Else
'            output = False
'        End If
'        Return output
'    End Function
'End Class
'Class NorGate
'    Implements Gate
'    Protected input1 As Boolean
'    Protected input2 As Boolean
'    Protected output As Boolean
'    Protected IsConnected As String
'    Protected FromConnected As String
'    Public GateID As String
'    Protected Truthtable(,) As Array
'    Sub New()
'        GateID = Str(gatecount)
'        gatecount += 1
'    End Sub

'    Public Sub Formtable() Implements Gate.Formtable
'        Throw New NotImplementedException()
'    End Sub

'    Private Function GateCalculate() Implements Gate.Calculate      'function has to find the outputs of the gate objects which led to it
'        If input1 = True Or input2 = True Then
'            output = False
'        Else
'            output = True
'        End If
'        Return output
'    End Function
'End Class

