using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using Bunifu.Framework.UI;

namespace StudentsRecordsManagementSystem
{
    public partial class ManagementSystem : Form
    {
        public ManagementSystem()
        {
            InitializeComponent();
        }
        private void ManagementMinimizedButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ManagementCloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ManagementResizeButton_Click(object sender, EventArgs e)
        {
            if (this.Width == 800)
            {
                this.Size = new Size(1024, 600);
                this.CenterToScreen();
            }
            else if (this.Width == 1024)
            {
                this.Size = new Size(800, 600);
                this.CenterToScreen();
                studRegSplitContainerUp.SplitterDistance = 143;
            }
        }

        public void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void OnlyAlpha(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void OnlyLetterOrNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void showPanel(Panel panelName)
        {
            Panel[] panel = { studentsRegPanel, CoursesEnrollingPanel, MarksEntryPanel, RecordSectionPanel, AttendanceEntryPanel, 
                              AttendanceRecordsPanel, IDCardPanel, AdmitCardPanel, MarksSheetPanel};

            for (int i = 0; i < panel.Length; i++)
            {
                panel[i].Visible = false;
            }
            panelName.Visible = true;
        }
        private void studentRegistrationBTN_Click(object sender, EventArgs e)
        {
            showPanel(studentsRegPanel);
        }

        private void CoursesEnrollingBTN_Click(object sender, EventArgs e)
        {
            showPanel(CoursesEnrollingPanel);
        }

        private void RecordSectionBTN_Click(object sender, EventArgs e)
        {
            showPanel(RecordSectionPanel);
        }

        private void AttendanceEntryBTN_Click(object sender, EventArgs e)
        {
            showPanel(AttendanceEntryPanel);
        }

        private void AdmitCardBTN_Click(object sender, EventArgs e)
        {
            showPanel(AdmitCardPanel);
        }

        private void MarksSheetBTN_Click(object sender, EventArgs e)
        {
            showPanel(MarksSheetPanel);
        }

        private void AttendanceRecordsBTN_Click(object sender, EventArgs e)
        {
            showPanel(AttendanceRecordsPanel);
        }

        private void IDCardBTN_Click(object sender, EventArgs e)
        {
            showPanel(IDCardPanel);
        }

        private void MarksEntryBTN_Click(object sender, EventArgs e)
        {
            showPanel(MarksEntryPanel);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Authentication AuthForm = new Authentication();
            this.Hide();
            AuthForm.Closed += (s, args) => this.Close();
            AuthForm.Show();
        }

        private void StudRegImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StudRegImg.Image = new Bitmap(open.FileName);
                StudRegImg.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void clearAllStudRegFields()
        {
            studRegNameTB.Text = "";
            studRegFatherTB.Text = "";
            studRegEnrolNo.Text = "";
            studRegGenderCB.selectedIndex = 0;
            studRegFacultyCB.selectedIndex = 0;
            studRegShiftCB.selectedIndex = 0;
            studRegClassCB.selectedIndex = 0;
            studRegSeatTB.Text = "";
            studRegAgeTB.Text = "";
            studRegFieldTB.Text = "";
            studRegDepartTB.Text = "";
            studRegSectionTB.Text = "";
            StudRegImg.Image = null;
        }
        private void studRegSaveBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + studRegSeatTB.Text);
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + studRegSeatTB.Text + "\\StudentDetails.txt";

            CircularLinkedList cll = new CircularLinkedList();
            cll.StudRegistration(studRegNameTB.Text, studRegFatherTB.Text, studRegEnrolNo.Text, studRegGenderCB.selectedValue,
                studRegFacultyCB.selectedValue, studRegShiftCB.selectedValue, studRegClassCB.selectedValue, studRegSeatTB.Text,
                studRegAgeTB.Text, studRegFieldTB.Text, studRegDepartTB.Text, studRegSectionTB.Text, StudRegImg,
                directoryPath, this);
        }

        private void CoursesSeatNoSearchTB_OnValueChanged(object sender, EventArgs e)
        {
            CoursesStudNameTB.Text = "";
            CoursesFatherNameTB.Text = "";
            CoursesClassTB.Text = "";
            CoursesSemesterCB.selectedIndex = -1;

        }
        private void CoursesSearchBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;

            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + CoursesSeatNoSearchTB.Text + "\\StudentDetails.txt";

