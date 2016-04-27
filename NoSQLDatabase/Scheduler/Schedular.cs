//////////////////////////////////////////////////////////////////////////////
// Schedular.cs - Define element for noSQL database                         //
// Ver 1.0                                                                  //
// Application: Demonstration for CSE681-SMA, Project#2                     //
// Language:    C#, ver 6.0, Visual Studio 2015                             //
// Platform:    Dell Inspiron 14 5000Series, Core-i5, Windows 10            //
// Author:      Yogesh Chaudhari, Student, Syracuse University              //
//              (315) 4809210, ychaudha@syr.edu                             //
//////////////////////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package implements a method to schedule continuous writing of data from DBEngine to XML file
 * after specific time-interval
 */
/*
 * Maintenance:
 * ------------
 * Required Files: Schedular.cs, DBElement.cs, DBEngine.cs, DBExtensions.cs, Display.cs, PersistEgine.cs, UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 *
 * Reference: Project2Starter project by Dr. Fawcett
 * ----------
 *
 *
 * Maintenance History:
 * --------------------
 * ver 1.0 : 7 Oct 15
 * - first release
 *
 */


using System;
using System.Collections.Generic;
using System.Timers;
using static System.Console;

namespace Project2Starter
{
    public class Schedular
    {
        public Timer schedular { get; set; } = new Timer();
        private int count = 0;

        public Schedular(DBEngine<int, DBElement<int, string>> db)
        {
            //setting time interval for persisting of data
            schedular.Interval = 2000;
            schedular.AutoReset = true;
            schedular.Enabled = true;
            //defining method to be called when elapsed event occurs
            //this method persists data into xml file from DBEngine.
            schedular.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                if (count++ < 5)
                {
                    "Persisting to Test_DB.xml file".title();
                    db.create_xml_from_db(true);
                }
                else
                {
                    "Stopped persisting to test_DB.xml file".title();
                    schedular.Enabled = false;
                    
                }
            };
        }
    }

#if (TEST_SCHEDULAR)
    class TestSchedular
    {
        static void Main(string[] args)
        {
            "Demonstrate Timer - needed for scheduled persistance in Project #2".title('=');
            Console.Write("\n\n  press any key to exit\n");
            DBEngine<int, DBElement<int, string>> db = new DBEngine<int, DBElement<int, string>>();

            for (int i = 0; i < 3; i++)
            {
                DBElement<int, string> elem = new DBElement<int, string>();
                elem.name = "element";
                elem.descr = "test element";
                elem.timeStamp = DateTime.Now;
                elem.children.AddRange(new List<int> { 1, 2, 3 });
                elem.payload = "elem's payload";
                elem.showElement();
                db.insert(i, elem);
            }
            db.showDB();
            WriteLine();
            Schedular td = new Schedular(db);
            td.schedular.Enabled = true;
            Console.ReadKey();
            Console.Write("\n\n");
        }
    }
#endif
}