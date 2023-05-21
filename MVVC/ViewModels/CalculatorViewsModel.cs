using System.Windows.Input;
using MauiCalculator.MVVC.Enums;
using PropertyChanged;

namespace MauiCalculator.MVVC.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewsModel
    {
        public bool ISNumber1 { set; get; } = true;
        public string Number1 { get; set; } = "0";
        public string Number2 { get; set; } = "0";
        public string History { get; set; } = "";
        public double Result { get; set; } = 0;
        public Operations Operation { get; set; } = Operations.Clear;

        public ICommand AddCommand => new Command(() => AddOperation());
        public ICommand SubtractionCommand => new Command(() => SubtractionOperation());
        public ICommand MultiplicationCommand => new Command(() => MultiplicationOperation());
        public ICommand DivisionCommand => new Command(() => DivisionOperation());
        public ICommand SquaredCommand => new Command(() => SquaredOperation());
        public ICommand ClearCommand => new Command(() => ClearOperation());
        public ICommand PorcentCommand => new Command(() => PorcentOperation());
        public ICommand Number1Command => new Command(() => Concatenar("1"));
        public ICommand Number2Command => new Command(() => Concatenar("2"));
        public ICommand Number3Command => new Command(() => Concatenar("3"));
        public ICommand Number4Command => new Command(() => Concatenar("4"));
        public ICommand Number5Command => new Command(() => Concatenar("5"));
        public ICommand Number6Command => new Command(() => Concatenar("6"));
        public ICommand Number7Command => new Command(() => Concatenar("7"));
        public ICommand Number8Command => new Command(() => Concatenar("8"));
        public ICommand Number9Command => new Command(() => Concatenar("9"));
        public ICommand Number0Command => new Command(() => Concatenar("0"));
        public ICommand DatCommand => new Command(() => Concatenar("."));
        public ICommand ResultCommand => new Command(() => ResultOperation());


        private void Concatenar(string data)
        {          
            if (ISNumber1)
            {
                if (data == "0" && Number1 == "0")
                {
                    return;
                }
                else if (data == "." && Number1 == "0")
                {
                    Number1 = "0" + data;
                }
                Number1 += data;
            }
            else
            {
                if (data == "0" && Number2 == "0")
                {
                    return;
                }
                else if (data == "." && Number2 == "0")
                {
                    Number2 = "0" + data;
                }
                Number2 += data;
            }

            History += data;
        }

        private void AddOperation()
        {
            if (Number1 != "0")
            {
                ISNumber1 = false;
                Operation = Operations.Add;
            }
            else if (Number2 == "0")
            {
                return;
            }
            else
            {
                ResultOperation();
                Number1 = Result.ToString();
                Number2 = "0";
            }
            History += "+";

        }

        private void MultiplicationOperation()
        {
            if (Number1 != "0")
            {
                ISNumber1 = false;
                Operation = Operations.Multiply;
            }
            else if (Number2 == "0")
            {
                return;
            }
            else
            {
                ResultOperation();
                Number1 = Result.ToString();
                Number2 = "0";
            }
            History += "*";
        }

        private void SubtractionOperation()
        {
            if (Number1 != "0")
            {
                ISNumber1 = false;
                Operation = Operations.Subtract;
            }
            else if (Number2 == "0")
            {
                return;
            }
            else
            {
                ResultOperation();
                Number1 = Result.ToString();
                Number2 = "0";
            }
            History += "-";
        }

        private void DivisionOperation()
        {
            if (Number1 != "0")
            {
                ISNumber1 = false;
                Operation = Operations.Divide;
            }
            else if (Number2 == "0")
            {
                return;
            }
            else
            {
                ResultOperation();
                Number1 = Result.ToString();
                Number2 = "0";
            }
            History += "/";
        }

        private void SquaredOperation()
        {
            if (Number1 != "0")
            {
                ISNumber1 = false;
                Operation = Operations.Squared;
            }
            else if (Number2 == "0")
            {
                return;
            }
            else
            {
                ResultOperation();
                Number1 = Result.ToString();
                Number2 = "0";
            }
            History += "^";
        }

        private void ClearOperation()
        {
            Result = 0;
            Number1 = "0";
            Number2 = "0";
            History = "";
            ISNumber1 = true;
        }

        private void PorcentOperation()
        {
            if (Number1 != "0")
            {
                ISNumber1 = false;
                Operation = Operations.Porcent;
            }
            else if (Number2 == "0")
            {                
                return;
            }
            else
            {
                ResultOperation();
                Number1 = Result.ToString();
                Number2 = "0";
            }
            History += "%";

        }

        private void ResultOperation()
        {
            if (Number1 == "0" || Number2 == "0")
            {
                return;
            }

            switch (Operation)
            {
                case Operations.Porcent:
                    Result = Convert.ToDouble(Number1) * (Convert.ToDouble(Number2) / 100);
                    break;
                case Operations.Add:
                    Result = Convert.ToDouble(Number1) + Convert.ToDouble(Number2);
                    break;
                case Operations.Subtract:
                    Result = Convert.ToDouble(Number1) - Convert.ToDouble(Number2);
                    break;
                case Operations.Multiply:
                    Result = Convert.ToDouble(Number1) * Convert.ToDouble(Number2);
                    break;
                case Operations.Divide:
                    Result = Convert.ToDouble(Number1) / Convert.ToDouble(Number2);
                    break;
                case Operations.Squared:
                    Result = (Double)Math.Pow(Convert.ToDouble(Number1), Convert.ToDouble(Number2));
                    break;
                case Operations.Clear:
                    break;
            }
            Number1 = Result.ToString();
            Number2 = "0";

        }

    }
}
