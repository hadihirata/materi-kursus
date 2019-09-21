Imports System.Data.Odbc
Public Class Prodi

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        DataGuru.Show()
    End Sub

    Private Sub Prodi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' On Error Resume Next
        If TextBox1.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TextBox1.Focus()
            Exit Sub
        Else
            Try
                Call koneksi()
                DML.Connection = Database
                DML.CommandType = CommandType.Text
                DML.CommandText = "insert into Prodi values('" & TextBox1.Text & "')"
                DML.ExecuteNonQuery()
                MsgBox("data telah disimpan")
                Call koneksi()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
        TextBox1.Text = ""

        Database.Close()
    End Sub
End Class