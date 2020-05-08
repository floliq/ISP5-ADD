using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
	enum Faculties
	{
		Fre = 0,
		Fkp,
		Fksis,
		Fitu,
		Ief,
		Fik,
		Fino
	};

	class Person
	{
		public static int Id = 0;

		protected struct Information
		{
			static string _Surname = " ";
			static string _Name = " ";
			static string _Fathername;

			static internal string Surname
			{
				get => Surname;
				set

				{
					if (Regex.Match(value, "[а-яА-Я]").Success)
					{
						Surname = value;
					}
				}
			}

			static internal string Name
			{
				get => Name;
				set

				{
					if (Regex.Match(value, "[а-яА-Я]").Success)
					{
						Name = value;
					}
				}
			}

			static internal string Fathername
			{
				get => Fathername;
				set

				{
					if (Regex.Match(value, "[а-яА-Я]").Success)
					{
						Fathername = value;
					}
				}
			}
		}


		public Person(string surname, string name, string fathername) =>
			(Information.Surname, Information.Name, Information.Fathername,Id)
			= (surname, name, fathername,++Id);

		// ИНДЕКСАТОР

		public string this[string propName]
		{
			get
			{
				switch (propName)
				{
					case "surname": return Information.Surname;
					case "name": return Information.Name;
					default: return "Doesn't FIND";
				}
			}
			set
			{
				switch (propName)
				{
					case "surname":
						Information.Surname = value;
						break;
					case "name":
						Information.Name = value;
						break;
					default:
						break;
				}
			}
		}
		public virtual string Print() => $"{Information.Surname} {Information.Name} {Information.Fathername}";
	}

	class Student : Person
	{
		public string NameUniversity { get; set; }
		public Student(string surname, string name, string fathername, string nameUniversity) : base(surname, name, fathername)
		{
			NameUniversity = nameUniversity;
		}
		public override string Print() => $"{Information.Surname} {Information.Name} {Information.Fathername} {NameUniversity}";
	}

	class Speciality : Person
	{
		public string Faculty { get; set; }
		public string Group { get; set; }

		public Speciality(string surname, string name, string fathername, int faculty, string group) :
			base(surname, name, fathername)
		{
			this.Faculty = Enum.GetName(typeof(Faculties), faculty);
			this.Group = group;
		}

		public override string Print() => $"{Information.Surname} {Information.Name} {Information.Fathername} {Faculty} {Group}";

		public void AddToPrint(params string[] args)
		{
			Console.Write(Print());
			foreach (var x in args)
			{
				Console.Write(" "+x);
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Person test = new Person("Иванов", "Иван", "Иванович");
			Console.WriteLine(test.Print());		
			test = new Student("Бойко", "Владислав", "Богданович","БГУИР");
			Console.WriteLine(test.Print());
			test = new Speciality("Бойко", "Владислав", "Богданович", 1, "944691");
			Console.WriteLine(test.Print());
			Console.ReadKey();
		}
	}
}
