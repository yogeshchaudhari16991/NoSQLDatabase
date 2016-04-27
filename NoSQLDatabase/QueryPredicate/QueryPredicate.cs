//////////////////////////////////////////////////////////////////////////////
// QueryPredicate.cs - Define element for noSQL database                         //
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
 * This package includes methods which define query by using lambda functions
 * and pass these lambda functions to QueryEngine for making queries on DBEngie<>
 * 
 */
/*
 * Maintenance:
 * ------------
 * Required Files: QueryPredicate.cs, DBElement.cs, DBEngine.cs, DIsplay.cs, IQuery.cs, QueryEngine.cs, UtilityExtensions.cs
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
using System.Linq;
using static System.Console;

namespace Project2Starter
{
    public class QueryPredicate
    {
        /* Defining a query using lambda function to search specific key 
        */
        public void key_value_search(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe )
        {
            "Query for value with specified key (key = 2):".title();
            WriteLine();
            int key_to_search = 2;
            Func<int, string, bool> keyValueSearch = (int key, string search) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                else
                {
                    if (key == int.Parse(search))
                    {
                        DBElement<int, string> ele = new DBElement<int, string>();
                        db.getValue(key, out ele);
                        return true;
                    }
                    else { return false; }
                }
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQuery(keyValueSearch, key_to_search.ToString(), out i_query);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("key : {0}", key);
                temp.showElement();
                WriteLine();
            }
        }

        /* Defining a query using lambda function to search children of specific element 
        */
        public void key_children_search(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe)
        {
            int specific_key = 2;
            "Query for children of specified key (key = 2):".title();
            WriteLine();
            Func<int, string, bool> childrenQuery = (int key, string search) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                if (key == int.Parse(search))
                {
                    DBElement<int, string> ele = new DBElement<int, string>();
                    db.getValue(key, out ele);
                    return true;
                }
                else return false;
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQuery(childrenQuery, specific_key.ToString(), out i_query);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("children of element with key {0} :", key);
                WriteLine();
                if (temp.children != null)
                {
                    int i = 0;
                    foreach (int child in temp.children)
                    {
                        WriteLine("Children {0}", i++);
                        DBElement<int, string> temp_child = new DBElement<int, string>();
                        if (db.Keys().Contains(child))
                        {
                            db.getValue(child, out temp_child);
                            WriteLine("key : {0}", child);
                            temp_child.showElement();
                            WriteLine();
                        }
                        else
                        {
                            WriteLine("no value with key {0} is present in database", child);
                            WriteLine();
                        }
                    }
                }
            }
        }

        /* Defining a query using lambda function to search specific key matchin a pattern 
        */
        public void pattern_matching(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe)
        {
            string pattern = "123";
            "Query for keys matching with specified pattern (pattern = 123):".title();
            WriteLine();
            Func<int, string, bool> keysMatchingPattern = (int key, string search) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                else
                {
                    if (key.ToString().Contains(search))
                    {
                        DBElement<int, string> ele = new DBElement<int, string>();
                        db.getValue(key, out ele);
                        return true;
                    }
                    else return false;
                }
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQuery(keysMatchingPattern, pattern, out i_query);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("key : {0}", key);
                temp.showElement();
                WriteLine();
            }
        }
        /* Defining a query using lambda function to search specific key matching default pattern
        */
        public void default_pattern_matching(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe)
        {
            string pattern = "";
            "Query for keys matching with specified pattern (pattern = none  -> default case):".title();
            WriteLine();
            Func<int, string, bool> keysMatchingPattern = (int key, string search) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                else
                {
                    if (key.ToString().Contains(search))
                    {
                        DBElement<int, string> ele = new DBElement<int, string>();
                        db.getValue(key, out ele);
                        return true;
                    }
                    else return false;
                }
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQuery(keysMatchingPattern, pattern, out i_query);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("key : {0}", key);
                temp.showElement();
                WriteLine();
            }

        }
        /* Defining a query using lambda function to search specific string in metadata 
        */
        public void metadata_string(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe)
        {
            string metadata_str = "ele";
            "Query for specified string in metadata: String = 'ele' ".title();
            WriteLine();
            Func<int, string, bool> stringMetadata = (int key, string search) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                else
                {
                    DBElement<int, string> ele = new DBElement<int, string>();
                    db.getValue(key, out ele);
                    if (ele.name.Contains(search) || ele.descr.Contains(search))
                        return true;
                    else return false;
                }
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQuery(stringMetadata, metadata_str, out i_query);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("key : {0}", key);
                temp.showElement();
                WriteLine();
            }
        }
        /* Defining a query using lambda function to search specific elements belonging in specific  
        *  time-interval
        */ 
        public void default_date_time_specific(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe)
        {
            DateTime start1 = new DateTime(2015, 10, 4);
            "Query for keys with specified date time interval: start=10/4/2015 end=not specified".title();
            WriteLine();
            Func<int, DateTime, DateTime, bool> DefaultTimeDateQuery = (int key, DateTime query_start, DateTime query_end) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                else
                {
                    DBElement<int, string> ele = new DBElement<int, string>();
                    db.getValue(key, out ele);
                    int start_result = DateTime.Compare(query_start, ele.timeStamp);
                    int end_result = DateTime.Compare(query_end, ele.timeStamp);
                    if ((start_result <= 0) && (end_result >= 0))
                    {
                        return true;
                    }
                    else return false;
                }
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQueryDate(DefaultTimeDateQuery, start1, out i_query);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("key : {0}", key);
                temp.showElement();
                WriteLine();
            }
        }

        /* Defining a query using lambda function to search specific elements belonging in specific  
        *  time-interval with end of time interval equal to present
        */
        public void date_time_specific(DBEngine<int, DBElement<int, string>> db, IQuery<int, DBElement<int, string>> i_query, QueryEngine<int, DBElement<int, string>> qe)
        {
            DateTime start = new DateTime(2015, 10, 4);
            DateTime end = new DateTime(2015, 10, 5);
            "Query for keys with specified date time interval: start=10/4/2015 end=10/5/2015".title();
            WriteLine();
            Func<int, DateTime, DateTime, bool> TimeDateQuery = (int key, DateTime query_start, DateTime query_end) => //lambda function
            {
                if (!db.Keys().Contains(key))
                    return false;
                else
                {
                    DBElement<int, string> ele = new DBElement<int, string>();
                    db.getValue(key, out ele);
                    int start_result = DateTime.Compare(query_start, ele.timeStamp);
                    int end_result = DateTime.Compare(query_end, ele.timeStamp);
                    if ((start_result <= 0) && (end_result >= 0))
                    {
                        return true;
                    }
                    else return false;
                }
            };
            // pass query to query engine and call simpleQuery to make query on DBEngine
            qe.simpleQueryDate(TimeDateQuery, start, out i_query, end);
            WriteLine();
            foreach (var key in i_query.Keys())
            {
                DBElement<int, string> temp = new DBElement<int, string>();
                i_query.getValue(key, out temp);
                WriteLine("key : {0}", key);
                temp.showElement();
                WriteLine();
            }
        }
    }

