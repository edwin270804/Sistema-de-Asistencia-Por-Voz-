using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;


namespace SistemaAsistenciaPorVoz.UI.Forms
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            pnlContent = new ModernUI.Controls.ModernPanel();
            pnlContenedorPrincipal = new Panel();
            pnlDashboard = new Panel();
            modernPanel1 = new ModernUI.Controls.ModernPanel();
            lblFecha = new ModernUI.Controls.ModernLabel();
            modernLabel2 = new ModernUI.Controls.ModernLabel();
            iconButton1 = new IconButton();
            lblBienvenido = new ModernUI.Controls.ModernLabel();
            pnlContenedorClases = new Panel();
            pnlEncabezados = new Panel();
            pnlAlertas = new ModernUI.Controls.ModernPanel();
            modernLabel3 = new ModernUI.Controls.ModernLabel();
            lblNumAlertas = new ModernUI.Controls.ModernLabel();
            modernLabel5 = new ModernUI.Controls.ModernLabel();
            btnIco3 = new IconButton();
            pnlAsistencia = new ModernUI.Controls.ModernPanel();
            lblEstadoAsistencia = new ModernUI.Controls.ModernLabel();
            lblNumAsistencia = new ModernUI.Controls.ModernLabel();
            modernLabel4 = new ModernUI.Controls.ModernLabel();
            btnIco2 = new IconButton();
            pnlClases = new ModernUI.Controls.ModernPanel();
            lblSubtitulo = new ModernUI.Controls.ModernLabel();
            lblNúmero = new ModernUI.Controls.ModernLabel();
            lblTitulo = new ModernUI.Controls.ModernLabel();
            btnIco1 = new IconButton();
            pnlSideBar = new ModernUI.Controls.ModernPanel();
            label1 = new Label();
            BtnExit = new IconButton();
            btnReportes = new IconButton();
            btnEstudiantes = new IconButton();
            btnCursos = new IconButton();
            btnInicio = new IconButton();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            pnlContent.SuspendLayout();
            pnlContenedorPrincipal.SuspendLayout();
            pnlDashboard.SuspendLayout();
            modernPanel1.SuspendLayout();
            pnlContenedorClases.SuspendLayout();
            pnlAlertas.SuspendLayout();
            pnlAsistencia.SuspendLayout();
            pnlClases.SuspendLayout();
            pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(10, 17, 40);
            pnlContent.BorderColor = Color.FromArgb(10, 17, 40);
            pnlContent.BorderRadius = 0;
            pnlContent.BorderThickness = 0;
            pnlContent.Controls.Add(pnlContenedorPrincipal);
            pnlContent.Controls.Add(pnlSideBar);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.GradientEndColor = null;
            pnlContent.GradientStartColor = null;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            pnlContent.Size = new Size(1900, 1200);
            pnlContent.TabIndex = 0;
            // 
            // pnlContenedorPrincipal
            // 
            pnlContenedorPrincipal.BackColor = Color.FromArgb(10, 17, 40);
            pnlContenedorPrincipal.Controls.Add(pnlDashboard);
            pnlContenedorPrincipal.Dock = DockStyle.Fill;
            pnlContenedorPrincipal.Location = new Point(203, 0);
            pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            pnlContenedorPrincipal.Size = new Size(1697, 1200);
            pnlContenedorPrincipal.TabIndex = 7;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(10, 17, 40);
            pnlDashboard.BackgroundImage = (Image)resources.GetObject("pnlDashboard.BackgroundImage");
            pnlDashboard.BackgroundImageLayout = ImageLayout.Stretch;
            pnlDashboard.Controls.Add(modernPanel1);
            pnlDashboard.Controls.Add(pnlContenedorClases);
            pnlDashboard.Controls.Add(pnlAlertas);
            pnlDashboard.Controls.Add(pnlAsistencia);
            pnlDashboard.Controls.Add(pnlClases);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1697, 1200);
            pnlDashboard.TabIndex = 0;
            // 
            // modernPanel1
            // 
            modernPanel1.BackColor = Color.Transparent;
            modernPanel1.BorderColor = Color.FromArgb(26, 42, 74);
            modernPanel1.BorderRadius = 0;
            modernPanel1.BorderThickness = 0;
            modernPanel1.Controls.Add(lblFecha);
            modernPanel1.Controls.Add(modernLabel2);
            modernPanel1.Controls.Add(iconButton1);
            modernPanel1.Controls.Add(lblBienvenido);
            modernPanel1.Dock = DockStyle.Top;
            modernPanel1.GradientEndColor = null;
            modernPanel1.GradientStartColor = null;
            modernPanel1.Location = new Point(0, 0);
            modernPanel1.Name = "modernPanel1";
            modernPanel1.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            modernPanel1.Size = new Size(1697, 133);
            modernPanel1.TabIndex = 6;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BadgeBackColor = Color.DodgerBlue;
            lblFecha.BadgeForeColor = Color.White;
            lblFecha.BorderColor = Color.LightGray;
            lblFecha.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.WhiteSmoke;
            lblFecha.Location = new Point(34, 94);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(232, 28);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Miércoles, 14 Oct 2026";
            // 
            // modernLabel2
            // 
            modernLabel2.AutoSize = true;
            modernLabel2.BadgeBackColor = Color.DodgerBlue;
            modernLabel2.BadgeForeColor = Color.White;
            modernLabel2.BorderColor = Color.LightGray;
            modernLabel2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modernLabel2.ForeColor = Color.WhiteSmoke;
            modernLabel2.Location = new Point(1364, 54);
            modernLabel2.Name = "modernLabel2";
            modernLabel2.Size = new Size(254, 31);
            modernLabel2.TabIndex = 2;
            modernLabel2.Text = "Ingenieria en Sistemas";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = IconChar.UserCircle;
            iconButton1.IconColor = Color.WhiteSmoke;
            iconButton1.IconFont = IconFont.Auto;
            iconButton1.Location = new Point(1624, 51);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(48, 45);
            iconButton1.TabIndex = 1;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // lblBienvenido
            // 
            lblBienvenido.BadgeBackColor = Color.DodgerBlue;
            lblBienvenido.BadgeForeColor = Color.White;
            lblBienvenido.BorderColor = Color.LightGray;
            lblBienvenido.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenido.ForeColor = Color.WhiteSmoke;
            lblBienvenido.Location = new Point(15, 46);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(456, 41);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido, Prof.  Edwin";
            lblBienvenido.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContenedorClases
            // 
            pnlContenedorClases.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContenedorClases.BackColor = Color.FromArgb(22, 32, 54);
            pnlContenedorClases.Controls.Add(pnlEncabezados);
            pnlContenedorClases.Location = new Point(40, 405);
            pnlContenedorClases.Name = "pnlContenedorClases";
            pnlContenedorClases.Size = new Size(1621, 475);
            pnlContenedorClases.TabIndex = 4;
            // 
            // pnlEncabezados
            // 
            pnlEncabezados.BackColor = Color.FromArgb(13, 23, 49);
            pnlEncabezados.Location = new Point(15, 19);
            pnlEncabezados.Name = "pnlEncabezados";
            pnlEncabezados.Size = new Size(1585, 40);
            pnlEncabezados.TabIndex = 0;
            // 
            // pnlAlertas
            // 
            pnlAlertas.BackColor = Color.FromArgb(22, 32, 54);
            pnlAlertas.BorderColor = Color.LightGray;
            pnlAlertas.BorderRadius = 20;
            pnlAlertas.BorderStyle = BorderStyle.FixedSingle;
            pnlAlertas.BorderThickness = 3;
            pnlAlertas.Controls.Add(modernLabel3);
            pnlAlertas.Controls.Add(lblNumAlertas);
            pnlAlertas.Controls.Add(modernLabel5);
            pnlAlertas.Controls.Add(btnIco3);
            pnlAlertas.GradientEndColor = null;
            pnlAlertas.GradientStartColor = null;
            pnlAlertas.Location = new Point(1240, 179);
            pnlAlertas.Name = "pnlAlertas";
            pnlAlertas.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            pnlAlertas.Size = new Size(429, 125);
            pnlAlertas.TabIndex = 3;
            // 
            // modernLabel3
            // 
            modernLabel3.AutoSize = true;
            modernLabel3.BadgeBackColor = Color.DodgerBlue;
            modernLabel3.BadgeForeColor = Color.White;
            modernLabel3.BorderColor = Color.LightGray;
            modernLabel3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modernLabel3.ForeColor = Color.LightGray;
            modernLabel3.Location = new Point(92, 87);
            modernLabel3.Name = "modernLabel3";
            modernLabel3.Size = new Size(285, 23);
            modernLabel3.TabIndex = 5;
            modernLabel3.Text = "Estudiantes en riesgo de deserción";
            // 
            // lblNumAlertas
            // 
            lblNumAlertas.AutoSize = true;
            lblNumAlertas.BadgeBackColor = Color.DodgerBlue;
            lblNumAlertas.BadgeForeColor = Color.White;
            lblNumAlertas.BorderColor = Color.LightGray;
            lblNumAlertas.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumAlertas.ForeColor = Color.LightGray;
            lblNumAlertas.Location = new Point(96, 35);
            lblNumAlertas.Name = "lblNumAlertas";
            lblNumAlertas.Size = new Size(46, 54);
            lblNumAlertas.TabIndex = 4;
            lblNumAlertas.Text = "2";
            // 
            // modernLabel5
            // 
            modernLabel5.AutoSize = true;
            modernLabel5.BadgeBackColor = Color.DodgerBlue;
            modernLabel5.BadgeForeColor = Color.White;
            modernLabel5.BorderColor = Color.LightGray;
            modernLabel5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modernLabel5.ForeColor = Color.WhiteSmoke;
            modernLabel5.Location = new Point(96, 17);
            modernLabel5.Name = "modernLabel5";
            modernLabel5.Size = new Size(130, 23);
            modernLabel5.TabIndex = 3;
            modernLabel5.Text = "Alertas Criticas";
            // 
            // btnIco3
            // 
            btnIco3.BackgroundImage = (Image)resources.GetObject("btnIco3.BackgroundImage");
            btnIco3.BackgroundImageLayout = ImageLayout.Zoom;
            btnIco3.FlatAppearance.BorderSize = 0;
            btnIco3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnIco3.FlatStyle = FlatStyle.Flat;
            btnIco3.IconChar = IconChar.None;
            btnIco3.IconColor = Color.WhiteSmoke;
            btnIco3.IconFont = IconFont.Auto;
            btnIco3.IconSize = 50;
            btnIco3.Location = new Point(19, 41);
            btnIco3.Name = "btnIco3";
            btnIco3.Size = new Size(54, 48);
            btnIco3.TabIndex = 2;
            btnIco3.UseVisualStyleBackColor = true;
            // 
            // pnlAsistencia
            // 
            pnlAsistencia.BackColor = Color.FromArgb(22, 32, 54);
            pnlAsistencia.BorderColor = Color.LightGray;
            pnlAsistencia.BorderRadius = 20;
            pnlAsistencia.BorderStyle = BorderStyle.FixedSingle;
            pnlAsistencia.BorderThickness = 3;
            pnlAsistencia.Controls.Add(lblEstadoAsistencia);
            pnlAsistencia.Controls.Add(lblNumAsistencia);
            pnlAsistencia.Controls.Add(modernLabel4);
            pnlAsistencia.Controls.Add(btnIco2);
            pnlAsistencia.GradientEndColor = null;
            pnlAsistencia.GradientStartColor = null;
            pnlAsistencia.Location = new Point(646, 179);
            pnlAsistencia.Name = "pnlAsistencia";
            pnlAsistencia.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            pnlAsistencia.Size = new Size(429, 125);
            pnlAsistencia.TabIndex = 3;
            // 
            // lblEstadoAsistencia
            // 
            lblEstadoAsistencia.AutoSize = true;
            lblEstadoAsistencia.BadgeBackColor = Color.DodgerBlue;
            lblEstadoAsistencia.BadgeForeColor = Color.White;
            lblEstadoAsistencia.BorderColor = Color.LightGray;
            lblEstadoAsistencia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoAsistencia.ForeColor = Color.LightGray;
            lblEstadoAsistencia.Location = new Point(87, 91);
            lblEstadoAsistencia.Name = "lblEstadoAsistencia";
            lblEstadoAsistencia.Size = new Size(188, 23);
            lblEstadoAsistencia.TabIndex = 4;
            lblEstadoAsistencia.Text = "Por encima de la meta";
            // 
            // lblNumAsistencia
            // 
            lblNumAsistencia.AutoSize = true;
            lblNumAsistencia.BadgeBackColor = Color.DodgerBlue;
            lblNumAsistencia.BadgeForeColor = Color.White;
            lblNumAsistencia.BorderColor = Color.LightGray;
            lblNumAsistencia.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumAsistencia.ForeColor = Color.LightGray;
            lblNumAsistencia.Location = new Point(88, 36);
            lblNumAsistencia.Name = "lblNumAsistencia";
            lblNumAsistencia.Size = new Size(46, 54);
            lblNumAsistencia.TabIndex = 3;
            lblNumAsistencia.Text = "2";
            // 
            // modernLabel4
            // 
            modernLabel4.AutoSize = true;
            modernLabel4.BadgeBackColor = Color.DodgerBlue;
            modernLabel4.BadgeForeColor = Color.White;
            modernLabel4.BorderColor = Color.LightGray;
            modernLabel4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modernLabel4.ForeColor = Color.WhiteSmoke;
            modernLabel4.Location = new Point(87, 13);
            modernLabel4.Name = "modernLabel4";
            modernLabel4.Size = new Size(172, 23);
            modernLabel4.TabIndex = 2;
            modernLabel4.Text = "Asistencia Promedio";
            // 
            // btnIco2
            // 
            btnIco2.BackgroundImage = (Image)resources.GetObject("btnIco2.BackgroundImage");
            btnIco2.BackgroundImageLayout = ImageLayout.Zoom;
            btnIco2.FlatAppearance.BorderSize = 0;
            btnIco2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnIco2.FlatStyle = FlatStyle.Flat;
            btnIco2.IconChar = IconChar.None;
            btnIco2.IconColor = Color.WhiteSmoke;
            btnIco2.IconFont = IconFont.Auto;
            btnIco2.IconSize = 55;
            btnIco2.Location = new Point(19, 41);
            btnIco2.Name = "btnIco2";
            btnIco2.Size = new Size(58, 48);
            btnIco2.TabIndex = 1;
            btnIco2.UseVisualStyleBackColor = true;
            // 
            // pnlClases
            // 
            pnlClases.BackColor = Color.FromArgb(22, 32, 54);
            pnlClases.BorderColor = Color.LightGray;
            pnlClases.BorderRadius = 20;
            pnlClases.BorderStyle = BorderStyle.FixedSingle;
            pnlClases.BorderThickness = 3;
            pnlClases.Controls.Add(lblSubtitulo);
            pnlClases.Controls.Add(lblNúmero);
            pnlClases.Controls.Add(lblTitulo);
            pnlClases.Controls.Add(btnIco1);
            pnlClases.GradientEndColor = null;
            pnlClases.GradientStartColor = null;
            pnlClases.Location = new Point(59, 179);
            pnlClases.Name = "pnlClases";
            pnlClases.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            pnlClases.Size = new Size(429, 125);
            pnlClases.TabIndex = 2;
            pnlClases.Paint += modernPanel2_Paint;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BadgeBackColor = Color.DodgerBlue;
            lblSubtitulo.BadgeForeColor = Color.White;
            lblSubtitulo.BorderColor = Color.LightGray;
            lblSubtitulo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.LightGray;
            lblSubtitulo.Location = new Point(87, 94);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(183, 23);
            lblSubtitulo.TabIndex = 3;
            lblSubtitulo.Text = "Programadas en total";
            // 
            // lblNúmero
            // 
            lblNúmero.AutoSize = true;
            lblNúmero.BadgeBackColor = Color.DodgerBlue;
            lblNúmero.BadgeForeColor = Color.White;
            lblNúmero.BorderColor = Color.LightGray;
            lblNúmero.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNúmero.ForeColor = Color.LightGray;
            lblNúmero.Location = new Point(90, 37);
            lblNúmero.Name = "lblNúmero";
            lblNúmero.Size = new Size(46, 54);
            lblNúmero.TabIndex = 2;
            lblNúmero.Text = "0";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.BadgeBackColor = Color.DodgerBlue;
            lblTitulo.BadgeForeColor = Color.White;
            lblTitulo.BorderColor = Color.LightGray;
            lblTitulo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.LightGray;
            lblTitulo.Location = new Point(87, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(120, 23);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Clases de Hoy";
            // 
            // btnIco1
            // 
            btnIco1.BackgroundImage = (Image)resources.GetObject("btnIco1.BackgroundImage");
            btnIco1.BackgroundImageLayout = ImageLayout.Zoom;
            btnIco1.FlatAppearance.BorderSize = 0;
            btnIco1.FlatStyle = FlatStyle.Flat;
            btnIco1.IconChar = IconChar.None;
            btnIco1.IconColor = Color.WhiteSmoke;
            btnIco1.IconFont = IconFont.Auto;
            btnIco1.IconSize = 50;
            btnIco1.Location = new Point(16, 41);
            btnIco1.Name = "btnIco1";
            btnIco1.Size = new Size(54, 48);
            btnIco1.TabIndex = 0;
            btnIco1.UseCompatibleTextRendering = true;
            btnIco1.UseVisualStyleBackColor = true;
            // 
            // pnlSideBar
            // 
            pnlSideBar.BackColor = Color.Transparent;
            pnlSideBar.BackgroundImageLayout = ImageLayout.None;
            pnlSideBar.BorderColor = Color.Transparent;
            pnlSideBar.BorderRadius = 0;
            pnlSideBar.BorderThickness = 0;
            pnlSideBar.Controls.Add(label2);
            pnlSideBar.Controls.Add(label1);
            pnlSideBar.Controls.Add(BtnExit);
            pnlSideBar.Controls.Add(btnReportes);
            pnlSideBar.Controls.Add(btnEstudiantes);
            pnlSideBar.Controls.Add(btnCursos);
            pnlSideBar.Controls.Add(btnInicio);
            pnlSideBar.Controls.Add(pictureBox1);
            pnlSideBar.Dock = DockStyle.Left;
            pnlSideBar.GradientEndColor = null;
            pnlSideBar.GradientStartColor = null;
            pnlSideBar.Location = new Point(0, 0);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.ShadowColor = Color.Transparent;
            pnlSideBar.Size = new Size(203, 1200);
            pnlSideBar.TabIndex = 5;
            pnlSideBar.Paint += pnlSideBar_Paint;
            // 
            // label1
            // 
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(5, 214);
            label1.Name = "label1";
            label1.Size = new Size(201, 48);
            label1.TabIndex = 6;
            label1.Text = "Sistema de Asistencia \r\n          Por Voz";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnExit
            // 
            BtnExit.Cursor = Cursors.Hand;
            BtnExit.FlatAppearance.BorderSize = 0;
            BtnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 42, 74);
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnExit.ForeColor = Color.WhiteSmoke;
            BtnExit.IconChar = IconChar.SignOut;
            BtnExit.IconColor = Color.WhiteSmoke;
            BtnExit.IconFont = IconFont.Auto;
            BtnExit.Location = new Point(3, 1086);
            BtnExit.Name = "BtnExit";
            BtnExit.Padding = new Padding(0, 0, 0, 5);
            BtnExit.Size = new Size(197, 91);
            BtnExit.TabIndex = 5;
            BtnExit.Text = "Cerrar Sesion";
            BtnExit.TextAlign = ContentAlignment.BottomCenter;
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click_1;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 42, 74);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.WhiteSmoke;
            btnReportes.IconChar = IconChar.FileCirclePlus;
            btnReportes.IconColor = Color.WhiteSmoke;
            btnReportes.IconFont = IconFont.Auto;
            btnReportes.Location = new Point(2, 742);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(0, 0, 0, 5);
            btnReportes.Size = new Size(198, 91);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.BottomCenter;
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnAjustes_Click;
            // 
            // btnEstudiantes
            // 
            btnEstudiantes.Cursor = Cursors.Hand;
            btnEstudiantes.FlatAppearance.BorderSize = 0;
            btnEstudiantes.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 42, 74);
            btnEstudiantes.FlatStyle = FlatStyle.Flat;
            btnEstudiantes.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstudiantes.ForeColor = Color.WhiteSmoke;
            btnEstudiantes.IconChar = IconChar.UserGraduate;
            btnEstudiantes.IconColor = Color.WhiteSmoke;
            btnEstudiantes.IconFont = IconFont.Auto;
            btnEstudiantes.Location = new Point(0, 629);
            btnEstudiantes.Name = "btnEstudiantes";
            btnEstudiantes.Padding = new Padding(0, 0, 0, 5);
            btnEstudiantes.Size = new Size(203, 91);
            btnEstudiantes.TabIndex = 3;
            btnEstudiantes.Text = "Estudiantes";
            btnEstudiantes.TextAlign = ContentAlignment.BottomCenter;
            btnEstudiantes.UseVisualStyleBackColor = true;
            btnEstudiantes.Click += btnReportes_Click;
            // 
            // btnCursos
            // 
            btnCursos.Cursor = Cursors.Hand;
            btnCursos.FlatAppearance.BorderSize = 0;
            btnCursos.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 42, 74);
            btnCursos.FlatStyle = FlatStyle.Flat;
            btnCursos.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCursos.ForeColor = Color.WhiteSmoke;
            btnCursos.IconChar = IconChar.BookOpen;
            btnCursos.IconColor = Color.WhiteSmoke;
            btnCursos.IconFont = IconFont.Auto;
            btnCursos.Location = new Point(0, 519);
            btnCursos.Name = "btnCursos";
            btnCursos.Padding = new Padding(0, 0, 0, 5);
            btnCursos.Size = new Size(204, 91);
            btnCursos.TabIndex = 2;
            btnCursos.Text = "Mis Cursos";
            btnCursos.TextAlign = ContentAlignment.BottomCenter;
            btnCursos.UseVisualStyleBackColor = true;
            btnCursos.Click += btnCursos_Click_1;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.Transparent;
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 42, 74);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnInicio.ForeColor = Color.WhiteSmoke;
            btnInicio.IconChar = IconChar.House;
            btnInicio.IconColor = Color.WhiteSmoke;
            btnInicio.IconFont = IconFont.Auto;
            btnInicio.Location = new Point(0, 409);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(0, 0, 0, 5);
            btnInicio.Size = new Size(204, 91);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "Inicio";
            btnInicio.TextAlign = ContentAlignment.BottomCenter;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(0, 0, 0, 5);
            pictureBox1.Size = new Size(201, 180);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.ForeColor = SystemColors.ActiveBorder;
            label2.Location = new Point(0, 1063);
            label2.Name = "label2";
            label2.Size = new Size(206, 25);
            label2.TabIndex = 7;
            label2.Text = "___________________________________";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 1200);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrincipal";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load_1;
            pnlContent.ResumeLayout(false);
            pnlContenedorPrincipal.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            modernPanel1.ResumeLayout(false);
            modernPanel1.PerformLayout();
            pnlContenedorClases.ResumeLayout(false);
            pnlAlertas.ResumeLayout(false);
            pnlAlertas.PerformLayout();
            pnlAsistencia.ResumeLayout(false);
            pnlAsistencia.PerformLayout();
            pnlClases.ResumeLayout(false);
            pnlClases.PerformLayout();
            pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ModernUI.Controls.ModernPanel pnlContent;
        private Panel pnlContenedorPrincipal;
        private Panel pnlDashboard;
        private ModernUI.Controls.ModernPanel pnlAlertas;
        private ModernUI.Controls.ModernPanel pnlAsistencia;
        private ModernUI.Controls.ModernPanel pnlClases;
        private IconButton btnIco2;
        private IconButton btnIco1;
        private IconButton btnIco3;
        private ModernUI.Controls.ModernLabel modernLabel5;
        private ModernUI.Controls.ModernLabel modernLabel4;
        private ModernUI.Controls.ModernLabel lblTitulo;
        private ModernUI.Controls.ModernLabel lblSubtitulo;
        private ModernUI.Controls.ModernLabel lblNúmero;
        private ModernUI.Controls.ModernLabel lblNumAsistencia;
        private ModernUI.Controls.ModernLabel lblNumAlertas;
        private Panel pnlContenedorClases;
        private Panel pnlEncabezados;
        private ModernUI.Controls.ModernLabel modernLabel3;
        private ModernUI.Controls.ModernLabel lblEstadoAsistencia;
        private ModernUI.Controls.ModernPanel modernPanel1;
        private ModernUI.Controls.ModernLabel lblFecha;
        private ModernUI.Controls.ModernLabel modernLabel2;
        private IconButton iconButton1;
        private ModernUI.Controls.ModernPanel pnlSideBar;
        private IconButton BtnExit;
        private IconButton btnReportes;
        private IconButton btnEstudiantes;
        private IconButton btnCursos;
        private IconButton btnInicio;
        private PictureBox pictureBox1;
        public ModernUI.Controls.ModernLabel lblBienvenido;
        private Label label1;
        private Label label2;
    }
}