using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace SchoolOfFineArt
{
    public class SchoolViewModel : ViewModelBase
    {
        StudentBody studentBody;
        Random rand = new Random();

        public SchoolViewModel() : this(null)
        {

        }

        public SchoolViewModel(IDictionary<string, object> properties)
        {
            StudentBody = new StudentBody();
            StudentBody.Students.Add(new Student());

            string uri = "http://xamarin.github.io/xamarin-forms-book-samples/SchoolOfFineArt/students.xml";

            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.BeginGetResponse((arg) =>
            {
                Stream stream = request.EndGetResponse(arg).GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                XmlSerializer xml = new XmlSerializer(typeof(StudentBody));
                StudentBody = xml.Deserialize(reader) as StudentBody;

                foreach (Student student in StudentBody.Students)
                {
                    student.StudentBody = StudentBody;

                    if(properties != null && properties.ContainsKey(student.FullName))
                    {
                        student.Notes = (string)properties[student.FullName];
                    }
                }
            }, null);

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                if(studentBody != null)
                {
                    int index = rand.Next(studentBody.Students.Count);
                    Student student = StudentBody.Students[index];
                    double factor = 1 + (rand.NextDouble() - 0.5) / 5;
                    student.GradePointAverage = Math.Round(Math.Max(0, Math.Min(5, factor * student.GradePointAverage)), 2);

                }
                return true;
            });
        }

        public void SaveNotes(IDictionary<string, object> properties)
        {
            foreach (Student student in StudentBody.Students)
            {
                properties[student.FullName] = student.Notes;
            }
        }



        public StudentBody StudentBody
        {
            protected set { SetProperty(ref studentBody, value); }
            get { return studentBody; }
        }


    }
}
