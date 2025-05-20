namespace StudentSystem
{
    class Student
    {
        public int id;
        public string name;
        public int age;
        public List<Course> courses;

        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].id == course.id)
                    return false;
            }
            courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            string info = $"ID: {id}, Name: {name}, Age: {age}, Courses: ";
            if (courses.Count == 0) 
                info += "None";
            else
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    info += courses[i].title;
                    if (i < courses.Count - 1) info += ", ";
                }
            }
            return info;
        }
    }

    class Instructor
    {
        public int id;
        public string name;
        public string specialization;

        public Instructor(int id, string name, string specialization)
        {
            this.id = id;
            this.name = name;
            this.specialization = specialization;
        }

        public string PrintDetails()
        {
            return $"ID: {id}, Name: {name}, Specialization: {specialization}";
        }
    }

    class Course
    {
        public int id;
        public string title;
        public Instructor instructor;

        public Course(int id, string title, Instructor instructor)
        {
            this.id = id;
            this.title = title;
            this.instructor = instructor;
        }

        public string PrintDetails()
        {
            return $"ID: {id}, Title: {title}, Instructor: {instructor.name}";
        }
    }

    class SchoolStudentManager
    {
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Instructor> instructors = new List<Instructor>();

        public bool AddStudent(Student s)
        {
            students.Add(s);
            return true;
        }

        public bool AddCourse(Course c)
        {
            courses.Add(c);
            return true;
        }

        public bool AddInstructor(Instructor i)
        {
            instructors.Add(i);
            return true;
        }

        public Student FindStudent(int id)
        {
            for (int i = 0; i < students.Count; i++)
                if (students[i].id == id)
                    return students[i];
            return null;
        }

        public bool UpdateStudent(int id, string name, int age)
        {
            Student s = FindStudent(id);
            if (s != null)
            {
                s.name = name;
                s.age = age;
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].id == id)
                {
                    students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Course FindCourse(int id)
        {
            for (int i = 0; i < courses.Count; i++)
                if (courses[i].id == id)
                    return courses[i];
            return null;
        }

        public Instructor FindInstructor(int id)
        {
            for (int i = 0; i < instructors.Count; i++)
                if (instructors[i].id == id)
                    return instructors[i];
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student s = FindStudent(studentId);
            Course c = FindCourse(courseId);
            if (s != null && c != null)
                return s.Enroll(c);
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SchoolStudentManager manager = new SchoolStudentManager();

            while (true)
            {
                Console.WriteLine("\n--- Student Management Menu ---");
                Console.WriteLine("1. Add a new Student");
                Console.WriteLine("2. View all Students");
                Console.WriteLine("3. Search for a Student by ID");
                Console.WriteLine("4. Update Student Information");
                Console.WriteLine("5. Delete a Student");
                Console.WriteLine("6. Add a new Course");
                Console.WriteLine("7. Add a new Instructor");
                Console.WriteLine("8. Enroll a Student in a Course");
                Console.WriteLine("9. View all Courses");
                Console.WriteLine("10. View all Instructors");
                Console.WriteLine("11. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter Student ID: ");
                    int id = Convert.ToInt32((Console.ReadLine()));
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32((Console.ReadLine()));
                    Console.Write("Student Added.");
                    manager.AddStudent(new Student(id, name, age));
                }
                else if (choice == "2")
                {
                    for (int i = 0; i < manager.students.Count; i++)
                        Console.WriteLine(manager.students[i].PrintDetails());
                }
                else if (choice == "3")
                {
                    Console.Write("Enter Student ID: ");
                    int id = Convert.ToInt32((Console.ReadLine()));
                    Student s = manager.FindStudent(id);
                    Console.WriteLine(s != null ? s.PrintDetails() : "Student not found.");
                }
                else if (choice == "4")
                {
                    Console.Write("Enter Student ID to update: ");
                    int id = Convert.ToInt32((Console.ReadLine()));
                    Console.Write("Enter new name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter new age: ");
                    int age = Convert.ToInt32((Console.ReadLine()));
                    Console.WriteLine(manager.UpdateStudent(id, name, age) ? "Updated." : "Student not found.");
                }
                else if (choice == "5")
                {
                    Console.Write("Enter Student ID to delete: ");
                    int id = Convert.ToInt32((Console.ReadLine()));
                    Console.WriteLine(manager.DeleteStudent(id) ? "Deleted." : "Student not found.");
                }
                else if (choice == "6")
                {
                    Console.Write("Enter Course ID: ");
                    int id = Convert.ToInt32((Console.ReadLine()));
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Instructor ID: ");
                    int instId = Convert.ToInt32((Console.ReadLine()));
                    Instructor inst = manager.FindInstructor(instId);
                    if (inst != null)
                        manager.AddCourse(new Course(id, title, inst));
                    else
                        Console.WriteLine("Instructor not found.");
                }
                else if (choice == "7")
                {
                    Console.Write("Enter Instructor ID: ");
                    int id = Convert.ToInt32((Console.ReadLine()));
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Specialization: ");
                    string spec = Console.ReadLine();
                    manager.AddInstructor(new Instructor(id, name, spec));
                }
                else if (choice == "8")
                {
                    Console.Write("Enter Student ID: ");
                    int sid = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Course ID: ");
                    int cid = Convert.ToInt32(Console.ReadLine());

                    if (manager.EnrollStudentInCourse(sid, cid))
                    {
                        Console.WriteLine("Enrolled.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to enroll.");
                    }

                }
                else if (choice == "9")
                {
                    for (int i = 0; i < manager.courses.Count; i++)
                        Console.WriteLine(manager.courses[i].PrintDetails());
                }
                else if (choice == "10")
                {
                    for (int i = 0; i < manager.instructors.Count; i++)
                        Console.WriteLine(manager.instructors[i].PrintDetails());
                }
                else if (choice == "11")
                {
                    Console.WriteLine("GoodBye..");
                    break;
                }
                else Console.WriteLine("Invalid choice.");
            }
        }
    }
}
