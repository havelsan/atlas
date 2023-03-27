
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
    /// Radyoloji Tetkik Açıklama Raporu
    /// </summary>
    public partial class RadiologyTestRequestDescription : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string TESTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public RadiologyTestRequestDescription MyParentReport
            {
                get { return (RadiologyTestRequestDescription)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1112121 { get {return Header().NewField1112121;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField LOGO111 { get {return Header().LOGO111;} }
            public TTReportField HizmetOzel11 { get {return Footer().HizmetOzel11;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName11 { get {return Footer().UserName11;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public RadiologyTestRequestDescription MyParentReport
                {
                    get { return (RadiologyTestRequestDescription)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField1112121;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1161;
                public TTReportField LOGO111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 207, 24, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"T.C.































































































XXXXXX































































































XXXXXX XXXXXXLIĞI";

                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 26, 195, 32, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112121.TextFont.Size = 14;
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @"RADYOLOJİ TETKİK AÇIKLAMA RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 3, 195, 26, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 31, 45, 37, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 11;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.Underline = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"HİZMETE ÖZEL";

                    LOGO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 3, 49, 23, false);
                    LOGO111.Name = "LOGO111";
                    LOGO111.TextFont.Name = "Courier New";
                    LOGO111.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField1112121.CalcValue = NewField1112121.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    LOGO111.CalcValue = LOGO111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField11,NewField1112121,NewField1161,LOGO111,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public RadiologyTestRequestDescription MyParentReport
                {
                    get { return (RadiologyTestRequestDescription)ParentReport; }
                }
                
                public TTReportField HizmetOzel11;
                public TTReportShape NewLine11;
                public TTReportField PrintDate;
                public TTReportField UserName11;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HizmetOzel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 4, 243, 10, false);
                    HizmetOzel11.Name = "HizmetOzel11";
                    HizmetOzel11.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel11.TextFont.Size = 11;
                    HizmetOzel11.TextFont.Bold = true;
                    HizmetOzel11.TextFont.Underline = true;
                    HizmetOzel11.TextFont.CharSet = 162;
                    HizmetOzel11.Value = @"HİZMETE ÖZEL";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 3, 203, 3, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 4, 37, 9, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}}";

                    UserName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 4, 125, 9, false);
                    UserName11.Name = "UserName11";
                    UserName11.TextFont.Size = 8;
                    UserName11.TextFont.CharSet = 162;
                    UserName11.Value = @"UserName";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 4, 203, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel11.CalcValue = HizmetOzel11.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + @"}";
                    UserName11.CalcValue = UserName11.Value;
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { HizmetOzel11,PrintDate,UserName11,PageNumber};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public RadiologyTestRequestDescription MyParentReport
            {
                get { return (RadiologyTestRequestDescription)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField NewField11411 { get {return Body().NewField11411;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField REQDOCTORNAME { get {return Body().REQDOCTORNAME;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField NewField121611 { get {return Body().NewField121611;} }
            public TTReportField PREDIAGNOSIS { get {return Body().PREDIAGNOSIS;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField1241 { get {return Body().NewField1241;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField NewField11241 { get {return Body().NewField11241;} }
            public TTReportField NewField112211 { get {return Body().NewField112211;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField NewField111221 { get {return Body().NewField111221;} }
            public TTReportField NewField1112211 { get {return Body().NewField1112211;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField NewField123211 { get {return Body().NewField123211;} }
            public TTReportField NewField1112411 { get {return Body().NewField1112411;} }
            public TTReportField BirrhDate1 { get {return Body().BirrhDate1;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField NewField11112211 { get {return Body().NewField11112211;} }
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
                list[0] = new TTReportNqlData<Radiology.RadiologyRequestPatientInfoReportQuery_Class>("RadiologyRequestPatientInfoReportQuery", Radiology.RadiologyRequestPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public RadiologyTestRequestDescription MyParentReport
                {
                    get { return (RadiologyTestRequestDescription)ParentReport; }
                }
                
                public TTReportField NewField11311;
                public TTReportField NewField11411;
                public TTReportField NewField11611;
                public TTReportField REQDOCTORNAME;
                public TTReportField FROMRESOURCE;
                public TTReportField NewField121611;
                public TTReportField PREDIAGNOSIS;
                public TTReportField NewField11116111;
                public TTReportField NewField11112111;
                public TTReportField NewField121;
                public TTReportField REQUESTDATE;
                public TTReportField NewField151;
                public TTReportField NAME;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField1261;
                public TTReportField NewField1321;
                public TTReportField HASTANO;
                public TTReportField NewField1241;
                public TTReportField NewField161;
                public TTReportField NewField11231;
                public TTReportField NewField11241;
                public TTReportField NewField112211;
                public TTReportField NewField1161;
                public TTReportField SEX;
                public TTReportField NewField111221;
                public TTReportField NewField1112211;
                public TTReportField NewField111121111;
                public TTReportField UNIQUEREFNO;
                public TTReportField NewField123211;
                public TTReportField NewField1112411;
                public TTReportField BirrhDate1;
                public TTReportField BIRTHDATE;
                public TTReportField NewField11112211; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 81;
                    RepeatCount = 0;
                    
                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 21, 50, 26, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Doktor Adı";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 11, 50, 16, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Cinsiyet / Yaşı";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 21, 154, 26, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"İsteyen Bölüm";

                    REQDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 21, 112, 26, false);
                    REQDOCTORNAME.Name = "REQDOCTORNAME";
                    REQDOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQDOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQDOCTORNAME.TextFont.Size = 9;
                    REQDOCTORNAME.TextFont.CharSet = 162;
                    REQDOCTORNAME.Value = @"{#REQUESTDOCTOR#}";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 21, 205, 26, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FROMRESOURCE.TextFont.Size = 9;
                    FROMRESOURCE.TextFont.CharSet = 162;
                    FROMRESOURCE.Value = @"{#FROMRES#}";

                    NewField121611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 34, 61, 39, false);
                    NewField121611.Name = "NewField121611";
                    NewField121611.TextFont.Size = 9;
                    NewField121611.TextFont.Bold = true;
                    NewField121611.TextFont.Underline = true;
                    NewField121611.TextFont.CharSet = 162;
                    NewField121611.Value = @"KLİNİK VE ANAMNEZ BULGULAR";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 40, 203, 75, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.Value = @"{#PREDIAGNOSIS#}";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 76, 60, 81, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.TextFont.Size = 9;
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.Underline = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"İSTENEN TETKİKLER";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 34, 63, 39, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Size = 9;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 26, 50, 31, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İstek Tarihi";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 26, 112, 31, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 50, 6, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Hastanın";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 6, 112, 11, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "Radiology";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{@TTOBJECTID@}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 11, 205, 16, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 50, 11, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @"Adı Soyadı";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 11, 154, 16, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 16, 205, 21, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "Radiology";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 16, 154, 21, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Hasta No";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 6, 52, 11, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 9;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 16, 156, 21, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @":";

                    NewField11241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 11, 156, 16, false);
                    NewField11241.Name = "NewField11241";
                    NewField11241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11241.TextFont.Size = 9;
                    NewField11241.TextFont.Bold = true;
                    NewField11241.TextFont.CharSet = 162;
                    NewField11241.Value = @":";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 26, 52, 31, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 11, 52, 16, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 11, 112, 16, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SEX.ObjectDefName = "SKRSCinsiyet";
                    SEX.DataMember = "ADI";
                    SEX.TextFont.Name = "Arial";
                    SEX.TextFont.Size = 9;
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"{#SEX#}";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 21, 52, 26, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Size = 9;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @":";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 21, 156, 26, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112211.TextFont.Size = 9;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 76, 63, 81, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Size = 9;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 6, 205, 11, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.ObjectDefName = "Radiology";
                    UNIQUEREFNO.DataMember = "EPISODE.PATIENT.UniqueRefNo";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{@TTOBJECTID@}";

                    NewField123211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 6, 154, 11, false);
                    NewField123211.Name = "NewField123211";
                    NewField123211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123211.TextFont.Size = 9;
                    NewField123211.TextFont.Bold = true;
                    NewField123211.TextFont.CharSet = 162;
                    NewField123211.Value = @"TC Kimlik No";

                    NewField1112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 6, 156, 11, false);
                    NewField1112411.Name = "NewField1112411";
                    NewField1112411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112411.TextFont.Size = 9;
                    NewField1112411.TextFont.Bold = true;
                    NewField1112411.TextFont.CharSet = 162;
                    NewField1112411.Value = @":";

                    BirrhDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 16, 50, 21, false);
                    BirrhDate1.Name = "BirrhDate1";
                    BirrhDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate1.TextFont.Size = 9;
                    BirrhDate1.TextFont.Bold = true;
                    BirrhDate1.TextFont.CharSet = 162;
                    BirrhDate1.Value = @"Doğum Tarihi";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 16, 112, 21, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRTHDATE.ObjectDefName = "Radiology";
                    BIRTHDATE.DataMember = "EPISODE.PATIENT.BirthDate";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{@TTOBJECTID@}";

                    NewField11112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 16, 52, 21, false);
                    NewField11112211.Name = "NewField11112211";
                    NewField11112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112211.TextFont.Size = 9;
                    NewField11112211.TextFont.Bold = true;
                    NewField11112211.TextFont.CharSet = 162;
                    NewField11112211.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Radiology.RadiologyRequestPatientInfoReportQuery_Class dataset_RadiologyRequestPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Radiology.RadiologyRequestPatientInfoReportQuery_Class>(0);
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    REQDOCTORNAME.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Requestdoctor) : "");
                    FROMRESOURCE.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Fromres) : "");
                    NewField121611.CalcValue = NewField121611.Value;
                    PREDIAGNOSIS.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.PreDiagnosis) : "");
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    REQUESTDATE.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.RequestDate) : "");
                    NewField151.CalcValue = NewField151.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    PROTOKOLNO.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Protocolno) : "");
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField11241.CalcValue = NewField11241.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    SEX.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Sex) : "");
                    SEX.PostFieldValueCalculation();
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    UNIQUEREFNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UNIQUEREFNO.PostFieldValueCalculation();
                    NewField123211.CalcValue = NewField123211.Value;
                    NewField1112411.CalcValue = NewField1112411.Value;
                    BirrhDate1.CalcValue = BirrhDate1.Value;
                    BIRTHDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BIRTHDATE.PostFieldValueCalculation();
                    NewField11112211.CalcValue = NewField11112211.Value;
                    return new TTReportObject[] { NewField11311,NewField11411,NewField11611,REQDOCTORNAME,FROMRESOURCE,NewField121611,PREDIAGNOSIS,NewField11116111,NewField11112111,NewField121,REQUESTDATE,NewField151,NAME,PROTOKOLNO,NewField1261,NewField1321,HASTANO,NewField1241,NewField161,NewField11231,NewField11241,NewField112211,NewField1161,SEX,NewField111221,NewField1112211,NewField111121111,UNIQUEREFNO,NewField123211,NewField1112411,BirrhDate1,BIRTHDATE,NewField11112211};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PROCGroup : TTReportGroup
        {
            public RadiologyTestRequestDescription MyParentReport
            {
                get { return (RadiologyTestRequestDescription)ParentReport; }
            }

            new public PROCGroupHeader Header()
            {
                return (PROCGroupHeader)_header;
            }

            new public PROCGroupFooter Footer()
            {
                return (PROCGroupFooter)_footer;
            }

            public TTReportField RADIOLOGYTESTNAME { get {return Header().RADIOLOGYTESTNAME;} }
            public TTReportField NewField1116121 { get {return Header().NewField1116121;} }
            public TTReportField PROCEDUREID { get {return Header().PROCEDUREID;} }
            public TTReportField WARNING { get {return Footer().WARNING;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField ContactAddress { get {return Footer().ContactAddress;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField ContactPhone { get {return Footer().ContactPhone;} }
            public PROCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestByObjectIDQuery_Class>("RadiologyTestByObjectIDQuery", RadiologyTest.RadiologyTestByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TESTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PROCGroupHeader(this);
                _footer = new PROCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PROCGroupHeader : TTReportSection
            {
                public RadiologyTestRequestDescription MyParentReport
                {
                    get { return (RadiologyTestRequestDescription)ParentReport; }
                }
                
                public TTReportField RADIOLOGYTESTNAME;
                public TTReportField NewField1116121;
                public TTReportField PROCEDUREID; 
                public PROCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RADIOLOGYTESTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 152, 7, false);
                    RADIOLOGYTESTNAME.Name = "RADIOLOGYTESTNAME";
                    RADIOLOGYTESTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RADIOLOGYTESTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    RADIOLOGYTESTNAME.TextFont.Size = 9;
                    RADIOLOGYTESTNAME.TextFont.CharSet = 162;
                    RADIOLOGYTESTNAME.Value = @"{#NAME#}";

                    NewField1116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 9, 61, 14, false);
                    NewField1116121.Name = "NewField1116121";
                    NewField1116121.TextFont.Size = 9;
                    NewField1116121.TextFont.Bold = true;
                    NewField1116121.TextFont.Underline = true;
                    NewField1116121.TextFont.CharSet = 162;
                    NewField1116121.Value = @"AÇIKLAMALAR";

                    PROCEDUREID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 9, 151, 14, false);
                    PROCEDUREID.Name = "PROCEDUREID";
                    PROCEDUREID.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREID.Value = @"{#PROCEDUREID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestByObjectIDQuery_Class dataset_RadiologyTestByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestByObjectIDQuery_Class>(0);
                    RADIOLOGYTESTNAME.CalcValue = (dataset_RadiologyTestByObjectIDQuery != null ? Globals.ToStringCore(dataset_RadiologyTestByObjectIDQuery.Name) : "");
                    NewField1116121.CalcValue = NewField1116121.Value;
                    PROCEDUREID.CalcValue = (dataset_RadiologyTestByObjectIDQuery != null ? Globals.ToStringCore(dataset_RadiologyTestByObjectIDQuery.Procedureid) : "");
                    return new TTReportObject[] { RADIOLOGYTESTNAME,NewField1116121,PROCEDUREID};
                }
            }
            public partial class PROCGroupFooter : TTReportSection
            {
                public RadiologyTestRequestDescription MyParentReport
                {
                    get { return (RadiologyTestRequestDescription)ParentReport; }
                }
                
                public TTReportField WARNING;
                public TTReportField NewField1;
                public TTReportField ContactAddress;
                public TTReportField NewField11;
                public TTReportField ContactPhone; 
                public PROCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 20;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    WARNING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 203, 6, false);
                    WARNING.Name = "WARNING";
                    WARNING.TextFont.Bold = true;
                    WARNING.TextFont.CharSet = 162;
                    WARNING.Value = @"Cihaz arızası gibi olağan dışı durumlarda verilen randevu saatinde gecikmeler olabilir.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 36, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İrtibat Adresi :";

                    ContactAddress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 8, 138, 20, false);
                    ContactAddress.Name = "ContactAddress";
                    ContactAddress.MultiLine = EvetHayirEnum.ehEvet;
                    ContactAddress.WordBreak = EvetHayirEnum.ehEvet;
                    ContactAddress.ExpandTabs = EvetHayirEnum.ehEvet;
                    ContactAddress.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 8, 168, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İrtibat Telefonu :";

                    ContactPhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 8, 203, 13, false);
                    ContactPhone.Name = "ContactPhone";
                    ContactPhone.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestByObjectIDQuery_Class dataset_RadiologyTestByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestByObjectIDQuery_Class>(0);
                    WARNING.CalcValue = WARNING.Value;
                    NewField1.CalcValue = NewField1.Value;
                    ContactAddress.CalcValue = ContactAddress.Value;
                    NewField11.CalcValue = NewField11.Value;
                    ContactPhone.CalcValue = ContactPhone.Value;
                    return new TTReportObject[] { WARNING,NewField1,ContactAddress,NewField11,ContactPhone};
                }

                public override void RunScript()
                {
#region PROC FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyTestRequestDescription)ParentReport).RuntimeParameters.TESTOBJECTID.ToString();
            RadiologyTest radTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            
            if(radTest.MasterResource != null)
            {
                if(!String.IsNullOrEmpty(radTest.MasterResource.ContactAddress))
                    this.ContactAddress.CalcValue = radTest.MasterResource.ContactAddress.Trim();
                if(!String.IsNullOrEmpty(radTest.MasterResource.ContactPhone))
                    this.ContactPhone.CalcValue = radTest.MasterResource.ContactPhone.Trim();
            }
#endregion PROC FOOTER_Script
                }
            }

        }

        public PROCGroup PROC;

        public partial class TESTGroup : TTReportGroup
        {
            public RadiologyTestRequestDescription MyParentReport
            {
                get { return (RadiologyTestRequestDescription)ParentReport; }
            }

            new public TESTGroupBody Body()
            {
                return (TESTGroupBody)_body;
            }
            public TTReportField TESTDESCRIPTION { get {return Body().TESTDESCRIPTION;} }
            public TESTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TESTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class>("GetRadiologyTestDescriptionReportNQL", RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.PROC.PROCEDUREID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TESTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TESTGroupBody : TTReportSection
            {
                public RadiologyTestRequestDescription MyParentReport
                {
                    get { return (RadiologyTestRequestDescription)ParentReport; }
                }
                
                public TTReportField TESTDESCRIPTION; 
                public TESTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    TESTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 3, 203, 8, false);
                    TESTDESCRIPTION.Name = "TESTDESCRIPTION";
                    TESTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTDESCRIPTION.Value = @"{#TESTDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class dataset_GetRadiologyTestDescriptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class>(0);
                    TESTDESCRIPTION.CalcValue = (dataset_GetRadiologyTestDescriptionReportNQL != null ? Globals.ToStringCore(dataset_GetRadiologyTestDescriptionReportNQL.Testdescription) : "");
                    return new TTReportObject[] { TESTDESCRIPTION};
                }
            }

        }

        public TESTGroup TEST;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public RadiologyTestRequestDescription()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            PROC = new PROCGroup(HEADER,"PROC");
            TEST = new TESTGroup(PROC,"TEST");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Radiology", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("TESTOBJECTID", "", "RadiologyTest", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("TESTOBJECTID"))
                _runtimeParameters.TESTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TESTOBJECTID"]);
            Name = "RADIOLOGYTESTREQUESTDESCRIPTION";
            Caption = "Radyoloji Tetkik Açıklama Raporu";
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