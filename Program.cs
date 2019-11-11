using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SpanAndOthers
{
    public class Program
    {
        public static void Main(string[] args)
        {


            #region Tuples

            // Tuples are commonly use for example
            // 1_ to return multiple values from methods
            // 2_ to pass multiple values through one parameter

            // One way
            var tuple = Tuple.Create(12, "ASD", 13, 13);


            // Or another
            var tuple2 = Tuple.Create<int, int, string>(12, 12, "12");

            // one more way
            tuple2 = new Tuple<int, int, string>(1, 1, "");


            // Array of tuples
            Tuple<string, int>[] tuples =
            {
                new Tuple<string,int>("Hey",1),
                new Tuple<string,int>("Teacher",2)
            };

            #endregion


            #region ValueTuples

            // They differ from the Tuple classes
            // They are structure than classes
            // DataMembers (Item1, Item2 etc...) are fields rather than properties

            // ValutTuple has no element. Only Create method
            var valueTuple = ValueTuple.Create<int, int, string>(12, 12, "S");
            valueTuple.Item2._();
            valueTuple.Item1._();

            // and so on



            // ValueTuple comparing
            var v1 = ValueTuple.Create<int, int, string>(1, 1, "a");
            var v2 = ValueTuple.Create<int, int, string>(1, 1, "b");

            v1.CompareTo(v2)._(); // -1
            v2.Item3 = "a";
            v1.CompareTo(v2)._(); // 0

            ((ITuple)v1).Length._(); // 3






            Console.Read();


            #endregion



            #region Unnamed tuples

            // Tuples has two major limitaions
            // Item1, Item2 has no semantic meaning
            // More performance concern beacause they are refference types

            var unnamedTuple = ("string", 14);
            unnamedTuple.Item1._(); // and so on... 

            // OR (string,string,int) person = 
            var person = (name: "Steve", surname: "Cornye", age: 14);
            (string, string, int) person2 = (name: "Steve", surname: "Corney", age: 14);
            person.name._();
            person.surname._();

            // variable in tuples
            string name = "Steve";
            int age = 14;

            var p1 = (s_name: name, s_age: age);

            // -------------------------------------

            string content = "The answare to everything";
            var p3 = (42, content);

            // ----------------------------------------------------

            // Tuples in methods

            var steve = GetUser(14);

            // method return a tuple

            static (int age, string name) GetUser(int id)
            {
                // a ton of logic
                var user = (age: 14, name: "Steve");
                return user;
            }

            // can return unnamed 
            static (int,int,string) Copmute(int id) { return ValueTuple.Create<int,int,string>(1,1,""); }


            #endregion


            #region Comparing ValueTuple

            Console.WriteLine("Value tuple comparing");

            var t1 = ValueTuple.Create<int, string>(1, "s");
            var t2 = ValueTuple.Create<int, string>(1, "a");

            (t1 == t2)._(); // false

            t1 = ValueTuple.Create<int, string>(1, "s");
            t2 = ValueTuple.Create<int, string>(1, "s");

            (t1 == t2)._(); // true

            #endregion

            #region IEnumerable of Struct types

            #endregion

            #region Getting List of TodoItems and returng Tuple of Id and name (Tiple as method return value)


            "IEnumerable returning Tuple"._();
            var todoItems = new List<ToDoItem>()
            {
                new ToDoItem{Id = Guid.NewGuid().ToString(), IsDone = true, Notes = "Some NOtes", Title = "On the dark side of the moon"},
                new ToDoItem{Id = Guid.NewGuid().ToString(), IsDone = true, Notes = "Some NOtes", Title = "For whom the beel calls"},
                new ToDoItem{Id = Guid.NewGuid().ToString(), IsDone = true, Notes = "Some NOtes", Title = "Hey teacher live that kid alone"},
                new ToDoItem{Id = Guid.NewGuid().ToString(), IsDone = true, Notes = "Some NOtes", Title = "Money, get away  "}
            };

            // local method 
            static IEnumerable<(string GuidId, string title )> GetTuple(IEnumerable<ToDoItem> items)
            {
                // a ton of logic
                return from item in items
                       select (Id: item.Id, age: item.Title);
            }

            GetTuple(todoItems).ToList().ForEach(x => $"{x.GuidId}: {x.title}"._());


            #endregion


            #region Deconstruction

            Console.WriteLine("- - - Deconstruction");

            (int someId, string someTitle) tupleEx = GetTupleVoid();

            tupleEx.someId._();
            tupleEx.someTitle._();

            // local methods

            static (int id, string title) GetTupleVoid()
            {
                return (id: 14, title: "For who, the bells calls");
            }



            /// ------------------------------
            /// Deconstruction
            /// ------------------------------

            (int id_, string content_) = GetTupleVoid();

            // OR

            var (MyId, MyTitle) = GetTupleVoid();


            (MyId is int).ToString(); // is true
            (MyTitle is  string).ToString(); // is true



            Console.ReadLine();
        }

        
        class ToDoItem
        {
            public string Id { get;set; }
            public bool IsDone { get; set; }
            public string Title { get; set; }
            public string Notes { get; set; }
        }
    }


    public static class Extension
    {
        public static void _(this object obj) => Console.WriteLine(obj);
    }

}
