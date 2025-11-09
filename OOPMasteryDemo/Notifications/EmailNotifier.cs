using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPMasteryDemo.Notifications
{
    public class EmailNotifier : INotifier
    {
        public void Notify(string message)
        {
            // For demo just write to console; in production you'd send email
            Console.WriteLine($"[EmailNotifier] Sending email notification: {message}");
        }
    }
}
