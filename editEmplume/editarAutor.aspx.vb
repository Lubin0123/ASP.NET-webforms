
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Partial Class editarAutor
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            listarUsuarios()
        End If
        sqlAutores.ConnectionString = ConexionDB.ObtenerConexion().ConnectionString
    End Sub
    Sub editarAutor()
        Dim idAutor As String = hdnIdAutor.Value
        Dim nombreAutor As String = txtNomAutor.Text.Trim()
        Dim apellidoAutor As String = txtApelliAutor.Text.Trim()
        Dim fechaNac As String = calFechaNacimient.SelectedDate.ToString("yyyy-MM-dd")
        Dim biografia As String = txtBiografia.Text.Trim()

        Dim conexion As SqlConnection
        conexion = ConexionDB.ObtenerConexion()
        Dim cmd As SqlCommand

        Try
            conexion.Open()
            cmd = New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.Connection = conexion
            cmd.CommandText = "update Autor SET nombreAutor = '" & nombreAutor & "', apellidoAutor = '" & apellidoAutor & "', " &
            "fechaNacimiento = '" & fechaNac & "', biografiaAutor = '" & biografia & "' WHERE idAutor = '" & idAutor & "';"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            LlblMessage.Text = "Error al crear el usuario"
            LlblMessage.CssClass = "from-label text-white"
            MostrarToast("dbg-ganger")
        End Try
    End Sub

    Sub listarUsuarios()
        'crear la conexion con el selectCommand y demas pasos 
        'sqlAutores.SelectCommand = "SELECT nombreAutor FROM Autor where idAutor = '" & idAutor & "'";

    End Sub
    Protected Sub calFechaNacimient_SelectionChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnRegPag_Click(sender As Object, e As EventArgs) Handles btnRegPag.Click
        Response.Redirect("Autor.aspx")
    End Sub

    Private Sub MostrarToast(color As String)
        Dim script As String = "
       bootstrap.Modal.getOrCreateInstance(document.getElementById('confirm')).hide();
       document.getElementById('liveToast').className = 'toast hide align-items-center " & color & "';" &
       "bootstrap.Toast.getOrCreateInstance(document.getElementById('liveToast')).show();"
        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, Guid.NewGuid().ToString(), script, True)
    End Sub

End Class
