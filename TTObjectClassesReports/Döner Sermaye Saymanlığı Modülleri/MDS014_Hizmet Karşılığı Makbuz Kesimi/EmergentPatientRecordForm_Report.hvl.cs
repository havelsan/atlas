
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Makbuzda Senet Ödemesi Dökülür
    /// </summary>
    public partial class EmergentPatientRecordForm : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public EmergentPatientRecordForm MyParentReport
            {
                get { return (EmergentPatientRecordForm)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField YAZI { get {return Body().YAZI;} }
            public TTReportField YAZI2 { get {return Body().YAZI2;} }
            public TTReportField YAZI3 { get {return Body().YAZI3;} }
            public TTReportField TEL { get {return Body().TEL;} }
            public TTReportField ADRES { get {return Body().ADRES;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField MEMUR { get {return Body().MEMUR;} }
            public TTReportField DONSERMUDADI { get {return Body().DONSERMUDADI;} }
            public TTReportField DONSERMUDUNVAN { get {return Body().DONSERMUDUNVAN;} }
            public TTReportField HOSPITALNAME { get {return Body().HOSPITALNAME;} }
            public TTReportField OPENINGDATE { get {return Body().OPENINGDATE;} }
            public TTReportField OPENINGTIME { get {return Body().OPENINGTIME;} }
            public TTReportField CURRENTUSER { get {return Body().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Body().PageNumber;} }
            public TTReportField PrintDate { get {return Body().PrintDate;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Receipt.EmergentPatientRecordFormQuery_Class>("EmergentPatientRecordFormQuery", Receipt.EmergentPatientRecordFormQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public EmergentPatientRecordForm MyParentReport
                {
                    get { return (EmergentPatientRecordForm)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField YAZI;
                public TTReportField YAZI2;
                public TTReportField YAZI3;
                public TTReportField TEL;
                public TTReportField ADRES;
                public TTReportField NewField1;
                public TTReportField ADSOYAD;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField MEMUR;
                public TTReportField DONSERMUDADI;
                public TTReportField DONSERMUDUNVAN;
                public TTReportField HOSPITALNAME;
                public TTReportField OPENINGDATE;
                public TTReportField OPENINGTIME;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 132;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 18, 130, 23, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.TextFont.Size = 9;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"ACİL HASTA TUTANAK FORMU";

                    YAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 36, 184, 64, false);
                    YAZI.Name = "YAZI";
                    YAZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZI.MultiLine = EvetHayirEnum.ehEvet;
                    YAZI.NoClip = EvetHayirEnum.ehEvet;
                    YAZI.WordBreak = EvetHayirEnum.ehEvet;
                    YAZI.ExpandTabs = EvetHayirEnum.ehEvet;
                    YAZI.Value = @"";

                    YAZI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 64, 37, 69, false);
                    YAZI2.Name = "YAZI2";
                    YAZI2.Value = @"Tel No :";

                    YAZI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 69, 37, 74, false);
                    YAZI3.Name = "YAZI3";
                    YAZI3.Value = @"Adres :";

                    TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 64, 74, 69, false);
                    TEL.Name = "TEL";
                    TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEL.Value = @"{#HOMEPHONE#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 69, 184, 74, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.Value = @"{#HOMEADDRESS#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 81, 61, 86, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Adı Soyadı";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 86, 61, 91, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.Value = @"{#PATIENTNAME#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 81, 184, 86, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"Acil Vezne Memuru";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 111, 122, 116, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Döner Sermaye İşlt. Müd.";

                    MEMUR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 86, 184, 91, false);
                    MEMUR.Name = "MEMUR";
                    MEMUR.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEMUR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""EMERGENCYCASHOFFICER"", """")
";

                    DONSERMUDADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 101, 122, 106, false);
                    DONSERMUDADI.Name = "DONSERMUDADI";
                    DONSERMUDADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    DONSERMUDADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""CIRCCAPITALDIRECTORNAME"", """")
";

                    DONSERMUDUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 106, 122, 111, false);
                    DONSERMUDUNVAN.Name = "DONSERMUDUNVAN";
                    DONSERMUDUNVAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    DONSERMUDUNVAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""CIRCCAPITALDIRECTORTITLE"", """")
";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 13, 45, 18, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")
";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 21, 45, 26, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.Visible = EvetHayirEnum.ehHayir;
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.Value = @"{#OPENINGDATE#}";

                    OPENINGTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 26, 45, 31, false);
                    OPENINGTIME.Name = "OPENINGTIME";
                    OPENINGTIME.Visible = EvetHayirEnum.ehHayir;
                    OPENINGTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGTIME.TextFormat = @"Short Time";
                    OPENINGTIME.Value = @"{#OPENINGDATE#}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 126, 129, 131, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 126, 184, 131, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 126, 71, 131, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.EmergentPatientRecordFormQuery_Class dataset_EmergentPatientRecordFormQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.EmergentPatientRecordFormQuery_Class>(0);
                    BASLIK.CalcValue = BASLIK.Value;
                    YAZI.CalcValue = @"";
                    YAZI2.CalcValue = YAZI2.Value;
                    YAZI3.CalcValue = YAZI3.Value;
                    TEL.CalcValue = (dataset_EmergentPatientRecordFormQuery != null ? Globals.ToStringCore(dataset_EmergentPatientRecordFormQuery.Homephone) : "");
                    ADRES.CalcValue = (dataset_EmergentPatientRecordFormQuery != null ? Globals.ToStringCore(dataset_EmergentPatientRecordFormQuery.Homeaddress) : "");
                    NewField1.CalcValue = NewField1.Value;
                    ADSOYAD.CalcValue = (dataset_EmergentPatientRecordFormQuery != null ? Globals.ToStringCore(dataset_EmergentPatientRecordFormQuery.PatientName) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    OPENINGDATE.CalcValue = (dataset_EmergentPatientRecordFormQuery != null ? Globals.ToStringCore(dataset_EmergentPatientRecordFormQuery.OpeningDate) : "");
                    OPENINGTIME.CalcValue = (dataset_EmergentPatientRecordFormQuery != null ? Globals.ToStringCore(dataset_EmergentPatientRecordFormQuery.OpeningDate) : "");
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    MEMUR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYCASHOFFICER", "")
;
                    DONSERMUDADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("CIRCCAPITALDIRECTORNAME", "")
;
                    DONSERMUDUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("CIRCCAPITALDIRECTORTITLE", "")
;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")
;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { BASLIK,YAZI,YAZI2,YAZI3,TEL,ADRES,NewField1,ADSOYAD,NewField11,NewField12,OPENINGDATE,OPENINGTIME,PageNumber,PrintDate,MEMUR,DONSERMUDADI,DONSERMUDUNVAN,HOSPITALNAME,CURRENTUSER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string gun = this.OPENINGDATE.FormattedValue;
            string saat = this.OPENINGTIME.FormattedValue;
            string yazi = "";
            
            yazi = yazi + ".........................................................................." ;
            yazi = yazi + " Müdürlüğünde Görevli ................................" ;
            yazi = yazi + " sicil nolu personel " + gun + " de saat " + saat ;
            yazi = yazi + " rahatsızlanarak " + this.HOSPITALNAME.CalcValue ;
            yazi = yazi + " Acil Servis'e müracaat ettim. Mesai saati dışı olduğundan dolayı sevk belgemi görevliye ibraz edemedim. Tedavimin bitiminde mesaiye başladığım gün sevk belgemi " ;
            yazi = yazi + this.HOSPITALNAME.CalcValue + " Döner Sermaye İşletme Müdürlüğüne teslim etmeyi kabul ediyorum. Bu yükümlülüğümü yerine getirmediğim taktirde adıma bu tarihte tahakkuk eden bütün masrafları ödemeyi kabul ediyorum." ;
            this.YAZI.CalcValue = yazi ;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EmergentPatientRecordForm()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "EMERGENTPATIENTRECORDFORM";
            Caption = "Acil Hasta Tutanak Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}