using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;

namespace Lab12_Exercise
{
    [PluginAttribute("Lab12_Exec", "TwentyTwo", DisplayName = "Lab12_Exec",
        ToolTip = "A tutorial project by TwentyTwo")]

    public class MainClass : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            // current document (.NET)
            Document doc = Application.ActiveDocument;
            // current selected items
            ModelItemCollection items = doc.CurrentSelection.SelectedItems;
            if (items.Count > 0)
            {              
                // call form
                UserControl1 dialog = new UserControl1(doc);
                dialog.ShowDialog();              
            }
            return 0;
        }
    }
}

