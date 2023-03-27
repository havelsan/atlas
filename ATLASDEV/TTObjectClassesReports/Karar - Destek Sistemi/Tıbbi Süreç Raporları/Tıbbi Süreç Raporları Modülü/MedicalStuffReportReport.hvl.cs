
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
    /// Tıbbi Malzeme Raporu
    /// </summary>
    public partial class MedicalStuffReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Group1Group : TTReportGroup
        {
            public MedicalStuffReportReport MyParentReport
            {
                get { return (MedicalStuffReportReport)ParentReport; }
            }

            new public Group1GroupHeader Header()
            {
                return (Group1GroupHeader)_header;
            }

            new public Group1GroupFooter Footer()
            {
                return (Group1GroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXALTBASLIK { get {return Header().XXXXXXALTBASLIK;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportShape NewRect1111 { get {return Header().NewRect1111;} }
            public TTReportField REPORTNO { get {return Header().REPORTNO;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportShape NewLine1131 { get {return Header().NewLine1131;} }
            public TTReportShape NewLine1161 { get {return Header().NewLine1161;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField115411 { get {return Header().NewField115411;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField EXAMINATIONDATE { get {return Header().EXAMINATIONDATE;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField MR { get {return Header().MR;} }
            public TTReportField STARTENDDATE { get {return Header().STARTENDDATE;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportField NewField116411 { get {return Header().NewField116411;} }
            public TTReportShape NewLine11511 { get {return Header().NewLine11511;} }
            public TTReportField NewField1114311 { get {return Header().NewField1114311;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField KURUMU { get {return Header().KURUMU;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField MEDULATAKIP { get {return Header().MEDULATAKIP;} }
            public TTReportField NewField1114611 { get {return Header().NewField1114611;} }
            public TTReportField HPROTOCOLNO { get {return Header().HPROTOCOLNO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine11211 { get {return Header().NewLine11211;} }
            public TTReportShape NewLine111511 { get {return Header().NewLine111511;} }
            public TTReportField NewField1114212 { get {return Header().NewField1114212;} }
            public TTReportShape NewLine1115111 { get {return Header().NewLine1115111;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField DOKTOR1 { get {return Footer().DOKTOR1;} }
            public TTReportField SIGNATURE2 { get {return Footer().SIGNATURE2;} }
            public TTReportField ONAY1 { get {return Footer().ONAY1;} }
            public TTReportField ONAYTARIH1 { get {return Footer().ONAYTARIH1;} }
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
            public TTReportField SIGNATURE3 { get {return Footer().SIGNATURE3;} }
            public TTReportField SIGNATURE1 { get {return Footer().SIGNATURE1;} }
            public TTReportField NAME1 { get {return Footer().NAME1;} }
            public TTReportField SURNAME1 { get {return Footer().SURNAME1;} }
            public TTReportField HEADDOCTORDIPNO { get {return Footer().HEADDOCTORDIPNO;} }
            public Group1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Group1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _header = new Group1GroupHeader(this);
                _footer = new Group1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Group1GroupHeader : TTReportSection
            {
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField NewField1111;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXALTBASLIK;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportShape NewRect1111;
                public TTReportField REPORTNO;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine1161;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField11311;
                public TTReportField NewField11511;
                public TTReportField NewField11611;
                public TTReportField NewField112411;
                public TTReportField NewField115411;
                public TTReportField NAMESURNAME;
                public TTReportField EXAMINATIONDATE;
                public TTReportField FATHERNAME;
                public TTReportField MR;
                public TTReportField STARTENDDATE;
                public TTReportField UNIQUEREFNO;
                public TTReportField DTARIHI;
                public TTReportField NewField116411;
                public TTReportShape NewLine11511;
                public TTReportField NewField1114311;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField ADDRESS;
                public TTReportField LOGO;
                public TTReportField KURUMU;
                public TTReportField NewField11411;
                public TTReportField PATIENTSTATUS;
                public TTReportField MEDULATAKIP;
                public TTReportField NewField1114611;
                public TTReportField HPROTOCOLNO;
                public TTReportField NewField1;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine111511;
                public TTReportField NewField1114212;
                public TTReportShape NewLine1115111;
                public TTReportField PROTOCOLNO; 
                public Group1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 138;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 20, 174, 49, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Arial Unicode MS";
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"{%XXXXXXBASLIK%}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 51, 170, 60, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial Unicode MS";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"TIBBİ MALZEME RAPORU";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 15, 257, 21, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 257, 7, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    XXXXXXALTBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 8, 257, 14, false);
                    XXXXXXALTBASLIK.Name = "XXXXXXALTBASLIK";
                    XXXXXXALTBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXALTBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXALTBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXALTBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXALTBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXALTBASLIK.TextFont.Size = 11;
                    XXXXXXALTBASLIK.TextFont.Bold = true;
                    XXXXXXALTBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALSUBNAME"", """")";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 32, 256, 37, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "StatusNotificationReport";
                    NAME.DataMember = "EPISODE.PATIENT.NAME";
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{@OBJECTID@}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 27, 256, 32, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME.ObjectDefName = "StatusNotificationReport";
                    SURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME.TextFont.CharSet = 1;
                    SURNAME.Value = @"{@OBJECTID@}";

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 17, 70, 198, 136, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 101, 171, 106, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Name = "Arial Unicode MS";
                    REPORTNO.TextFont.Size = 8;
                    REPORTNO.Value = @"{#REPORTNO#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 77, 198, 77, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 84, 198, 84, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 94, 198, 94, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 112, 70, 112, 122, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 71, 49, 76, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Unicode MS";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Adı Soyadı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 78, 139, 83, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Unicode MS";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Muayene Tarihi";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 85, 52, 90, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial Unicode MS";
                    NewField11311.TextFont.Size = 8;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @"Doğum Tarihi";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 78, 44, 83, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial Unicode MS";
                    NewField11511.TextFont.Size = 8;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"Baba Adı";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 85, 139, 90, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial Unicode MS";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.Value = @"Poliklinik";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 71, 139, 76, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.TextFont.Name = "Arial Unicode MS";
                    NewField112411.TextFont.Size = 8;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.Value = @"T.C Kimlik No";

                    NewField115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 109, 148, 113, false);
                    NewField115411.Name = "NewField115411";
                    NewField115411.TextFont.Name = "Arial Unicode MS";
                    NewField115411.TextFont.Size = 8;
                    NewField115411.TextFont.Bold = true;
                    NewField115411.Value = @"Başlangıç-Bitiş Tarihi";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 71, 109, 76, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Name = "Arial Unicode MS";
                    NAMESURNAME.TextFont.Size = 8;
                    NAMESURNAME.Value = @"{%NAME%} {%SURNAME%}";

                    EXAMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 78, 192, 83, false);
                    EXAMINATIONDATE.Name = "EXAMINATIONDATE";
                    EXAMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXAMINATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXAMINATIONDATE.TextFont.Name = "Arial Unicode MS";
                    EXAMINATIONDATE.TextFont.Size = 8;
                    EXAMINATIONDATE.Value = @"";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 78, 108, 83, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.ObjectDefName = "StatusNotificationReport";
                    FATHERNAME.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    FATHERNAME.TextFont.Name = "Arial Unicode MS";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{@OBJECTID@}";

                    MR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 85, 192, 88, false);
                    MR.Name = "MR";
                    MR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MR.MultiLine = EvetHayirEnum.ehEvet;
                    MR.NoClip = EvetHayirEnum.ehEvet;
                    MR.WordBreak = EvetHayirEnum.ehEvet;
                    MR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MR.TextFont.Name = "Arial Unicode MS";
                    MR.TextFont.Size = 8;
                    MR.Value = @"{#MR#}";

                    STARTENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 110, 193, 113, false);
                    STARTENDDATE.Name = "STARTENDDATE";
                    STARTENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTENDDATE.TextFont.Name = "Arial Unicode MS";
                    STARTENDDATE.TextFont.Size = 8;
                    STARTENDDATE.Value = @"{%STARTDATE%}-{%ENDDATE%}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 71, 174, 76, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Name = "Arial Unicode MS";
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 85, 111, 90, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"dd/MM/yyyy";
                    DTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    DTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    DTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    DTARIHI.ObjectDefName = "StatusNotificationReport";
                    DTARIHI.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DTARIHI.TextFont.Name = "Arial Unicode MS";
                    DTARIHI.TextFont.Size = 8;
                    DTARIHI.Value = @"{@OBJECTID@}";

                    NewField116411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 101, 134, 106, false);
                    NewField116411.Name = "NewField116411";
                    NewField116411.TextFont.Name = "Arial Unicode MS";
                    NewField116411.TextFont.Size = 8;
                    NewField116411.TextFont.Bold = true;
                    NewField116411.Value = @"Rapor No";

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 107, 198, 107, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 124, 44, 129, false);
                    NewField1114311.Name = "NewField1114311";
                    NewField1114311.TextFont.Name = "Arial Unicode MS";
                    NewField1114311.TextFont.Size = 8;
                    NewField1114311.TextFont.Bold = true;
                    NewField1114311.Value = @"Adres";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 69, 250, 74, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.CharSet = 1;
                    STARTDATE.Value = @"{#STARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 78, 250, 83, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.CharSet = 1;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 124, 196, 131, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADDRESS.ObjectDefName = "StatusNotificationReport";
                    ADDRESS.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.HOMEADDRESS";
                    ADDRESS.TextFont.Name = "Arial Unicode MS";
                    ADDRESS.TextFont.Size = 8;
                    ADDRESS.Value = @"{@OBJECTID@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 22, 205, 45, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    KURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 96, 111, 105, false);
                    KURUMU.Name = "KURUMU";
                    KURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMU.NoClip = EvetHayirEnum.ehEvet;
                    KURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMU.TextFont.Name = "Arial Unicode MS";
                    KURUMU.TextFont.Size = 8;
                    KURUMU.Value = @"";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 95, 52, 106, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial Unicode MS";
                    NewField11411.TextFont.Size = 8;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @"Sosyal Güvencesi/
Kurumu:";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 116, 80, 121, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.VertAlign = VerticalAlignmentEnum.vaBottom;
                    PATIENTSTATUS.ObjectDefName = "PatientStatusEnum";
                    PATIENTSTATUS.DataMember = "DISPLAYTEXT";
                    PATIENTSTATUS.TextFont.Name = "Arial Unicode MS";
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.Value = @"{#PATIENTSTATUS#}";

                    MEDULATAKIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 116, 49, 121, false);
                    MEDULATAKIP.Name = "MEDULATAKIP";
                    MEDULATAKIP.VertAlign = VerticalAlignmentEnum.vaBottom;
                    MEDULATAKIP.TextFont.Name = "Arial Unicode MS";
                    MEDULATAKIP.TextFont.Size = 8;
                    MEDULATAKIP.TextFont.Bold = true;
                    MEDULATAKIP.Value = @"GSS Provizyon No";

                    NewField1114611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 95, 145, 100, false);
                    NewField1114611.Name = "NewField1114611";
                    NewField1114611.TextFont.Name = "Arial Unicode MS";
                    NewField1114611.TextFont.Size = 8;
                    NewField1114611.TextFont.Bold = true;
                    NewField1114611.Value = @"Online Protokol No";

                    HPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 87, 245, 92, false);
                    HPROTOCOLNO.Name = "HPROTOCOLNO";
                    HPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    HPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOCOLNO.TextFont.Name = "Arial Unicode MS";
                    HPROTOCOLNO.TextFont.Size = 8;
                    HPROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 63, 198, 70, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial Unicode MS";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"BAŞVURU SAHİBİNİN:";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 63, 198, 63, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 63, 198, 69, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 112, 101, 198, 101, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 114, 198, 114, false);
                    NewLine111511.Name = "NewLine111511";
                    NewLine111511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1114212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 108, 44, 113, false);
                    NewField1114212.Name = "NewField1114212";
                    NewField1114212.TextFont.Name = "Arial Unicode MS";
                    NewField1114212.TextFont.Size = 8;
                    NewField1114212.TextFont.Bold = true;
                    NewField1114212.Value = @"Sicil No";

                    NewLine1115111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 122, 198, 122, false);
                    NewLine1115111.Name = "NewLine1115111";
                    NewLine1115111.DrawStyle = DrawStyleConstants.vbSolid;

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 95, 175, 100, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.TextFont.Name = "Arial Unicode MS";
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StatusNotificationReport.GetStatusNotificationRaportRNQL_Class dataset_GetStatusNotificationRaportRNQL = ParentGroup.rsGroup.GetCurrentRecord<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(0);
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BASLIK.CalcValue = MyParentReport.Group1.XXXXXXBASLIK.CalcValue;
                    NewField1111.CalcValue = NewField1111.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    SURNAME.PostFieldValueCalculation();
                    REPORTNO.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.ReportNo) : "");
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField115411.CalcValue = NewField115411.Value;
                    NAMESURNAME.CalcValue = MyParentReport.Group1.NAME.CalcValue + @" " + MyParentReport.Group1.SURNAME.CalcValue;
                    EXAMINATIONDATE.CalcValue = @"";
                    FATHERNAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    FATHERNAME.PostFieldValueCalculation();
                    MR.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.Mr) : "");
                    STARTDATE.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.StartDate) : "");
                    ENDDATE.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.EndDate) : "");
                    STARTENDDATE.CalcValue = MyParentReport.Group1.STARTDATE.FormattedValue + @"-" + MyParentReport.Group1.ENDDATE.FormattedValue;
                    UNIQUEREFNO.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.UniqueRefNo) : "");
                    DTARIHI.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    DTARIHI.PostFieldValueCalculation();
                    NewField116411.CalcValue = NewField116411.Value;
                    NewField1114311.CalcValue = NewField1114311.Value;
                    ADDRESS.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    ADDRESS.PostFieldValueCalculation();
                    LOGO.CalcValue = @"";
                    KURUMU.CalcValue = @"";
                    NewField11411.CalcValue = NewField11411.Value;
                    PATIENTSTATUS.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.PatientStatus) : "");
                    PATIENTSTATUS.PostFieldValueCalculation();
                    MEDULATAKIP.CalcValue = MEDULATAKIP.Value;
                    NewField1114611.CalcValue = NewField1114611.Value;
                    HPROTOCOLNO.CalcValue = (dataset_GetStatusNotificationRaportRNQL != null ? Globals.ToStringCore(dataset_GetStatusNotificationRaportRNQL.HospitalProtocolNo) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField1114212.CalcValue = NewField1114212.Value;
                    PROTOCOLNO.CalcValue = PROTOCOLNO.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");
                    return new TTReportObject[] { XXXXXXBASLIK,BASLIK,NewField1111,NAME,SURNAME,REPORTNO,NewField1121,NewField11211,NewField11311,NewField11511,NewField11611,NewField112411,NewField115411,NAMESURNAME,EXAMINATIONDATE,FATHERNAME,MR,STARTDATE,ENDDATE,STARTENDDATE,UNIQUEREFNO,DTARIHI,NewField116411,NewField1114311,ADDRESS,LOGO,KURUMU,NewField11411,PATIENTSTATUS,MEDULATAKIP,NewField1114611,HPROTOCOLNO,NewField1,NewField1114212,PROTOCOLNO,XXXXXXIL,XXXXXXALTBASLIK};
                }

                public override void RunScript()
                {
#region GROUP1 HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);                                    
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport )context.GetObject(new Guid(sObjectID),"StatusNotificationReport");

            this.KURUMU.CalcValue = report.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
            this.PROTOCOLNO.CalcValue = report.SubEpisode.ProtocolNo;
             this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
             this.PATIENTSTATUS.CalcValue =  report.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
            SubEpisode subepisode = report.SubEpisode;
             
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
#endregion GROUP1 HEADER_Script
                }
            }
            public partial class Group1GroupFooter : TTReportSection
            {
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField DOKTOR1;
                public TTReportField SIGNATURE2;
                public TTReportField ONAY1;
                public TTReportField ONAYTARIH1;
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
                public TTReportField SIGNATURE3;
                public TTReportField SIGNATURE1;
                public TTReportField NAME1;
                public TTReportField SURNAME1;
                public TTReportField HEADDOCTORDIPNO; 
                public Group1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 60;
                    RepeatCount = 0;
                    
                    DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 73, 21, false);
                    DOKTOR1.Name = "DOKTOR1";
                    DOKTOR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1.TextFont.Size = 8;
                    DOKTOR1.Value = @"";

                    SIGNATURE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 6, 138, 11, false);
                    SIGNATURE2.Name = "SIGNATURE2";
                    SIGNATURE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE2.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE2.TextFont.Size = 8;
                    SIGNATURE2.TextFont.Bold = true;
                    SIGNATURE2.Value = @"İMZA";

                    ONAY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 28, 185, 33, false);
                    ONAY1.Name = "ONAY1";
                    ONAY1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY1.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY1.TextFont.Name = "Arial Unicode MS";
                    ONAY1.TextFont.Size = 8;
                    ONAY1.TextFont.Bold = true;
                    ONAY1.Value = @"ONAY";

                    ONAYTARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 33, 193, 38, false);
                    ONAYTARIH1.Name = "ONAYTARIH1";
                    ONAYTARIH1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYTARIH1.TextFont.Size = 8;
                    ONAYTARIH1.Value = @"...../...../........";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 38, 202, 48, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTOR.TextFont.Name = "Arial Unicode MS";
                    HEADDOCTOR.TextFont.Size = 8;
                    HEADDOCTOR.Value = @"";

                    HEADDOCTOROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 17, 245, 22, false);
                    HEADDOCTOROBJECTID.Name = "HEADDOCTOROBJECTID";
                    HEADDOCTOROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOROBJECTID.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOROBJECTID.TextFont.CharSet = 1;
                    HEADDOCTOROBJECTID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR_OBJECTID"", """")";

                    ONAYLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 53, 185, 58, false);
                    ONAYLABEL.Name = "ONAYLABEL";
                    ONAYLABEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYLABEL.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYLABEL.TextFont.Name = "Arial Unicode MS";
                    ONAYLABEL.TextFont.Size = 8;
                    ONAYLABEL.Value = @"Başhekim";

                    DOKTOR1BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 11, 73, 15, false);
                    DOKTOR1BOLUM.Name = "DOKTOR1BOLUM";
                    DOKTOR1BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1BOLUM.TextFont.Size = 8;
                    DOKTOR1BOLUM.Value = @"";

                    DOKTOR1DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 73, 25, false);
                    DOKTOR1DIPNO.Name = "DOKTOR1DIPNO";
                    DOKTOR1DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1DIPNO.TextFont.Size = 8;
                    DOKTOR1DIPNO.Value = @"";

                    DOKTOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 15, 138, 21, false);
                    DOKTOR2.Name = "DOKTOR2";
                    DOKTOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2.TextFont.Name = "Arial Unicode MS";
                    DOKTOR2.TextFont.Size = 8;
                    DOKTOR2.Value = @"";

                    DOKTOR2BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 11, 138, 15, false);
                    DOKTOR2BOLUM.Name = "DOKTOR2BOLUM";
                    DOKTOR2BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR2BOLUM.TextFont.Size = 8;
                    DOKTOR2BOLUM.Value = @"";

                    DOKTOR2DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 20, 138, 25, false);
                    DOKTOR2DIPNO.Name = "DOKTOR2DIPNO";
                    DOKTOR2DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR2DIPNO.TextFont.Size = 8;
                    DOKTOR2DIPNO.Value = @"";

                    DOKTOR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 15, 201, 21, false);
                    DOKTOR3.Name = "DOKTOR3";
                    DOKTOR3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3.TextFont.Name = "Arial Unicode MS";
                    DOKTOR3.TextFont.Size = 8;
                    DOKTOR3.Value = @"";

                    DOKTOR3BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 11, 201, 15, false);
                    DOKTOR3BOLUM.Name = "DOKTOR3BOLUM";
                    DOKTOR3BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR3BOLUM.TextFont.Size = 8;
                    DOKTOR3BOLUM.Value = @"";

                    DOKTOR3DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 20, 201, 25, false);
                    DOKTOR3DIPNO.Name = "DOKTOR3DIPNO";
                    DOKTOR3DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR3DIPNO.TextFont.Size = 8;
                    DOKTOR3DIPNO.Value = @"";

                    SIGNATURE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 73, 11, false);
                    SIGNATURE3.Name = "SIGNATURE3";
                    SIGNATURE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE3.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE3.TextFont.Size = 8;
                    SIGNATURE3.TextFont.Bold = true;
                    SIGNATURE3.Value = @"İMZA";

                    SIGNATURE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 6, 201, 11, false);
                    SIGNATURE1.Name = "SIGNATURE1";
                    SIGNATURE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE1.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE1.TextFont.Size = 8;
                    SIGNATURE1.TextFont.Bold = true;
                    SIGNATURE1.Value = @"İMZA";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 34, 259, 39, false);
                    NAME1.Name = "NAME1";
                    NAME1.Visible = EvetHayirEnum.ehHayir;
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME1.ObjectDefName = "StatusNotificationReport";
                    NAME1.DataMember = "EPISODE.PATIENT.NAME";
                    NAME1.TextFont.CharSet = 1;
                    NAME1.Value = @"{@OBJECTID@}";

                    SURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 29, 259, 34, false);
                    SURNAME1.Name = "SURNAME1";
                    SURNAME1.Visible = EvetHayirEnum.ehHayir;
                    SURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME1.ObjectDefName = "StatusNotificationReport";
                    SURNAME1.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME1.TextFont.CharSet = 1;
                    SURNAME1.Value = @"{@OBJECTID@}";

                    HEADDOCTORDIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 48, 202, 53, false);
                    HEADDOCTORDIPNO.Name = "HEADDOCTORDIPNO";
                    HEADDOCTORDIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTORDIPNO.TextFont.Name = "Arial Unicode MS";
                    HEADDOCTORDIPNO.TextFont.Size = 8;
                    HEADDOCTORDIPNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StatusNotificationReport.GetStatusNotificationRaportRNQL_Class dataset_GetStatusNotificationRaportRNQL = ParentGroup.rsGroup.GetCurrentRecord<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(0);
                    DOKTOR1.CalcValue = DOKTOR1.Value;
                    SIGNATURE2.CalcValue = SIGNATURE2.Value;
                    ONAY1.CalcValue = ONAY1.Value;
                    ONAYTARIH1.CalcValue = ONAYTARIH1.Value;
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
                    SIGNATURE3.CalcValue = SIGNATURE3.Value;
                    SIGNATURE1.CalcValue = SIGNATURE1.Value;
                    NAME1.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    NAME1.PostFieldValueCalculation();
                    SURNAME1.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    SURNAME1.PostFieldValueCalculation();
                    HEADDOCTORDIPNO.CalcValue = HEADDOCTORDIPNO.Value;
                    HEADDOCTOROBJECTID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
                    return new TTReportObject[] { DOKTOR1,SIGNATURE2,ONAY1,ONAYTARIH1,HEADDOCTOR,ONAYLABEL,DOKTOR1BOLUM,DOKTOR1DIPNO,DOKTOR2,DOKTOR2BOLUM,DOKTOR2DIPNO,DOKTOR3,DOKTOR3BOLUM,DOKTOR3DIPNO,SIGNATURE3,SIGNATURE1,NAME1,SURNAME1,HEADDOCTORDIPNO,HEADDOCTOROBJECTID};
                }

                public override void RunScript()
                {
#region GROUP1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            if(report.ProcedureDoctor!=null)
            {
                this.DOKTOR1.CalcValue =(report.ProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(report.ProcedureDoctor.Title.Value) : "") + " " +  report.ProcedureDoctor.Name ;
                this.DOKTOR1BOLUM.CalcValue = ((report.ProcedureDoctor.ResourceSpecialities != null && report.ProcedureDoctor.ResourceSpecialities.Count > 0 )? report.ProcedureDoctor.ResourceSpecialities[0].Speciality.Name : "");
            this.DOKTOR1DIPNO.CalcValue = "Tescil No: " + report.ProcedureDoctor.DiplomaRegisterNo;
                
            }
            
            if(report.CommitteeReport  == true)
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
                
                if(report.SecondDoctor!=null)
                {
                    this.DOKTOR2.CalcValue =(report.SecondDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(report.SecondDoctor.Title.Value) : "") + " " +  report.SecondDoctor.Name ;
                    this.DOKTOR2BOLUM.CalcValue = ((report.SecondDoctor.ResourceSpecialities != null && report.SecondDoctor.ResourceSpecialities.Count > 0 )? report.SecondDoctor.ResourceSpecialities[0].Speciality.Name : "");
                     this.DOKTOR2DIPNO.CalcValue = "Tescil No: " + report.SecondDoctor.DiplomaRegisterNo;
                
                }     
                if(report.ThirdDoctor!=null)
                {
                      this.DOKTOR3.CalcValue =(report.ThirdDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(report.ThirdDoctor.Title.Value) : "") + " " +  report.ThirdDoctor.Name ;
                      this.DOKTOR3BOLUM.CalcValue = ((report.ThirdDoctor.ResourceSpecialities != null && report.ThirdDoctor.ResourceSpecialities.Count > 0 )? report.ThirdDoctor.ResourceSpecialities[0].Speciality.Name : "");
                      this.DOKTOR3DIPNO.CalcValue = "Tescil No: "  + report.ThirdDoctor.DiplomaRegisterNo;
                
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
            
            
            ResUser head = (ResUser)context.GetObject(new Guid(this.HEADDOCTOROBJECTID.CalcValue),"ResUser");
            this.HEADDOCTOR.CalcValue = (head.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(head.Title.Value) : "") + " " +  head.Name ;
            this.HEADDOCTORDIPNO.CalcValue = "Tescil No: "  + head.DiplomaRegisterNo;
#endregion GROUP1 FOOTER_Script
                }
            }

        }

        public Group1Group Group1;

        public partial class MAINGroup : TTReportGroup
        {
            public MedicalStuffReportReport MyParentReport
            {
                get { return (MedicalStuffReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DiagnosisField { get {return Body().DiagnosisField;} }
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
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField DiagnosisField; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    DiagnosisField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 4, 198, 13, false);
                    DiagnosisField.Name = "DiagnosisField";
                    DiagnosisField.DrawStyle = DrawStyleConstants.vbSolid;
                    DiagnosisField.MultiLine = EvetHayirEnum.ehEvet;
                    DiagnosisField.NoClip = EvetHayirEnum.ehEvet;
                    DiagnosisField.WordBreak = EvetHayirEnum.ehEvet;
                    DiagnosisField.ExpandTabs = EvetHayirEnum.ehEvet;
                    DiagnosisField.TextFont.Name = "Arial Unicode MS";
                    DiagnosisField.TextFont.Size = 8;
                    DiagnosisField.Value = @"  ICD KODU VE TANI(LAR):";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisField.CalcValue = DiagnosisField.Value;
                    return new TTReportObject[] { DiagnosisField};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
                    this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString() + "\n";

            foreach(ReportDiagnosis diagnosis in report.ReportDiagnosis){
                        this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString() +  diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + ", ";
            }
                    this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString().Substring(0, this.DiagnosisField.CalcValue.ToString().Length - 2);
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ExaminationGroup : TTReportGroup
        {
            public MedicalStuffReportReport MyParentReport
            {
                get { return (MedicalStuffReportReport)ParentReport; }
            }

            new public ExaminationGroupBody Body()
            {
                return (ExaminationGroupBody)_body;
            }
            public TTReportField EXAMINATION { get {return Body().EXAMINATION;} }
            public ExaminationGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ExaminationGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ExaminationGroupBody(this);
            }

            public partial class ExaminationGroupBody : TTReportSection
            {
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField EXAMINATION; 
                public ExaminationGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    EXAMINATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 3, 198, 12, false);
                    EXAMINATION.Name = "EXAMINATION";
                    EXAMINATION.DrawStyle = DrawStyleConstants.vbSolid;
                    EXAMINATION.MultiLine = EvetHayirEnum.ehEvet;
                    EXAMINATION.NoClip = EvetHayirEnum.ehEvet;
                    EXAMINATION.WordBreak = EvetHayirEnum.ehEvet;
                    EXAMINATION.ExpandTabs = EvetHayirEnum.ehEvet;
                    EXAMINATION.TextFont.Name = "Arial Unicode MS";
                    EXAMINATION.TextFont.Size = 8;
                    EXAMINATION.Value = @"  MUAYENE BULGULARI :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EXAMINATION.CalcValue = EXAMINATION.Value;
                    return new TTReportObject[] { EXAMINATION};
                }

                public override void RunScript()
                {
#region EXAMINATION BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            if(report.Description != null)
                    this.EXAMINATION.CalcValue = this.EXAMINATION.CalcValue.ToString() + "\n" + TTReportTool.TTReport.HTMLtoText(report.Description.ToString());
#endregion EXAMINATION BODY_Script
                }
            }

        }

        public ExaminationGroup Examination;

        public partial class DescriptionGroup : TTReportGroup
        {
            public MedicalStuffReportReport MyParentReport
            {
                get { return (MedicalStuffReportReport)ParentReport; }
            }

            new public DescriptionGroupBody Body()
            {
                return (DescriptionGroupBody)_body;
            }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public DescriptionGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DescriptionGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DescriptionGroupBody(this);
            }

            public partial class DescriptionGroupBody : TTReportSection
            {
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION; 
                public DescriptionGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 3, 198, 12, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial Unicode MS";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.Value = @"  AÇIKLAMA :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTION.CalcValue = DESCRIPTION.Value;
                    return new TTReportObject[] { DESCRIPTION};
                }

                public override void RunScript()
                {
#region DESCRIPTION BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            if(report.ReportDescription != null)
                    this.DESCRIPTION.CalcValue = this.DESCRIPTION.CalcValue.ToString() + "\n" + TTReportTool.TTReport.HTMLtoText(report.ReportDescription.ToString());
#endregion DESCRIPTION BODY_Script
                }
            }

        }

        public DescriptionGroup Description;

        public partial class DECISIONGroup : TTReportGroup
        {
            public MedicalStuffReportReport MyParentReport
            {
                get { return (MedicalStuffReportReport)ParentReport; }
            }

            new public DECISIONGroupBody Body()
            {
                return (DECISIONGroupBody)_body;
            }
            public TTReportField Decision { get {return Body().Decision;} }
            public DECISIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DECISIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DECISIONGroupBody(this);
            }

            public partial class DECISIONGroupBody : TTReportSection
            {
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField Decision; 
                public DECISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 29;
                    RepeatCount = 0;
                    
                    Decision = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 3, 198, 26, false);
                    Decision.Name = "Decision";
                    Decision.DrawStyle = DrawStyleConstants.vbSolid;
                    Decision.MultiLine = EvetHayirEnum.ehEvet;
                    Decision.NoClip = EvetHayirEnum.ehEvet;
                    Decision.WordBreak = EvetHayirEnum.ehEvet;
                    Decision.ExpandTabs = EvetHayirEnum.ehEvet;
                    Decision.TextFont.Name = "Arial Unicode MS";
                    Decision.TextFont.Size = 8;
                    Decision.Value = @"  KARAR :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Decision.CalcValue = Decision.Value;
                    return new TTReportObject[] { Decision};
                }

                public override void RunScript()
                {
#region DECISION BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
                    this.Decision.CalcValue = this.Decision.CalcValue.ToString() + "\n" + TTReportTool.TTReport.HTMLtoText(report.ReportDecision.ToString());
#endregion DECISION BODY_Script
                }
            }

        }

        public DECISIONGroup DECISION;

        public partial class TextGroup : TTReportGroup
        {
            public MedicalStuffReportReport MyParentReport
            {
                get { return (MedicalStuffReportReport)ParentReport; }
            }

            new public TextGroupBody Body()
            {
                return (TextGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TextGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TextGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TextGroupBody(this);
            }

            public partial class TextGroupBody : TTReportSection
            {
                public MedicalStuffReportReport MyParentReport
                {
                    get { return (MedicalStuffReportReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public TextGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 4, 198, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Unicode MS";
                    NewField1.TextFont.Size = 8;
                    NewField1.Value = @"Hastanın yukarıda belirtilen hastalığı ile ilgili sıralanan malzemeyi ................... süre ile kullanması gerekmektedir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }

                public override void RunScript()
                {
#region TEXT BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MedicalStuffReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            this.NewField1.CalcValue = "Hastanın yukarıda belirtilen hastalığı ile ilgili sıralanan malzemeyi "+ report.ReportDuration.ToString() + " " +TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(report.ReportDurationType) + " süre ile kullanması gerekmektedir.";
#endregion TEXT BODY_Script
                }
            }

        }

        public TextGroup Text;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MedicalStuffReportReport()
        {
            Group1 = new Group1Group(this,"Group1");
            MAIN = new MAINGroup(Group1,"MAIN");
            Examination = new ExaminationGroup(Group1,"Examination");
            Description = new DescriptionGroup(Group1,"Description");
            DECISION = new DECISIONGroup(Group1,"DECISION");
            Text = new TextGroup(Group1,"Text");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            Name = "MEDICALSTUFFREPORTREPORT";
            Caption = "Tıbbi Malzeme Raporu";
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