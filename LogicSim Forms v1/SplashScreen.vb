Class SplashScreen
    Public Shared WithEvents WindowInstance As New Window
    Private Sub start_prof_Click(sender As Object, e As EventArgs) Handles start_prof.Click
        Me.Hide()
        WindowInstance.windowProf = True
        WindowInstance.Show()
    End Sub

    Private Sub start_nonprof_Click(sender As Object, e As EventArgs) Handles start_nonprof.Click
        Me.Hide()
        WindowInstance.windowProf = False
        WindowInstance.Show()
    End Sub
End Class