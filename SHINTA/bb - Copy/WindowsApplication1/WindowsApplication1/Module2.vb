Imports System.Data.Odbc

Module Module2

    Public Database1 As OdbcConnection
    Public Tabel1 As OdbcDataAdapter
    Public Data1 As DataSet
    Public Str1 As String
    Public Record1 As New BindingSource
    Public DML1 As New OdbcCommand
    Public Cari1 As OdbcDataReader
    Sub koneksi2()
        Str1 = "Driver={MySQL ODBC 3.51 Driver};database=cakeshop;server=localhost;uid=root"
        Database1 = New OdbcConnection(Str1)
        If Database1.State = ConnectionState.Closed Then
            Database1.Open()
        End If

    End Sub

End Module
