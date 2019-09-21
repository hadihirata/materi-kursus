Imports System.Data.Odbc
Public Class MataPelajaran
    Sub Data_Record()
        Try
            Call Koneksi()
            Tabel = New Data.Odbc.OdbcDataAdapter("select * from MataPelajaran", Database)
            Data = New DataSet
            Tabel.Fill(Data)
            Record.DataSource = Data
            Record.DataMember = Data.Tables(0).ToString()
            '  DGV.DataSource = Record
            ' DGV.Columns(0).Width = 100
            ' DGV.Columns(5).Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString())

        End Try

    End Sub
    Private Sub MataPelajaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call Data_Record()
        Call atur()
        TextBox1.Focus()
        Call Ambil()
        GroupBox1.Enabled = False
    End Sub
    Sub Ambil()
        Call koneksi()
        Tabel = New Data.Odbc.OdbcDataAdapter("select * from DataGuru", Database)
        Data = New DataSet
        Tabel.Fill(Data)
        Record.DataSource = Data
        Record.DataMember = Data.Tables(0).ToString()

        Try
            Dim a As DataRow
            ComboBox1.Items.Clear()
            For Each a In Data.Tables(0).Rows
                ComboBox1.Items.Add(a.Item(0))
            Next a
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Exit Sub
        Database.Close()
        Cari.Close()

    End Sub
    Sub atur()
        Button1.Enabled = True
        Button1.Text = "Tambah"
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True

    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub
    Sub ubah()
        Call koneksi()
        Try
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "update MataPelajaran set Mapel= '" & TextBox2.Text & "', Nip='" & ComboBox1.Text & "',  NamaGuru='" & TextBox3.Text & "', Kelas='" & ComboBox2.Text & "' where KodeMapel='" & TextBox1.Text & "'"
            DML.ExecuteNonQuery()
            MsgBox("Data telah diubah")
            '  Call koneksi()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        Database.Close()

    End Sub
    Private Sub TextBox5_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            Koneksi()

            Dim cari1 As String = TextBox5.Text
            Dim sql = "select * from MataPelajaran where KodeMapel = '" & TextBox5.Text & "' "
            Dim sqlc As OdbcCommand = New OdbcCommand(sql, Database)
            Dim cari As OdbcDataReader
            cari = sqlc.ExecuteReader

            If cari.Read Then
                TextBox1.Text = cari("KodeMapel")
                TextBox1.Enabled = False
                TextBox2.Text = cari("Mapel")
                ComboBox1.Text = cari("Nip")
                TextBox3.Text = cari("NamaGuru")
                ComboBox2.Text = cari("Kelas")
            Else
                MessageBox.Show("Data tidak ditemukan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            cari.Close()
            Database.Close()
        End If
        GroupBox1.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call bersih()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True
    End Sub

    Sub simpan()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Data Belum Lengkap")
            Exit Sub
        Else
            Try
                Database.Open()
                Call koneksi()
                DML.Connection = Database
                DML.CommandType = CommandType.Text
                DML.CommandText = "insert into MataPelajaran values('" & TextBox1.Text & "','" & TextBox2.Text & "','" _
                    & ComboBox1.Text & "','" & TextBox3.Text & "','" & ComboBox2.Text & "')"
                DML.ExecuteNonQuery()
                MsgBox("data telah disimpan")
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
        Call bersih()
        ' Call Data_Record()
        Database.Close()

    End Sub
    Sub simpan1()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Data Belum Lengkap")
            Exit Sub
        Else
            Try
                Call koneksi()
                DML.Connection = Database
                DML.CommandType = CommandType.Text
                DML.CommandText = "insert into MataPelajaran values('" & TextBox1.Text & "','" & TextBox2.Text & "','" _
                    & ComboBox1.Text & "','" & TextBox3.Text & "','" & ComboBox2.Text & "')"
                DML.ExecuteNonQuery()
                MsgBox("data telah disimpan")
                Call koneksi()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
        Call bersih()
        '  Call Data_Record()
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
                '   Call Data_Record()
                Database.Close()

        End Select
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Call Koneksi()
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "delete from MataPelajaran where KodeMapel='" & TextBox1.Text & "'"
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

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MenuUtama.Show()
        Me.Hide()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Koneksi()
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select * from DataGuru where NIP='" & ComboBox1.Text & "'"
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()
            TextBox3.Text = Cari("NamaGuru")
        End If
        Database.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case Button1.Text
            Case "Tambah"
                GroupBox1.Enabled = True
                Button1.Text = "Simpan"
                Call Ambil()
            Case "Simpan"
                Button1.Text = "Tambah"
                Call simpan1()
                Call atur()

        End Select
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select * from DataGuru where NIP='" & ComboBox1.Text & "'"
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()
            TextBox3.Text = Cari("NamaGuru")
            Cari.Close()
           
        End If


    End Sub

    End Class
