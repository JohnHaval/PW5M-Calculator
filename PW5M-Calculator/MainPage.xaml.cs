namespace PW5M_Calculator;

public partial class MainPage : ContentPage
{	
	public MainPage()
	{
		InitializeComponent();
        Calculator = new MAUICalculator();
    }
	MAUICalculator Calculator;
	bool isActionClicked = false;
	private void Clear_Clicked(object sender, EventArgs e)
	{
		isActionClicked = false;
		ActionArea.Text = "";
		Calculator = new MAUICalculator();
    }

    private void Del_Clicked(object sender, EventArgs e)
	{
		try
		{
            ActionArea.Text = ActionArea.Text.Remove(ActionArea.Text.Length - 1, 1);			
			if (Calculator.SecondVal.Text != "")
			{
                Calculator.SecondVal.Text = Calculator.SecondVal.Text.Remove(Calculator.SecondVal.Text.Length - 1, 1);
            }
			else
			{
				if (Calculator.Action != "")
				{
					Calculator.Action = "";
					isActionClicked = false;
                }
				else
				{
					Calculator.FirstVal.Text = Calculator.FirstVal.Text.Remove(Calculator.FirstVal.Text.Length - 1, 1);
				}
            }
		}
		catch { }
	}

	private void Number_Clicked(object sender, EventArgs e)
	{
		try
		{
			if (!isActionClicked)
			{
				if (Calculator.FirstVal.Text.Length <= 6 && Calculator.FirstVal.Text.Length >= 0)
				{
					ActionArea.Text += ((Button)sender).Text;
                    Calculator.FirstVal.Text += ((Button)sender).Text;
                }
			}
			else
			{
				if (Calculator.SecondVal.Text.Length <= 6 && Calculator.SecondVal.Text.Length >= 0)
				{
                    ActionArea.Text += ((Button)sender).Text;
                    Calculator.SecondVal.Text += ((Button)sender).Text;
                }
			}
		}
		catch { }
	}

	private void Percent_Clicked(object sender, EventArgs e)
	{
        if (!isActionClicked)
        {
            FirstType(sender, e);
        }
        else
        {            
            Results.Add(new Label { Text = $"{ResultReplace(Calculator.Equal())}" });
            isActionClicked = true;
            Calculator.Action = "%";
            ActionArea.Text += "%";
        }
    }

	private void Imul_Clicked(object sender, EventArgs e)
	{
		if (!isActionClicked)
		{
			FirstType(sender, e);
        }
		else
		{
            Results.Add(new Label { Text = $"{ResultReplace(Calculator.Equal())}" });
            isActionClicked = true;
            Calculator.Action = "*";
			ActionArea.Text += "*";
		}
	}

	private void ClearResults_Clicked(object sender, EventArgs e)
	{
		Results.Clear();
	}

	private void Division_Clicked(object sender, EventArgs e)
	{
        if (!isActionClicked)
        {
            FirstType(sender, e);
        }
        else
        {
            Results.Add(new Label { Text = $"{ResultReplace(Calculator.Equal())}" });
            isActionClicked = true;
            Calculator.Action = "/";
            ActionArea.Text += "/";
        }
    }

	private void Minus_Clicked(object sender, EventArgs e)
	{
		if (Calculator.FirstVal.Text == "")
		{
			ActionArea.Text += "-";
			Calculator.FirstVal.Text += "-";
		}
		else if (Calculator.FirstVal.Text != "-")
		{
			if (!isActionClicked)
			{
				FirstType(sender, e);
			}
			else
			{
				Results.Add(new Label { Text = $"{ResultReplace(Calculator.Equal())}" });
				isActionClicked = true;
				Calculator.Action = "-";
				ActionArea.Text += "-";
			}
		}
    }

	private void Plus_Clicked(object sender, EventArgs e)
	{
        if (!isActionClicked)
        {
            FirstType(sender, e);
        }
        else
        {
            Results.Add(new Label { Text = $"{ResultReplace(Calculator.Equal())}" });
			isActionClicked = true;
            Calculator.Action = "+";
            ActionArea.Text += "+";
        }
    }

	private void Equal_Clicked(object sender, EventArgs e)
	{
        isActionClicked = false;
        Results.Add(new Label { Text = $"{ResultReplace(Calculator.Equal())}" });		
    }

	private void FirstType(object sender, EventArgs e)
	{
		try
		{
			ActionArea.Text += ((Button)sender).Text;
			Calculator.Action = ((Button)sender).Text;
            isActionClicked = true;
		}
		catch { }
    }
	private double ResultReplace(double result)
	{
		Calculator.FirstVal.Text = ActionArea.Text = result.ToString();
        Calculator.Action = Calculator.SecondVal.Text = "";
        isActionClicked = false;
        return result;
	}
}

