using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.IO;
using MetroFramework.Controls;
using MetroFramework;


namespace StudentsRecordsManagementSystem
{
    public class managementSys //---> Node
    {
        public string StdName { get; set; }
        public string Fname { get; set; }
        public string EnrollNo { get; set; }
        public string Gender { get; set; }
        public string Faculty { get; set; }
        public string Shift { get; set; }
        public string Class { get; set; }
        public string SeatNo { get; set; }
        public string StdAge { get; set; }
        public string Dept { get; set; }
        public string Section { get; set; }
        public string Semester { get; set; }
        public string Field { get; set; }
        public string Course1 { get; set; }
        public string Course2 { get; set; }
        public string Course3 { get; set; }
        public string Course4 { get; set; }
        public string Course5 { get; set; }
        public string CourseTitle1 { get; set; }
        public string CourseTitle2 { get; set; }
        public string CourseTitle3 { get; set; }
        public string CourseTitle4 { get; set; }
        public string CourseTitle5 { get; set; }
        public string MarksCourse1 { get; set; }
        public string MarksCourse2 { get; set; }
        public string MarksCourse3 { get; set; }
        public string MarksCourse4 { get; set; }
        public string MarksCourse5 { get; set; }
        public string Path { get; set; }
        public PictureBox StdImg { get; set; }
        public ManagementSystem ManagementForm;
        public managementSys Next;
        public managementSys Previous;

        //Node Constructor For Student Registration
        public managementSys(string stdName, string fname, string EnrollNo, string gender, string faculty, string Shift,
                             string Class, string seatNo, string StdAge, string field, string dept, string Section, PictureBox stdImg, string path,
                             ManagementSystem managementForm)
        {
            this.StdName = stdName;
            this.Fname = fname;
            this.EnrollNo = EnrollNo;
            this.Gender = gender;
            this.Faculty = faculty;
            this.Shift = Shift;
            this.Class = Class;
            this.SeatNo = seatNo;
            this.StdAge = StdAge;
            this.Field = field;
            this.Dept = dept;
            this.Section = Section;
            this.Path = path;
            this.ManagementForm = managementForm;
            this.StdImg = stdImg;
            this.Next = null;
            this.Previous = null;
        }

        //Node Constructor For Courses Enrolling
        public managementSys(string seatNo, string semester, string course1, string course2, string course3, string course4, string course5,
            string courseTitle1, string courseTitle2, string courseTitle3, string courseTitle4, string courseTitle5, string path,
            ManagementSystem managementForm)
        {
            this.SeatNo = seatNo;
            this.Semester = semester;
            this.Course1 = course1;
            this.Course2 = course2;
            this.Course3 = course3;
            this.Course4 = course4;
            this.Course5 = course5;
            this.CourseTitle1 = courseTitle1;
            this.CourseTitle2 = courseTitle2;
            this.CourseTitle3 = courseTitle3;
            this.CourseTitle4 = courseTitle4;
            this.CourseTitle5 = courseTitle5;
            this.Path = path;
            this.ManagementForm = managementForm;
            this.Next = null;
            this.Previous = null;
        }

        //Node Constructor For Courses Marks
        public managementSys(string seatNo, string semester, string marksCourse1, string marksCourse2, string marksCourse3,
            string marksCourse4, string marksCourse5, string path,
            ManagementSystem managementForm)
        {
            this.SeatNo = seatNo;
            this.Semester = semester;
            this.MarksCourse1 = marksCourse1;
            this.MarksCourse2 = marksCourse2;
            this.MarksCourse3 = marksCourse3;
            this.MarksCourse4 = marksCourse4;
            this.MarksCourse5 = marksCourse5;
            this.Path = path;
            this.ManagementForm = managementForm;
            this.Next = null;
            this.Previous = null;
        }
    }

