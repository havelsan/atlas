
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
    /// Hasta Katılım Payından Muaf İlaç Raporu
    /// </summary>
    public partial class ParticipatnFreeDrugReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class OutherGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public OutherGroupHeader Header()
            {
                return (OutherGroupHeader)_header;
            }

            new public OutherGroupFooter Footer()
            {
                return (OutherGroupFooter)_footer;
            }

            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXALTBASLIK { get {return Header().XXXXXXALTBASLIK;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportShape NewRect1111 { get {return Header().NewRect1111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportShape NewLine1131 { get {return Header().NewLine1131;} }
            public TTReportShape NewLine1141 { get {return Header().NewLine1141;} }
            public TTReportShape NewLine1151 { get {return Header().NewLine1151;} }
            public TTReportShape NewLine1161 { get {return Header().NewLine1161;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField NewField114411 { get {return Header().NewField114411;} }
            public TTReportField NewField115411 { get {return Header().NewField115411;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField EXAMINATIONDATE { get {return Header().EXAMINATIONDATE;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField MR { get {return Header().MR;} }
            public TTReportField MEDULATAKIPNO { get {return Header().MEDULATAKIPNO;} }
            public TTReportField STARTENDDATE { get {return Header().STARTENDDATE;} }
            public TTReportField KURUMU { get {return Header().KURUMU;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportField NewField1114311 { get {return Header().NewField1114311;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField TEL { get {return Header().TEL;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField DOKTOR1 { get {return Footer().DOKTOR1;} }
            public TTReportField SIGNATURE2 { get {return Footer().SIGNATURE2;} }
            public TTReportField SIGNATURE3 { get {return Footer().SIGNATURE3;} }
            public TTReportField SIGNATURE1 { get {return Footer().SIGNATURE1;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField HEADDOCTOR { get {return Footer().HEADDOCTOR;} }
            public TTReportField HEADDOCTOROBJECTID { get {return Footer().HEADDOCTOROBJECTID;} }
            public TTReportField ONAYLAYAN { get {return Footer().ONAYLAYAN;} }
            public TTReportField DOKTOR1BOLUM { get {return Footer().DOKTOR1BOLUM;} }
            public TTReportField DOKTOR1DIPNO { get {return Footer().DOKTOR1DIPNO;} }
            public TTReportField DOKTOR2 { get {return Footer().DOKTOR2;} }
            public TTReportField DOKTOR2BOLUM { get {return Footer().DOKTOR2BOLUM;} }
            public TTReportField DOKTOR2DIPNO { get {return Footer().DOKTOR2DIPNO;} }
            public TTReportField DOKTOR3 { get {return Footer().DOKTOR3;} }
            public TTReportField DOKTOR3BOLUM { get {return Footer().DOKTOR3BOLUM;} }
            public TTReportField DOKTOR3DIPNO { get {return Footer().DOKTOR3DIPNO;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public OutherGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OutherGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>("GetParticipatnFreeDrugReportRNQL", ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new OutherGroupHeader(this);
                _footer = new OutherGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class OutherGroupHeader : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXALTBASLIK;
                public TTReportField BASLIK;
                public TTReportField NewField11;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportShape NewRect1111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine1141;
                public TTReportShape NewLine1151;
                public TTReportShape NewLine1161;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField11311;
                public TTReportField NewField11411;
                public TTReportField NewField11511;
                public TTReportField NewField11611;
                public TTReportField NewField112411;
                public TTReportField NewField113411;
                public TTReportField NewField114411;
                public TTReportField NewField115411;
                public TTReportField NAMESURNAME;
                public TTReportField EXAMINATIONDATE;
                public TTReportField FATHERNAME;
                public TTReportField MR;
                public TTReportField MEDULATAKIPNO;
                public TTReportField STARTENDDATE;
                public TTReportField KURUMU;
                public TTReportField UNIQUEREFNO;
                public TTReportField DTARIHI;
                public TTReportField NewField1114311;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField TEL;
                public TTReportField ADDRESS;
                public TTReportField LOGO; 
                public OutherGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 94;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 25, 257, 31, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.TextFont.CharSet = 162;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 11, 257, 17, false);
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

                    XXXXXXALTBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 18, 257, 24, false);
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

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 10, 173, 32, false);
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

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 35, 201, 43, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İLAÇ KULLANIM RAPORU";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 44, 257, 49, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "ParticipatnFreeDrugReport";
                    NAME.DataMember = "EPISODE.PATIENT.NAME";
                    NAME.Value = @"{@TTOBJECTID@}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 39, 257, 44, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SURNAME.ObjectDefName = "ParticipatnFreeDrugReport";
                    SURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME.Value = @"{@TTOBJECTID@}";

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 9, 44, 201, 94, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 51, 200, 51, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 58, 200, 58, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 65, 200, 65, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 76, 200, 76, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 84, 200, 84, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 45, 103, 84, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 40, 50, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Hastanın Adı Soyadı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 52, 130, 57, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Muayene Tarihi";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 43, 64, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Doğum Tarihi";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 43, 71, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Kurumu ve Görevi";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 35, 58, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Size = 9;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Baba Adı";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 59, 130, 64, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Poliklinik/Servis";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 45, 130, 50, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.TextFont.Size = 9;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.TextFont.CharSet = 162;
                    NewField112411.Value = @"T.C Kimlik No";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 77, 35, 82, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Size = 9;
                    NewField113411.TextFont.Bold = true;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"Tel";

                    NewField114411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 67, 135, 71, false);
                    NewField114411.Name = "NewField114411";
                    NewField114411.TextFont.Size = 9;
                    NewField114411.TextFont.Bold = true;
                    NewField114411.TextFont.CharSet = 162;
                    NewField114411.Value = @"Online Protokol No";

                    NewField115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 77, 135, 81, false);
                    NewField115411.Name = "NewField115411";
                    NewField115411.TextFont.Size = 9;
                    NewField115411.TextFont.Bold = true;
                    NewField115411.TextFont.CharSet = 162;
                    NewField115411.Value = @"Başlangıç-Bitiş Tarihi";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 45, 100, 50, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Size = 9;
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"{%NAME%} {%SURNAME%}";

                    EXAMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 52, 195, 57, false);
                    EXAMINATIONDATE.Name = "EXAMINATIONDATE";
                    EXAMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXAMINATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXAMINATIONDATE.TextFont.Size = 9;
                    EXAMINATIONDATE.TextFont.CharSet = 162;
                    EXAMINATIONDATE.Value = @"";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 52, 99, 57, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.ObjectDefName = "ParticipatnFreeDrugReport";
                    FATHERNAME.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    FATHERNAME.Value = @"{@TTOBJECTID@}";

                    MR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 59, 199, 64, false);
                    MR.Name = "MR";
                    MR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MR.MultiLine = EvetHayirEnum.ehEvet;
                    MR.NoClip = EvetHayirEnum.ehEvet;
                    MR.WordBreak = EvetHayirEnum.ehEvet;
                    MR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MR.TextFont.Size = 9;
                    MR.TextFont.CharSet = 162;
                    MR.Value = @"{#MR#}";

                    MEDULATAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 67, 200, 71, false);
                    MEDULATAKIPNO.Name = "MEDULATAKIPNO";
                    MEDULATAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDULATAKIPNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEDULATAKIPNO.TextFont.Size = 9;
                    MEDULATAKIPNO.TextFont.CharSet = 162;
                    MEDULATAKIPNO.Value = @"{#REPORTCHASINGNO#}";

                    STARTENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 77, 200, 82, false);
                    STARTENDDATE.Name = "STARTENDDATE";
                    STARTENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTENDDATE.TextFont.Size = 9;
                    STARTENDDATE.TextFont.CharSet = 162;
                    STARTENDDATE.Value = @"{%STARTDATE%}-{%ENDDATE%}";

                    KURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 66, 102, 74, false);
                    KURUMU.Name = "KURUMU";
                    KURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMU.NoClip = EvetHayirEnum.ehEvet;
                    KURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMU.TextFont.Size = 9;
                    KURUMU.TextFont.CharSet = 162;
                    KURUMU.Value = @"";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 45, 175, 50, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 59, 102, 64, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"dd/MM/yyyy";
                    DTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    DTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    DTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    DTARIHI.ObjectDefName = "ParticipatnFreeDrugReport";
                    DTARIHI.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DTARIHI.TextFont.Size = 9;
                    DTARIHI.TextFont.CharSet = 162;
                    DTARIHI.Value = @"{@TTOBJECTID@}";

                    NewField1114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 85, 35, 90, false);
                    NewField1114311.Name = "NewField1114311";
                    NewField1114311.TextFont.Size = 9;
                    NewField1114311.TextFont.Bold = true;
                    NewField1114311.TextFont.CharSet = 162;
                    NewField1114311.Value = @"Adres";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 81, 251, 86, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{#REPORTSTARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 90, 251, 95, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{#REPORTENDDATE#}";

                    TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 77, 98, 82, false);
                    TEL.Name = "TEL";
                    TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEL.ObjectDefName = "ParticipatnFreeDrugReport";
                    TEL.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.MOBILEPHONE";
                    TEL.TextFont.Size = 9;
                    TEL.TextFont.CharSet = 162;
                    TEL.Value = @"{@TTOBJECTID@}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 85, 199, 92, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADDRESS.ObjectDefName = "ParticipatnFreeDrugReport";
                    ADDRESS.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.HOMEADDRESS";
                    ADDRESS.TextFont.Size = 9;
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"{@TTOBJECTID@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 40, 33, false);
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class dataset_GetParticipatnFreeDrugReportRNQL = ParentGroup.rsGroup.GetCurrentRecord<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>(0);
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BASLIK.CalcValue = MyParentReport.Outher.XXXXXXBASLIK.CalcValue;
                    NewField11.CalcValue = NewField11.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SURNAME.PostFieldValueCalculation();
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    NewField114411.CalcValue = NewField114411.Value;
                    NewField115411.CalcValue = NewField115411.Value;
                    NAMESURNAME.CalcValue = MyParentReport.Outher.NAME.CalcValue + @" " + MyParentReport.Outher.SURNAME.CalcValue;
                    EXAMINATIONDATE.CalcValue = @"";
                    FATHERNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FATHERNAME.PostFieldValueCalculation();
                    MR.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.Mr) : "");
                    MEDULATAKIPNO.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.ReportChasingNo) : "");
                    STARTDATE.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.ReportStartDate) : "");
                    ENDDATE.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.ReportEndDate) : "");
                    STARTENDDATE.CalcValue = MyParentReport.Outher.STARTDATE.FormattedValue + @"-" + MyParentReport.Outher.ENDDATE.FormattedValue;
                    KURUMU.CalcValue = @"";
                    UNIQUEREFNO.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.UniqueRefNo) : "");
                    DTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DTARIHI.PostFieldValueCalculation();
                    NewField1114311.CalcValue = NewField1114311.Value;
                    TEL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TEL.PostFieldValueCalculation();
                    ADDRESS.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ADDRESS.PostFieldValueCalculation();
                    LOGO.CalcValue = @"";
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");
                    return new TTReportObject[] { XXXXXXBASLIK,BASLIK,NewField11,NAME,SURNAME,NewField1121,NewField11211,NewField11311,NewField11411,NewField11511,NewField11611,NewField112411,NewField113411,NewField114411,NewField115411,NAMESURNAME,EXAMINATIONDATE,FATHERNAME,MR,MEDULATAKIPNO,STARTDATE,ENDDATE,STARTENDDATE,KURUMU,UNIQUEREFNO,DTARIHI,NewField1114311,TEL,ADDRESS,LOGO,XXXXXXIL,XXXXXXALTBASLIK};
                }

                public override void RunScript()
                {
#region OUTHER HEADER_Script
                    //
//            
//            string diagnoseStr= "";
//            if( this.MILUNIT.CalcValue != "")
//            {
//                this.PATIENTENTERPRISEORMILUNIT.CalcValue= this.MILUNIT.CalcValue;
//            }
//            else
//            {
//                this.PATIENTENTERPRISEORMILUNIT.CalcValue= this.PATIENTENTERPRISE.CalcValue;
//            }
//            
//            
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
//            if(p.Episode.Relationship != null)
//            {
//                this.PATIENTENTERPRISEORMILUNIT.CalcValue += "(" + p.Episode.Relationship.Relationship + ")";
//            }
//            
//            if(p.Episode.PatientExaminations.Count > 0)
//            {
//                foreach(PatientExamination pe in p.Episode.PatientExaminations)
//                {
//                    if (pe.Cancelled != true)
//                    {
//                        this.PDEFNO.CalcValue = pe.ProtocolNo.Value.ToString();
//                        break;
//                    }
//                }
//            }
//            else if(p.Episode.InpatientAdmissions.Count > 0)
//            {
//                foreach(InpatientAdmission ia in p.Episode.InpatientAdmissions)
//                {
//                    if (ia.Cancelled != true)
//                    {
//                        this.PDEFNO.CalcValue = ia.QuarantineProtocolNo.Value.ToString();
//                        break;
//                    }
//                }
//            }
//            else if(p.Episode.EmergencyInterventions.Count > 0)
//            {
//                foreach(EmergencyIntervention ei in p.Episode.EmergencyInterventions)
//                {
//                    if (ei.Cancelled != true)
//                    {
//                        this.PDEFNO.CalcValue = ei.ProtocolNo.Value.ToString();
//                        break;
//                    }
//                }
//            }
//            
//            if(p.Diagnosis.Count>0)// Buradan tanı girişi yapılmadıysa episodedaki kesin  tanılara bakar
//            {
//                foreach( DiagnosisGrid diagnosis in p.Diagnosis)
//                {
//                    diagnoseStr = diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name  + "-" +  diagnosis.FreeDiagnosis + "; " + diagnoseStr ;
//                }
//            }
//            else
//            {
//                foreach( DiagnosisGrid diagnosis in p.Episode.SecDiagnosis)
//                {
//                    diagnoseStr = diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name  + "-" +  diagnosis.FreeDiagnosis + "; " + diagnoseStr ;
//                }
//            }
//            this.DIAGNOSISFIELD.CalcValue= diagnoseStr;
//            
//            if(p.ProcedureDoctor!=null) {
//                //this.SIGNATURE.CalcValue =p.ProcedureDoctor.SignatureBlock;
//                //edited by ETAGMAT 06.03.2012
//                this.SIGNATURE.CalcValue =p.ProcedureDoctor.SignatureBlockWDiplomaInfo;             
//            }
//            
//            //            foreach(TTObjectState obj in p.GetStateHistory())
//            //            {
//            //                if( obj.StateDefID == ParticipatnFreeDrugReport.States.Report)
//            //                {
//            //                    this.SIGNATURE.CalcValue= obj.User.Name;
//            //                    //this.SIGNATURE1.CalcValue= obj.User.Name;
//            //                }
//            //            }
//            
//            if(this.PATIENTAPPROVALFORMNO.CalcValue != "")
//            {
//                this.ACIKLAMA.CalcValue = "Hastaya onay formu dolduruldu. Form Seri No : " + this.PATIENTAPPROVALFORMNO.CalcValue;
//            }
//            else
//                this.ACIKLAMA.CalcValue = "";

 TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");  
            this.KURUMU.CalcValue = p.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
            
                this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
               SubEpisode subepisode = p.SubEpisode;
             
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
#endregion OUTHER HEADER_Script
                }
            }
            public partial class OutherGroupFooter : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField DOKTOR1;
                public TTReportField SIGNATURE2;
                public TTReportField SIGNATURE3;
                public TTReportField SIGNATURE1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField HEADDOCTOR;
                public TTReportField HEADDOCTOROBJECTID;
                public TTReportField ONAYLAYAN;
                public TTReportField DOKTOR1BOLUM;
                public TTReportField DOKTOR1DIPNO;
                public TTReportField DOKTOR2;
                public TTReportField DOKTOR2BOLUM;
                public TTReportField DOKTOR2DIPNO;
                public TTReportField DOKTOR3;
                public TTReportField DOKTOR3BOLUM;
                public TTReportField DOKTOR3DIPNO;
                public TTReportField NewField16; 
                public OutherGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 59;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 15, 64, 22, false);
                    DOKTOR1.Name = "DOKTOR1";
                    DOKTOR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1.TextFont.Size = 9;
                    DOKTOR1.TextFont.CharSet = 162;
                    DOKTOR1.Value = @"";

                    SIGNATURE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 4, 128, 9, false);
                    SIGNATURE2.Name = "SIGNATURE2";
                    SIGNATURE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE2.TextFont.Size = 9;
                    SIGNATURE2.TextFont.Bold = true;
                    SIGNATURE2.TextFont.CharSet = 162;
                    SIGNATURE2.Value = @"İMZA";

                    SIGNATURE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 4, 192, 9, false);
                    SIGNATURE3.Name = "SIGNATURE3";
                    SIGNATURE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE3.TextFont.Size = 9;
                    SIGNATURE3.TextFont.Bold = true;
                    SIGNATURE3.TextFont.CharSet = 162;
                    SIGNATURE3.Value = @"İMZA";

                    SIGNATURE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 4, 64, 9, false);
                    SIGNATURE1.Name = "SIGNATURE1";
                    SIGNATURE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE1.TextFont.Size = 9;
                    SIGNATURE1.TextFont.Bold = true;
                    SIGNATURE1.TextFont.CharSet = 162;
                    SIGNATURE1.Value = @"İMZA";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 29, 116, 34, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"ONAY";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 34, 124, 39, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"...../...../........";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 39, 128, 46, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTOR.TextFont.Size = 9;
                    HEADDOCTOR.TextFont.Bold = true;
                    HEADDOCTOR.TextFont.CharSet = 162;
                    HEADDOCTOR.Value = @"";

                    HEADDOCTOROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 32, 258, 37, false);
                    HEADDOCTOROBJECTID.Name = "HEADDOCTOROBJECTID";
                    HEADDOCTOROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOROBJECTID.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOROBJECTID.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR_OBJECTID"", """")";

                    ONAYLAYAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 46, 116, 51, false);
                    ONAYLAYAN.Name = "ONAYLAYAN";
                    ONAYLAYAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    ONAYLAYAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYLAYAN.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYLAYAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYLAYAN.TextFont.Size = 9;
                    ONAYLAYAN.TextFont.Bold = true;
                    ONAYLAYAN.TextFont.CharSet = 162;
                    ONAYLAYAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTORTITAL"", ""Başhekim"")";

                    DOKTOR1BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 10, 64, 15, false);
                    DOKTOR1BOLUM.Name = "DOKTOR1BOLUM";
                    DOKTOR1BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1BOLUM.TextFont.Size = 9;
                    DOKTOR1BOLUM.TextFont.CharSet = 162;
                    DOKTOR1BOLUM.Value = @"";

                    DOKTOR1DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 22, 64, 27, false);
                    DOKTOR1DIPNO.Name = "DOKTOR1DIPNO";
                    DOKTOR1DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR1DIPNO.TextFont.Size = 9;
                    DOKTOR1DIPNO.TextFont.CharSet = 162;
                    DOKTOR1DIPNO.Value = @"";

                    DOKTOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 15, 128, 22, false);
                    DOKTOR2.Name = "DOKTOR2";
                    DOKTOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2.TextFont.Size = 9;
                    DOKTOR2.TextFont.CharSet = 162;
                    DOKTOR2.Value = @"";

                    DOKTOR2BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 10, 128, 15, false);
                    DOKTOR2BOLUM.Name = "DOKTOR2BOLUM";
                    DOKTOR2BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2BOLUM.TextFont.Size = 9;
                    DOKTOR2BOLUM.TextFont.CharSet = 162;
                    DOKTOR2BOLUM.Value = @"";

                    DOKTOR2DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 22, 128, 27, false);
                    DOKTOR2DIPNO.Name = "DOKTOR2DIPNO";
                    DOKTOR2DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR2DIPNO.TextFont.Size = 9;
                    DOKTOR2DIPNO.TextFont.CharSet = 162;
                    DOKTOR2DIPNO.Value = @"";

                    DOKTOR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 15, 192, 22, false);
                    DOKTOR3.Name = "DOKTOR3";
                    DOKTOR3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3.TextFont.Size = 9;
                    DOKTOR3.TextFont.CharSet = 162;
                    DOKTOR3.Value = @"";

                    DOKTOR3BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 10, 192, 15, false);
                    DOKTOR3BOLUM.Name = "DOKTOR3BOLUM";
                    DOKTOR3BOLUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3BOLUM.TextFont.Size = 9;
                    DOKTOR3BOLUM.TextFont.CharSet = 162;
                    DOKTOR3BOLUM.Value = @"";

                    DOKTOR3DIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 22, 192, 27, false);
                    DOKTOR3DIPNO.Name = "DOKTOR3DIPNO";
                    DOKTOR3DIPNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTOR3DIPNO.TextFont.Size = 9;
                    DOKTOR3DIPNO.TextFont.CharSet = 162;
                    DOKTOR3DIPNO.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 52, 206, 57, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class dataset_GetParticipatnFreeDrugReportRNQL = ParentGroup.rsGroup.GetCurrentRecord<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>(0);
                    DOKTOR1.CalcValue = DOKTOR1.Value;
                    SIGNATURE2.CalcValue = SIGNATURE2.Value;
                    SIGNATURE3.CalcValue = SIGNATURE3.Value;
                    SIGNATURE1.CalcValue = SIGNATURE1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    HEADDOCTOR.CalcValue = HEADDOCTOR.Value;
                    DOKTOR1BOLUM.CalcValue = DOKTOR1BOLUM.Value;
                    DOKTOR1DIPNO.CalcValue = DOKTOR1DIPNO.Value;
                    DOKTOR2.CalcValue = DOKTOR2.Value;
                    DOKTOR2BOLUM.CalcValue = DOKTOR2BOLUM.Value;
                    DOKTOR2DIPNO.CalcValue = DOKTOR2DIPNO.Value;
                    DOKTOR3.CalcValue = DOKTOR3.Value;
                    DOKTOR3BOLUM.CalcValue = DOKTOR3BOLUM.Value;
                    DOKTOR3DIPNO.CalcValue = DOKTOR3DIPNO.Value;
                    NewField16.CalcValue = NewField16.Value;
                    HEADDOCTOROBJECTID.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
                    ONAYLAYAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL", "Başhekim");
                    return new TTReportObject[] { DOKTOR1,SIGNATURE2,SIGNATURE3,SIGNATURE1,NewField12,NewField13,HEADDOCTOR,DOKTOR1BOLUM,DOKTOR1DIPNO,DOKTOR2,DOKTOR2BOLUM,DOKTOR2DIPNO,DOKTOR3,DOKTOR3BOLUM,DOKTOR3DIPNO,NewField16,HEADDOCTOROBJECTID,ONAYLAYAN};
                }

                public override void RunScript()
                {
#region OUTHER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
            if(p.ProcedureDoctor!=null)
            {
                this.DOKTOR1.CalcValue =(p.ProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(p.ProcedureDoctor.Title.Value) : "") + " " +  p.ProcedureDoctor.Name ;
                this.DOKTOR1BOLUM.CalcValue = ((p.ProcedureDoctor.ResourceSpecialities != null && p.ProcedureDoctor.ResourceSpecialities.Count > 0 )? p.ProcedureDoctor.ResourceSpecialities[0].Speciality.Name : "");
                this.DOKTOR1DIPNO.CalcValue = p.ProcedureDoctor.DiplomaRegisterNo;
                
            }
            
            if(p.CommitteeReport  == true)
            {
                this.SIGNATURE2.Visible = EvetHayirEnum.ehEvet;
                this.SIGNATURE3.Visible = EvetHayirEnum.ehEvet;
                if(p.SecondDoctor!=null)
                {
                    this.DOKTOR2.CalcValue =(p.SecondDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(p.SecondDoctor.Title.Value) : "") + " " +  p.SecondDoctor.Name ;
                    this.DOKTOR2BOLUM.CalcValue = ((p.SecondDoctor.ResourceSpecialities != null && p.SecondDoctor.ResourceSpecialities.Count > 0 )? p.SecondDoctor.ResourceSpecialities[0].Speciality.Name : "");
                     this.DOKTOR2DIPNO.CalcValue = p.SecondDoctor.DiplomaRegisterNo;
                
                }     
                if(p.ThirdDoctor!=null)
                {
                      this.DOKTOR3.CalcValue =(p.ThirdDoctor.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(p.ThirdDoctor.Title.Value) : "") + " " +  p.ThirdDoctor.Name ;
                      this.DOKTOR3BOLUM.CalcValue = ((p.ThirdDoctor.ResourceSpecialities != null && p.ThirdDoctor.ResourceSpecialities.Count > 0 )? p.ThirdDoctor.ResourceSpecialities[0].Speciality.Name : "");
                      this.DOKTOR3DIPNO.CalcValue = p.ThirdDoctor.DiplomaRegisterNo;
                
                 }     
            }
            else
            {
                 this.SIGNATURE2.Visible = EvetHayirEnum.ehHayir;
                this.SIGNATURE3.Visible = EvetHayirEnum.ehHayir;
            }
            
            
            ResUser head = (ResUser)context.GetObject(new Guid(this.HEADDOCTOROBJECTID.CalcValue),"ResUser");
            this.HEADDOCTOR.CalcValue = (head.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(head.Title.Value) : "") + " " +  head.Name ;
#endregion OUTHER FOOTER_Script
                }
            }

        }

        public OutherGroup Outher;

        public partial class MAINGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11911 { get {return Body().NewField11911;} }
            public TTReportField TESTSANDSIGNS { get {return Body().TESTSANDSIGNS;} }
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
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField NewField11911;
                public TTReportField TESTSANDSIGNS; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 62, 5, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.TextFont.Bold = true;
                    NewField11911.TextFont.Underline = true;
                    NewField11911.TextFont.CharSet = 162;
                    NewField11911.Value = @"MUAYENE BULGULARI";

                    TESTSANDSIGNS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 201, 16, false);
                    TESTSANDSIGNS.Name = "TESTSANDSIGNS";
                    TESTSANDSIGNS.MultiLine = EvetHayirEnum.ehEvet;
                    TESTSANDSIGNS.NoClip = EvetHayirEnum.ehEvet;
                    TESTSANDSIGNS.WordBreak = EvetHayirEnum.ehEvet;
                    TESTSANDSIGNS.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESTSANDSIGNS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11911.CalcValue = NewField11911.Value;
                    TESTSANDSIGNS.CalcValue = TESTSANDSIGNS.Value;
                    return new TTReportObject[] { NewField11911,TESTSANDSIGNS};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            //System.Diagnostics.Debugger.Break();
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport participatnFreeDrugReport = (ParticipatnFreeDrugReport)context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
            if(participatnFreeDrugReport.TestsAndSigns !=null)
                this.TESTSANDSIGNS.Value =TTReportTool.TTReport.HTMLtoText(participatnFreeDrugReport.TestsAndSigns.ToString()) + "\r\n";
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        public partial class DIAGNOSISGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public DIAGNOSISGroupBody Body()
            {
                return (DIAGNOSISGroupBody)_body;
            }
            public TTReportField DIAGNOSISFIELD { get {return Body().DIAGNOSISFIELD;} }
            public TTReportField NewField111911 { get {return Body().NewField111911;} }
            public DIAGNOSISGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DIAGNOSISGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DIAGNOSISGroupBody(this);
            }

            public partial class DIAGNOSISGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField DIAGNOSISFIELD;
                public TTReportField NewField111911; 
                public DIAGNOSISGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    DIAGNOSISFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 201, 16, false);
                    DIAGNOSISFIELD.Name = "DIAGNOSISFIELD";
                    DIAGNOSISFIELD.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.Value = @"";

                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 62, 5, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.TextFont.Bold = true;
                    NewField111911.TextFont.Underline = true;
                    NewField111911.TextFont.CharSet = 162;
                    NewField111911.Value = @"TANILAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DIAGNOSISFIELD.CalcValue = DIAGNOSISFIELD.Value;
                    NewField111911.CalcValue = NewField111911.Value;
                    return new TTReportObject[] { DIAGNOSISFIELD,NewField111911};
                }

                public override void RunScript()
                {
#region DIAGNOSIS BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
            if(p.ReportDiagnosis != null )
            { 
                foreach (ReportDiagnosis diagnosis in p.ReportDiagnosis)
                {
                    this.DIAGNOSISFIELD.CalcValue +=  diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + "\r\n";
                }
            }
#endregion DIAGNOSIS BODY_Script
                }
            }

        }

        public DIAGNOSISGroup DIAGNOSIS;

        public partial class DRUGBASLIKGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public DRUGBASLIKGroupBody Body()
            {
                return (DRUGBASLIKGroupBody)_body;
            }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField NewField11811 { get {return Body().NewField11811;} }
            public TTReportField NewField11812 { get {return Body().NewField11812;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public DRUGBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DRUGBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DRUGBASLIKGroupBody(this);
            }

            public partial class DRUGBASLIKGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField NewField141;
                public TTReportField NewField1181;
                public TTReportField NewField11811;
                public TTReportField NewField11812;
                public TTReportField NewField1; 
                public DRUGBASLIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 111, 6, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @" İlacın Etken Madde İsmi (Medula Kapsamında)";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 1, 158, 6, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"Doz 1";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 180, 6, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @"Doz 2";

                    NewField11812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 201, 6, false);
                    NewField11812.Name = "NewField11812";
                    NewField11812.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11812.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11812.TextFont.Bold = true;
                    NewField11812.TextFont.CharSet = 162;
                    NewField11812.Value = @"Birimi";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 136, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Periyot";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField141.CalcValue = NewField141.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField11812.CalcValue = NewField11812.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField141,NewField1181,NewField11811,NewField11812,NewField1};
                }
                public override void RunPreScript()
                {
#region DRUGBASLIK BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
            int etkenMaddeKontrol = 0;
            foreach(ParticipationFreeDrgGrid item in p.ParticipationFreeDrugs)
            {
                if (item.EtkinMadde != null)
                    etkenMaddeKontrol=1;
            }
            if( etkenMaddeKontrol == 0)
            {
                this.NewField1.Visible = EvetHayirEnum.ehHayir;
                this.NewField1181.Visible = EvetHayirEnum.ehHayir;
                this.NewField11811.Visible = EvetHayirEnum.ehHayir;
                this.NewField11812.Visible = EvetHayirEnum.ehHayir;
                this.NewField141.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.NewField1.Visible = EvetHayirEnum.ehEvet;
                this.NewField1181.Visible = EvetHayirEnum.ehEvet;
                this.NewField11811.Visible = EvetHayirEnum.ehEvet;
                this.NewField11812.Visible = EvetHayirEnum.ehEvet;
                this.NewField141.Visible = EvetHayirEnum.ehEvet;
            }
#endregion DRUGBASLIK BODY_PreScript
                }
            }

        }

        public DRUGBASLIKGroup DRUGBASLIK;

        public partial class DRUGGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public DRUGGroupBody Body()
            {
                return (DRUGGroupBody)_body;
            }
            public TTReportField DRUGNAME { get {return Body().DRUGNAME;} }
            public TTReportField MEDULADOSEINTEGER { get {return Body().MEDULADOSEINTEGER;} }
            public TTReportField MEDULAUSAGEDOSE2 { get {return Body().MEDULAUSAGEDOSE2;} }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField ICERIKMIKTARI { get {return Body().ICERIKMIKTARI;} }
            public TTReportField PERIODUNITTYPE { get {return Body().PERIODUNITTYPE;} }
            public TTReportField DozBirimi { get {return Body().DozBirimi;} }
            public TTReportField Gun { get {return Body().Gun;} }
            public DRUGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DRUGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class>("GetParticipantFreeDrugRepRNQL", ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DRUGGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DRUGGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField DRUGNAME;
                public TTReportField MEDULADOSEINTEGER;
                public TTReportField MEDULAUSAGEDOSE2;
                public TTReportField NO;
                public TTReportField ICERIKMIKTARI;
                public TTReportField PERIODUNITTYPE;
                public TTReportField DozBirimi;
                public TTReportField Gun; 
                public DRUGGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 112, 6, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.Value = @"{#ETKINMADDEADI#}";

                    MEDULADOSEINTEGER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 1, 158, 6, false);
                    MEDULADOSEINTEGER.Name = "MEDULADOSEINTEGER";
                    MEDULADOSEINTEGER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDULADOSEINTEGER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MEDULADOSEINTEGER.Value = @"{#MEDULADOSEINTEGER#}";

                    MEDULAUSAGEDOSE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 180, 6, false);
                    MEDULAUSAGEDOSE2.Name = "MEDULAUSAGEDOSE2";
                    MEDULAUSAGEDOSE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDULAUSAGEDOSE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MEDULAUSAGEDOSE2.Value = @"{#MEDULAUSAGEDOSE2#}";

                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 15, 6, false);
                    NO.Name = "NO";
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.TextFont.CharSet = 162;
                    NO.Value = @"{@counter@} -";

                    ICERIKMIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 243, 6, false);
                    ICERIKMIKTARI.Name = "ICERIKMIKTARI";
                    ICERIKMIKTARI.Visible = EvetHayirEnum.ehHayir;
                    ICERIKMIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICERIKMIKTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ICERIKMIKTARI.Value = @"{#ICERIKMIKTARI#}";

                    PERIODUNITTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 136, 6, false);
                    PERIODUNITTYPE.Name = "PERIODUNITTYPE";
                    PERIODUNITTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERIODUNITTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERIODUNITTYPE.ObjectDefName = "PeriodUnitTypeEnum";
                    PERIODUNITTYPE.DataMember = "DISPLAYTEXT";
                    PERIODUNITTYPE.Value = @"{#PERIODUNITTYPE#}";

                    DozBirimi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 201, 6, false);
                    DozBirimi.Name = "DozBirimi";
                    DozBirimi.FieldType = ReportFieldTypeEnum.ftVariable;
                    DozBirimi.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DozBirimi.ObjectDefName = "UsageDoseUnitTypeEnum";
                    DozBirimi.DataMember = "DISPLAYTEXT";
                    DozBirimi.Value = @"{#USAGEDOSEUNITTYPE#}";

                    Gun = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 1, 117, 6, false);
                    Gun.Name = "Gun";
                    Gun.FieldType = ReportFieldTypeEnum.ftVariable;
                    Gun.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Gun.Value = @"{#DAY#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class dataset_GetParticipantFreeDrugRepRNQL = ParentGroup.rsGroup.GetCurrentRecord<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class>(0);
                    DRUGNAME.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.etkinMaddeAdi) : "");
                    MEDULADOSEINTEGER.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.MedulaDoseInteger) : "");
                    MEDULAUSAGEDOSE2.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.MedulaUsageDose2) : "");
                    NO.CalcValue = ParentGroup.Counter.ToString() + @" -";
                    ICERIKMIKTARI.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.icerikMiktari) : "");
                    PERIODUNITTYPE.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.PeriodUnitType) : "");
                    PERIODUNITTYPE.PostFieldValueCalculation();
                    DozBirimi.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.UsageDoseUnitType) : "");
                    DozBirimi.PostFieldValueCalculation();
                    Gun.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL.Day) : "");
                    return new TTReportObject[] { DRUGNAME,MEDULADOSEINTEGER,MEDULAUSAGEDOSE2,NO,ICERIKMIKTARI,PERIODUNITTYPE,DozBirimi,Gun};
                }
                public override void RunPreScript()
                {
#region DRUG BODY_PreScript
                    //   TTObjectContext context = new TTObjectContext(true);
          //  string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
           // ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
          
           // foreach(ParticipationFreeDrgGrid item in p.ParticipationFreeDrugs)
           // {
              //  if(item.EtkinMadde !=null)
              //  {
                 //   this.ICERIKMIKTARI.CalcValue = item.EtkinMadde.icerikMiktari;
               // }
          //  }
#endregion DRUG BODY_PreScript
                }
            }

        }

        public DRUGGroup DRUG;

        public partial class DRUGNOTMEDULABASLIKGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public DRUGNOTMEDULABASLIKGroupBody Body()
            {
                return (DRUGNOTMEDULABASLIKGroupBody)_body;
            }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField11811 { get {return Body().NewField11811;} }
            public TTReportField NewField111811 { get {return Body().NewField111811;} }
            public TTReportField NewField121811 { get {return Body().NewField121811;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public DRUGNOTMEDULABASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DRUGNOTMEDULABASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DRUGNOTMEDULABASLIKGroupBody(this);
            }

            public partial class DRUGNOTMEDULABASLIKGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField NewField1141;
                public TTReportField NewField11811;
                public TTReportField NewField111811;
                public TTReportField NewField121811;
                public TTReportField NewField11; 
                public DRUGNOTMEDULABASLIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 111, 6, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @" İlacın Etken Madde İsmi (Medula Harici)";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 1, 158, 6, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @"Doz 1";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 180, 6, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111811.TextFont.Bold = true;
                    NewField111811.TextFont.CharSet = 162;
                    NewField111811.Value = @"Doz 2";

                    NewField121811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 201, 6, false);
                    NewField121811.Name = "NewField121811";
                    NewField121811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121811.TextFont.Bold = true;
                    NewField121811.TextFont.CharSet = 162;
                    NewField121811.Value = @"Birimi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 136, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Periyot";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    NewField121811.CalcValue = NewField121811.Value;
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField1141,NewField11811,NewField111811,NewField121811,NewField11};
                }
                public override void RunPreScript()
                {
#region DRUGNOTMEDULABASLIK BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport p = (ParticipatnFreeDrugReport )context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
            
            int etkenMaddeKontrol = 0;
            foreach(ParticipationFreeDrgGrid item in p.ParticipationFreeDrugs)
            {
                if (item.EtkinMadde == null)
                    etkenMaddeKontrol=1;
            }
            if( etkenMaddeKontrol == 0)
            {
                this.NewField111811.Visible = EvetHayirEnum.ehHayir;
                this.NewField11.Visible = EvetHayirEnum.ehHayir;
                this.NewField11811.Visible = EvetHayirEnum.ehHayir;
                this.NewField121811.Visible = EvetHayirEnum.ehHayir;
                this.NewField1141.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.NewField111811.Visible = EvetHayirEnum.ehEvet;
                this.NewField11.Visible = EvetHayirEnum.ehEvet;
                this.NewField11811.Visible = EvetHayirEnum.ehEvet;
                this.NewField121811.Visible = EvetHayirEnum.ehEvet;
                this.NewField1141.Visible = EvetHayirEnum.ehEvet;
            }
#endregion DRUGNOTMEDULABASLIK BODY_PreScript
                }
            }

        }

        public DRUGNOTMEDULABASLIKGroup DRUGNOTMEDULABASLIK;

        public partial class DRUGNOTMEDULAGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public DRUGNOTMEDULAGroupBody Body()
            {
                return (DRUGNOTMEDULAGroupBody)_body;
            }
            public TTReportField DRUGNAME1 { get {return Body().DRUGNAME1;} }
            public TTReportField FREQUENCY1 { get {return Body().FREQUENCY1;} }
            public TTReportField DOSE1 { get {return Body().DOSE1;} }
            public TTReportField NO1 { get {return Body().NO1;} }
            public TTReportField DOZBIRIM1 { get {return Body().DOZBIRIM1;} }
            public TTReportField PERIODUNITTYPE1 { get {return Body().PERIODUNITTYPE1;} }
            public TTReportField dozBirimi1 { get {return Body().dozBirimi1;} }
            public TTReportField Gun1 { get {return Body().Gun1;} }
            public DRUGNOTMEDULAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DRUGNOTMEDULAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class>("GetParticipantFreeDrugRepRNQL_NotMedula", ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DRUGNOTMEDULAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DRUGNOTMEDULAGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField DRUGNAME1;
                public TTReportField FREQUENCY1;
                public TTReportField DOSE1;
                public TTReportField NO1;
                public TTReportField DOZBIRIM1;
                public TTReportField PERIODUNITTYPE1;
                public TTReportField dozBirimi1;
                public TTReportField Gun1; 
                public DRUGNOTMEDULAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    DRUGNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 111, 6, false);
                    DRUGNAME1.Name = "DRUGNAME1";
                    DRUGNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME1.Value = @"{#DRUGNAME#}";

                    FREQUENCY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 1, 158, 6, false);
                    FREQUENCY1.Name = "FREQUENCY1";
                    FREQUENCY1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FREQUENCY1.Value = @"{#MEDULADOSEINTEGER#}";

                    DOSE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 180, 6, false);
                    DOSE1.Name = "DOSE1";
                    DOSE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOSE1.Value = @"{#MEDULAUSAGEDOSE2#}";

                    NO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 15, 6, false);
                    NO1.Name = "NO1";
                    NO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO1.TextFont.CharSet = 162;
                    NO1.Value = @"{@counter@} -";

                    DOZBIRIM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 201, 6, false);
                    DOZBIRIM1.Name = "DOZBIRIM1";
                    DOZBIRIM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOZBIRIM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOZBIRIM1.Value = @"{%dozBirimi1%}";

                    PERIODUNITTYPE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 260, 5, false);
                    PERIODUNITTYPE1.Name = "PERIODUNITTYPE1";
                    PERIODUNITTYPE1.Visible = EvetHayirEnum.ehHayir;
                    PERIODUNITTYPE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERIODUNITTYPE1.ObjectDefName = "PeriodUnitTypeEnum";
                    PERIODUNITTYPE1.DataMember = "DISPLAYTEXT";
                    PERIODUNITTYPE1.Value = @"{#PERIODUNITTYPE#}";

                    dozBirimi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 1, 230, 6, false);
                    dozBirimi1.Name = "dozBirimi1";
                    dozBirimi1.Visible = EvetHayirEnum.ehHayir;
                    dozBirimi1.FieldType = ReportFieldTypeEnum.ftVariable;
                    dozBirimi1.ObjectDefName = "UsageDoseUnitTypeEnum";
                    dozBirimi1.DataMember = "DISPLAYTEXT";
                    dozBirimi1.Value = @"{#USAGEDOSEUNITTYPE#}";

                    Gun1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 136, 6, false);
                    Gun1.Name = "Gun1";
                    Gun1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Gun1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Gun1.Value = @"{#DAY#} {%PERIODUNITTYPE1%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class dataset_GetParticipantFreeDrugRepRNQL_NotMedula = ParentGroup.rsGroup.GetCurrentRecord<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class>(0);
                    DRUGNAME1.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL_NotMedula != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL_NotMedula.DrugName) : "");
                    FREQUENCY1.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL_NotMedula != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL_NotMedula.MedulaDoseInteger) : "");
                    DOSE1.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL_NotMedula != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL_NotMedula.MedulaUsageDose2) : "");
                    NO1.CalcValue = ParentGroup.Counter.ToString() + @" -";
                    dozBirimi1.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL_NotMedula != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL_NotMedula.UsageDoseUnitType) : "");
                    dozBirimi1.PostFieldValueCalculation();
                    DOZBIRIM1.CalcValue = MyParentReport.DRUGNOTMEDULA.dozBirimi1.CalcValue;
                    PERIODUNITTYPE1.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL_NotMedula != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL_NotMedula.PeriodUnitType) : "");
                    PERIODUNITTYPE1.PostFieldValueCalculation();
                    Gun1.CalcValue = (dataset_GetParticipantFreeDrugRepRNQL_NotMedula != null ? Globals.ToStringCore(dataset_GetParticipantFreeDrugRepRNQL_NotMedula.Day) : "") + @" " + MyParentReport.DRUGNOTMEDULA.PERIODUNITTYPE1.CalcValue;
                    return new TTReportObject[] { DRUGNAME1,FREQUENCY1,DOSE1,NO1,dozBirimi1,DOZBIRIM1,PERIODUNITTYPE1,Gun1};
                }
            }

        }

        public DRUGNOTMEDULAGroup DRUGNOTMEDULA;

        public partial class MEDULADESCRIPTIONGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public MEDULADESCRIPTIONGroupBody Body()
            {
                return (MEDULADESCRIPTIONGroupBody)_body;
            }
            public TTReportField NewField11119111 { get {return Body().NewField11119111;} }
            public TTReportField MEDULADESCRIPTION { get {return Body().MEDULADESCRIPTION;} }
            public MEDULADESCRIPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MEDULADESCRIPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MEDULADESCRIPTIONGroupBody(this);
            }

            public partial class MEDULADESCRIPTIONGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField NewField11119111;
                public TTReportField MEDULADESCRIPTION; 
                public MEDULADESCRIPTIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 32, 9, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.Underline = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"AÇIKLAMA";

                    MEDULADESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 201, 21, false);
                    MEDULADESCRIPTION.Name = "MEDULADESCRIPTION";
                    MEDULADESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    MEDULADESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    MEDULADESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    MEDULADESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEDULADESCRIPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11119111.CalcValue = NewField11119111.Value;
                    MEDULADESCRIPTION.CalcValue = MEDULADESCRIPTION.Value;
                    return new TTReportObject[] { NewField11119111,MEDULADESCRIPTION};
                }
                public override void RunPreScript()
                {
#region MEDULADESCRIPTION BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            //System.Diagnostics.Debugger.Break();
            string sObjectID = ((ParticipatnFreeDrugReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ParticipatnFreeDrugReport participatnFreeDrugReport = (ParticipatnFreeDrugReport)context.GetObject(new Guid(sObjectID),"ParticipatnFreeDrugReport");
            if(participatnFreeDrugReport.Description !=null)
                this.MEDULADESCRIPTION.Value =TTReportTool.TTReport.HTMLtoText(participatnFreeDrugReport.Description.ToString()) + "\r\n";
#endregion MEDULADESCRIPTION BODY_PreScript
                }
            }

        }

        public MEDULADESCRIPTIONGroup MEDULADESCRIPTION;

        public partial class DESCRIPTIONGroup : TTReportGroup
        {
            public ParticipatnFreeDrugReportReport MyParentReport
            {
                get { return (ParticipatnFreeDrugReportReport)ParentReport; }
            }

            new public DESCRIPTIONGroupBody Body()
            {
                return (DESCRIPTIONGroupBody)_body;
            }
            public TTReportField NOTE1 { get {return Body().NOTE1;} }
            public TTReportField STARTDATE1 { get {return Body().STARTDATE1;} }
            public TTReportField ENDDATE1 { get {return Body().ENDDATE1;} }
            public TTReportField NewField1119111 { get {return Body().NewField1119111;} }
            public DESCRIPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DESCRIPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DESCRIPTIONGroupBody(this);
            }

            public partial class DESCRIPTIONGroupBody : TTReportSection
            {
                public ParticipatnFreeDrugReportReport MyParentReport
                {
                    get { return (ParticipatnFreeDrugReportReport)ParentReport; }
                }
                
                public TTReportField NOTE1;
                public TTReportField STARTDATE1;
                public TTReportField ENDDATE1;
                public TTReportField NewField1119111; 
                public DESCRIPTIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    NOTE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 201, 15, false);
                    NOTE1.Name = "NOTE1";
                    NOTE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTE1.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE1.NoClip = EvetHayirEnum.ehEvet;
                    NOTE1.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE1.Value = @" Hastanın yukarıda etken madde ismi, kullanım dozu, adedi ve tanıları ile ilgili ilaçlarını ..{%STARTDATE1%} -  {%ENDDATE1%}.. tarihleri arasında kullanılması gerekmekte olup, hasta katılım payından muaftır.";

                    STARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, -1, 245, 4, false);
                    STARTDATE1.Name = "STARTDATE1";
                    STARTDATE1.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE1.TextFormat = @"dd/MM/yyyy";
                    STARTDATE1.Value = @"{#Outher.REPORTSTARTDATE#}";

                    ENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 9, 245, 14, false);
                    ENDDATE1.Name = "ENDDATE1";
                    ENDDATE1.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE1.TextFormat = @"dd/MM/yyyy";
                    ENDDATE1.Value = @"{#Outher.REPORTENDDATE#}";

                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 32, 5, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.Underline = true;
                    NewField1119111.TextFont.CharSet = 162;
                    NewField1119111.Value = @"KARAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class dataset_GetParticipatnFreeDrugReportRNQL = MyParentReport.Outher.rsGroup.GetCurrentRecord<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>(0);
                    STARTDATE1.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.ReportStartDate) : "");
                    ENDDATE1.CalcValue = (dataset_GetParticipatnFreeDrugReportRNQL != null ? Globals.ToStringCore(dataset_GetParticipatnFreeDrugReportRNQL.ReportEndDate) : "");
                    NOTE1.CalcValue = @" Hastanın yukarıda etken madde ismi, kullanım dozu, adedi ve tanıları ile ilgili ilaçlarını .." + MyParentReport.DESCRIPTION.STARTDATE1.FormattedValue + @" -  " + MyParentReport.DESCRIPTION.ENDDATE1.FormattedValue + @".. tarihleri arasında kullanılması gerekmekte olup, hasta katılım payından muaftır.";
                    NewField1119111.CalcValue = NewField1119111.Value;
                    return new TTReportObject[] { STARTDATE1,ENDDATE1,NOTE1,NewField1119111};
                }
            }

        }

        public DESCRIPTIONGroup DESCRIPTION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ParticipatnFreeDrugReportReport()
        {
            Outher = new OutherGroup(this,"Outher");
            MAIN = new MAINGroup(Outher,"MAIN");
            DIAGNOSIS = new DIAGNOSISGroup(Outher,"DIAGNOSIS");
            DRUGBASLIK = new DRUGBASLIKGroup(Outher,"DRUGBASLIK");
            DRUG = new DRUGGroup(Outher,"DRUG");
            DRUGNOTMEDULABASLIK = new DRUGNOTMEDULABASLIKGroup(Outher,"DRUGNOTMEDULABASLIK");
            DRUGNOTMEDULA = new DRUGNOTMEDULAGroup(Outher,"DRUGNOTMEDULA");
            MEDULADESCRIPTION = new MEDULADESCRIPTIONGroup(Outher,"MEDULADESCRIPTION");
            DESCRIPTION = new DESCRIPTIONGroup(Outher,"DESCRIPTION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PARTICIPATNFREEDRUGREPORTREPORT";
            Caption = "Hasta Katılım Payından Muaf İlaç Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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