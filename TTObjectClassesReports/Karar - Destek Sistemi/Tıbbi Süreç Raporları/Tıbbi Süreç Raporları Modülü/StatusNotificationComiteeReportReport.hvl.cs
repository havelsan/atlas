
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
    /// Durum Bildirir Sağlık Kurulu Raporu
    /// </summary>
    public partial class StatusNotificationComiteeReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Group1Group : TTReportGroup
        {
            public StatusNotificationComiteeReportReport MyParentReport
            {
                get { return (StatusNotificationComiteeReportReport)ParentReport; }
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
            public TTReportShape NewLine1141 { get {return Header().NewLine1141;} }
            public TTReportShape NewLine1161 { get {return Header().NewLine1161;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
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
            public TTReportField TEL { get {return Header().TEL;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField KURUMU { get {return Header().KURUMU;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField NewField111612 { get {return Header().NewField111612;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField DOKTOR1 { get {return Footer().DOKTOR1;} }
            public TTReportField SIGNATURE2 { get {return Footer().SIGNATURE2;} }
            public TTReportField HEADDOCTOROBJECTID { get {return Footer().HEADDOCTOROBJECTID;} }
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
                public StatusNotificationComiteeReportReport MyParentReport
                {
                    get { return (StatusNotificationComiteeReportReport)ParentReport; }
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
                public TTReportShape NewLine1141;
                public TTReportShape NewLine1161;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField11311;
                public TTReportField NewField11511;
                public TTReportField NewField11611;
                public TTReportField NewField112411;
                public TTReportField NewField113411;
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
                public TTReportField TEL;
                public TTReportField ADDRESS;
                public TTReportField LOGO;
                public TTReportField KURUMU;
                public TTReportField NewField11411;
                public TTReportField NewField1;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportField NewField111611;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportField NewField111612;
                public TTReportField PROTOCOLNO; 
                public Group1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 134;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 16, 170, 38, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Arial Unicode MS";
                    BASLIK.TextFont.Size = 11;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"{%XXXXXXBASLIK%}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 40, 170, 49, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial Unicode MS";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"DURUM BİLDİRİR SAĞLIK KURULU RAPORU";

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

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 22, 60, 193, 127, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 102, 162, 107, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Name = "Arial Unicode MS";
                    REPORTNO.TextFont.Size = 8;
                    REPORTNO.Value = @"{#REPORTNO#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 67, 193, 67, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 74, 193, 74, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 85, 193, 85, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 102, 193, 102, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 102, 60, 102, 116, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 61, 54, 66, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Unicode MS";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Adı Soyadı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 68, 137, 73, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Unicode MS";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Muayene Tarihi Saati";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 75, 57, 80, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial Unicode MS";
                    NewField11311.TextFont.Size = 8;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @"Doğum Tarihi";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 68, 49, 73, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial Unicode MS";
                    NewField11511.TextFont.Size = 8;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"Baba Adı";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 75, 128, 80, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial Unicode MS";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.Value = @"Poliklinik/Servis";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 61, 128, 66, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.TextFont.Name = "Arial Unicode MS";
                    NewField112411.TextFont.Size = 8;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.Value = @"T.C Kimlik No";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 110, 49, 115, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Name = "Arial Unicode MS";
                    NewField113411.TextFont.Size = 8;
                    NewField113411.TextFont.Bold = true;
                    NewField113411.Value = @"Tel";

                    NewField115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 94, 133, 98, false);
                    NewField115411.Name = "NewField115411";
                    NewField115411.TextFont.Name = "Arial Unicode MS";
                    NewField115411.TextFont.Size = 8;
                    NewField115411.TextFont.Bold = true;
                    NewField115411.Value = @"Rapor Tarihi";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 60, 97, 65, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Name = "Arial Unicode MS";
                    NAMESURNAME.TextFont.Size = 8;
                    NAMESURNAME.Value = @"{%NAME%} {%SURNAME%}";

                    EXAMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 68, 189, 73, false);
                    EXAMINATIONDATE.Name = "EXAMINATIONDATE";
                    EXAMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    EXAMINATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXAMINATIONDATE.TextFont.Name = "Arial Unicode MS";
                    EXAMINATIONDATE.TextFont.Size = 8;
                    EXAMINATIONDATE.Value = @"";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 68, 97, 73, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.ObjectDefName = "StatusNotificationReport";
                    FATHERNAME.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    FATHERNAME.TextFont.Name = "Arial Unicode MS";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{@OBJECTID@}";

                    MR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 75, 188, 84, false);
                    MR.Name = "MR";
                    MR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MR.MultiLine = EvetHayirEnum.ehEvet;
                    MR.NoClip = EvetHayirEnum.ehEvet;
                    MR.WordBreak = EvetHayirEnum.ehEvet;
                    MR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MR.TextFont.Name = "Arial Unicode MS";
                    MR.TextFont.Size = 8;
                    MR.Value = @"{#MR#}";

                    STARTENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 94, 188, 97, false);
                    STARTENDDATE.Name = "STARTENDDATE";
                    STARTENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTENDDATE.TextFont.Name = "Arial Unicode MS";
                    STARTENDDATE.TextFont.Size = 8;
                    STARTENDDATE.Value = @"{%STARTDATE%}-{%ENDDATE%}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 61, 175, 66, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Name = "Arial Unicode MS";
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 75, 97, 80, false);
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

                    NewField116411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 103, 128, 108, false);
                    NewField116411.Name = "NewField116411";
                    NewField116411.TextFont.Name = "Arial Unicode MS";
                    NewField116411.TextFont.Size = 8;
                    NewField116411.TextFont.Bold = true;
                    NewField116411.Value = @"Rapor No";

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 116, 193, 116, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 117, 49, 122, false);
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

                    TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 110, 97, 115, false);
                    TEL.Name = "TEL";
                    TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEL.ObjectDefName = "StatusNotificationReport";
                    TEL.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.MOBILEPHONE";
                    TEL.TextFont.Name = "Arial Unicode MS";
                    TEL.TextFont.Size = 8;
                    TEL.Value = @"{@OBJECTID@}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 117, 191, 124, false);
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

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 16, 203, 39, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    KURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 86, 97, 97, false);
                    KURUMU.Name = "KURUMU";
                    KURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMU.NoClip = EvetHayirEnum.ehEvet;
                    KURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMU.TextFont.Name = "Arial Unicode MS";
                    KURUMU.TextFont.Size = 8;
                    KURUMU.Value = @"";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 86, 57, 91, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Arial Unicode MS";
                    NewField11411.TextFont.Size = 8;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @"Kurumu ve Görevi";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 53, 193, 60, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial Unicode MS";
                    NewField1.Value = @" BAŞVURU SAHİBİNİN:";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 53, 193, 53, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 53, 22, 60, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 193, 53, 193, 60, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 86, 132, 91, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Name = "Arial Unicode MS";
                    NewField111611.TextFont.Size = 8;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.Value = @"Online Protokol No";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 102, 92, 193, 92, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 109, 193, 109, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 103, 56, 108, false);
                    NewField111612.Name = "NewField111612";
                    NewField111612.TextFont.Name = "Arial Unicode MS";
                    NewField111612.TextFont.Size = 8;
                    NewField111612.TextFont.Bold = true;
                    NewField111612.Value = @"Rapor İstek Nedeni";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 86, 166, 91, false);
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
                    NewField113411.CalcValue = NewField113411.Value;
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
                    TEL.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    TEL.PostFieldValueCalculation();
                    ADDRESS.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    ADDRESS.PostFieldValueCalculation();
                    LOGO.CalcValue = @"";
                    KURUMU.CalcValue = @"";
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField111612.CalcValue = NewField111612.Value;
                    PROTOCOLNO.CalcValue = PROTOCOLNO.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");
                    return new TTReportObject[] { XXXXXXBASLIK,BASLIK,NewField1111,NAME,SURNAME,REPORTNO,NewField1121,NewField11211,NewField11311,NewField11511,NewField11611,NewField112411,NewField113411,NewField115411,NAMESURNAME,EXAMINATIONDATE,FATHERNAME,MR,STARTDATE,ENDDATE,STARTENDDATE,UNIQUEREFNO,DTARIHI,NewField116411,NewField1114311,TEL,ADDRESS,LOGO,KURUMU,NewField11411,NewField1,NewField111611,NewField111612,PROTOCOLNO,XXXXXXIL,XXXXXXALTBASLIK};
                }

                public override void RunScript()
                {
#region GROUP1 HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);                                    
            string sObjectID = ((StatusNotificationComiteeReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport )context.GetObject(new Guid(sObjectID),"StatusNotificationReport");

            this.KURUMU.CalcValue = report.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
            
             this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
             //this.PATIENTSTATUS.CalcValue =  report.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
             this.PROTOCOLNO.CalcValue = report.SubEpisode.ProtocolNo;
            SubEpisode subepisode = report.SubEpisode;
             
             while(subepisode.OldSubEpisode != null){
                subepisode = subepisode.OldSubEpisode;
             }
            
            if(report.ReportDurationType != null){
                if(report.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue)
                    this.STARTENDDATE.CalcValue =((DateTime)report.StartDate).ToString("dd.MM.yyyy")+ " - " +"Halen Devam Ediyor";
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
                public StatusNotificationComiteeReportReport MyParentReport
                {
                    get { return (StatusNotificationComiteeReportReport)ParentReport; }
                }
                
                public TTReportField DOKTOR1;
                public TTReportField SIGNATURE2;
                public TTReportField HEADDOCTOROBJECTID;
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
                public Group1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 31;
                    RepeatCount = 0;
                    
                    DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 68, 21, false);
                    DOKTOR1.Name = "DOKTOR1";
                    DOKTOR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1.TextFont.Size = 8;
                    DOKTOR1.Value = @"";

                    SIGNATURE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 6, 133, 11, false);
                    SIGNATURE2.Name = "SIGNATURE2";
                    SIGNATURE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE2.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE2.TextFont.Size = 8;
                    SIGNATURE2.TextFont.Bold = true;
                    SIGNATURE2.Value = @"İMZA";

                    HEADDOCTOROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 2, 242, 7, false);
                    HEADDOCTOROBJECTID.Name = "HEADDOCTOROBJECTID";
                    HEADDOCTOROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOROBJECTID.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOROBJECTID.TextFont.CharSet = 1;
                    HEADDOCTOROBJECTID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR_OBJECTID"", """")";

                    DOKTOR1BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 68, 15, false);
                    DOKTOR1BOLUM.Name = "DOKTOR1BOLUM";
                    DOKTOR1BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1BOLUM.TextFont.Size = 8;
                    DOKTOR1BOLUM.Value = @"";

                    DOKTOR1DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 68, 25, false);
                    DOKTOR1DIPNO.Name = "DOKTOR1DIPNO";
                    DOKTOR1DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1DIPNO.TextFont.Size = 8;
                    DOKTOR1DIPNO.Value = @"";

                    DOKTOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 15, 133, 21, false);
                    DOKTOR2.Name = "DOKTOR2";
                    DOKTOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2.TextFont.Name = "Arial Unicode MS";
                    DOKTOR2.TextFont.Size = 8;
                    DOKTOR2.Value = @"";

                    DOKTOR2BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 11, 133, 15, false);
                    DOKTOR2BOLUM.Name = "DOKTOR2BOLUM";
                    DOKTOR2BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR2BOLUM.TextFont.Size = 8;
                    DOKTOR2BOLUM.Value = @"";

                    DOKTOR2DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 20, 133, 25, false);
                    DOKTOR2DIPNO.Name = "DOKTOR2DIPNO";
                    DOKTOR2DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR2DIPNO.TextFont.Size = 8;
                    DOKTOR2DIPNO.Value = @"";

                    DOKTOR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 15, 196, 21, false);
                    DOKTOR3.Name = "DOKTOR3";
                    DOKTOR3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3.TextFont.Name = "Arial Unicode MS";
                    DOKTOR3.TextFont.Size = 8;
                    DOKTOR3.Value = @"";

                    DOKTOR3BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 11, 196, 15, false);
                    DOKTOR3BOLUM.Name = "DOKTOR3BOLUM";
                    DOKTOR3BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR3BOLUM.TextFont.Size = 8;
                    DOKTOR3BOLUM.Value = @"";

                    DOKTOR3DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 20, 196, 25, false);
                    DOKTOR3DIPNO.Name = "DOKTOR3DIPNO";
                    DOKTOR3DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR3DIPNO.TextFont.Size = 8;
                    DOKTOR3DIPNO.Value = @"";

                    SIGNATURE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 68, 11, false);
                    SIGNATURE3.Name = "SIGNATURE3";
                    SIGNATURE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE3.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE3.TextFont.Size = 8;
                    SIGNATURE3.TextFont.Bold = true;
                    SIGNATURE3.Value = @"İMZA";

                    SIGNATURE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 6, 196, 11, false);
                    SIGNATURE1.Name = "SIGNATURE1";
                    SIGNATURE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE1.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE1.TextFont.Size = 8;
                    SIGNATURE1.TextFont.Bold = true;
                    SIGNATURE1.Value = @"İMZA";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 19, 256, 24, false);
                    NAME1.Name = "NAME1";
                    NAME1.Visible = EvetHayirEnum.ehHayir;
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME1.ObjectDefName = "StatusNotificationReport";
                    NAME1.DataMember = "EPISODE.PATIENT.NAME";
                    NAME1.TextFont.CharSet = 1;
                    NAME1.Value = @"{@OBJECTID@}";

                    SURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 14, 256, 19, false);
                    SURNAME1.Name = "SURNAME1";
                    SURNAME1.Visible = EvetHayirEnum.ehHayir;
                    SURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME1.ObjectDefName = "StatusNotificationReport";
                    SURNAME1.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME1.TextFont.CharSet = 1;
                    SURNAME1.Value = @"{@OBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StatusNotificationReport.GetStatusNotificationRaportRNQL_Class dataset_GetStatusNotificationRaportRNQL = ParentGroup.rsGroup.GetCurrentRecord<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(0);
                    DOKTOR1.CalcValue = DOKTOR1.Value;
                    SIGNATURE2.CalcValue = SIGNATURE2.Value;
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
                    HEADDOCTOROBJECTID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
                    return new TTReportObject[] { DOKTOR1,SIGNATURE2,DOKTOR1BOLUM,DOKTOR1DIPNO,DOKTOR2,DOKTOR2BOLUM,DOKTOR2DIPNO,DOKTOR3,DOKTOR3BOLUM,DOKTOR3DIPNO,SIGNATURE3,SIGNATURE1,NAME1,SURNAME1,HEADDOCTOROBJECTID};
                }

                public override void RunScript()
                {
#region GROUP1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationComiteeReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
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
#endregion GROUP1 FOOTER_Script
                }
            }

        }

        public Group1Group Group1;

        public partial class PhysicalExaminationGroup : TTReportGroup
        {
            public StatusNotificationComiteeReportReport MyParentReport
            {
                get { return (StatusNotificationComiteeReportReport)ParentReport; }
            }

            new public PhysicalExaminationGroupBody Body()
            {
                return (PhysicalExaminationGroupBody)_body;
            }
            public TTReportField PhysicalExamination { get {return Body().PhysicalExamination;} }
            public PhysicalExaminationGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PhysicalExaminationGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PhysicalExaminationGroupBody(this);
            }

            public partial class PhysicalExaminationGroupBody : TTReportSection
            {
                public StatusNotificationComiteeReportReport MyParentReport
                {
                    get { return (StatusNotificationComiteeReportReport)ParentReport; }
                }
                
                public TTReportField PhysicalExamination; 
                public PhysicalExaminationGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    PhysicalExamination = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 2, 193, 11, false);
                    PhysicalExamination.Name = "PhysicalExamination";
                    PhysicalExamination.DrawStyle = DrawStyleConstants.vbSolid;
                    PhysicalExamination.MultiLine = EvetHayirEnum.ehEvet;
                    PhysicalExamination.NoClip = EvetHayirEnum.ehEvet;
                    PhysicalExamination.WordBreak = EvetHayirEnum.ehEvet;
                    PhysicalExamination.ExpandTabs = EvetHayirEnum.ehEvet;
                    PhysicalExamination.TextFont.Name = "Arial Unicode MS";
                    PhysicalExamination.Value = @" FİZİKİ MUAYENE BULGULARI:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysicalExamination.CalcValue = PhysicalExamination.Value;
                    return new TTReportObject[] { PhysicalExamination};
                }

                public override void RunScript()
                {
#region PHYSICALEXAMINATION BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
        string sObjectID = ((StatusNotificationComiteeReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if(statusNotificationReport.Description != null)
             {
                 this.PhysicalExamination.CalcValue =this.PhysicalExamination.CalcValue +"\n"+ statusNotificationReport.Description;
             }else{
                 this.PhysicalExamination.CalcValue += "\n\n\n";
             }
#endregion PHYSICALEXAMINATION BODY_Script
                }
            }

        }

        public PhysicalExaminationGroup PhysicalExamination;

        public partial class LaboratoryRadiologyResultsGroup : TTReportGroup
        {
            public StatusNotificationComiteeReportReport MyParentReport
            {
                get { return (StatusNotificationComiteeReportReport)ParentReport; }
            }

            new public LaboratoryRadiologyResultsGroupBody Body()
            {
                return (LaboratoryRadiologyResultsGroupBody)_body;
            }
            public TTReportField LaboratoryRadiologyResults { get {return Body().LaboratoryRadiologyResults;} }
            public LaboratoryRadiologyResultsGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LaboratoryRadiologyResultsGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new LaboratoryRadiologyResultsGroupBody(this);
            }

            public partial class LaboratoryRadiologyResultsGroupBody : TTReportSection
            {
                public StatusNotificationComiteeReportReport MyParentReport
                {
                    get { return (StatusNotificationComiteeReportReport)ParentReport; }
                }
                
                public TTReportField LaboratoryRadiologyResults; 
                public LaboratoryRadiologyResultsGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    LaboratoryRadiologyResults = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 3, 193, 15, false);
                    LaboratoryRadiologyResults.Name = "LaboratoryRadiologyResults";
                    LaboratoryRadiologyResults.DrawStyle = DrawStyleConstants.vbSolid;
                    LaboratoryRadiologyResults.MultiLine = EvetHayirEnum.ehEvet;
                    LaboratoryRadiologyResults.NoClip = EvetHayirEnum.ehEvet;
                    LaboratoryRadiologyResults.WordBreak = EvetHayirEnum.ehEvet;
                    LaboratoryRadiologyResults.ExpandTabs = EvetHayirEnum.ehEvet;
                    LaboratoryRadiologyResults.TextFont.Name = "Arial Unicode MS";
                    LaboratoryRadiologyResults.Value = @" LABORATUVAR TETKİK/GÖRÜNTÜLEME SONUÇLARI:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRadiologyResults.CalcValue = LaboratoryRadiologyResults.Value;
                    return new TTReportObject[] { LaboratoryRadiologyResults};
                }

                public override void RunScript()
                {
#region LABORATORYRADIOLOGYRESULTS BODY_Script
                    this.LaboratoryRadiologyResults.CalcValue += "\n\n\n";
#endregion LABORATORYRADIOLOGYRESULTS BODY_Script
                }
            }

        }

        public LaboratoryRadiologyResultsGroup LaboratoryRadiologyResults;

        public partial class MAINGroup : TTReportGroup
        {
            public StatusNotificationComiteeReportReport MyParentReport
            {
                get { return (StatusNotificationComiteeReportReport)ParentReport; }
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
                public StatusNotificationComiteeReportReport MyParentReport
                {
                    get { return (StatusNotificationComiteeReportReport)ParentReport; }
                }
                
                public TTReportField DiagnosisField; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    DiagnosisField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 193, 9, false);
                    DiagnosisField.Name = "DiagnosisField";
                    DiagnosisField.DrawStyle = DrawStyleConstants.vbSolid;
                    DiagnosisField.MultiLine = EvetHayirEnum.ehEvet;
                    DiagnosisField.NoClip = EvetHayirEnum.ehEvet;
                    DiagnosisField.WordBreak = EvetHayirEnum.ehEvet;
                    DiagnosisField.ExpandTabs = EvetHayirEnum.ehEvet;
                    DiagnosisField.TextFont.Name = "Arial Unicode MS";
                    DiagnosisField.Value = @" ICD KODU VE TANI(LAR):";

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
            string sObjectID = ((StatusNotificationComiteeReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
                    this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString() + "\n";

            foreach(ReportDiagnosis diagnosis in report.ReportDiagnosis){
                        this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString() +  diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + ", ";
            }
                    this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString().Substring(0, this.DiagnosisField.CalcValue.ToString().Length - 2) +"\n";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class DECISIONGroup : TTReportGroup
        {
            public StatusNotificationComiteeReportReport MyParentReport
            {
                get { return (StatusNotificationComiteeReportReport)ParentReport; }
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
                public StatusNotificationComiteeReportReport MyParentReport
                {
                    get { return (StatusNotificationComiteeReportReport)ParentReport; }
                }
                
                public TTReportField Decision; 
                public DECISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    Decision = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 3, 193, 10, false);
                    Decision.Name = "Decision";
                    Decision.DrawStyle = DrawStyleConstants.vbSolid;
                    Decision.MultiLine = EvetHayirEnum.ehEvet;
                    Decision.NoClip = EvetHayirEnum.ehEvet;
                    Decision.WordBreak = EvetHayirEnum.ehEvet;
                    Decision.ExpandTabs = EvetHayirEnum.ehEvet;
                    Decision.TextFont.Name = "Arial Unicode MS";
                    Decision.Value = @" KARAR :";

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
            string sObjectID = ((StatusNotificationComiteeReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
                    this.Decision.CalcValue = this.Decision.CalcValue.ToString() + "\n" + TTReportTool.TTReport.HTMLtoText(report.ReportDecision.ToString()) +"\n";
#endregion DECISION BODY_Script
                }
            }

        }

        public DECISIONGroup DECISION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StatusNotificationComiteeReportReport()
        {
            Group1 = new Group1Group(this,"Group1");
            PhysicalExamination = new PhysicalExaminationGroup(Group1,"PhysicalExamination");
            LaboratoryRadiologyResults = new LaboratoryRadiologyResultsGroup(Group1,"LaboratoryRadiologyResults");
            MAIN = new MAINGroup(Group1,"MAIN");
            DECISION = new DECISIONGroup(Group1,"DECISION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            Name = "STATUSNOTIFICATIONCOMITEEREPORTREPORT";
            Caption = "Durum Bildirir Sağlık Kurulu Raporu";
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