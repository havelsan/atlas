
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
    /// Teslim Tesellüm Belgesi
    /// </summary>
    public partial class InpatientAdmissionGivenAndTakenMaterialReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public QuarantineProcessTypeEnum? PROCESSTYPE = (QuarantineProcessTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["QuarantineProcessTypeEnum"].ConvertValue("1");
        }

        public partial class ReportHeaderGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public ReportHeaderGroupHeader Header()
            {
                return (ReportHeaderGroupHeader)_header;
            }

            new public ReportHeaderGroupFooter Footer()
            {
                return (ReportHeaderGroupFooter)_footer;
            }

            public TTReportField REPORTHEADER { get {return Header().REPORTHEADER;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField lablePROESSTYPE { get {return Header().lablePROESSTYPE;} }
            public TTReportField NewField61 { get {return Header().NewField61;} }
            public TTReportField PROESSTYPE { get {return Header().PROESSTYPE;} }
            public TTReportField lableNAME { get {return Header().lableNAME;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField lableTratmentClinic { get {return Header().lableTratmentClinic;} }
            public TTReportField NewField62 { get {return Header().NewField62;} }
            public TTReportField TREATMENTCLINIC { get {return Header().TREATMENTCLINIC;} }
            public TTReportField lablePROTNO { get {return Header().lablePROTNO;} }
            public TTReportField NewField63 { get {return Header().NewField63;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField lableACTIONID { get {return Header().lableACTIONID;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField lableWHOGIVE1 { get {return Footer().lableWHOGIVE1;} }
            public TTReportField PERSONWHOTAKEMATERIALS1 { get {return Footer().PERSONWHOTAKEMATERIALS1;} }
            public TTReportField monPERSONWHOGIVEMATERIALSSING1 { get {return Footer().monPERSONWHOGIVEMATERIALSSING1;} }
            public TTReportField monPERSONWHOTakeMATERIALSSING1 { get {return Footer().monPERSONWHOTakeMATERIALSSING1;} }
            public ReportHeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ReportHeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmission.GetInpatientDischargeInfo_Class>("GetInpatientDischargeInfo", InpatientAdmission.GetInpatientDischargeInfo((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ReportHeaderGroupHeader(this);
                _footer = new ReportHeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ReportHeaderGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField REPORTHEADER;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO;
                public TTReportField lablePROESSTYPE;
                public TTReportField NewField61;
                public TTReportField PROESSTYPE;
                public TTReportField lableNAME;
                public TTReportField NewField16;
                public TTReportField FULLNAME;
                public TTReportField lableTratmentClinic;
                public TTReportField NewField62;
                public TTReportField TREATMENTCLINIC;
                public TTReportField lablePROTNO;
                public TTReportField NewField63;
                public TTReportField PROTOKOLNO;
                public TTReportField lableACTIONID;
                public TTReportField NewField26;
                public TTReportField ACTIONID;
                public TTReportField EPISODE; 
                public ReportHeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 33, 206, 39, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.TextFont.Name = "Arial Narrow";
                    REPORTHEADER.TextFont.Size = 15;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.Value = @"TESLİM TESELLÜM BELGESİ";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 206, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.Size = 10;
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"Logo";

                    lablePROESSTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 48, 45, false);
                    lablePROESSTYPE.Name = "lablePROESSTYPE";
                    lablePROESSTYPE.TextFont.Name = "Arial Narrow";
                    lablePROESSTYPE.TextFont.Size = 11;
                    lablePROESSTYPE.TextFont.Bold = true;
                    lablePROESSTYPE.Value = @"İşlem Tipi";

                    NewField61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 40, 50, 45, false);
                    NewField61.Name = "NewField61";
                    NewField61.TextFont.Name = "Arial Narrow";
                    NewField61.TextFont.Size = 11;
                    NewField61.TextFont.Bold = true;
                    NewField61.Value = @":";

                    PROESSTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 40, 206, 45, false);
                    PROESSTYPE.Name = "PROESSTYPE";
                    PROESSTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROESSTYPE.ObjectDefName = "QuarantineProcessTypeEnum";
                    PROESSTYPE.DataMember = "DISPLAYTEXT";
                    PROESSTYPE.TextFont.Name = "Arial Narrow";
                    PROESSTYPE.Value = @"{@PROCESSTYPE@}";

                    lableNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 48, 50, false);
                    lableNAME.Name = "lableNAME";
                    lableNAME.TextFont.Name = "Arial Narrow";
                    lableNAME.TextFont.Size = 11;
                    lableNAME.TextFont.Bold = true;
                    lableNAME.Value = @"Hasta Adı Soyadı";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 45, 50, 50, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 45, 206, 50, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Arial Narrow";
                    FULLNAME.Value = @"{#NAME#} {#SURNAME#}";

                    lableTratmentClinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 50, 48, 55, false);
                    lableTratmentClinic.Name = "lableTratmentClinic";
                    lableTratmentClinic.TextFont.Name = "Arial Narrow";
                    lableTratmentClinic.TextFont.Size = 11;
                    lableTratmentClinic.TextFont.Bold = true;
                    lableTratmentClinic.Value = @"Yatığı Klinik";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 50, 50, 55, false);
                    NewField62.Name = "NewField62";
                    NewField62.TextFont.Name = "Arial Narrow";
                    NewField62.TextFont.Size = 11;
                    NewField62.TextFont.Bold = true;
                    NewField62.Value = @":";

                    TREATMENTCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 50, 206, 55, false);
                    TREATMENTCLINIC.Name = "TREATMENTCLINIC";
                    TREATMENTCLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTCLINIC.TextFont.Name = "Arial Narrow";
                    TREATMENTCLINIC.Value = @"{#TREATMENTCLINIC#}";

                    lablePROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 55, 48, 60, false);
                    lablePROTNO.Name = "lablePROTNO";
                    lablePROTNO.TextFont.Name = "Arial Narrow";
                    lablePROTNO.TextFont.Size = 11;
                    lablePROTNO.TextFont.Bold = true;
                    lablePROTNO.Value = @"Tıbbi Kayıt Protokol No";

                    NewField63 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 55, 50, 60, false);
                    NewField63.Name = "NewField63";
                    NewField63.TextFont.Name = "Arial Narrow";
                    NewField63.TextFont.Size = 11;
                    NewField63.TextFont.Bold = true;
                    NewField63.Value = @":";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 55, 206, 60, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                    lableACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 48, 65, false);
                    lableACTIONID.Name = "lableACTIONID";
                    lableACTIONID.TextFont.Name = "Arial Narrow";
                    lableACTIONID.TextFont.Size = 11;
                    lableACTIONID.TextFont.Bold = true;
                    lableACTIONID.Value = @"İşlem No";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 60, 50, 65, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 11;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @":";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 60, 206, 65, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.ObjectDefName = "InpatientAdmission";
                    ACTIONID.DataMember = "ID";
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.Value = @"{@TTOBJECTID@}";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 41, 372, 46, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Name = "Arial Narrow";
                    EPISODE.Value = @"{#EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientDischargeInfo_Class dataset_GetInpatientDischargeInfo = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientDischargeInfo_Class>(0);
                    REPORTHEADER.CalcValue = REPORTHEADER.Value;
                    LOGO.CalcValue = LOGO.Value;
                    lablePROESSTYPE.CalcValue = lablePROESSTYPE.Value;
                    NewField61.CalcValue = NewField61.Value;
                    PROESSTYPE.CalcValue = MyParentReport.RuntimeParameters.PROCESSTYPE.ToString();
                    PROESSTYPE.PostFieldValueCalculation();
                    lableNAME.CalcValue = lableNAME.Value;
                    NewField16.CalcValue = NewField16.Value;
                    FULLNAME.CalcValue = (dataset_GetInpatientDischargeInfo != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfo.Name) : "") + @" " + (dataset_GetInpatientDischargeInfo != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfo.Surname) : "");
                    lableTratmentClinic.CalcValue = lableTratmentClinic.Value;
                    NewField62.CalcValue = NewField62.Value;
                    TREATMENTCLINIC.CalcValue = (dataset_GetInpatientDischargeInfo != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfo.Treatmentclinic) : "");
                    lablePROTNO.CalcValue = lablePROTNO.Value;
                    NewField63.CalcValue = NewField63.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetInpatientDischargeInfo != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfo.QuarantineProtocolNo) : "");
                    lableACTIONID.CalcValue = lableACTIONID.Value;
                    NewField26.CalcValue = NewField26.Value;
                    ACTIONID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ACTIONID.PostFieldValueCalculation();
                    EPISODE.CalcValue = (dataset_GetInpatientDischargeInfo != null ? Globals.ToStringCore(dataset_GetInpatientDischargeInfo.Episode) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { REPORTHEADER,LOGO,lablePROESSTYPE,NewField61,PROESSTYPE,lableNAME,NewField16,FULLNAME,lableTratmentClinic,NewField62,TREATMENTCLINIC,lablePROTNO,NewField63,PROTOKOLNO,lableACTIONID,NewField26,ACTIONID,EPISODE,XXXXXXBASLIK};
                }
            }
            public partial class ReportHeaderGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber;
                public TTReportField lableWHOGIVE1;
                public TTReportField PERSONWHOTAKEMATERIALS1;
                public TTReportField monPERSONWHOGIVEMATERIALSSING1;
                public TTReportField monPERSONWHOTakeMATERIALSSING1; 
                public ReportHeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 59;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 45, 206, 45, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 51, 207, 56, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 46, 207, 51, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 46, 111, 51, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                    lableWHOGIVE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 74, 7, false);
                    lableWHOGIVE1.Name = "lableWHOGIVE1";
                    lableWHOGIVE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableWHOGIVE1.TextFont.Name = "Arial Narrow";
                    lableWHOGIVE1.TextFont.Size = 11;
                    lableWHOGIVE1.TextFont.Bold = true;
                    lableWHOGIVE1.Value = @"Teslim Eden";

                    PERSONWHOTAKEMATERIALS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 2, 192, 7, false);
                    PERSONWHOTAKEMATERIALS1.Name = "PERSONWHOTAKEMATERIALS1";
                    PERSONWHOTAKEMATERIALS1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTAKEMATERIALS1.TextFont.Name = "Arial Narrow";
                    PERSONWHOTAKEMATERIALS1.TextFont.Size = 11;
                    PERSONWHOTAKEMATERIALS1.TextFont.Bold = true;
                    PERSONWHOTAKEMATERIALS1.Value = @"Teslim Alan";

                    monPERSONWHOGIVEMATERIALSSING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 12, 74, 17, false);
                    monPERSONWHOGIVEMATERIALSSING1.Name = "monPERSONWHOGIVEMATERIALSSING1";
                    monPERSONWHOGIVEMATERIALSSING1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    monPERSONWHOGIVEMATERIALSSING1.TextFont.Name = "Arial Narrow";
                    monPERSONWHOGIVEMATERIALSSING1.TextFont.Size = 11;
                    monPERSONWHOGIVEMATERIALSSING1.TextFont.Bold = true;
                    monPERSONWHOGIVEMATERIALSSING1.Value = @"İmza";

                    monPERSONWHOTakeMATERIALSSING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 12, 192, 17, false);
                    monPERSONWHOTakeMATERIALSSING1.Name = "monPERSONWHOTakeMATERIALSSING1";
                    monPERSONWHOTakeMATERIALSSING1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    monPERSONWHOTakeMATERIALSSING1.TextFont.Name = "Arial Narrow";
                    monPERSONWHOTakeMATERIALSSING1.TextFont.Size = 11;
                    monPERSONWHOTakeMATERIALSSING1.TextFont.Bold = true;
                    monPERSONWHOTakeMATERIALSSING1.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientDischargeInfo_Class dataset_GetInpatientDischargeInfo = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientDischargeInfo_Class>(0);
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    lableWHOGIVE1.CalcValue = lableWHOGIVE1.Value;
                    PERSONWHOTAKEMATERIALS1.CalcValue = PERSONWHOTAKEMATERIALS1.Value;
                    monPERSONWHOGIVEMATERIALSSING1.CalcValue = monPERSONWHOGIVEMATERIALSSING1.Value;
                    monPERSONWHOTakeMATERIALSSING1.CalcValue = monPERSONWHOTakeMATERIALSSING1.Value;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate,PageNumber,lableWHOGIVE1,PERSONWHOTAKEMATERIALS1,monPERSONWHOGIVEMATERIALSSING1,monPERSONWHOTakeMATERIALSSING1,UserName};
                }
            }

        }

        public ReportHeaderGroup ReportHeader;

        public partial class TakenMaterialsGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public TakenMaterialsGroupHeader Header()
            {
                return (TakenMaterialsGroupHeader)_header;
            }

            new public TakenMaterialsGroupFooter Footer()
            {
                return (TakenMaterialsGroupFooter)_footer;
            }

            public TTReportField labelPROCESSDATE { get {return Header().labelPROCESSDATE;} }
            public TTReportField labelMATERIAL { get {return Header().labelMATERIAL;} }
            public TTReportField lableAMOUNT { get {return Header().lableAMOUNT;} }
            public TTReportField TakenMaterials { get {return Header().TakenMaterials;} }
            public TTReportField lableAMOUNT1 { get {return Header().lableAMOUNT1;} }
            public TTReportField lableAMOUNT2 { get {return Header().lableAMOUNT2;} }
            public TTReportField labelPERSONWHOGIVEMATERIALS { get {return Footer().labelPERSONWHOGIVEMATERIALS;} }
            public TTReportField PERSONWHOGIVEMATERIALS { get {return Footer().PERSONWHOGIVEMATERIALS;} }
            public TTReportField labelPERSONWHOTAKEMATERIALS { get {return Footer().labelPERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOTAKEMATERIALS { get {return Footer().PERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOGIVEMATERIALSSING { get {return Footer().PERSONWHOGIVEMATERIALSSING;} }
            public TTReportField PERSONWHOTakeMATERIALSSING { get {return Footer().PERSONWHOTakeMATERIALSSING;} }
            public TakenMaterialsGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TakenMaterialsGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>("GetInpatientAdmissionTakenMaterials", InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.ReportHeader.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TakenMaterialsGroupHeader(this);
                _footer = new TakenMaterialsGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TakenMaterialsGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField labelPROCESSDATE;
                public TTReportField labelMATERIAL;
                public TTReportField lableAMOUNT;
                public TTReportField TakenMaterials;
                public TTReportField lableAMOUNT1;
                public TTReportField lableAMOUNT2; 
                public TakenMaterialsGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    labelPROCESSDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 50, 23, false);
                    labelPROCESSDATE.Name = "labelPROCESSDATE";
                    labelPROCESSDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    labelPROCESSDATE.TextFont.Name = "Arial Narrow";
                    labelPROCESSDATE.TextFont.Size = 11;
                    labelPROCESSDATE.TextFont.Bold = true;
                    labelPROCESSDATE.Value = @"İşlem Tarihi";

                    labelMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 18, 107, 23, false);
                    labelMATERIAL.Name = "labelMATERIAL";
                    labelMATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    labelMATERIAL.TextFont.Name = "Arial Narrow";
                    labelMATERIAL.TextFont.Size = 11;
                    labelMATERIAL.TextFont.Bold = true;
                    labelMATERIAL.Value = @"Alınan Eşya";

                    lableAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 18, 125, 23, false);
                    lableAMOUNT.Name = "lableAMOUNT";
                    lableAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT.TextFont.Name = "Arial Narrow";
                    lableAMOUNT.TextFont.Size = 11;
                    lableAMOUNT.TextFont.Bold = true;
                    lableAMOUNT.Value = @"Miktar";

                    TakenMaterials = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 206, 17, false);
                    TakenMaterials.Name = "TakenMaterials";
                    TakenMaterials.TextFont.Name = "Arial Narrow";
                    TakenMaterials.TextFont.Size = 11;
                    TakenMaterials.TextFont.Bold = true;
                    TakenMaterials.Value = @"Hastadan Alınan Eşyalar";

                    lableAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 18, 161, 23, false);
                    lableAMOUNT1.Name = "lableAMOUNT1";
                    lableAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT1.TextFont.Name = "Arial Narrow";
                    lableAMOUNT1.TextFont.Size = 11;
                    lableAMOUNT1.TextFont.Bold = true;
                    lableAMOUNT1.Value = @"Teslim Eden";

                    lableAMOUNT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 18, 206, 23, false);
                    lableAMOUNT2.Name = "lableAMOUNT2";
                    lableAMOUNT2.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT2.TextFont.Name = "Arial Narrow";
                    lableAMOUNT2.TextFont.Size = 11;
                    lableAMOUNT2.TextFont.Bold = true;
                    lableAMOUNT2.Value = @"Teslim Alan";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class dataset_GetInpatientAdmissionTakenMaterials = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>(0);
                    labelPROCESSDATE.CalcValue = labelPROCESSDATE.Value;
                    labelMATERIAL.CalcValue = labelMATERIAL.Value;
                    lableAMOUNT.CalcValue = lableAMOUNT.Value;
                    TakenMaterials.CalcValue = TakenMaterials.Value;
                    lableAMOUNT1.CalcValue = lableAMOUNT1.Value;
                    lableAMOUNT2.CalcValue = lableAMOUNT2.Value;
                    return new TTReportObject[] { labelPROCESSDATE,labelMATERIAL,lableAMOUNT,TakenMaterials,lableAMOUNT1,lableAMOUNT2};
                }
                public override void RunPreScript()
                {
#region TAKENMATERIALS HEADER_PreScript
                    if( ((InpatientAdmissionGivenAndTakenMaterialReport)ParentReport).RuntimeParameters.PROCESSTYPE.Value==QuarantineProcessTypeEnum.TakedFromPatient)
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehEvet;
            }
            else
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion TAKENMATERIALS HEADER_PreScript
                }
            }
            public partial class TakenMaterialsGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField labelPERSONWHOGIVEMATERIALS;
                public TTReportField PERSONWHOGIVEMATERIALS;
                public TTReportField labelPERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOGIVEMATERIALSSING;
                public TTReportField PERSONWHOTakeMATERIALSSING; 
                public TakenMaterialsGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    labelPERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 3, 76, 8, false);
                    labelPERSONWHOGIVEMATERIALS.Name = "labelPERSONWHOGIVEMATERIALS";
                    labelPERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    labelPERSONWHOGIVEMATERIALS.TextFont.Size = 11;
                    labelPERSONWHOGIVEMATERIALS.TextFont.Bold = true;
                    labelPERSONWHOGIVEMATERIALS.Value = @"Teslim Eden";

                    PERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 76, 13, false);
                    PERSONWHOGIVEMATERIALS.Name = "PERSONWHOGIVEMATERIALS";
                    PERSONWHOGIVEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALS.Value = @"{#TakenMaterials.PERSONWHOGIVEMATERIALS#}";

                    labelPERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 3, 194, 8, false);
                    labelPERSONWHOTAKEMATERIALS.Name = "labelPERSONWHOTAKEMATERIALS";
                    labelPERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    labelPERSONWHOTAKEMATERIALS.TextFont.Size = 11;
                    labelPERSONWHOTAKEMATERIALS.TextFont.Bold = true;
                    labelPERSONWHOTAKEMATERIALS.Value = @"Teslim Alan";

                    PERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 8, 194, 13, false);
                    PERSONWHOTAKEMATERIALS.Name = "PERSONWHOTAKEMATERIALS";
                    PERSONWHOTAKEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOTAKEMATERIALS.Value = @"{#TakenMaterials.PERSONWHOTAKEMATERIALS#}";

                    PERSONWHOGIVEMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 13, 76, 18, false);
                    PERSONWHOGIVEMATERIALSSING.Name = "PERSONWHOGIVEMATERIALSSING";
                    PERSONWHOGIVEMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALSSING.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALSSING.TextFont.Size = 11;
                    PERSONWHOGIVEMATERIALSSING.TextFont.Bold = true;
                    PERSONWHOGIVEMATERIALSSING.Value = @"İmza";

                    PERSONWHOTakeMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 13, 194, 18, false);
                    PERSONWHOTakeMATERIALSSING.Name = "PERSONWHOTakeMATERIALSSING";
                    PERSONWHOTakeMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTakeMATERIALSSING.TextFont.Name = "Arial Narrow";
                    PERSONWHOTakeMATERIALSSING.TextFont.Size = 11;
                    PERSONWHOTakeMATERIALSSING.TextFont.Bold = true;
                    PERSONWHOTakeMATERIALSSING.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class dataset_GetInpatientAdmissionTakenMaterials = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>(0);
                    labelPERSONWHOGIVEMATERIALS.CalcValue = labelPERSONWHOGIVEMATERIALS.Value;
                    PERSONWHOGIVEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.PersonWhoGiveMaterials) : "");
                    labelPERSONWHOTAKEMATERIALS.CalcValue = labelPERSONWHOTAKEMATERIALS.Value;
                    PERSONWHOTAKEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.PersonWhoTakeMaterials) : "");
                    PERSONWHOGIVEMATERIALSSING.CalcValue = PERSONWHOGIVEMATERIALSSING.Value;
                    PERSONWHOTakeMATERIALSSING.CalcValue = PERSONWHOTakeMATERIALSSING.Value;
                    return new TTReportObject[] { labelPERSONWHOGIVEMATERIALS,PERSONWHOGIVEMATERIALS,labelPERSONWHOTAKEMATERIALS,PERSONWHOTAKEMATERIALS,PERSONWHOGIVEMATERIALSSING,PERSONWHOTakeMATERIALSSING};
                }
                public override void RunPreScript()
                {
#region TAKENMATERIALS FOOTER_PreScript
                    if( ((InpatientAdmissionGivenAndTakenMaterialReport)ParentReport).RuntimeParameters.PROCESSTYPE.Value==QuarantineProcessTypeEnum.TakedFromPatient)
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehEvet;
            }
            else
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion TAKENMATERIALS FOOTER_PreScript
                }
            }

        }

        public TakenMaterialsGroup TakenMaterials;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROCESSDATE { get {return Body().PROCESSDATE;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField PWGM { get {return Body().PWGM;} }
            public TTReportField PWTM { get {return Body().PWTM;} }
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

                InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class dataSet_GetInpatientAdmissionTakenMaterials = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>(0);    
                return new object[] {(dataSet_GetInpatientAdmissionTakenMaterials==null ? null : dataSet_GetInpatientAdmissionTakenMaterials.PersonWhoGiveMaterials), (dataSet_GetInpatientAdmissionTakenMaterials==null ? null : dataSet_GetInpatientAdmissionTakenMaterials.PersonWhoTakeMaterials)};
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
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField PROCESSDATE;
                public TTReportField MATERIAL;
                public TTReportField AMOUNT;
                public TTReportField PWGM;
                public TTReportField PWTM; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PROCESSDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 50, 5, false);
                    PROCESSDATE.Name = "PROCESSDATE";
                    PROCESSDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSDATE.TextFormat = @"Short Date";
                    PROCESSDATE.TextFont.Name = "Arial Narrow";
                    PROCESSDATE.Value = @"{#TakenMaterials.PROCESSDATE#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 107, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.TextFont.Name = "Arial Narrow";
                    MATERIAL.Value = @"{#TakenMaterials.MATERIAL#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 125, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.Value = @"{#TakenMaterials.AMOUNT#}";

                    PWGM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 161, 5, false);
                    PWGM.Name = "PWGM";
                    PWGM.DrawStyle = DrawStyleConstants.vbSolid;
                    PWGM.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWGM.TextFont.Name = "Arial Narrow";
                    PWGM.Value = @"{#TakenMaterials.PERSONWHOGIVEMATERIALS#}";

                    PWTM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 206, 5, false);
                    PWTM.Name = "PWTM";
                    PWTM.DrawStyle = DrawStyleConstants.vbSolid;
                    PWTM.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWTM.TextFont.Name = "Arial Narrow";
                    PWTM.Value = @"{#TakenMaterials.PERSONWHOTAKEMATERIALS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class dataset_GetInpatientAdmissionTakenMaterials = MyParentReport.TakenMaterials.rsGroup.GetCurrentRecord<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>(0);
                    PROCESSDATE.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.ProcessDate) : "");
                    MATERIAL.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.Material) : "");
                    AMOUNT.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.Amount) : "");
                    PWGM.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.PersonWhoGiveMaterials) : "");
                    PWTM.CalcValue = (dataset_GetInpatientAdmissionTakenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionTakenMaterials.PersonWhoTakeMaterials) : "");
                    return new TTReportObject[] { PROCESSDATE,MATERIAL,AMOUNT,PWGM,PWTM};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    if( ((InpatientAdmissionGivenAndTakenMaterialReport)ParentReport).RuntimeParameters.PROCESSTYPE.Value==QuarantineProcessTypeEnum.TakedFromPatient)
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehEvet;
            }
            else
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        public partial class GivenMaterialsGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public GivenMaterialsGroupHeader Header()
            {
                return (GivenMaterialsGroupHeader)_header;
            }

            new public GivenMaterialsGroupFooter Footer()
            {
                return (GivenMaterialsGroupFooter)_footer;
            }

            public TTReportField TakenMaterials { get {return Header().TakenMaterials;} }
            public TTReportField labelPROCESSDATE1 { get {return Header().labelPROCESSDATE1;} }
            public TTReportField labelMATERIAL1 { get {return Header().labelMATERIAL1;} }
            public TTReportField lableAMOUNT1 { get {return Header().lableAMOUNT1;} }
            public TTReportField lableAMOUNT11 { get {return Header().lableAMOUNT11;} }
            public TTReportField lableAMOUNT12 { get {return Header().lableAMOUNT12;} }
            public TTReportField lablePERSONWHOGIVEMATERIALS { get {return Footer().lablePERSONWHOGIVEMATERIALS;} }
            public TTReportField PERSONWHOGIVEMATERIALS { get {return Footer().PERSONWHOGIVEMATERIALS;} }
            public TTReportField PERSONWHOGIVEMATERIALSSING { get {return Footer().PERSONWHOGIVEMATERIALSSING;} }
            public TTReportField labelPERSONWHOTAKEMATERIALS { get {return Footer().labelPERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOTAKEMATERIALS { get {return Footer().PERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOTakeMATERIALSSING { get {return Footer().PERSONWHOTakeMATERIALSSING;} }
            public GivenMaterialsGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GivenMaterialsGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>("GetInpatientAdmissionGivenMaterials", InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.ReportHeader.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GivenMaterialsGroupHeader(this);
                _footer = new GivenMaterialsGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class GivenMaterialsGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField TakenMaterials;
                public TTReportField labelPROCESSDATE1;
                public TTReportField labelMATERIAL1;
                public TTReportField lableAMOUNT1;
                public TTReportField lableAMOUNT11;
                public TTReportField lableAMOUNT12; 
                public GivenMaterialsGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TakenMaterials = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 206, 13, false);
                    TakenMaterials.Name = "TakenMaterials";
                    TakenMaterials.TextFont.Name = "Arial Narrow";
                    TakenMaterials.TextFont.Size = 11;
                    TakenMaterials.TextFont.Bold = true;
                    TakenMaterials.Value = @"Hastaya Verilen Eşyalar";

                    labelPROCESSDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 50, 19, false);
                    labelPROCESSDATE1.Name = "labelPROCESSDATE1";
                    labelPROCESSDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    labelPROCESSDATE1.TextFont.Name = "Arial Narrow";
                    labelPROCESSDATE1.TextFont.Size = 11;
                    labelPROCESSDATE1.TextFont.Bold = true;
                    labelPROCESSDATE1.Value = @"İşlem Tarihi";

                    labelMATERIAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 14, 107, 19, false);
                    labelMATERIAL1.Name = "labelMATERIAL1";
                    labelMATERIAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    labelMATERIAL1.TextFont.Name = "Arial Narrow";
                    labelMATERIAL1.TextFont.Size = 11;
                    labelMATERIAL1.TextFont.Bold = true;
                    labelMATERIAL1.Value = @"Verilen Eşya";

                    lableAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 14, 125, 19, false);
                    lableAMOUNT1.Name = "lableAMOUNT1";
                    lableAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT1.TextFont.Name = "Arial Narrow";
                    lableAMOUNT1.TextFont.Size = 11;
                    lableAMOUNT1.TextFont.Bold = true;
                    lableAMOUNT1.Value = @"Miktar";

                    lableAMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 14, 161, 19, false);
                    lableAMOUNT11.Name = "lableAMOUNT11";
                    lableAMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT11.TextFont.Name = "Arial Narrow";
                    lableAMOUNT11.TextFont.Size = 11;
                    lableAMOUNT11.TextFont.Bold = true;
                    lableAMOUNT11.Value = @"Teslim Eden";

                    lableAMOUNT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 14, 206, 19, false);
                    lableAMOUNT12.Name = "lableAMOUNT12";
                    lableAMOUNT12.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT12.TextFont.Name = "Arial Narrow";
                    lableAMOUNT12.TextFont.Size = 11;
                    lableAMOUNT12.TextFont.Bold = true;
                    lableAMOUNT12.Value = @"Teslim Alan";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class dataset_GetInpatientAdmissionGivenMaterials = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>(0);
                    TakenMaterials.CalcValue = TakenMaterials.Value;
                    labelPROCESSDATE1.CalcValue = labelPROCESSDATE1.Value;
                    labelMATERIAL1.CalcValue = labelMATERIAL1.Value;
                    lableAMOUNT1.CalcValue = lableAMOUNT1.Value;
                    lableAMOUNT11.CalcValue = lableAMOUNT11.Value;
                    lableAMOUNT12.CalcValue = lableAMOUNT12.Value;
                    return new TTReportObject[] { TakenMaterials,labelPROCESSDATE1,labelMATERIAL1,lableAMOUNT1,lableAMOUNT11,lableAMOUNT12};
                }
                public override void RunPreScript()
                {
#region GIVENMATERIALS HEADER_PreScript
                    if( ((InpatientAdmissionGivenAndTakenMaterialReport)ParentReport).RuntimeParameters.PROCESSTYPE.Value==QuarantineProcessTypeEnum.GivedToPatient)
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehEvet;
            }
            else
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion GIVENMATERIALS HEADER_PreScript
                }
            }
            public partial class GivenMaterialsGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField lablePERSONWHOGIVEMATERIALS;
                public TTReportField PERSONWHOGIVEMATERIALS;
                public TTReportField PERSONWHOGIVEMATERIALSSING;
                public TTReportField labelPERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOTakeMATERIALSSING; 
                public GivenMaterialsGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    lablePERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 3, 76, 8, false);
                    lablePERSONWHOGIVEMATERIALS.Name = "lablePERSONWHOGIVEMATERIALS";
                    lablePERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lablePERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    lablePERSONWHOGIVEMATERIALS.TextFont.Size = 11;
                    lablePERSONWHOGIVEMATERIALS.TextFont.Bold = true;
                    lablePERSONWHOGIVEMATERIALS.Value = @"Teslim Eden";

                    PERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 76, 13, false);
                    PERSONWHOGIVEMATERIALS.Name = "PERSONWHOGIVEMATERIALS";
                    PERSONWHOGIVEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALS.Value = @"{#GivenMaterials.PERSONWHOGIVEMATERIALS#}";

                    PERSONWHOGIVEMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 13, 76, 18, false);
                    PERSONWHOGIVEMATERIALSSING.Name = "PERSONWHOGIVEMATERIALSSING";
                    PERSONWHOGIVEMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALSSING.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALSSING.TextFont.Size = 11;
                    PERSONWHOGIVEMATERIALSSING.TextFont.Bold = true;
                    PERSONWHOGIVEMATERIALSSING.Value = @"İmza";

                    labelPERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 2, 194, 7, false);
                    labelPERSONWHOTAKEMATERIALS.Name = "labelPERSONWHOTAKEMATERIALS";
                    labelPERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    labelPERSONWHOTAKEMATERIALS.TextFont.Size = 11;
                    labelPERSONWHOTAKEMATERIALS.TextFont.Bold = true;
                    labelPERSONWHOTAKEMATERIALS.Value = @"Teslim Alan";

                    PERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 7, 194, 12, false);
                    PERSONWHOTAKEMATERIALS.Name = "PERSONWHOTAKEMATERIALS";
                    PERSONWHOTAKEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOTAKEMATERIALS.Value = @"{#GivenMaterials.PERSONWHOTAKEMATERIALS#}";

                    PERSONWHOTakeMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 12, 194, 17, false);
                    PERSONWHOTakeMATERIALSSING.Name = "PERSONWHOTakeMATERIALSSING";
                    PERSONWHOTakeMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTakeMATERIALSSING.TextFont.Name = "Arial Narrow";
                    PERSONWHOTakeMATERIALSSING.TextFont.Size = 11;
                    PERSONWHOTakeMATERIALSSING.TextFont.Bold = true;
                    PERSONWHOTakeMATERIALSSING.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class dataset_GetInpatientAdmissionGivenMaterials = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>(0);
                    lablePERSONWHOGIVEMATERIALS.CalcValue = lablePERSONWHOGIVEMATERIALS.Value;
                    PERSONWHOGIVEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.PersonWhoGiveMaterials) : "");
                    PERSONWHOGIVEMATERIALSSING.CalcValue = PERSONWHOGIVEMATERIALSSING.Value;
                    labelPERSONWHOTAKEMATERIALS.CalcValue = labelPERSONWHOTAKEMATERIALS.Value;
                    PERSONWHOTAKEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.PersonWhoTakeMaterials) : "");
                    PERSONWHOTakeMATERIALSSING.CalcValue = PERSONWHOTakeMATERIALSSING.Value;
                    return new TTReportObject[] { lablePERSONWHOGIVEMATERIALS,PERSONWHOGIVEMATERIALS,PERSONWHOGIVEMATERIALSSING,labelPERSONWHOTAKEMATERIALS,PERSONWHOTAKEMATERIALS,PERSONWHOTakeMATERIALSSING};
                }
                public override void RunPreScript()
                {
#region GIVENMATERIALS FOOTER_PreScript
                    if( ((InpatientAdmissionGivenAndTakenMaterialReport)ParentReport).RuntimeParameters.PROCESSTYPE.Value==QuarantineProcessTypeEnum.GivedToPatient)
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehEvet;
            }
            else
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion GIVENMATERIALS FOOTER_PreScript
                }
            }

        }

        public GivenMaterialsGroup GivenMaterials;

        public partial class GivenMaterialsMainGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public GivenMaterialsMainGroupBody Body()
            {
                return (GivenMaterialsMainGroupBody)_body;
            }
            public TTReportField PROCESSDATE { get {return Body().PROCESSDATE;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField PWGM1 { get {return Body().PWGM1;} }
            public TTReportField PWTM1 { get {return Body().PWTM1;} }
            public GivenMaterialsMainGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GivenMaterialsMainGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class dataSet_GetInpatientAdmissionGivenMaterials = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>(0);    
                return new object[] {(dataSet_GetInpatientAdmissionGivenMaterials==null ? null : dataSet_GetInpatientAdmissionGivenMaterials.PersonWhoGiveMaterials), (dataSet_GetInpatientAdmissionGivenMaterials==null ? null : dataSet_GetInpatientAdmissionGivenMaterials.PersonWhoTakeMaterials)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new GivenMaterialsMainGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class GivenMaterialsMainGroupBody : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField PROCESSDATE;
                public TTReportField MATERIAL;
                public TTReportField AMOUNT;
                public TTReportField PWGM1;
                public TTReportField PWTM1; 
                public GivenMaterialsMainGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PROCESSDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 50, 5, false);
                    PROCESSDATE.Name = "PROCESSDATE";
                    PROCESSDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSDATE.TextFormat = @"Short Date";
                    PROCESSDATE.TextFont.Name = "Arial Narrow";
                    PROCESSDATE.Value = @"{#GivenMaterials.PROCESSDATE#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 107, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.TextFont.Name = "Arial Narrow";
                    MATERIAL.Value = @"{#GivenMaterials.MATERIAL#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 125, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.Value = @"{#GivenMaterials.AMOUNT#}";

                    PWGM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 161, 5, false);
                    PWGM1.Name = "PWGM1";
                    PWGM1.DrawStyle = DrawStyleConstants.vbSolid;
                    PWGM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWGM1.TextFont.Name = "Arial Narrow";
                    PWGM1.Value = @"{#GivenMaterials.PERSONWHOGIVEMATERIALS#}";

                    PWTM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 206, 5, false);
                    PWTM1.Name = "PWTM1";
                    PWTM1.DrawStyle = DrawStyleConstants.vbSolid;
                    PWTM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWTM1.TextFont.Name = "Arial Narrow";
                    PWTM1.Value = @"{#GivenMaterials.PERSONWHOTAKEMATERIALS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class dataset_GetInpatientAdmissionGivenMaterials = MyParentReport.GivenMaterials.rsGroup.GetCurrentRecord<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>(0);
                    PROCESSDATE.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.ProcessDate) : "");
                    MATERIAL.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.Material) : "");
                    AMOUNT.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.Amount) : "");
                    PWGM1.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.PersonWhoGiveMaterials) : "");
                    PWTM1.CalcValue = (dataset_GetInpatientAdmissionGivenMaterials != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionGivenMaterials.PersonWhoTakeMaterials) : "");
                    return new TTReportObject[] { PROCESSDATE,MATERIAL,AMOUNT,PWGM1,PWTM1};
                }
                public override void RunPreScript()
                {
#region GIVENMATERIALSMAIN BODY_PreScript
                    if( ((InpatientAdmissionGivenAndTakenMaterialReport)ParentReport).RuntimeParameters.PROCESSTYPE.Value==QuarantineProcessTypeEnum.GivedToPatient)
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehEvet;
            }
            else
            {
                this.Visible=TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion GIVENMATERIALSMAIN BODY_PreScript
                }
            }

        }

        public GivenMaterialsMainGroup GivenMaterialsMain;

        public partial class VariableMaterialsGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public VariableMaterialsGroupHeader Header()
            {
                return (VariableMaterialsGroupHeader)_header;
            }

            new public VariableMaterialsGroupFooter Footer()
            {
                return (VariableMaterialsGroupFooter)_footer;
            }

            public TTReportField VariableMaterial { get {return Header().VariableMaterial;} }
            public VariableMaterialsGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public VariableMaterialsGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>("GetInpatientAdmissionValuableMaterialsNQL", InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.ReportHeader.EPISODE.CalcValue),((QuarantineProcessTypeEnum)TTObjectDefManager.Instance.DataTypes["QuarantineProcessTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PROCESSTYPE.ToString()].EnumValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new VariableMaterialsGroupHeader(this);
                _footer = new VariableMaterialsGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class VariableMaterialsGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField VariableMaterial; 
                public VariableMaterialsGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    VariableMaterial = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 206, 13, false);
                    VariableMaterial.Name = "VariableMaterial";
                    VariableMaterial.TextFont.Name = "Arial Narrow";
                    VariableMaterial.TextFont.Size = 11;
                    VariableMaterial.TextFont.Bold = true;
                    VariableMaterial.Value = @"Geri Verilmesi Zorunlu Eşyalar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class dataset_GetInpatientAdmissionValuableMaterialsNQL = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(0);
                    VariableMaterial.CalcValue = VariableMaterial.Value;
                    return new TTReportObject[] { VariableMaterial};
                }
            }
            public partial class VariableMaterialsGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                 
                public VariableMaterialsGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public VariableMaterialsGroup VariableMaterials;

        public partial class VariableMaterialsProcessTypeGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public VariableMaterialsProcessTypeGroupHeader Header()
            {
                return (VariableMaterialsProcessTypeGroupHeader)_header;
            }

            new public VariableMaterialsProcessTypeGroupFooter Footer()
            {
                return (VariableMaterialsProcessTypeGroupFooter)_footer;
            }

            public TTReportField labelPROCESSDATE1 { get {return Header().labelPROCESSDATE1;} }
            public TTReportField labelMATERIAL1 { get {return Header().labelMATERIAL1;} }
            public TTReportField lableAMOUNT1 { get {return Header().lableAMOUNT1;} }
            public TTReportField lableAMOUNT11 { get {return Header().lableAMOUNT11;} }
            public TTReportField lableAMOUNT12 { get {return Header().lableAMOUNT12;} }
            public TTReportField lableVPERSONWHOGIVEMATERIALS { get {return Footer().lableVPERSONWHOGIVEMATERIALS;} }
            public TTReportField PERSONWHOGIVEMATERIALS { get {return Footer().PERSONWHOGIVEMATERIALS;} }
            public TTReportField PERSONWHOGIVEMATERIALSSING { get {return Footer().PERSONWHOGIVEMATERIALSSING;} }
            public TTReportField labelPERSONWHOTAKEMATERIALS { get {return Footer().labelPERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOTAKEMATERIALS { get {return Footer().PERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOTakeMATERIALSSING { get {return Footer().PERSONWHOTakeMATERIALSSING;} }
            public VariableMaterialsProcessTypeGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public VariableMaterialsProcessTypeGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class dataSet_GetInpatientAdmissionValuableMaterialsNQL = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(0);    
                return new object[] {(dataSet_GetInpatientAdmissionValuableMaterialsNQL==null ? null : dataSet_GetInpatientAdmissionValuableMaterialsNQL.QuarantineProcessType)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new VariableMaterialsProcessTypeGroupHeader(this);
                _footer = new VariableMaterialsProcessTypeGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class VariableMaterialsProcessTypeGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField labelPROCESSDATE1;
                public TTReportField labelMATERIAL1;
                public TTReportField lableAMOUNT1;
                public TTReportField lableAMOUNT11;
                public TTReportField lableAMOUNT12; 
                public VariableMaterialsProcessTypeGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    labelPROCESSDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 50, 6, false);
                    labelPROCESSDATE1.Name = "labelPROCESSDATE1";
                    labelPROCESSDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    labelPROCESSDATE1.TextFont.Name = "Arial Narrow";
                    labelPROCESSDATE1.TextFont.Size = 11;
                    labelPROCESSDATE1.TextFont.Bold = true;
                    labelPROCESSDATE1.Value = @"İşlem Tarihi";

                    labelMATERIAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 107, 6, false);
                    labelMATERIAL1.Name = "labelMATERIAL1";
                    labelMATERIAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    labelMATERIAL1.TextFont.Name = "Arial Narrow";
                    labelMATERIAL1.TextFont.Size = 11;
                    labelMATERIAL1.TextFont.Bold = true;
                    labelMATERIAL1.Value = @"Eşya";

                    lableAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 125, 6, false);
                    lableAMOUNT1.Name = "lableAMOUNT1";
                    lableAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT1.TextFont.Name = "Arial Narrow";
                    lableAMOUNT1.TextFont.Size = 11;
                    lableAMOUNT1.TextFont.Bold = true;
                    lableAMOUNT1.Value = @"Miktar";

                    lableAMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 1, 161, 6, false);
                    lableAMOUNT11.Name = "lableAMOUNT11";
                    lableAMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT11.TextFont.Name = "Arial Narrow";
                    lableAMOUNT11.TextFont.Size = 11;
                    lableAMOUNT11.TextFont.Bold = true;
                    lableAMOUNT11.Value = @"Teslim Eden";

                    lableAMOUNT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 206, 6, false);
                    lableAMOUNT12.Name = "lableAMOUNT12";
                    lableAMOUNT12.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT12.TextFont.Name = "Arial Narrow";
                    lableAMOUNT12.TextFont.Size = 11;
                    lableAMOUNT12.TextFont.Bold = true;
                    lableAMOUNT12.Value = @"Teslim Alan";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class dataset_GetInpatientAdmissionValuableMaterialsNQL = MyParentReport.VariableMaterials.rsGroup.GetCurrentRecord<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(0);
                    labelPROCESSDATE1.CalcValue = labelPROCESSDATE1.Value;
                    labelMATERIAL1.CalcValue = labelMATERIAL1.Value;
                    lableAMOUNT1.CalcValue = lableAMOUNT1.Value;
                    lableAMOUNT11.CalcValue = lableAMOUNT11.Value;
                    lableAMOUNT12.CalcValue = lableAMOUNT12.Value;
                    return new TTReportObject[] { labelPROCESSDATE1,labelMATERIAL1,lableAMOUNT1,lableAMOUNT11,lableAMOUNT12};
                }
            }
            public partial class VariableMaterialsProcessTypeGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField lableVPERSONWHOGIVEMATERIALS;
                public TTReportField PERSONWHOGIVEMATERIALS;
                public TTReportField PERSONWHOGIVEMATERIALSSING;
                public TTReportField labelPERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOTakeMATERIALSSING; 
                public VariableMaterialsProcessTypeGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    lableVPERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 3, 76, 8, false);
                    lableVPERSONWHOGIVEMATERIALS.Name = "lableVPERSONWHOGIVEMATERIALS";
                    lableVPERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableVPERSONWHOGIVEMATERIALS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lableVPERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    lableVPERSONWHOGIVEMATERIALS.TextFont.Size = 11;
                    lableVPERSONWHOGIVEMATERIALS.TextFont.Bold = true;
                    lableVPERSONWHOGIVEMATERIALS.Value = @"Teslim Eden";

                    PERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 76, 13, false);
                    PERSONWHOGIVEMATERIALS.Name = "PERSONWHOGIVEMATERIALS";
                    PERSONWHOGIVEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALS.Value = @"{#VariableMaterials.PERSONWHOGIVEMATERIALS#}";

                    PERSONWHOGIVEMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 13, 76, 18, false);
                    PERSONWHOGIVEMATERIALSSING.Name = "PERSONWHOGIVEMATERIALSSING";
                    PERSONWHOGIVEMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALSSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONWHOGIVEMATERIALSSING.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALSSING.TextFont.Size = 11;
                    PERSONWHOGIVEMATERIALSSING.TextFont.Bold = true;
                    PERSONWHOGIVEMATERIALSSING.Value = @"İmza";

                    labelPERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 3, 194, 8, false);
                    labelPERSONWHOTAKEMATERIALS.Name = "labelPERSONWHOTAKEMATERIALS";
                    labelPERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPERSONWHOTAKEMATERIALS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelPERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    labelPERSONWHOTAKEMATERIALS.TextFont.Size = 11;
                    labelPERSONWHOTAKEMATERIALS.TextFont.Bold = true;
                    labelPERSONWHOTAKEMATERIALS.Value = @"Teslim Alan";

                    PERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 8, 194, 13, false);
                    PERSONWHOTAKEMATERIALS.Name = "PERSONWHOTAKEMATERIALS";
                    PERSONWHOTAKEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTAKEMATERIALS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOTAKEMATERIALS.Value = @"{#VariableMaterials.PERSONWHOTAKEMATERIALS#}";

                    PERSONWHOTakeMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 13, 194, 18, false);
                    PERSONWHOTakeMATERIALSSING.Name = "PERSONWHOTakeMATERIALSSING";
                    PERSONWHOTakeMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTakeMATERIALSSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONWHOTakeMATERIALSSING.TextFont.Name = "Arial Narrow";
                    PERSONWHOTakeMATERIALSSING.TextFont.Size = 11;
                    PERSONWHOTakeMATERIALSSING.TextFont.Bold = true;
                    PERSONWHOTakeMATERIALSSING.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class dataset_GetInpatientAdmissionValuableMaterialsNQL = MyParentReport.VariableMaterials.rsGroup.GetCurrentRecord<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(0);
                    lableVPERSONWHOGIVEMATERIALS.CalcValue = lableVPERSONWHOGIVEMATERIALS.Value;
                    PERSONWHOGIVEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.PersonWhoGiveMaterials) : "");
                    PERSONWHOGIVEMATERIALSSING.CalcValue = PERSONWHOGIVEMATERIALSSING.Value;
                    labelPERSONWHOTAKEMATERIALS.CalcValue = labelPERSONWHOTAKEMATERIALS.Value;
                    PERSONWHOTAKEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.PersonWhoTakeMaterials) : "");
                    PERSONWHOTakeMATERIALSSING.CalcValue = PERSONWHOTakeMATERIALSSING.Value;
                    return new TTReportObject[] { lableVPERSONWHOGIVEMATERIALS,PERSONWHOGIVEMATERIALS,PERSONWHOGIVEMATERIALSSING,labelPERSONWHOTAKEMATERIALS,PERSONWHOTAKEMATERIALS,PERSONWHOTakeMATERIALSSING};
                }
            }

        }

        public VariableMaterialsProcessTypeGroup VariableMaterialsProcessType;

        public partial class VariableMaterialsMainGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public VariableMaterialsMainGroupBody Body()
            {
                return (VariableMaterialsMainGroupBody)_body;
            }
            public TTReportField PROCESSDATE { get {return Body().PROCESSDATE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField PWGM1 { get {return Body().PWGM1;} }
            public TTReportField PWTM1 { get {return Body().PWTM1;} }
            public VariableMaterialsMainGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public VariableMaterialsMainGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new VariableMaterialsMainGroupBody(this);
            }

            public partial class VariableMaterialsMainGroupBody : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField PROCESSDATE;
                public TTReportField AMOUNT;
                public TTReportField MATERIAL;
                public TTReportField PWGM1;
                public TTReportField PWTM1; 
                public VariableMaterialsMainGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PROCESSDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 50, 5, false);
                    PROCESSDATE.Name = "PROCESSDATE";
                    PROCESSDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSDATE.TextFormat = @"Short Date";
                    PROCESSDATE.TextFont.Name = "Arial Narrow";
                    PROCESSDATE.Value = @"{#VariableMaterials.PROCESSDATE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 125, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.Value = @"{#VariableMaterials.AMOUNT#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 107, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.TextFont.Name = "Arial Narrow";
                    MATERIAL.Value = @"{#VariableMaterials.MATERIAL#}";

                    PWGM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 161, 5, false);
                    PWGM1.Name = "PWGM1";
                    PWGM1.DrawStyle = DrawStyleConstants.vbSolid;
                    PWGM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWGM1.TextFont.Name = "Arial Narrow";
                    PWGM1.Value = @"{#VariableMaterials.PERSONWHOGIVEMATERIALS#}";

                    PWTM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 206, 5, false);
                    PWTM1.Name = "PWTM1";
                    PWTM1.DrawStyle = DrawStyleConstants.vbSolid;
                    PWTM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWTM1.TextFont.Name = "Arial Narrow";
                    PWTM1.Value = @"{#VariableMaterials.PERSONWHOTAKEMATERIALS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class dataset_GetInpatientAdmissionValuableMaterialsNQL = MyParentReport.VariableMaterials.rsGroup.GetCurrentRecord<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(0);
                    PROCESSDATE.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.ProcessDate) : "");
                    AMOUNT.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.Amount) : "");
                    MATERIAL.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.Material) : "");
                    PWGM1.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.PersonWhoGiveMaterials) : "");
                    PWTM1.CalcValue = (dataset_GetInpatientAdmissionValuableMaterialsNQL != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionValuableMaterialsNQL.PersonWhoTakeMaterials) : "");
                    return new TTReportObject[] { PROCESSDATE,AMOUNT,MATERIAL,PWGM1,PWTM1};
                }
            }

        }

        public VariableMaterialsMainGroup VariableMaterialsMain;

        public partial class MoneyGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public MoneyGroupHeader Header()
            {
                return (MoneyGroupHeader)_header;
            }

            new public MoneyGroupFooter Footer()
            {
                return (MoneyGroupFooter)_footer;
            }

            public TTReportField MoneyMaterials { get {return Header().MoneyMaterials;} }
            public MoneyGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MoneyGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>("GetInpatientAdmissionMoney", InpatientAdmissionMoney.GetInpatientAdmissionMoney((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.ReportHeader.EPISODE.CalcValue),((QuarantineProcessTypeEnum)TTObjectDefManager.Instance.DataTypes["QuarantineProcessTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PROCESSTYPE.ToString()].EnumValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MoneyGroupHeader(this);
                _footer = new MoneyGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MoneyGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField MoneyMaterials; 
                public MoneyGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MoneyMaterials = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 206, 14, false);
                    MoneyMaterials.Name = "MoneyMaterials";
                    MoneyMaterials.TextFont.Name = "Arial Narrow";
                    MoneyMaterials.TextFont.Size = 11;
                    MoneyMaterials.TextFont.Bold = true;
                    MoneyMaterials.Value = @"Para";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class dataset_GetInpatientAdmissionMoney = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(0);
                    MoneyMaterials.CalcValue = MoneyMaterials.Value;
                    return new TTReportObject[] { MoneyMaterials};
                }
            }
            public partial class MoneyGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                 
                public MoneyGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MoneyGroup Money;

        public partial class MoneyProcessTypeGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public MoneyProcessTypeGroupHeader Header()
            {
                return (MoneyProcessTypeGroupHeader)_header;
            }

            new public MoneyProcessTypeGroupFooter Footer()
            {
                return (MoneyProcessTypeGroupFooter)_footer;
            }

            public TTReportField PROCESSDATE { get {return Header().PROCESSDATE;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField MONETARYUNIT { get {return Header().MONETARYUNIT;} }
            public TTReportField RECEIPTNO { get {return Header().RECEIPTNO;} }
            public TTReportField lableAMOUNT11 { get {return Header().lableAMOUNT11;} }
            public TTReportField lableAMOUNT12 { get {return Header().lableAMOUNT12;} }
            public TTReportField lableWHOGIVE { get {return Footer().lableWHOGIVE;} }
            public TTReportField PERSONWHOGIVEMATERIALS { get {return Footer().PERSONWHOGIVEMATERIALS;} }
            public TTReportField PERSONWHOTAKEMATERIALS { get {return Footer().PERSONWHOTAKEMATERIALS;} }
            public TTReportField PERSONWHOTAKEMATERIALS2 { get {return Footer().PERSONWHOTAKEMATERIALS2;} }
            public TTReportField monPERSONWHOGIVEMATERIALSSING { get {return Footer().monPERSONWHOGIVEMATERIALSSING;} }
            public TTReportField monPERSONWHOTakeMATERIALSSING { get {return Footer().monPERSONWHOTakeMATERIALSSING;} }
            public MoneyProcessTypeGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MoneyProcessTypeGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class dataSet_GetInpatientAdmissionMoney = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(0);    
                return new object[] {(dataSet_GetInpatientAdmissionMoney==null ? null : dataSet_GetInpatientAdmissionMoney.QuarantineProcessType)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new MoneyProcessTypeGroupHeader(this);
                _footer = new MoneyProcessTypeGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MoneyProcessTypeGroupHeader : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField PROCESSDATE;
                public TTReportField AMOUNT;
                public TTReportField MONETARYUNIT;
                public TTReportField RECEIPTNO;
                public TTReportField lableAMOUNT11;
                public TTReportField lableAMOUNT12; 
                public MoneyProcessTypeGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROCESSDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 50, 6, false);
                    PROCESSDATE.Name = "PROCESSDATE";
                    PROCESSDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSDATE.TextFont.Name = "Arial Narrow";
                    PROCESSDATE.TextFont.Size = 11;
                    PROCESSDATE.TextFont.Bold = true;
                    PROCESSDATE.Value = @"İşlem Tarihi";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 79, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.Size = 11;
                    AMOUNT.TextFont.Bold = true;
                    AMOUNT.Value = @"Miktar";

                    MONETARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 1, 95, 6, false);
                    MONETARYUNIT.Name = "MONETARYUNIT";
                    MONETARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MONETARYUNIT.TextFont.Name = "Arial Narrow";
                    MONETARYUNIT.TextFont.Size = 11;
                    MONETARYUNIT.TextFont.Bold = true;
                    MONETARYUNIT.Value = @"Birimi";

                    RECEIPTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 1, 125, 6, false);
                    RECEIPTNO.Name = "RECEIPTNO";
                    RECEIPTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RECEIPTNO.TextFont.Name = "Arial Narrow";
                    RECEIPTNO.TextFont.Size = 11;
                    RECEIPTNO.TextFont.Bold = true;
                    RECEIPTNO.Value = @"Makbuz No";

                    lableAMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 1, 161, 6, false);
                    lableAMOUNT11.Name = "lableAMOUNT11";
                    lableAMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT11.TextFont.Name = "Arial Narrow";
                    lableAMOUNT11.TextFont.Size = 11;
                    lableAMOUNT11.TextFont.Bold = true;
                    lableAMOUNT11.Value = @"Teslim Eden";

                    lableAMOUNT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 206, 6, false);
                    lableAMOUNT12.Name = "lableAMOUNT12";
                    lableAMOUNT12.DrawStyle = DrawStyleConstants.vbSolid;
                    lableAMOUNT12.TextFont.Name = "Arial Narrow";
                    lableAMOUNT12.TextFont.Size = 11;
                    lableAMOUNT12.TextFont.Bold = true;
                    lableAMOUNT12.Value = @"Teslim Alan";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class dataset_GetInpatientAdmissionMoney = MyParentReport.Money.rsGroup.GetCurrentRecord<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(0);
                    PROCESSDATE.CalcValue = PROCESSDATE.Value;
                    AMOUNT.CalcValue = AMOUNT.Value;
                    MONETARYUNIT.CalcValue = MONETARYUNIT.Value;
                    RECEIPTNO.CalcValue = RECEIPTNO.Value;
                    lableAMOUNT11.CalcValue = lableAMOUNT11.Value;
                    lableAMOUNT12.CalcValue = lableAMOUNT12.Value;
                    return new TTReportObject[] { PROCESSDATE,AMOUNT,MONETARYUNIT,RECEIPTNO,lableAMOUNT11,lableAMOUNT12};
                }
            }
            public partial class MoneyProcessTypeGroupFooter : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField lableWHOGIVE;
                public TTReportField PERSONWHOGIVEMATERIALS;
                public TTReportField PERSONWHOTAKEMATERIALS;
                public TTReportField PERSONWHOTAKEMATERIALS2;
                public TTReportField monPERSONWHOGIVEMATERIALSSING;
                public TTReportField monPERSONWHOTakeMATERIALSSING; 
                public MoneyProcessTypeGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    lableWHOGIVE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 76, 7, false);
                    lableWHOGIVE.Name = "lableWHOGIVE";
                    lableWHOGIVE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableWHOGIVE.TextFont.Name = "Arial Narrow";
                    lableWHOGIVE.TextFont.Size = 11;
                    lableWHOGIVE.TextFont.Bold = true;
                    lableWHOGIVE.Value = @"Teslim Eden";

                    PERSONWHOGIVEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 76, 12, false);
                    PERSONWHOGIVEMATERIALS.Name = "PERSONWHOGIVEMATERIALS";
                    PERSONWHOGIVEMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOGIVEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOGIVEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOGIVEMATERIALS.Value = @"{#Money.PERSONWHOGIVEMATERIALS#}";

                    PERSONWHOTAKEMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 2, 194, 7, false);
                    PERSONWHOTAKEMATERIALS.Name = "PERSONWHOTAKEMATERIALS";
                    PERSONWHOTAKEMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTAKEMATERIALS.TextFont.Name = "Arial Narrow";
                    PERSONWHOTAKEMATERIALS.TextFont.Size = 11;
                    PERSONWHOTAKEMATERIALS.TextFont.Bold = true;
                    PERSONWHOTAKEMATERIALS.Value = @"Teslim Alan";

                    PERSONWHOTAKEMATERIALS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 7, 194, 12, false);
                    PERSONWHOTAKEMATERIALS2.Name = "PERSONWHOTAKEMATERIALS2";
                    PERSONWHOTAKEMATERIALS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONWHOTAKEMATERIALS2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONWHOTAKEMATERIALS2.TextFont.Name = "Arial Narrow";
                    PERSONWHOTAKEMATERIALS2.Value = @"{#Money.PERSONWHOTAKEMATERIALS#}";

                    monPERSONWHOGIVEMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 12, 76, 17, false);
                    monPERSONWHOGIVEMATERIALSSING.Name = "monPERSONWHOGIVEMATERIALSSING";
                    monPERSONWHOGIVEMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    monPERSONWHOGIVEMATERIALSSING.TextFont.Name = "Arial Narrow";
                    monPERSONWHOGIVEMATERIALSSING.TextFont.Size = 11;
                    monPERSONWHOGIVEMATERIALSSING.TextFont.Bold = true;
                    monPERSONWHOGIVEMATERIALSSING.Value = @"İmza";

                    monPERSONWHOTakeMATERIALSSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 12, 194, 17, false);
                    monPERSONWHOTakeMATERIALSSING.Name = "monPERSONWHOTakeMATERIALSSING";
                    monPERSONWHOTakeMATERIALSSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    monPERSONWHOTakeMATERIALSSING.TextFont.Name = "Arial Narrow";
                    monPERSONWHOTakeMATERIALSSING.TextFont.Size = 11;
                    monPERSONWHOTakeMATERIALSSING.TextFont.Bold = true;
                    monPERSONWHOTakeMATERIALSSING.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class dataset_GetInpatientAdmissionMoney = MyParentReport.Money.rsGroup.GetCurrentRecord<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(0);
                    lableWHOGIVE.CalcValue = lableWHOGIVE.Value;
                    PERSONWHOGIVEMATERIALS.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.PersonWhoGiveMaterials) : "");
                    PERSONWHOTAKEMATERIALS.CalcValue = PERSONWHOTAKEMATERIALS.Value;
                    PERSONWHOTAKEMATERIALS2.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.PersonWhoTakeMaterials) : "");
                    monPERSONWHOGIVEMATERIALSSING.CalcValue = monPERSONWHOGIVEMATERIALSSING.Value;
                    monPERSONWHOTakeMATERIALSSING.CalcValue = monPERSONWHOTakeMATERIALSSING.Value;
                    return new TTReportObject[] { lableWHOGIVE,PERSONWHOGIVEMATERIALS,PERSONWHOTAKEMATERIALS,PERSONWHOTAKEMATERIALS2,monPERSONWHOGIVEMATERIALSSING,monPERSONWHOTakeMATERIALSSING};
                }
            }

        }

        public MoneyProcessTypeGroup MoneyProcessType;

        public partial class MoneyMainGroup : TTReportGroup
        {
            public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
            {
                get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
            }

            new public MoneyMainGroupBody Body()
            {
                return (MoneyMainGroupBody)_body;
            }
            public TTReportField PROCESSDATE { get {return Body().PROCESSDATE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField MONETARYUNIT { get {return Body().MONETARYUNIT;} }
            public TTReportField RECEIPTNO { get {return Body().RECEIPTNO;} }
            public TTReportField PWGM1 { get {return Body().PWGM1;} }
            public TTReportField PWTM1 { get {return Body().PWTM1;} }
            public MoneyMainGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MoneyMainGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MoneyMainGroupBody(this);
            }

            public partial class MoneyMainGroupBody : TTReportSection
            {
                public InpatientAdmissionGivenAndTakenMaterialReport MyParentReport
                {
                    get { return (InpatientAdmissionGivenAndTakenMaterialReport)ParentReport; }
                }
                
                public TTReportField PROCESSDATE;
                public TTReportField AMOUNT;
                public TTReportField MONETARYUNIT;
                public TTReportField RECEIPTNO;
                public TTReportField PWGM1;
                public TTReportField PWTM1; 
                public MoneyMainGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PROCESSDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 50, 5, false);
                    PROCESSDATE.Name = "PROCESSDATE";
                    PROCESSDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSDATE.TextFont.Name = "Arial Narrow";
                    PROCESSDATE.Value = @"{#Money.PROCESSDATE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 79, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.Value = @"{#Money.AMOUNT#}";

                    MONETARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 0, 95, 5, false);
                    MONETARYUNIT.Name = "MONETARYUNIT";
                    MONETARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MONETARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONETARYUNIT.TextFont.Name = "Arial Narrow";
                    MONETARYUNIT.Value = @"{#Money.MONETARYUNIT#}";

                    RECEIPTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 125, 5, false);
                    RECEIPTNO.Name = "RECEIPTNO";
                    RECEIPTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RECEIPTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTNO.TextFont.Name = "Arial Narrow";
                    RECEIPTNO.Value = @"{#Money.RECEIPTNO#}";

                    PWGM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 161, 5, false);
                    PWGM1.Name = "PWGM1";
                    PWGM1.DrawStyle = DrawStyleConstants.vbSolid;
                    PWGM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWGM1.TextFont.Name = "Arial Narrow";
                    PWGM1.Value = @"{#Money.PERSONWHOGIVEMATERIALS#}";

                    PWTM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 206, 5, false);
                    PWTM1.Name = "PWTM1";
                    PWTM1.DrawStyle = DrawStyleConstants.vbSolid;
                    PWTM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PWTM1.TextFont.Name = "Arial Narrow";
                    PWTM1.Value = @"{#Money.PERSONWHOTAKEMATERIALS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class dataset_GetInpatientAdmissionMoney = MyParentReport.Money.rsGroup.GetCurrentRecord<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(0);
                    PROCESSDATE.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.ProcessDate) : "");
                    AMOUNT.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.Amount) : "");
                    MONETARYUNIT.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.MonetaryUnit) : "");
                    RECEIPTNO.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.ReceiptNo) : "");
                    PWGM1.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.PersonWhoGiveMaterials) : "");
                    PWTM1.CalcValue = (dataset_GetInpatientAdmissionMoney != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionMoney.PersonWhoTakeMaterials) : "");
                    return new TTReportObject[] { PROCESSDATE,AMOUNT,MONETARYUNIT,RECEIPTNO,PWGM1,PWTM1};
                }
            }

        }

        public MoneyMainGroup MoneyMain;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InpatientAdmissionGivenAndTakenMaterialReport()
        {
            ReportHeader = new ReportHeaderGroup(this,"ReportHeader");
            TakenMaterials = new TakenMaterialsGroup(ReportHeader,"TakenMaterials");
            MAIN = new MAINGroup(TakenMaterials,"MAIN");
            GivenMaterials = new GivenMaterialsGroup(ReportHeader,"GivenMaterials");
            GivenMaterialsMain = new GivenMaterialsMainGroup(GivenMaterials,"GivenMaterialsMain");
            VariableMaterials = new VariableMaterialsGroup(ReportHeader,"VariableMaterials");
            VariableMaterialsProcessType = new VariableMaterialsProcessTypeGroup(VariableMaterials,"VariableMaterialsProcessType");
            VariableMaterialsMain = new VariableMaterialsMainGroup(VariableMaterialsProcessType,"VariableMaterialsMain");
            Money = new MoneyGroup(ReportHeader,"Money");
            MoneyProcessType = new MoneyProcessTypeGroup(Money,"MoneyProcessType");
            MoneyMain = new MoneyMainGroup(MoneyProcessType,"MoneyMain");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hasta Yatış", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PROCESSTYPE", "1", "İşlem Tipi", @"", true, true, false, new Guid("85655ed3-1a00-4d56-a6a3-7edcb458e741"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PROCESSTYPE"))
                _runtimeParameters.PROCESSTYPE = (QuarantineProcessTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["QuarantineProcessTypeEnum"].ConvertValue(parameters["PROCESSTYPE"]);
            Name = "INPATIENTADMISSIONGIVENANDTAKENMATERIALREPORT";
            Caption = "Teslim Tesellüm Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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
            fd.TextFont.Size = 9;
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