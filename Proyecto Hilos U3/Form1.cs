using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Hilos_U3
{
    public partial class Form1 : Form
    {
        private int[] posicionesX = { 2, 2, 2, 2, 2 };
        private int[] posicionesY = { 50, 130, 210, 290, 370 };
        private PictureBox[] aviones = new PictureBox[5];
        private Button[] botones = new Button[5];
        private List<Thread> hilos = new List<Thread>();
        private Random random = new Random();
        private ManualResetEvent pausa = new ManualResetEvent(true);
        private bool carreraTerminada = false;
        private Label lblGanador;
        private PictureBox fondo;

        public Form1()
        {
            InitializeComponent();
            ConfigurarDobleBuffer();
            CargarPista();
            CargarAviones();
            CargarBotones();
            CargarLabelGanador();
            ReproducirMusica("C:\\Users\\Jassiel\\source\\repos\\Proyecto Hilos U3\\Sonidos\\Screen.wav");
        }

        private void ConfigurarDobleBuffer()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void CargarPista()
        {
            string rutaPista = Path.Combine(Application.StartupPath, "C:\\Users\\Jassiel\\source\\repos\\Proyecto Hilos U3\\Imagenes", "pista2.png");
            if (File.Exists(rutaPista))
            {
                fondo = new PictureBox()
                {
                    Image = Image.FromFile(rutaPista),
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                this.Controls.Add(fondo);
                fondo.SendToBack(); // Asegura que la pista no tape otros elementos
            }
        }

        private void CargarAviones()
        {
            string rutaAvion = Path.Combine(Application.StartupPath, "C:\\Users\\Jassiel\\source\\repos\\Proyecto Hilos U3\\Imagenes", "avion.png");
            this.SuspendLayout();
            for (int i = 0; i < 5; i++)
            {
                if (File.Exists(rutaAvion))
                {
                    aviones[i] = new PictureBox()
                    {
                        Image = Image.FromFile(rutaAvion),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(50, 50),
                        Location = new Point(posicionesX[i], posicionesY[i]),
                        BackColor = Color.Transparent
                    };
                    this.Controls.Add(aviones[i]);
                    aviones[i].BringToFront();
                }
                else
                {
                    MessageBox.Show("No se encontró la imagen del avión: " + rutaAvion);
                }
            }
            this.ResumeLayout();
        }

        private void CargarBotones()
        {
            for (int i = 0; i < 5; i++)
            {
                botones[i] = new Button()
                {
                    Text = $"Avión {i + 1}",
                    Location = new Point(20, posicionesY[i]),
                    Size = new Size(80, 30),
                    BackColor = Color.LightBlue
                };
                botones[i].Click += (sender, e) => MessageBox.Show($"Avión {i + 1} listo!");
                this.Controls.Add(botones[i]);
                botones[i].BringToFront();
            }
        }

        private void CargarLabelGanador()
        {
            lblGanador = new Label()
            {
                Text = "",
                Location = new Point(390, 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblGanador);
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            carreraTerminada = false;
            lblGanador.Text = "";
            hilos.Clear();

            for (int i = 0; i < 5; i++)
            {
                posicionesX[i] = 2;
                aviones[i].Location = new Point(posicionesX[i], posicionesY[i]);
                int index = i;
                Thread hilo = new Thread(() => MoverAvion(index));
                hilos.Add(hilo);
                hilo.Start();
            }
            ReproducirMusica("C:\\Users\\Jassiel\\source\\repos\\Proyecto Hilos U3\\Sonidos\\Despegue.wav");
        }

        private void MoverAvion(int index)
        {
            int velocidad = random.Next(3, 30);
            while (posicionesX[index] < 800 && !carreraTerminada)
            {
                pausa.WaitOne();
                Thread.Sleep(velocidad);
                posicionesX[index] += 6;
                this.Invoke((MethodInvoker)delegate
                {
                    aviones[index].Location = new Point(posicionesX[index], posicionesY[index]);
                    VerificarGanador(index);
                    aviones[index].Invalidate();
                });
            }
        }

        private void VerificarGanador(int index)
        {
            if (!carreraTerminada && posicionesX[index] >= 800)
            {
                carreraTerminada = true;
                lblGanador.Text = $"🏆 ¡GANADOR: Avión {index + 1}! 🏆";
                lblGanador.Visible = true;
                lblGanador.BringToFront();
                ReproducirMusica("C:\\Users\\Jassiel\\source\\repos\\Proyecto Hilos U3\\Sonidos\\Score.wav");
            }
        }

        private void btn_Pausar_Click(object sender, EventArgs e)
        {
            pausa.Reset();
        }

        private void btn_Reanudar_Click(object sender, EventArgs e)
        {
            pausa.Set();
        }

        private void btn_Reiniciar_Click(object sender, EventArgs e)
        {
            carreraTerminada = true;
            pausa.Reset();
            foreach (Thread hilo in hilos)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
            btn_Iniciar_Click(null, null);
        }

        private void ReproducirMusica(string archivo)
        {
            try
            {
                string rutaSonido = Path.Combine(Application.StartupPath, archivo);
                if (File.Exists(rutaSonido))
                {
                    using (SoundPlayer sp = new SoundPlayer(rutaSonido))
                    {
                        sp.Play();
                    }
                }
                else
                {
                    MessageBox.Show("Error: No se encontró el archivo de sonido " + archivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el sonido: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