    //Student Registration Class
    public class StudentsRegistration
    {
        public StudentsRegistration(string stdName, string fname, string enrollNo, string gender, string faculty, string Shift,
                             string Class, string seatNo, string stdAge, string field, string dept, string section, PictureBox stdImg, string path,
                             ManagementSystem managementForm)
        {
            if (stdName == "" || fname == "" || enrollNo == "" || gender == "Select" || faculty == "Select" || Shift == "Select" ||
                Class == "Select" || seatNo == "" || stdAge == "" || field == "" || dept == "" || section == "")
            {

                MetroMessageBox.Show(managementForm,
                "Please fill in all fields",
                "Blank fields",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                if (stdImg.Image == null)
                {
                    MetroMessageBox.Show(managementForm,
                    "Please Upload an Image",
                    "Image Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    if (!File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path);
                        sw.WriteLine(seatNo);
                        sw.WriteLine(enrollNo);
                        sw.WriteLine(stdName);
                        sw.WriteLine(fname);
                        sw.WriteLine(Class);
                        sw.WriteLine(gender);
                        sw.WriteLine(faculty);
                        sw.WriteLine(Shift);
                        sw.WriteLine(stdAge);
                        sw.WriteLine(field);
                        sw.WriteLine(dept);
                        sw.WriteLine(section);
                        sw.Close();

                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo+"\\Image\\");
                       string directoryPath1 = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo + "\\Image\\"+ seatNo+".jpg";
                        
                            stdImg.Image.Save(directoryPath1);
                 
                        MetroMessageBox.Show(managementForm,
                        "Your Record has been Saved",
                        "Sucessfully Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                        managementForm.clearAllStudRegFields();
                    }
                    else
                    {
                        MetroMessageBox.Show(managementForm,
                        "This record is already exist",
                        "Already Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
            }
        }
    }

    //Courses Enrolling Class
    public class CoursesEnrolling
    {
        public CoursesEnrolling(string seatNo, string semester, string course1, string course2, string course3, string course4, string course5,
            string courseTitle1, string courseTitle2, string courseTitle3, string courseTitle4, string courseTitle5, string path,
            ManagementSystem managementForm)
        {
            if (seatNo == "" || course1 == "" || course2 == "" || course3 == "" || course4 == "" || course5 == "" ||
             courseTitle1 == "" || courseTitle2 == "" || courseTitle3 == "" || courseTitle4 == "" || courseTitle5 == "" || semester == "Select")
            {
                MetroMessageBox.Show(managementForm,
                "Please fill in all fields",
                "Blank fields",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                if (File.Exists(path))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo + "\\Courses\\Semseter " + semester);
                    string coursesPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo + "\\Courses\\Semseter " + semester + "\\CousersDetails.txt";

                    if (!File.Exists(coursesPath))
                    {
                        StreamWriter sw = new StreamWriter(coursesPath);
                        sw.WriteLine(course1);
                        sw.WriteLine(course2);
                        sw.WriteLine(course3);
                        sw.WriteLine(course4);
                        sw.WriteLine(course5);
                        sw.WriteLine(courseTitle1);
                        sw.WriteLine(courseTitle2);
                        sw.WriteLine(courseTitle3);
                        sw.WriteLine(courseTitle4);
                        sw.WriteLine(courseTitle5);
                        sw.Close();

                        MetroMessageBox.Show(managementForm,
                            "Your Record has been Saved",
                            "Sucessfully Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                        managementForm.clearAllEnrollCoursesFields();

                    }
                    else
                    {
                        MetroMessageBox.Show(managementForm,
                            "Courses Already been Enrolled for this Semester",
                            "Enrolled Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm,
                            "Invalid Information",
                            "Record not Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }
    }

    //Courses Marks Entry Class
    public class MarksEntry
    {
        public MarksEntry(string seatNo, string semester, string marksCourse1, string marksCourse2, string marksCourse3,
            string marksCourse4, string marksCourse5, string path,
            ManagementSystem managementForm)
        {
            if (seatNo == "" || marksCourse1 == "" || marksCourse2 == "" || marksCourse3 == "" || marksCourse4 == "" || marksCourse5 == "" ||semester == "Select")
            {
                MetroMessageBox.Show(managementForm,
                "Please fill in all fields",
                "Blank fields",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                if (File.Exists(path))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo + "\\Courses\\Semseter " + semester);
                    string coursesMarksPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo + "\\Courses\\Semseter " + semester + "\\CousersMarksDetails.txt";

                    if (!File.Exists(coursesMarksPath))
                    {
                        StreamWriter sw = new StreamWriter(coursesMarksPath);
                        sw.WriteLine(marksCourse1);
                        sw.WriteLine(marksCourse2);
                        sw.WriteLine(marksCourse3);
                        sw.WriteLine(marksCourse4);
                        sw.WriteLine(marksCourse5);
                        sw.Close();

                        MetroMessageBox.Show(managementForm,
                            "Your Record has been Saved",
                            "Sucessfully Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                        managementForm.clearAllMarksFields();
                    }
                    else
                    {
                        MetroMessageBox.Show(managementForm,
                            "Marks Already been saved for this Semester",
                            "Saved Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm,
                            "Invalid Information",
                            "Record not Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

    }

    public class CircularLinkedList
    {
        public managementSys Header;
        public managementSys Pointer;

        public CircularLinkedList()
        {
            this.Header = null;
            this.Pointer = null;
        }

        //Students Registration using CircularLinkedList
        public void StudRegistration(string stdName, string fname, string EnrollNo, string gender, string faculty, string Shift,
                             string Class, string seatNo, string StdAge, string field, string dept, string Section, PictureBox stdImg, string path,
                             ManagementSystem managementForm)
        {
            managementSys StdReg = new managementSys(stdName, fname, EnrollNo, gender, faculty, Shift,
                              Class, seatNo, StdAge, field, dept, Section, stdImg, path,
                              managementForm);

            if (Header == null)
            {
                Header = StdReg;
                Pointer = StdReg;
                Header.Previous = Pointer;
                Pointer.Next = Header;
                new StudentsRegistration(StdReg.StdName, StdReg.Fname, StdReg.EnrollNo, StdReg.Gender, StdReg.Faculty, StdReg.Shift,
                                 StdReg.Class, StdReg.SeatNo, StdReg.StdAge, StdReg.Field, StdReg.Dept, StdReg.Section, StdReg.StdImg, StdReg.Path,
                                 StdReg.ManagementForm);
            }
            else
            {
                Pointer.Next = StdReg;
                Pointer.Next.Previous = Pointer;
                Pointer = Pointer.Next;
                Pointer.Next = Header;
                Header.Previous = Pointer;
                new StudentsRegistration(StdReg.StdName, StdReg.Fname, StdReg.EnrollNo, StdReg.Gender, StdReg.Faculty, StdReg.Shift,
                                 StdReg.Class, StdReg.SeatNo, StdReg.StdAge, StdReg.Field, StdReg.Dept, StdReg.Section, StdReg.StdImg, StdReg.Path,
                                 StdReg.ManagementForm);
            }
        }

        //courses Enrolling using CircularLinkedList
        public void CoursesEnrolled(string seatNo, string semester, string course1, string course2, string course3, string course4, string course5,
            string courseTitle1, string courseTitle2, string courseTitle3, string courseTitle4, string courseTitle5, string path,
            ManagementSystem managementForm)
        {
            managementSys CoursesEnroll = new managementSys(seatNo, semester, course1, course2, course3, course4, course5,
             courseTitle1, courseTitle2, courseTitle3, courseTitle4, courseTitle5, path,
             managementForm);

            if (Header == null)
            {
                Header = CoursesEnroll;
                Pointer = CoursesEnroll;
                Header.Previous = Pointer;
                Pointer.Next = Header;

                new CoursesEnrolling(CoursesEnroll.SeatNo, CoursesEnroll.Semester, CoursesEnroll.Course1,
                    CoursesEnroll.Course2, CoursesEnroll.Course3, CoursesEnroll.Course4, CoursesEnroll.Course5,
                    CoursesEnroll.CourseTitle1, CoursesEnroll.CourseTitle2, CoursesEnroll.CourseTitle3,
                    CoursesEnroll.CourseTitle4, CoursesEnroll.CourseTitle5, CoursesEnroll.Path, CoursesEnroll.ManagementForm);
            }
            else
            {
                Pointer.Next = CoursesEnroll;
                Pointer.Next.Previous = Pointer;
                Pointer = Pointer.Next;
                Pointer.Next = Header;
                Header.Previous = Pointer;

                new CoursesEnrolling(CoursesEnroll.SeatNo, CoursesEnroll.Semester, CoursesEnroll.Course1,
                    CoursesEnroll.Course2, CoursesEnroll.Course3, CoursesEnroll.Course4, CoursesEnroll.Course5,
                    CoursesEnroll.CourseTitle1, CoursesEnroll.CourseTitle2, CoursesEnroll.CourseTitle3,
                    CoursesEnroll.CourseTitle4, CoursesEnroll.CourseTitle5, CoursesEnroll.Path, CoursesEnroll.ManagementForm);
            }
        }

        //courses Marks Entry using CircularLinkedList
        public void MarksEntry(string seatNo, string semester, string marksCourse1, string marksCourse2, string marksCourse3,
            string marksCourse4, string marksCourse5, string path,
            ManagementSystem managementForm)
        {
            managementSys MarksEnter = new managementSys(seatNo, semester, marksCourse1, marksCourse2, marksCourse3,
             marksCourse4, marksCourse5, path, managementForm);

            if (Header == null)
            {
                Header = MarksEnter;
                Pointer = MarksEnter;
                Header.Previous = Pointer;
                Pointer.Next = Header;

                new MarksEntry(MarksEnter.SeatNo, MarksEnter.Semester, MarksEnter.MarksCourse1, MarksEnter.MarksCourse2,
                    MarksEnter.MarksCourse3, MarksEnter.MarksCourse4, MarksEnter.MarksCourse5, MarksEnter.Path,
                    MarksEnter.ManagementForm);
            }
            else
            {
                Pointer.Next = MarksEnter;
                Pointer.Next.Previous = Pointer;
                Pointer = Pointer.Next;
                Pointer.Next = Header;
                Header.Previous = Pointer;

                new MarksEntry(MarksEnter.SeatNo, MarksEnter.Semester, MarksEnter.MarksCourse1, MarksEnter.MarksCourse2,
                    MarksEnter.MarksCourse3, MarksEnter.MarksCourse4, MarksEnter.MarksCourse5, MarksEnter.Path,
                    MarksEnter.ManagementForm);
            }
        }
    }
}
