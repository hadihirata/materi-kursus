Imports System.Data.Odbc
Public Class Login
    Dim CMD As New OdbcCommand
    Dim RD As OdbcDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Username dan passwordtidak boleh kosong", MsgBoxStyle.Critical)
            TextBox1.Focus()
        Else
            Call koneksi()
            CMD = New OdbcCommand("Select * from Login where Username = '" & TextBox1.Text & "' and Password ='" & TextBox2.Text & "'  and Type ='" & ComboBox1.Text & "'", Database)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then                    
                Me.Hide()
                MenuUtama.Show()
                If ComboBox1.Text = "Student" Then
                    MenuUtama.BtnSiswa.Enabled = True
                    MenuUtama.BtnGuru.Enabled = False
                    MenuUtama.BtnMapel.Enabled = False
                    MenuUtama.BtnNilai.Enabled = False
                    MenuUtama.BtnKeluar.Enabled = True
                    Form1.GroupBox2.Visible = False
                    Form1.Button1.Visible = True
                    Form1.Button2.Visible = False
                    Form1.Button3.Visible = False
                    Form1.Button4.Visible = False
                    Form1.Button5.Visible = True
                ElseIf ComboBox1.Text = "Teacher" Then
                    MenuUtama.BtnSiswa.Enabled = False
                    MenuUtama.BtnGuru.Enabled = True
                    MenuUtama.BtnNilai.Enabled = False
                    MenuUtama.BtnMapel.Enabled = True
                    MenuUtama.BtnKeluar.Enabled = True
                    Form1.GroupBox2.Visible = False
                    DataGuru.Button1.Visible = True
                    DataGuru.Button2.Visible = False
                    DataGuru.Button3.Visible = False
                    DataGuru.Button4.Visible = False
                    DataGuru.Button5.Visible = True
                    MataPelajaran.GroupBox2.Visible = False
                    MataPelajaran.Button1.Visible = True
                    MataPelajaran.Button2.Visible = False
                    MataPelajaran.Button3.Visible = False
                    MataPelajaran.Button4.Visible = False
                    MataPelajaran.Button5.Visible = True
                ElseIf ComboBox1.Text = "Administrator" Then
                    MenuUtama.BtnSiswa.Enabled = False
                    MenuUtama.BtnMapel.Enabled = False
                    MenuUtama.BtnNilai.Enabled = True
                    MenuUtama.BtnGuru.Enabled = False
                    MenuUtama.BtnKeluar.Enabled = True
                    ' DataNilai.GroupBox2.Visible = False
                    DataNilai.Button1.Visible = True
                    DataNilai.Button2.Visible = False
                    DataNilai.Button3.Visible = False
                    DataNilai.Button4.Visible = False
                    DataNilai.Button5.Visible = True
                ElseIf ComboBox1.Text = "Super User" Then
                    MenuUtama.BtnSiswa.Enabled = True
                    MenuUtama.BtnKeluar.Enabled = True
                    MenuUtama.BtnMapel.Enabled = True
                    MenuUtama.BtnNilai.Enabled = True
                    MenuUtama.BtnGuru.Enabled = True
                Else
                    MsgBox("Username atau Password Salah")
                End If
            End If
        End If
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox1.Focus()
        End If
    End Sub


    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
