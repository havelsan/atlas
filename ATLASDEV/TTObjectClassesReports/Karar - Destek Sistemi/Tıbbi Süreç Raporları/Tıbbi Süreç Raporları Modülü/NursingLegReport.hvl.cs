
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
    /// Hemşirelik Bacak Ölçüm Raporu
    /// </summary>
    public partial class NursingLegReport : TTReport
    {
#region Methods
   public int appointmentCount =  0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingLegReport MyParentReport
            {
                get { return (NursingLegReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField LBL_TARIH { get {return Header().LBL_TARIH;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField LABELK { get {return Header().LABELK;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField XXXXXXBaslik { get {return Header().XXXXXXBaslik;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField LBL_TARIH2 { get {return Header().LBL_TARIH2;} }
            public TTReportField TARIH2 { get {return Header().TARIH2;} }
            public TTReportField BIRIMLBL { get {return Header().BIRIMLBL;} }
            public TTReportField Name { get {return Header().Name;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField182 { get {return Header().NewField182;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public TTReportField BTSTARIH { get {return Header().BTSTARIH;} }
            public TTReportField LABELK1 { get {return Header().LABELK1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
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
                public NursingLegReport MyParentReport
                {
                    get { return (NursingLegReport)ParentReport; }
                }
                
                public TTReportField LBL_TARIH;
                public TTReportShape NewLine1;
                public TTReportField LABELK;
                public TTReportField TARIH1;
                public TTReportField NewField18;
                public TTReportField XXXXXXBaslik;
                public TTReportField LOGO;
                public TTReportField LBL_TARIH2;
                public TTReportField TARIH2;
                public TTReportField BIRIMLBL;
                public TTReportField Name;
                public TTReportField NewField181;
                public TTReportField NewField182;
                public TTReportField BirthDate;
                public TTReportField BTSTARIH;
                public TTReportField LABELK1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 70;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 64, 50, 68, false);
                    LBL_TARIH.Name = "LBL_TARIH";
                    LBL_TARIH.TextFont.Name = "Arial Narrow";
                    LBL_TARIH.TextFont.Size = 8;
                    LBL_TARIH.TextFont.Bold = true;
                    LBL_TARIH.Value = @"Tarihi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 70, 183, 70, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine1.DrawWidth = 2;

                    LABELK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 64, 115, 68, false);
                    LABELK.Name = "LABELK";
                    LABELK.TextFont.Name = "Arial Narrow";
                    LABELK.TextFont.Size = 8;
                    LABELK.TextFont.Bold = true;
                    LABELK.Value = @"Sağ Bacak Ölçümü";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 49, 29, 53, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.TextFont.Name = "Arial Narrow";
                    TARIH1.TextFont.Size = 8;
                    TARIH1.TextFont.Bold = true;
                    TARIH1.Value = @"Doğum Tarihi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 49, 32, 53, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 8;
                    NewField18.Value = @":";

                    XXXXXXBaslik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 6, 203, 40, false);
                    XXXXXXBaslik.Name = "XXXXXXBaslik";
                    XXXXXXBaslik.DrawWidth = 2;
                    XXXXXXBaslik.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBaslik.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBaslik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBaslik.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBaslik.TextFont.Name = "Arial Narrow";
                    XXXXXXBaslik.TextFont.Size = 11;
                    XXXXXXBaslik.TextFont.Bold = true;
                    XXXXXXBaslik.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue (""HOSPITALCITY"", """") + ""\r\n"" + ""Hemşirelik Bacak Ölçüm Raporu"";";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 38, 25, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.Value = @"";

                    LBL_TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 64, 15, 68, false);
                    LBL_TARIH2.Name = "LBL_TARIH2";
                    LBL_TARIH2.TextFont.Name = "Arial Narrow";
                    LBL_TARIH2.TextFont.Size = 8;
                    LBL_TARIH2.TextFont.Bold = true;
                    LBL_TARIH2.Value = @"Sıra";

                    TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 53, 29, 57, false);
                    TARIH2.Name = "TARIH2";
                    TARIH2.TextFont.Name = "Arial Narrow";
                    TARIH2.TextFont.Size = 8;
                    TARIH2.TextFont.Bold = true;
                    TARIH2.Value = @"Tanısı";

                    BIRIMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 45, 29, 49, false);
                    BIRIMLBL.Name = "BIRIMLBL";
                    BIRIMLBL.TextFont.Name = "Arial Narrow";
                    BIRIMLBL.TextFont.Size = 8;
                    BIRIMLBL.TextFont.Bold = true;
                    BIRIMLBL.Value = @"Adı Soyadı";

                    Name = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 45, 111, 49, false);
                    Name.Name = "Name";
                    Name.FieldType = ReportFieldTypeEnum.ftVariable;
                    Name.NoClip = EvetHayirEnum.ehEvet;
                    Name.TextFont.Name = "Arial Narrow";
                    Name.TextFont.Size = 8;
                    Name.Value = @"";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 45, 32, 49, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.Size = 8;
                    NewField181.Value = @":";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 53, 32, 57, false);
                    NewField182.Name = "NewField182";
                    NewField182.TextFont.Name = "Arial Narrow";
                    NewField182.TextFont.Size = 8;
                    NewField182.Value = @":";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 49, 111, 53, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthDate.NoClip = EvetHayirEnum.ehEvet;
                    BirthDate.TextFont.Name = "Arial Narrow";
                    BirthDate.TextFont.Size = 8;
                    BirthDate.Value = @"";

                    BTSTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 53, 111, 57, false);
                    BTSTARIH.Name = "BTSTARIH";
                    BTSTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    BTSTARIH.NoClip = EvetHayirEnum.ehEvet;
                    BTSTARIH.TextFont.Name = "Arial Narrow";
                    BTSTARIH.TextFont.Size = 8;
                    BTSTARIH.Value = @"";

                    LABELK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 64, 182, 68, false);
                    LABELK1.Name = "LABELK1";
                    LABELK1.TextFont.Name = "Arial Narrow";
                    LABELK1.TextFont.Size = 8;
                    LABELK1.TextFont.Bold = true;
                    LABELK1.Value = @"Sol Bacak Ölçümü";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_TARIH.CalcValue = LBL_TARIH.Value;
                    LABELK.CalcValue = LABELK.Value;
                    TARIH1.CalcValue = TARIH1.Value;
                    NewField18.CalcValue = NewField18.Value;
                    LOGO.CalcValue = @"";
                    LBL_TARIH2.CalcValue = LBL_TARIH2.Value;
                    TARIH2.CalcValue = TARIH2.Value;
                    BIRIMLBL.CalcValue = BIRIMLBL.Value;
                    Name.CalcValue = @"";
                    NewField181.CalcValue = NewField181.Value;
                    NewField182.CalcValue = NewField182.Value;
                    BirthDate.CalcValue = @"";
                    BTSTARIH.CalcValue = @"";
                    LABELK1.CalcValue = LABELK1.Value;
                    XXXXXXBaslik.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue ("HOSPITALCITY", "") + "\r\n" + "Hemşirelik Bacak Ölçüm Raporu";;
                    return new TTReportObject[] { LBL_TARIH,LABELK,TARIH1,NewField18,LOGO,LBL_TARIH2,TARIH2,BIRIMLBL,Name,NewField181,NewField182,BirthDate,BTSTARIH,LABELK1,XXXXXXBaslik};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingLegReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication measurement = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
            this.Name.CalcValue = measurement.Episode.Patient.Name +" "+ measurement.Episode.Patient.Surname;
            this.BirthDate.CalcValue = measurement.Episode.Patient.BirthDate.ToString();
            this.BTSTARIH.CalcValue = measurement?.Episode?.Diagnosis[0]?.Diagnose?.Name;  
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingLegReport MyParentReport
                {
                    get { return (NursingLegReport)ParentReport; }
                }
                
                public TTReportShape NewLine2;
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER;
                public TTReportField USERNAME; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 291, 1, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine2.DrawWidth = 2;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 145, 7, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.TextFont.Size = 8;
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 2, 290, 7, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.Name = "Arial Narrow";
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 57, 12, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Name = "Arial Narrow";
                    USERNAME.TextFont.Size = 8;
                    USERNAME.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    USERNAME.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString() + @" - " + MyParentReport.HEADER.USERNAME.CalcValue;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { USERNAME,PRINTDATE,PAGENUMBER};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingLegReport MyParentReport
            {
                get { return (NursingLegReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField Alt { get {return Body().Alt;} }
            public TTReportField Ust { get {return Body().Ust;} }
            public TTReportField Alt1 { get {return Body().Alt1;} }
            public TTReportField Ust1 { get {return Body().Ust1;} }
            public TTReportField LOWERLEFTLEG_GetNursingLegMeasurements { get {return Body().LOWERLEFTLEG_GetNursingLegMeasurements;} }
            public TTReportField LOWERRIGHTLEG_GetNursingLegMeasurements { get {return Body().LOWERRIGHTLEG_GetNursingLegMeasurements;} }
            public TTReportField UPPERLEFTLEG_GetNursingLegMeasurements { get {return Body().UPPERLEFTLEG_GetNursingLegMeasurements;} }
            public TTReportField UPPERRIGHTLEG_GetNursingLegMeasurements { get {return Body().UPPERRIGHTLEG_GetNursingLegMeasurements;} }
            public TTReportField APPLICATIONDATE { get {return Body().APPLICATIONDATE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
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
                list[0] = new TTReportNqlData<NursingLegMeasurement.GetNursingLegMeasurements_Class>("GetNursingLegMeasurements", NursingLegMeasurement.GetNursingLegMeasurements((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NursingLegReport MyParentReport
                {
                    get { return (NursingLegReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField OBJECTID;
                public TTReportField Alt;
                public TTReportField Ust;
                public TTReportField Alt1;
                public TTReportField Ust1;
                public TTReportField LOWERLEFTLEG_GetNursingLegMeasurements;
                public TTReportField LOWERRIGHTLEG_GetNursingLegMeasurements;
                public TTReportField UPPERLEFTLEG_GetNursingLegMeasurements;
                public TTReportField UPPERRIGHTLEG_GetNursingLegMeasurements;
                public TTReportField APPLICATIONDATE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 15, 10, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.NoClip = EvetHayirEnum.ehEvet;
                    COUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial Narrow";
                    COUNT.TextFont.Size = 8;
                    COUNT.Value = @"{@counter@}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 331, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID.NoClip = EvetHayirEnum.ehEvet;
                    OBJECTID.ExpandTabs = EvetHayirEnum.ehEvet;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    Alt = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 60, 5, false);
                    Alt.Name = "Alt";
                    Alt.FieldType = ReportFieldTypeEnum.ftVariable;
                    Alt.NoClip = EvetHayirEnum.ehEvet;
                    Alt.TextFont.Name = "Arial Narrow";
                    Alt.TextFont.Size = 8;
                    Alt.TextFont.Bold = true;
                    Alt.Value = @"Alt";

                    Ust = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 5, 60, 10, false);
                    Ust.Name = "Ust";
                    Ust.FieldType = ReportFieldTypeEnum.ftVariable;
                    Ust.NoClip = EvetHayirEnum.ehEvet;
                    Ust.TextFont.Name = "Arial Narrow";
                    Ust.TextFont.Size = 8;
                    Ust.TextFont.Bold = true;
                    Ust.Value = @"Ust";

                    Alt1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 127, 5, false);
                    Alt1.Name = "Alt1";
                    Alt1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Alt1.NoClip = EvetHayirEnum.ehEvet;
                    Alt1.TextFont.Name = "Arial Narrow";
                    Alt1.TextFont.Size = 8;
                    Alt1.TextFont.Bold = true;
                    Alt1.Value = @"Alt";

                    Ust1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 5, 127, 10, false);
                    Ust1.Name = "Ust1";
                    Ust1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Ust1.NoClip = EvetHayirEnum.ehEvet;
                    Ust1.TextFont.Name = "Arial Narrow";
                    Ust1.TextFont.Size = 8;
                    Ust1.TextFont.Bold = true;
                    Ust1.Value = @"Ust";

                    LOWERLEFTLEG_GetNursingLegMeasurements = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 183, 5, false);
                    LOWERLEFTLEG_GetNursingLegMeasurements.Name = "LOWERLEFTLEG_GetNursingLegMeasurements";
                    LOWERLEFTLEG_GetNursingLegMeasurements.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOWERLEFTLEG_GetNursingLegMeasurements.TextFont.Name = "Arial Narrow";
                    LOWERLEFTLEG_GetNursingLegMeasurements.TextFont.CharSet = 1;
                    LOWERLEFTLEG_GetNursingLegMeasurements.Value = @"{#LOWERLEFTLEG!GetNursingLegMeasurements#}";

                    LOWERRIGHTLEG_GetNursingLegMeasurements = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 116, 5, false);
                    LOWERRIGHTLEG_GetNursingLegMeasurements.Name = "LOWERRIGHTLEG_GetNursingLegMeasurements";
                    LOWERRIGHTLEG_GetNursingLegMeasurements.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOWERRIGHTLEG_GetNursingLegMeasurements.TextFont.Name = "Arial Narrow";
                    LOWERRIGHTLEG_GetNursingLegMeasurements.TextFont.CharSet = 1;
                    LOWERRIGHTLEG_GetNursingLegMeasurements.Value = @"{#LOWERRIGHTLEG!GetNursingLegMeasurements#}";

                    UPPERLEFTLEG_GetNursingLegMeasurements = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 5, 183, 10, false);
                    UPPERLEFTLEG_GetNursingLegMeasurements.Name = "UPPERLEFTLEG_GetNursingLegMeasurements";
                    UPPERLEFTLEG_GetNursingLegMeasurements.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPPERLEFTLEG_GetNursingLegMeasurements.TextFont.Name = "Arial Narrow";
                    UPPERLEFTLEG_GetNursingLegMeasurements.TextFont.CharSet = 1;
                    UPPERLEFTLEG_GetNursingLegMeasurements.Value = @"{#UPPERLEFTLEG!GetNursingLegMeasurements#}";

                    UPPERRIGHTLEG_GetNursingLegMeasurements = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 5, 115, 10, false);
                    UPPERRIGHTLEG_GetNursingLegMeasurements.Name = "UPPERRIGHTLEG_GetNursingLegMeasurements";
                    UPPERRIGHTLEG_GetNursingLegMeasurements.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPPERRIGHTLEG_GetNursingLegMeasurements.TextFont.Name = "Arial Narrow";
                    UPPERRIGHTLEG_GetNursingLegMeasurements.TextFont.CharSet = 1;
                    UPPERRIGHTLEG_GetNursingLegMeasurements.Value = @"{#UPPERRIGHTLEG!GetNursingLegMeasurements#}";

                    APPLICATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 50, 10, false);
                    APPLICATIONDATE.Name = "APPLICATIONDATE";
                    APPLICATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPLICATIONDATE.TextFont.Name = "Arial Narrow";
                    APPLICATIONDATE.TextFont.CharSet = 1;
                    APPLICATIONDATE.Value = @"{#APPLICATIONDATE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 184, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 11, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 11, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 184, 0, 184, 11, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingLegMeasurement.GetNursingLegMeasurements_Class dataset_GetNursingLegMeasurements = ParentGroup.rsGroup.GetCurrentRecord<NursingLegMeasurement.GetNursingLegMeasurements_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    OBJECTID.CalcValue = (dataset_GetNursingLegMeasurements != null ? Globals.ToStringCore(dataset_GetNursingLegMeasurements.ObjectID) : "");
                    Alt.CalcValue = @"Alt";
                    Ust.CalcValue = @"Ust";
                    Alt1.CalcValue = @"Alt";
                    Ust1.CalcValue = @"Ust";
                    LOWERLEFTLEG_GetNursingLegMeasurements.CalcValue = (dataset_GetNursingLegMeasurements != null ? Globals.ToStringCore(dataset_GetNursingLegMeasurements.LowerLeftLeg) : "");
                    LOWERRIGHTLEG_GetNursingLegMeasurements.CalcValue = (dataset_GetNursingLegMeasurements != null ? Globals.ToStringCore(dataset_GetNursingLegMeasurements.LowerRightLeg) : "");
                    UPPERLEFTLEG_GetNursingLegMeasurements.CalcValue = (dataset_GetNursingLegMeasurements != null ? Globals.ToStringCore(dataset_GetNursingLegMeasurements.UpperLeftLeg) : "");
                    UPPERRIGHTLEG_GetNursingLegMeasurements.CalcValue = (dataset_GetNursingLegMeasurements != null ? Globals.ToStringCore(dataset_GetNursingLegMeasurements.UpperRightLeg) : "");
                    APPLICATIONDATE.CalcValue = (dataset_GetNursingLegMeasurements != null ? Globals.ToStringCore(dataset_GetNursingLegMeasurements.ApplicationDate) : "");
                    return new TTReportObject[] { COUNT,OBJECTID,Alt,Ust,Alt1,Ust1,LOWERLEFTLEG_GetNursingLegMeasurements,LOWERRIGHTLEG_GetNursingLegMeasurements,UPPERLEFTLEG_GetNursingLegMeasurements,UPPERRIGHTLEG_GetNursingLegMeasurements,APPLICATIONDATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingLegReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGLEGREPORT";
            Caption = "Hemşirelik Bacak Ölçüm Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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
            fd.TextFont.CharSet = 162;
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