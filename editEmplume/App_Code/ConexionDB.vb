Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Configuration
Public Class ConexionDB
    Public Shared Function ObtenerConexion() As SqlConnection
        Dim cadenaConexion As String = ConfigurationManager.ConnectionStrings("conexionGeneral").ConnectionString
        Return New SqlConnection(cadenaConexion)
    End Function

End Class
