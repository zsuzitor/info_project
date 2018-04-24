using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;


namespace main_info
{

    public class Article
    {
        public int Id { get; set; }
        public int Section_id { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        //public int Id { get; set; }
        //public int Id { get; set; }
        public Article()
        {
            Id = 0;
            Section_id = 0;
            Head = null;
            Body = null;
        }
    }
    public class Section
    {
        public int Id { get; set; }
        public int Parrent_id { get; set; }
public string Head { get; set; }
        //public List<Section> Sections_list { get; set; }
        //public List<Section> Article_list { get; set; }

        public Section()
        {
            Id = 0;
            Parrent_id = 0;
Head ="";
        }
    }
    public partial class Form1 : Form
    {
        List<Article> Article_list = new List<Article>();
        List<Section> Section_list = new List<Section>();
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_Closing;
            read_db();
            start_brows();
            //Thread.Sleep(5000);
            //string fsd = webBrowser1.Document.GetElementById("test_id").GetAttribute("value");

        }


        //--------------------------------------------------------------
        bool read_db()
        {
            bool success = false;

            DataContractJsonSerializer jsonFormatter_1 = new DataContractJsonSerializer(typeof(List<Article>));
            using (FileStream fs = new FileStream("Article.json", FileMode.OpenOrCreate))
            {
                Article_list = (List<Article>)jsonFormatter_1.ReadObject(fs);

               
            }


            return success;
        }
        bool write_db()
        {
            bool success = false;
            read_db();
            
            
            //TODO достать из браузера если что то добавлено и добавить в главные списки


            DataContractJsonSerializer jsonFormatter_1 = new DataContractJsonSerializer(typeof(List<Article>));
            using (FileStream fs = new FileStream("Article.json", FileMode.OpenOrCreate))
            {
                jsonFormatter_1.WriteObject(fs, Article_list);
            }
            DataContractJsonSerializer jsonFormatter_2 = new DataContractJsonSerializer(typeof(List<Section>));
            using (FileStream fs = new FileStream("Section.json", FileMode.OpenOrCreate))
            {
                jsonFormatter_2.WriteObject(fs, Section_list);
            }
            return success;
        }


        void start_brows()
        {
            string res_html = "<html><head>";

            //CSS
            res_html += "<style type='text/css'>";
            res_html += ".test{width:500px;}";
            res_html += "</style>";

            //JS
            res_html += "<script>";
            res_html += "function func_test(a){alert(a);}";
            res_html += "</script>";

            //START BODY
            res_html += "</head><body>";


           res_html +="Please enter your name:<br/>" +
    "<input type='text' id='test_id' value='123' name='userName'/><br/>" +
    "<button class='test' onclick=\"func_test('dfg')\">кликни</button>" +
    "";

            res_html += "</body></html>";

            webBrowser1.DocumentText = res_html;
            return;
        }

        //--------------------------------------------------------------
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string asd = webBrowser1.DocumentText;
            string fsd = webBrowser1.Document.GetElementById("test_id").GetAttribute("value");
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fsd = webBrowser1.Document.GetElementById("test_id").GetAttribute("value");
        }
        }
}
