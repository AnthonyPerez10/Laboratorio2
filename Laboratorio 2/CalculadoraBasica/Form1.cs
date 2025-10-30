using System.Data;

namespace CalculadoraBasica
{
    public partial class Form1 : Form
    {
        //Declaracion de variables
        private bool nuevaEntrada = false;
        bool error = false;
        private bool resultadoMostrado = false; 

        public Form1()
        {
            InitializeComponent();
            TboxPantalla.Text = "0"; //Para que aparezca 0 por defecto
            TboxPantalla.ReadOnly = true; // No editable
            TboxPantalla.Font = new Font("Segoe UI", 12); // Tamaño 14
            TboxPantalla.TextAlign = HorizontalAlignment.Right; // Opcional: alinear a la derecha
            TboxPantalla.ScrollBars = ScrollBars.None;
            this.KeyPreview = true; //Permite capturar teclas
            this.KeyDown += teclas_Accion;
        }

        //Boton borrar el numero escrito 
        private void BtnBorrar_Click(object sender, EventArgs e)
        {

            if (error)
            {
                MostrarError();
                return;
            }

            if (TboxPantalla.Text.Length > 1)
                TboxPantalla.Text = TboxPantalla.Text.Substring(0, TboxPantalla.Text.Length - 1);
            else
                TboxPantalla.Text = "0";

            //Mantener el curso a la derecha. 
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
        }

        //Metodo para la funcion de seleccionar el operador 
        private void SeleccionarOperador(string op)
        {
            try
            {
                string texto = TboxPantalla.Text;

                if (texto.EndsWith("+") || texto.EndsWith("-") || texto.EndsWith("×") || texto.EndsWith("÷"))
                {
                    TboxPantalla.Text = texto.Substring(0, texto.Length - 1) + SimboloOperador(op);
                    return;
                }

                if (texto.Contains("="))
                {
                    // Si ya hay resultado, tomar solo la línea del resultado
                    string[] lineas = texto.Split('\n');
                    TboxPantalla.Text = lineas.Last().Replace("= ", "").Trim();
                }

                TboxPantalla.Text += SimboloOperador(op);
                nuevaEntrada = false;

                //Mantener el curso a la derecha. 
                TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
                TboxPantalla.SelectionLength = 0;
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
            error = false;

            //Mantener el curso a la derecha. 
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
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
                // Si ya hay resultado mostrado, no re-evaluar
                if (resultadoMostrado)
                {
                    // Simplemente mantener el resultado actual
                    return;
                }

                string expresion = TboxPantalla.Text
                    .Replace("×", "*")
                    .Replace("÷", "/")
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Trim();

                if (expresion.EndsWith("+") || expresion.EndsWith("-") ||
                    expresion.EndsWith("*") || expresion.EndsWith("/"))
                    return;

                DataTable dt = new DataTable();
                var resultado = dt.Compute(expresion, "");

                // Convertimos el resultado a double para validaciones
                double valor = Convert.ToDouble(resultado);

                // Validamos que no sea infinito ni NaN
                if (double.IsInfinity(valor) || double.IsNaN(valor))
                {
                    MostrarError("Operación inválida"); // Mostramos error
                    return; // Salimos sin actualizar el TextBox
                }

                // Si todo está bien, mostramos la operación y el resultado
                TboxPantalla.Text = $"{expresion}\r\n= {valor:0.################}";
                resultadoMostrado = true;
                nuevaEntrada = true;

                TboxPantalla.Text = $"{expresion}\r\n= {Convert.ToDouble(resultado):0.################}";
                resultadoMostrado = true;
                nuevaEntrada = true;

                //Mantener el curso a la derecha. 
                TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
                TboxPantalla.SelectionLength = 0;
            }
            catch
            {
                MostrarError("Error en la expresión");
            }
        }

        //Boton de accion del punto decimal 
        private void BtnPuntoDecimal_Click(object sender, EventArgs e)
        {
            string texto = TboxPantalla.Text;

            // Si acabamos de mostrar un resultado, iniciamos un nuevo número
            if (resultadoMostrado)
            {
                TboxPantalla.Text = "0.";
                resultadoMostrado = false;
                nuevaEntrada = false;
                //Mantener el curso a la derecha. 
                TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
                TboxPantalla.SelectionLength = 0;
                return;
            }

            // Último número después del operador
            string[] partes = texto.Split(new char[] { '+', '-', '×', '÷' }, StringSplitOptions.RemoveEmptyEntries);
            string ultimo = partes.LastOrDefault()?.Trim() ?? "";

            if (!ultimo.Contains("."))
            {
                if (nuevoNumero() || ultimo == "")
                {
                    TboxPantalla.Text += "0.";  // Anteponer cero si no hay número
                }
                else
                {
                    TboxPantalla.Text += ".";
                }
            }

            //Mantener el curso a la derecha. 
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
        }
        
        //Metodo de validar numero al inicio. 
        private bool nuevoNumero()
        {
            return nuevaEntrada || TboxPantalla.Text.EndsWith("+") ||
                   TboxPantalla.Text.EndsWith("-") ||
                   TboxPantalla.Text.EndsWith("×") ||
                   TboxPantalla.Text.EndsWith("÷") ||
                   TboxPantalla.Text.Contains("\n"); // Si ya hay resultado, iniciar nuevo número
        }


        // Metodo de agregar los numeros y mostrar en pantalla 
        private void BtnNumeros(object sender, EventArgs e)  //Evento que engloba a todos los numeros de la calculadora
        {

            Button btn = (Button)sender;
            if (error)
            {
                TboxPantalla.Text = "0";
                error = false;
            }

            // Tomar el número actual (después del último operador)
            string texto = TboxPantalla.Text;
            string[] operadores = new string[] { "+", "-", "×", "÷" };
            int indiceUltOperador = texto.LastIndexOfAny(new char[] { '+', '-', '×', '÷' });

            string numeroActual = indiceUltOperador >= 0 ? texto.Substring(indiceUltOperador + 1).Trim() : texto;

            // Limitar a 12 dígitos, ignorando el punto decimal
            if (numeroActual.Replace(".", "").Length >= 12)
                return;

            // Si la pantalla está mostrando 0 o venimos de un resultado
            if (texto == "0" || nuevaEntrada)
            {
                TboxPantalla.Text = btn.Text;
                nuevaEntrada = false;
            }
            else
            {
                TboxPantalla.Text += btn.Text;
            }

            resultadoMostrado = false;

            //Mantener el curso a la derecha. 
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
        }

        //Metodo para controlar el manejo de impresion de errores
        private void MostrarError(string mensaje = "Error   ")
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
