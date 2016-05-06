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
    public class DBInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<ClassContext>
    {
        protected override void Seed(ClassContext Context)
        {
            var classes = new List<ClassModel>();
            StringBuilder temp = new StringBuilder();
            StringBuilder parser = new StringBuilder();
            string core = "https://www.washington.edu/students/crscatt/";
            string[] links = System.IO.File.ReadAllLines(@"../UnparsedLinks.txt"); //read each link
            string[] titles = new string[links.Length]; //one of the parse arrays of data
            //string[] code
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
                Boolean foundTarget = false;
                int counter = 0;
                stringHolder = parser.ToString();
                while (!foundTarget)
                {
                    counter++;
                    if (stringHolder[counter] == ' ') //found the space, we know how long the text is.
                        foundTarget = true;
                }
                parser.Length = counter; //chop off the rest of the text.
                titles[i] = parser.ToString();
                parser.Clear();
                parser.Append(stringHolder);
                parser.Replace(titles[i]+ " ", ""); //remove title from 
            }
            for(int i =0; i < links.Length; i++)
            {
                temp.Append(core); //append core file apth
                temp.Append(links[i]); //append extension file path.
                titles = parseOutClasses(temp.ToString(), titles); //call function to grab all the information on the page.
                for(int j = 0; i < titles.Length; i++) //for loop to parse all the chunks of data. and store into text file and DB.
                {

                }
                temp.Clear();//reset for next cycle
            }
            base.Seed(Context);
        }

        private string[] parseOutClasses(string toString, string[] titles)
        {
            throw new NotImplementedException();

        }
    }
}