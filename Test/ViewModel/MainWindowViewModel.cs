using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test.BaseClass;
using Test.Windows;

namespace Test.ViewModel
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            TemplateCommand = new DelegateCommand(TemplateClick);
        }

        public ICommand TemplateCommand { get; set; }
        public void TemplateClick(object param)
        {
            new TemplateWindow() { DataContext = new TemplateViewModel() }.Show();
        }
    }
}
