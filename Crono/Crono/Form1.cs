namespace Crono
{
    public partial class Form1 : Form
    {
        Thread hilo;

        public Form1()
        {
            InitializeComponent();
        }


        delegate void TiempoDelegado();

        public void CambiarTiempo()
        {
            if (this.InvokeRequired)
            {
                TiempoDelegado delegado = new TiempoDelegado(CambiarTiempo);
                try
                {
                    this.Invoke(delegado);
                }
                catch (ObjectDisposedException ex)
                {
                    return;
                }
            }
            else
            {
                label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" +
                              DateTime.Now.Second.ToString("00");
            }
        }

        private void Tiempo()
        {
            Thread.Sleep(100);
            if (this.Disposing || this.IsDisposed)
                return;
            CambiarTiempo();
            Tiempo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hilo = new Thread(Tiempo);
            hilo.Start();
        }
    }
}