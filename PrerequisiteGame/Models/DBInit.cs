using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.IO;
using System.Reflection;
using System.Text;

namespace PrerequisiteGame.Models
{
    //we will create the database always to demonstrate the text parsing.
    public class DBInit : System.Data.Entity.DropCreateDatabaseAlways<ClassContext>
    {
        protected override void Seed(ClassContext Context)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("./Classes.txt");
            String line;
            bool validLine = false;
            bool firstOfSet = true;
            string comparitiveLine = "View course details";
            string courseTitle;
            string courseNumber;
            string courseDescription;
            List<string> coursePrereqs;
            while ((line = file.ReadLine())!= null) //read each line.
            {
                for(int i = 0; i < line.Length && i < comparitiveLine.Length; i++) //some lines are junk, they start with "View course details MyPlan"
                {
                    if(line[i] != comparitiveLine[i])
                    {
                        validLine = true;
                        break;
                    }
                }
                if(validLine && firstOfSet) //first line of the pair for classes
                {

                    coursePrereqs = new List<String>();
                }
                validLine = false;
            }


            base.Seed(Context);
        }
        /* All this commented code was the webscarpper, no longer need it.
           theOutput = File.CreateText("OutputFIle.txt"); //text document to spit out to
           var classes = new List<ClassOffering>();
           StringBuilder parser = new StringBuilder();
           string core = "https://www.washington.edu/students/crscatt/";
           string[] links = System.IO.File.ReadAllLines(@"../UnparsedLinks.txt"); //read each link
           string[] titles = new string[links.Length]; //one of the parse arrays of data
           HtmlWeb web = new HtmlWeb();
           HtmlDocument document = new HtmlDocument();
           HtmlNode[] nodes;
           for (int i = 0; i < links.Length; i++)
           {
               //Get line, then extract all info form the line of HTML.
               parser.Append(links[i]);
               parser.Replace("<li>", "");
               parser.Replace("<a href=\"", "");
               parser.Replace("</a>", "");
               parser.Replace("</li>", "");
               parser.Replace("\">", " ").ToString(); //returns the replaced string
               string stringHolder;
               bool foundTarget = false;
               int counter = 0;
               stringHolder = parser.ToString();
               while (!foundTarget)
               {
                   counter++;
                   if (stringHolder[counter] == ' ') //found the space, we know how long the text is.
                       foundTarget = true;
               }
               parser.Length = counter; //chop off the rest of the text.
               links[i] = parser.ToString(); //send link to the array
               parser.Clear(); //clear the parser
               parser.Append(stringHolder); //append old file
               parser.Replace(titles[i]+ " ", ""); //remove link and get only the title
               titles[i] = parser.ToString(); //we now have the titles and the type code EXAMPLE Computer Science & Systems (T CSS) 
           }
           parser.Clear();
           for(int i =0; i < links.Length; i++)
           {
               parser.Append(core); //append core file apth
               parser.Append(links[i]); //append extension file path.
               document = web.Load(parser.ToString());

               parser.Clear();//reset for next cycle
           }
        private List<Classes> GetClasses(string Path)
        {
            List<Classes> ClassList = new List<Classes>();

            return ClassList;
        }
        private class Classes
        {
            public int CID { get; set; } //Course Number
            public string CourseCode { get; set; } //Example T ACCT
            public string CourseName { get; set; } //example FInancial Accoutning II:gvwhghw
            public List<String> CourseCodePrereqs { get; set; } //list of the TACCT210, etc.
            public int credits { get; set; } //credit the class is worth
        }
        */
    }
}