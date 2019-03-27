using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Calculator.Services
{
    class CalculateService : INotifyPropertyChanged
    {
        public CalculateService()
        {
            triggerDictionary = new Dictionary<string, bool>();
            triggerDictionary.Add("isSumm", false);
            triggerDictionary.Add("isDivide", false);
            triggerDictionary.Add("isSubstract", false);
            triggerDictionary.Add("isMultiplied", false);
            array = new string[] { "isSumm", "isMultiplied", "isDivide", "isSubstract" };
        }
        private string result = "";
        private string number1 = "";
        private string number2;
        private int resuleToInt = 0;
        int count = 0;
        private Dictionary<string, bool> triggerDictionary;
        private string[] array;

        private bool myTrigger = false;

        private bool triggerOperator = false;
        public bool TriggerOperator
        {
            get
            {
                return triggerOperator;
            }
            set
            {
                triggerOperator = value;
                OnPropertyChanged("TriggerOperator");
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }
        public void AddtoResult(string number)
        {
            if (triggerOperator == true)
            {
                if (myTrigger == true)
                {
                    Result = "";
                    Result = Result + number;
                    number2 = result;
                    myTrigger = false;
                }
                else
                {
                    Result = Result + number;
                    number2 = result;
                }
            }
            else
            {
                if (Result == "")
                {
                    Result = number;
                }
                else
                {
                    
                    Result = Result + number;
                }
            }
        }

        public void ClearResult()
        {
            Result = "";

            for (int i = 0; i < array.Length; i++)
            {
                triggerDictionary[array[i]] = false;
            }
            TriggerOperator = false;
            result = "";
            number1 = "";
            number2 = "";
            resuleToInt = 0;
        }

        public void SummClick()
        {
            if (number1 != ""&& count!= 0)
            {
                
                resuleToInt = int.Parse(number1) + int.Parse(Result);
                Result = resuleToInt.ToString();
                number1 = Result;
                myTrigger = true;
            }
            else
            {
                number1 = Result;
                resuleToInt = 0;
                myTrigger = true; count++;
            }

            SetOperator("isSumm");
            //triggerDictionary["isSumm"] = true;
            //OnTriger();
        }
        public void DivideClick()
        {
            if (number1 != "" && count != 0)
            {

                resuleToInt = int.Parse(number1) / int.Parse(Result);
                Result = resuleToInt.ToString();
                number1 = Result;
                myTrigger = true;
            }
            else
            {
                number1 = Result;
                resuleToInt = 0;
                Result = "";
                count++;
            }

            SetOperator("isDivide");
            //triggerDictionary["isSumm"] = true;
            //OnTriger();
        }
        public void MultiClick()
        {
            if (number1 != "" && count != 0)
            {

                resuleToInt = int.Parse(number1) * int.Parse(Result);
                Result = resuleToInt.ToString();
                number1 = Result;
                myTrigger = true;
            }
            else
            {
                number1 = Result;
                resuleToInt = 0;
                Result = "";
                count++;
            }

            SetOperator("isMultiplied");
            //triggerDictionary["isSumm"] = true;
            //OnTriger();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



        public void OnTriger()
        {
            foreach (var d in triggerDictionary)
            {
                if (d.Value == true)
                {
                    TriggerOperator = false;
                }

            }
        }


        public void SetOperator(string operatorName)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == operatorName)
                {
                    triggerDictionary[array[i]] = true;
                }
                else
                {
                    triggerDictionary[array[i]] = false;
                }
            }
            TriggerOperator = true;

        }

        public void GetResult()
        {

            var num1 = int.Parse(number1);
            var num2 = int.Parse(number2);
            string str = "";
            foreach (var d in triggerDictionary)
            {
                if (d.Value == true)
                {
                    str = d.Key;
                }
            }
            switch (str)
            {
                case "isSumm":
                    Result = (num1 + num2).ToString();
                    break;
                case "isDivide":
                    Result = (num1 / num2).ToString();
                    break;
                case "isMultiplied":
                    Result = (num1 * num2).ToString();
                    break;
                case "isSubstract":
                    Result = (num1 - num2).ToString();
                    break;
            }
            myTrigger = true;
        }
    }
}
