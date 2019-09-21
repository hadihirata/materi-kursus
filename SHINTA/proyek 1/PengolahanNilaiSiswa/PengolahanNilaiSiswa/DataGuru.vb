Imports System.Data.Odbc
Public Class DataGuru
    Sub Data_Record()
       Call koneksi()
        Tabel = New OdbcDataAdapter("select * from DataGuru", Database)
        Data = New DataSet
        Tabel.Fill(Data, "DataGuru")
        DGV.DataSource = (Data.Tables("DataGuru"))
        DGV.ReadOnly = True

    End Sub
    Sub atur()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TEXTBOX2.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub ubah()
        Try
            Call Koneksi()
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "update DataGuru set NamaGuru='" & TextBox2.Text & "', JenisKelamin='" & TEXTBOX2.Text & "', Pendidikan='" & ComboBox2.Text & "', Prodi='" & ComboBox3.Text & "', Alamat='" & TextBox3.Text & "', NoTelepon='" & TextBox4.Text & "' where NIP='" & TextBox1.Text & "'"
            DML.ExecuteNonQuery()
            MsgBox("Data telah diubah")
            Call Koneksi()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        DGV.Refresh()
        Database.Close()


    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call bersih()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' On Error Resume Next
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TEXTBOX2.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TextBox1.Focus()
            Exit Sub
        Else
            Try
                Call Koneksi()
                DML.Connection = Database
                DML.CommandType = CommandType.Text
                DML.CommandText = "insert into DataGuru values('" & TextBox1.Text & "','" & TextBox2.Text & "','" _
                    & TEXTBOX2.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
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

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Call Koneksi()
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "delete from DataGuru where NIP='" & TextBox1.Text & "'"
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

    Private Sub DataGuru_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call Data_Record()
        Call atur()
        TextBox1.Focus()
        Call Ambil()

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            Koneksi()

            Dim cari1 As String = TextBox5.Text
            Dim sql = "select * from DataGuru where NIP = '" & TextBox5.Text & "' "
            Dim sqlc As Odbc.OdbcCommand = New Odbc.OdbcCommand(sql, Database)
            Dim cari As Odbc.OdbcDataReader
            cari = sqlc.ExecuteReader

            If cari.Read Then
                TextBox1.Text = cari("NIP")
                TextBox1.Enabled = False
                TextBox2.Text = cari("NamaGuru")
                TEXTBOX2.Text = cari("JenisKelamin")
                ComboBox2.Text = cari("Pendidikan")
                ComboBox3.Text = cari("Prodi")
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

    Private Sub form_load()
        Throw New NotImplementedException
    End Sub

    Private Sub DataGuru_Load_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Hide()
        Prodi.Show()
    End Sub
    Sub Ambil()
        Call koneksi()
        Tabel = New Data.Odbc.OdbcDataAdapter("select * from Prodi", Database)
        Data = New DataSet
        Tabel.Fill(Data)
        Record.DataSource = Data
        Record.DataMember = Data.Tables(0).ToString()

        Try
            Dim a As DataRow
            ComboBox3.Items.Clear()
            For Each a In Data.Tables(0).Rows
                ComboBox3.Items.Add(a.Item(0))
            Next a
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Exit Sub
        Database.Close()
        Cari.Close()

    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Call koneksi()
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select * from Prodi where NamaProdi='" & ComboBox3.Text & "'"
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()

            Cari.Close()

        End If

    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub
End Class
