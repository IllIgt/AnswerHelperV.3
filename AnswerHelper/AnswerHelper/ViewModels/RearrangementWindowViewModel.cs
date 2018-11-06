﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnswerHelper
{
    abstract class RearrangementWindowViewModel : ViewModel
    {
        public Command SaveCommand { get; private set; }
        public string Chromosome { get; set; }
        public string Location { get; set; }
        public virtual List<string> CopiesNumbers { get; }
        public string SelectedCN { get; set; }
        
        public RearrangementWindowViewModel()
        {
            SaveCommand = new Command(OnSaveCommandExecuted);
        }

        protected virtual void OnSaveCommandExecuted(object obj)
        {
            throw new NotImplementedException();
        }

        protected string[] LocationParse()
        {
            Regex regex = new Regex(@"\d+\s+\d+");
            Match match = regex.Match(Location);
            return Regex.Split(match.Value, @"\s+");
        }
    }
}
