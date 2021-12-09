﻿using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Entity
{
    public class Group
    {
        public Group(GroupName name, int maxStudentNumber)
        {
            CourseNumber = name.CourseNumber;
            GroupNumber = name.GroupNumber;
            MaxStudentNumber = maxStudentNumber;
            Students = new List<Student>();
        }

        public CourseNumber CourseNumber { get; }
        public string GroupNumber { get; }
        public List<Student> Students { get; }
        public int MaxStudentNumber { get; }

        public string FullName => $"M3{CourseNumber}{GroupNumber}";

        public Student AddStudent(Student student)
        {
            if (Students.Count >= MaxStudentNumber) throw new IsuException("max students exceeded");
            Students.Add(student);
            return student;
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
    }
}