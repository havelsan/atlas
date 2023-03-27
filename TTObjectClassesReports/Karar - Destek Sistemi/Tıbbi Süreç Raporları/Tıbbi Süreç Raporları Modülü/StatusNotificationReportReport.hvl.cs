
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
    /// Durum Bildirir Raporu
    /// </summary>
    public partial class StatusNotificationReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StatusNotificationReportReport MyParentReport
            {
                get { return (StatusNotificationReportReport)ParentReport; }
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
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
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
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField TEL { get {return Header().TEL;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField KURUMU { get {return Header().KURUMU;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField116411 { get {return Header().NewField116411;} }
            public TTReportField HPROTOCOLNO { get {return Header().HPROTOCOLNO;} }
            public TTReportField DOKTOR1 { get {return Footer().DOKTOR1;} }
            public TTReportField SIGNATURE2 { get {return Footer().SIGNATURE2;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportField ONAYTARIH { get {return Footer().ONAYTARIH;} }
            public TTReportField HEADDOCTOR { get {return Footer().HEADDOCTOR;} }
            public TTReportField HEADDOCTOROBJECTID { get {return Footer().HEADDOCTOROBJECTID;} }
            public TTReportField ONAYLABEL { get {return Footer().ONAYLABEL;} }
            public TTReportField DOKTOR1BOLUM { get {return Footer().DOKTOR1BOLUM;} }
            public TTReportField DOKTOR1DIPNO { get {return Footer().DOKTOR1DIPNO;} }
            public TTReportField DOKTOR2 { get {return Footer().DOKTOR2;} }
            public TTReportField DOKTOR2BOLUM { get {return Footer().DOKTOR2BOLUM;} }
            public TTReportField DOKTOR2DIPNO { get {return Footer().DOKTOR2DIPNO;} }
            public TTReportField DOKTOR3 { get {return Footer().DOKTOR3;} }
            public TTReportField DOKTOR3BOLUM { get {return Footer().DOKTOR3BOLUM;} }
            public TTReportField DOKTOR3DIPNO { get {return Footer().DOKTOR3DIPNO;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField SIGNATURE3 { get {return Footer().SIGNATURE3;} }
            public TTReportField SIGNATURE1 { get {return Footer().SIGNATURE1;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NAME1 { get {return Footer().NAME1;} }
            public TTReportField SURNAME1 { get {return Footer().SURNAME1;} }
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
                list[0] = new TTReportNqlData<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>("GetStatusNotificationRaportRNQL", StatusNotificationReport.GetStatusNotificationRaportRNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.OBJECTID)));
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
                public StatusNotificationReportReport MyParentReport
                {
                    get { return (StatusNotificationReportReport)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField NewField111;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXALTBASLIK;
                public TTReportField NAME;
                public TTReportField SURNAME;
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
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField TEL;
                public TTReportField ADDRESS;
                public TTReportField LOGO;
                public TTReportField KURUMU;
                public TTReportField NewField1141;
                public TTReportField PATIENTSTATUS;
                public TTReportField NewField112411;
                public TTReportField NewField116411;
                public TTReportField HPROTOCOLNO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 92;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 11, 171, 33, false);
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

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 35, 171, 44, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"";

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

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 37, 257, 42, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "StatusNotificationReport";
                    NAME.DataMember = "EPISODE.PATIENT.NAME";
                    NAME.Value = @"{@OBJECTID@}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 32, 257, 37, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME.ObjectDefName = "StatusNotificationReport";
                    SURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME.Value = @"{@OBJECTID@}";

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 8, 45, 200, 91, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 76, 158, 81, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Size = 8;
                    REPORTNO.TextFont.CharSet = 162;
                    REPORTNO.Value = @"{#REPORTNO#}";

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
                    NewField11451.Value = @"Başlangıç-Bitiş Tarihi";

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
                    EXAMINATIONDATE.Value = @"";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 53, 99, 58, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.ObjectDefName = "StatusNotificationReport";
                    FATHERNAME.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{@OBJECTID@}";

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
                    MR.Value = @"{#MR#}";

                    STARTENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 69, 200, 72, false);
                    STARTENDDATE.Name = "STARTENDDATE";
                    STARTENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTENDDATE.TextFont.Size = 8;
                    STARTENDDATE.TextFont.CharSet = 162;
                    STARTENDDATE.Value = @"{%STARTDATE%}-{%ENDDATE%}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 46, 161, 51, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 60, 102, 65, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"dd/MM/yyyy";
                    DTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    DTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    DTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    DTARIHI.ObjectDefName = "StatusNotificationReport";
                    DTARIHI.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DTARIHI.TextFont.Size = 8;
                    DTARIHI.TextFont.CharSet = 162;
                    DTARIHI.Value = @"{@OBJECTID@}";

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

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 74, 251, 79, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{#STARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 83, 251, 88, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{#ENDDATE#}";

                    TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 76, 98, 81, false);
                    TEL.Name = "TEL";
                    TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEL.ObjectDefName = "StatusNotificationReport";
                    TEL.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.MOBILEPHONE";
                    TEL.TextFont.Size = 8;
                    TEL.TextFont.CharSet = 162;
                    TEL.Value = @"{@OBJECTID@}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 83, 200, 90, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADDRESS.ObjectDefName = "StatusNotificationReport";
                    ADDRESS.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.HOMEADDRESS";
                    ADDRESS.TextFont.Size = 8;
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"{@OBJECTID@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 11, 204, 34, false);
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
                    KURUMU.Value = @"";

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
                    PATIENTSTATUS.ObjectDefName = "PatientStatusEnum";
                    PATIENTSTATUS.DataMember = "DISPLAYTEXT";
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"{#PATIENTSTATUS#}";

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
                    NewField116411.Value = @"H.Protokol No";

                    HPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 76, 200, 81, false);
                    HPROTOCOLNO.Name = "HPROTOCOLNO";
                    HPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOCOLNO.TextFont.Size = 8;
                    HPROTOCOLNO.TextFont.CharSet = 162;
                    HPROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StatusNotificationReport.GetStatusNotificationRaportRNQL_Class dataset_GetStatusNotificationRaportRNQL = ParentGroup.rsGroup.GetCurrentRecord<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(0);
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BASLIK.CalcValue = MyParentReport.PARTA.XXXXXXBASLIK.CalcValue;
                    NewField111.CalcValue = NewField111.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    SURNAME.PostFieldValueCalculation();
                    REPORTNO.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.ReportNo) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField11451.CalcValue = NewField11451.Value;
                    NAMESURNAME.CalcValue = MyParentReport.PARTA.NAME.CalcValue + @" " + MyParentReport.PARTA.SURNAME.CalcValue;
                    EXAMINATIONDATE.CalcValue = @"";
                    FATHERNAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    FATHERNAME.PostFieldValueCalculation();
                    MR.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.Mr) : "");
                    STARTDATE.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.StartDate) : "");
                    ENDDATE.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.EndDate) : "");
                    STARTENDDATE.CalcValue = MyParentReport.PARTA.STARTDATE.FormattedValue + @"-" + MyParentReport.PARTA.ENDDATE.FormattedValue;
                    UNIQUEREFNO.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.UniqueRefNo) : "");
                    DTARIHI.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    DTARIHI.PostFieldValueCalculation();
                    NewField11461.CalcValue = NewField11461.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    TEL.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    TEL.PostFieldValueCalculation();
                    ADDRESS.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    ADDRESS.PostFieldValueCalculation();
                    LOGO.CalcValue = @"";
                    KURUMU.CalcValue = @"";
                    NewField1141.CalcValue = NewField1141.Value;
                    PATIENTSTATUS.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.PatientStatus) : "");
                    PATIENTSTATUS.PostFieldValueCalculation();
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField116411.CalcValue = NewField116411.Value;
                    HPROTOCOLNO.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.HospitalProtocolNo) : "");
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");
                    return new TTReportObject[] { XXXXXXBASLIK,BASLIK,NewField111,NAME,SURNAME,REPORTNO,NewField121,NewField1121,NewField1131,NewField1151,NewField1161,NewField11421,NewField11431,NewField11451,NAMESURNAME,EXAMINATIONDATE,FATHERNAME,MR,STARTDATE,ENDDATE,STARTENDDATE,UNIQUEREFNO,DTARIHI,NewField11461,NewField113411,TEL,ADDRESS,LOGO,KURUMU,NewField1141,PATIENTSTATUS,NewField112411,NewField116411,HPROTOCOLNO,XXXXXXIL,XXXXXXALTBASLIK};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport )context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            
             if (report.HCRequestReason.ObjectID.ToString() == "f9b7c97b-073c-4f14-a3d2-db4e73bafe8f" ||
                 report.HCRequestReason.ObjectID.ToString() == "402650d7-d53d-4855-82b5-ac0a7520d9e0")
                    {
                        this.NewField111.CalcValue = "DURUM BİLDİRİR TEK HEKİM SAĞLIK RAPORU";
                    }
                    else if (report.HCRequestReason.ObjectID.ToString() == "43a28b0f-e419-4ef0-a028-039fc40e4a77" ||
                             report.HCRequestReason.ObjectID.ToString() == "bf32a4f5-79a8-4b9b-8200-1e15e56cc524" ||
                             report.HCRequestReason.ObjectID.ToString() == "97c1f9a9-4a18-4720-ba75-6f3b0fbc0841" ||
                             report.HCRequestReason.ObjectID.ToString() == "9de74dab-2fe2-430c-9621-39ffadbfc9cf"
                             )
                    {
                        this.NewField111.CalcValue = "DURUM BİLDİRİRSAĞLIK KURULU RAPORU";
                    } else if(report.HCRequestReason.ObjectID.ToString() == "4887e4e6-efb3-46ca-9689-6e997a9d246e" ||
                             report.HCRequestReason.ObjectID.ToString() == "d5630c69-15e4-4762-a6d0-0731d59f7759" ||
                             report.HCRequestReason.ObjectID.ToString() == "bc80a3d8-2485-4583-85b2-d6a2d5248b2d" ||
                             report.HCRequestReason.ObjectID.ToString() == "b74fb02b-24c8-41d8-8ca3-dc357b275660"
                             )
                    {
                        this.NewField111.CalcValue = "İLAÇ KULLANIM RAPORU";
                    }
                    else if (report.HCRequestReason.ObjectID.ToString() == "3ad998b1-111a-4e18-82b8-b21305f0f504" ||
                          report.HCRequestReason.ObjectID.ToString() == "ec2bbc8c-5c50-4382-b028-e34542897d90"
                          )
                    {
                        this.NewField111.CalcValue = "İSTİRAHAT RAPORU";
                    }
                    else if (report.HCRequestReason.ObjectID.ToString() == "842e1769-fff2-415d-80bb-30281dbf6b1e" ||
                        report.HCRequestReason.ObjectID.ToString() == "02c9df60-3507-4c14-8162-1ba5584ae897" ||
                        report.HCRequestReason.ObjectID.ToString() == "77b8dc29-8850-4733-8d31-5b51bf0d080b"
                        )
                    {
                        this.NewField111.CalcValue = "TIBBİ MALZEME RAPORU";
             } else {
                 this.NewField111.CalcValue = report.HCRequestReason.ReasonName.ToString();
             }

            this.KURUMU.CalcValue = report.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
            
             this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
             this.PATIENTSTATUS.CalcValue =  report.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
            SubEpisode subepisode = report.SubEpisode;
             
            if(report.ReportDurationType != null){
                if(report.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue)
                    this.STARTENDDATE.CalcValue =((DateTime)report.StartDate).ToString("dd.MM.yyyy")+ " - " +"Halen Devam Ediyor";
            }
             while(subepisode.OldSubEpisode != null){
                subepisode = subepisode.OldSubEpisode;
             }
             
            foreach(EpisodeAction episodeAction in subepisode.EpisodeActions){
                if(episodeAction is PatientExamination && episodeAction.IsCancelled == false)
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
                public StatusNotificationReportReport MyParentReport
                {
                    get { return (StatusNotificationReportReport)ParentReport; }
                }
                
                public TTReportField DOKTOR1;
                public TTReportField SIGNATURE2;
                public TTReportField ONAY;
                public TTReportField ONAYTARIH;
                public TTReportField HEADDOCTOR;
                public TTReportField HEADDOCTOROBJECTID;
                public TTReportField ONAYLABEL;
                public TTReportField DOKTOR1BOLUM;
                public TTReportField DOKTOR1DIPNO;
                public TTReportField DOKTOR2;
                public TTReportField DOKTOR2BOLUM;
                public TTReportField DOKTOR2DIPNO;
                public TTReportField DOKTOR3;
                public TTReportField DOKTOR3BOLUM;
                public TTReportField DOKTOR3DIPNO;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField SIGNATURE3;
                public TTReportField SIGNATURE1;
                public TTReportField NewField15;
                public TTReportField NAME1;
                public TTReportField SURNAME1;
                public TTReportField NewField1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 92;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 12, 74, 18, false);
                    DOKTOR1.Name = "DOKTOR1";
                    DOKTOR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1.TextFont.Size = 8;
                    DOKTOR1.TextFont.CharSet = 162;
                    DOKTOR1.Value = @"";

                    SIGNATURE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 3, 139, 8, false);
                    SIGNATURE2.Name = "SIGNATURE2";
                    SIGNATURE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE2.TextFont.Size = 8;
                    SIGNATURE2.TextFont.Bold = true;
                    SIGNATURE2.TextFont.CharSet = 162;
                    SIGNATURE2.Value = @"İMZA";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 26, 121, 31, false);
                    ONAY.Name = "ONAY";
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Size = 8;
                    ONAY.TextFont.Bold = true;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"ONAY";

                    ONAYTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 31, 129, 36, false);
                    ONAYTARIH.Name = "ONAYTARIH";
                    ONAYTARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYTARIH.TextFont.Size = 8;
                    ONAYTARIH.TextFont.CharSet = 162;
                    ONAYTARIH.Value = @"...../...../........";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 35, 133, 41, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTOR.TextFont.Size = 8;
                    HEADDOCTOR.TextFont.CharSet = 162;
                    HEADDOCTOR.Value = @"";

                    HEADDOCTOROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 14, 246, 19, false);
                    HEADDOCTOROBJECTID.Name = "HEADDOCTOROBJECTID";
                    HEADDOCTOROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOROBJECTID.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOROBJECTID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR_OBJECTID"", """")";

                    ONAYLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 41, 121, 46, false);
                    ONAYLABEL.Name = "ONAYLABEL";
                    ONAYLABEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYLABEL.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYLABEL.TextFont.Size = 8;
                    ONAYLABEL.TextFont.CharSet = 162;
                    ONAYLABEL.Value = @"Başhekim";

                    DOKTOR1BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 74, 12, false);
                    DOKTOR1BOLUM.Name = "DOKTOR1BOLUM";
                    DOKTOR1BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1BOLUM.TextFont.Size = 8;
                    DOKTOR1BOLUM.TextFont.CharSet = 162;
                    DOKTOR1BOLUM.Value = @"";

                    DOKTOR1DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 17, 74, 22, false);
                    DOKTOR1DIPNO.Name = "DOKTOR1DIPNO";
                    DOKTOR1DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1DIPNO.TextFont.Size = 8;
                    DOKTOR1DIPNO.TextFont.CharSet = 162;
                    DOKTOR1DIPNO.Value = @"";

                    DOKTOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 12, 139, 18, false);
                    DOKTOR2.Name = "DOKTOR2";
                    DOKTOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2.TextFont.Size = 8;
                    DOKTOR2.TextFont.CharSet = 162;
                    DOKTOR2.Value = @"";

                    DOKTOR2BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 8, 139, 12, false);
                    DOKTOR2BOLUM.Name = "DOKTOR2BOLUM";
                    DOKTOR2BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2BOLUM.TextFont.Size = 8;
                    DOKTOR2BOLUM.TextFont.CharSet = 162;
                    DOKTOR2BOLUM.Value = @"";

                    DOKTOR2DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 17, 139, 22, false);
                    DOKTOR2DIPNO.Name = "DOKTOR2DIPNO";
                    DOKTOR2DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2DIPNO.TextFont.Size = 8;
                    DOKTOR2DIPNO.TextFont.CharSet = 162;
                    DOKTOR2DIPNO.Value = @"";

                    DOKTOR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 12, 202, 18, false);
                    DOKTOR3.Name = "DOKTOR3";
                    DOKTOR3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3.TextFont.Size = 8;
                    DOKTOR3.TextFont.CharSet = 162;
                    DOKTOR3.Value = @"";

                    DOKTOR3BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 8, 202, 12, false);
                    DOKTOR3BOLUM.Name = "DOKTOR3BOLUM";
                    DOKTOR3BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3BOLUM.TextFont.Size = 8;
                    DOKTOR3BOLUM.TextFont.CharSet = 162;
                    DOKTOR3BOLUM.Value = @"";

                    DOKTOR3DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 17, 202, 22, false);
                    DOKTOR3DIPNO.Name = "DOKTOR3DIPNO";
                    DOKTOR3DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3DIPNO.TextFont.Size = 8;
                    DOKTOR3DIPNO.TextFont.CharSet = 162;
                    DOKTOR3DIPNO.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 56, 206, 61, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"*Hekim sayısı durum bildirir raporun niteliğine göre belirlenecek olup, hekim imza adedi daha fazla veya daha az olabilir.";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 51, 34, 56, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Açıklama";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 71, 206, 76, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"";

                    SIGNATURE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 3, 74, 8, false);
                    SIGNATURE3.Name = "SIGNATURE3";
                    SIGNATURE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE3.TextFont.Size = 8;
                    SIGNATURE3.TextFont.Bold = true;
                    SIGNATURE3.TextFont.CharSet = 162;
                    SIGNATURE3.Value = @"İMZA";

                    SIGNATURE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 3, 202, 8, false);
                    SIGNATURE1.Name = "SIGNATURE1";
                    SIGNATURE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE1.TextFont.Size = 8;
                    SIGNATURE1.TextFont.Bold = true;
                    SIGNATURE1.TextFont.CharSet = 162;
                    SIGNATURE1.Value = @"İMZA";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 61, 206, 66, false);
                    NewField15.Name = "NewField15";
                    NewField15.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"*{#UNIQUEREFNO#} TC Kimlik numaralı {%NAME1%} {%SURNAME1%}'ın {#REPORTNO#} numaralı raporudur.
";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 31, 260, 36, false);
                    NAME1.Name = "NAME1";
                    NAME1.Visible = EvetHayirEnum.ehHayir;
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME1.ObjectDefName = "StatusNotificationReport";
                    NAME1.DataMember = "EPISODE.PATIENT.NAME";
                    NAME1.Value = @"{@OBJECTID@}";

                    SURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 26, 260, 31, false);
                    SURNAME1.Name = "SURNAME1";
                    SURNAME1.Visible = EvetHayirEnum.ehHayir;
                    SURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME1.ObjectDefName = "StatusNotificationReport";
                    SURNAME1.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME1.Value = @"{@OBJECTID@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 66, 206, 71, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StatusNotificationReport.GetStatusNotificationRaportRNQL_Class dataset_GetStatusNotificationRaportRNQL = ParentGroup.rsGroup.GetCurrentRecord<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(0);
                    DOKTOR1.CalcValue = DOKTOR1.Value;
                    SIGNATURE2.CalcValue = SIGNATURE2.Value;
                    ONAY.CalcValue = ONAY.Value;
                    ONAYTARIH.CalcValue = ONAYTARIH.Value;
                    HEADDOCTOR.CalcValue = HEADDOCTOR.Value;
                    ONAYLABEL.CalcValue = ONAYLABEL.Value;
                    DOKTOR1BOLUM.CalcValue = DOKTOR1BOLUM.Value;
                    DOKTOR1DIPNO.CalcValue = DOKTOR1DIPNO.Value;
                    DOKTOR2.CalcValue = DOKTOR2.Value;
                    DOKTOR2BOLUM.CalcValue = DOKTOR2BOLUM.Value;
                    DOKTOR2DIPNO.CalcValue = DOKTOR2DIPNO.Value;
                    DOKTOR3.CalcValue = DOKTOR3.Value;
                    DOKTOR3BOLUM.CalcValue = DOKTOR3BOLUM.Value;
                    DOKTOR3DIPNO.CalcValue = DOKTOR3DIPNO.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    SIGNATURE3.CalcValue = SIGNATURE3.Value;
                    SIGNATURE1.CalcValue = SIGNATURE1.Value;
                    NAME1.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    NAME1.PostFieldValueCalculation();
                    SURNAME1.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    SURNAME1.PostFieldValueCalculation();
                    NewField15.CalcValue = @"*" + (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.UniqueRefNo) : "") + @" TC Kimlik numaralı " + MyParentReport.PARTA.NAME1.CalcValue + @" " + MyParentReport.PARTA.SURNAME1.CalcValue + @"'ın " + (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.ReportNo) : "") + @" numaralı raporudur.
";
                    NewField1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    HEADDOCTOROBJECTID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
                    return new TTReportObject[] { DOKTOR1,SIGNATURE2,ONAY,ONAYTARIH,HEADDOCTOR,ONAYLABEL,DOKTOR1BOLUM,DOKTOR1DIPNO,DOKTOR2,DOKTOR2BOLUM,DOKTOR2DIPNO,DOKTOR3,DOKTOR3BOLUM,DOKTOR3DIPNO,NewField3,NewField4,NewField5,SIGNATURE3,SIGNATURE1,NAME1,SURNAME1,NewField15,NewField1,HEADDOCTOROBJECTID};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
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
             
                      
                this.DOKTOR2DIPNO.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR2.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR2BOLUM.Visible = EvetHayirEnum.ehHayir; 
                
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehHayir; 
                this.DOKTOR3DIPNO.Visible = EvetHayirEnum.ehHayir; 
                
                
            }
            
            if(statusNotificationReport.HCRequestReason.ObjectID.ToString() == "842e1769-fff2-415d-80bb-30281dbf6b1e" ||
                        statusNotificationReport.HCRequestReason.ObjectID.ToString() == "02c9df60-3507-4c14-8162-1ba5584ae897" ||
                        statusNotificationReport.HCRequestReason.ObjectID.ToString() == "77b8dc29-8850-4733-8d31-5b51bf0d080b"){
                 this.ONAY.Visible = EvetHayirEnum.ehEvet;
                this.ONAYTARIH.Visible = EvetHayirEnum.ehEvet;
                this.HEADDOCTOR.Visible = EvetHayirEnum.ehEvet;
                this.ONAYLABEL.Visible = EvetHayirEnum.ehEvet;
                
            }else {
                this.ONAY.Visible = EvetHayirEnum.ehHayir;
                this.ONAYTARIH.Visible = EvetHayirEnum.ehHayir;
                this.HEADDOCTOR.Visible = EvetHayirEnum.ehHayir;
                this.ONAYLABEL.Visible = EvetHayirEnum.ehHayir;
                
            }
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
            public StatusNotificationReportReport MyParentReport
            {
                get { return (StatusNotificationReportReport)ParentReport; }
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
                public StatusNotificationReportReport MyParentReport
                {
                    get { return (StatusNotificationReportReport)ParentReport; }
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
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Unicode MS";
                    TANI.TextFont.Size = 8;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"{#PARTA.DIAGNOSISDETAIL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StatusNotificationReport.GetStatusNotificationRaportRNQL_Class dataset_GetStatusNotificationRaportRNQL = MyParentReport.PARTA.rsGroup.GetCurrentRecord<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(0);
                    NewField111911.CalcValue = NewField111911.Value;
                    TANI.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.DiagnosisDetail) : "");
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
                    //                                                TTObjectContext context = new TTObjectContext(true);
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
            public StatusNotificationReportReport MyParentReport
            {
                get { return (StatusNotificationReportReport)ParentReport; }
            }

            new public ACIKLAMAGroupBody Body()
            {
                return (ACIKLAMAGroupBody)_body;
            }
            public TTReportField LBLACIKLAMA { get {return Body().LBLACIKLAMA;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
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
                public StatusNotificationReportReport MyParentReport
                {
                    get { return (StatusNotificationReportReport)ParentReport; }
                }
                
                public TTReportField LBLACIKLAMA;
                public TTReportField ACIKLAMA; 
                public ACIKLAMAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    LBLACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 61, 5, false);
                    LBLACIKLAMA.Name = "LBLACIKLAMA";
                    LBLACIKLAMA.TextFont.Name = "Arial";
                    LBLACIKLAMA.TextFont.Size = 9;
                    LBLACIKLAMA.TextFont.Bold = true;
                    LBLACIKLAMA.TextFont.CharSet = 162;
                    LBLACIKLAMA.Value = @"AÇIKLAMA";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 199, 17, false);
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
                    LBLACIKLAMA.CalcValue = LBLACIKLAMA.Value;
                    ACIKLAMA.CalcValue = ACIKLAMA.Value;
                    return new TTReportObject[] { LBLACIKLAMA,ACIKLAMA};
                }
                public override void RunPreScript()
                {
#region ACIKLAMA BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if (statusNotificationReport.ReportDescription != null && statusNotificationReport.ReportDescription != "")
                    {
                        this.ACIKLAMA.Value = statusNotificationReport.ReportDescription;
                    }
                    else
                    {
                        this.Visible = EvetHayirEnum.ehHayir;
                    }
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

        public partial class BULGULARGroup : TTReportGroup
        {
            public StatusNotificationReportReport MyParentReport
            {
                get { return (StatusNotificationReportReport)ParentReport; }
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
                public StatusNotificationReportReport MyParentReport
                {
                    get { return (StatusNotificationReportReport)ParentReport; }
                }
                
                public TTReportField NewField1119111;
                public TTReportField BULGU; 
                public BULGULARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 61, 5, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.TextFont.Name = "Arial";
                    NewField1119111.TextFont.Size = 9;
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.CharSet = 162;
                    NewField1119111.Value = @"MUAYENE BULGULARI";

                    BULGU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 199, 16, false);
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
                    //                                                                            TTObjectContext context = new TTObjectContext(true);
//            //System.Diagnostics.Debugger.Break();
//            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
//            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
//             if(statusNotificationReport.Description != null)
//             {
//                 this.SIGNS.Value = statusNotificationReport.Description + "\r\n";
//             }
//               
TTObjectContext context = new TTObjectContext(true);
        string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if(statusNotificationReport.Description != null)
             {
                 this.BULGU.Value = TTReportTool.TTReport.HTMLtoText(statusNotificationReport.Description.ToString());
             }else
                    {
                        this.Visible = EvetHayirEnum.ehHayir;
                    }
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

        public partial class KARARGroup : TTReportGroup
        {
            public StatusNotificationReportReport MyParentReport
            {
                get { return (StatusNotificationReportReport)ParentReport; }
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
                public StatusNotificationReportReport MyParentReport
                {
                    get { return (StatusNotificationReportReport)ParentReport; }
                }
                
                public TTReportField NewField11119111;
                public TTReportField KARAR; 
                public KARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
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
            string sObjectID = ((StatusNotificationReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if(statusNotificationReport.ReportDecision != null)
             {
                 this.KARAR.Value =TTReportTool.TTReport.HTMLtoText(statusNotificationReport.ReportDecision.ToString());
             }
#endregion KARAR BODY_PreScript
                }
            }

        }

        public KARARGroup KARAR;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StatusNotificationReportReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            ACIKLAMA = new ACIKLAMAGroup(PARTA,"ACIKLAMA");
            BULGULAR = new BULGULARGroup(PARTA,"BULGULAR");
            KARAR = new KARARGroup(PARTA,"KARAR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            Name = "STATUSNOTIFICATIONREPORTREPORT";
            Caption = "Durum Bildirir Raporu";
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