
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
    /// Halk Sağlığı Tetkik Sonuç Raporu
    /// </summary>
    public partial class CommunityHealthResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public CommunityHealthResultReport MyParentReport
            {
                get { return (CommunityHealthResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField lblSamplePlace { get {return Header().lblSamplePlace;} }
            public TTReportField lblActiondate { get {return Header().lblActiondate;} }
            public TTReportField lblRaporTarihi { get {return Header().lblRaporTarihi;} }
            public TTReportField dotsPatientName1 { get {return Header().dotsPatientName1;} }
            public TTReportField dotsPatientSex1 { get {return Header().dotsPatientSex1;} }
            public TTReportField dotsPatientFatherName1 { get {return Header().dotsPatientFatherName1;} }
            public TTReportField lblSamleType { get {return Header().lblSamleType;} }
            public TTReportField dotsPatientStatus1 { get {return Header().dotsPatientStatus1;} }
            public TTReportField SamplePlace { get {return Header().SamplePlace;} }
            public TTReportField ActionDate { get {return Header().ActionDate;} }
            public TTReportField RaportDate { get {return Header().RaportDate;} }
            public TTReportField SampleType { get {return Header().SampleType;} }
            public TTReportField Tasnif_Dışı1 { get {return Header().Tasnif_Dışı1;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField EVRAKNO1 { get {return Header().EVRAKNO1;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField PrintDate1 { get {return Header().PrintDate1;} }
            public TTReportField Ek { get {return Header().Ek;} }
            public TTReportField ToplamMeq { get {return Header().ToplamMeq;} }
            public TTReportField Tasnif_Dışı { get {return Footer().Tasnif_Dışı;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField ApprovedBy { get {return Footer().ApprovedBy;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>("GetCommunityHealthResultReportNQL", CommunityHealthProcedure.GetCommunityHealthResultReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public CommunityHealthResultReport MyParentReport
                {
                    get { return (CommunityHealthResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField6;
                public TTReportField lblSamplePlace;
                public TTReportField lblActiondate;
                public TTReportField lblRaporTarihi;
                public TTReportField dotsPatientName1;
                public TTReportField dotsPatientSex1;
                public TTReportField dotsPatientFatherName1;
                public TTReportField lblSamleType;
                public TTReportField dotsPatientStatus1;
                public TTReportField SamplePlace;
                public TTReportField ActionDate;
                public TTReportField RaportDate;
                public TTReportField SampleType;
                public TTReportField Tasnif_Dışı1;
                public TTReportField NewField141;
                public TTReportField EVRAKNO1;
                public TTReportField NewField16;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField PrintDate1;
                public TTReportField Ek;
                public TTReportField ToplamMeq; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 48, 197, 53, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 13;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"HALK SAĞLIĞI SONUÇ RAPORU";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 3, 244, 9, false);
                    NewField6.Name = "NewField6";
                    NewField6.Visible = EvetHayirEnum.ehHayir;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    lblSamplePlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 20, 55, 25, false);
                    lblSamplePlace.Name = "lblSamplePlace";
                    lblSamplePlace.TextFont.Name = "Arial";
                    lblSamplePlace.TextFont.Size = 9;
                    lblSamplePlace.TextFont.CharSet = 162;
                    lblSamplePlace.Value = @"Numunenin Alındığı Yer";

                    lblActiondate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 25, 55, 30, false);
                    lblActiondate.Name = "lblActiondate";
                    lblActiondate.TextFont.Name = "Arial";
                    lblActiondate.TextFont.Size = 9;
                    lblActiondate.TextFont.CharSet = 162;
                    lblActiondate.Value = @"Labaratuvara Geliş Tarihi";

                    lblRaporTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 30, 55, 35, false);
                    lblRaporTarihi.Name = "lblRaporTarihi";
                    lblRaporTarihi.TextFont.Name = "Arial";
                    lblRaporTarihi.TextFont.Size = 9;
                    lblRaporTarihi.TextFont.CharSet = 162;
                    lblRaporTarihi.Value = @"Rapor Tarihi";

                    dotsPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 20, 58, 25, false);
                    dotsPatientName1.Name = "dotsPatientName1";
                    dotsPatientName1.TextFont.Name = "Arial";
                    dotsPatientName1.TextFont.Size = 9;
                    dotsPatientName1.TextFont.CharSet = 162;
                    dotsPatientName1.Value = @":";

                    dotsPatientSex1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 25, 58, 30, false);
                    dotsPatientSex1.Name = "dotsPatientSex1";
                    dotsPatientSex1.TextFont.Name = "Arial";
                    dotsPatientSex1.TextFont.Size = 9;
                    dotsPatientSex1.TextFont.CharSet = 162;
                    dotsPatientSex1.Value = @":";

                    dotsPatientFatherName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 30, 58, 35, false);
                    dotsPatientFatherName1.Name = "dotsPatientFatherName1";
                    dotsPatientFatherName1.TextFont.Name = "Arial";
                    dotsPatientFatherName1.TextFont.Size = 9;
                    dotsPatientFatherName1.TextFont.CharSet = 162;
                    dotsPatientFatherName1.Value = @":";

                    lblSamleType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 35, 55, 45, false);
                    lblSamleType.Name = "lblSamleType";
                    lblSamleType.MultiLine = EvetHayirEnum.ehEvet;
                    lblSamleType.WordBreak = EvetHayirEnum.ehEvet;
                    lblSamleType.TextFont.Name = "Arial";
                    lblSamleType.TextFont.Size = 9;
                    lblSamleType.TextFont.CharSet = 162;
                    lblSamleType.Value = @"Numuneler ve Talep Edilen Analizler";

                    dotsPatientStatus1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 35, 58, 40, false);
                    dotsPatientStatus1.Name = "dotsPatientStatus1";
                    dotsPatientStatus1.TextFont.Name = "Arial";
                    dotsPatientStatus1.TextFont.Size = 9;
                    dotsPatientStatus1.TextFont.CharSet = 162;
                    dotsPatientStatus1.Value = @":";

                    SamplePlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 20, 197, 25, false);
                    SamplePlace.Name = "SamplePlace";
                    SamplePlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    SamplePlace.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SamplePlace.MultiLine = EvetHayirEnum.ehEvet;
                    SamplePlace.TextFont.Name = "Arial";
                    SamplePlace.TextFont.Size = 9;
                    SamplePlace.TextFont.CharSet = 162;
                    SamplePlace.Value = @"{#SAMPLEPLACE#}";

                    ActionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 25, 197, 30, false);
                    ActionDate.Name = "ActionDate";
                    ActionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionDate.TextFormat = @"dd/MM/yyyy";
                    ActionDate.MultiLine = EvetHayirEnum.ehEvet;
                    ActionDate.TextFont.Name = "Arial";
                    ActionDate.TextFont.Size = 9;
                    ActionDate.TextFont.CharSet = 162;
                    ActionDate.Value = @"{#ACTIONDATE#}";

                    RaportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 30, 197, 35, false);
                    RaportDate.Name = "RaportDate";
                    RaportDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    RaportDate.TextFormat = @"dd/MM/yyyy";
                    RaportDate.MultiLine = EvetHayirEnum.ehEvet;
                    RaportDate.TextFont.Name = "Arial";
                    RaportDate.TextFont.Size = 9;
                    RaportDate.TextFont.CharSet = 162;
                    RaportDate.Value = @"{#REPORTDATE#}";

                    SampleType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 35, 197, 47, false);
                    SampleType.Name = "SampleType";
                    SampleType.FieldType = ReportFieldTypeEnum.ftVariable;
                    SampleType.TextFormat = @"Long Time";
                    SampleType.MultiLine = EvetHayirEnum.ehEvet;
                    SampleType.WordBreak = EvetHayirEnum.ehEvet;
                    SampleType.ExpandTabs = EvetHayirEnum.ehEvet;
                    SampleType.TextFont.Name = "Arial";
                    SampleType.TextFont.Size = 9;
                    SampleType.TextFont.CharSet = 162;
                    SampleType.Value = @"{#DESCRIPTION#}";

                    Tasnif_Dışı1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 33, 7, false);
                    Tasnif_Dışı1.Name = "Tasnif_Dışı1";
                    Tasnif_Dışı1.TextFont.Name = "Arial Narrow";
                    Tasnif_Dışı1.TextFont.Size = 11;
                    Tasnif_Dışı1.TextFont.Bold = true;
                    Tasnif_Dışı1.TextFont.Underline = true;
                    Tasnif_Dışı1.TextFont.CharSet = 162;
                    Tasnif_Dışı1.Value = @"TASNİF DIŞI";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 10, 25, 14, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"SAĞ.KRL:";

                    EVRAKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 10, 148, 15, false);
                    EVRAKNO1.Name = "EVRAKNO1";
                    EVRAKNO1.FieldType = ReportFieldTypeEnum.ftExpression;
                    EVRAKNO1.TextFont.Name = "Arial";
                    EVRAKNO1.TextFont.CharSet = 162;
                    EVRAKNO1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""COMMUNITYHEALTHREPORTDOCUMENTNUMBER"","""")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 10, 25, 14, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 10, 39, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"HALK SAĞ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 10, 42, 15, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 10, 197, 15, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"MMMM/yyyy";
                    PrintDate1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    Ek = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 2, 197, 7, false);
                    Ek.Name = "Ek";
                    Ek.TextFormat = @"Short Date";
                    Ek.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Ek.TextFont.Name = "Arial";
                    Ek.TextFont.CharSet = 162;
                    Ek.Value = @"Ek-A";

                    ToplamMeq = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 42, 252, 48, false);
                    ToplamMeq.Name = "ToplamMeq";
                    ToplamMeq.Visible = EvetHayirEnum.ehHayir;
                    ToplamMeq.FieldType = ReportFieldTypeEnum.ftVariable;
                    ToplamMeq.TextFont.Name = "Arial Narrow";
                    ToplamMeq.TextFont.Size = 11;
                    ToplamMeq.TextFont.CharSet = 162;
                    ToplamMeq.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class dataset_GetCommunityHealthResultReportNQL = ParentGroup.rsGroup.GetCurrentRecord<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    lblSamplePlace.CalcValue = lblSamplePlace.Value;
                    lblActiondate.CalcValue = lblActiondate.Value;
                    lblRaporTarihi.CalcValue = lblRaporTarihi.Value;
                    dotsPatientName1.CalcValue = dotsPatientName1.Value;
                    dotsPatientSex1.CalcValue = dotsPatientSex1.Value;
                    dotsPatientFatherName1.CalcValue = dotsPatientFatherName1.Value;
                    lblSamleType.CalcValue = lblSamleType.Value;
                    dotsPatientStatus1.CalcValue = dotsPatientStatus1.Value;
                    SamplePlace.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.SamplePlace) : "");
                    ActionDate.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.ActionDate) : "");
                    RaportDate.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.ReportDate) : "");
                    SampleType.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.Description) : "");
                    Tasnif_Dışı1.CalcValue = Tasnif_Dışı1.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    Ek.CalcValue = Ek.Value;
                    ToplamMeq.CalcValue = @"";
                    EVRAKNO1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("COMMUNITYHEALTHREPORTDOCUMENTNUMBER","");
                    return new TTReportObject[] { NewField,NewField6,lblSamplePlace,lblActiondate,lblRaporTarihi,dotsPatientName1,dotsPatientSex1,dotsPatientFatherName1,lblSamleType,dotsPatientStatus1,SamplePlace,ActionDate,RaportDate,SampleType,Tasnif_Dışı1,NewField141,NewField16,NewField121,NewField1121,PrintDate1,Ek,ToplamMeq,EVRAKNO1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((CommunityHealthResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CommunityHealthRequest communityHealthRequest = (CommunityHealthRequest)objectContext.GetObject(new Guid(objectID),"CommunityHealthRequest");
            this.ToplamMeq.CalcValue= communityHealthRequest.ToplamMeq.ToString();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public CommunityHealthResultReport MyParentReport
                {
                    get { return (CommunityHealthResultReport)ParentReport; }
                }
                
                public TTReportField Tasnif_Dışı;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber;
                public TTReportField NewField1111;
                public TTReportField ApprovedBy; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    Tasnif_Dışı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 17, 33, 23, false);
                    Tasnif_Dışı.Name = "Tasnif_Dışı";
                    Tasnif_Dışı.TextFont.Name = "Arial Narrow";
                    Tasnif_Dışı.TextFont.Size = 11;
                    Tasnif_Dışı.TextFont.Bold = true;
                    Tasnif_Dışı.TextFont.Underline = true;
                    Tasnif_Dışı.TextFont.CharSet = 162;
                    Tasnif_Dışı.Value = @"TASNİF DIŞI";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 24, 198, 24, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 25, 36, 30, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PrintDate.TextFont.Name = "Microsoft Sans Serif";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 25, 137, 30, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UserName.TextFont.Name = "Microsoft Sans Serif";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 25, 197, 30, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Microsoft Sans Serif";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 275, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Onaylayan Uzman";

                    ApprovedBy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 197, 22, false);
                    ApprovedBy.Name = "ApprovedBy";
                    ApprovedBy.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ApprovedBy.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedBy.NoClip = EvetHayirEnum.ehEvet;
                    ApprovedBy.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedBy.TextFont.Name = "Microsoft Sans Serif";
                    ApprovedBy.TextFont.Size = 8;
                    ApprovedBy.TextFont.CharSet = 162;
                    ApprovedBy.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class dataset_GetCommunityHealthResultReportNQL = ParentGroup.rsGroup.GetCurrentRecord<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(0);
                    Tasnif_Dışı.CalcValue = Tasnif_Dışı.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField1111.CalcValue = NewField1111.Value;
                    ApprovedBy.CalcValue = ApprovedBy.Value;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { Tasnif_Dışı,PrintDate,PageNumber,NewField1111,ApprovedBy,UserName};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((CommunityHealthResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CommunityHealthRequest reqObject = (CommunityHealthRequest)context.GetObject(new Guid(sObjectID),"CommunityHealthRequest");
            
            ResUser approvedBy = reqObject.ApprovalDoctor;
  
            string CrLf = "\r\n";
            string SB = "";
            string TextContext = "";
                        
            //ApprovedBy
            if(approvedBy != null)
            {
                SB = approvedBy.SignatureBlock; //approvedBy.Rank == null ? "" : approvedBy.Rank.Name;
                TextContext = SB + CrLf ;
                this.ApprovedBy.CalcValue = TextContext;
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class KategoriGroup : TTReportGroup
        {
            public CommunityHealthResultReport MyParentReport
            {
                get { return (CommunityHealthResultReport)ParentReport; }
            }

            new public KategoriGroupHeader Header()
            {
                return (KategoriGroupHeader)_header;
            }

            new public KategoriGroupFooter Footer()
            {
                return (KategoriGroupFooter)_footer;
            }

            public TTReportField Kategory { get {return Header().Kategory;} }
            public TTReportField Analiz { get {return Header().Analiz;} }
            public TTReportField Birim { get {return Header().Birim;} }
            public TTReportField Sonuç { get {return Header().Sonuç;} }
            public TTReportField meqBaslik { get {return Header().meqBaslik;} }
            public TTReportField mvalBaslik { get {return Header().mvalBaslik;} }
            public TTReportField CalcMeqandMval { get {return Header().CalcMeqandMval;} }
            public KategoriGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KategoriGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class dataSet_GetCommunityHealthResultReportNQL = ParentGroup.rsGroup.GetCurrentRecord<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(0);    
                return new object[] {(dataSet_GetCommunityHealthResultReportNQL==null ? null : dataSet_GetCommunityHealthResultReportNQL.Requestobjectid)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new KategoriGroupHeader(this);
                _footer = new KategoriGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class KategoriGroupHeader : TTReportSection
            {
                public CommunityHealthResultReport MyParentReport
                {
                    get { return (CommunityHealthResultReport)ParentReport; }
                }
                
                public TTReportField Kategory;
                public TTReportField Analiz;
                public TTReportField Birim;
                public TTReportField Sonuç;
                public TTReportField meqBaslik;
                public TTReportField mvalBaslik;
                public TTReportField CalcMeqandMval; 
                public KategoriGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    RepeatCount = 0;
                    
                    Kategory = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 197, 6, false);
                    Kategory.Name = "Kategory";
                    Kategory.DrawStyle = DrawStyleConstants.vbSolid;
                    Kategory.FieldType = ReportFieldTypeEnum.ftVariable;
                    Kategory.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Kategory.TextFont.Name = "Arial Narrow";
                    Kategory.TextFont.Size = 12;
                    Kategory.TextFont.Bold = true;
                    Kategory.TextFont.CharSet = 162;
                    Kategory.Value = @"{#HEADER.CATEGORY#}";

                    Analiz = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 82, 12, false);
                    Analiz.Name = "Analiz";
                    Analiz.DrawStyle = DrawStyleConstants.vbSolid;
                    Analiz.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Analiz.TextFont.Name = "Arial Narrow";
                    Analiz.TextFont.CharSet = 162;
                    Analiz.Value = @"ANALİZ";

                    Birim = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 7, 109, 12, false);
                    Birim.Name = "Birim";
                    Birim.DrawStyle = DrawStyleConstants.vbSolid;
                    Birim.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Birim.TextFont.Name = "Arial Narrow";
                    Birim.TextFont.CharSet = 162;
                    Birim.Value = @"Birim";

                    Sonuç = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 7, 138, 12, false);
                    Sonuç.Name = "Sonuç";
                    Sonuç.DrawStyle = DrawStyleConstants.vbSolid;
                    Sonuç.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Sonuç.TextFont.Name = "Arial Narrow";
                    Sonuç.TextFont.CharSet = 162;
                    Sonuç.Value = @"Sonuç";

                    meqBaslik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 7, 165, 12, false);
                    meqBaslik.Name = "meqBaslik";
                    meqBaslik.DrawStyle = DrawStyleConstants.vbSolid;
                    meqBaslik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    meqBaslik.TextFont.Name = "Arial Narrow";
                    meqBaslik.TextFont.CharSet = 162;
                    meqBaslik.Value = @"meq";

                    mvalBaslik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 7, 197, 12, false);
                    mvalBaslik.Name = "mvalBaslik";
                    mvalBaslik.DrawStyle = DrawStyleConstants.vbSolid;
                    mvalBaslik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    mvalBaslik.TextFont.Name = "Arial Narrow";
                    mvalBaslik.TextFont.CharSet = 162;
                    mvalBaslik.Value = @"%mval";

                    CalcMeqandMval = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 3, 254, 8, false);
                    CalcMeqandMval.Name = "CalcMeqandMval";
                    CalcMeqandMval.Visible = EvetHayirEnum.ehHayir;
                    CalcMeqandMval.DrawStyle = DrawStyleConstants.vbSolid;
                    CalcMeqandMval.FieldType = ReportFieldTypeEnum.ftVariable;
                    CalcMeqandMval.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CalcMeqandMval.TextFont.Name = "Arial Narrow";
                    CalcMeqandMval.TextFont.Size = 12;
                    CalcMeqandMval.TextFont.CharSet = 162;
                    CalcMeqandMval.Value = @"{#HEADER.CALCMEQANDMVAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class dataset_GetCommunityHealthResultReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(0);
                    Kategory.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.Category) : "");
                    Analiz.CalcValue = Analiz.Value;
                    Birim.CalcValue = Birim.Value;
                    Sonuç.CalcValue = Sonuç.Value;
                    meqBaslik.CalcValue = meqBaslik.Value;
                    mvalBaslik.CalcValue = mvalBaslik.Value;
                    CalcMeqandMval.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.CalcMeqAndMval) : "");
                    return new TTReportObject[] { Kategory,Analiz,Birim,Sonuç,meqBaslik,mvalBaslik,CalcMeqandMval};
                }

                public override void RunScript()
                {
#region KATEGORI HEADER_Script
                    if(this.CalcMeqandMval.CalcValue == "True")
            {
                this.meqBaslik.Visible = EvetHayirEnum.ehEvet;
                this.mvalBaslik.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.meqBaslik.Visible = EvetHayirEnum.ehHayir;
                this.mvalBaslik.Visible = EvetHayirEnum.ehHayir;
            }
#endregion KATEGORI HEADER_Script
                }
            }
            public partial class KategoriGroupFooter : TTReportSection
            {
                public CommunityHealthResultReport MyParentReport
                {
                    get { return (CommunityHealthResultReport)ParentReport; }
                }
                 
                public KategoriGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public KategoriGroup Kategori;

        public partial class MAINGroup : TTReportGroup
        {
            public CommunityHealthResultReport MyParentReport
            {
                get { return (CommunityHealthResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ProcedureTestName { get {return Body().ProcedureTestName;} }
            public TTReportField Result { get {return Body().Result;} }
            public TTReportField Unit { get {return Body().Unit;} }
            public TTReportField mval { get {return Body().mval;} }
            public TTReportField Meq { get {return Body().Meq;} }
            public TTReportField TTObjectId { get {return Body().TTObjectId;} }
            public TTReportField ToplamMeq { get {return Body().ToplamMeq;} }
            public TTReportField CalcMeqandMval { get {return Body().CalcMeqandMval;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class dataSet_GetCommunityHealthResultReportNQL = ParentGroup.rsGroup.GetCurrentRecord<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(0);    
                return new object[] {(dataSet_GetCommunityHealthResultReportNQL==null ? null : dataSet_GetCommunityHealthResultReportNQL.Category)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CommunityHealthResultReport MyParentReport
                {
                    get { return (CommunityHealthResultReport)ParentReport; }
                }
                
                public TTReportField ProcedureTestName;
                public TTReportField Result;
                public TTReportField Unit;
                public TTReportField mval;
                public TTReportField Meq;
                public TTReportField TTObjectId;
                public TTReportField ToplamMeq;
                public TTReportField CalcMeqandMval; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ProcedureTestName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 82, 6, false);
                    ProcedureTestName.Name = "ProcedureTestName";
                    ProcedureTestName.DrawStyle = DrawStyleConstants.vbSolid;
                    ProcedureTestName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProcedureTestName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ProcedureTestName.MultiLine = EvetHayirEnum.ehEvet;
                    ProcedureTestName.NoClip = EvetHayirEnum.ehEvet;
                    ProcedureTestName.WordBreak = EvetHayirEnum.ehEvet;
                    ProcedureTestName.ExpandTabs = EvetHayirEnum.ehEvet;
                    ProcedureTestName.TextFont.Name = "Microsoft Sans Serif";
                    ProcedureTestName.TextFont.Size = 8;
                    ProcedureTestName.TextFont.CharSet = 162;
                    ProcedureTestName.Value = @"{#HEADER.PROCEDURENAME#}";

                    Result = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 138, 6, false);
                    Result.Name = "Result";
                    Result.DrawStyle = DrawStyleConstants.vbSolid;
                    Result.FieldType = ReportFieldTypeEnum.ftVariable;
                    Result.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Result.MultiLine = EvetHayirEnum.ehEvet;
                    Result.NoClip = EvetHayirEnum.ehEvet;
                    Result.WordBreak = EvetHayirEnum.ehEvet;
                    Result.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result.TextFont.Name = "Microsoft Sans Serif";
                    Result.TextFont.Size = 8;
                    Result.TextFont.CharSet = 162;
                    Result.Value = @"{#HEADER.RESULT#}";

                    Unit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 109, 6, false);
                    Unit.Name = "Unit";
                    Unit.DrawStyle = DrawStyleConstants.vbSolid;
                    Unit.FieldType = ReportFieldTypeEnum.ftVariable;
                    Unit.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Unit.MultiLine = EvetHayirEnum.ehEvet;
                    Unit.NoClip = EvetHayirEnum.ehEvet;
                    Unit.WordBreak = EvetHayirEnum.ehEvet;
                    Unit.ExpandTabs = EvetHayirEnum.ehEvet;
                    Unit.TextFont.Name = "Microsoft Sans Serif";
                    Unit.TextFont.Size = 8;
                    Unit.TextFont.CharSet = 162;
                    Unit.Value = @"{#HEADER.UNIT#}";

                    mval = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 196, 6, false);
                    mval.Name = "mval";
                    mval.DrawStyle = DrawStyleConstants.vbSolid;
                    mval.TextFormat = @"#,###.###";
                    mval.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    mval.MultiLine = EvetHayirEnum.ehEvet;
                    mval.NoClip = EvetHayirEnum.ehEvet;
                    mval.WordBreak = EvetHayirEnum.ehEvet;
                    mval.ExpandTabs = EvetHayirEnum.ehEvet;
                    mval.TextFont.Name = "Microsoft Sans Serif";
                    mval.TextFont.Size = 8;
                    mval.TextFont.CharSet = 162;
                    mval.Value = @"";

                    Meq = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 165, 6, false);
                    Meq.Name = "Meq";
                    Meq.DrawStyle = DrawStyleConstants.vbSolid;
                    Meq.TextFormat = @"#,###.###";
                    Meq.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Meq.MultiLine = EvetHayirEnum.ehEvet;
                    Meq.NoClip = EvetHayirEnum.ehEvet;
                    Meq.WordBreak = EvetHayirEnum.ehEvet;
                    Meq.ExpandTabs = EvetHayirEnum.ehEvet;
                    Meq.TextFont.Name = "Microsoft Sans Serif";
                    Meq.TextFont.Size = 8;
                    Meq.TextFont.CharSet = 162;
                    Meq.Value = @"";

                    TTObjectId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 245, 7, false);
                    TTObjectId.Name = "TTObjectId";
                    TTObjectId.Visible = EvetHayirEnum.ehHayir;
                    TTObjectId.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTObjectId.TextFont.Name = "Arial Narrow";
                    TTObjectId.TextFont.Size = 11;
                    TTObjectId.TextFont.CharSet = 162;
                    TTObjectId.Value = @"{#HEADER.TTOBJECTID#}";

                    ToplamMeq = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 1, 280, 7, false);
                    ToplamMeq.Name = "ToplamMeq";
                    ToplamMeq.Visible = EvetHayirEnum.ehHayir;
                    ToplamMeq.FieldType = ReportFieldTypeEnum.ftVariable;
                    ToplamMeq.TextFont.Name = "Arial Narrow";
                    ToplamMeq.TextFont.Size = 11;
                    ToplamMeq.TextFont.CharSet = 162;
                    ToplamMeq.Value = @"{%HEADER.ToplamMeq%}";

                    CalcMeqandMval = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 1, 319, 6, false);
                    CalcMeqandMval.Name = "CalcMeqandMval";
                    CalcMeqandMval.Visible = EvetHayirEnum.ehHayir;
                    CalcMeqandMval.DrawStyle = DrawStyleConstants.vbSolid;
                    CalcMeqandMval.FieldType = ReportFieldTypeEnum.ftVariable;
                    CalcMeqandMval.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CalcMeqandMval.TextFont.Name = "Arial Narrow";
                    CalcMeqandMval.TextFont.Size = 12;
                    CalcMeqandMval.TextFont.CharSet = 162;
                    CalcMeqandMval.Value = @"{#HEADER.CALCMEQANDMVAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class dataset_GetCommunityHealthResultReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<CommunityHealthProcedure.GetCommunityHealthResultReportNQL_Class>(0);
                    ProcedureTestName.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.Procedurename) : "");
                    Result.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.Result) : "");
                    Unit.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.Unit) : "");
                    mval.CalcValue = mval.Value;
                    Meq.CalcValue = Meq.Value;
                    TTObjectId.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.Ttobjectid) : "");
                    ToplamMeq.CalcValue = MyParentReport.HEADER.ToplamMeq.CalcValue;
                    CalcMeqandMval.CalcValue = (dataset_GetCommunityHealthResultReportNQL != null ? Globals.ToStringCore(dataset_GetCommunityHealthResultReportNQL.CalcMeqAndMval) : "");
                    return new TTReportObject[] { ProcedureTestName,Result,Unit,mval,Meq,TTObjectId,ToplamMeq,CalcMeqandMval};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.CalcMeqandMval.CalcValue == "True")
             {
                this.Meq.Visible = EvetHayirEnum.ehEvet;
                this.mval.Visible = EvetHayirEnum.ehEvet;
                TTObjectContext objectContext = new TTObjectContext(true);
                string objectID = this.TTObjectId.CalcValue.ToString();
                CommunityHealthProcedure communityHealthProcedure = (CommunityHealthProcedure)objectContext.GetObject(new Guid(objectID),"CommunityHealthProcedure");
                this.Meq.CalcValue= communityHealthProcedure.Meq.ToString();
                var toplamMeq = Convert.ToDouble(this.ToplamMeq.CalcValue);
                this.mval.CalcValue= (100 * communityHealthProcedure.Meq/ toplamMeq).ToString();
            } 
            else
            {
                this.Meq.Visible = EvetHayirEnum.ehHayir;
                this.mval.Visible = EvetHayirEnum.ehHayir;
            }
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

        public CommunityHealthResultReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            Kategori = new KategoriGroup(HEADER,"Kategori");
            MAIN = new MAINGroup(Kategori,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protokol No", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f1afb241-e28f-4f1a-84a3-e7fe12256626");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COMMUNITYHEALTHRESULTREPORT";
            Caption = "Halk Sağlığı Tetkik Sonuç Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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