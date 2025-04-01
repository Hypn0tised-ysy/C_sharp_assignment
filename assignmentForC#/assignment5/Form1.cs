using System.Text.RegularExpressions;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }
        private void dot_Click(object sender, EventArgs e)
        {
textBox1.Text += ".";
        }
        private void backspace_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Length > 0 ? textBox1.Text.Substring(0, textBox1.Text.Length - 1) : "";
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            textBox1.Text += button.Text;
        }

        // �����ť����¼�
        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // �ȺŰ�ť����¼�
        private void equal_Click(object sender, EventArgs e)
        {
            try
            {
                string infixExpression = textBox1.Text;
                string postfixExpression = InfixToPostfix(infixExpression);
                double result = EvaluatePostfix(postfixExpression);
                textBox2.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����ˣ�\n" + ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ��׺���ʽת�沨�����ʽ
       public static string[] Tokenize(string expression)
        {
            // ������ʽ����ƥ�����֡�������������
            var regex = new Regex(@"\d+(\.\d*)?|\+|\-|\*|\/|\(|\)");
            var matches = regex.Matches(expression);
            List<string> tokens = new List<string>();

            foreach (Match match in matches)
            {
                tokens.Add(match.Value);
            }

            // �� List<string> ת��Ϊ string[] ������
            return tokens.ToArray();
        }


        private string InfixToPostfix(string infix)
        {
            Stack<string> operators = new Stack<string>();
            List<string> output = new List<string>();
            string[] tokens = Tokenize(infix);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _)) // ����ǲ�����
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Pop(); // ���� '('
                }
                else if ("+-*/".Contains(token)) // ������
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(token))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0) // ����ʣ��Ĳ�����
            {
                output.Add(operators.Pop());
            }

            return string.Join(" ", output);
        }

        // ��ȡ�����������ȼ�
        private int GetPrecedence(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            return 0;
        }

        // �����沨�����ʽ
        private double EvaluatePostfix(string postfix)
        {
            if (string.IsNullOrWhiteSpace(postfix))
            {
                throw new InvalidOperationException("Postfix expression is empty or invalid.");
            }

            Stack<double> stack = new Stack<double>();
            string[] tokens = Tokenize(postfix);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double num)) // ���������
                {
                    stack.Push(num);
                }
                else // ����������
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Insufficient operands.");
                    }

                    double b = stack.Pop();
                    double a = stack.Pop();
                    double result = token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b,
                        _ => throw new InvalidOperationException("Unknown operator")
                    };
                    stack.Push(result);
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("The postfix expression is invalid.");
            }

            return stack.Pop();
        }


        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
