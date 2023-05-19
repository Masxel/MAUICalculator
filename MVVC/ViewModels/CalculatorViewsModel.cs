using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiCalculator.MVVC.ViewModels
{
    public class CalculatorViewsModel
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }

        public ICommand AddCommand => new Command(() => Result = Number1 + Number2);
        public ICommand SubtractionCommand => new Command(() => Result = Number1 - Number2);
        public ICommand MultiplicationCommand => new Command(() => Result = Number1 * Number2);
        public ICommand DivisionCommand => new Command(() => Result = Number1 * Number2);


    }
}
