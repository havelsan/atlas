
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
    /// Patoloji İstek Formu
    /// </summary>
    public partial class PathologyRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PathologyRequestReport MyParentReport
            {
                get { return (PathologyRequestReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewFieldBaslik { get {return Header().NewFieldBaslik;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField UserName1 { get {return Footer().UserName1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
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
                public PathologyRequestReport MyParentReport
                {
                    get { return (PathologyRequestReport)ParentReport; }
                }
                
                public TTReportField NewFieldBaslik;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewFieldBaslik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 36, 159, 43, false);
                    NewFieldBaslik.Name = "NewFieldBaslik";
                    NewFieldBaslik.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldBaslik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldBaslik.TextFont.Name = "Arial Narrow";
                    NewFieldBaslik.TextFont.Size = 14;
                    NewFieldBaslik.TextFont.Bold = true;
                    NewFieldBaslik.TextFont.CharSet = 162;
                    NewFieldBaslik.Value = @"PATOLOJİ İSTEK BİLGİ FORMU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 4, 179, 34, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 6, 34, 29, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO1.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO1.DataMember = "EMBLEM";
                    LOGO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewFieldBaslik.CalcValue = NewFieldBaslik.Value;
                    LOGO1.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewFieldBaslik,LOGO1,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PathologyRequestReport MyParentReport
                {
                    get { return (PathologyRequestReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 5, 209, 5, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 6, 28, 11, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate1.TextFont.Name = "Arial Narrow";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}}";

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 6, 119, 11, false);
                    UserName1.Name = "UserName1";
                    UserName1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName1.TextFont.Name = "Arial Narrow";
                    UserName1.TextFont.Size = 8;
                    UserName1.TextFont.CharSet = 162;
                    UserName1.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 6, 209, 11, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.TextFont.Name = "Arial Narrow";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + @"}";
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate1,PageNumber1,UserName1};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyRequestReport MyParentReport
            {
                get { return (PathologyRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField PatientName { get {return Body().PatientName;} }
            public TTReportField FromResource { get {return Body().FromResource;} }
            public TTReportField RequestDoctor { get {return Body().RequestDoctor;} }
            public TTReportField RequestDate { get {return Body().RequestDate;} }
            public TTReportField BirthDate { get {return Body().BirthDate;} }
            public TTReportField NewField123211 { get {return Body().NewField123211;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField BirrhDate1 { get {return Body().BirrhDate1;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField NewField111311 { get {return Body().NewField111311;} }
            public TTReportField NewField111312 { get {return Body().NewField111312;} }
            public TTReportField NewField111313 { get {return Body().NewField111313;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportField TCNo { get {return Body().TCNo;} }
            public TTReportField NewField1313111 { get {return Body().NewField1313111;} }
            public TTReportField Sex { get {return Body().Sex;} }
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
                list[0] = new TTReportNqlData<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class>("PathologyRequestPatientInfoReportQuery", PathologyRequest.PathologyRequestPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyRequestReport MyParentReport
                {
                    get { return (PathologyRequestReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField7;
                public TTReportField NewField12;
                public TTReportField NewField21;
                public TTReportField NewField26;
                public TTReportField PatientName;
                public TTReportField FromResource;
                public TTReportField RequestDoctor;
                public TTReportField RequestDate;
                public TTReportField BirthDate;
                public TTReportField NewField123211;
                public TTReportField NewField121;
                public TTReportField BirrhDate1;
                public TTReportField NewField112;
                public TTReportField NewField13;
                public TTReportField NewField122;
                public TTReportField NewField111611;
                public TTReportField NewField1261;
                public TTReportField NewField131;
                public TTReportField NewField11311;
                public TTReportField NewField111311;
                public TTReportField NewField111312;
                public TTReportField NewField111313;
                public TTReportShape NewLine11111;
                public TTReportField TCNo;
                public TTReportField NewField1313111;
                public TTReportField Sex; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 57;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 14, 36, 19, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Adı Soyadı";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 19, 36, 24, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Cinsiyet / Yaşı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 15, 166, 20, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"İstek Yapan Doktor";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 14, 39, 19, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 19, 39, 24, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Size = 9;
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @":";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 15, 169, 20, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 9;
                    NewField26.TextFont.Bold = true;
                    NewField26.TextFont.CharSet = 162;
                    NewField26.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 14, 120, 19, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    FromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 20, 215, 25, false);
                    FromResource.Name = "FromResource";
                    FromResource.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResource.Value = @"{#FROMRES#}";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 15, 215, 20, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor.Value = @"{#REQUESTDOCTORNAME#}";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 10, 215, 15, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    RequestDate.Value = @"{#REQUESTDATE#}";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 24, 120, 29, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthDate.TextFormat = @"dd/MM/yyyy";
                    BirthDate.Value = @"{#BIRTHDATE#}";

                    NewField123211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 9, 36, 14, false);
                    NewField123211.Name = "NewField123211";
                    NewField123211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123211.TextFont.Name = "Arial Narrow";
                    NewField123211.TextFont.Size = 9;
                    NewField123211.TextFont.Bold = true;
                    NewField123211.TextFont.CharSet = 162;
                    NewField123211.Value = @"TC Kimlik Numarası";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 9, 39, 14, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    BirrhDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 24, 36, 29, false);
                    BirrhDate1.Name = "BirrhDate1";
                    BirrhDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate1.TextFont.Name = "Arial Narrow";
                    BirrhDate1.TextFont.Size = 9;
                    BirrhDate1.TextFont.Bold = true;
                    BirrhDate1.TextFont.CharSet = 162;
                    BirrhDate1.Value = @"Doğum Tarihi";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 24, 39, 29, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 10, 166, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İstek Tarihi";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 10, 169, 15, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @":";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 20, 166, 25, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111611.TextFont.Name = "Arial Narrow";
                    NewField111611.TextFont.Size = 9;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"İsteyen Bölüm";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 20, 169, 25, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.TextFont.Name = "Arial Narrow";
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 52, 36, 57, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial Narrow";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Numune Alım Tarihi";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 52, 67, 57, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Alındığı Organ";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 52, 111, 57, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.TextFont.Name = "Arial Narrow";
                    NewField111311.TextFont.Size = 9;
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"Alındığı Dokunun Temel Özelliği";

                    NewField111312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 52, 142, 57, false);
                    NewField111312.Name = "NewField111312";
                    NewField111312.TextFont.Name = "Arial Narrow";
                    NewField111312.TextFont.Size = 9;
                    NewField111312.TextFont.Bold = true;
                    NewField111312.TextFont.CharSet = 162;
                    NewField111312.Value = @"Alınma Şekli";

                    NewField111313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 52, 211, 57, false);
                    NewField111313.Name = "NewField111313";
                    NewField111313.TextFont.Name = "Arial Narrow";
                    NewField111313.TextFont.Size = 9;
                    NewField111313.TextFont.Bold = true;
                    NewField111313.TextFont.CharSet = 162;
                    NewField111313.Value = @"Açıklama";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 57, 211, 57, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    TCNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 9, 120, 14, false);
                    TCNo.Name = "TCNo";
                    TCNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNo.Value = @"{#UNIQUEREFNO#}";

                    NewField1313111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 52, 184, 57, false);
                    NewField1313111.Name = "NewField1313111";
                    NewField1313111.TextFont.Name = "Arial Narrow";
                    NewField1313111.TextFont.Size = 9;
                    NewField1313111.TextFont.Bold = true;
                    NewField1313111.TextFont.CharSet = 162;
                    NewField1313111.Value = @"Klinik Bulgu";

                    Sex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 19, 71, 24, false);
                    Sex.Name = "Sex";
                    Sex.FieldType = ReportFieldTypeEnum.ftVariable;
                    Sex.ObjectDefName = "SKRSCinsiyet";
                    Sex.DataMember = "ADI";
                    Sex.TextFont.CharSet = 162;
                    Sex.Value = @"{#SEX#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyRequestPatientInfoReportQuery_Class dataset_PathologyRequestPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField26.CalcValue = NewField26.Value;
                    PatientName.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.Name) : "") + @" " + (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.Surname) : "");
                    FromResource.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.Fromres) : "");
                    RequestDoctor.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.Requestdoctorname) : "");
                    RequestDate.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.Requestdate) : "");
                    BirthDate.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.BirthDate) : "");
                    NewField123211.CalcValue = NewField123211.Value;
                    NewField121.CalcValue = NewField121.Value;
                    BirrhDate1.CalcValue = BirrhDate1.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField111312.CalcValue = NewField111312.Value;
                    NewField111313.CalcValue = NewField111313.Value;
                    TCNo.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.UniqueRefNo) : "");
                    NewField1313111.CalcValue = NewField1313111.Value;
                    Sex.CalcValue = (dataset_PathologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyRequestPatientInfoReportQuery.Sex) : "");
                    Sex.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField,NewField2,NewField7,NewField12,NewField21,NewField26,PatientName,FromResource,RequestDoctor,RequestDate,BirthDate,NewField123211,NewField121,BirrhDate1,NewField112,NewField13,NewField122,NewField111611,NewField1261,NewField131,NewField11311,NewField111311,NewField111312,NewField111313,TCNo,NewField1313111,Sex};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MATERIALGroup : TTReportGroup
        {
            public PathologyRequestReport MyParentReport
            {
                get { return (PathologyRequestReport)ParentReport; }
            }

            new public MATERIALGroupBody Body()
            {
                return (MATERIALGroupBody)_body;
            }
            public TTReportField NUMUMEALIMTARIH { get {return Body().NUMUMEALIMTARIH;} }
            public TTReportField ORGAN { get {return Body().ORGAN;} }
            public TTReportField MATOZELLIK { get {return Body().MATOZELLIK;} }
            public TTReportField ALINMASEKLI { get {return Body().ALINMASEKLI;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField BULGU { get {return Body().BULGU;} }
            public MATERIALGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MATERIALGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class>("GetPathologyMaterialsByRequestNQL", PathologyMaterial.GetPathologyMaterialsByRequestNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MATERIALGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MATERIALGroupBody : TTReportSection
            {
                public PathologyRequestReport MyParentReport
                {
                    get { return (PathologyRequestReport)ParentReport; }
                }
                
                public TTReportField NUMUMEALIMTARIH;
                public TTReportField ORGAN;
                public TTReportField MATOZELLIK;
                public TTReportField ALINMASEKLI;
                public TTReportField ACIKLAMA;
                public TTReportField BULGU; 
                public MATERIALGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    NUMUMEALIMTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 37, 6, false);
                    NUMUMEALIMTARIH.Name = "NUMUMEALIMTARIH";
                    NUMUMEALIMTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMUMEALIMTARIH.TextFormat = @"dd/MM/yyyy";
                    NUMUMEALIMTARIH.Value = @"{#SAMPLETAKENDATE#}";

                    ORGAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 69, 6, false);
                    ORGAN.Name = "ORGAN";
                    ORGAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORGAN.MultiLine = EvetHayirEnum.ehEvet;
                    ORGAN.NoClip = EvetHayirEnum.ehEvet;
                    ORGAN.WordBreak = EvetHayirEnum.ehEvet;
                    ORGAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ORGAN.ObjectDefName = "SKRSICDOYERLESIMYERI";
                    ORGAN.DataMember = "KODTANIMI";
                    ORGAN.Value = @"{#MATERIALYER#}";

                    MATOZELLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 1, 108, 6, false);
                    MATOZELLIK.Name = "MATOZELLIK";
                    MATOZELLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATOZELLIK.MultiLine = EvetHayirEnum.ehEvet;
                    MATOZELLIK.NoClip = EvetHayirEnum.ehEvet;
                    MATOZELLIK.WordBreak = EvetHayirEnum.ehEvet;
                    MATOZELLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    MATOZELLIK.ObjectDefName = "SKRSNumuneAlindigiDokununTemelOzelligi";
                    MATOZELLIK.DataMember = "ADI";
                    MATOZELLIK.Value = @"{#MATERIALOZELLIK#}";

                    ALINMASEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 1, 140, 6, false);
                    ALINMASEKLI.Name = "ALINMASEKLI";
                    ALINMASEKLI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALINMASEKLI.MultiLine = EvetHayirEnum.ehEvet;
                    ALINMASEKLI.NoClip = EvetHayirEnum.ehEvet;
                    ALINMASEKLI.WordBreak = EvetHayirEnum.ehEvet;
                    ALINMASEKLI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ALINMASEKLI.ObjectDefName = "SKRSNumuneAlinmaSekli";
                    ALINMASEKLI.DataMember = "ADI";
                    ALINMASEKLI.Value = @"{#ALINMASEKLI#}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 214, 6, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.Value = @"{#ACIKLAMA#}";

                    BULGU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 1, 186, 6, false);
                    BULGU.Name = "BULGU";
                    BULGU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BULGU.MultiLine = EvetHayirEnum.ehEvet;
                    BULGU.NoClip = EvetHayirEnum.ehEvet;
                    BULGU.WordBreak = EvetHayirEnum.ehEvet;
                    BULGU.ExpandTabs = EvetHayirEnum.ehEvet;
                    BULGU.Value = @"{#KLINIKBULGU#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class dataset_GetPathologyMaterialsByRequestNQL = ParentGroup.rsGroup.GetCurrentRecord<PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class>(0);
                    NUMUMEALIMTARIH.CalcValue = (dataset_GetPathologyMaterialsByRequestNQL != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByRequestNQL.Sampletakendate) : "");
                    ORGAN.CalcValue = (dataset_GetPathologyMaterialsByRequestNQL != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByRequestNQL.Materialyer) : "");
                    ORGAN.PostFieldValueCalculation();
                    MATOZELLIK.CalcValue = (dataset_GetPathologyMaterialsByRequestNQL != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByRequestNQL.Materialozellik) : "");
                    MATOZELLIK.PostFieldValueCalculation();
                    ALINMASEKLI.CalcValue = (dataset_GetPathologyMaterialsByRequestNQL != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByRequestNQL.Alinmasekli) : "");
                    ALINMASEKLI.PostFieldValueCalculation();
                    ACIKLAMA.CalcValue = (dataset_GetPathologyMaterialsByRequestNQL != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByRequestNQL.Aciklama) : "");
                    BULGU.CalcValue = (dataset_GetPathologyMaterialsByRequestNQL != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByRequestNQL.Klinikbulgu) : "");
                    return new TTReportObject[] { NUMUMEALIMTARIH,ORGAN,MATOZELLIK,ALINMASEKLI,ACIKLAMA,BULGU};
                }
            }

        }

        public MATERIALGroup MATERIAL;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PathologyRequestReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            MATERIAL = new MATERIALGroup(HEADER,"MATERIAL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYREQUESTREPORT";
            Caption = "Patoloji İstek Formu";
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
            fd.TextFont.Name = "Courier New";
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