using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace appSqlWpfLogisticCompany
{
    public partial class Requests
    {
        public SolidColorBrush StatusColor
        {
            get
            {
                switch(Request_Status)
                {
                    case "Открыта": return Brushes.Green;
                    default: return Brushes.Red;
                }
            }
        }
    }
}
