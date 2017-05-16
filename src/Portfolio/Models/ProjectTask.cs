using System;
using System.Web;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Portfolio.Models {

    public class ProjectTask{

        int _id;
        int _imgAmount;//todo make it to search automatically
        technology[] _technologiesUsed;
        string _name, _description;
        bool _commercial = false, _done = true;
        DateTime _endDate;

        public int Id { get { return _id; } set { _id = value; } }

        [MaxLength(60, ErrorMessage = "Nazwa projektu nie może być dłuższa niż 60 znaków")]
        public string Name { get { return _name; } set { _name = value; } }

        [MaxLength(10000, ErrorMessage = "Pole opisu projektu nie może być dłuższe niż 10 000 znaków")]
        public string Description { get { return _description; } set { _description = value; } }
        
        public bool Commercial { get { return _commercial; } set { _commercial = value; } }
        public string CommercialTxt { get { return Commercial ? "Projekt komercyjny" : ""; } }
        
        public bool Done { get { return _done; } set { _done = value; } }
        public string DoneTxt { get { return Done ? "ukończony" : "w trakcie realizacji"; } }

        public DateTime EndDate { get { return _endDate; } set { _endDate = value; } }
        public string EndDateTxt { get { return _endDate.ToString("MM-yyyy"); } }

        public int ImgAmount { get { return _imgAmount; } set { _imgAmount = value; } }

        public technology[] TechnologiesUsed {
            get { return _technologiesUsed; }
            set { _technologiesUsed = value; }
        }


        public List<string> TechnologiesUsedName {
            get {
                List<string> techUsedName = new List<string>();

                foreach (var tech in _technologiesUsed) {
                    techUsedName.Add(GetTechDescr(tech));
                }
                return techUsedName;
            }
        }


        public static string GetTechDescr(Enum tech) {
            FieldInfo ourFieldInfo = tech.GetType().GetField(tech.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])ourFieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return tech.ToString();
        }

        //todo: make the img file like id-numberOfImg  with supplied number
        string GetImageFileName(int num) {  return "task" + Id.ToString() + "-" + num.ToString() + ".jpg";  }

        //todo: aut findind images for a proper project
        //imgs existing in folder should be auto deteted
        //now it is defined in class how many img files are for one project
        public List<string> ImageFiles {
            get {
                List<string> imgList = new List<string>();
                for (int i = 1; i <= _imgAmount; i++) {
                    imgList.Add(GetImageFileName(i));
                }
                return imgList;
            }
        }


        public ImgOfProject GetProjectImg(string imageName) {
            ImgOfProject img = new ImgOfProject();
            img.ProjectId = _id;
            img.ImgName = imageName;
            return img;
        }


    }


    public class ImgOfProject {
        int _projectId, _imgNum;
        string _imgName;

        public int ProjectId { get { return _projectId; } set { _projectId = value; } }
        public int ImgNum { get { return _imgNum; } set { _imgNum = value; } }
        public string ImgName { get { return _imgName; } set { _imgName = value; } }
    }


    public enum technology {
        [Description("C#")]
        csharp,
        [Description("C")]
        c,
        [Description("C++")]
        cpp,
        [Description("ASP.NET")]
        aspnet,
        [Description("MVC")]
        mvc,
        [Description("Sql")]
        sql,
        [Description("MySql")]
        mssql,
        [Description("Java")]
        java,
        [Description("PHP")]
        php,
        [Description("HTML")]
        html,
        [Description("CSS")]
        css,
        [Description("Bootstrap")]
        bootstrap,
        [Description("JavaScript")]
        javascript,
        [Description("jQuery")]
        jquery,
        [Description("AJAX")]
        ajax,
        [Description("AngularJs")]
        angularjs,
        [Description("Wordpress")]
        wordpress,
        [Description("Microcontrolllers")]
        microcontrollers,
        [Description("Embedded Systems")]
        embeddedsystems,
        [Description("FreeRTOS")]
        freertos,
        [Description("ARM Cortex-M")]
        armcortexm,
        [Description("Objective programming")]
        objectiveprogramming,
        [Description("WinForms")]
        winforms,
        [Description("Git")]
        git,
        [Description("Jenkins")]
        jenkins,
        [Description("Scrum")]
        scrum,
        [Description("OBD II")]
        obd2,
        [Description("CAN")]
        can
    }


}
