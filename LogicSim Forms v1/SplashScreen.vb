Class SplashScreen
    Public Shared WithEvents WindowInstance As New Window
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        WindowInstance.Show()
    End Sub
End Class