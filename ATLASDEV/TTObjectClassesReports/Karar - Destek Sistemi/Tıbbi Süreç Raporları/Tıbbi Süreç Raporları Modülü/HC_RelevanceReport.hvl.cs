
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
    /// Uygunluk Raporu
    /// </summary>
    public partial class HC_RelevanceReport : TTReport
    {
#region Methods
   public class DrBlock_Class {
            public string dr1;
            public string dr2;
            public string dr3;
       
        }
        public int drBlockCounter = 0;
        
        List<DrBlock_Class> drBlocklist = new  List<DrBlock_Class>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXALTBASLIK { get {return Header().XXXXXXALTBASLIK;} }
            public TTReportShape NewRect111 { get {return Header().NewRect111;} }
            public TTReportField REPORTNO { get {return Header().REPORTNO;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLine141 { get {return Header().NewLine141;} }
            public TTReportShape NewLine161 { get {return Header().NewLine161;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField11451 { get {return Header().NewField11451;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField EXAMINATIONDATE { get {return Header().EXAMINATIONDATE;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField MR { get {return Header().MR;} }
            public TTReportField STARTENDDATE { get {return Header().STARTENDDATE;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportField NewField11461 { get {return Header().NewField11461;} }
            public TTReportShape NewLine1151 { get {return Header().NewLine1151;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField TEL { get {return Header().TEL;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField KURUMU { get {return Header().KURUMU;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField116411 { get {return Header().NewField116411;} }
            public TTReportField HPROTOCOLNO { get {return Header().HPROTOCOLNO;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField HEALTHCOMMITTEEOBJECTID { get {return Header().HEALTHCOMMITTEEOBJECTID;} }
            public TTReportField lblOrnek { get {return Header().lblOrnek;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportField ONAYTARIH { get {return Footer().ONAYTARIH;} }
            public TTReportField HEADDOCTOR { get {return Footer().HEADDOCTOR;} }
            public TTReportField HEADDOCTOROBJECTID { get {return Footer().HEADDOCTOROBJECTID;} }
            public TTReportField ONAYLABEL { get {return Footer().ONAYLABEL;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetHealthCommitteeByObjectID_Class>("GetHealthCommitteeByObjectID", HealthCommittee.GetHealthCommitteeByObjectID((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField NewField111;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXALTBASLIK;
                public TTReportShape NewRect111;
                public TTReportField REPORTNO;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine161;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField NewField11421;
                public TTReportField NewField11431;
                public TTReportField NewField11451;
                public TTReportField NAMESURNAME;
                public TTReportField EXAMINATIONDATE;
                public TTReportField FATHERNAME;
                public TTReportField MR;
                public TTReportField STARTENDDATE;
                public TTReportField UNIQUEREFNO;
                public TTReportField DTARIHI;
                public TTReportField NewField11461;
                public TTReportShape NewLine1151;
                public TTReportField NewField113411;
                public TTReportField TEL;
                public TTReportField ADDRESS;
                public TTReportField LOGO;
                public TTReportField KURUMU;
                public TTReportField NewField1141;
                public TTReportField PATIENTSTATUS;
                public TTReportField NewField112411;
                public TTReportField NewField116411;
                public TTReportField HPROTOCOLNO;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField HEALTHCOMMITTEEOBJECTID;
                public TTReportField lblOrnek; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 92;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 11, 181, 33, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Size = 11;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"{%XXXXXXBASLIK%}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 35, 181, 44, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"TIBBİ UYGUNLUK KOMİSYON RAPORU";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 20, 258, 26, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.TextFont.CharSet = 162;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 6, 258, 12, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    XXXXXXALTBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 13, 258, 19, false);
                    XXXXXXALTBASLIK.Name = "XXXXXXALTBASLIK";
                    XXXXXXALTBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXALTBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXALTBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXALTBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXALTBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXALTBASLIK.TextFont.Size = 11;
                    XXXXXXALTBASLIK.TextFont.Bold = true;
                    XXXXXXALTBASLIK.TextFont.CharSet = 162;
                    XXXXXXALTBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALSUBNAME"", """")";

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 8, 45, 200, 91, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 76, 158, 81, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Size = 8;
                    REPORTNO.TextFont.CharSet = 162;
                    REPORTNO.Value = @"{#RAPORNO#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 52, 200, 52, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 59, 200, 59, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 66, 200, 66, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 74, 200, 74, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 46, 103, 81, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 40, 51, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Hastanın Adı Soyadı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 53, 130, 58, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Muayene Tarihi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 43, 65, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Doğum Tarihi";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 35, 58, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 8;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Baba Adı";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 60, 130, 65, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Poliklinik/Servis";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 46, 130, 51, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.TextFont.Size = 8;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"T.C Kimlik No";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 76, 35, 81, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.TextFont.Size = 8;
                    NewField11431.TextFont.Bold = true;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"Tel";

                    NewField11451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 69, 135, 73, false);
                    NewField11451.Name = "NewField11451";
                    NewField11451.TextFont.Size = 8;
                    NewField11451.TextFont.Bold = true;
                    NewField11451.TextFont.CharSet = 162;
                    NewField11451.Value = @"Rapor Tarihi";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 46, 100, 51, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Size = 8;
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"{%NAME%} {%SURNAME%}";

                    EXAMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 53, 195, 58, false);
                    EXAMINATIONDATE.Name = "EXAMINATIONDATE";
                    EXAMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXAMINATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXAMINATIONDATE.TextFont.Size = 8;
                    EXAMINATIONDATE.TextFont.CharSet = 162;
                    EXAMINATIONDATE.Value = @"{#MUAYENETARIHI#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 53, 99, 58, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    MR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 60, 199, 65, false);
                    MR.Name = "MR";
                    MR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MR.MultiLine = EvetHayirEnum.ehEvet;
                    MR.NoClip = EvetHayirEnum.ehEvet;
                    MR.WordBreak = EvetHayirEnum.ehEvet;
                    MR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MR.TextFont.Size = 8;
                    MR.TextFont.CharSet = 162;
                    MR.Value = @"{#BOLUM#}";

                    STARTENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 69, 200, 72, false);
                    STARTENDDATE.Name = "STARTENDDATE";
                    STARTENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTENDDATE.TextFont.Size = 8;
                    STARTENDDATE.TextFont.CharSet = 162;
                    STARTENDDATE.Value = @"{#RAPORTARIHI#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 46, 161, 51, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#TCNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 60, 102, 65, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"dd/MM/yyyy";
                    DTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    DTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    DTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    DTARIHI.TextFont.Size = 8;
                    DTARIHI.TextFont.CharSet = 162;
                    DTARIHI.Value = @"{#DTARIHI#}";

                    NewField11461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 76, 130, 81, false);
                    NewField11461.Name = "NewField11461";
                    NewField11461.TextFont.Size = 8;
                    NewField11461.TextFont.Bold = true;
                    NewField11461.TextFont.CharSet = 162;
                    NewField11461.Value = @"Rapor No";

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 81, 199, 81, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 84, 35, 89, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Size = 8;
                    NewField113411.TextFont.Bold = true;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"Adres";

                    TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 76, 98, 81, false);
                    TEL.Name = "TEL";
                    TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEL.TextFont.Size = 8;
                    TEL.TextFont.CharSet = 162;
                    TEL.Value = @"{#CEPTEL#}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 83, 200, 90, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADDRESS.TextFont.Size = 8;
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"{#ADRES#}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 11, 39, 34, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                    KURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 68, 102, 74, false);
                    KURUMU.Name = "KURUMU";
                    KURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMU.NoClip = EvetHayirEnum.ehEvet;
                    KURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMU.TextFont.Size = 8;
                    KURUMU.TextFont.CharSet = 162;
                    KURUMU.Value = @"{#KURUM#}";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 43, 74, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Kurumu ve Görevi";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 39, 41, 44, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.VertAlign = VerticalAlignmentEnum.vaBottom;
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 39, 28, 44, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField112411.TextFont.Size = 8;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.TextFont.CharSet = 162;
                    NewField112411.Value = @"Medulaya Takip:";

                    NewField116411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 76, 178, 81, false);
                    NewField116411.Name = "NewField116411";
                    NewField116411.TextFont.Size = 8;
                    NewField116411.TextFont.Bold = true;
                    NewField116411.TextFont.CharSet = 162;
                    NewField116411.Value = @"Kabul Nu:";

                    HPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 76, 200, 81, false);
                    HPROTOCOLNO.Name = "HPROTOCOLNO";
                    HPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOCOLNO.TextFont.Size = 8;
                    HPROTOCOLNO.TextFont.CharSet = 162;
                    HPROTOCOLNO.Value = @"{#ID#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 39, 254, 44, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.Value = @"{#PNAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 34, 254, 39, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME.Value = @"{#PSURNAME#}";

                    HEALTHCOMMITTEEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 44, 254, 49, false);
                    HEALTHCOMMITTEEOBJECTID.Name = "HEALTHCOMMITTEEOBJECTID";
                    HEALTHCOMMITTEEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEALTHCOMMITTEEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHCOMMITTEEOBJECTID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEALTHCOMMITTEEOBJECTID.Value = @"{#HEALTHCOMMITTEEOBJECTID#}
";

                    lblOrnek = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, -39, 308, 51, false);
                    lblOrnek.Name = "lblOrnek";
                    lblOrnek.FillStyle = FillStyleConstants.vbFSTransparent;
                    lblOrnek.TextColor = System.Drawing.Color.Silver;
                    lblOrnek.FontAngle = 450;
                    lblOrnek.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblOrnek.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblOrnek.TextFont.Size = 72;
                    lblOrnek.TextFont.CharSet = 162;
                    lblOrnek.Value = @"ÖRNEKTIR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteeByObjectID_Class dataset_GetHealthCommitteeByObjectID = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteeByObjectID_Class>(0);
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BASLIK.CalcValue = MyParentReport.PARTA.XXXXXXBASLIK.CalcValue;
                    NewField111.CalcValue = NewField111.Value;
                    REPORTNO.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Raporno) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField11451.CalcValue = NewField11451.Value;
                    NAME.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Pname) : "");
                    SURNAME.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Psurname) : "");
                    NAMESURNAME.CalcValue = MyParentReport.PARTA.NAME.CalcValue + @" " + MyParentReport.PARTA.SURNAME.CalcValue;
                    EXAMINATIONDATE.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Muayenetarihi) : "");
                    FATHERNAME.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.FatherName) : "");
                    MR.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Bolum) : "");
                    STARTENDDATE.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Raportarihi) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Tcno) : "");
                    DTARIHI.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Dtarihi) : "");
                    NewField11461.CalcValue = NewField11461.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    TEL.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Ceptel) : "");
                    ADDRESS.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Adres) : "");
                    LOGO.CalcValue = @"";
                    KURUMU.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Kurum) : "");
                    NewField1141.CalcValue = NewField1141.Value;
                    PATIENTSTATUS.CalcValue = @"";
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField116411.CalcValue = NewField116411.Value;
                    HPROTOCOLNO.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.ID) : "");
                    HEALTHCOMMITTEEOBJECTID.CalcValue = (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Healthcommitteeobjectid) : "") + @"
";
                    lblOrnek.CalcValue = lblOrnek.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");
                    return new TTReportObject[] { XXXXXXBASLIK,BASLIK,NewField111,REPORTNO,NewField121,NewField1121,NewField1131,NewField1151,NewField1161,NewField11421,NewField11431,NewField11451,NAME,SURNAME,NAMESURNAME,EXAMINATIONDATE,FATHERNAME,MR,STARTENDDATE,UNIQUEREFNO,DTARIHI,NewField11461,NewField113411,TEL,ADDRESS,LOGO,KURUMU,NewField1141,PATIENTSTATUS,NewField112411,NewField116411,HPROTOCOLNO,HEALTHCOMMITTEEOBJECTID,lblOrnek,XXXXXXIL,XXXXXXALTBASLIK};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HC_RelevanceReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee report = (HealthCommittee )context.GetObject(new Guid(sObjectID),"HealthCommittee");
            this.KURUMU.CalcValue = report.SubEpisode.LastSubEpisodeProtocol.Payer.Name;
            
            if (report.CurrentStateDefID == HealthCommittee.States.Completed)
                this.lblOrnek.Visible = EvetHayirEnum.ehHayir;
            else
                this.lblOrnek.Visible = EvetHayirEnum.ehEvet;
            
            DrBlock_Class drBlock = null;

            int i = 0;
            int counter = 0;
            foreach (BaseHealthCommittee_ExtDoctorGrid doctors in report.ExternalDoctors)
            {
                if (i % 3 == 0)
                {
                    drBlock = new DrBlock_Class();
                    MyParentReport.drBlocklist.Add(drBlock);
                    counter++;
                    drBlock.dr1 += doctors.ExternalDoctorName + "\n" + (doctors.Speciality != null ? doctors.Speciality.Name : "")
                        + "\nDip.Tes.No:" + doctors.ExternalDoctorRegNumber + " Uzm.Tes.No:" + doctors.ExternalDoctorSpecialityRegNo;
                    if (doctors.Reject.HasValue && doctors.Reject.Value)
                        drBlock.dr1 += "\nŞerh düşülmüştür.Nedeni;\n" + doctors.Description;
                }
                else if (i % 3 == 1)
                {
                    drBlock.dr2 += doctors.ExternalDoctorName + "\n" + (doctors.Speciality != null ? doctors.Speciality.Name : "")
                        + "\nDip.Tes.No:" + doctors.ExternalDoctorRegNumber + " Uzm.Tes.No:" + doctors.ExternalDoctorSpecialityRegNo
                        + "\n" + doctors.Description;
                    if (doctors.Reject.HasValue && doctors.Reject.Value)
                        drBlock.dr2 += "\nŞerh düşülmüştür.Nedeni;\n" + doctors.Description;
                }
                else if (i % 3 == 2)
                {
                    drBlock.dr3 += doctors.ExternalDoctorName + "\n" + (doctors.Speciality != null ? doctors.Speciality.Name : "")
                        + "\nDip.Tes.No:" + doctors.ExternalDoctorRegNumber + " Uzm.Tes.No:" + doctors.ExternalDoctorSpecialityRegNo
                        + "\n" + doctors.Description;
                    if (doctors.Reject.HasValue && doctors.Reject.Value)
                        drBlock.dr3 += "\nŞerh düşülmüştür.Nedeni;\n" + doctors.Description;
                }
                i++;

            }

            foreach (var member in report.Members)
            {
                        if (i % 3 == 0)
                        {
                            drBlock = new DrBlock_Class();
                            MyParentReport.drBlocklist.Add(drBlock);
                            counter++;
                            drBlock.dr1 += member.MemberDoctor.Name + "\n" + (member.Speciality != null ? member.Speciality.Name : "")
                                + "\nDip.Tes.No:" + member.MemberDoctor.DiplomaRegisterNo + " Uzm.Tes.No:" + member.MemberDoctor.SpecialityRegistryNo;
                            if (member.Reject.HasValue && member.Reject.Value)
                                drBlock.dr1 += "\nŞerh düşülmüştür.Nedeni;\n" + member.Description;
                        }
                        else if (i % 3 == 1)
                        {
                            drBlock.dr2 += member.MemberDoctor.Name + "\n" + (member.Speciality != null ? member.Speciality.Name : "")
                                + "\nDip.Tes.No:" + member.MemberDoctor.DiplomaRegisterNo + " Uzm.Tes.No:" + member.MemberDoctor.SpecialityRegistryNo;
                            if (member.Reject.HasValue && member.Reject.Value)
                                drBlock.dr2 += "\nŞerh düşülmüştür.Nedeni;\n" + member.Description;
                        }
                        else if (i % 3 == 2)
                        {
                            drBlock.dr3 += member.MemberDoctor.Name + "\n" + (member.Speciality != null ? member.Speciality.Name : "")
                                + "\nDip.Tes.No:" + member.MemberDoctor.DiplomaRegisterNo + " Uzm.Tes.No:" + member.MemberDoctor.SpecialityRegistryNo;
                            if (member.Reject.HasValue && member.Reject.Value)
                                drBlock.dr3 += "\nŞerh düşülmüştür.Nedeni;\n" + member.Description;
                        }
                i++;
            }

            MyParentReport.DrBlock.RepeatCount = counter;
            
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
            this.PATIENTSTATUS.CalcValue = (report.MasterAction != null && report.MasterAction is InPatientTreatmentClinicApplication) ? ((InPatientTreatmentClinicApplication)report.MasterAction).SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo: report.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
            foreach(EpisodeAction episodeAction in report.Episode.EpisodeActions){
                if(episodeAction is PatientExamination && episodeAction.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    PatientExamination patientExamination= (PatientExamination) episodeAction;
                    this.EXAMINATIONDATE.CalcValue = patientExamination.ProcessDate != null ? patientExamination.ProcessDate.ToString() : null;
                }
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField ONAY;
                public TTReportField ONAYTARIH;
                public TTReportField HEADDOCTOR;
                public TTReportField HEADDOCTOROBJECTID;
                public TTReportField ONAYLABEL;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField15;
                public TTReportField NewField1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 31;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 24, 247, 29, false);
                    ONAY.Name = "ONAY";
                    ONAY.Visible = EvetHayirEnum.ehHayir;
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Size = 8;
                    ONAY.TextFont.Bold = true;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"ONAY";

                    ONAYTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 29, 255, 34, false);
                    ONAYTARIH.Name = "ONAYTARIH";
                    ONAYTARIH.Visible = EvetHayirEnum.ehHayir;
                    ONAYTARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYTARIH.TextFont.Size = 8;
                    ONAYTARIH.TextFont.CharSet = 162;
                    ONAYTARIH.Value = @"...../...../........";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 33, 259, 39, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTOR.TextFont.Size = 8;
                    HEADDOCTOR.TextFont.CharSet = 162;
                    HEADDOCTOR.Value = @"";

                    HEADDOCTOROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 14, 246, 19, false);
                    HEADDOCTOROBJECTID.Name = "HEADDOCTOROBJECTID";
                    HEADDOCTOROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOROBJECTID.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOROBJECTID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR_OBJECTID"", """")";

                    ONAYLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 39, 247, 44, false);
                    ONAYLABEL.Name = "ONAYLABEL";
                    ONAYLABEL.Visible = EvetHayirEnum.ehHayir;
                    ONAYLABEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYLABEL.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYLABEL.TextFont.Size = 8;
                    ONAYLABEL.TextFont.CharSet = 162;
                    ONAYLABEL.Value = @"Başhekim";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 208, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"*Hekim sayısı durum bildirir raporun niteliğine göre belirlenecek olup, hekim imza adedi daha fazla veya daha az olabilir.";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 36, 8, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Açıklama";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 23, 208, 28, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 208, 18, false);
                    NewField15.Name = "NewField15";
                    NewField15.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"*{#TCNO#}TC Kimlik numaralı {#PNAME#} {#PSURNAME#}'ın {#RAPORNO#}numaralı raporudur.
";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 18, 208, 23, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteeByObjectID_Class dataset_GetHealthCommitteeByObjectID = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteeByObjectID_Class>(0);
                    ONAY.CalcValue = ONAY.Value;
                    ONAYTARIH.CalcValue = ONAYTARIH.Value;
                    HEADDOCTOR.CalcValue = HEADDOCTOR.Value;
                    ONAYLABEL.CalcValue = ONAYLABEL.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField15.CalcValue = @"*" + (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Tcno) : "") + @"TC Kimlik numaralı " + (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Pname) : "") + @" " + (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Psurname) : "") + @"'ın " + (dataset_GetHealthCommitteeByObjectID != null ? Globals.ToStringCore(dataset_GetHealthCommitteeByObjectID.Raporno) : "") + @"numaralı raporudur.
";
                    NewField1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    HEADDOCTOROBJECTID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
                    return new TTReportObject[] { ONAY,ONAYTARIH,HEADDOCTOR,ONAYLABEL,NewField3,NewField4,NewField5,NewField15,NewField1,HEADDOCTOROBJECTID};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
           /*  string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            if(statusNotificationReport.ProcedureDoctor!=null)
            {
                this.DOKTOR1.CalcValue =(statusNotificationReport.ProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(statusNotificationReport.ProcedureDoctor.Title.Value) : "") + " " +  statusNotificationReport.ProcedureDoctor.Name ;
                this.DOKTOR1BOLUM.CalcValue = ((statusNotificationReport.ProcedureDoctor.ResourceSpecialities != null && statusNotificationReport.ProcedureDoctor.ResourceSpecialities.Count > 0 )? statusNotificationReport.ProcedureDoctor.ResourceSpecialities[0].Speciality.Name : "");
            this.DOKTOR1DIPNO.CalcValue = "Tescil No: " + statusNotificationReport.ProcedureDoctor.DiplomaRegisterNo;
                
            }
            
            if(statusNotificationReport.CommitteeReport  == true)
            {
                this.SIGNATURE2.Visible = EvetHayirEnum.ehEvet;
                this.SIGNATURE3.Visible = EvetHayirEnum.ehEvet;
                this.SIGNATURE1.Visible = EvetHayirEnum.ehEvet;
                
                this.ONAY.Visible = EvetHayirEnum.ehEvet;
                this.ONAYTARIH.Visible = EvetHayirEnum.ehEvet;
                this.HEADDOCTOR.Visible = EvetHayirEnum.ehEvet;
                this.ONAYLABEL.Visible = EvetHayirEnum.ehEvet;
                
                this.DOKTOR2DIPNO.Visible = EvetHayirEnum.ehEvet; 
                this.DOKTOR2.Visible = EvetHayirEnum.ehEvet; 
                this.DOKTOR2BOLUM.Visible = EvetHayirEnum.ehEvet; 
                
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehEvet; 
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehEvet; 
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehEvet; 
                
                if(statusNotificationReport.SecondDoctor!=null)
                {
                    this.DOKTOR2.CalcValue =(statusNotificationReport.SecondDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(statusNotificationReport.SecondDoctor.Title.Value) : "") + " " +  statusNotificationReport.SecondDoctor.Name ;
                    this.DOKTOR2BOLUM.CalcValue = ((statusNotificationReport.SecondDoctor.ResourceSpecialities != null && statusNotificationReport.SecondDoctor.ResourceSpecialities.Count > 0 )? statusNotificationReport.SecondDoctor.ResourceSpecialities[0].Speciality.Name : "");
                     this.DOKTOR2DIPNO.CalcValue = "Tescil No: " + statusNotificationReport.SecondDoctor.DiplomaRegisterNo;
                
                }     
                if(statusNotificationReport.ThirdDoctor!=null)
                {
                      this.DOKTOR3.CalcValue =(statusNotificationReport.ThirdDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(statusNotificationReport.ThirdDoctor.Title.Value) : "") + " " +  statusNotificationReport.ThirdDoctor.Name ;
                      this.DOKTOR3BOLUM.CalcValue = ((statusNotificationReport.ThirdDoctor.ResourceSpecialities != null && statusNotificationReport.ThirdDoctor.ResourceSpecialities.Count > 0 )? statusNotificationReport.ThirdDoctor.ResourceSpecialities[0].Speciality.Name : "");
                      this.DOKTOR3DIPNO.CalcValue = "Tescil No: "  + statusNotificationReport.ThirdDoctor.DiplomaRegisterNo;
                
                 }     
            }
            else
            {
                 this.SIGNATURE2.Visible = EvetHayirEnum.ehHayir;
                this.SIGNATURE3.Visible = EvetHayirEnum.ehEvet;
                 this.SIGNATURE1.Visible = EvetHayirEnum.ehHayir;
                
                    this.ONAY.Visible = EvetHayirEnum.ehHayir;
                this.ONAYTARIH.Visible = EvetHayirEnum.ehHayir;
                this.HEADDOCTOR.Visible = EvetHayirEnum.ehHayir;
                this.ONAYLABEL.Visible = EvetHayirEnum.ehHayir;
                
                      
                this.DOKTOR2DIPNO.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR2.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR2BOLUM.Visible = EvetHayirEnum.ehHayir; 
                
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehHayir; 
                
                
            }
            
            */
            ResUser head = (ResUser)context.GetObject(new Guid(this.HEADDOCTOROBJECTID.CalcValue),"ResUser");
            this.HEADDOCTOR.CalcValue = (head.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(head.Title.Value) : "") + " " +  head.Name ;
           
            //this.ONAY.CalcValue =ResHospital.ApprovalSignatureBlock;
            
            //            foreach(TTObjectState obj in p.GetStateHistory())
            //            {
            //                if( obj.StateDefID == ParticipatnFreeDrugReport.States.Report)
            //                {
            //                     //this.SIGNATURE.CalcValue= obj.User.Name;
            //                     this.SIGNATURE1.CalcValue= obj.User.Name;
            //                }
            //
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField111911 { get {return Body().NewField111911;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField NewField111911;
                public TTReportField TANI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 61, 6, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.TextFont.Name = "Arial";
                    NewField111911.TextFont.Size = 9;
                    NewField111911.TextFont.Bold = true;
                    NewField111911.TextFont.CharSet = 162;
                    NewField111911.Value = @"ICD KODU VE TANI(LAR)";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 200, 18, false);
                    TANI.Name = "TANI";
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Unicode MS";
                    TANI.TextFont.Size = 8;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111911.CalcValue = NewField111911.Value;
                    TANI.CalcValue = TANI.Value;
                    return new TTReportObject[] { NewField111911,TANI};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    //             TTObjectContext context = new TTObjectContext(true);
//            //System.Diagnostics.Debugger.Break();
//            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
//            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
//             foreach (ReportDiagnosis reportDiagnose in statusNotificationReport.ReportDiagnosis)
//             {
//                 this.DIAGNOSIS.Value = reportDiagnose.DiagnosisGrid.Diagnose.Code + "-" + reportDiagnose.DiagnosisGrid.Diagnose.Name + "\r\n";
//             }
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string diagnoseStr = "";
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HC_RelevanceReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee p = (HealthCommittee)context.GetObject(new Guid(sObjectID), "HealthCommittee");

//            if (p.Diagnosis.Count > 0)// Buradan tanı girişi yapılmadıysa episodedaki kesin  tanılara bakar
//            {
//                foreach (DiagnosisGrid diagnosis in p.Diagnosis)
//                {
//                    diagnoseStr = diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + "-" + diagnosis.FreeDiagnosis + "; " + "\n" + diagnoseStr;
//                }
//            }
//            else
//            {
//                foreach (DiagnosisGrid diagnosis in p.Episode.Diagnosis)
//                {
//                    diagnoseStr = diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + "-" + diagnosis.FreeDiagnosis + "; " + "\n" + diagnoseStr;
//                }
//            }

            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(p);
            DiagnosisGrid dg = null;
            List<string> codeArray = new List<string>();
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is PatientExamination && ((PatientExamination)eaction).PatientExaminationType == PatientExaminationEnum.HealthCommittee && !eaction.IsCancelled && eaction.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                {
                    PatientExamination exam = (PatientExamination)eaction;
                    if (exam.CurrentStateDefID.Equals(PatientExamination.States.Completed) && exam.Diagnosis != null )
                    {
                        for (int i = 0; i < exam.Diagnosis.Count; i++)
                        {
                            dg = exam.Diagnosis[i];
                            if (!codeArray.Contains(dg.Diagnose.Code))
                            {
                                codeArray.Add(dg.Diagnose.Code);
                                diagnoseStr = dg.Diagnose.Code + "-" + dg.Diagnose.Name + "-" + "; " + "\n" + diagnoseStr;
                            }
                        }
                    }
                }
            }
            this.TANI.CalcValue = diagnoseStr;
            if(p.ProcedureDoctor!=null) {
                //this.SIGNATURE.CalcValue =p.ProcedureDoctor.SignatureBlock;
                //edited by ETAGMAT 06.03.2012
                //this.SIGNATURE.CalcValue = p.ProcedureDoctor.SignatureBlockWDiplomaInfo.Replace("\r", "");//boşluklar gitsin
            }                              //                                                TTObjectContext context = new TTObjectContext(true);
            //            //System.Diagnostics.Debugger.Break();
            //            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            //            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            //             foreach (ReportDiagnosis reportDiagnose in statusNotificationReport.ReportDiagnosis)
            //             {
            //                 this.TANI.CalcValue += reportDiagnose.DiagnosisGrid.Diagnose.Code + "-" + reportDiagnose.DiagnosisGrid.Diagnose.Name + "\r\n";
            //             }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ACIKLAMAGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public ACIKLAMAGroupBody Body()
            {
                return (ACIKLAMAGroupBody)_body;
            }
            public ACIKLAMAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ACIKLAMAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ACIKLAMAGroupBody(this);
            }

            public partial class ACIKLAMAGroupBody : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                 
                public ACIKLAMAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
                public override void RunPreScript()
                {
#region ACIKLAMA BODY_PreScript
                    /*                                                                               TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if (statusNotificationReport.ReportDescription != null && statusNotificationReport.ReportDescription != "")
                    {
                        this.ACIKLAMA.Value = statusNotificationReport.ReportDescription;
                    }
                    else
                    {
                        this.Visible = EvetHayirEnum.ehHayir;
                    }*/
#endregion ACIKLAMA BODY_PreScript
                }

                public override void RunScript()
                {
#region ACIKLAMA BODY_Script
                    /*     TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if(statusNotificationReport.ReportDescription != null)
             {
                 this.ACIKLAMA.CalcValue = statusNotificationReport.ReportDescription + "\r\n";
             }*/
#endregion ACIKLAMA BODY_Script
                }
            }

        }

        public ACIKLAMAGroup ACIKLAMA;

        public partial class COMPLAINTHeaderGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public COMPLAINTHeaderGroupHeader Header()
            {
                return (COMPLAINTHeaderGroupHeader)_header;
            }

            new public COMPLAINTHeaderGroupFooter Footer()
            {
                return (COMPLAINTHeaderGroupFooter)_footer;
            }

            public TTReportField NewField11119111 { get {return Header().NewField11119111;} }
            public COMPLAINTHeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMPLAINTHeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new COMPLAINTHeaderGroupHeader(this);
                _footer = new COMPLAINTHeaderGroupFooter(this);

            }

            public partial class COMPLAINTHeaderGroupHeader : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField NewField11119111; 
                public COMPLAINTHeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 61, 5, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial";
                    NewField11119111.TextFont.Size = 9;
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"ŞİKAYETLERİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11119111.CalcValue = NewField11119111.Value;
                    return new TTReportObject[] { NewField11119111};
                }
            }
            public partial class COMPLAINTHeaderGroupFooter : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                 
                public COMPLAINTHeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public COMPLAINTHeaderGroup COMPLAINTHeader;

        public partial class COMPLAINTGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public COMPLAINTGroupBody Body()
            {
                return (COMPLAINTGroupBody)_body;
            }
            public TTReportField ComplaintDepartment { get {return Body().ComplaintDepartment;} }
            public TTReportField PEOBJECTID { get {return Body().PEOBJECTID;} }
            public TTReportField COMPLAINT { get {return Body().COMPLAINT;} }
            public COMPLAINTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMPLAINTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PatientExamination.GetPatientExaminationByMasterAction_Class>("GetPatientExaminationByMasterAction", PatientExamination.GetPatientExaminationByMasterAction((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTA.HEALTHCOMMITTEEOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new COMPLAINTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class COMPLAINTGroupBody : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField ComplaintDepartment;
                public TTReportField PEOBJECTID;
                public TTReportField COMPLAINT; 
                public COMPLAINTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    ComplaintDepartment = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 58, 5, false);
                    ComplaintDepartment.Name = "ComplaintDepartment";
                    ComplaintDepartment.Visible = EvetHayirEnum.ehHayir;
                    ComplaintDepartment.FieldType = ReportFieldTypeEnum.ftVariable;
                    ComplaintDepartment.TextFont.Name = "Arial";
                    ComplaintDepartment.TextFont.Size = 9;
                    ComplaintDepartment.TextFont.Bold = true;
                    ComplaintDepartment.TextFont.CharSet = 162;
                    ComplaintDepartment.Value = @"";

                    PEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 6, 254, 11, false);
                    PEOBJECTID.Name = "PEOBJECTID";
                    PEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PEOBJECTID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PEOBJECTID.Value = @"{#OBJECTID#}";

                    COMPLAINT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 200, 17, false);
                    COMPLAINT.Name = "COMPLAINT";
                    COMPLAINT.MultiLine = EvetHayirEnum.ehEvet;
                    COMPLAINT.NoClip = EvetHayirEnum.ehEvet;
                    COMPLAINT.WordBreak = EvetHayirEnum.ehEvet;
                    COMPLAINT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COMPLAINT.TextFont.Name = "Arial Unicode MS";
                    COMPLAINT.TextFont.Size = 8;
                    COMPLAINT.TextFont.CharSet = 162;
                    COMPLAINT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientExamination.GetPatientExaminationByMasterAction_Class dataset_GetPatientExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<PatientExamination.GetPatientExaminationByMasterAction_Class>(0);
                    ComplaintDepartment.CalcValue = @"";
                    PEOBJECTID.CalcValue = (dataset_GetPatientExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetPatientExaminationByMasterAction.ObjectID) : "");
                    COMPLAINT.CalcValue = COMPLAINT.Value;
                    return new TTReportObject[] { ComplaintDepartment,PEOBJECTID,COMPLAINT};
                }

                public override void RunScript()
                {
#region COMPLAINT BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.PEOBJECTID.CalcValue;
            PatientExamination pe = (PatientExamination)context.GetObject(new Guid(sObjectID),"PatientExamination");
            if(pe.Complaint != null)
            {
                this.COMPLAINT.CalcValue =TTReportTool.TTReport.HTMLtoText(pe.Complaint.ToString());
            }
            this.ComplaintDepartment.CalcValue = pe.MasterResource.Name;
#endregion COMPLAINT BODY_Script
                }
            }

        }

        public COMPLAINTGroup COMPLAINT;

        public partial class BULGULARGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public BULGULARGroupBody Body()
            {
                return (BULGULARGroupBody)_body;
            }
            public TTReportField NewField1119111 { get {return Body().NewField1119111;} }
            public TTReportField BULGU { get {return Body().BULGU;} }
            public BULGULARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BULGULARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BULGULARGroupBody(this);
            }

            public partial class BULGULARGroupBody : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField NewField1119111;
                public TTReportField BULGU; 
                public BULGULARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 61, 5, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.TextFont.Name = "Arial";
                    NewField1119111.TextFont.Size = 9;
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.CharSet = 162;
                    NewField1119111.Value = @"MUAYENE BULGULARI";

                    BULGU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 199, 15, false);
                    BULGU.Name = "BULGU";
                    BULGU.MultiLine = EvetHayirEnum.ehEvet;
                    BULGU.NoClip = EvetHayirEnum.ehEvet;
                    BULGU.WordBreak = EvetHayirEnum.ehEvet;
                    BULGU.ExpandTabs = EvetHayirEnum.ehEvet;
                    BULGU.TextFont.Name = "Arial Unicode MS";
                    BULGU.TextFont.Size = 8;
                    BULGU.TextFont.CharSet = 162;
                    BULGU.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1119111.CalcValue = NewField1119111.Value;
                    BULGU.CalcValue = BULGU.Value;
                    return new TTReportObject[] { NewField1119111,BULGU};
                }
                public override void RunPreScript()
                {
#region BULGULAR BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HC_RelevanceReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee statusNotificationReport = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            if(statusNotificationReport.ClinicalFindings != null)
            {
                this.BULGU.Value =TTReportTool.TTReport.HTMLtoText(statusNotificationReport.ClinicalFindings.ToString());
            }
            //   TTObjectContext context = new TTObjectContext(true);
//            //System.Diagnostics.Debugger.Break();
//            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
//            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
//             if(statusNotificationReport.Description != null)
//             {
//                 this.SIGNS.Value = statusNotificationReport.Description + "\r\n";
//             }
//     
/*
TTObjectContext context = new TTObjectContext(true);
        string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if(statusNotificationReport.Description != null)
             {
                 this.BULGU.Value = statusNotificationReport.Description;
             }else
                    {
                        this.Visible = EvetHayirEnum.ehHayir;
                    }*/
#endregion BULGULAR BODY_PreScript
                }

                public override void RunScript()
                {
#region BULGULAR BODY_Script
                    //TTObjectContext context = new TTObjectContext(true);
            //System.Diagnostics.Debugger.Break();
            /*string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if(statusNotificationReport.Description != null)
             {
                 this.BULGU.CalcValue = statusNotificationReport.Description + "\r\n";
             }
            */
#endregion BULGULAR BODY_Script
                }
            }

        }

        public BULGULARGroup BULGULAR;

        public partial class KARAR_NEW_PAGEGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public KARAR_NEW_PAGEGroupHeader Header()
            {
                return (KARAR_NEW_PAGEGroupHeader)_header;
            }

            new public KARAR_NEW_PAGEGroupFooter Footer()
            {
                return (KARAR_NEW_PAGEGroupFooter)_footer;
            }

            public TTReportField LBLACIKLAMA1 { get {return Header().LBLACIKLAMA1;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public KARAR_NEW_PAGEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARAR_NEW_PAGEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KARAR_NEW_PAGEGroupHeader(this);
                _footer = new KARAR_NEW_PAGEGroupFooter(this);

            }

            public partial class KARAR_NEW_PAGEGroupHeader : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField LBLACIKLAMA1;
                public TTReportField ACIKLAMA; 
                public KARAR_NEW_PAGEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLACIKLAMA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 61, 7, false);
                    LBLACIKLAMA1.Name = "LBLACIKLAMA1";
                    LBLACIKLAMA1.TextFont.Name = "Arial";
                    LBLACIKLAMA1.TextFont.Size = 9;
                    LBLACIKLAMA1.TextFont.Bold = true;
                    LBLACIKLAMA1.TextFont.CharSet = 162;
                    LBLACIKLAMA1.Value = @"TIBBI GEREKÇELER";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 199, 19, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Name = "Arial Unicode MS";
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLACIKLAMA1.CalcValue = LBLACIKLAMA1.Value;
                    ACIKLAMA.CalcValue = ACIKLAMA.Value;
                    return new TTReportObject[] { LBLACIKLAMA1,ACIKLAMA};
                }
                public override void RunPreScript()
                {
#region KARAR_NEW_PAGE HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HC_RelevanceReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee statusNotificationReport = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            if(statusNotificationReport.Definition != null)
            {
                this.ACIKLAMA.Value =TTReportTool.TTReport.HTMLtoText(statusNotificationReport.Definition.ToString());
            }
#endregion KARAR_NEW_PAGE HEADER_PreScript
                }
            }
            public partial class KARAR_NEW_PAGEGroupFooter : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public KARAR_NEW_PAGEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 2, 161, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NewField1";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public KARAR_NEW_PAGEGroup KARAR_NEW_PAGE;

        public partial class KARARGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public KARARGroupBody Body()
            {
                return (KARARGroupBody)_body;
            }
            public TTReportField NewField11119111 { get {return Body().NewField11119111;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public KARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KARARGroupBody(this);
            }

            public partial class KARARGroupBody : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField NewField11119111;
                public TTReportField KARAR; 
                public KARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 61, 4, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial";
                    NewField11119111.TextFont.Size = 9;
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"KARAR";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 199, 15, false);
                    KARAR.Name = "KARAR";
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial Unicode MS";
                    KARAR.TextFont.Size = 8;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11119111.CalcValue = NewField11119111.Value;
                    KARAR.CalcValue = KARAR.Value;
                    return new TTReportObject[] { NewField11119111,KARAR};
                }
                public override void RunPreScript()
                {
#region KARAR BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HC_RelevanceReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee statusNotificationReport = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            if(statusNotificationReport.HealthCommitteeDecision != null)
            {
                this.KARAR.Value =TTReportTool.TTReport.HTMLtoText(statusNotificationReport.HealthCommitteeDecision.ToString());
            }
            
             this.ForceNewPage = EvetHayirEnum.ehEvet;
#endregion KARAR BODY_PreScript
                }
            }

        }

        public KARARGroup KARAR;

        public partial class DrBlockGroup : TTReportGroup
        {
            public HC_RelevanceReport MyParentReport
            {
                get { return (HC_RelevanceReport)ParentReport; }
            }

            new public DrBlockGroupBody Body()
            {
                return (DrBlockGroupBody)_body;
            }
            public TTReportField SIGNATURE12 { get {return Body().SIGNATURE12;} }
            public TTReportField SIGNATURE13 { get {return Body().SIGNATURE13;} }
            public TTReportField SIGNATURE11 { get {return Body().SIGNATURE11;} }
            public TTReportField dr2 { get {return Body().dr2;} }
            public TTReportField dr3 { get {return Body().dr3;} }
            public TTReportField dr1 { get {return Body().dr1;} }
            public DrBlockGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DrBlockGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DrBlockGroupBody(this);
            }

            public partial class DrBlockGroupBody : TTReportSection
            {
                public HC_RelevanceReport MyParentReport
                {
                    get { return (HC_RelevanceReport)ParentReport; }
                }
                
                public TTReportField SIGNATURE12;
                public TTReportField SIGNATURE13;
                public TTReportField SIGNATURE11;
                public TTReportField dr2;
                public TTReportField dr3;
                public TTReportField dr1; 
                public DrBlockGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 31;
                    RepeatCount = 0;
                    
                    SIGNATURE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 6, 133, 11, false);
                    SIGNATURE12.Name = "SIGNATURE12";
                    SIGNATURE12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE12.TextFont.Size = 8;
                    SIGNATURE12.TextFont.Bold = true;
                    SIGNATURE12.TextFont.CharSet = 162;
                    SIGNATURE12.Value = @"İMZA";

                    SIGNATURE13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 68, 11, false);
                    SIGNATURE13.Name = "SIGNATURE13";
                    SIGNATURE13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE13.TextFont.Size = 8;
                    SIGNATURE13.TextFont.Bold = true;
                    SIGNATURE13.TextFont.CharSet = 162;
                    SIGNATURE13.Value = @"İMZA";

                    SIGNATURE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 6, 196, 11, false);
                    SIGNATURE11.Name = "SIGNATURE11";
                    SIGNATURE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE11.TextFont.Size = 8;
                    SIGNATURE11.TextFont.Bold = true;
                    SIGNATURE11.TextFont.CharSet = 162;
                    SIGNATURE11.Value = @"İMZA";

                    dr2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 11, 133, 30, false);
                    dr2.Name = "dr2";
                    dr2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dr2.TextFont.Size = 8;
                    dr2.TextFont.CharSet = 162;
                    dr2.Value = @"";

                    dr3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 11, 196, 30, false);
                    dr3.Name = "dr3";
                    dr3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dr3.TextFont.Size = 8;
                    dr3.TextFont.CharSet = 162;
                    dr3.Value = @"";

                    dr1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 68, 29, false);
                    dr1.Name = "dr1";
                    dr1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dr1.TextFont.Size = 8;
                    dr1.TextFont.CharSet = 162;
                    dr1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIGNATURE12.CalcValue = SIGNATURE12.Value;
                    SIGNATURE13.CalcValue = SIGNATURE13.Value;
                    SIGNATURE11.CalcValue = SIGNATURE11.Value;
                    dr2.CalcValue = dr2.Value;
                    dr3.CalcValue = dr3.Value;
                    dr1.CalcValue = dr1.Value;
                    return new TTReportObject[] { SIGNATURE12,SIGNATURE13,SIGNATURE11,dr2,dr3,dr1};
                }
                public override void RunPreScript()
                {
#region DRBLOCK BODY_PreScript
                    //      if (MyParentReport.drBlockCounter == 0)
                            //this.ForceNewPage = EvetHayirEnum.ehEvet;
                        //else
                       //     this.ForceNewPage = EvetHayirEnum.ehHayir;
#endregion DRBLOCK BODY_PreScript
                }

                public override void RunScript()
                {
#region DRBLOCK BODY_Script
                    if (MyParentReport.DrBlock.RepeatCount > 0)
            {

                var obj = MyParentReport.drBlocklist[MyParentReport.drBlockCounter];
                this.dr1.CalcValue = obj.dr1;

                if (!string.IsNullOrEmpty(obj.dr1))
                    this.SIGNATURE13.Visible = EvetHayirEnum.ehEvet;
                else
                    this.SIGNATURE13.Visible = EvetHayirEnum.ehHayir;

                this.dr2.CalcValue = obj.dr2;

                if (!string.IsNullOrEmpty(obj.dr2))
                    this.SIGNATURE12.Visible = EvetHayirEnum.ehEvet;
                else
                    this.SIGNATURE12.Visible = EvetHayirEnum.ehHayir;

                this.dr3.CalcValue = obj.dr3;

                if (!string.IsNullOrEmpty(obj.dr3))
                    this.SIGNATURE11.Visible = EvetHayirEnum.ehEvet;
                else
                    this.SIGNATURE11.Visible = EvetHayirEnum.ehHayir;

                MyParentReport.drBlockCounter += 1;
                this.Visible = EvetHayirEnum.ehEvet;
                
            }
            else
            {
                this.Visible = EvetHayirEnum.ehHayir;
            }
#endregion DRBLOCK BODY_Script
                }
            }

        }

        public DrBlockGroup DrBlock;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HC_RelevanceReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            ACIKLAMA = new ACIKLAMAGroup(PARTA,"ACIKLAMA");
            COMPLAINTHeader = new COMPLAINTHeaderGroup(PARTA,"COMPLAINTHeader");
            COMPLAINT = new COMPLAINTGroup(COMPLAINTHeader,"COMPLAINT");
            BULGULAR = new BULGULARGroup(PARTA,"BULGULAR");
            KARAR_NEW_PAGE = new KARAR_NEW_PAGEGroup(PARTA,"KARAR_NEW_PAGE");
            KARAR = new KARARGroup(KARAR_NEW_PAGE,"KARAR");
            DrBlock = new DrBlockGroup(PARTA,"DrBlock");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HC_RELEVANCEREPORT";
            Caption = "Uygunluk Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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