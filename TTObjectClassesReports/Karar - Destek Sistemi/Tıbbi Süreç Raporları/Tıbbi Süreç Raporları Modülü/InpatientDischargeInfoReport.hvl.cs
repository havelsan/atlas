
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
    /// Taburcu Belgesi
    /// </summary>
    public partial class InpatientDischargeInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public InpatientDischargeInfoReport MyParentReport
            {
                get { return (InpatientDischargeInfoReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public InpatientDischargeInfoReport MyParentReport
                {
                    get { return (InpatientDischargeInfoReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 203, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + "" HASTA ÇIKIŞ BELGESİ"";";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + " HASTA ÇIKIŞ BELGESİ";;
                    return new TTReportObject[] { XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public InpatientDischargeInfoReport MyParentReport
                {
                    get { return (InpatientDischargeInfoReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class InpatientDischargeInfoGroup : TTReportGroup
        {
            public InpatientDischargeInfoReport MyParentReport
            {
                get { return (InpatientDischargeInfoReport)ParentReport; }
            }

            new public InpatientDischargeInfoGroupHeader Header()
            {
                return (InpatientDischargeInfoGroupHeader)_header;
            }

            new public InpatientDischargeInfoGroupFooter Footer()
            {
                return (InpatientDischargeInfoGroupFooter)_footer;
            }

            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField TOWNOFBIRTH { get {return Header().TOWNOFBIRTH;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField TREATMENTCLINIC { get {return Header().TREATMENTCLINIC;} }
            public TTReportField QUARANTINEINPATIENTDATE { get {return Header().QUARANTINEINPATIENTDATE;} }
            public TTReportField QUARANTINEDISCHARGEDATE { get {return Header().QUARANTINEDISCHARGEDATE;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField labelKimlikNo { get {return Header().labelKimlikNo;} }
            public TTReportField labelNAME { get {return Header().labelNAME;} }
            public TTReportField labelSURNAME { get {return Header().labelSURNAME;} }
            public TTReportField LabelTOWNOFBIRTH { get {return Header().LabelTOWNOFBIRTH;} }
            public TTReportField labelMILITARYUNIT { get {return Header().labelMILITARYUNIT;} }
            public TTReportField labelRANK { get {return Header().labelRANK;} }
            public TTReportField labelQUARANTINEINPATIENTDATE { get {return Header().labelQUARANTINEINPATIENTDATE;} }
            public TTReportField labelFATHERNAME { get {return Header().labelFATHERNAME;} }
            public TTReportField labeleMILITARYOFFICE { get {return Header().labeleMILITARYOFFICE;} }
            public TTReportField labelTREATMENTCLINIC { get {return Header().labelTREATMENTCLINIC;} }
            public TTReportField labelQUARANTINEDISCHARGEDATE { get {return Header().labelQUARANTINEDISCHARGEDATE;} }
            public TTReportField MILITARYOFFICE { get {return Header().MILITARYOFFICE;} }
            public TTReportField lableQUARANTINEPROTOKOLNO { get {return Header().lableQUARANTINEPROTOKOLNO;} }
            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField RANK { get {return Header().RANK;} }
            public TTReportField QPROTOKOLNO { get {return Header().QPROTOKOLNO;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportField lableQUARANTINEPROTOKOLNO1 { get {return Header().lableQUARANTINEPROTOKOLNO1;} }
            public TTReportField QTABURCUNO { get {return Header().QTABURCUNO;} }
            public TTReportField TOWNOFBIRTHANDDATE { get {return Header().TOWNOFBIRTHANDDATE;} }
            public TTReportField DATEOFBIRTH { get {return Header().DATEOFBIRTH;} }
            public TTReportRTF CONCLUSION { get {return Footer().CONCLUSION;} }
            public InpatientDischargeInfoGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public InpatientDischargeInfoGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmission.GetInpatientDischargeInfo_Class>("GetInpatientDischargeInfoNQL", InpatientAdmission.GetInpatientDischargeInfo((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new InpatientDischargeInfoGroupHeader(this);
                _footer = new InpatientDischargeInfoGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class InpatientDischargeInfoGroupHeader : TTReportSection
            {
                public InpatientDischargeInfoReport MyParentReport
                {
                    get { return (InpatientDischargeInfoReport)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField TOWNOFBIRTH;
                public TTReportField UNIQUEREFNO;
                public TTReportField FATHERNAME;
                public TTReportField TREATMENTCLINIC;
                public TTReportField QUARANTINEINPATIENTDATE;
                public TTReportField QUARANTINEDISCHARGEDATE;
                public TTReportField EPISODE;
                public TTReportField labelKimlikNo;
                public TTReportField labelNAME;
                public TTReportField labelSURNAME;
                public TTReportField LabelTOWNOFBIRTH;
                public TTReportField labelMILITARYUNIT;
                public TTReportField labelRANK;
                public TTReportField labelQUARANTINEINPATIENTDATE;
                public TTReportField labelFATHERNAME;
                public TTReportField labeleMILITARYOFFICE;
                public TTReportField labelTREATMENTCLINIC;
                public TTReportField labelQUARANTINEDISCHARGEDATE;
                public TTReportField MILITARYOFFICE;
                public TTReportField lableQUARANTINEPROTOKOLNO;
                public TTReportField MILITARYUNIT;
                public TTReportField RANK;
                public TTReportField QPROTOKOLNO;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportField lableQUARANTINEPROTOKOLNO1;
                public TTReportField QTABURCUNO;
                public TTReportField TOWNOFBIRTHANDDATE;
                public TTReportField DATEOFBIRTH; 
                public InpatientDischargeInfoGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 7, 104, 13, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#NAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 13, 104, 19, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Arial Narrow";
                    SURNAME.TextFont.Size = 9;
                    SURNAME.Value = @"{#SURNAME#}";

                    TOWNOFBIRTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 14, 277, 21, false);
                    TOWNOFBIRTH.Name = "TOWNOFBIRTH";
                    TOWNOFBIRTH.Visible = EvetHayirEnum.ehHayir;
                    TOWNOFBIRTH.DrawStyle = DrawStyleConstants.vbSolid;
                    TOWNOFBIRTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOWNOFBIRTH.TextFont.Name = "Arial Narrow";
                    TOWNOFBIRTH.TextFont.Size = 9;
                    TOWNOFBIRTH.Value = @"{#TOWNOFBIRTH#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 64, 6, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 7, 202, 13, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.TextFont.Size = 9;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    TREATMENTCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 37, 202, 43, false);
                    TREATMENTCLINIC.Name = "TREATMENTCLINIC";
                    TREATMENTCLINIC.DrawStyle = DrawStyleConstants.vbSolid;
                    TREATMENTCLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTCLINIC.TextFont.Name = "Arial Narrow";
                    TREATMENTCLINIC.TextFont.Size = 9;
                    TREATMENTCLINIC.Value = @"{#TREATMENTCLINIC#}";

                    QUARANTINEINPATIENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 43, 104, 49, false);
                    QUARANTINEINPATIENTDATE.Name = "QUARANTINEINPATIENTDATE";
                    QUARANTINEINPATIENTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    QUARANTINEINPATIENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEINPATIENTDATE.TextFormat = @"Short Date";
                    QUARANTINEINPATIENTDATE.TextFont.Name = "Arial Narrow";
                    QUARANTINEINPATIENTDATE.TextFont.Size = 9;
                    QUARANTINEINPATIENTDATE.Value = @"{#HOSPITALINPATIENTDATE#}";

                    QUARANTINEDISCHARGEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 43, 201, 49, false);
                    QUARANTINEDISCHARGEDATE.Name = "QUARANTINEDISCHARGEDATE";
                    QUARANTINEDISCHARGEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    QUARANTINEDISCHARGEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEDISCHARGEDATE.TextFormat = @"Short Date";
                    QUARANTINEDISCHARGEDATE.TextFont.Name = "Arial Narrow";
                    QUARANTINEDISCHARGEDATE.TextFont.Size = 9;
                    QUARANTINEDISCHARGEDATE.Value = @"{#HOSPITALDISCHARGEDATE#}";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 50, 20, 55, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Name = "Arial Narrow";
                    EPISODE.TextFont.Size = 9;
                    EPISODE.Value = @"{#EPISODE#}";

                    labelKimlikNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 22, 6, false);
                    labelKimlikNo.Name = "labelKimlikNo";
                    labelKimlikNo.TextFont.Name = "Arial Narrow";
                    labelKimlikNo.TextFont.Size = 9;
                    labelKimlikNo.TextFont.Bold = true;
                    labelKimlikNo.Value = @"KİMLİK NO:";

                    labelNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 7, 33, 13, false);
                    labelNAME.Name = "labelNAME";
                    labelNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    labelNAME.TextFont.Name = "Arial Narrow";
                    labelNAME.TextFont.Size = 9;
                    labelNAME.TextFont.Bold = true;
                    labelNAME.Value = @"ADI";

                    labelSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 13, 33, 19, false);
                    labelSURNAME.Name = "labelSURNAME";
                    labelSURNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    labelSURNAME.TextFont.Name = "Arial Narrow";
                    labelSURNAME.TextFont.Size = 9;
                    labelSURNAME.TextFont.Bold = true;
                    labelSURNAME.Value = @"SOYADI";

                    LabelTOWNOFBIRTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 13, 142, 19, false);
                    LabelTOWNOFBIRTH.Name = "LabelTOWNOFBIRTH";
                    LabelTOWNOFBIRTH.DrawStyle = DrawStyleConstants.vbSolid;
                    LabelTOWNOFBIRTH.TextFont.Name = "Arial Narrow";
                    LabelTOWNOFBIRTH.TextFont.Size = 9;
                    LabelTOWNOFBIRTH.TextFont.Bold = true;
                    LabelTOWNOFBIRTH.Value = @"DOĞUM YERİ ve TARİHİ";

                    labelMILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 19, 33, 37, false);
                    labelMILITARYUNIT.Name = "labelMILITARYUNIT";
                    labelMILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    labelMILITARYUNIT.TextFont.Name = "Arial Narrow";
                    labelMILITARYUNIT.TextFont.Size = 9;
                    labelMILITARYUNIT.TextFont.Bold = true;
                    labelMILITARYUNIT.Value = @"BİRLİĞİ";

                    labelRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 37, 33, 43, false);
                    labelRANK.Name = "labelRANK";
                    labelRANK.DrawStyle = DrawStyleConstants.vbSolid;
                    labelRANK.TextFont.Name = "Arial Narrow";
                    labelRANK.TextFont.Size = 9;
                    labelRANK.TextFont.Bold = true;
                    labelRANK.Value = @"SINIF ve RÜTBESİ";

                    labelQUARANTINEINPATIENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 43, 33, 49, false);
                    labelQUARANTINEINPATIENTDATE.Name = "labelQUARANTINEINPATIENTDATE";
                    labelQUARANTINEINPATIENTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    labelQUARANTINEINPATIENTDATE.TextFont.Name = "Arial Narrow";
                    labelQUARANTINEINPATIENTDATE.TextFont.Size = 9;
                    labelQUARANTINEINPATIENTDATE.TextFont.Bold = true;
                    labelQUARANTINEINPATIENTDATE.Value = @"YATIŞ TARİHİ";

                    labelFATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 7, 142, 13, false);
                    labelFATHERNAME.Name = "labelFATHERNAME";
                    labelFATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    labelFATHERNAME.TextFont.Name = "Arial Narrow";
                    labelFATHERNAME.TextFont.Size = 9;
                    labelFATHERNAME.TextFont.Bold = true;
                    labelFATHERNAME.Value = @"BABA ADI";

                    labeleMILITARYOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 19, 142, 31, false);
                    labeleMILITARYOFFICE.Name = "labeleMILITARYOFFICE";
                    labeleMILITARYOFFICE.DrawStyle = DrawStyleConstants.vbSolid;
                    labeleMILITARYOFFICE.TextFont.Name = "Arial Narrow";
                    labeleMILITARYOFFICE.TextFont.Size = 9;
                    labeleMILITARYOFFICE.TextFont.Bold = true;
                    labeleMILITARYOFFICE.Value = @"XXXXXXLİK ŞUBESİ";

                    labelTREATMENTCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 37, 142, 43, false);
                    labelTREATMENTCLINIC.Name = "labelTREATMENTCLINIC";
                    labelTREATMENTCLINIC.DrawStyle = DrawStyleConstants.vbSolid;
                    labelTREATMENTCLINIC.TextFont.Name = "Arial Narrow";
                    labelTREATMENTCLINIC.TextFont.Size = 9;
                    labelTREATMENTCLINIC.TextFont.Bold = true;
                    labelTREATMENTCLINIC.Value = @"YATTIĞI KLİNİK";

                    labelQUARANTINEDISCHARGEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 43, 142, 49, false);
                    labelQUARANTINEDISCHARGEDATE.Name = "labelQUARANTINEDISCHARGEDATE";
                    labelQUARANTINEDISCHARGEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    labelQUARANTINEDISCHARGEDATE.TextFont.Name = "Arial Narrow";
                    labelQUARANTINEDISCHARGEDATE.TextFont.Size = 9;
                    labelQUARANTINEDISCHARGEDATE.TextFont.Bold = true;
                    labelQUARANTINEDISCHARGEDATE.Value = @"ÇIKIŞ TARİHİ";

                    MILITARYOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 19, 202, 31, false);
                    MILITARYOFFICE.Name = "MILITARYOFFICE";
                    MILITARYOFFICE.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYOFFICE.TextFont.Name = "Arial Narrow";
                    MILITARYOFFICE.TextFont.Size = 8;
                    MILITARYOFFICE.Value = @"";

                    lableQUARANTINEPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 1, 104, 6, false);
                    lableQUARANTINEPROTOKOLNO.Name = "lableQUARANTINEPROTOKOLNO";
                    lableQUARANTINEPROTOKOLNO.TextFont.Name = "Arial Narrow";
                    lableQUARANTINEPROTOKOLNO.TextFont.Size = 9;
                    lableQUARANTINEPROTOKOLNO.TextFont.Bold = true;
                    lableQUARANTINEPROTOKOLNO.Value = @"TIBBI KAYIT PROTOKOL NO:";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 19, 104, 37, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial Narrow";
                    MILITARYUNIT.TextFont.Size = 8;
                    MILITARYUNIT.Value = @"";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 37, 104, 43, false);
                    RANK.Name = "RANK";
                    RANK.DrawStyle = DrawStyleConstants.vbSolid;
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.TextFont.Name = "Arial Narrow";
                    RANK.TextFont.Size = 9;
                    RANK.Value = @"";

                    QPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 1, 141, 6, false);
                    QPROTOKOLNO.Name = "QPROTOKOLNO";
                    QPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QPROTOKOLNO.TextFont.Name = "Arial Narrow";
                    QPROTOKOLNO.TextFont.Size = 9;
                    QPROTOKOLNO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 202, 7, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 49, 202, 49, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 202, 7, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 13, 6, 47, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 13, 6, 48, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 13, 202, 48, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    lableQUARANTINEPROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 163, 6, false);
                    lableQUARANTINEPROTOKOLNO1.Name = "lableQUARANTINEPROTOKOLNO1";
                    lableQUARANTINEPROTOKOLNO1.TextFont.Name = "Arial Narrow";
                    lableQUARANTINEPROTOKOLNO1.TextFont.Size = 9;
                    lableQUARANTINEPROTOKOLNO1.TextFont.Bold = true;
                    lableQUARANTINEPROTOKOLNO1.Value = @"TABURCU NO:";

                    QTABURCUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 1, 202, 6, false);
                    QTABURCUNO.Name = "QTABURCUNO";
                    QTABURCUNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QTABURCUNO.TextFont.Name = "Arial Narrow";
                    QTABURCUNO.TextFont.Size = 9;
                    QTABURCUNO.Value = @"{#DISCHARGENUMBER#}";

                    TOWNOFBIRTHANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 13, 202, 19, false);
                    TOWNOFBIRTHANDDATE.Name = "TOWNOFBIRTHANDDATE";
                    TOWNOFBIRTHANDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOWNOFBIRTHANDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOWNOFBIRTHANDDATE.TextFont.Name = "Arial Narrow";
                    TOWNOFBIRTHANDDATE.TextFont.Size = 9;
                    TOWNOFBIRTHANDDATE.Value = @"{%TOWNOFBIRTH%} {%DATEOFBIRTH%}";

                    DATEOFBIRTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 21, 277, 28, false);
                    DATEOFBIRTH.Name = "DATEOFBIRTH";
                    DATEOFBIRTH.Visible = EvetHayirEnum.ehHayir;
                    DATEOFBIRTH.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEOFBIRTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEOFBIRTH.TextFormat = @"dd/MM/yyyy";
                    DATEOFBIRTH.TextFont.Name = "Arial Narrow";
                    DATEOFBIRTH.TextFont.Size = 9;
                    DATEOFBIRTH.Value = @"{#BIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientDischargeInfo_Class dataset_GetInpatientDischargeInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientDischargeInfo_Class>(0);
                    NAME.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.Name) : "");
                    SURNAME.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.Surname) : "");
                    TOWNOFBIRTH.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.Townofbirth) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.UniqueRefNo) : "");
                    FATHERNAME.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.FatherName) : "");
                    TREATMENTCLINIC.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.Treatmentclinic) : "");
                    QUARANTINEINPATIENTDATE.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.HospitalInPatientDate) : "");
                    QUARANTINEDISCHARGEDATE.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.HospitalDischargeDate) : "");
                    EPISODE.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.Episode) : "");
                    labelKimlikNo.CalcValue = labelKimlikNo.Value;
                    labelNAME.CalcValue = labelNAME.Value;
                    labelSURNAME.CalcValue = labelSURNAME.Value;
                    LabelTOWNOFBIRTH.CalcValue = LabelTOWNOFBIRTH.Value;
                    labelMILITARYUNIT.CalcValue = labelMILITARYUNIT.Value;
                    labelRANK.CalcValue = labelRANK.Value;
                    labelQUARANTINEINPATIENTDATE.CalcValue = labelQUARANTINEINPATIENTDATE.Value;
                    labelFATHERNAME.CalcValue = labelFATHERNAME.Value;
                    labeleMILITARYOFFICE.CalcValue = labeleMILITARYOFFICE.Value;
                    labelTREATMENTCLINIC.CalcValue = labelTREATMENTCLINIC.Value;
                    labelQUARANTINEDISCHARGEDATE.CalcValue = labelQUARANTINEDISCHARGEDATE.Value;
                    MILITARYOFFICE.CalcValue = @"";
                    lableQUARANTINEPROTOKOLNO.CalcValue = lableQUARANTINEPROTOKOLNO.Value;
                    MILITARYUNIT.CalcValue = @"";
                    RANK.CalcValue = @"";
                    QPROTOKOLNO.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.QuarantineProtocolNo) : "");
                    lableQUARANTINEPROTOKOLNO1.CalcValue = lableQUARANTINEPROTOKOLNO1.Value;
                    QTABURCUNO.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.DischargeNumber) : "");
                    DATEOFBIRTH.CalcValue = (dataset_GetInpatientDischargeInfoNQL != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfoNQL.BirthDate) : "");
                    TOWNOFBIRTHANDDATE.CalcValue = MyParentReport.InpatientDischargeInfo.TOWNOFBIRTH.CalcValue + @" " + MyParentReport.InpatientDischargeInfo.DATEOFBIRTH.FormattedValue;
                    return new TTReportObject[] { NAME,SURNAME,TOWNOFBIRTH,UNIQUEREFNO,FATHERNAME,TREATMENTCLINIC,QUARANTINEINPATIENTDATE,QUARANTINEDISCHARGEDATE,EPISODE,labelKimlikNo,labelNAME,labelSURNAME,LabelTOWNOFBIRTH,labelMILITARYUNIT,labelRANK,labelQUARANTINEINPATIENTDATE,labelFATHERNAME,labeleMILITARYOFFICE,labelTREATMENTCLINIC,labelQUARANTINEDISCHARGEDATE,MILITARYOFFICE,lableQUARANTINEPROTOKOLNO,MILITARYUNIT,RANK,QPROTOKOLNO,lableQUARANTINEPROTOKOLNO1,QTABURCUNO,DATEOFBIRTH,TOWNOFBIRTHANDDATE};
                }
            }
            public partial class InpatientDischargeInfoGroupFooter : TTReportSection
            {
                public InpatientDischargeInfoReport MyParentReport
                {
                    get { return (InpatientDischargeInfoReport)ParentReport; }
                }
                
                public TTReportRTF CONCLUSION; 
                public InpatientDischargeInfoGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    CONCLUSION = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 6, 0, 202, 7, false);
                    CONCLUSION.Name = "CONCLUSION";
                    CONCLUSION.DrawStyle = DrawStyleConstants.vbSolid;
                    CONCLUSION.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientDischargeInfo_Class dataset_GetInpatientDischargeInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientDischargeInfo_Class>(0);
                    CONCLUSION.CalcValue = CONCLUSION.Value;
                    return new TTReportObject[] { CONCLUSION};
                }
                public override void RunPreScript()
                {
#region INPATIENTDISCHARGEINFO FOOTER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((InpatientDischargeInfoReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InpatientAdmission inpatientAdmission = (InpatientAdmission)context.GetObject(new Guid(sObjectID),"InpatientAdmission");
            this.CONCLUSION.Value = TTObjectClasses.Common.GetRTFOfTextString("SONUÇ \r\n" + TTObjectClasses.Common.GetTextOfRTFString(inpatientAdmission.GetDischargedConclusion()));
#endregion INPATIENTDISCHARGEINFO FOOTER_PreScript
                }
            }

        }

        public InpatientDischargeInfoGroup InpatientDischargeInfo;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientDischargeInfoReport MyParentReport
            {
                get { return (InpatientDischargeInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField LableDIAGNOSIS { get {return Body().LableDIAGNOSIS;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField CODE { get {return Body().CODE;} }
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
                list[0] = new TTReportNqlData<DiagnosisGrid.GetMainDiagnosisByEpisode_Class>("GetMainDiagnosisByEpisode", DiagnosisGrid.GetMainDiagnosisByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.InpatientDischargeInfo.EPISODE.CalcValue)));
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
                public InpatientDischargeInfoReport MyParentReport
                {
                    get { return (InpatientDischargeInfoReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField LableDIAGNOSIS;
                public TTReportShape NewLine2;
                public TTReportField NAME;
                public TTReportField CODE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 202, 7, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 9;
                    TANI.Value = @"";

                    LableDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 33, 7, false);
                    LableDIAGNOSIS.Name = "LableDIAGNOSIS";
                    LableDIAGNOSIS.DrawStyle = DrawStyleConstants.vbSolid;
                    LableDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    LableDIAGNOSIS.TextFont.Size = 9;
                    LableDIAGNOSIS.TextFont.Bold = true;
                    LableDIAGNOSIS.Value = @"TANI";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 202, 7, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 237, 4, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#NAME#}";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 4, 237, 8, false);
                    CODE.Name = "CODE";
                    CODE.Visible = EvetHayirEnum.ehHayir;
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.Size = 8;
                    CODE.Value = @"{#CODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetMainDiagnosisByEpisode_Class dataset_GetMainDiagnosisByEpisode = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetMainDiagnosisByEpisode_Class>(0);
                    TANI.CalcValue = @"";
                    LableDIAGNOSIS.CalcValue = LableDIAGNOSIS.Value;
                    NAME.CalcValue = (dataset_GetMainDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetMainDiagnosisByEpisode.Name) : "");
                    CODE.CalcValue = (dataset_GetMainDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetMainDiagnosisByEpisode.Code) : "");
                    return new TTReportObject[] { TANI,LableDIAGNOSIS,NAME,CODE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.TANI.CalcValue = "" + this.CODE.CalcValue + " - " + this.NAME.CalcValue + "";
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

        public InpatientDischargeInfoReport()
        {
            Header = new HeaderGroup(this,"Header");
            InpatientDischargeInfo = new InpatientDischargeInfoGroup(Header,"InpatientDischargeInfo");
            MAIN = new MAINGroup(InpatientDischargeInfo,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hasta Yatış", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INPATIENTDISCHARGEINFOREPORT";
            Caption = "Taburcu Belgesi";
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 11;
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