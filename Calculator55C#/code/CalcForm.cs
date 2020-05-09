using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator55
{
    public partial class CalcForm : Form
    {

        String inputText = "";

        // the equation I've used for most testing: 5--5.6*(-6)/2.24^(-3)
        //-372.6446464

        public CalcForm() {
            InitializeComponent();
        }

        private void textFieldKp(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                submit();
            }
        }
        
        private void submit() {
            inputText = textField.Text.Replace(" ", "");

            //turn the string into an array of strings
            String[] equation = new String[inputText.Length];
            for (int i = 0; i < equation.Length; i++) 
                equation[i] = inputText[i].ToString();

            Double num1 = 0; //used throughout the method as storage for double.tryParse

            for (int i = 0; i < equation.Length - 1; i++) {
                if ((Double.TryParse(equation[i], out num1) || equation[i] == ".") && (Double.TryParse(equation[i + 1], out num1) || equation[i + 1] == ".")) {
                    if ((equation[i] == "." && equation[i + 1] == ".") || (equation[i + 1] == "." && Double.TryParse(equation[i], out num1) && num1 % 1 != 0)) {
                        twoDecimalsError(equation[i] + equation[i + 1]);
                        return;
                    }
                    equation[i + 1] = equation[i] + equation[i + 1];
                    equation[i] = "";
                } else if ((equation[i] == "-" && equation[i + 1] == "-") || (equation[i] == "+" && equation[i + 1] == "+")) {
                    equation[i + 1] = "+";
                    equation[i] = "";
                } else if ((equation[i] == "+" && equation[i + 1] == "-") || (equation[i] == "-" && equation[i + 1] == "+")) {
                    equation[i + 1] = "-";
                    equation[i] = "";
                } else if (equation[i] == "*" && equation[i + 1] == "*") {
                    equation[i + 1] = "^";
                    equation[i] = "";
                } else if (i+4 < equation.Length && equation[i]+ equation[i+1]+ equation[i+2]+ equation[i+3] + equation[i+4] == "sqrt(") {
                    for (int j = i; j < i + 4; j++)
                        equation[j] = "";
                    equation[i+4] = "sqrt(";
                }
            }

            equation = removeEmpty(equation);

            // make everything with a negative adding a negative number so it's easier to deal with
            for (int i = 0; i < equation.Length; i++) {
                if (equation[i] == "-" && Double.TryParse(equation[i + 1], out num1)) {
                    equation[i + 1] = (num1 * -1).ToString();
                    if (i != 0 && Double.TryParse(equation[i - 1], out num1)) {
                        equation[i] = "+";
                    } else {
                        equation[i] = "";
                    }
                    
                }
            }

            equation = removeEmpty(equation);

            // 0: removing brackets where it can
            // 1: it does all exponents and square root
            // 2: multiplication and devision
            // 3: addition and subtraction
            int onbed = 0;
            Double num2 = 0;
            while (true) {
                for (int i = 0; i < equation.Length; i++) {
                    //brackets
                    if (i+2 < equation.Length && equation[i] == "(" && equation[i+2] == ")") {
                        //equation[i] = equation[i+1];
                        equation[i] = "";
                        equation[i + 2] = "";
                        equation = removeEmpty(equation);
                        onbed = 0;
                        continue;
                    }
                    // exponents and square roots
                    else if (onbed == 1) {
                        if (i + 2 < equation.Length && equation[i + 1] == "^" && (Double.TryParse(equation[i], out num1) && (Double.TryParse(equation[i + 2], out num2)))) {
                            equation[i] = Math.Pow(num1, num2).ToString();
                            equation[i + 1] = "";
                            equation[i + 2] = "";
                            equation = removeEmpty(equation);
                            onbed = 0;
                            continue;
                        } else if (i + 2 < equation.Length && equation[i] == "sqrt(" && Double.TryParse(equation[i+1], out num1) && equation[i + 2] == ")") {
                            equation[i] = Math.Pow(num1, 0.5).ToString();
                            equation[i + 1] = "";
                            equation[i + 2] = "";
                            equation = removeEmpty(equation);
                            onbed = 0;
                            continue;
                        }
                    }
                    // multiplication and division
                    else if (onbed == 2) {
                        if (i > 0 && i < equation.Length - 1 && (Double.TryParse(equation[i - 1], out num1) && Double.TryParse(equation[i + 1], out num2))
                            && !(i > 1 && equation[i - 2] == "^") && !(i < equation.Length - 2 && equation[i + 2] == "^"))
                        {
                            if (equation[i] == "*")
                            {
                                equation[i - 1] = (num1 * num2).ToString();
                                equation[i] = "";
                                equation[i + 1] = "";
                                equation = removeEmpty(equation);
                                onbed = 0;
                                continue;
                            }
                            else if (equation[i] == "/")
                            {
                                equation[i - 1] = (num1 / num2).ToString();
                                equation[i] = "";
                                equation[i + 1] = "";
                                equation = removeEmpty(equation);
                                onbed = 0;
                                continue;
                            }
                        }
                        //two numbers side by side is multiplication
                        if (i < equation.Length - 1 && Double.TryParse(equation[i], out num1) && Double.TryParse(equation[i + 1], out num2)) {
                            equation[i] = (num1 * num2).ToString();
                            equation[i + 1] = "";
                            equation = removeEmpty(equation);
                            onbed = 0;
                            continue;
                        }
                    }
                    // addition and subtraction
                    else if (onbed == 3) {
                        if (i > 0 && i < equation.Length - 1 && (equation[i] == "+" || equation[i] == "-") && (Double.TryParse(equation[i - 1], out num1) && (Double.TryParse(equation[i + 1], out num2)))
                            && (i < 2 || (i > 1 && (equation[i - 2] == "+" || equation[i - 2] == "-" || equation[i - 2] == "("))) && (i >= equation.Length - 3 || (i < equation.Length - 3 && (equation[i + 2] == "+" || equation[i + 2] == "-" || equation[i + 2] == ")")))
                            )
                        {
                            
                            if (equation[i] == "+") {
                                
                                equation[i - 1] = (num1 + num2).ToString();
                                equation[i] = "";
                                equation[i + 1] = "";
                                equation = removeEmpty(equation);
                                onbed = 0;
                                continue;
                            } else if (equation[i] == "-") {
                                equation[i - 1] = (num1 - num2).ToString();
                                equation[i] = "";
                                equation[i + 1] = "";
                                equation = removeEmpty(equation);
                                onbed = 0;
                                continue;
                            }
                        }
                    }
                }

                if (onbed++ == 3) break;
            }
            
            outPutTb.Text = string.Join("",equation);
        }

        private String[] removeEmpty(String[] arrayToFix) {
            // this section is slightly confusing but much shorter than before and more efficient
            int arraySize = 0;
            for (int i = 0; i < arrayToFix.Length; i++) {
                arraySize++;
                if (arrayToFix[i] == "") {
                    for (int j = i+1; j < arrayToFix.Length; j++) {
                        if (arrayToFix[j] != "") {
                            arrayToFix[i] = arrayToFix[j];
                            arrayToFix[j] = "";
                            break;
                        } else if (j+1 == arrayToFix.Length) {
                            Array.Resize(ref arrayToFix, arraySize);
                            return arrayToFix;
                        }
                    }
                }
            }
            return arrayToFix;
        }

        void updateText(String addition) {
            inputText = textField.Text + addition;
            textField.Text = this.inputText;
        }
        
        private void equalsButtonPress(object sender, EventArgs e) { submit(); }

        private void minusButtonPress(object sender, EventArgs e) { updateText("-"); }
        private void addButtonPress(object sender, EventArgs e) { updateText("+"); }
        private void divideButtonPress(object sender, EventArgs e) { updateText("/"); }
        private void multiplyButtonPress(object sender, EventArgs e) { updateText("*"); }
        private void powerButtonPress(object sender, EventArgs e) { updateText("^"); }
        private void sqrtButtonPress(object sender, EventArgs e) { updateText("sqrt()"); }
        private void rightBracketButtonPress(object sender, EventArgs e) { updateText(")"); }
        private void leftBracketButtonPress(object sender, EventArgs e) { updateText("("); }

        private void click0(object sender, EventArgs e) { updateText("0"); }
        private void click1(object sender, EventArgs e) { updateText("1"); }
        private void click2(object sender, EventArgs e) { updateText("2"); }
        private void click3(object sender, EventArgs e) { updateText("3"); }
        private void click4(object sender, EventArgs e) { updateText("4"); }
        private void click5(object sender, EventArgs e) { updateText("5"); }
        private void click6(object sender, EventArgs e) { updateText("6"); }
        private void click7(object sender, EventArgs e) { updateText("7"); }
        private void click8(object sender, EventArgs e) { updateText("8"); }
        private void click9(object sender, EventArgs e) { updateText("9"); }

        //errors
        void twoDecimalsError(String errorLocation) {
            outPutTb.Text = "two deciamls found in one number: "+errorLocation;
        }

    }
}
