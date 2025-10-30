namespace CalculadoraBasica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblTitulo = new Label();
            TboxPantalla = new TextBox();
            BtnLimpiar = new Button();
            PanelPrincipal = new Panel();
            BtnPuntoDecimal = new Button();
            BtnMultiplicar = new Button();
            BtnResta = new Button();
            BtnSuma = new Button();
            BtnNum0 = new Button();
            BtnNum = new Button();
            BtnNum6 = new Button();
            BtnDividir = new Button();
            BtnNum9 = new Button();
            BtnBorrar = new Button();
            BtnNum2 = new Button();
            BtnNum5 = new Button();
            BtnNum8 = new Button();
            BtnIgual = new Button();
            BtnNum7 = new Button();
            BtnNum4 = new Button();
            BtnNum1 = new Button();
            LlbResultado = new Label();
            PanelPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // LblTitulo
            // 
            LblTitulo.AutoSize = true;
            LblTitulo.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTitulo.Location = new Point(107, 19);
            LblTitulo.Name = "LblTitulo";
            LblTitulo.Size = new Size(183, 27);
            LblTitulo.TabIndex = 0;
            LblTitulo.Text = "Calculadora Basica";
            LblTitulo.Click += LblTitulo_Click;
            // 
            // TboxPantalla
            // 
            TboxPantalla.Location = new Point(21, 49);
            TboxPantalla.Multiline = true;
            TboxPantalla.Name = "TboxPantalla";
            TboxPantalla.ReadOnly = true;
            TboxPantalla.Size = new Size(338, 71);
            TboxPantalla.TabIndex = 1;
            TboxPantalla.TextAlign = HorizontalAlignment.Right;
            TboxPantalla.TextChanged += TboxPantalla_TextChanged;
            // 
            // BtnLimpiar
            // 
            BtnLimpiar.AccessibleName = "BtnLimpiar";
            BtnLimpiar.BackColor = Color.Salmon;
            BtnLimpiar.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnLimpiar.Location = new Point(21, 136);
            BtnLimpiar.Name = "BtnLimpiar";
            BtnLimpiar.Size = new Size(80, 40);
            BtnLimpiar.TabIndex = 2;
            BtnLimpiar.Text = "C";
            BtnLimpiar.UseVisualStyleBackColor = false;
            BtnLimpiar.Click += BtnLimpiar_Click;
            // 
            // PanelPrincipal
            // 
            PanelPrincipal.BackColor = Color.LightGray;
            PanelPrincipal.Controls.Add(LlbResultado);
            PanelPrincipal.Controls.Add(BtnPuntoDecimal);
            PanelPrincipal.Controls.Add(BtnMultiplicar);
            PanelPrincipal.Controls.Add(BtnResta);
            PanelPrincipal.Controls.Add(BtnSuma);
            PanelPrincipal.Controls.Add(BtnNum0);
            PanelPrincipal.Controls.Add(BtnNum);
            PanelPrincipal.Controls.Add(BtnNum6);
            PanelPrincipal.Controls.Add(BtnDividir);
            PanelPrincipal.Controls.Add(BtnNum9);
            PanelPrincipal.Controls.Add(BtnBorrar);
            PanelPrincipal.Controls.Add(BtnNum2);
            PanelPrincipal.Controls.Add(BtnNum5);
            PanelPrincipal.Controls.Add(BtnNum8);
            PanelPrincipal.Controls.Add(BtnIgual);
            PanelPrincipal.Controls.Add(BtnNum7);
            PanelPrincipal.Controls.Add(BtnNum4);
            PanelPrincipal.Controls.Add(BtnNum1);
            PanelPrincipal.Controls.Add(BtnLimpiar);
            PanelPrincipal.Controls.Add(LblTitulo);
            PanelPrincipal.Controls.Add(TboxPantalla);
            PanelPrincipal.Location = new Point(0, 1);
            PanelPrincipal.Name = "PanelPrincipal";
            PanelPrincipal.Size = new Size(377, 387);
            PanelPrincipal.TabIndex = 3;
            // 
            // BtnPuntoDecimal
            // 
            BtnPuntoDecimal.BackColor = Color.LightGray;
            BtnPuntoDecimal.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnPuntoDecimal.Location = new Point(279, 320);
            BtnPuntoDecimal.Name = "BtnPuntoDecimal";
            BtnPuntoDecimal.Size = new Size(80, 40);
            BtnPuntoDecimal.TabIndex = 19;
            BtnPuntoDecimal.Text = ".";
            BtnPuntoDecimal.UseVisualStyleBackColor = true;
            BtnPuntoDecimal.Click += BtnPuntoDecimal_Click;
            // 
            // BtnMultiplicar
            // 
            BtnMultiplicar.BackColor = Color.Gold;
            BtnMultiplicar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnMultiplicar.Location = new Point(279, 136);
            BtnMultiplicar.Name = "BtnMultiplicar";
            BtnMultiplicar.Size = new Size(80, 40);
            BtnMultiplicar.TabIndex = 18;
            BtnMultiplicar.Text = "×";
            BtnMultiplicar.UseVisualStyleBackColor = false;
            BtnMultiplicar.Click += BtnMultiplicar_Click;
            // 
            // BtnResta
            // 
            BtnResta.BackColor = Color.Gold;
            BtnResta.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnResta.Location = new Point(279, 182);
            BtnResta.Name = "BtnResta";
            BtnResta.Size = new Size(80, 40);
            BtnResta.TabIndex = 17;
            BtnResta.Text = "-";
            BtnResta.UseVisualStyleBackColor = false;
            BtnResta.Click += BtnResta_Click;
            // 
            // BtnSuma
            // 
            BtnSuma.BackColor = Color.Gold;
            BtnSuma.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnSuma.Location = new Point(279, 228);
            BtnSuma.Name = "BtnSuma";
            BtnSuma.Size = new Size(80, 40);
            BtnSuma.TabIndex = 16;
            BtnSuma.Text = "+";
            BtnSuma.UseVisualStyleBackColor = false;
            BtnSuma.Click += BtnSuma_Click;
            // 
            // BtnNum0
            // 
            BtnNum0.BackColor = Color.LightGray;
            BtnNum0.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum0.Location = new Point(193, 320);
            BtnNum0.Name = "BtnNum0";
            BtnNum0.Size = new Size(80, 40);
            BtnNum0.TabIndex = 15;
            BtnNum0.Text = "0";
            BtnNum0.UseVisualStyleBackColor = true;
            BtnNum0.Click += BtnNumeros;
            // 
            // BtnNum
            // 
            BtnNum.BackColor = Color.LightGray;
            BtnNum.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum.Location = new Point(193, 274);
            BtnNum.Name = "BtnNum";
            BtnNum.Size = new Size(80, 40);
            BtnNum.TabIndex = 14;
            BtnNum.Text = "3";
            BtnNum.UseVisualStyleBackColor = true;
            BtnNum.Click += BtnNumeros;
            // 
            // BtnNum6
            // 
            BtnNum6.BackColor = Color.LightGray;
            BtnNum6.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum6.Location = new Point(193, 228);
            BtnNum6.Name = "BtnNum6";
            BtnNum6.Size = new Size(80, 40);
            BtnNum6.TabIndex = 13;
            BtnNum6.Text = "6";
            BtnNum6.UseVisualStyleBackColor = true;
            BtnNum6.Click += BtnNumeros;
            // 
            // BtnDividir
            // 
            BtnDividir.BackColor = Color.Gold;
            BtnDividir.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnDividir.Location = new Point(193, 136);
            BtnDividir.Name = "BtnDividir";
            BtnDividir.Size = new Size(80, 40);
            BtnDividir.TabIndex = 12;
            BtnDividir.Text = "÷";
            BtnDividir.UseVisualStyleBackColor = false;
            BtnDividir.Click += BtnDividir_Click;
            // 
            // BtnNum9
            // 
            BtnNum9.BackColor = Color.LightGray;
            BtnNum9.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum9.Location = new Point(193, 182);
            BtnNum9.Name = "BtnNum9";
            BtnNum9.Size = new Size(80, 40);
            BtnNum9.TabIndex = 11;
            BtnNum9.Text = "9";
            BtnNum9.UseVisualStyleBackColor = true;
            BtnNum9.Click += BtnNumeros;
            // 
            // BtnBorrar
            // 
            BtnBorrar.BackColor = Color.LightGray;
            BtnBorrar.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnBorrar.Location = new Point(107, 136);
            BtnBorrar.Name = "BtnBorrar";
            BtnBorrar.Size = new Size(80, 40);
            BtnBorrar.TabIndex = 10;
            BtnBorrar.Text = "←";
            BtnBorrar.UseVisualStyleBackColor = true;
            BtnBorrar.Click += BtnBorrar_Click;
            // 
            // BtnNum2
            // 
            BtnNum2.BackColor = Color.LightGray;
            BtnNum2.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum2.Location = new Point(107, 274);
            BtnNum2.Name = "BtnNum2";
            BtnNum2.Size = new Size(80, 40);
            BtnNum2.TabIndex = 9;
            BtnNum2.Text = "2";
            BtnNum2.UseVisualStyleBackColor = true;
            BtnNum2.Click += BtnNumeros;
            // 
            // BtnNum5
            // 
            BtnNum5.BackColor = Color.LightGray;
            BtnNum5.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum5.Location = new Point(107, 228);
            BtnNum5.Name = "BtnNum5";
            BtnNum5.Size = new Size(80, 40);
            BtnNum5.TabIndex = 8;
            BtnNum5.Text = "5";
            BtnNum5.UseVisualStyleBackColor = true;
            BtnNum5.Click += BtnNumeros;
            // 
            // BtnNum8
            // 
            BtnNum8.BackColor = Color.LightGray;
            BtnNum8.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum8.Location = new Point(107, 182);
            BtnNum8.Name = "BtnNum8";
            BtnNum8.Size = new Size(80, 40);
            BtnNum8.TabIndex = 7;
            BtnNum8.Text = "8";
            BtnNum8.UseVisualStyleBackColor = true;
            BtnNum8.Click += BtnNumeros;
            // 
            // BtnIgual
            // 
            BtnIgual.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnIgual.Location = new Point(21, 320);
            BtnIgual.Name = "BtnIgual";
            BtnIgual.Size = new Size(166, 40);
            BtnIgual.TabIndex = 6;
            BtnIgual.Text = "=";
            BtnIgual.UseVisualStyleBackColor = true;
            BtnIgual.Click += BtnIgual_Click;
            // 
            // BtnNum7
            // 
            BtnNum7.BackColor = Color.LightGray;
            BtnNum7.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum7.Location = new Point(21, 182);
            BtnNum7.Name = "BtnNum7";
            BtnNum7.Size = new Size(80, 40);
            BtnNum7.TabIndex = 5;
            BtnNum7.Text = "7";
            BtnNum7.UseVisualStyleBackColor = true;
            BtnNum7.Click += BtnNumeros;
            // 
            // BtnNum4
            // 
            BtnNum4.BackColor = Color.LightGray;
            BtnNum4.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum4.Location = new Point(21, 228);
            BtnNum4.Name = "BtnNum4";
            BtnNum4.Size = new Size(80, 40);
            BtnNum4.TabIndex = 4;
            BtnNum4.Text = "4";
            BtnNum4.UseVisualStyleBackColor = true;
            BtnNum4.Click += BtnNumeros;
            // 
            // BtnNum1
            // 
            BtnNum1.BackColor = Color.LightGray;
            BtnNum1.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            BtnNum1.Location = new Point(21, 274);
            BtnNum1.Name = "BtnNum1";
            BtnNum1.Size = new Size(80, 40);
            BtnNum1.TabIndex = 3;
            BtnNum1.Text = "1";
            BtnNum1.UseVisualStyleBackColor = true;
            BtnNum1.Click += BtnNumeros;
            // 
            // LlbResultado
            // 
            LlbResultado.AutoSize = true;
            LlbResultado.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LlbResultado.Location = new Point(268, 100);
            LlbResultado.Name = "LlbResultado";
            LlbResultado.Size = new Size(0, 20);
            LlbResultado.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 385);
            Controls.Add(PanelPrincipal);
            Name = "Form1";
            Text = "Form1";
            PanelPrincipal.ResumeLayout(false);
            PanelPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label LblTitulo;
        private TextBox TboxPantalla;
        private Button BtnLimpiar;
        private Panel PanelPrincipal;
        private Button BtnIgual;
        private Button BtnNum7;
        private Button BtnNum4;
        private Button BtnNum1;
        private Button BtnNum2;
        private Button BtnNum5;
        private Button BtnNum8;
        private Button BtnNum0;
        private Button BtnNum;
        private Button BtnNum6;
        private Button BtnDividir;
        private Button BtnNum9;
        private Button BtnBorrar;
        private Button BtnPuntoDecimal;
        private Button BtnMultiplicar;
        private Button BtnResta;
        private Button BtnSuma;
        private Label LlbResultado;
    }
}
