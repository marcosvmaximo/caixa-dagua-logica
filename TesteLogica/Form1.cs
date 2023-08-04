namespace TesteLogica
{
    public partial class Form1 : Form
    {
        private bool s1Enable = true;
        private bool s2Enable = true;
        private bool s3Enable = true;
        private bool s4Enable = true;

        private bool v1Enable = false;
        private bool b1Enable = false;

        public Form1()
        {
            InitializeComponent();

            s1.Checked = s1Enable;
            s2.Checked = s2Enable;
            s3.Checked = s3Enable;
            s4.Checked = s4Enable;

            valvula1.Enabled = false;
            bomba1.Enabled = false;
        }

        private void AtualizarControleCaixaDagua()
        {
            valvula1.Checked = v1Enable;
            bomba1.Checked = b1Enable;

            s1.Checked = s1Enable;
            s2.Checked = s2Enable;
            s3.Checked = s3Enable;
            s4.Checked = s4Enable;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void chkS1_CheckedChanged(object sender, EventArgs e)
        {
            s1Enable = s1.Checked;

            if (s1Enable)
            {
                // Se S1 est� com agua, s2 tamb�m est�
                s2Enable = true;

                // Fecha quando s1 estiver com agua
                v1Enable = false;
            }

            if(s1Enable && !s4Enable)
            {
                b1Enable = true;
            }

            AtualizarControleCaixaDagua();
        }

        private void chkS2_CheckedChanged(object sender, EventArgs e)
        {
            s2Enable = s2.Checked;

            if (!s2Enable)
            {
                // S1 nunca ter� agua se s2 n�o possuir agua
                s1Enable = false;

                // Abrir a v�lvula se s2 estiver sem �gua
                v1Enable = true;

                // Bomba nunca deve estar ativada caso esteja sem agua o s2
                b1Enable = false;
            }

            AtualizarControleCaixaDagua();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkS3_CheckedChanged(object sender, EventArgs e)
        {
            s3Enable = s3.Checked;

            if (s3Enable)
            {
                // Se S3 est� com agua, s4 tamb�m est�
                s4Enable = true;

                // se S3 estiver com agua, bomba deve ser desligada
                b1Enable = false;
            }
            AtualizarControleCaixaDagua();
        }

        private void chkS4_CheckedChanged(object sender, EventArgs e)
        {
            s4Enable = s4.Checked;

            if (!s4Enable)
            {
                s3Enable = false;
            }

            if (!s4Enable && s1Enable)
            {
                // Se S4 est� sem agua, S3 tamb�m est�
                s3Enable = false;

                // Se S4 n�o possuir agua, bomba deve ser ativada
                b1Enable = true;


            }
            AtualizarControleCaixaDagua();
        }
    }
}