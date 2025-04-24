Imports System.Data.SqlClient
Imports System.Configuration
Partial Class Autor
    Inherits System.Web.UI.Page
    Dim conexion As SqlConnection

    Public Property LlblError As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarAutor()
        End If
    End Sub
    Sub crearAutor()
        Try
            Dim nombre As String = txtNomAutor.Text.Trim().Replace("'", "''")
            Dim apellido As String = txtApelliAutor.Text.Trim().Replace("'", "''")
            Dim fechaNac As String = calFechaNac.SelectedDate.ToString("yyyy-MM-dd")
            Dim biografia As String = txtBiografia.Text.Trim().Replace("'", "''")
            Dim query As String = "INSERT INTO Autor (nombreAutor, apellidoAutor, fechaNacimiento, biografiaAutor) " &
                              "VALUES ('" & nombre & "', '" & apellido & "', '" & fechaNac & "', '" & biografia & "')"
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using comando As SqlCommand = New SqlCommand(query, conexion)
                    comando.ExecuteNonQuery()
                End Using

            End Using
            LlblMessage.Text = "Autor creado correctamente."
        Catch ex As Exception
            LblError.Text = "Error al crear el autor: " & ex.Message
        End Try

    End Sub
    Sub cargarAutor()
        Dim sqlAutor As SqlDataSource = CType(FindControl("sqlAutor"), SqlDataSource)
        sqlAutor.ConnectionString = ConfigurationManager.ConnectionStrings("MiConexionSQLServer").ConnectionString
        sqlAutor.SelectCommand = "SELECT * FROM Autor"
        sqlAutor.DataBind()
    End Sub

    Private Sub btnCrearAutor_Click(sender As Object, e As EventArgs) Handles btnCrearAutor.Click
        crearAutor()
    End Sub

    Private Sub btnCalendario_Click(sender As Object, e As ImageClickEventArgs) Handles btnCalendario.Click
        pnlCalendario.Visible = Not pnlCalendario.Visible
    End Sub
    Protected Sub calFechaNac_SelectionChanged(sender As Object, e As EventArgs)
        txtFechaNaci.Text = calFechaNac.SelectedDate.ToString("yyyy-MM-dd")
        pnlCalendario.Visible = False
    End Sub

End Class
