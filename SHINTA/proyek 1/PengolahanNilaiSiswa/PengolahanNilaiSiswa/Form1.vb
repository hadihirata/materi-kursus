Imports System.Data.Odbc
Public Class Form1
    Sub Data_Record()
        Call koneksi()
        Tabel = New OdbcDataAdapter("select * from DataSiswa", Database)
        Data = New DataSet
        Tabel.Fill(Data, "DataSiswa")
        DGV.DataSource = (Data.Tables("DataSiswa"))
        DGV.ReadOnly = True

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SiswaDataSet.DataSiswa' table. You can move, or remove it, as needed.
        '  Me.DataSiswaTableAdapter.Fill(Me.SiswaDataSet.DataSiswa)
        Call Koneksi()
        Call Data_Record()
        Call atur()
        TextBox1.Focus()
    End Sub
    Sub atur()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TextBox1.Focus()
            Exit Sub
        Else
            Try
                Call Koneksi()
                DML.Connection = Database
                DML.CommandType = CommandType.Text
                DML.CommandText = "insert into DataSiswa values('" & TextBox1.Text & "','" & TextBox2.Text & "','" _
                    & ComboBox1.Text & "','" & DateTimePicker1.Value & "','" & ComboBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                DML.ExecuteNonQuery()
                MsgBox("data telah disimpan")
                Call Koneksi()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
        Call bersih()

        Call Data_Record()
        Database.Close()
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Select Case Button2.Text
            Case "Update"
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = True
                Call ubah()
                Call bersih()
                Call Data_Record()
                Database.Close()

        End Select
    End Sub
    Sub ubah()
        Try
            Call Koneksi()
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "update DataSiswa set NamaSiswa='" & TextBox2.Text & "', JenisKelamin='" & ComboBox1.Text & "', TanggalLahir='" & DateTimePicker1.Value & "', Kelas='" & ComboBox2.Text & "', Alamat='" & TextBox3.Text & "', NoTelepon='" & TextBox4.Text & _
                "' where NIS='" & TextBox1.Text & "'"
            DML.ExecuteNonQuery()
            MsgBox("Data telah diubah")
            Call Koneksi()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        DGV.Refresh()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Call Koneksi()
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "delete from DataSiswa where NIS='" & TextBox1.Text & "'"
            DML.ExecuteNonQuery()
            MsgBox("data telah dihapus")
            'Call Atur()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        bersih()
        Call Data_Record()
        Database.Close()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub TextBox5_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            Koneksi()

            Dim cari1 As String = TextBox5.Text
            Dim sql = "select * from DataSiswa where NIS = '" & TextBox5.Text & "' "
            Dim sqlc As OdbcCommand = New OdbcCommand(sql, Database)
            Dim cari As OdbcDataReader
            cari = sqlc.ExecuteReader

            If cari.Read Then
                TextBox1.Text = cari("NIS")
                TextBox1.Enabled = False
                TextBox2.Text = cari("NamaSiswa")
                ComboBox1.Text = cari("JenisKelamin")
                DateTimePicker1.Value = cari("TanggalLahir")
                ComboBox2.Text = cari("Kelas")
                TextBox3.Text = cari("Alamat")
                TextBox4.Text = cari("NoTelepon")

            Else
                MessageBox.Show("Data tidak ditemukan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            cari.Close()
            Database.Close()
        End If
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
    End Sub
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call bersih()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
