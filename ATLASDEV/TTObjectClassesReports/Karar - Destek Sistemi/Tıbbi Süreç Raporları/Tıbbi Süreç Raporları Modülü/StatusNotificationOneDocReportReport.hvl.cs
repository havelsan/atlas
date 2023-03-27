
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
    /// Durum Bildirir Tek Hekim Sağlık Raporu
    /// </summary>
    public partial class StatusNotificationOneDocReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Group1Group : TTReportGroup
        {
            public StatusNotificationOneDocReportReport MyParentReport
            {
                get { return (StatusNotificationOneDocReportReport)ParentReport; }
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
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField NewField115411 { get {return Header().NewField115411;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField SportLicenceCheck { get {return Header().SportLicenceCheck;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField ShotgunCheck { get {return Header().ShotgunCheck;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField SanityCheck { get {return Header().SanityCheck;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField InstitutionCheck { get {return Header().InstitutionCheck;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField PATIENTSEX { get {return Header().PATIENTSEX;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField DOKTOR1 { get {return Footer().DOKTOR1;} }
            public TTReportField HEADDOCTOROBJECTID { get {return Footer().HEADDOCTOROBJECTID;} }
            public TTReportField DOKTOR1BOLUM { get {return Footer().DOKTOR1BOLUM;} }
            public TTReportField DOKTOR1DIPNO { get {return Footer().DOKTOR1DIPNO;} }
            public TTReportField SIGNATURE3 { get {return Footer().SIGNATURE3;} }
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
                public StatusNotificationOneDocReportReport MyParentReport
                {
                    get { return (StatusNotificationOneDocReportReport)ParentReport; }
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
                public TTReportField NewField11311;
                public TTReportField NewField11511;
                public TTReportField NewField112411;
                public TTReportField NewField113411;
                public TTReportField NewField115411;
                public TTReportField NAMESURNAME;
                public TTReportField FATHERNAME;
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
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField SportLicenceCheck;
                public TTReportField NewField4;
                public TTReportField ShotgunCheck;
                public TTReportField NewField5;
                public TTReportField SanityCheck;
                public TTReportField NewField6;
                public TTReportField InstitutionCheck;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportField NewField11211;
                public TTReportField NewField11611;
                public TTReportShape NewLine4;
                public TTReportField PATIENTSEX;
                public TTReportField PROTOCOLNO; 
                public Group1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 146;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 18, 170, 40, false);
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

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 44, 170, 53, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial Unicode MS";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"DURUM BİLDİRİR TEK HEKİM SAĞLIK RAPORU";

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

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 14, 88, 197, 142, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 118, 156, 123, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Name = "Arial Unicode MS";
                    REPORTNO.TextFont.Size = 8;
                    REPORTNO.Value = @"{#REPORTNO#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 95, 197, 95, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 102, 197, 102, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 109, 197, 109, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 124, 197, 124, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 106, 88, 106, 124, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 89, 46, 94, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Unicode MS";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Adı Soyadı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 103, 49, 108, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial Unicode MS";
                    NewField11311.TextFont.Size = 8;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @"Doğum Tarihi";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 96, 41, 101, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial Unicode MS";
                    NewField11511.TextFont.Size = 8;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"Baba Adı";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 89, 133, 94, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.TextFont.Name = "Arial Unicode MS";
                    NewField112411.TextFont.Size = 8;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.Value = @"T.C Kimlik No";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 103, 133, 108, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Name = "Arial Unicode MS";
                    NewField113411.TextFont.Size = 8;
                    NewField113411.TextFont.Bold = true;
                    NewField113411.Value = @"Tel";

                    NewField115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 125, 46, 129, false);
                    NewField115411.Name = "NewField115411";
                    NewField115411.TextFont.Name = "Arial Unicode MS";
                    NewField115411.TextFont.Size = 8;
                    NewField115411.TextFont.Bold = true;
                    NewField115411.Value = @"Rapor Tarihi";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 89, 95, 94, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Name = "Arial Unicode MS";
                    NAMESURNAME.TextFont.Size = 8;
                    NAMESURNAME.Value = @"{%NAME%} {%SURNAME%}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 96, 95, 101, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.ObjectDefName = "StatusNotificationReport";
                    FATHERNAME.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    FATHERNAME.TextFont.Name = "Arial Unicode MS";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{@OBJECTID@}";

                    STARTENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 125, 106, 128, false);
                    STARTENDDATE.Name = "STARTENDDATE";
                    STARTENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTENDDATE.TextFont.Name = "Arial Unicode MS";
                    STARTENDDATE.TextFont.Size = 8;
                    STARTENDDATE.Value = @"{%STARTDATE%}-{%ENDDATE%}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 89, 164, 94, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Name = "Arial Unicode MS";
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 103, 95, 108, false);
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

                    NewField116411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 118, 133, 123, false);
                    NewField116411.Name = "NewField116411";
                    NewField116411.TextFont.Name = "Arial Unicode MS";
                    NewField116411.TextFont.Size = 8;
                    NewField116411.TextFont.Bold = true;
                    NewField116411.Value = @"Rapor No";

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 131, 197, 131, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 132, 41, 137, false);
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

                    TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 103, 186, 108, false);
                    TEL.Name = "TEL";
                    TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEL.ObjectDefName = "StatusNotificationReport";
                    TEL.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.MOBILEPHONE";
                    TEL.TextFont.Name = "Arial Unicode MS";
                    TEL.TextFont.Size = 8;
                    TEL.Value = @"{@OBJECTID@}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 132, 194, 139, false);
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

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 18, 204, 41, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    KURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 110, 95, 121, false);
                    KURUMU.Name = "KURUMU";
                    KURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMU.NoClip = EvetHayirEnum.ehEvet;
                    KURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMU.TextFont.Name = "Arial Unicode MS";
                    KURUMU.TextFont.Size = 8;
                    KURUMU.Value = @"";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 111, 49, 116, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Arial Unicode MS";
                    NewField11411.TextFont.Size = 8;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @"Kurumu ve Görevi";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 81, 197, 88, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial Unicode MS";
                    NewField1.Value = @"  BAŞVURU SAHİBİNİN:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 56, 50, 61, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Unicode MS";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"VERİLME NEDENİ:";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 64, 38, 69, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Unicode MS";
                    NewField3.Value = @"SPOR LİSANSI";

                    SportLicenceCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 64, 42, 68, false);
                    SportLicenceCheck.Name = "SportLicenceCheck";
                    SportLicenceCheck.DrawStyle = DrawStyleConstants.vbSolid;
                    SportLicenceCheck.TextFont.Name = "Arial";
                    SportLicenceCheck.TextFont.Bold = true;
                    SportLicenceCheck.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 64, 84, 69, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Unicode MS";
                    NewField4.Value = @"YİVSİZ AV TÜFEĞİ";

                    ShotgunCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 64, 88, 68, false);
                    ShotgunCheck.Name = "ShotgunCheck";
                    ShotgunCheck.DrawStyle = DrawStyleConstants.vbSolid;
                    ShotgunCheck.TextFont.Name = "Arial";
                    ShotgunCheck.TextFont.Bold = true;
                    ShotgunCheck.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 64, 122, 69, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial Unicode MS";
                    NewField5.Value = @"AKLİ MELEKE";

                    SanityCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 64, 126, 68, false);
                    SanityCheck.Name = "SanityCheck";
                    SanityCheck.DrawStyle = DrawStyleConstants.vbSolid;
                    SanityCheck.TextFont.Name = "Arial";
                    SanityCheck.TextFont.Bold = true;
                    SanityCheck.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 71, 118, 76, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial Unicode MS";
                    NewField6.Value = @"KURUM VE KURULUŞLARA (Okul, Yurt vb. ) VERİLMEK ÜZERE";

                    InstitutionCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 71, 122, 75, false);
                    InstitutionCheck.Name = "InstitutionCheck";
                    InstitutionCheck.DrawStyle = DrawStyleConstants.vbSolid;
                    InstitutionCheck.TextFont.Name = "Arial";
                    InstitutionCheck.TextFont.Bold = true;
                    InstitutionCheck.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 81, 197, 81, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 81, 14, 88, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 82, 197, 88, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 96, 133, 101, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Unicode MS";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Cinsiyeti";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 110, 137, 115, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial Unicode MS";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.Value = @"Online Protokol No";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 106, 117, 197, 117, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    PATIENTSEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 96, 189, 101, false);
                    PATIENTSEX.Name = "PATIENTSEX";
                    PATIENTSEX.TextFont.Name = "Arial Unicode MS";
                    PATIENTSEX.TextFont.Size = 8;
                    PATIENTSEX.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 110, 165, 115, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
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
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    NewField115411.CalcValue = NewField115411.Value;
                    NAMESURNAME.CalcValue = MyParentReport.Group1.NAME.CalcValue + @" " + MyParentReport.Group1.SURNAME.CalcValue;
                    FATHERNAME.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    FATHERNAME.PostFieldValueCalculation();
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
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    SportLicenceCheck.CalcValue = SportLicenceCheck.Value;
                    NewField4.CalcValue = NewField4.Value;
                    ShotgunCheck.CalcValue = ShotgunCheck.Value;
                    NewField5.CalcValue = NewField5.Value;
                    SanityCheck.CalcValue = SanityCheck.Value;
                    NewField6.CalcValue = NewField6.Value;
                    InstitutionCheck.CalcValue = InstitutionCheck.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    PATIENTSEX.CalcValue = PATIENTSEX.Value;
                    PROTOCOLNO.CalcValue = PROTOCOLNO.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");
                    return new TTReportObject[] { XXXXXXBASLIK,BASLIK,NewField1111,NAME,SURNAME,REPORTNO,NewField1121,NewField11311,NewField11511,NewField112411,NewField113411,NewField115411,NAMESURNAME,FATHERNAME,STARTDATE,ENDDATE,STARTENDDATE,UNIQUEREFNO,DTARIHI,NewField116411,NewField1114311,TEL,ADDRESS,LOGO,KURUMU,NewField11411,NewField1,NewField2,NewField3,SportLicenceCheck,NewField4,ShotgunCheck,NewField5,SanityCheck,NewField6,InstitutionCheck,NewField11211,NewField11611,PATIENTSEX,PROTOCOLNO,XXXXXXIL,XXXXXXALTBASLIK};
                }

                public override void RunScript()
                {
#region GROUP1 HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);                                    
            string sObjectID = ((StatusNotificationOneDocReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport )context.GetObject(new Guid(sObjectID),"StatusNotificationReport");

            this.KURUMU.CalcValue = report.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
            
             this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
             //this.PATIENTSTATUS.CalcValue =  report.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
             this.PROTOCOLNO.CalcValue = report.SubEpisode.ProtocolNo;
             SubEpisode subepisode = report.SubEpisode;
             if(report.Episode.Patient.Sex != null)
                 this.PATIENTSEX.CalcValue = report.Episode.Patient.Sex.ADI;
             /*while(subepisode.OldSubEpisode != null){
                subepisode = subepisode.OldSubEpisode;
             }
             
            foreach(EpisodeAction episodeAction in subepisode.EpisodeActions){
                if(episodeAction is PatientExamination && episodeAction.IsCancelled == false)
                {
                    PatientExamination patientExamination= (PatientExamination) episodeAction;
                    this.EXAMINATIONDATE.CalcValue = patientExamination.ProcessDate != null ? patientExamination.ProcessDate.ToString() : null;
                }
             }*/
             if(report.ReportReason == StatusNotificationReasonEnum.SportLicence)
                    {
                        this.SportLicenceCheck.CalcValue = "X";
                        this.ShotgunCheck.CalcValue = "";
                        this.SanityCheck.CalcValue = "";
                        this.InstitutionCheck.CalcValue = "";
                    }else if (report.ReportReason == StatusNotificationReasonEnum.Shotgun)
                    {
                        this.SportLicenceCheck.CalcValue = "";
                        this.ShotgunCheck.CalcValue = "X";
                        this.SanityCheck.CalcValue = "";
                        this.InstitutionCheck.CalcValue = "";
                    }
                    else if (report.ReportReason == StatusNotificationReasonEnum.ToGiveOutInstutition)
                    {
                        this.SportLicenceCheck.CalcValue = "";
                        this.ShotgunCheck.CalcValue = "";
                        this.SanityCheck.CalcValue = "";
                        this.InstitutionCheck.CalcValue = "X";
                    }
                    else if (report.ReportReason == StatusNotificationReasonEnum.MentalBalance)
                    {
                        this.SportLicenceCheck.CalcValue = "";
                        this.ShotgunCheck.CalcValue = "";
                        this.SanityCheck.CalcValue = "X";
                        this.InstitutionCheck.CalcValue = "";
                    }
                    
            if(report.ReportDurationType != null){
                if(report.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue)
                    this.STARTENDDATE.CalcValue =((DateTime)report.StartDate).ToString("dd.MM.yyyy")+ " - " +"Halen Devam Ediyor";
            }
#endregion GROUP1 HEADER_Script
                }
            }
            public partial class Group1GroupFooter : TTReportSection
            {
                public StatusNotificationOneDocReportReport MyParentReport
                {
                    get { return (StatusNotificationOneDocReportReport)ParentReport; }
                }
                
                public TTReportField DOKTOR1;
                public TTReportField HEADDOCTOROBJECTID;
                public TTReportField DOKTOR1BOLUM;
                public TTReportField DOKTOR1DIPNO;
                public TTReportField SIGNATURE3;
                public TTReportField NAME1;
                public TTReportField SURNAME1; 
                public Group1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 31;
                    RepeatCount = 0;
                    
                    DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 15, 199, 21, false);
                    DOKTOR1.Name = "DOKTOR1";
                    DOKTOR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1.TextFont.Size = 8;
                    DOKTOR1.Value = @"";

                    HEADDOCTOROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 4, 241, 9, false);
                    HEADDOCTOROBJECTID.Name = "HEADDOCTOROBJECTID";
                    HEADDOCTOROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOROBJECTID.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOROBJECTID.TextFont.CharSet = 1;
                    HEADDOCTOROBJECTID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR_OBJECTID"", """")";

                    DOKTOR1BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 11, 199, 15, false);
                    DOKTOR1BOLUM.Name = "DOKTOR1BOLUM";
                    DOKTOR1BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1BOLUM.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1BOLUM.TextFont.Size = 8;
                    DOKTOR1BOLUM.Value = @"";

                    DOKTOR1DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 20, 199, 25, false);
                    DOKTOR1DIPNO.Name = "DOKTOR1DIPNO";
                    DOKTOR1DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1DIPNO.TextFont.Name = "Arial Unicode MS";
                    DOKTOR1DIPNO.TextFont.Size = 8;
                    DOKTOR1DIPNO.Value = @"";

                    SIGNATURE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 6, 199, 11, false);
                    SIGNATURE3.Name = "SIGNATURE3";
                    SIGNATURE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE3.TextFont.Name = "Arial Unicode MS";
                    SIGNATURE3.TextFont.Size = 8;
                    SIGNATURE3.TextFont.Bold = true;
                    SIGNATURE3.Value = @"İMZA";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 21, 255, 26, false);
                    NAME1.Name = "NAME1";
                    NAME1.Visible = EvetHayirEnum.ehHayir;
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME1.ObjectDefName = "StatusNotificationReport";
                    NAME1.DataMember = "EPISODE.PATIENT.NAME";
                    NAME1.TextFont.CharSet = 1;
                    NAME1.Value = @"{@OBJECTID@}";

                    SURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 16, 255, 21, false);
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
                    DOKTOR1BOLUM.CalcValue = DOKTOR1BOLUM.Value;
                    DOKTOR1DIPNO.CalcValue = DOKTOR1DIPNO.Value;
                    SIGNATURE3.CalcValue = SIGNATURE3.Value;
                    NAME1.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    NAME1.PostFieldValueCalculation();
                    SURNAME1.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    SURNAME1.PostFieldValueCalculation();
                    HEADDOCTOROBJECTID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
                    return new TTReportObject[] { DOKTOR1,DOKTOR1BOLUM,DOKTOR1DIPNO,SIGNATURE3,NAME1,SURNAME1,HEADDOCTOROBJECTID};
                }

                public override void RunScript()
                {
#region GROUP1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationOneDocReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            if(report.ProcedureDoctor!=null)
            {
                this.DOKTOR1.CalcValue =(report.ProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(report.ProcedureDoctor.Title.Value) : "") + " " +  report.ProcedureDoctor.Name ;
                this.DOKTOR1BOLUM.CalcValue = ((report.ProcedureDoctor.ResourceSpecialities != null && report.ProcedureDoctor.ResourceSpecialities.Count > 0 )? report.ProcedureDoctor.ResourceSpecialities[0].Speciality.Name : "");
            this.DOKTOR1DIPNO.CalcValue = "Tescil No: " + report.ProcedureDoctor.DiplomaRegisterNo;
                
            }
#endregion GROUP1 FOOTER_Script
                }
            }

        }

        public Group1Group Group1;

        public partial class MAINGroup : TTReportGroup
        {
            public StatusNotificationOneDocReportReport MyParentReport
            {
                get { return (StatusNotificationOneDocReportReport)ParentReport; }
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
                public StatusNotificationOneDocReportReport MyParentReport
                {
                    get { return (StatusNotificationOneDocReportReport)ParentReport; }
                }
                
                public TTReportField DiagnosisField; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    DiagnosisField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 13, 197, 21, false);
                    DiagnosisField.Name = "DiagnosisField";
                    DiagnosisField.DrawStyle = DrawStyleConstants.vbSolid;
                    DiagnosisField.MultiLine = EvetHayirEnum.ehEvet;
                    DiagnosisField.NoClip = EvetHayirEnum.ehEvet;
                    DiagnosisField.WordBreak = EvetHayirEnum.ehEvet;
                    DiagnosisField.ExpandTabs = EvetHayirEnum.ehEvet;
                    DiagnosisField.TextFont.Name = "Arial Unicode MS";
                    DiagnosisField.Value = @" ICD KODU VE TANI(LAR)/BULGU(LAR):";

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
            string sObjectID = ((StatusNotificationOneDocReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
                    this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString() + "\n";

            foreach(ReportDiagnosis diagnosis in report.ReportDiagnosis){
                        this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString() +  diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + ", ";
            }
                    this.DiagnosisField.CalcValue = this.DiagnosisField.CalcValue.ToString().Substring(0, this.DiagnosisField.CalcValue.ToString().Length - 2) + "\n";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class TextGroup : TTReportGroup
        {
            public StatusNotificationOneDocReportReport MyParentReport
            {
                get { return (StatusNotificationOneDocReportReport)ParentReport; }
            }

            new public TextGroupBody Body()
            {
                return (TextGroupBody)_body;
            }
            public TTReportField DescriptionField { get {return Body().DescriptionField;} }
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
                public StatusNotificationOneDocReportReport MyParentReport
                {
                    get { return (StatusNotificationOneDocReportReport)ParentReport; }
                }
                
                public TTReportField DescriptionField; 
                public TextGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    DescriptionField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 197, 18, false);
                    DescriptionField.Name = "DescriptionField";
                    DescriptionField.DrawStyle = DrawStyleConstants.vbSolid;
                    DescriptionField.MultiLine = EvetHayirEnum.ehEvet;
                    DescriptionField.NoClip = EvetHayirEnum.ehEvet;
                    DescriptionField.WordBreak = EvetHayirEnum.ehEvet;
                    DescriptionField.ExpandTabs = EvetHayirEnum.ehEvet;
                    DescriptionField.TextFont.Name = "Arial Unicode MS";
                    DescriptionField.Value = @" AKLİ MELEKE RAPORU İÇİN MİNİ MENTAL TEST SONUCU:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DescriptionField.CalcValue = DescriptionField.Value;
                    return new TTReportObject[] { DescriptionField};
                }

                public override void RunScript()
                {
#region TEXT BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationOneDocReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport statusNotificationReport = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
             if (statusNotificationReport.ReportDescription != null && statusNotificationReport.ReportDescription != "")
                    {
                        this.DescriptionField.CalcValue += "\n"+ statusNotificationReport.ReportDescription;
                    }
                                 if(statusNotificationReport.ReportReason != StatusNotificationReasonEnum.MentalBalance)
                    {
                        this.DescriptionField.CalcValue += "\n\n\n\n";
                    }
#endregion TEXT BODY_Script
                }
            }

        }

        public TextGroup Text;

        public partial class DECISIONGroup : TTReportGroup
        {
            public StatusNotificationOneDocReportReport MyParentReport
            {
                get { return (StatusNotificationOneDocReportReport)ParentReport; }
            }

            new public DECISIONGroupBody Body()
            {
                return (DECISIONGroupBody)_body;
            }
            public TTReportField Decision { get {return Body().Decision;} }
            public TTReportField AppropriateCheck { get {return Body().AppropriateCheck;} }
            public TTReportField InAppropriateCheck { get {return Body().InAppropriateCheck;} }
            public TTReportField AppropriateTextField { get {return Body().AppropriateTextField;} }
            public TTReportField InAppropriateTextField { get {return Body().InAppropriateTextField;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
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
                public StatusNotificationOneDocReportReport MyParentReport
                {
                    get { return (StatusNotificationOneDocReportReport)ParentReport; }
                }
                
                public TTReportField Decision;
                public TTReportField AppropriateCheck;
                public TTReportField InAppropriateCheck;
                public TTReportField AppropriateTextField;
                public TTReportField InAppropriateTextField;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12; 
                public DECISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 47;
                    RepeatCount = 0;
                    
                    Decision = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 31, 6, false);
                    Decision.Name = "Decision";
                    Decision.TextFont.Name = "Arial Unicode MS";
                    Decision.Value = @" KARAR :";

                    AppropriateCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 19, 12, false);
                    AppropriateCheck.Name = "AppropriateCheck";
                    AppropriateCheck.DrawStyle = DrawStyleConstants.vbSolid;
                    AppropriateCheck.TextFont.Name = "Arial";
                    AppropriateCheck.TextFont.Bold = true;
                    AppropriateCheck.Value = @"";

                    InAppropriateCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 24, 19, 28, false);
                    InAppropriateCheck.Name = "InAppropriateCheck";
                    InAppropriateCheck.DrawStyle = DrawStyleConstants.vbSolid;
                    InAppropriateCheck.TextFont.Name = "Arial";
                    InAppropriateCheck.TextFont.Bold = true;
                    InAppropriateCheck.Value = @"";

                    AppropriateTextField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 8, 194, 21, false);
                    AppropriateTextField.Name = "AppropriateTextField";
                    AppropriateTextField.TextFont.Name = "Arial Unicode MS";
                    AppropriateTextField.Value = @"";

                    InAppropriateTextField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 25, 194, 37, false);
                    InAppropriateTextField.Name = "InAppropriateTextField";
                    InAppropriateTextField.TextFont.Name = "Arial Unicode MS";
                    InAppropriateTextField.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 197, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 41, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 41, 197, 41, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 0, 197, 41, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Decision.CalcValue = Decision.Value;
                    AppropriateCheck.CalcValue = AppropriateCheck.Value;
                    InAppropriateCheck.CalcValue = InAppropriateCheck.Value;
                    AppropriateTextField.CalcValue = AppropriateTextField.Value;
                    InAppropriateTextField.CalcValue = InAppropriateTextField.Value;
                    return new TTReportObject[] { Decision,AppropriateCheck,InAppropriateCheck,AppropriateTextField,InAppropriateTextField};
                }

                public override void RunScript()
                {
#region DECISION BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StatusNotificationOneDocReportReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            StatusNotificationReport report = (StatusNotificationReport)context.GetObject(new Guid(sObjectID),"StatusNotificationReport");
            DateTime examinationDate = ((DateTime)report.StartDate);
                    

                    HCRequestReason requestReason = report.HCRequestReason;
                    string reportDecision;
                    
                    if(report.ReportDecision != null){
                        reportDecision = report.ReportDecision.ToString();
                    }
                    else{
                        reportDecision = ".......................";
                    }
                    
                    if (report.Appropriate.HasValue == true && report.Appropriate.Value == true)
                    {
                        this.AppropriateCheck.CalcValue = "X";
                    }
                    else{
                        this.InAppropriateCheck.CalcValue = "X";
                    }
                    bool isHospitalPursaklar = false;
                    string hospitalParameterValue = TTObjectClasses.SystemParameter.GetParameterValue("DURUMBILDIRIRRAPORUPURSAKLAR", "FALSE");

                    if(hospitalParameterValue == "TRUE")
                    {
                        isHospitalPursaklar = true;
                    }

                    string muayeneText = "fizik";
                    if(isHospitalPursaklar == true) {
                        if (report.ReportReason == StatusNotificationReasonEnum.MentalBalance || report.ReportReason == StatusNotificationReasonEnum.Shotgun)
                            muayeneText = "psikiyatri";

                        this.AppropriateTextField.CalcValue = "Yukarıda bilgileri bulunan şahsın " + examinationDate.ToString("dd.MM.yyyy") +
                            " tarihinde yapılan " + muayeneText + " muayenesi sonucunda " + reportDecision + " bildirir hekim kanaat raporudur.";

                        this.InAppropriateTextField.CalcValue = " Yukarıda bilgileri bulunan şahsın " + examinationDate.ToString("dd.MM.yyyy") +
                            " tarihinde yapılan " + muayeneText + " muayenesi sonucunda ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmesi uygundur.";
                    }
                    else
                    {                 
                    this.AppropriateTextField.CalcValue = "Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve " + examinationDate.ToString("dd.MM.yyyy") +
                        " tarihinde yapılan " +muayeneText +" muayenesi sonucunda " + reportDecision + " engel bir durumu olmadığını bildirir hekim kanaat raporudur.";                                                    
                                        
                        this.InAppropriateTextField.CalcValue = " Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve " + examinationDate.ToString("dd.MM.yyyy") +
                            " tarihinde yapılan " + muayeneText + " muayenesi sonucunda ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmesi uygundur.";
                    }
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

        public StatusNotificationOneDocReportReport()
        {
            Group1 = new Group1Group(this,"Group1");
            MAIN = new MAINGroup(Group1,"MAIN");
            Text = new TextGroup(Group1,"Text");
            DECISION = new DECISIONGroup(Group1,"DECISION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            Name = "STATUSNOTIFICATIONONEDOCREPORTREPORT";
            Caption = "Durum Bildirir Tek Hekim Sağlık Raporu";
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