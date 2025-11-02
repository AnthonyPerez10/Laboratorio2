using System.Text.RegularExpressions;
using System.Linq;


namespace CalculadoraBasica
{
    public partial class Form1 : Form
    {
        //Declaracion de variables
        private bool nuevaEntrada = false;
        double operando1 = 0;
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
                nuevaEntrada = false;
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
            if (error)
            {
                TboxPantalla.Text = "0";
                error = false;
            }

            // Si hay un "=", usar el resultado como base
            if (TboxPantalla.Text.Contains("="))
                TboxPantalla.Text = operando1.ToString();

            // Si está vacío o "0" y no es "-", no permitas operador al inicio
            if ((string.IsNullOrWhiteSpace(TboxPantalla.Text) || TboxPantalla.Text == "0")
                && op != "-") return;

            // Si termina en operador, reemplázalo
            if (TboxPantalla.Text.EndsWith(" +") || TboxPantalla.Text.EndsWith(" -") ||
                TboxPantalla.Text.EndsWith(" ×") || TboxPantalla.Text.EndsWith(" ÷") ||
                TboxPantalla.Text.EndsWith("+") || TboxPantalla.Text.EndsWith("-") ||
                TboxPantalla.Text.EndsWith("×") || TboxPantalla.Text.EndsWith("÷") ||
                TboxPantalla.Text.EndsWith("(")) // evita poner op justo tras "("
            {
                if (TboxPantalla.Text.EndsWith("(") && op != "-")
                    return; // permitimos "-" como unario después de "("
                TboxPantalla.Text = TboxPantalla.Text.TrimEnd();
                if (!TboxPantalla.Text.EndsWith("("))
                    TboxPantalla.Text = TboxPantalla.Text.Substring(0, TboxPantalla.Text.Length - 1);
            }

            switch (op)
            {
                case "+": TboxPantalla.Text += " +"; break;
                case "-": TboxPantalla.Text += " -"; break;
                case "*": TboxPantalla.Text += " ×"; break;
                case "/": TboxPantalla.Text += " ÷"; break;
            }

            nuevaEntrada = false;
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
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
            operando1 = 0;
            operador = "";
            nuevaEntrada = false;
            error = false;
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
                string expresion = TboxPantalla.Text.Trim();

                // Si está vacío o termina en operador, no evaluamos
                if (string.IsNullOrEmpty(expresion) ||
                    expresion.EndsWith("+") || expresion.EndsWith("-") ||
                    expresion.EndsWith("×") || expresion.EndsWith("÷"))
                {
                    MostrarError("Expresión incompleta");
                    return;
                }

                // Reemplazar símbolos visuales por los que entiende C#
                expresion = expresion.Replace("×", "*").Replace("÷", "/");

                // Eliminar espacios duplicados
                expresion = System.Text.RegularExpressions.Regex.Replace(expresion, @"\s+", " ");

                // Insertar multiplicación explícita donde haya multiplicación implícita
                expresion = Regex.Replace(expresion, @"(\d)\s*\(", "$1*(");
                expresion = Regex.Replace(expresion, @"\)\s*(\d)", ")*$1");
                expresion = Regex.Replace(expresion, @"\)\s*\(", ")*(");

                // Validar que solo haya números, operadores y paréntesis
                if (!System.Text.RegularExpressions.Regex.IsMatch(expresion, @"^[0-9+\-*/(). ]+$"))
                {
                    MostrarError("Entrada no válida");
                    return;
                }

                // Validar paréntesis balanceados
                int abiertos = expresion.Count(c => c == '(');
                int cerrados = expresion.Count(c => c == ')');
                if (abiertos != cerrados)
                {
                    MostrarError("Paréntesis desbalanceados");
                    return;
                }

