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

        // 清除按钮点击事件
        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // 等号按钮点击事件
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
                MessageBox.Show("出错了！\n" + ex.Message, "计算错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 中缀表达式转逆波兰表达式
       public static string[] Tokenize(string expression)
        {
            // 正则表达式用于匹配数字、操作符和括号
            var regex = new Regex(@"\d+(\.\d*)?|\+|\-|\*|\/|\(|\)");
            var matches = regex.Matches(expression);
            List<string> tokens = new List<string>();

            foreach (Match match in matches)
            {
                tokens.Add(match.Value);
            }

            // 将 List<string> 转换为 string[] 并返回
            return tokens.ToArray();
        }


        private string InfixToPostfix(string infix)
        {
            Stack<string> operators = new Stack<string>();
            List<string> output = new List<string>();
            string[] tokens = Tokenize(infix);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _)) // 如果是操作数
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
                    operators.Pop(); // 弹出 '('
                }
                else if ("+-*/".Contains(token)) // 操作符
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(token))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0) // 弹出剩余的操作符
            {
                output.Add(operators.Pop());
            }

            return string.Join(" ", output);
        }

        // 获取操作符的优先级
        private int GetPrecedence(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            return 0;
        }

        // 计算逆波兰表达式
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
                if (double.TryParse(token, out double num)) // 如果是数字
                {
                    stack.Push(num);
                }
                else // 如果是运算符
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
