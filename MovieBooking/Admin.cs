using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MovieBooking
{
    public class Admin
    {
        public void Module()
        {
            try
            {
                if (!File.Exists(@"D:\CSFiles\Bookings.txt"))
                {
                    Console.WriteLine("No One has booked tickets till now");
                }
                else
                {
                    using (FileStream fileStreamObj = new FileStream(@"D:\CSFiles\Bookings.txt", FileMode.Open))
                    {
                        StreamReader streamReaderObj = new StreamReader(fileStreamObj);
                        while (streamReaderObj.Peek() > 0)
                        {
                            Console.WriteLine(streamReaderObj.ReadLine());
                        }
                    }
                }
            UP:
                Console.Write("Enter yes to LogOut - ");
                if (Console.ReadLine() == "yes")
                {
                    return;
                }
                goto UP;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR 404");
                using (FileStream fileStreamObj2 = new FileStream(@"D:\CSFiles\Log.txt", FileMode.Append, FileAccess.Write))
                {
                    StreamWriter streamWriterObj = new StreamWriter(fileStreamObj2);
                    streamWriterObj.Write("Date : " + DateTime.Now.ToString() + " ");
                    streamWriterObj.Write("Message : " + ex.Message + " ");
                    streamWriterObj.WriteLine("StackTrace : " + ex.StackTrace + " ");
                }
            }
        }
    }
}