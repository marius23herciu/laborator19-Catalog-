using Abp.Domain.Entities;
using laborator19_Catalog_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborator19_Catalog_
{
    public class DataLayer
    {
        private CatalogueDbContext ctx;
        public DataLayer(CatalogueDbContext context)
        {
            this.ctx = context;
        }

        public Subject AddSubject(string name)
        {
            var newSubject = new Subject
            {
                Name = name,
            };

            ctx.Add(newSubject);
            foreach (var student in ctx.Students)
            {
                student.Subjects.Add(newSubject);
            }
            ctx.SaveChanges();

            return newSubject;
        }
        public Mark AddMarkToStudent(int studentId, int subjectId, int value)
        {
            var student = ctx.Students.Where(s => s.Id == studentId).FirstOrDefault();

            var newMark = new Mark
            {
                Value = value,
                SubjectId = subjectId,
                DateTime = DateTime.Now,
            };
            student.Marks.Add(newMark);

            ctx.SaveChanges();

            return newMark;
        }
        public List<int> GetAllMarks(int id)
        {
            var student = ctx.Students.Include(m => m.Marks).Where(s => s.Id == id).FirstOrDefault();
            var marks = student.Marks.Select(v => v.Value).ToList();

            return marks;
        }
        public List<int> GetAllMarksForSpecificSubject(int studentId, int subjectId)
        {
            var student = ctx.Students.Include(m => m.Marks).Where(s => s.Id == studentId).FirstOrDefault();
           
            var subject = ctx.Subjects.Where(s => s.Id == subjectId).FirstOrDefault();
            
            var marks = student.Marks.Where(s => s.SubjectId == subjectId).Select(v => v.Value).ToList();

            return marks;
        }
        public List<double> GetAllAveragesForOneStudent(int studentId)
        {
            var student = ctx.Students.Include(s => s.Subjects).Include(m => m.Marks).Where(s => s.Id == studentId).FirstOrDefault();
            var marks = student.Marks.Select(v => v.Value).ToList();

            List<double> allAverages = new List<double>();

            var subjects = student.Subjects.ToList();
            
            double average = 0;
            double sum = 0;
            int counter = 0;
            foreach (var subject in subjects)
            {
                foreach (var mark in student.Marks)
                {
                    if (mark.SubjectId == subject.Id)
                    {
                        sum += mark.Value;
                        counter++;
                    }
                }
                average = sum / counter;
                allAverages.Add(average);

                average = 0;
                sum = 0;
                counter = 0;
            }

            return allAverages;
        }
        public List<double> GetAllAveragesInOrder(bool ascendingOrder)
        {
            var students = ctx.Students.Include(s => s.Subjects).Include(m => m.Marks).ToList();
            var subjects = ctx.Subjects.ToList();
            
            double average = 0;
            double sum = 0;
            int counter = 0;

            double sumOfAverages = 0;
            double finalAverage = 0;
            int counterOfAverages = 0;

            List<double> listOfAverages = new List<double>();

            foreach (var student in students)
            {
                foreach (var subject in subjects)
                {
                    foreach (var mark in student.Marks)
                    {
                        if (subject.Id == mark.SubjectId)
                        {
                            sum += mark.Value;
                            counter++;
                        }
                    }
                    if (sum > 0)
                    {
                        average = sum / counter;
                        sumOfAverages += average;
                        counterOfAverages++;
                    }
                    sum = 0;
                    counter = 0;
                    average = 0;
                }
                if (sumOfAverages > 0)
                {
                    finalAverage = sumOfAverages / counterOfAverages;
                }
                listOfAverages.Add(finalAverage);
                sumOfAverages = 0;
                finalAverage = 0;
                counterOfAverages = 0;
            }

            if (ascendingOrder == true)
            {
                listOfAverages.Sort();
            }
            else
            {
                List<double> temp = new List<double>();
                foreach (double d in listOfAverages.OrderByDescending(d => d))
                {
                    temp.Add(d);
                }
                listOfAverages = temp;
            }

            return listOfAverages;
        }
    }
}
