namespace Proyecto_Hilos_U3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.btn_Pausar = new System.Windows.Forms.Button();
            this.btn_Reanudar = new System.Windows.Forms.Button();
            this.btn_Reiniciar = new System.Windows.Forms.Button();
            this.lblganador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.Location = new System.Drawing.Point(12, 12);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.Size = new System.Drawing.Size(74, 23);
            this.btn_Iniciar.TabIndex = 2;
            this.btn_Iniciar.Text = "INICIAR";
            this.btn_Iniciar.UseVisualStyleBackColor = true;
            this.btn_Iniciar.Click += new System.EventHandler(this.btn_Iniciar_Click);
            // 
            // btn_Pausar
            // 
            this.btn_Pausar.Location = new System.Drawing.Point(93, 12);
            this.btn_Pausar.Name = "btn_Pausar";
            this.btn_Pausar.Size = new System.Drawing.Size(74, 23);
            this.btn_Pausar.TabIndex = 2;
            this.btn_Pausar.Text = "PAUSAR";
            this.btn_Pausar.UseVisualStyleBackColor = true;
            this.btn_Pausar.Click += new System.EventHandler(this.btn_Pausar_Click);
            // 
            // btn_Reanudar
            // 
            this.btn_Reanudar.Location = new System.Drawing.Point(174, 12);
            this.btn_Reanudar.Name = "btn_Reanudar";
            this.btn_Reanudar.Size = new System.Drawing.Size(83, 23);
            this.btn_Reanudar.TabIndex = 2;
            this.btn_Reanudar.Text = "REANUDAR";
            this.btn_Reanudar.UseVisualStyleBackColor = true;
            this.btn_Reanudar.Click += new System.EventHandler(this.btn_Reanudar_Click);
            // 
            // btn_Reiniciar
            // 
            this.btn_Reiniciar.Location = new System.Drawing.Point(264, 12);
            this.btn_Reiniciar.Name = "btn_Reiniciar";
            this.btn_Reiniciar.Size = new System.Drawing.Size(74, 23);
            this.btn_Reiniciar.TabIndex = 2;
            this.btn_Reiniciar.Text = "REINICIAR";
            this.btn_Reiniciar.UseVisualStyleBackColor = true;
            this.btn_Reiniciar.Click += new System.EventHandler(this.btn_Reiniciar_Click);
            // 
            // lblganador
            // 
            this.lblganador.AutoSize = true;
            this.lblganador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblganador.Location = new System.Drawing.Point(626, 12);
            this.lblganador.Name = "lblganador";
            this.lblganador.Size = new System.Drawing.Size(0, 25);
            this.lblganador.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 453);
            this.Controls.Add(this.lblganador);
            this.Controls.Add(this.btn_Reiniciar);
            this.Controls.Add(this.btn_Reanudar);
            this.Controls.Add(this.btn_Pausar);
            this.Controls.Add(this.btn_Iniciar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Proyecto Hilos - U3 Castro Hernandez Rolando Jassiel -Fansisco Alonso Robles Barr" +
    "era";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_Iniciar;
        private System.Windows.Forms.Button btn_Pausar;
        private System.Windows.Forms.Button btn_Reanudar;
        private System.Windows.Forms.Button btn_Reiniciar;
        private System.Windows.Forms.Label lblganador;
    }
}

