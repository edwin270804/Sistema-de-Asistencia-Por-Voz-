using SistemaAsistenciaPorVoz.DAL;
using SistemaAsistenciaPorVoz.DAL.Common;
using SistemaAsistenciaPorVoz.Entity;
using SistemaAsistenciaPorVoz.UI.Forms;


namespace SistemaAsistenciaPorVoz.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();

            ConfiguracionDAL configuracionDAL = new();

            // verificar si existe una conexion
            if (!configuracionDAL.ExisteConfiguracion())
            {
                FrmConfigurarConexion frmConfigurar = 
                    new FrmConfigurarConexion();

                DialogResult resultado = frmConfigurar.ShowDialog();

                // Si el usuario no configuro la conexion,
                // se cierra la aplicacion
                if (resultado != DialogResult.OK)
                    return;

            }

            // Obtener conexion Guardada
            ConexionEntity? config =
                configuracionDAL.Obtener();

            if(config is null)
            {
                MessageBox.Show("No fue posible cargar la configuracion de conexion","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            // Construir Cadena de Conexion
            Conexion.CadenaConexion =
                $"Server={config.Servidor};" +
                $"Database={config.BaseDatos};" +
                $"User Id={config.UsuarioSql};" +
                $"Password={config.Password};" +
                $"TrustServerCertificate=True;";

            





            Application.Run(new FrmLogin());

           /* MessageBox.Show(
                "Configuración cargada correctamente.",
                "Sistema de Asistencia por Voz",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);*/
        }
    }
}