#if(TEST_QUERYPREDICATE)
    class Test_QueryPredicate
    {
        static void Main(string[] args)
        {
            DBEngine<int, DBElement<int, string>> db = new DBEngine<int, DBElement<int, string>>();
            for (int i = 0; i < 3; i++)
            {
                DBElement<int, string> elem = new DBElement<int, string>();
                elem.name = "element";
                elem.descr = "test element";
                elem.timeStamp = new DateTime(2015, 10, (2 + i));
                elem.children.AddRange(new List<int> { 1, 2, 3 });
                elem.payload = "elem's payload";
                elem.showElement();
                WriteLine();
                db.insert(12345 + i, elem);
            }
            for (int i = 0; i < 3; i++)
            {
                DBElement<int, string> elem = new DBElement<int, string>();
                elem.name = "db data";
                elem.descr = "db data description";
                elem.timeStamp = DateTime.Now;
                elem.children.AddRange(new List<int> { 12345, 12346, 12347 });
                elem.payload = "elem's payload";
                elem.showElement();
                WriteLine();
                db.insert(i+1, elem);
            }

            IQuery<int, DBElement<int, string>> i_query = new DBEngine<int, DBElement<int, string>>();
            QueryEngine<int, DBElement<int, string>> qe = new QueryEngine<int, DBElement<int, string>>(db);
            //<---- creating a query predicate object and calling each query on given test database --->
            QueryPredicate qp = new QueryPredicate();
            qp.key_value_search(db, i_query, qe);
            WriteLine();
            qp.key_children_search(db, i_query, qe);
            WriteLine();
            qp.pattern_matching(db, i_query, qe);
            WriteLine();
            qp.default_pattern_matching(db, i_query, qe);
            WriteLine();
            qp.metadata_string(db, i_query, qe);
            WriteLine();
            qp.date_time_specific(db, i_query, qe);
            WriteLine();
            qp.default_date_time_specific(db, i_query, qe);
            WriteLine();
        }
    }
#endif
}