                // Evaluar la expresión completa usando DataTable.Compute
                using (System.Data.DataTable dt = new System.Data.DataTable())
                {
                    object resultadoObj = dt.Compute(expresion, "");
                    double resultado = Math.Round(Convert.ToDouble(resultadoObj), 3);

                    // Verificar resultados inválidos
                    if (double.IsInfinity(resultado) || double.IsNaN(resultado))
                    {
                        MostrarError("Resultado indefinido");
                        return;
                    }

                    // Mostrar resultado final en el display
                    TboxPantalla.Text = $"{TboxPantalla.Text} = {resultado}";

                    // Guardar resultado para continuar operando con él
                    operando1 = resultado;
                    operador = "";
                    nuevaEntrada = true;
                }
            }
            catch (Exception)
            {
                MostrarError("Expresión inválida");
            }
        }

        //Boton de accion del punto decimal 
        private void BtnPuntoDecimal_Click(object sender, EventArgs e)
        {
            // Si hay error, reiniciar
            if (error)
            {
                TboxPantalla.Text = "0";
                error = false;
            }

            // Si venimos de un resultado anterior (=), reiniciar
            if (TboxPantalla.Text.Contains("="))
            {
                TboxPantalla.Text = "0";
                operando1 = 0;
                operador = "";
                nuevaEntrada = false;
            }

            // Si solo hay "0" en pantalla, lo borramos antes de escribir el punto
            if (TboxPantalla.Text == "0")
                TboxPantalla.Text = "";

            //Último carácter visible (ignora espacios)
            char last = '\0';
            for (int i = TboxPantalla.Text.Length - 1; i >= 0; i--)
                if (!char.IsWhiteSpace(TboxPantalla.Text[i])) { last = TboxPantalla.Text[i]; break; }

            // Si el último carácter es ')', agregar multiplicación implícita
            if (last == ')')
            {
                TboxPantalla.Text += " × 0.";
                TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
                TboxPantalla.SelectionLength = 0;
                return;
            }

            // Dividir texto para validar último número
            string[] partes = TboxPantalla.Text.Split(new char[] { '+', '-', '×', '÷' }, StringSplitOptions.RemoveEmptyEntries);
            string ultimoNumero = partes.Length > 0 ? partes[partes.Length - 1].Trim() : "";

            // Si ya contiene un punto, no agregar otro
            if (ultimoNumero.Contains(".")) return;

            //Si empieza nueva entrada o está vacío, agregar "0."
            if (nuevaEntrada || string.IsNullOrWhiteSpace(ultimoNumero))
            {
                TboxPantalla.Text += "0.";
                nuevaEntrada = false;
            }
            else
            {
                TboxPantalla.Text += ".";
            }

            // Colocar el cursor al final
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
        }


        // Metodo de agregar los numeros y mostrar en pantalla 
        private void BtnNumeros(object sender, EventArgs e)  //Evento que engloba a todos los numeros de la calculadora
        {
            Button btn = (Button)sender;
            if (TboxPantalla.Text.Replace(" ", "").Length >= 20) return;

            // Si venimos de un resultado con "=", reiniciar todo
            if (TboxPantalla.Text.Contains("="))
            {
                TboxPantalla.Text = "0";
                operando1 = 0;
                operador = "";
                nuevaEntrada = false;
                error = false;
            }

            if (error)
            {
                TboxPantalla.Text = "0";
                error = false;
            }

            // Quitar 0 inicial
            if (TboxPantalla.Text == "0")
                TboxPantalla.Text = "";

            // Si el último es ')', insertar "×" antes del número
            char last = '\0';
            for (int i = TboxPantalla.Text.Length - 1; i >= 0; i--)
                if (!char.IsWhiteSpace(TboxPantalla.Text[i])) { last = TboxPantalla.Text[i]; break; }

            if (last == ')')
            {
                TboxPantalla.Text += " × " + btn.Text;
                TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
                TboxPantalla.SelectionLength = 0;
                return;
            }

            if (nuevaEntrada)
            {
                TboxPantalla.Text = btn.Text; // empieza nuevo número
                nuevaEntrada = false;
            }
            else
            {
                TboxPantalla.Text += btn.Text; // continúa expresión
            }

            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
            TboxPantalla.SelectionLength = 0;
        }

        //Metodo para controlar el manejo de impresion de errores
        private void MostrarError(string mensaje = "Error")
        {
            TboxPantalla.Text = mensaje;
            error = true;
            nuevaEntrada = true;
            operando1 = 0;
            operador = "";
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

        private void BtnParentesis(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            string simbolo = btn.Text;

            if (TboxPantalla.Text.Replace(" ", "").Length >= 25) return;

            // Si hay error, reiniciar
            if (error)
            {
                TboxPantalla.Text = simbolo;
                error = false;
                nuevaEntrada = false;
                return;
            }

            // Si venimos de un resultado anterior (=), reiniciar si abrimos "("
            if (TboxPantalla.Text.Contains("="))
            {
                if (simbolo == "(")
                {
                    TboxPantalla.Text = "(";
                    nuevaEntrada = false;
                    return;
                }
                else
                {
                    MostrarError("Expresión no válida después de resultado");
                    return;
                }
            }

            // Si el display tiene solo "0", borrar antes del primer "("
            if (TboxPantalla.Text == "0")
                TboxPantalla.Text = "";

            // Detectar último carácter visible (no espacio)
            char last = '\0';
            for (int i = TboxPantalla.Text.Length - 1; i >= 0; i--)
                if (!char.IsWhiteSpace(TboxPantalla.Text[i])) { last = TboxPantalla.Text[i]; break; }

            // Si es paréntesis de apertura "("
            if (simbolo == "(")
            {
                // Si viene después de número, ".", o ")", agregar multiplicación implícita
                if (char.IsDigit(last) || last == ')' || last == '.')
                    TboxPantalla.Text += " × (";
                else
                    TboxPantalla.Text += "(";
            }
            // Si es paréntesis de cierre ")"
            else if (simbolo == ")")
            {
                int abiertos = TboxPantalla.Text.Count(c => c == '(');
                int cerrados = TboxPantalla.Text.Count(c => c == ')');

                if (abiertos > cerrados)
                {
                    // Evita cerrar justo después de un operador o un "("
                    if (last != '+' && last != '-' && last != '×' && last != '÷' && last != '(')
                        TboxPantalla.Text += ")";
                }
                else
                {
                    MostrarError("Falta '(' antes de ')'");
                    return;
                }
            }

            // Cursor al final
            TboxPantalla.SelectionStart = TboxPantalla.Text.Length;
        }


    }
}