            if (File.Exists(directoryPath))
            {
                StreamReader sr = new StreamReader(directoryPath);
                sr.ReadLine(); sr.ReadLine();
                CoursesStudNameTB.Text = sr.ReadLine();
                CoursesFatherNameTB.Text = sr.ReadLine();
                CoursesClassTB.Text = sr.ReadLine();
                sr.Close();
                CoursesSemesterCB.Enabled = true;
                CoursesSemesterCB.selectedIndex = 0;
            }
            else
            {
                MetroMessageBox.Show(this,
                        "Invalid Information",
                        "Record not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        public void clearAllEnrollCoursesFields()
        {
            CoursesSeatNoSearchTB.Text = "";
            CoursesSemesterCB.selectedIndex = 0;
            EnrollCourseNo1TB.Text = "";
            EnrollCourseNo2TB.Text = "";
            EnrollCourseNo3TB.Text = "";
            EnrollCourseNo4TB.Text = "";
            EnrollCourseNo5TB.Text = "";
            EnrollCourse1TitleTB.Text = "";
            EnrollCourse2TitleTB.Text = "";
            EnrollCourse3TitleTB.Text = "";
            EnrollCourse4TitleTB.Text = "";
            EnrollCourse5TitleTB.Text = "";
        }
        private void EnrollCoursesBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + CoursesSeatNoSearchTB.Text);
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + CoursesSeatNoSearchTB.Text + "\\StudentDetails.txt";

            try
            {
                CircularLinkedList CLL = new CircularLinkedList();
                CLL.CoursesEnrolled(CoursesSeatNoSearchTB.Text, CoursesSemesterCB.selectedValue, EnrollCourseNo1TB.Text,
                    EnrollCourseNo2TB.Text, EnrollCourseNo3TB.Text, EnrollCourseNo4TB.Text, EnrollCourseNo5TB.Text,
                    EnrollCourse1TitleTB.Text, EnrollCourse2TitleTB.Text, EnrollCourse3TitleTB.Text, EnrollCourse4TitleTB.Text,
                    EnrollCourse5TitleTB.Text, directoryPath, this);
            }
            catch (Exception) 
            {
                MetroMessageBox.Show(this,
                "Please fill in all fields",
                "Blank fields",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }

        }

        private void MarksEntrySeatNoSearchBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;

            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + MarksEntrySeatNoTB.Text + "\\StudentDetails.txt";

            if (File.Exists(directoryPath))
            {
                StreamReader sr = new StreamReader(directoryPath);
                sr.ReadLine(); sr.ReadLine();
                MarksEntryStudNameTB.Text = sr.ReadLine();
                MarksEntryFatherNameTB.Text = sr.ReadLine();
                MarksEntryClassTB.Text = sr.ReadLine();
                sr.Close();
                MarksEntrySemesterCB.Enabled = true;
            }
            else
            {
                MetroMessageBox.Show(this,
                        "Invalid Information",
                        "Record not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void MarksEntrySemesterCB_onItemSelected(object sender, EventArgs e)
        {
            string coursesPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + MarksEntrySeatNoTB.Text + "\\Courses\\Semseter " + MarksEntrySemesterCB.selectedValue + "\\CousersDetails.txt";

            if (File.Exists(coursesPath))
            {
                StreamReader sr = new StreamReader(coursesPath);
                EntryCourseNo1TB.Text = sr.ReadLine();
                EntryCourseNo2TB.Text = sr.ReadLine();
                EntryCourseNo3TB.Text = sr.ReadLine();
                EntryCourseNo4TB.Text = sr.ReadLine();
                EntryCourseNo5TB.Text = sr.ReadLine();
                sr.Close();
            }
            else if(MarksEntrySemesterCB.selectedValue == "Select")
            {
                EntryCourseNo1TB.Text = "";
                EntryCourseNo2TB.Text = "";
                EntryCourseNo3TB.Text = "";
                EntryCourseNo4TB.Text = "";
                EntryCourseNo5TB.Text = "";
            }
            else
            {
                EntryCourseNo1TB.Text = "";
                EntryCourseNo2TB.Text = "";
                EntryCourseNo3TB.Text = "";
                EntryCourseNo4TB.Text = "";
                EntryCourseNo5TB.Text = "";
                MetroMessageBox.Show(this,
                    "Courses Record not Found for this semester first enroll in courses",
                    "Invalid Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void MarksEntrySeatNoTB_OnValueChanged(object sender, EventArgs e)
        {
            MarksEntryStudNameTB.Text = "";
            MarksEntryFatherNameTB.Text = "";
            MarksEntryClassTB.Text = "";
        }
        public void clearAllMarksFields()
        {
            MarksEntrySeatNoTB.Text = "";
            MarksEntrySemesterCB.selectedIndex = 0;
            EntryMarks1TB.Text = "";
            EntryMarks2TB.Text = "";
            EntryMarks3TB.Text = "";
            EntryMarks4TB.Text = "";
            EntryMarks5TB.Text = "";
        }
        private void SaveMarksBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + MarksEntrySeatNoTB.Text);
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + MarksEntrySeatNoTB.Text + "\\StudentDetails.txt";

            try
            {
                CircularLinkedList CLL = new CircularLinkedList();
                CLL.MarksEntry(MarksEntrySeatNoTB.Text, MarksEntrySemesterCB.selectedValue, EntryMarks1TB.Text,
                    EntryMarks2TB.Text, EntryMarks3TB.Text, EntryMarks4TB.Text, EntryMarks5TB.Text, directoryPath, this);
            }
            catch (Exception) 
            {
                MetroMessageBox.Show(this,
                "Please fill in all fields",
                "Blank fields",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void RecordSeatNoSearchBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + RecordSeatNoTB.Text + "\\StudentDetails.txt";
            
            if(File.Exists(directoryPath))
            {
                StreamReader sr = new StreamReader(directoryPath);
                sr.ReadLine(); sr.ReadLine();
                RecordStudNameTB.Text = sr.ReadLine();
                RecordFatherTB.Text = sr.ReadLine();
                RecordClassCB.Text = sr.ReadLine();
                RecordGenderCB.Text = sr.ReadLine();
                RecordFacultyCB.Text = sr.ReadLine();
                RecordShiftCB.Text = sr.ReadLine();
                RecordAgeTB.Text = sr.ReadLine();
                RecordFieldTB.Text = sr.ReadLine();
                RecordDepartTB.Text = sr.ReadLine();
                RecordSectionTB.Text = sr.ReadLine();
                sr.Close();
            }
            else
            {
                MetroMessageBox.Show(this,
                        "Invalid Information",
                        "Record not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void EditDetailsBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + RecordSeatNoTB.Text + "\\StudentDetails.txt";

            if (File.Exists(directoryPath))
            {
                RecordStudNameTB.Enabled = true;
                RecordFatherTB.Enabled = true;
                RecordClassCB.Enabled = true;
                RecordGenderCB.Enabled = true;
                RecordFacultyCB.Enabled = true;
                RecordShiftCB.Enabled = true;
                RecordAgeTB.Enabled = true;
                RecordFieldTB.Enabled = true;
                RecordDepartTB.Enabled = true;
                RecordSectionTB.Enabled = true;
            }
            else
            {
                MetroMessageBox.Show(this,
                         "Invalid Information",
                         "Record not Found",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void RecordEditSaveBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + RecordSeatNoTB.Text + "\\StudentDetails.txt";
            if (File.Exists(directoryPath))
            {
                StreamWriter sw = new StreamWriter(directoryPath);

                sw.WriteLine(RecordSeatNoTB.Text);
                sw.WriteLine();
                sw.WriteLine(RecordStudNameTB.Text);
                sw.WriteLine(RecordFatherTB.Text);
                sw.WriteLine(RecordClassCB.Text);
                sw.WriteLine(RecordGenderCB.Text);
                sw.WriteLine(RecordFacultyCB.Text);
                sw.WriteLine(RecordShiftCB.Text);
                sw.WriteLine(RecordAgeTB.Text);
                sw.WriteLine(RecordFieldTB.Text);
                sw.WriteLine(RecordDepartTB.Text);
                sw.WriteLine(RecordSectionTB.Text);
                sw.Close();

                MetroMessageBox.Show(this,
                        "Your Record has been Saved",
                        "Sucessfully Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
            }
            
        }

        private void AttendanceEntrySeatNoSearchBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + AttendanceEntrySeatNoTB.Text + "\\StudentDetails.txt";

            if (File.Exists(directoryPath))
            {
                StreamReader sr = new StreamReader(directoryPath);
                sr.ReadLine(); sr.ReadLine();
                AttendanceEntryStudNameTB.Text = sr.ReadLine();
                AttendanceEntryFatherTB.Text = sr.ReadLine();
                AttendanceEntryClassTB.Text = sr.ReadLine();
                sr.ReadLine();
                AttendanceEntryFieldTB.Text = sr.ReadLine();
                AttendanceEntryShiftTB.Text = sr.ReadLine();
                sr.ReadLine(); sr.ReadLine(); sr.ReadLine();
                AttendanceEntrySectionTB.Text = sr.ReadLine();
                sr.Close();
            }
            else
            {
                MetroMessageBox.Show(this,
                         "Invalid Information",
                         "Record not Found",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }

        }

        private void SaveAttendanceBTN_Click(object sender, EventArgs e)
        {
            if (AttendanceEntryStudNameTB.Text != "" && AttendanceEntrySemesterCB.selectedValue != "Select" 
                && AttendanceEntryCourseNoTB.Text != "")
            {
                string directoryPath;
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + AttendanceEntrySeatNoTB.Text + "\\Courses\\Semseter " + AttendanceEntrySemesterCB.selectedValue + "\\" + AttendanceEntryCourseNoTB.Text);
                directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + AttendanceEntrySeatNoTB.Text + "\\Courses\\Semseter " + AttendanceEntrySemesterCB.selectedValue + "\\" + AttendanceEntryCourseNoTB.Text + "\\" + AttendanceEntryDate.Text + ".txt";

                if (!File.Exists(directoryPath))
                {
                    if (AttendanceEntryTeacherTB.Text != "" &&
                        AttendanceEntryRemarksCB.selectedValue != "Select")
                    {
                        StreamWriter sw = new StreamWriter(directoryPath);
                        sw.WriteLine(AttendanceEntryTeacherTB.Text);
                        sw.WriteLine(AttendanceEntryRemarksCB.selectedValue);
                        sw.Close();
                        MetroMessageBox.Show(this,
                                "Your Record has been Saved",
                                "Sucessfully Saved",
                                MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                        AttendanceEntrySeatNoTB.Text = "";
                        AttendanceEntrySemesterCB.selectedIndex = 0;
                        AttendanceEntryTeacherTB.Text = "";
                        AttendanceEntryCourseNoTB.Text = "";
                        AttendanceEntryRemarksCB.selectedIndex = 0;
                    }
                    else
                    {
                        MetroMessageBox.Show(this,
                             "Enter Teacher Name and Select Remarks",
                             "Record not save",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this,
                             "Already these Course Attendance Saved",
                             "Record not Save",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
            else
            {
                MetroMessageBox.Show(this,
                         "Invalid Information",
                         "Record not save",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }

        }

        private void ViewAttendanceSeatNoSearchBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + ViewAttendanceSeatNoTB.Text + "\\StudentDetails.txt";

            if (File.Exists(directoryPath) && ViewAttendanceSeatNoTB.Text != "")
            {
                StreamReader sr = new StreamReader(directoryPath);
                sr.ReadLine(); sr.ReadLine();
                ViewAttendanceStudNameTB.Text = sr.ReadLine();
                ViewAttendanceFatherTB.Text = sr.ReadLine();
                ViewAttendanceClassTB.Text = sr.ReadLine();
                sr.ReadLine();
                ViewAttendanceFieldTB.Text = sr.ReadLine();
                ViewAttendanceShiftTB.Text = sr.ReadLine();
                sr.ReadLine(); sr.ReadLine(); sr.ReadLine();
                ViewAttendanceSectionTB.Text = sr.ReadLine();
                sr.Close();
            }
            else
            {
                MetroMessageBox.Show(this,
                         "Invalid Information",
                         "Record not Found",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void AttendanceEntrySeatNoTB_OnValueChanged(object sender, EventArgs e)
        {
            AttendanceEntryStudNameTB.Text = "";
            AttendanceEntryFatherTB.Text = "";
            AttendanceEntryClassTB.Text = "";
            AttendanceEntryFieldTB.Text = "";
            AttendanceEntryShiftTB.Text = "";
            AttendanceEntrySectionTB.Text = "";
        }

        private void ViewAttendanceSeatNoTB_OnValueChanged(object sender, EventArgs e)
        {
            ViewAttendanceStudNameTB.Text = "";
            ViewAttendanceFatherTB.Text = "";
            ViewAttendanceClassTB.Text = "";
            ViewAttendanceFieldTB.Text = "";
            ViewAttendanceShiftTB.Text = "";
            ViewAttendanceSectionTB.Text = "";
            ViewAttendanceTeacherTB.Text = "";
            ViewAttendanceRemarksTB.Text = "";
        }

        private void ViewAttendanceSemesterCB_onItemSelected(object sender, EventArgs e)
        {
            if (ViewAttendanceSemesterCB.selectedValue == "Select")
            {
                ViewAttendanceTeacherTB.Text = "";
                ViewAttendanceRemarksTB.Text = "";
            }
        }
        private void ViewAttendanceBTN_Click(object sender, EventArgs e)
        {
            string directoryPath;
           
            directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + ViewAttendanceSeatNoTB.Text + "\\Courses\\Semseter " + ViewAttendanceSemesterCB.selectedValue + "\\" + ViewAttendanceCourseNoTB.Text + "\\" + ViewAttendanceDate.Text + ".txt";

            if (File.Exists(directoryPath) && ViewAttendanceStudNameTB.Text !="")
            {
                StreamReader sr = new StreamReader(directoryPath);
                ViewAttendanceTeacherTB.Text =  sr.ReadLine();
                ViewAttendanceRemarksTB.Text = sr.ReadLine();
                sr.Close();
            }
            else
            {
                MetroMessageBox.Show(this,
                         "Invalid Information",
                         "Record not Found",
                         MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void IDSeatNoSearchBTN_Click(object sender, EventArgs e)
        {
            if (IDSeatNoTB.Text == "")
            {
                MetroMessageBox.Show(this,
                "Enter Right Information",
                "Invalid Information",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                string directoryPath = Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + IDSeatNoTB.Text + "\\StudentDetails.txt";
                if (File.Exists(directoryPath))
                {
                    StreamReader sr = new StreamReader(directoryPath);
                    string seatNo = sr.ReadLine();
                    string enrollNo = sr.ReadLine();
                    string name = sr.ReadLine();
                    string fName = sr.ReadLine();
                    string clas = sr.ReadLine();
                    string gender = sr.ReadLine();
                    string faculty = sr.ReadLine();
                    string shift = sr.ReadLine();
                    string age = sr.ReadLine();
                    string field = sr.ReadLine();
                    string dept = sr.ReadLine();
                    string section = sr.ReadLine();
                    sr.Close();

                    IDStudNameTB.Text = name;
                    IDFatherTB.Text = fName;
                    IDAgeTB.Text = age;
                    IDFacultyTB.Text = faculty;
                    IDClassTB.Text = clas;
                    IDShiftTB.Text = shift;
                    IDDepartNameTB.Text = dept;
                    IDFieldTB.Text = field;
                    try
                    {
                        Bitmap pic = new Bitmap(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + seatNo + "\\Image\\" + seatNo + ".jpg");
                        IDImage.Image = pic;
                        IDImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (ArgumentException)
                    {
                        MetroMessageBox.Show(this,
                            "Record Not Found",
                            "Invalid Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }

                }
                else
                {
                    MetroMessageBox.Show(this,
                        "Record Not Found",
                        "Invalid Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }

        }

        private void PrintIDCardBTN_Click(object sender, EventArgs e)
        {
            if (IDSeatNoTB.Text == "" || IDStudNameTB.Text == "")
            {
                MetroMessageBox.Show(this,
                 "Please first search Seat No then Click Print",
                 "Invalid Information",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.Show();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                 Bitmap bmp1 = Properties.Resources.rectangle1;
                 Image img1 = bmp1;
                 e.Graphics.DrawImage(img1, 5, 5, img1.Width, img1.Height);

                 Bitmap bmp2 = Properties.Resources.Karachi_University_logo;
                 Image img2 = bmp2;
                 e.Graphics.DrawImage(img2, 180, 50, img2.Width, img2.Height);

                e.Graphics.DrawString("University Of Karachi", new Font("arial", 18, FontStyle.Bold), Brushes.Black, new Point(180, 20));
                e.Graphics.DrawString("STUDENT ID CARD", new Font("arial", 16, FontStyle.Bold), Brushes.Black, new Point(200, 50));
                e.Graphics.DrawString("SESSION 2017-2018", new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(220, 80));

                e.Graphics.DrawString("Seat NO : " + IDSeatNoTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(40, 120));
                e.Graphics.DrawString("Name : " + IDStudNameTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(40, 150));
                e.Graphics.DrawString("Father Name : " + IDFatherTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(40, 180));
                e.Graphics.DrawString("Class : " + IDClassTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(40, 210));
                e.Graphics.DrawString("Faculty : " + IDFacultyTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(200, 210));
                e.Graphics.DrawString("Shift : " + IDShiftTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(40, 240));
                e.Graphics.DrawString("Department : " + IDDepartNameTB.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(40, 270));

                Bitmap pic = new Bitmap(Environment.CurrentDirectory + "\\Database\\StudentRecords\\" + IDSeatNoTB.Text + "\\Image\\" + IDSeatNoTB.Text + ".jpg");
                e.Graphics.DrawImage(pic, 450, 120, 150, 150);
            }
            catch
            {
                MetroMessageBox.Show(this,
                 "Record Not Found",
                 "Invalid Information",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void MarkSheetSeatNoSearchBTN_Click(object sender, EventArgs e)
        {        
            if (MarkSheetSeatNoTB.Text == "")
            {

                MetroMessageBox.Show(this,
                "Enter Right Information",
                "Invalid Information",
                MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                string directoryPath = Environment.CurrentDirectory + "//Database//StudentRecords//" + MarkSheetSeatNoTB.Text + "//StudentDetails.txt";
                if (File.Exists(directoryPath))
                {
                    StreamReader sr = new StreamReader(directoryPath);
                    sr.ReadLine(); sr.ReadLine();
                    MarkSheetStudNameTB.Text = sr.ReadLine();
                    MarkSheetFatherTB.Text = sr.ReadLine();
                    MarkSheetClassTB.Text = sr.ReadLine();
                    sr.Close();
                    MarkSheetSemesterCB.Enabled = true;
                }
                else
                {
                    MetroMessageBox.Show(this,
                 "Record Not Found",
                 "Invalid Information",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);

                }
            }

        }

        private void MarkSheetSemesterCB_onItemSelected(object sender, EventArgs e)
        {
            string CoursesDetailsPath = Environment.CurrentDirectory + "//Database//StudentRecords//" + MarkSheetSeatNoTB.Text + "//Courses//Semseter " + MarkSheetSemesterCB.selectedValue + "//CousersDetails.txt";
            string CoursesMarksDetailsPath = Environment.CurrentDirectory + "//Database//StudentRecords//" + MarkSheetSeatNoTB.Text + "//Courses//Semseter " + MarkSheetSemesterCB.selectedValue + "//CousersMarksDetails.txt";

            if (MarkSheetSemesterCB.selectedValue == "Select" || !File.Exists(CoursesDetailsPath))
            {
                MarkSheetCourse1NoTB.Text = "";
                MarkSheetCourse2NoTB.Text = "";
                MarkSheetCourse3NoTB.Text = "";
                MarkSheetCourse4NoTB.Text = "";
                MarkSheetCourse5NoTB.Text = "";
                MarkSheetMark1TB.Text = "";
                MarkSheetMark2TB.Text = "";
                MarkSheetMark3TB.Text = "";
                MarkSheetMark4TB.Text = "";
                MarkSheetMark5TB.Text = "";
                MarkSheetGPATB.Text = "";

                if(MarkSheetSemesterCB.selectedValue != "Select" )
                {
                    MetroMessageBox.Show(this,
                        "Fisrt Enrolling in Courses",
                     "Record Not Found",
                     MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
            else
            {
                if (!File.Exists(CoursesDetailsPath))
                {
                    MetroMessageBox.Show(this,
                        "Fisrt Enrolling in Courses",
                     "Record Not Found",
                     MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    StreamReader srDetails = new StreamReader(CoursesDetailsPath);
                    MarkSheetCourse1NoTB.Text = srDetails.ReadLine();
                    MarkSheetCourse2NoTB.Text = srDetails.ReadLine();
                    MarkSheetCourse3NoTB.Text = srDetails.ReadLine();
                    MarkSheetCourse4NoTB.Text = srDetails.ReadLine();
                    MarkSheetCourse5NoTB.Text = srDetails.ReadLine();
                    srDetails.Close();

                    StreamReader srMarks = new StreamReader(CoursesMarksDetailsPath);
                    MarkSheetMark1TB.Text = srMarks.ReadLine();
                    MarkSheetMark2TB.Text = srMarks.ReadLine();
                    MarkSheetMark3TB.Text = srMarks.ReadLine();
                    MarkSheetMark4TB.Text = srMarks.ReadLine();
                    MarkSheetMark5TB.Text = srMarks.ReadLine();
                    srMarks.Close();

                }
            }
        }

        private void GPACalculateBTN_Click(object sender, EventArgs e)
        {
            if (MarkSheetMark1TB.Text == "")
            {
                MetroMessageBox.Show(this,
                 "Please Select Semester",
                 "Invalid Information",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                int m1 = Convert.ToInt32(MarkSheetMark1TB.Text);
                int m2 = Convert.ToInt32(MarkSheetMark2TB.Text);
                int m3 = Convert.ToInt32(MarkSheetMark3TB.Text);
                int m4 = Convert.ToInt32(MarkSheetMark4TB.Text);
                int m5 = Convert.ToInt32(MarkSheetMark5TB.Text);

                float t = ((m1 + m2 + m3 + m4 + m5) * 100) / 500;
                float gpa = t / 21;
                MarkSheetGPATB.Text = Convert.ToString(gpa);
            }
        }

        private void PrintMarkSheetBTN_Click(object sender, EventArgs e)
        {
            if (MarkSheetMark1TB.Text == "" || MarkSheetGPATB.Text == "")
            {
                MetroMessageBox.Show(this,
                 "Please first search Seat No then select Semester and Click on Calculate GPA then Click Print",
                 "Invalid Information",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                printPreviewDialog2.Document = printDocument2;
                printPreviewDialog2.Show();
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp1 = Properties.Resources.MarksheetTemplate;
            Image img1 = bmp1;
            e.Graphics.DrawImage(img1, 5, 5, 840, 600);

            e.Graphics.DrawString("Seat No:         " + MarkSheetSeatNoTB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(170, 160));
            e.Graphics.DrawString("Name:         " + MarkSheetStudNameTB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(470, 160));
            e.Graphics.DrawString("Father's Name:         " + MarkSheetFatherTB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(170, 210));
            e.Graphics.DrawString("Class:         " + MarkSheetClassTB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(470,210));
            e.Graphics.DrawString("Course No:       " + MarkSheetCourse1NoTB.Text + "           Marks:      " + MarkSheetMark1TB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 265));
            e.Graphics.DrawString("Course No:       " + MarkSheetCourse2NoTB.Text + "           Marks:      " + MarkSheetMark2TB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 295));
            e.Graphics.DrawString("Course No:       " + MarkSheetCourse3NoTB.Text + "           Marks:      " + MarkSheetMark3TB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 325));
            e.Graphics.DrawString("Course No:       " + MarkSheetCourse4NoTB.Text + "           Marks:      " + MarkSheetMark4TB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 355));
            e.Graphics.DrawString("Course No:       " + MarkSheetCourse5NoTB.Text + "           Marks:      " + MarkSheetMark5TB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 385));

            int m1 = Convert.ToInt32(MarkSheetMark1TB.Text);
            int m2 = Convert.ToInt32(MarkSheetMark2TB.Text);
            int m3 = Convert.ToInt32(MarkSheetMark3TB.Text);
            int m4 = Convert.ToInt32(MarkSheetMark4TB.Text);
            int m5 = Convert.ToInt32(MarkSheetMark5TB.Text);

            float t = ((m1 + m2 + m3 + m4 + m5) * 100) / 500;
            float gpa = t / 21;
            string total = Convert.ToString(t);
            MarkSheetGPATB.Text = Convert.ToString(gpa);
            e.Graphics.DrawString("Percantage:       " + total + "%", new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(470, 455));
            e.Graphics.DrawString("Total GPA:       " + MarkSheetGPATB.Text, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(470, 500));
        }

        private void ViewAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            ViewAttendanceTeacherTB.Text = "";
            ViewAttendanceRemarksTB.Text = "";
        }
    }
}
