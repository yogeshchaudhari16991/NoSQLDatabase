//////////////////////////////////////////////////////////////////////////////
// ItemFactory.cs - Define element for noSQL database                         //
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
 * ItemFactory provides a method to add metadata<Key> and value instance(payload)<Data> 
 * to DBElement<key, Data> instance
 *
 */
/*
 * Maintenance:
 * ------------
 * Required Files: ItemFactory.cs, DBElement.cs, Display.cs, UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.0 : 7 Oct 15
 * - first release
 *
 */


using System;
using System.Collections.Generic;
using static System.Console;

namespace Project2Starter
{
    public static class ItemFactory
    {
        public static void addElementData<Key, Data>(this DBElement<Key, Data> element, string name, string descr, DateTime time, List<Key> key_List, Data payload)
        {
            element.name = name;
            element.descr = descr;
            element.timeStamp = time;
            element.children.AddRange(key_List);
            element.payload = payload;
        }
    }


#if(TEST_ITEMFACTORY)

    class TestItemFactory
    {
        static void Main(string[] args)
        {
            "Testing Item Factory package".title();
            "Adding data to element with payload as string".title();
            DBElement<int, string> test_element = new DBElement<int, string>();
            test_element.addElementData("element for test", "element created to test addElementData()", DateTime.Now, new List<int> { 1,2,3,4}, "test_element payload");
            test_element.showElement();
            WriteLine();
            "Adding data to element with payload as list of string".title();
            DBElement<string, List<string>> test_enum_element = new DBElement<string, List<string>>();
            test_enum_element.addElementData("element for test", "element created to test addElementData()", DateTime.Now, new List<string> { "1", "two", "3", "four" }, new List<string> { "test_element's payload1", "test_element's payload2", "test_element's payload3" });
            test_enum_element.showEnumerableElement();
            WriteLine();
        }
    }
#endif
}
