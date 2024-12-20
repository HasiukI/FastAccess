using FastAccess.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAccess.ViewModels
{
    class MainViewModel
    {
        public HotKeyViewModel HotKey { get; set; }

        public MainViewModel() { 
            HotKey = new HotKeyViewModel();
        }
    }
}
