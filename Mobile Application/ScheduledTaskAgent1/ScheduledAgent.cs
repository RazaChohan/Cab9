using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using System;
using Microsoft.Phone.Shell;

namespace ScheduledTaskAgent1
{
        public class ScheduledAgent : ScheduledTaskAgent
    {
        private static volatile bool _classInitialized;

        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        public ScheduledAgent()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
                });
            }
        }

        /// Code to execute on Unhandled Exceptions
        private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }
        private void TestCallback(object sender, ScheduledTaskServiceReference.CabBookingCompletedEventArgs e)
        {
            
            //var toast = new ShellToast { Title = DateTime.Now.ToShortTimeString(), Content = e.Result.ToString() };
            //toast.Show();
            //MessageBox.Show(e.Result.ToString());
            //NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        protected override void OnInvoke(ScheduledTask task)
        {

            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(60));

            //ScheduledTaskServiceReference.ServiceClient clientForTesting = new ScheduledTaskServiceReference.ServiceClient();
            //clientForTesting.AuthenticateCustomerCompleted += new EventHandler<ScheduledTaskServiceReference.AuthenticateCustomerCompletedEventArgs>(TestCallback);
            //clientForTesting.AuthenticateCustomerAsync("Taimoor Bin Khalid","123");       
                 
            /////////////////
            ScheduledTaskServiceReference.ServiceClient clientForTesting = new ScheduledTaskServiceReference.ServiceClient();
            clientForTesting.CabBookingCompleted += new EventHandler<ScheduledTaskServiceReference.CabBookingCompletedEventArgs>(TestCallback);
            clientForTesting.CabBookingAsync("Uncatered", DateTime.Now, "AK. Brohi Road, H-11/4, H-11, Islamabad, Pakistan,", "A. K. Brohi Road, G-11/1, G-11, Islamabad, Pakistan,", "Executive");
               
            //////////////////
            //System.Threading.Thread.Sleep(5000);    //2 seconds wait
            var toast = new ShellToast { Title = DateTime.Now.ToShortTimeString(), Content = "Background Task Running" };
            toast.Show();
            NotifyComplete();  
            
        }
    }

}