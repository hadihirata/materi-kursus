Imports MySql.Data.MySqlClient
Imports System.Drawing.Bitmap
Imports System.Data.SqlClient

Public Class Loginm
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Username dan passwordtidak boleh kosong", MsgBoxStyle.Critical)
            TextBox1.Focus()
        Else
            Call koneksi()
            cmd = New MySqlCommand("Select * from Login where User = '" & TextBox1.Text & "' and Password ='" & TextBox2.Text & "'  and Type ='" & ComboBox1.Text & "'", database)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Me.Hide()
                Form5.Show()
                If ComboBox1.Text = "Administrator" Then
                    Form5.Button1.Enabled = True
                    Form5.Button2.Enabled = True
                    Form5.Button3.Enabled = True
                    Form5.Button4.Enabled = True

                ElseIf ComboBox1.Text = "Kasir" Then
                    Form5.Button2.Enabled = True
                    Form5.Button3.Enabled = True
                    Form5.Button1.Enabled = False
                    Form5.Button4.Enabled = False
                Else
                    MsgBox("Username atau Password Salah")
                End If
            End If
        End If
    End Sub

    Private Sub Loginm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class