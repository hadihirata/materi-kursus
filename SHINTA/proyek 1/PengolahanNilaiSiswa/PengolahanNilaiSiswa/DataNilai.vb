Imports System.Data.Odbc
Public Class DataNilai
    Sub Data_Record()
        Try
            Call Koneksi()
            Tabel = New Data.Odbc.OdbcDataAdapter("select * from DataNilai", Database)
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
        'TODO: This line of code loads data into the 'SiswaDataSet.MataPelajaran' table. You can move, or remove it, as needed.
        ' Me.MataPelajaranTableAdapter.Fill(Me.SiswaDataSet.MataPelajaran)
        Call Koneksi()
        Call Data_Record()
        Call atur()

        GroupBox2.Enabled = False

    End Sub
   
    Sub Ambil1()
        Call koneksi()
        Tabel = New Data.Odbc.OdbcDataAdapter("select distinct Kelas from MataPelajaran order by 1", Database)
        Data = New DataSet
        Tabel.Fill(Data)
        Record.DataSource = Data
        Record.DataMember = Data.Tables(0).ToString()

        Try
            Dim a As DataRow
            ComboBox2.Items.Clear()
            For Each a In Data.Tables(0).Rows
                ComboBox2.Items.Add(a.Item(0))
            Next a
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Database.Close()

    End Sub
    Sub Ambil2()
        Tabel = New Data.Odbc.OdbcDataAdapter("select * from MataPelajaran", Database)
        Data = New DataSet
        Tabel.Fill(Data)
        Record.DataSource = Data
        Record.DataMember = Data.Tables(0).ToString()

        Try
            Dim a As DataRow
            ComboBox2.Items.Clear()
            For Each a In Data.Tables(0).Rows
                ComboBox2.Items.Add(a.Item(4))
            Next a
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Database.Close()

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

        Txtnama.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TEXTBOX2.Text = ""
        ComboBox2.Text = ""
        txtjumlah.Text = ""
        txtnilai.Text = ""
        txtrata.Text = ""
        txtket.Text = ""


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub
    Sub ubah()
        Try
            Call Koneksi()
            DML.Connection = Database
            DML.CommandType = CommandType.Text
            DML.CommandText = "update DataNilai set  NamaSiswa='" & Txtnama.Text & "',  Kelas='" & ComboBox2.Text & "', Mapel1='" & TextBox4.Text & "', Nilai1='" & TextBox10.Text & "', Mapel2='" & TextBox5.Text & "', Nilai2='" & TextBox11.Text & "', Mapel3='" & TextBox6.Text & "', Nilai3='" & TextBox12.Text & "' , Mapel4='" & TextBox7.Text & "' , Nilai4='" & TextBox13.Text & "', Mapel5='" & TextBox8.Text & "' , Nilai5='" & TextBox14.Text & "', Mapel6='" & TextBox9.Text & "' , Nilai6='" & TextBox15.Text & "' , JumlahNilai='" & txtjumlah.Text & "', RataRata='" & txtrata.Text & "' , NilaiHuruf='" & txtnilai.Text & "' where NIS='" & TEXTBOX2.Text & "'"
            DML.ExecuteNonQuery()
            MsgBox("Data telah diubah")
            Call Koneksi()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Call Data_Record()
        Database.Close()
        TextBox1.Text = ""


    End Sub
    Private Sub TextBox5_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress

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
        If Txtnama.Text = "" Or TEXTBOX2.Text = "" Or ComboBox2.Text = "" Or txtjumlah.Text = "" Or txtrata.Text = "" Or txtnilai.Text = "" Then
            MsgBox("Data Belum Lengkap")

            Exit Sub
        Else
            Try
                Call koneksi()
                DML.Connection = Database
                DML.CommandType = CommandType.Text
                DML.CommandText = "insert into DataNilai values('" & TEXTBOX2.Text & "','" & Txtnama.Text & "','" & ComboBox2.Text & "','" & TextBox4.Text & "','" & TextBox10.Text & "','" & TextBox5.Text & "','" & TextBox11.Text & "','" & TextBox6.Text & "','" & TextBox12.Text & "','" & TextBox7.Text & "','" & TextBox13.Text & "','" & TextBox8.Text & "','" & TextBox14.Text & "','" & TextBox9.Text & "','" & TextBox15.Text & "','" & txtjumlah.Text & "','" & txtrata.Text & "','" & txtnilai.Text & "','" & txtket.Text & "')"
                DML.ExecuteNonQuery()
                MsgBox("data telah disimpan")
                Call koneksi()
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
            DML.CommandText = "delete from DataNilai where NIS='" & TEXTBOX2.Text & "'"
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
    Private Sub TEXTBOX2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case Button1.Text
            Case "Tambah"
                GroupBox2.Enabled = True
                Button1.Text = "Simpan"
                'Call Ambil()
                Call Ambil1()
            Case "Simpan"
                Button1.Text = "Tambah"
                Call simpan()
                Call atur()

        End Select
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call coba1()
    End Sub
    Sub coba()
        Call Koneksi()
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select Mapel from MataPelajaran where Kelas = '" & ComboBox2.Text & "' "
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()
            TextBox4.Text = Cari("Mapel")
        End If
    End Sub
    Sub coba1()
        Call koneksi()
        Call koneksi()
        Tabel = New Data.Odbc.OdbcDataAdapter("select * from MataPelajaran", Database)
        Data = New DataSet
        Tabel.Fill(Data)
        Record.DataSource = Data
        Record.DataMember = Data.Tables(0).ToString()
        Dim mapel(6) As String
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select Mapel from MataPelajaran where Kelas = '" & ComboBox2.Text & "' "
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()
            Dim oDS As New DataSet
            Dim oDa As New OdbcDataAdapter
            oDa = New Data.Odbc.OdbcDataAdapter("SELECT * FROM MataPelajaran where Kelas = '" & ComboBox2.Text & "' ", Database)
            oDa.Fill(oDS)

            Dim oTbl As New DataTable
            oTbl = oDS.Tables(0)

            On Error Resume Next
            TextBox4.Text = oTbl.Rows(0).Item(1)
            TextBox5.Text = oTbl.Rows(1).Item(1)
            TextBox6.Text = oTbl.Rows(2).Item(1)
            TextBox7.Text = oTbl.Rows(3).Item(1)
            TextBox8.Text = oTbl.Rows(4).Item(1)
            TextBox9.Text = oTbl.Rows(5).Item(1)

        End If
    End Sub
    Sub coba2()
        Call koneksi()
        Call koneksi()
        Tabel = New Data.Odbc.OdbcDataAdapter("select * from MataPelajaran", Database)
        Data = New DataSet
        Tabel.Fill(Data)
        Record.DataSource = Data
        Record.DataMember = Data.Tables(0).ToString()
        '  DGV.DataSource = Record
        '  TextBox6.Text = Record(Tabel.data(0))
        Dim mapel(6) As String
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select Mapel from MataPelajaran where Kelas = '" & ComboBox2.Text & "' "
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()



            Dim oDS As New DataSet
            Dim oDa As New OdbcDataAdapter
            oDa = New Data.Odbc.OdbcDataAdapter("SELECT * FROM MataPelajaran where Kelas = '" & ComboBox2.Text & "' ", Database)
            oDa.Fill(oDS)

            Dim oTbl As New DataTable
            oTbl = oDS.Tables(0)

            On Error Resume Next
            TextBox4.Text = oTbl.Rows(0).Item(1)
            TextBox5.Text = oTbl.Rows(1).Item(1)
            TextBox6.Text = oTbl.Rows(2).Item(1)
            TextBox7.Text = oTbl.Rows(3).Item(1)
            TextBox8.Text = oTbl.Rows(4).Item(1)
            TextBox9.Text = oTbl.Rows(5).Item(1)

            Database.Close()
        End If
    End Sub
    Sub tampildata()
        Dim cari2 As String = TextBox5.Text
        Dim sql = "select Mapel from MataPelajaran where Kelas = '" & ComboBox2.Text & "' "
        Dim sqlc As odbcCommand = New odbcCommand(sql, Database)
        Dim cari As OdbcDataReader
        cari = sqlc.ExecuteReader

        If cari.Read Then
            '  Txtid.Text = cari("ID")
            TextBox4.Text = cari("Mapel")

        End If


    End Sub

    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        txtjumlah.Text = Val(TextBox10.Text) + Val(TextBox11.Text) + Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text)
        txtrata.Text = Val(txtjumlah.Text) / 6

        If txtjumlah.Text <= 30 Then
            txtnilai.Text = "D"
            txtket.Text = "BELAJAR LAH LEBIH GIAT"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "C"
            txtket.Text = "SELAMAT NILAI ANDA CUKUP"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "B"
            txtket.Text = " SELAMAT NILAI MEMUASKAN"
        Else
            txtnilai.Text = "A"
            txtket.Text = " SELAMAT NILAI SEMPURNA"
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call coba2()
    End Sub

    Private Sub TEXTBOX2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call koneksi()
        DML.Connection = Database
        DML.CommandType = CommandType.Text
        DML.CommandText = "select * from DataSiswa where NIS='" & TEXTBOX2.Text & "'"
        Cari = DML.ExecuteReader
        If Cari.HasRows = True Then
            Cari.Read()
            Txtnama.Text = Cari("NamaSiswa")
        End If
        txtjumlah.Enabled = False
        txtrata.Enabled = False
        txtnilai.Enabled = False

        Database.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            koneksi()

            Dim cari1 As String = TextBox1.Text
            Dim sql = "select * from DataNilai where ID = '" & TextBox1.Text & "' "
            Dim sqlc As OdbcCommand = New OdbcCommand(sql, Database)
            Dim cari As OdbcDataReader
            cari = sqlc.ExecuteReader

            If cari.Read Then
                TextBox2.Text = cari("NIS")
                TextBox2.Enabled = False
                ' TEXTBOX2.Text = cari("NIS")
                Txtnama.Text = cari("NamaSiswa")
                ComboBox2.Text = cari("Kelas")
                TextBox4.Text = cari("Mapel1")
                TextBox10.Text = cari("Nilai1")
                TextBox5.Text = cari("Mapel2")
                TextBox11.Text = cari("Nilai2")
                TextBox6.Text = cari("Mapel3")
                TextBox12.Text = cari("Nilai3")
                TextBox7.Text = cari("Mapel4")
                TextBox13.Text = cari("Nilai4")
                TextBox8.Text = cari("Mapel5")
                TextBox14.Text = cari("Nilai5")
                TextBox9.Text = cari("Mapel6")
                TextBox15.Text = cari("Nilai6")
                txtjumlah.Text = cari("JumlahNilai")
                txtrata.Text = cari("RataRata")
                txtnilai.Text = cari("NilaiHuruf")
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then


            koneksi()

            Dim cari1 As String = TextBox1.Text
            Dim sql = "select * from DataSiswa where NIS = '" & TextBox2.Text & "' "
            Dim sqlc As OdbcCommand = New OdbcCommand(sql, Database)
            Dim cari As OdbcDataReader
            cari = sqlc.ExecuteReader

            If cari.Read Then
                TextBox2.Text = cari("NIS")
                'TextBox2.Enabled = False
                ' TEXTBOX2.Text = cari("NIS")
                Txtnama.Text = cari("NamaSiswa")

            Else
                MessageBox.Show("Data tidak ditemukan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            cari.Close()
            Database.Close()

            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = False
            Button5.Enabled = False
        End If
    End Sub

   
    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        txtjumlah.Text = Val(TextBox10.Text) + Val(TextBox11.Text) + Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text)
        txtrata.Text = Val(txtjumlah.Text) / 6

        If txtjumlah.Text <= 30 Then
            txtnilai.Text = "D"
            txtket.Text = "BELAJAR LAH LEBIH GIAT"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "C"
            txtket.Text = "SELAMAT NILAI ANDA CUKUP"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "B"
            txtket.Text = " SELAMAT NILAI MEMUASKAN"
        Else
            txtnilai.Text = "A"
            txtket.Text = " SELAMAT NILAI SEMPURNA"
        End If
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        txtjumlah.Text = Val(TextBox10.Text) + Val(TextBox11.Text) + Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text)
        txtrata.Text = Val(txtjumlah.Text) / 6

        If txtjumlah.Text <= 30 Then
            txtnilai.Text = "D"
            txtket.Text = "BELAJAR LAH LEBIH GIAT"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "C"
            txtket.Text = "SELAMAT NILAI ANDA CUKUP"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "B"
            txtket.Text = " SELAMAT NILAI MEMUASKAN"
        Else
            txtnilai.Text = "A"
            txtket.Text = " SELAMAT NILAI SEMPURNA"
        End If
    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        txtjumlah.Text = Val(TextBox10.Text) + Val(TextBox11.Text) + Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text)
        txtrata.Text = Val(txtjumlah.Text) / 6

        If txtjumlah.Text <= 30 Then
            txtnilai.Text = "D"
            txtket.Text = "BELAJAR LAH LEBIH GIAT"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "C"
            txtket.Text = "SELAMAT NILAI ANDA CUKUP"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "B"
            txtket.Text = " SELAMAT NILAI MEMUASKAN"
        Else
            txtnilai.Text = "A"
            txtket.Text = " SELAMAT NILAI SEMPURNA"
        End If
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        txtjumlah.Text = Val(TextBox10.Text) + Val(TextBox11.Text) + Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text)
        txtrata.Text = Val(txtjumlah.Text) / 6

        If txtjumlah.Text <= 30 Then
            txtnilai.Text = "D"
            txtket.Text = "BELAJAR LAH LEBIH GIAT"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "C"
            txtket.Text = "SELAMAT NILAI ANDA CUKUP"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "B"
            txtket.Text = " SELAMAT NILAI MEMUASKAN"
        Else
            txtnilai.Text = "A"
            txtket.Text = " SELAMAT NILAI SEMPURNA"
        End If
    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged
        txtjumlah.Text = Val(TextBox10.Text) + Val(TextBox11.Text) + Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text)
        txtrata.Text = Val(txtjumlah.Text) / 6

        If txtjumlah.Text <= 30 Then
            txtnilai.Text = "D"
            txtket.Text = "BELAJAR LAH LEBIH GIAT"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "C"
            txtket.Text = "SELAMAT NILAI ANDA CUKUP"

        ElseIf txtjumlah.Text <= 40 Then
            txtnilai.Text = "B"
            txtket.Text = " SELAMAT NILAI MEMUASKAN"
        Else
            txtnilai.Text = "A"
            txtket.Text = " SELAMAT NILAI SEMPURNA"
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
