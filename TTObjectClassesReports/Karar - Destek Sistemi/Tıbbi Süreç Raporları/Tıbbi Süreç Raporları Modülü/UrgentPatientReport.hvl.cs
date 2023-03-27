
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
    /// Acil Hasta Yatış Listesi
    /// </summary>
    public partial class UrgentPatientReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public UrgentPatientReport MyParentReport
            {
                get { return (UrgentPatientReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportShape NewRect11 { get {return Header().NewRect11;} }
            public TTReportShape NewRect111 { get {return Header().NewRect111;} }
            public TTReportShape NewRect1111 { get {return Header().NewRect1111;} }
            public TTReportShape NewRect112 { get {return Header().NewRect112;} }
            public TTReportShape NewRect1211 { get {return Header().NewRect1211;} }
            public TTReportShape NewRect1212 { get {return Header().NewRect1212;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField STATU { get {return Header().STATU;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField AGE_CONST { get {return Header().AGE_CONST;} }
            public TTReportField PATIENTSEX_CONST { get {return Header().PATIENTSEX_CONST;} }
            public TTReportField CLINIC { get {return Header().CLINIC;} }
            public TTReportField DIAGNOSE_CONST { get {return Header().DIAGNOSE_CONST;} }
            public TTReportField DATE_CONST { get {return Header().DATE_CONST;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField DATE_CONST1 { get {return Header().DATE_CONST1;} }
            public TTReportField DATE_CONST2 { get {return Header().DATE_CONST2;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public UrgentPatientReport MyParentReport
                {
                    get { return (UrgentPatientReport)ParentReport; }
                }
                
                public TTReportShape NewRect1;
                public TTReportShape NewRect11;
                public TTReportShape NewRect111;
                public TTReportShape NewRect1111;
                public TTReportShape NewRect112;
                public TTReportShape NewRect1211;
                public TTReportShape NewRect1212;
                public TTReportField DATE;
                public TTReportField NAMESURNAME;
                public TTReportField STATU;
                public TTReportField TCKIMLIKNO;
                public TTReportField AGE_CONST;
                public TTReportField PATIENTSEX_CONST;
                public TTReportField CLINIC;
                public TTReportField DIAGNOSE_CONST;
                public TTReportField DATE_CONST;
                public TTReportField NewField1;
                public TTReportField DATE_CONST1;
                public TTReportField DATE_CONST2;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 62;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 26, 56, 84, 62, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 84, 56, 112, 62, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 112, 56, 147, 62, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 147, 56, 157, 62, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 179, 56, 230, 62, false);
                    NewRect112.Name = "NewRect112";
                    NewRect112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 230, 56, 284, 62, false);
                    NewRect1211.Name = "NewRect1211";
                    NewRect1211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 157, 56, 179, 62, false);
                    NewRect1212.Name = "NewRect1212";
                    NewRect1212.DrawStyle = DrawStyleConstants.vbSolid;

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 50, 102, 55, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.Value = @"{@printdatetime@}";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 57, 64, 62, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.Bold = true;
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"Adı Soyadı";

                    STATU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 57, 136, 62, false);
                    STATU.Name = "STATU";
                    STATU.FillStyle = FillStyleConstants.vbFSTransparent;
                    STATU.TextFont.Name = "Arial";
                    STATU.TextFont.Bold = true;
                    STATU.TextFont.CharSet = 162;
                    STATU.Value = @"Statüsü";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 57, 110, 62, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Bold = true;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"TC Kimlik No";

                    AGE_CONST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 57, 155, 62, false);
                    AGE_CONST.Name = "AGE_CONST";
                    AGE_CONST.FillStyle = FillStyleConstants.vbFSTransparent;
                    AGE_CONST.TextFont.Name = "Arial";
                    AGE_CONST.TextFont.Bold = true;
                    AGE_CONST.TextFont.CharSet = 162;
                    AGE_CONST.Value = @"Yaş";

                    PATIENTSEX_CONST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 57, 175, 62, false);
                    PATIENTSEX_CONST.Name = "PATIENTSEX_CONST";
                    PATIENTSEX_CONST.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTSEX_CONST.TextFont.Name = "Arial";
                    PATIENTSEX_CONST.TextFont.Bold = true;
                    PATIENTSEX_CONST.TextFont.CharSet = 162;
                    PATIENTSEX_CONST.Value = @"Cinsiyet";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 57, 215, 62, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.FillStyle = FillStyleConstants.vbFSTransparent;
                    CLINIC.TextFont.Name = "Arial";
                    CLINIC.TextFont.Bold = true;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"Yattığı Klinik";

                    DIAGNOSE_CONST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 57, 261, 62, false);
                    DIAGNOSE_CONST.Name = "DIAGNOSE_CONST";
                    DIAGNOSE_CONST.FillStyle = FillStyleConstants.vbFSTransparent;
                    DIAGNOSE_CONST.TextFont.Name = "Arial";
                    DIAGNOSE_CONST.TextFont.Bold = true;
                    DIAGNOSE_CONST.TextFont.CharSet = 162;
                    DIAGNOSE_CONST.Value = @"Tanısı";

                    DATE_CONST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 50, 55, 55, false);
                    DATE_CONST.Name = "DATE_CONST";
                    DATE_CONST.TextFont.Name = "Arial";
                    DATE_CONST.TextFont.Bold = true;
                    DATE_CONST.TextFont.CharSet = 162;
                    DATE_CONST.Value = @"Rapor Tarihi      :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 28, 205, 36, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 14;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"ACİL HASTA YATIŞ LİSTESİ";

                    DATE_CONST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 45, 55, 50, false);
                    DATE_CONST1.Name = "DATE_CONST1";
                    DATE_CONST1.TextFont.Name = "Arial";
                    DATE_CONST1.TextFont.Bold = true;
                    DATE_CONST1.TextFont.CharSet = 162;
                    DATE_CONST1.Value = @"Bitiş Tarihi         :";

                    DATE_CONST2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 40, 55, 45, false);
                    DATE_CONST2.Name = "DATE_CONST2";
                    DATE_CONST2.TextFont.Name = "Arial";
                    DATE_CONST2.TextFont.Bold = true;
                    DATE_CONST2.TextFont.CharSet = 162;
                    DATE_CONST2.Value = @"Başlangıç Tarihi:";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 40, 102, 45, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 45, 102, 50, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DATE.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    NAMESURNAME.CalcValue = NAMESURNAME.Value;
                    STATU.CalcValue = STATU.Value;
                    TCKIMLIKNO.CalcValue = TCKIMLIKNO.Value;
                    AGE_CONST.CalcValue = AGE_CONST.Value;
                    PATIENTSEX_CONST.CalcValue = PATIENTSEX_CONST.Value;
                    CLINIC.CalcValue = CLINIC.Value;
                    DIAGNOSE_CONST.CalcValue = DIAGNOSE_CONST.Value;
                    DATE_CONST.CalcValue = DATE_CONST.Value;
                    NewField1.CalcValue = NewField1.Value;
                    DATE_CONST1.CalcValue = DATE_CONST1.Value;
                    DATE_CONST2.CalcValue = DATE_CONST2.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { DATE,NAMESURNAME,STATU,TCKIMLIKNO,AGE_CONST,PATIENTSEX_CONST,CLINIC,DIAGNOSE_CONST,DATE_CONST,NewField1,DATE_CONST1,DATE_CONST2,STARTDATE,ENDDATE};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public UrgentPatientReport MyParentReport
                {
                    get { return (UrgentPatientReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public UrgentPatientReport MyParentReport
            {
                get { return (UrgentPatientReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField REFNO { get {return Body().REFNO;} }
            public TTReportField RES { get {return Body().RES;} }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportShape NewRect11 { get {return Body().NewRect11;} }
            public TTReportShape NewRect111 { get {return Body().NewRect111;} }
            public TTReportShape NewRect1111 { get {return Body().NewRect1111;} }
            public TTReportShape NewRect1112 { get {return Body().NewRect1112;} }
            public TTReportShape NewRect1113 { get {return Body().NewRect1113;} }
            public TTReportShape NewRect13111 { get {return Body().NewRect13111;} }
            public TTReportField PATIENTSEX { get {return Body().PATIENTSEX;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportShape NewRect12111 { get {return Body().NewRect12111;} }
            public TTReportField NUM { get {return Body().NUM;} }
            public TTReportField DIAGNOSE { get {return Body().DIAGNOSE;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetUrgentPatientListByDate_Class>("GetUrgentPatientListByDate", InpatientAdmission.GetUrgentPatientListByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public UrgentPatientReport MyParentReport
                {
                    get { return (UrgentPatientReport)ParentReport; }
                }
                
                public TTReportField PATIENTNAME;
                public TTReportField REFNO;
                public TTReportField RES;
                public TTReportShape NewRect1;
                public TTReportShape NewRect11;
                public TTReportShape NewRect111;
                public TTReportShape NewRect1111;
                public TTReportShape NewRect1112;
                public TTReportShape NewRect1113;
                public TTReportShape NewRect13111;
                public TTReportField PATIENTSEX;
                public TTReportField BIRTHDATE;
                public TTReportField AGE;
                public TTReportShape NewRect12111;
                public TTReportField NUM;
                public TTReportField DIAGNOSE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 53;
                    RepeatCount = 0;
                    
                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 84, 5, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PATIENTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTNAME.Value = @"{#NAME#} {#SURNAME#}";

                    REFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 112, 5, false);
                    REFNO.Name = "REFNO";
                    REFNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    REFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REFNO.Value = @"{#REFNO#}";

                    RES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 230, 5, false);
                    RES.Name = "RES";
                    RES.FillStyle = FillStyleConstants.vbFSTransparent;
                    RES.FieldType = ReportFieldTypeEnum.ftVariable;
                    RES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RES.Value = @"{#RES#}";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 26, 0, 84, 5, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 84, 0, 112, 5, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect11.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 112, 0, 147, 5, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect111.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 179, 0, 230, 5, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1111.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 230, 0, 284, 5, false);
                    NewRect1112.Name = "NewRect1112";
                    NewRect1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1112.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 147, 0, 157, 5, false);
                    NewRect1113.Name = "NewRect1113";
                    NewRect1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1113.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect13111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 157, 0, 179, 5, false);
                    NewRect13111.Name = "NewRect13111";
                    NewRect13111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect13111.FillStyle = FillStyleConstants.vbFSTransparent;

                    PATIENTSEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 178, 5, false);
                    PATIENTSEX.Name = "PATIENTSEX";
                    PATIENTSEX.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTSEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSEX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PATIENTSEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTSEX.ObjectDefName = "SexEnum";
                    PATIENTSEX.DataMember = "DISPLAYTEXT";
                    PATIENTSEX.Value = @"{#SEX#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 3, 345, 8, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.Visible = EvetHayirEnum.ehHayir;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"General Date";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{#BIRTHDATE#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 156, 5, false);
                    AGE.Name = "AGE";
                    AGE.FillStyle = FillStyleConstants.vbFSTransparent;
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AGE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGE.Value = @"";

                    NewRect12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 18, 0, 26, 5, false);
                    NewRect12111.Name = "NewRect12111";
                    NewRect12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect12111.FillStyle = FillStyleConstants.vbFSTransparent;

                    NUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 25, 5, false);
                    NUM.Name = "NUM";
                    NUM.FillStyle = FillStyleConstants.vbFSTransparent;
                    NUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NUM.Value = @"{@counter@}";

                    DIAGNOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 284, 5, false);
                    DIAGNOSE.Name = "DIAGNOSE";
                    DIAGNOSE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DIAGNOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIAGNOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSE.Value = @"{#DIAGNOSE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetUrgentPatientListByDate_Class dataset_GetUrgentPatientListByDate = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetUrgentPatientListByDate_Class>(0);
                    PATIENTNAME.CalcValue = (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.Name) : "") + @" " + (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.Surname) : "");
                    REFNO.CalcValue = (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.Refno) : "");
                    RES.CalcValue = (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.Res) : "");
                    PATIENTSEX.CalcValue = (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.Sex) : "");
                    PATIENTSEX.PostFieldValueCalculation();
                    BIRTHDATE.CalcValue = (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.BirthDate) : "");
                    AGE.CalcValue = @"";
                    NUM.CalcValue = ParentGroup.Counter.ToString();
                    DIAGNOSE.CalcValue = (dataset_GetUrgentPatientListByDate != null ? Globals.ToStringCore(dataset_GetUrgentPatientListByDate.Diagnose) : "");
                    return new TTReportObject[] { PATIENTNAME,REFNO,RES,PATIENTSEX,BIRTHDATE,AGE,NUM,DIAGNOSE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    int patientAge = DateTime.Now.Year - DateTime.ParseExact(this.BIRTHDATE.CalcValue,"dd/MM/yyyy HH:mm:ss", null).Year;
                                                this.AGE.CalcValue = patientAge.ToString();
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

        public UrgentPatientReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "URGENTPATIENTREPORT";
            Caption = "Acil Hasta Yatış Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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