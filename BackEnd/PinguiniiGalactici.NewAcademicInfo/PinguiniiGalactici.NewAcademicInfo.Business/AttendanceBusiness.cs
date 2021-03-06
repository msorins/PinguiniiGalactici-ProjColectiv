﻿using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class AttendanceBusiness : BusinessObject
    {
        #region Constructor
        public AttendanceBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Attendance Attendances)
        {
            _context.DALContext.AttendancesDAL.Insert(Attendances);

            PrepareForEmail(Attendances);
        }

        public Attendance ReadById(Guid AttendancesID)
        {
            return _context.DALContext.AttendancesDAL.ReadById(AttendancesID);
        }

        public IEnumerable<Attendance> ReadAll()
        {
            return _context.DALContext.AttendancesDAL.ReadAll();
        }

        public IEnumerable<AttendancesCourses> ReadAllWithCourses()
        {
            return _context.DALContext.AttendancesDAL.ReadAllWithCourses();
        }

        public IEnumerable<Attendance> ReadForStudent()
        {
            return _context.DALContext.AttendancesDAL.ReadForStudent();
        }

        public void Update(Attendance Attendances)
        {
            _context.DALContext.AttendancesDAL.Update(Attendances);

            PrepareForEmail(Attendances);
        }


        public void Delete(Guid AttendancesID)
        {
            _context.DALContext.AttendancesDAL.Delete(AttendancesID);

            Attendance attendance = _context.DALContext.AttendancesDAL.ReadById(AttendancesID);
            PrepareForEmail(attendance);
        }

        public void UpdateBulk(List<Attendance> attendances)
        {
            foreach (Attendance a in attendances)
                Update(a);
        }

        public void UpdateOrInsert(int studentID, Guid courseID, int weekNr, Guid typeID, decimal? grade)
        {
            _context.DALContext.AttendancesDAL.UpdateOrInsert(studentID, courseID, weekNr, typeID, grade);
            Student student = _context.DALContext.StudentsDAL.ReadById(studentID);
            SendEmail(student.Email);
        }

        private void PrepareForEmail(Attendance attendance)
        {
            StudentCourse enrollment = _context.DALContext.StudentCourseDAL.ReadById(attendance.EnrollmentID);
            Student student = _context.DALContext.StudentsDAL.ReadById(enrollment.StudentID);

            SendEmail(student.Email);
        }

        private void SendEmail(string email)
        {
            string senderEmail = ConfigurationManager.AppSettings["senderEmail"];
            string senderPassword = ConfigurationManager.AppSettings["senderPassword"];
            string emailSubject = "Your academic situation has changed";
            string emailBody = "Hello!<br/><br/>Your attendances and/or grades have been modified. "
                + "Please acces your account to insure the accuracy of your new academic situation."
                + "<br/><br/>Have a good day!<br/>Pinguinii Galactici";

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(new MailAddress(email));
            mail.IsBodyHtml = true;

            mail.Subject = emailSubject;
            mail.Body = emailBody;


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        public IEnumerable<AttendancesCourses> ReadAllWithCourseAndStudent(Guid courseID, int registrationNumber)
        {
            return _context.DALContext.AttendancesDAL.ReadAllWithCourseAndStudent(courseID, registrationNumber);
        }

        #endregion
    }
}
