namespace PW5M_Calculator
{
    public class MAUICalculator
    {
        public Entry FirstVal;
        public Entry SecondVal;
        public string Action;
        public MAUICalculator()
        {
            FirstVal = new Entry();
            FirstVal.Text = "";
            SecondVal = new Entry();
            SecondVal.Text = "";
            Action = "";
        }
        public double Imul()
        {
            double a = Convert.ToDouble(FirstVal.Text);
            double b = Convert.ToDouble(SecondVal.Text);
            return a * b;
        }
        public double Imul(double a, double b)
        {
            FirstVal.Text = a.ToString();
            SecondVal.Text = b.ToString();
            return a * b;
        }
        public double Div()
        {
            double a = Convert.ToDouble(FirstVal.Text);
            double b = Convert.ToDouble(SecondVal.Text);
            return a / b;
        }
        public double Div(double a, double b)
        {
            FirstVal.Text = a.ToString();
            SecondVal.Text = b.ToString();
            return a / b;
        }
        public double Add()
        {
            double a = Convert.ToDouble(FirstVal.Text);
            double b = Convert.ToDouble(SecondVal.Text);
            return a + b;
        }
        public double Add(double a, double b)
        {
            FirstVal.Text = a.ToString();
            SecondVal.Text = b.ToString();
            return a + b;
        }
        public double Sub()
        {
            double a = Convert.ToDouble(FirstVal.Text);
            double b = Convert.ToDouble(SecondVal.Text);
            return a - b;
        }
        public double Sub(double a, double b)
        {
            FirstVal.Text = a.ToString();
            SecondVal.Text = b.ToString();
            return a - b;
        }
        public double Percent()
        {
            double a = Convert.ToDouble(FirstVal.Text);
            double b = Convert.ToDouble(SecondVal.Text);
            return a % b;
        }
        public double Percent(double a, double b)
        {
            FirstVal.Text = a.ToString();
            SecondVal.Text = b.ToString();
            return a % b;
        }
        public double Equal()
        {            
            return ActionDetect();
        }
        private double ActionDetect()
        {
            double a = 0, b = 0;
            try
            {
                a = Convert.ToDouble(FirstVal.Text);
            }
            catch
            {
                FirstVal.Text = "0";
            }
            try
            {
                b = Convert.ToDouble(SecondVal.Text);
            }
            catch
            {
                SecondVal.Text = "0";
            }
            if (Action == "*")
            {
                return a * b;
            }
            if (Action == "/")
            {
                return a / b;
            }
            if (Action == "+")
            {
                return a + b;
            }
            if (Action == "-")
            {
                return a - b;
            }
            if (Action == "%")
            {                
                return a % b;
            }
            return 0;
        }
    }
}
