using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ConsoleApp1
{
    class Program
    {
        private const String filename = "schedule.xml";
        private const String stylesheet = "schedule.xsl";
        private const String output = "schedule.txt";
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            XmlElement xRoot = xDoc.DocumentElement;

            Console.WriteLine("1. Все занятия на данной неделе");
            GetAllLessons(xRoot);

            Console.WriteLine("2. Все аудитории, в которых проходят занятия");
            GetAllAudiences(xRoot);

            Console.WriteLine("3. Все практические занятия на неделе");
            GetAllPracticalLessons(xRoot);

            Console.WriteLine("4. Все лекции, проводимые в указанной аудитории");
            GetAllLectureByAudience(xRoot, 501);

            Console.WriteLine("5. Преподаватели, проводящие практики в указанной аудитории");
            GetTeachersByAudience(xRoot, 509);

            Console.WriteLine("6. Последние занятие для каждого дня недели");
            GetLastLessonForWeekOfDay(xRoot);

            Console.WriteLine("7. Общее количество занятий за всю неделю");
            GetNummberOfLessonsForWeek(xRoot);


            XslTransform xslt = new XslTransform();
            xslt.Load(stylesheet);
            XPathDocument xpathdocument = new XPathDocument(filename);
            FileStream fstream = new FileStream(output, FileMode.OpenOrCreate);
            xslt.Transform(xpathdocument, null, fstream, null);

            Console.ReadKey();
        }

        static void GetAllLessons(XmlElement xRoot)
        {
            XmlNodeList childnodes = xRoot.SelectNodes("//Lesson");
            foreach (XmlNode lesson in childnodes)
                Console.WriteLine("Lesson: " + lesson.SelectSingleNode("Name").InnerText);
        }

        static void GetAllAudiences(XmlElement xRoot)
        {
            XmlNodeList childnodes = xRoot.SelectNodes("//Lesson");
            foreach (XmlNode lesson in childnodes)
                Console.WriteLine("Audience: " + lesson.SelectSingleNode("Audience").InnerText);
        }

        static void GetAllPracticalLessons(XmlElement xRoot)
        {
            XmlNodeList childnodes = xRoot.SelectNodes("//Lesson");
            foreach (XmlNode lesson in childnodes)
                if (lesson.SelectSingleNode("Type").InnerText == "Practice")
                    Console.WriteLine("Practical lesson: " + lesson.SelectSingleNode("Name").InnerText);
        }

        static void GetAllLectureByAudience(XmlElement xRoot, int audience)
        {
            XmlNodeList childnodes = xRoot.SelectNodes("//Lesson");
            foreach (XmlNode lesson in childnodes)
                if (lesson.SelectSingleNode("Type").InnerText == "Lecture" && Convert.ToInt32(lesson.SelectSingleNode("Audience").InnerText) == audience)
                    Console.WriteLine("Lecture lesson: " + lesson.SelectSingleNode("Name").InnerText);
        }

        static void GetTeachersByAudience(XmlElement xRoot, int audience)
        {
            XmlNodeList childNodes = xRoot.SelectNodes("//Lesson");
            foreach (XmlNode lesson in childNodes)
                if (lesson.SelectSingleNode("Type").InnerText == "Practice" && Convert.ToInt32(lesson.SelectSingleNode("Audience").InnerText) == audience)
                    Console.WriteLine("Teacher: " + lesson.SelectSingleNode("Teacher").InnerText);
        }

        static void GetLastLessonForWeekOfDay(XmlElement xRoot)
        {
            XmlNodeList childNodes = xRoot.SelectNodes("//Group/Lesson[last()]/Name");
            foreach (XmlNode child in childNodes)
                Console.WriteLine("Lesson: " + child.InnerText);
        }

        static void GetNummberOfLessonsForWeek(XmlElement xRoot)
        {
            Console.WriteLine("Count: " + xRoot.SelectNodes("//Lesson").Count);
        }
    }
}
