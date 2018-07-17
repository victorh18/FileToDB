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
            string file = "";
            string tableName = "";
            bool generateCreate = false;

            if (args.Length == 0)
            {
                Console.WriteLine("Incorrect use of the program! \nCorrect usage: FileToDB.exe <file> <opt: tableName> <opt: generateCreateScript>");
                return;
            }
            if (args.Length > 0)
            {
                file = args[0];
                tableName = Path.GetFileNameWithoutExtension(file);
                
            }
            if(args.Length > 1)
            {
                tableName = args[1];
            }
            if(args.Length > 2)
            {
                generateCreate = Boolean.Parse(args[2]);
            }

            FileToDB lol = new FileToDB(file, tableName);
            lol.createTableScript = generateCreate;
            lol.createScript();
            Console.WriteLine("Script generated! \nPress any key to exit the program...");
            Console.ReadKey();
        }
    }

    public enum SQLType
    {
        Varchar = 1,
        Numeric = 2,
        Decimal = 3,
        DateTime = 4

    }

    //Class that contains program logic
    class FileToDB
    {
        public string fileName { get; set; }
        private List<Field> fields { get; set; }
        public string tableName { get; set; }
        public int recordSize { get; set; }
        public bool createTableScript { get; set; }

        private struct Field
        {
            public string name;
            public int initialPosition;
            //stands for length, to avoid confusion with reserved keyword
            public int len;
            //Stands for type, to avoid confusion
            public SQLType typ;

            public Field(string _name, int _initialPosition, int _len)
            {
                name = _name;
                initialPosition = _initialPosition;
                len = _len;
                typ = SQLType.Varchar;
            }
        }

        /// <summary>
        /// Consturctor lol
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_tableName"></param>
        public FileToDB(string _fileName, string _tableName = "lol")
        {
            this.fileName = _fileName;
            this.tableName = _tableName;

        }

        //This method return the definition of fields given the heading of the file
        private void defineFields(string fileName)
        {
            List<Field> _return = new List<Field>();
            int iniP = 0;
            int len = 0;
            string strLine = "";
            strLine = readLine(fileName, 2);
            this.recordSize = strLine.Length;
            do
            {
                Field field = new Field();
                field.initialPosition = iniP;
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

           
            this.fields = _return;

            return;
        }

        //This method return the requested line of the requested file
        private string readLine(string fileName, int lineNumber)
        {
            string strLine = "";
            int i = lineNumber - 1;
            strLine = File.ReadLines(fileName).Skip(i).Take(1).First();
            return strLine;
        } 

        //This method takes a line and separates its content in the correspondant fields
        private List<String> separateFields(List<Field> fields, string strLine)
        {
            if (validateLine(strLine))
            {
                List<string> _return = new List<string>();
                foreach (Field _field in fields)
                {
                    _return.Add(strLine.Substring(_field.initialPosition, _field.len).Trim());
                }

                return _return;
            }

            return null;
            
        }

        //This method creates the INSERT statement
        private string createInsert(List<Field> fields, List<string> detalle)
        {
            string _return = "";
            int index = 0;
            _return = "INSERT INTO " + this.tableName + " (";
            foreach (Field _field in fields)
            {
                _return += _field.name + ", ";
            }

            _return = _return.Substring(0, _return.Length - 2) + ")";
            _return += Environment.NewLine + "VALUES(";

            foreach (string _detalle in detalle)
            {
                if(_detalle == "NULL")
                {
                    _return += _detalle + ", ";
                }
                else
                {
                    _return += quote(_detalle) + ", ";
                }
                
            }

            _return = _return.Substring(0, _return.Length - 2) + ")";

            return _return;

        }

        public void createScript()
        {
            

            //First we define the fields
            this.defineFields(fileName);
            //We create the file where we're putting the script
            List<string> lines = new List<string>();

            //If the user specifies the creation of the table as well...
            if (createTableScript)
            {
                defineFieldTypes();
                lines.Add(createTable());
            }

            for (int i = 3; i < File.ReadLines(fileName).Count(); i++)
            {
                List<string> ls = separateFields(this.fields, readLine(this.fileName, i));
                if (ls != null)
                {
                    lines.Add(createInsert(this.fields, ls));
                }
                
            }

            

            File.WriteAllLines(Path.GetFileNameWithoutExtension(this.fileName) + ".sql", lines);
            Console.WriteLine(":D");
            
        }

        private string quote(string text)
        {
            return "'" + text + "'";
        }

        //This method determines whether a column is valid for decomposing into fields
        private bool validateLine(string strLine)
        {
            //It must be the same lenght as the fields extracted
            if (
                !string.IsNullOrEmpty(strLine) && (
                !strLine.Contains("rows affected") &&
                !strLine.Contains("row affected")
                    )
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //This method determines the most compatible SQL data type for the field
        private SQLType defineType(List<string> values, Field _field)
        {
            bool blDate = true;
            bool blDecimal = true;
            bool blNumeric = true;
            
            foreach(string value in values)
            {
                blDate = DateTime.TryParse(value, out DateTime d) ? blDate : false;
                blDecimal = validateDecimalType(value) ? blDecimal : false;
                blNumeric = blDecimal ? blNumeric : (Int32.TryParse(value, out int i) ? blNumeric : false);
            }

            if (blDate)
            {
                _field.typ = SQLType.Varchar;
                return SQLType.DateTime;
            } else if (blDecimal)
            {
                _field.typ = SQLType.Decimal;
                return SQLType.Decimal;

            } else if (blNumeric)
            {
                _field.typ = SQLType.Numeric;
                return SQLType.Numeric;
            }else
            {
                _field.typ = SQLType.Varchar;
                return SQLType.Varchar;
            }

        }

        private bool validateDecimalType(string value)
        {
            if (value.Contains("."))
            {
                return double.TryParse(value, out double i);
            }
            else
            {
                return false;
            }
        }

        private void defineFieldTypes()
        {
            //Creating a new list because cannot modify the ones iterating
            List<Field> _fields = new List<Field>();
            foreach (Field field in this.fields)
            {
                List<string> values = new List<string>();

                for (int i = 3; i < File.ReadLines(this.fileName).Count(); i++)
                {
                    string strLine = readLine(this.fileName, i);
                    if (validateLine(strLine))
                    {
                        values.Add(strLine.Substring(field.initialPosition, field.len));
                    }
                    
                }
                Field _f = field;
                _f.typ = defineType(values, field);
                _fields.Add(_f);
                //defineType(values, field);
            }
            this.fields = _fields;
        }

        private string createTable()
        {
            string _strReturn = "";
            _strReturn = "CREATE TABLE " + this.tableName + "(\n";
            foreach (Field _field in this.fields)
            {
                _strReturn += "\t" + _field.name + " " + SQLTypeDefinition(_field) + ", \n";
            }

            _strReturn = _strReturn.Substring(0, _strReturn.Length - 3) + "\n)";
                
            return _strReturn;
        }

        //This method determines how the SQL type should be specified
        private string SQLTypeDefinition(Field _field)
        {
            switch (_field.typ)
            {
                case SQLType.Varchar:
                    return "VARCHAR(MAX)";    
                case SQLType.Numeric:
                    return "NUMERIC";
                case SQLType.Decimal:
                    return "DECIMAL(14, 2)";
                default:
                    return "DATETIME";
            }

        }

        public void testing()
        {
            ////readLine
            //Console.WriteLine(readLine(this.fileName, 1));

            ////defineFields
            //this.defineFields(fileName);
            //foreach (Field _field in this.fields)
            //{
            //    Console.WriteLine(_field.name + "; Initial Postion: {0}, Length: {1}", _field.initialPosition, _field.len);
            //}

            ////separateFields
            //this.defineFields(fileName);
            //string l = "";
            //l = readLine(fileName, 3);

            //foreach (string s in this.separateFields(this.fields, l))
            //{
            //    Console.WriteLine(s);
            //} 

            ////createInsert
            //this.defineFields(fileName);
            //string l = "";
            //l = readLine(fileName, 3);
            //Console.WriteLine(createInsert(fields, separateFields(fields, l)));

            ////createScript
            //this.defineFields(fileName);
            //foreach (string s in createScript())
            //{
            //    Console.WriteLine(s);
            //}

            ////defineFieldTypes
            //this.defineFields(fileName);
            //this.defineFieldTypes();
            //foreach(Field f in this.fields)
            //{

            //    Console.WriteLine(f.typ + ", {0}", SQLTypeDefinition(f));
            //}

            //createTable
            this.defineFields(fileName);
            this.defineFieldTypes();
            Console.WriteLine(createTable());

        }
    }

}
