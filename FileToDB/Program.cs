using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------    DEGUGGIN MODE   ---------------------");
            Console.WriteLine("Testing the output of: readLine");
            //FileToDB lol = new FileToDB(args[0]);
            FileToDB lol = new FileToDB(@"C:\Users\vdelarosa\Documents\Visual Studio 2017\Projects\FileToDB\FileToDB\bin\Debug\pruebaCom.txt");
            lol.testing();
            Console.WriteLine(":v");
            Console.ReadKey();
        }
    } 

    //Class that contains program logic
    class FileToDB
    {
        public string fileName { get; set; }
        private List<Field> fields { get; set; }
        public string tableName { get; set; }

        public struct Field
        {
            public string name;
            public int initialPosition;
            //stands for length, to avoid confusion with reserved keyword
            public int len;
            //Stands for type, to avoid confusion
            public int typ;

            public Field(string _name, int _initialPosition, int _len, int _typ)
            {
                name = _name;
                initialPosition = _initialPosition;
                len = _len;
                typ = _typ;
            }
        }

        public FileToDB(string _fileName, string _tableName = "")
        {
            this.fileName = _fileName;
            this.tableName = _tableName;

        }

        //This method return the definition of fields given the heading of the file
        private List<Field> defineFields(string fileName)
        {
            List<Field> _return = new List<Field>();
            int iniP = 0;
            int len = 0;
            string strLine = "";
            strLine = readLine(fileName, 2);
            //while (strLine.IndexOf(" ") != 0)
            do
            {
                Field field = new Field();
                field.initialPosition = iniP;
                //field.len = strLine.IndexOf(" ") == -1 ? strLine.Length : strLine.IndexOf(" ");
                //field.name = readLine(fileName, 1).Substring(field.initialPosition, field.len).Trim();
                //strLine = strLine.Substring(field.len + 1);
                if (strLine.IndexOf(" ") == -1)
                {
                    field.len = strLine.Length;
                    strLine = "";
                }
                else
                {
                    field.len = strLine.IndexOf(" ");
                    strLine = strLine.Substring(field.len + 1);
                }
                field.name = readLine(fileName, 1).Substring(field.initialPosition, field.len).Trim();

                iniP = field.initialPosition + field.len + 1;

                _return.Add(field);
            } while (strLine.IndexOf(" ") != -1);
            return _return;
        }

        //This method return the requested line of the requested file
        private string readLine(string fileName, int lineNumber)
        {
            string strLine = "";
            int i = lineNumber - 1;
            strLine = File.ReadLines(fileName).Skip(i).Take(1).First();
            return strLine;
        } 

        public void testing()
        {
            ////readLine
            //Console.WriteLine(readLine(this.fileName, 1));

            //defineFields
            foreach (Field _field in defineFields(this.fileName))
            {
                Console.WriteLine(_field.name + "; Initial Postion: {0}, Length: {1}", _field.initialPosition, _field.len);
            }
        }
    }

}
