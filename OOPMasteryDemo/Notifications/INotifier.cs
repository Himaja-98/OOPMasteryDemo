using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPMasteryDemo.Notifications
{
    // Interface - contract
    public interface INotifier
    {
        void Notify(string message);
    }
}
