namespace CalculadoraBasica
{
    public partial class Form1 : Form
    {
        //Declaracion de variables
        private bool nuevaEntrada = false;
        double operando1 = 0;
        double operando2 = 0;
        string operador = "";
        bool error = false;

        public Form1()
        {
            InitializeComponent();
            TboxPantalla.Text = "0"; //Para que aparezca 0 por defecto
            TboxPantalla.ReadOnly = true; // No editable
            TboxPantalla.Font = new Font("Segoe UI", 14); // Tamaño 14
            TboxPantalla.TextAlign = HorizontalAlignment.Right; // Opcional: alinear a la derecha

            this.KeyPreview = true; //Permite capturar teclas
            this.KeyDown += teclas_Accion;
        }

        //Boton borrar el numero escrito 
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

        //Metodo para la funcion de seleccionar el operador 
        private void SeleccionarOperador(string op)
        {
            try
            {
                operando1 = double.Parse(TboxPantalla.Text);
                operador = op;

                //Mostrar el operador en TextBox
                switch (op)
                {
                    case "+": TboxPantalla.Text = operando1 + " +"; break;
                    case "-": TboxPantalla.Text = operando1 + " -"; break;
                    case "*": TboxPantalla.Text = operando1 + " ×"; break;
                    case "/": TboxPantalla.Text = operando1 + " ÷"; break;
                }

                nuevaEntrada = false; 
            }
            catch
            {
                MostrarError();
            }
        }
        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void TboxPantalla_TextChanged(object sender, EventArgs e)
        {

        }

        //Boton de limpiar todo la operacion 
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            //Se limpia todo
            TboxPantalla.Text = "0";
            nuevaEntrada = false;
        }

        // Boton de operador de divsion 
        private void BtnDividir_Click(object sender, EventArgs e)
        {
            SeleccionarOperador("/");
        }

        //Boton de operador de multiplicacion 
        private void BtnMultiplicar_Click(object sender, EventArgs e)
        {
            SeleccionarOperador("*"); 
        }

        private void BtnNum0_Click(object sender, EventArgs e)
        {

        }

        //Boton de operador de resta
        private void BtnResta_Click(object sender, EventArgs e)
        {
            SeleccionarOperador("-");
        }

        //Boton de operador de suma 
        private void BtnSuma_Click(object sender, EventArgs e)
        {
            SeleccionarOperador("+");
        }

        //Boton operador =, y sus devidas operaciones 
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                // Extraer la parte después del operador (el segundo número)
                string[] partes = TboxPantalla.Text.Split(new char[] { '+', '-', '×', '÷' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length < 2)
                {
                    return; // no hay operación completa
                }

                operando1 = double.Parse(partes[0].Trim());
                operando2 = double.Parse(partes[1].Trim());

                double resultado = 0;

                switch (operador)
                {
                    case "+": resultado = operando1 + operando2;
                        resultado = Math.Round(resultado, 3); break; //Suma 
                    case "-": resultado = operando1 - operando2;
                        resultado = Math.Round(resultado, 3); break; //Resta
                    case "*": resultado = operando1 * operando2;
                        resultado = Math.Round(resultado, 3); break; //Multiplicacion
                    case "/":  //Division 
                        if (operando2 == 0)  // Verificando el divissor no sea 0 
                        {
                            MostrarError("División por cero");
                            return;
                        }
                        resultado = operando1 / operando2;
                        resultado = Math.Round(resultado, 3); //Reduciendo la divison a 3 decimales
                        break;
                }

                // Mostrar resultado
                TboxPantalla.Text = $"{operando1} {SimboloOperador(operador)} {operando2} = {resultado}";
                nuevaEntrada = true;
            }
            catch
            {
                MostrarError();
            }
        }

        //Boton de accion del punto decimal 
        private void BtnPuntoDecimal_Click(object sender, EventArgs e)
        {
            string[] partes = TboxPantalla.Text.Split(new char[] { '+', '-', '×', '÷' }, StringSplitOptions.RemoveEmptyEntries);
            string ultimoNumero = partes[partes.Length - 1].Trim(); // Tomamos el último número

            // Si ya contiene un punto, no agregamos otro
            if (!ultimoNumero.Contains("."))
            {
                if (nuevaEntrada || ultimoNumero == "")
                {
                    TboxPantalla.Text += "0."; // Si empieza nuevo número, agregamos 0.
                    nuevaEntrada = false;
                }
                else {TboxPantalla.Text += ".";}

                // Cursor al final
                TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
                TboxPantalla.SelectionLength = 0;
            }

        }

        // Metodo de agregar los numeros y mostrar en pantalla 
        private void BtnNumeros(object sender, EventArgs e)  //Evento que engloba a todos los numeros de la calculadora
        {

            Button btn = (Button)sender;
            if (TboxPantalla.Text.Replace(" ", "").Length >= 12) return;
            //Si la pantalla esta mostrando un error limpiamos
            if (error)
            {
                TboxPantalla.Text = "0";
                error = false;
            }

            // Si el texto es "0" o acabamos de mostrar un resultado, reemplazamos
            if (TboxPantalla.Text == "0" || nuevaEntrada)
            {
                TboxPantalla.Text = btn.Text;
                nuevaEntrada = false;
            }
            else
            {
                TboxPantalla.Text += btn.Text;
            }
            // Colocar el cursor al final
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
        }

        //Metodo para controlar el manejo de impresion de errores
        private void MostrarError(string mensaje = "Error")
        {
            TboxPantalla.Text = mensaje;
            error = true;
            nuevaEntrada = true; 
        }

        // Función auxiliar para mostrar el símbolo correcto en el TextBox
        private string SimboloOperador(string op)
        {
            return op switch
            {
                "+" => "+",
                "-" => "-",
                "*" => "×",
                "/" => "÷",
                _ => ""
            };
        }

        //Boton de teclas de accion desde el teclado
        private void teclas_Accion(object sender, KeyEventArgs e)
        {
            string numero = null;

            // Números teclado principal
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                numero = (e.KeyCode - Keys.D0).ToString();
            // Números Numpad
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                numero = (e.KeyCode - Keys.NumPad0).ToString();

            if (numero != null)
            {
                // Creamos un Button temporal para reutilizar BtnNumeros
                Button btn = new Button();
                btn.Text = numero;
                BtnNumeros(btn, EventArgs.Empty);
            }
            // Punto decimal
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                BtnPuntoDecimal_Click(null, null);
            }
            // Operadores y teclas 
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.S) //Tecla S para suma a igual que + solo
                BtnSuma_Click(null, null);
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.R) //Tecla R para resta a igual que Simbolo de resta solo
                BtnResta_Click(null, null);
            else if (e.KeyCode == Keys.Multiply || e.KeyCode == Keys.M) //Tecla M para multiplicacion a igual que simbolo x solo
                BtnMultiplicar_Click(null, null);
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.D) //Tecla D para dividir a igula que simbolo division solo 
                BtnDividir_Click(null, null);
            // Enter para =
            else if (e.KeyCode == Keys.Enter)
                BtnIgual_Click(null, null);
            // Escape para limpiar
            else if (e.KeyCode == Keys.Escape)
                BtnLimpiar_Click(null, null);
            // Backspace para borrar
            else if (e.KeyCode == Keys.Back)
                BtnBorrar_Click(null, null);

            e.SuppressKeyPress = true; // Evita sonido de alerta del sistema
        }
    }
}
