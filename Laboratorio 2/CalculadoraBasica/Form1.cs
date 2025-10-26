namespace CalculadoraBasica
{
    public partial class Form1 : Form
    {
        //Declaracion de variables

        private bool nuevaEntrada = false;

        public Form1()
        {
            InitializeComponent();
            TboxPantalla.Text = "0"; //Para que aparezca 0 por defecto
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {

            // Si estamos en nuevaEntrada} dejamos 0
            if (nuevaEntrada)
            {
                TboxPantalla.Text = "0";
                nuevaEntrada = true;
                return;
            }

            if (TboxPantalla.Text.Length > 1) //Si el texto es mayor a 1 se borra una posicion 
            {
                TboxPantalla.Text = TboxPantalla.Text.Substring(0, TboxPantalla.Text.Length - 1);
            }
            else
            {
                TboxPantalla.Text = "0"; //Sino se pone en 0 automticamente
            }
        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void TboxPantalla_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            //Se limpia todo
            TboxPantalla.Text = "0";
            nuevaEntrada = false;
        }

        private void BtnDividir_Click(object sender, EventArgs e)
        {

        }

        private void BtnMultiplicar_Click(object sender, EventArgs e)
        {

        }

        private void BtnNum0_Click(object sender, EventArgs e)
        {

        }

        private void BtnResta_Click(object sender, EventArgs e)
        {

        }

        private void BtnSuma_Click(object sender, EventArgs e)
        {

        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {

        }

        private void BtnPuntoDecimal_Click(object sender, EventArgs e)
        {
            // Si venimos de realizar alguna operacion o seleccionamos un operado, empezamos con 0.
            if (nuevaEntrada) 
            {
                TboxPantalla.Text = "0";
                nuevaEntrada = false;
            }
            if (!TboxPantalla.Text.Contains(".")) // Si no tiene punto y no excede el largo máximo, lo agregamos
            {
                TboxPantalla.Text += ".";
            }
        }

        private void BtnNumeros(object sender, EventArgs e)  //Evento que engloba a todos los numeros de la calculadora
        {

            Button btn = (Button)sender;
            if (TboxPantalla.Text == "0" || nuevaEntrada) 
            {
                TboxPantalla.Text = btn.Text; //Se muestra en pantalla el texto del boton pulsado
                nuevaEntrada = false; // Para marcar a que ya esta en modo edicion y pase a concatenar 
            }
            else if (TboxPantalla.Text.Length < 12)
            {
                TboxPantalla.Text += btn.Text; //Se concatena si no se excede de los 12 digitos
            }

        }
    }
}
