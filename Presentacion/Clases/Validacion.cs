using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Clases
{
    public class Validacion
    {
        public static void NoLetras(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || (char.IsWhiteSpace(e.KeyChar) || char.IsUpper(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 22))
            {
                e.Handled = true;
            }
        }
        public static void NoNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 2)
            {
                e.Handled = true;
            }
        }

        public static void NoSimbolos(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || Convert.ToInt32(e.KeyChar) == 2)
            {
                e.Handled = true;
            }
        }

        public static void VerificarNoVacios(object sender, EventArgs e, ErrorProvider error)
        {
            if (sender is TextBox)
            {
                error.SetError(((TextBox)sender),
                    !string.IsNullOrEmpty(((TextBox)sender).Text) ? "" : "Dato Obligatorio");
            }
            else if (sender is NumericUpDown)
            {
                error.SetError(((NumericUpDown)sender),
                    !string.IsNullOrEmpty(((NumericUpDown)sender).Text) ? "" : "Dato Obligatorio");
            }
        }

        public static void NoInyeccion(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '{' || e.KeyChar == '}' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == ';' || e.KeyChar == '+' || e.KeyChar == '"' || (int)e.KeyChar == 39)
            {
                e.Handled = true;
            }
        }

        public static bool ValidarEmail(string Email, ErrorProvider errorProvider, TextBox textBox)
        {
            var Estado = false;
            var expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(Email, expresion))
            {
                if (Regex.Replace(Email, expresion, String.Empty).Length == 0)
                {
                    errorProvider.SetError(textBox, string.Empty);
                    Estado = true;
                }
                else
                {
                    errorProvider.SetError(textBox, "Formato del Mail Incorrecto");
                }
            }
            else
            {
                errorProvider.SetError(textBox, "Formato del Mail Incorrecto");
            }

            return Estado;
        }
    }
}
