namespace SistemaAsistenciaPorVoz.UI.Forms
{
    partial class FrmCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCursos));
            modernPanel1 = new ModernUI.Controls.ModernPanel();
            btnNuevoCurso = new FontAwesome.Sharp.IconButton();
            modernPanel2 = new ModernUI.Controls.ModernPanel();
            lblFecha = new ModernUI.Controls.ModernLabel();
            modernLabel2 = new ModernUI.Controls.ModernLabel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            lblBienvenidoCurso = new ModernUI.Controls.ModernLabel();
            pnlContedorTabla = new ModernUI.Controls.ModernPanel();
            lblSubtituloSeccion = new ModernUI.Controls.ModernLabel();
            lblTituloSeccion = new ModernUI.Controls.ModernLabel();
            modernPanel1.SuspendLayout();
            modernPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // modernPanel1
            // 
            modernPanel1.BackColor = Color.Transparent;
            modernPanel1.BackgroundImage = (Image)resources.GetObject("modernPanel1.BackgroundImage");
            modernPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            modernPanel1.BorderColor = Color.LightGray;
            modernPanel1.BorderRadius = 0;
            modernPanel1.BorderThickness = 0;
            modernPanel1.Controls.Add(btnNuevoCurso);
            modernPanel1.Controls.Add(modernPanel2);
            modernPanel1.Controls.Add(pnlContedorTabla);
            modernPanel1.Controls.Add(lblSubtituloSeccion);
            modernPanel1.Controls.Add(lblTituloSeccion);
            modernPanel1.Dock = DockStyle.Fill;
            modernPanel1.GradientEndColor = null;
            modernPanel1.GradientStartColor = null;
            modernPanel1.Location = new Point(0, 0);
            modernPanel1.Name = "modernPanel1";
            modernPanel1.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            modernPanel1.Size = new Size(1900, 1200);
            modernPanel1.TabIndex = 0;
            // 
            // btnNuevoCurso
            // 
            btnNuevoCurso.BackColor = Color.FromArgb(8, 123, 255);
            btnNuevoCurso.Cursor = Cursors.Hand;
            btnNuevoCurso.FlatAppearance.BorderColor = Color.FromArgb(8, 123, 255);
            btnNuevoCurso.FlatAppearance.BorderSize = 0;
            btnNuevoCurso.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 123, 255);
            btnNuevoCurso.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 42, 74);
            btnNuevoCurso.FlatStyle = FlatStyle.Flat;
            btnNuevoCurso.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoCurso.ForeColor = Color.WhiteSmoke;
            btnNuevoCurso.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnNuevoCurso.IconColor = Color.WhiteSmoke;
            btnNuevoCurso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNuevoCurso.IconSize = 45;
            btnNuevoCurso.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevoCurso.Location = new Point(1412, 220);
            btnNuevoCurso.Name = "btnNuevoCurso";
            btnNuevoCurso.Size = new Size(180, 53);
            btnNuevoCurso.TabIndex = 9;
            btnNuevoCurso.Text = "      Nuevo Curso";
            btnNuevoCurso.UseVisualStyleBackColor = false;
            btnNuevoCurso.Click += btnNuevoCurso_Click_1;
            // 
            // modernPanel2
            // 
            modernPanel2.BorderColor = Color.FromArgb(26, 42, 74);
            modernPanel2.BorderRadius = 0;
            modernPanel2.BorderThickness = 0;
            modernPanel2.Controls.Add(lblFecha);
            modernPanel2.Controls.Add(modernLabel2);
            modernPanel2.Controls.Add(iconButton1);
            modernPanel2.Controls.Add(lblBienvenidoCurso);
            modernPanel2.Dock = DockStyle.Top;
            modernPanel2.GradientEndColor = null;
            modernPanel2.GradientStartColor = null;
            modernPanel2.Location = new Point(0, 0);
            modernPanel2.Name = "modernPanel2";
            modernPanel2.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            modernPanel2.Size = new Size(1900, 133);
            modernPanel2.TabIndex = 8;
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
            modernLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            modernLabel2.AutoSize = true;
            modernLabel2.BadgeBackColor = Color.DodgerBlue;
            modernLabel2.BadgeForeColor = Color.White;
            modernLabel2.BorderColor = Color.LightGray;
            modernLabel2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modernLabel2.ForeColor = Color.WhiteSmoke;
            modernLabel2.Location = new Point(1557, 55);
            modernLabel2.Name = "modernLabel2";
            modernLabel2.Size = new Size(254, 31);
            modernLabel2.TabIndex = 2;
            modernLabel2.Text = "Ingenieria en Sistemas";
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconButton1.IconColor = Color.WhiteSmoke;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(1822, 51);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(48, 45);
            iconButton1.TabIndex = 1;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // lblBienvenidoCurso
            // 
            lblBienvenidoCurso.BadgeBackColor = Color.DodgerBlue;
            lblBienvenidoCurso.BadgeForeColor = Color.White;
            lblBienvenidoCurso.BorderColor = Color.LightGray;
            lblBienvenidoCurso.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenidoCurso.ForeColor = Color.WhiteSmoke;
            lblBienvenidoCurso.Location = new Point(15, 46);
            lblBienvenidoCurso.Name = "lblBienvenidoCurso";
            lblBienvenidoCurso.Size = new Size(456, 41);
            lblBienvenidoCurso.TabIndex = 0;
            lblBienvenidoCurso.Text = "Bienvenido, Prof.  Edwin";
            lblBienvenidoCurso.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContedorTabla
            // 
            pnlContedorTabla.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContedorTabla.BackColor = Color.FromArgb(22, 32, 54);
            pnlContedorTabla.BorderColor = Color.FromArgb(28, 42, 75);
            pnlContedorTabla.BorderRadius = 0;
            pnlContedorTabla.BorderThickness = 0;
            pnlContedorTabla.GradientEndColor = null;
            pnlContedorTabla.GradientStartColor = null;
            pnlContedorTabla.Location = new Point(59, 316);
            pnlContedorTabla.Name = "pnlContedorTabla";
            pnlContedorTabla.Padding = new Padding(15, 0, 0, 10);
            pnlContedorTabla.ShadowColor = Color.FromArgb(50, 0, 0, 0);
            pnlContedorTabla.Size = new Size(1728, 582);
            pnlContedorTabla.TabIndex = 6;
            // 
            // lblSubtituloSeccion
            // 
            lblSubtituloSeccion.AutoSize = true;
            lblSubtituloSeccion.BadgeBackColor = Color.DodgerBlue;
            lblSubtituloSeccion.BadgeForeColor = Color.White;
            lblSubtituloSeccion.BorderColor = Color.LightGray;
            lblSubtituloSeccion.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloSeccion.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtituloSeccion.Location = new Point(42, 220);
            lblSubtituloSeccion.Name = "lblSubtituloSeccion";
            lblSubtituloSeccion.Size = new Size(245, 25);
            lblSubtituloSeccion.TabIndex = 4;
            lblSubtituloSeccion.Text = "Administre sus cursos activos";
            // 
            // lblTituloSeccion
            // 
            lblTituloSeccion.AutoSize = true;
            lblTituloSeccion.BadgeBackColor = Color.DodgerBlue;
            lblTituloSeccion.BadgeForeColor = Color.White;
            lblTituloSeccion.BorderColor = Color.LightGray;
            lblTituloSeccion.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloSeccion.ForeColor = Color.WhiteSmoke;
            lblTituloSeccion.Location = new Point(40, 167);
            lblTituloSeccion.Name = "lblTituloSeccion";
            lblTituloSeccion.Size = new Size(306, 46);
            lblTituloSeccion.TabIndex = 3;
            lblTituloSeccion.Text = "Gestión de Cursos";
            // 
            // FrmCursos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 1200);
            Controls.Add(modernPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCursos";
            Text = "FrmCursos";
            modernPanel1.ResumeLayout(false);
            modernPanel1.PerformLayout();
            modernPanel2.ResumeLayout(false);
            modernPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ModernUI.Controls.ModernPanel modernPanel1;
        private ModernUI.Controls.ModernLabel lblSubtituloSeccion;
        private ModernUI.Controls.ModernLabel lblTituloSeccion;
        private ModernUI.Controls.ModernPanel pnlContedorTabla;
        private ModernUI.Controls.ModernPanel modernPanel2;
        private ModernUI.Controls.ModernLabel lblFecha;
        private ModernUI.Controls.ModernLabel modernLabel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private ModernUI.Controls.ModernLabel lblBienvenidoCurso;
        private FontAwesome.Sharp.IconButton btnNuevoCurso;
    }
}