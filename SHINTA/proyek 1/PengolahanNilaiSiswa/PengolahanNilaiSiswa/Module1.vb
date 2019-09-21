Imports System.Data.Odbc
Module ModKoneksi
    Public Database As OdbcConnection
    Public Tabel As OdbcDataAdapter
    Public Data As DataSet
    Public Str As String

    Public Record As New BindingSource
    Public DML As New OdbcCommand
    Public Cari As OdbcDataReader


    Sub koneksi()
        Str = "Driver={MySQL ODBC 3.51 Driver};database=siswa;server=localhost;uid=root"
        Database = New OdbcConnection(Str)
        If Database.State = ConnectionState.Closed Then
            Database.Open()
        End If

    End Sub
End Module
