using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{//CRUD =>Create,Read,Update,Delete
    class Program
    {//migration
        static void Main(string[] args)
        {
            MyContext context = new MyContext();
            var data=context.Dorm.Include(a=>a.Students). ToList();

            Console.ReadKey();

        }

        private static void AddOneToMany(MyContext context)
        {
            var dorm = context.Dorm.Find(2);
            Student student = new Student()
            {
                Age = 19,
                Name = "smaneh",
                Dorm = dorm
            };
            context.Students.Add(student);
            context.SaveChanges();
        }

        private static void RemoveDemo(MyContext context)
        {
            context.Students.Remove(new Student() { StudentId = 4 });
            context.SaveChanges();
        }


        private static void Upadte2(MyContext context)
        {
            Student student = new Student()
            {
                StudentId = 4,
                Name = "nasim",
                Average = 19.9,
                Age = 25
            };
            context.Students.Update(student);
            context.SaveChanges();
        }

        private static void Update1(MyContext context)
        {
            Student student = context.Students.Find(2);
            student.Age = 18;
            student.Name = "saman";

            context.SaveChanges();
            Console.WriteLine("Done ");
        }


        /// <summary>
        /// Create by Fallah
        /// For Read ModelTypes
        /// </summary>
        /// <param name="context"></param>
        private static void ReadDemo(MyContext context)
        {
            List<Student> students = context.Students.ToList();

            List<Student> students1 = context.Students.Where(a => a.Age > 15).ToList();
            List<Student> students2 = context.Students.Where(a => a.Age > 15 && a.Average > 10)
                .ToList();

            List<Student> students3 = context.Students.OrderBy(a => a.Average).ToList();
            List<Student> students4 = context.Students.OrderByDescending(a => a.Average).ToList();

            List<Student> students5 = context.Students.Where(a => a.Age > 12)
                .OrderBy(a => a.Average).ToList();

            List<Student> students6 = context.Students.Take(3).ToList();
            List<Student> students7 = context.Students.Skip(2).Take(3).ToList();



            Student student8 = context.Students.First(a => a.Age > 10);
            //Student student9 = context.Students.First(a => a.Age > 110);
            Student student10 = context.Students.FirstOrDefault(a => a.Age > 110);

            //Student student11 = context.Students.Single(a => a.Age>12);
            //Student student12 = context.Students.SingleOrDefault(a => a.Age>12);

            Student student13 = context.Students.Find(2);
            Console.WriteLine(student13.Name + " " + student13.Age);
        }


        /// <summary>
        ///  Create by Fallah
        ///  For Insert Entity To Database
        /// </summary>
        /// <param name="context"></param>
        private static void AddDemo(MyContext context)
        {
            Student student = new Student()
            {
                Name = "shima",
                Average = 12.2,
                Age = 25
            };
            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}
