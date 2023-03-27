
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
    /// Ayaktan Hasta Reçetesi Raporu
    /// </summary>
    public partial class OutpatientPrescriptionReportByFormat : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public OutpatientPrescriptionReportByFormat MyParentReport
            {
                get { return (OutpatientPrescriptionReportByFormat)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField11120 { get {return Header().NewField11120;} }
            public TTReportField NewField11118 { get {return Header().NewField11118;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField11116 { get {return Header().NewField11116;} }
            public TTReportField NewField131111 { get {return Header().NewField131111;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11114 { get {return Header().NewField11114;} }
            public TTReportField NewField11117 { get {return Header().NewField11117;} }
            public TTReportField NewField11119 { get {return Header().NewField11119;} }
            public TTReportField NewField1111181 { get {return Header().NewField1111181;} }
            public TTReportField NewField1111192 { get {return Header().NewField1111192;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField EXTERNALPHARMACY { get {return Header().EXTERNALPHARMACY;} }
            public TTReportField PRESCRIPTIONDATE { get {return Header().PRESCRIPTIONDATE;} }
            public TTReportField PROCEDURESPECIALITY { get {return Header().PROCEDURESPECIALITY;} }
            public TTReportField DIAGNOSIS { get {return Header().DIAGNOSIS;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField PATIENTID { get {return Header().PATIENTID;} }
            public TTReportField REGISTRYNO { get {return Header().REGISTRYNO;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField PROVISIONNO { get {return Header().PROVISIONNO;} }
            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField NewField171111 { get {return Header().NewField171111;} }
            public TTReportField NewField1111171 { get {return Header().NewField1111171;} }
            public TTReportField NewField11711111 { get {return Header().NewField11711111;} }
            public TTReportField NewField11711112 { get {return Header().NewField11711112;} }
            public TTReportField NewField11711113 { get {return Header().NewField11711113;} }
            public TTReportField NewField131111711 { get {return Header().NewField131111711;} }
            public TTReportField NewField131111712 { get {return Header().NewField131111712;} }
            public TTReportField NewField1217111131 { get {return Header().NewField1217111131;} }
            public TTReportField NewField1217111132 { get {return Header().NewField1217111132;} }
            public TTReportField NewField1217111133 { get {return Header().NewField1217111133;} }
            public TTReportField NewField1117111131 { get {return Header().NewField1117111131;} }
            public TTReportField ERECETENO { get {return Header().ERECETENO;} }
            public TTReportField NewField1111121 { get {return Header().NewField1111121;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField TITLE_RANK_NAME_SURNAME { get {return Header().TITLE_RANK_NAME_SURNAME;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField DRUGGIVINGDATE { get {return Header().DRUGGIVINGDATE;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField1111172 { get {return Footer().NewField1111172;} }
            public TTReportField NewField12711111 { get {return Footer().NewField12711111;} }
            public TTReportField NewField12711112 { get {return Footer().NewField12711112;} }
            public TTReportField NewField12711113 { get {return Footer().NewField12711113;} }
            public TTReportField NewField17811111 { get {return Footer().NewField17811111;} }
            public TTReportField NewField18811111 { get {return Footer().NewField18811111;} }
            public TTReportField NewField19811111 { get {return Footer().NewField19811111;} }
            public TTReportField NewField10911111 { get {return Footer().NewField10911111;} }
            public TTReportField TOTALDRUGPRICE { get {return Footer().TOTALDRUGPRICE;} }
            public TTReportField DISCOUNT { get {return Footer().DISCOUNT;} }
            public TTReportField TOTALSOCIETYLOT { get {return Footer().TOTALSOCIETYLOT;} }
            public TTReportField TOTALPATIENTLOT { get {return Footer().TOTALPATIENTLOT;} }
            public TTReportField NewField12711114 { get {return Footer().NewField12711114;} }
            public TTReportField NewField111111721 { get {return Footer().NewField111111721;} }
            public TTReportField NewField1127111111 { get {return Footer().NewField1127111111;} }
            public TTReportField TOTALPRICEDIFFERENCE { get {return Footer().TOTALPRICEDIFFERENCE;} }
            public TTReportField TOTALPATIENTLOT1 { get {return Footer().TOTALPATIENTLOT1;} }
            public TTReportField NewField141111721 { get {return Footer().NewField141111721;} }
            public TTReportField NewField1127111141 { get {return Footer().NewField1127111141;} }
            public TTReportField NewField111111722 { get {return Footer().NewField111111722;} }
            public TTReportField NewField1227111111 { get {return Footer().NewField1227111111;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField12711115 { get {return Footer().NewField12711115;} }
            public TTReportField TITLE_RANK_NAME_SURNAME1 { get {return Footer().TITLE_RANK_NAME_SURNAME1;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField DIPLOMAREGISTERNO { get {return Footer().DIPLOMAREGISTERNO;} }
            public TTReportField TABIPTITLE { get {return Footer().TABIPTITLE;} }
            public TTReportField NewField17811112 { get {return Footer().NewField17811112;} }
            public TTReportField NewField121111871 { get {return Footer().NewField121111871;} }
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
                list[0] = new TTReportNqlData<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>("GetOutpatientPrescriptionReportQuery", OutPatientPrescription.GetOutpatientPrescriptionReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OutpatientPrescriptionReportByFormat MyParentReport
                {
                    get { return (OutpatientPrescriptionReportByFormat)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField11120;
                public TTReportField NewField11118;
                public TTReportField NewField11112;
                public TTReportField NewField11116;
                public TTReportField NewField131111;
                public TTReportField LOGO;
                public TTReportField HOSPITALNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField11114;
                public TTReportField NewField11117;
                public TTReportField NewField11119;
                public TTReportField NewField1111181;
                public TTReportField NewField1111192;
                public TTReportField PAYER;
                public TTReportField EXTERNALPHARMACY;
                public TTReportField PRESCRIPTIONDATE;
                public TTReportField PROCEDURESPECIALITY;
                public TTReportField DIAGNOSIS;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTID;
                public TTReportField REGISTRYNO;
                public TTReportField PROTOCOLNO;
                public TTReportField PROVISIONNO;
                public TTReportField HOSPITAL;
                public TTReportField NewField171111;
                public TTReportField NewField1111171;
                public TTReportField NewField11711111;
                public TTReportField NewField11711112;
                public TTReportField NewField11711113;
                public TTReportField NewField131111711;
                public TTReportField NewField131111712;
                public TTReportField NewField1217111131;
                public TTReportField NewField1217111132;
                public TTReportField NewField1217111133;
                public TTReportField NewField1117111131;
                public TTReportField ERECETENO;
                public TTReportField NewField1111121;
                public TTReportField NewField111;
                public TTReportField TITLE_RANK_NAME_SURNAME;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField DRUGGIVINGDATE;
                public TTReportField NewField1112; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 115;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 39, 197, 108, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Dr. Dip. No. Adı,
 Soyadı
 (Varsa Kaşesi)";

                    NewField11120 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 31, 197, 39, false);
                    NewField11120.Name = "NewField11120";
                    NewField11120.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11120.TextFont.Name = "Arial";
                    NewField11120.TextFont.Bold = true;
                    NewField11120.TextFont.CharSet = 162;
                    NewField11120.Value = @"Protokol:";

                    NewField11118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 25, 197, 31, false);
                    NewField11118.Name = "NewField11118";
                    NewField11118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11118.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11118.TextFont.Name = "Arial";
                    NewField11118.TextFont.Bold = true;
                    NewField11118.TextFont.CharSet = 162;
                    NewField11118.Value = @" Tarih:";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 86, 143, 108, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @" Tanı:";

                    NewField11116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 62, 143, 86, false);
                    NewField11116.Name = "NewField11116";
                    NewField11116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116.TextFont.Name = "Arial";
                    NewField11116.TextFont.Bold = true;
                    NewField11116.TextFont.CharSet = 162;
                    NewField11116.Value = @" Tabibin Kurumu:";

                    NewField131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 25, 143, 39, false);
                    NewField131111.Name = "NewField131111";
                    NewField131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131111.TextFont.Name = "Arial";
                    NewField131111.TextFont.Bold = true;
                    NewField131111.TextFont.CharSet = 162;
                    NewField131111.Value = @" Hastanın Adı Soyadı:";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 12, 251, 32, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.TextFont.Name = "Arial";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 10, 433, 33, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 12;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 39, 143, 62, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" Hastanın Kurumu:";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 37, 250, 42, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Eczane Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 125, 254, 130, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Reçete Tarihi";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 130, 254, 135, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.Visible = EvetHayirEnum.ehHayir;
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Uzmanlık Dalı";

                    NewField11114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 145, 254, 150, false);
                    NewField11114.Name = "NewField11114";
                    NewField11114.Visible = EvetHayirEnum.ehHayir;
                    NewField11114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114.TextFont.Name = "Arial";
                    NewField11114.TextFont.Bold = true;
                    NewField11114.TextFont.CharSet = 162;
                    NewField11114.Value = @"T.C. Kimlik Nu.";

                    NewField11117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 160, 254, 165, false);
                    NewField11117.Name = "NewField11117";
                    NewField11117.Visible = EvetHayirEnum.ehHayir;
                    NewField11117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11117.TextFont.Name = "Arial";
                    NewField11117.TextFont.Bold = true;
                    NewField11117.TextFont.CharSet = 162;
                    NewField11117.Value = @"Provizyon Nu.";

                    NewField11119 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 54, 246, 59, false);
                    NewField11119.Name = "NewField11119";
                    NewField11119.Visible = EvetHayirEnum.ehHayir;
                    NewField11119.TextFont.Name = "Arial";
                    NewField11119.TextFont.Bold = true;
                    NewField11119.TextFont.CharSet = 162;
                    NewField11119.Value = @"Sicil Nu.";

                    NewField1111181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 37, 253, 42, false);
                    NewField1111181.Name = "NewField1111181";
                    NewField1111181.Visible = EvetHayirEnum.ehHayir;
                    NewField1111181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111181.TextFont.Name = "Arial";
                    NewField1111181.TextFont.Bold = true;
                    NewField1111181.TextFont.CharSet = 162;
                    NewField1111181.Value = @":";

                    NewField1111192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 54, 248, 59, false);
                    NewField1111192.Name = "NewField1111192";
                    NewField1111192.Visible = EvetHayirEnum.ehHayir;
                    NewField1111192.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111192.TextFont.Name = "Arial";
                    NewField1111192.TextFont.Bold = true;
                    NewField1111192.TextFont.CharSet = 162;
                    NewField1111192.Value = @":";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 45, 143, 59, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Name = "Arial";
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @" {#PAYER#}";

                    EXTERNALPHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 43, 344, 48, false);
                    EXTERNALPHARMACY.Name = "EXTERNALPHARMACY";
                    EXTERNALPHARMACY.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALPHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALPHARMACY.WordBreak = EvetHayirEnum.ehEvet;
                    EXTERNALPHARMACY.TextFont.Name = "Arial";
                    EXTERNALPHARMACY.TextFont.CharSet = 162;
                    EXTERNALPHARMACY.Value = @"{#EXTERNALPHARMACY#}";

                    PRESCRIPTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 125, 302, 130, false);
                    PRESCRIPTIONDATE.Name = "PRESCRIPTIONDATE";
                    PRESCRIPTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    PRESCRIPTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRESCRIPTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONDATE.TextFormat = @"dd/MM/yyyy";
                    PRESCRIPTIONDATE.TextFont.Name = "Arial";
                    PRESCRIPTIONDATE.TextFont.CharSet = 162;
                    PRESCRIPTIONDATE.Value = @"{#PRESCRIPTIONDATE#}";

                    PROCEDURESPECIALITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 130, 387, 135, false);
                    PROCEDURESPECIALITY.Name = "PROCEDURESPECIALITY";
                    PROCEDURESPECIALITY.Visible = EvetHayirEnum.ehHayir;
                    PROCEDURESPECIALITY.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCEDURESPECIALITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURESPECIALITY.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDURESPECIALITY.TextFont.Name = "Arial";
                    PROCEDURESPECIALITY.TextFont.CharSet = 162;
                    PROCEDURESPECIALITY.Value = @"{#PROCEDURESPECIALITY#}";

                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 92, 143, 105, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.TextFont.Name = "Arial";
                    DIAGNOSIS.TextFont.CharSet = 162;
                    DIAGNOSIS.Value = @"";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 32, 143, 37, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @" {#PATIENT#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 145, 302, 150, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.Visible = EvetHayirEnum.ehHayir;
                    PATIENTID.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.TextFont.Name = "Arial";
                    PATIENTID.TextFont.CharSet = 162;
                    PATIENTID.Value = @"{#UNIQUEREFNO#}";

                    REGISTRYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 59, 260, 64, false);
                    REGISTRYNO.Name = "REGISTRYNO";
                    REGISTRYNO.Visible = EvetHayirEnum.ehHayir;
                    REGISTRYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRYNO.TextFont.Name = "Arial";
                    REGISTRYNO.TextFont.CharSet = 162;
                    REGISTRYNO.Value = @"{#EMPLOYMENTRECORDID#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 32, 195, 37, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    PROVISIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 160, 302, 165, false);
                    PROVISIONNO.Name = "PROVISIONNO";
                    PROVISIONNO.Visible = EvetHayirEnum.ehHayir;
                    PROVISIONNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PROVISIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVISIONNO.TextFont.Name = "Arial";
                    PROVISIONNO.TextFont.CharSet = 162;
                    PROVISIONNO.Value = @"{#SPTSPROVISIONID#}";

                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 67, 143, 84, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITAL.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"";

                    NewField171111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 98, 263, 107, false);
                    NewField171111.Name = "NewField171111";
                    NewField171111.Visible = EvetHayirEnum.ehHayir;
                    NewField171111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171111.TextFont.Name = "Arial";
                    NewField171111.TextFont.Bold = true;
                    NewField171111.TextFont.CharSet = 162;
                    NewField171111.Value = @"Verilen İlaç";

                    NewField1111171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 98, 273, 107, false);
                    NewField1111171.Name = "NewField1111171";
                    NewField1111171.Visible = EvetHayirEnum.ehHayir;
                    NewField1111171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111171.TextFont.Name = "Arial";
                    NewField1111171.TextFont.Bold = true;
                    NewField1111171.TextFont.CharSet = 162;
                    NewField1111171.Value = @"Adet";

                    NewField11711111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 98, 283, 107, false);
                    NewField11711111.Name = "NewField11711111";
                    NewField11711111.Visible = EvetHayirEnum.ehHayir;
                    NewField11711111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711111.TextFont.Name = "Arial";
                    NewField11711111.TextFont.Bold = true;
                    NewField11711111.TextFont.CharSet = 162;
                    NewField11711111.Value = @"Doz";

                    NewField11711112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 284, 98, 295, 107, false);
                    NewField11711112.Name = "NewField11711112";
                    NewField11711112.Visible = EvetHayirEnum.ehHayir;
                    NewField11711112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711112.TextFont.Name = "Arial";
                    NewField11711112.TextFont.Bold = true;
                    NewField11711112.TextFont.CharSet = 162;
                    NewField11711112.Value = @"H/A R";

                    NewField11711113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 98, 307, 107, false);
                    NewField11711113.Name = "NewField11711113";
                    NewField11711113.Visible = EvetHayirEnum.ehHayir;
                    NewField11711113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11711113.TextFont.Name = "Arial";
                    NewField11711113.TextFont.Bold = true;
                    NewField11711113.TextFont.CharSet = 162;
                    NewField11711113.Value = @"Birim
Fiyat";

                    NewField131111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 98, 319, 107, false);
                    NewField131111711.Name = "NewField131111711";
                    NewField131111711.Visible = EvetHayirEnum.ehHayir;
                    NewField131111711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131111711.TextFont.Name = "Arial";
                    NewField131111711.TextFont.Bold = true;
                    NewField131111711.TextFont.CharSet = 162;
                    NewField131111711.Value = @"İlaç
Fiyatı";

                    NewField131111712 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 320, 98, 331, 107, false);
                    NewField131111712.Name = "NewField131111712";
                    NewField131111712.Visible = EvetHayirEnum.ehHayir;
                    NewField131111712.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131111712.TextFont.Name = "Arial";
                    NewField131111712.TextFont.Bold = true;
                    NewField131111712.TextFont.CharSet = 162;
                    NewField131111712.Value = @"Hasta
Payı";

                    NewField1217111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 332, 98, 344, 107, false);
                    NewField1217111131.Name = "NewField1217111131";
                    NewField1217111131.Visible = EvetHayirEnum.ehHayir;
                    NewField1217111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1217111131.TextFont.Name = "Arial";
                    NewField1217111131.TextFont.Bold = true;
                    NewField1217111131.TextFont.CharSet = 162;
                    NewField1217111131.Value = @"Kurum
Payı";

                    NewField1217111132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 345, 98, 354, 107, false);
                    NewField1217111132.Name = "NewField1217111132";
                    NewField1217111132.Visible = EvetHayirEnum.ehHayir;
                    NewField1217111132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1217111132.TextFont.Name = "Arial";
                    NewField1217111132.TextFont.Bold = true;
                    NewField1217111132.TextFont.CharSet = 162;
                    NewField1217111132.Value = @"İlaç
Bitiş";

                    NewField1217111133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 355, 98, 365, 107, false);
                    NewField1217111133.Name = "NewField1217111133";
                    NewField1217111133.Visible = EvetHayirEnum.ehHayir;
                    NewField1217111133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1217111133.TextFont.Name = "Arial";
                    NewField1217111133.TextFont.Bold = true;
                    NewField1217111133.TextFont.CharSet = 162;
                    NewField1217111133.Value = @"KDV
Oranı";

                    NewField1117111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 98, 383, 107, false);
                    NewField1117111131.Name = "NewField1117111131";
                    NewField1117111131.Visible = EvetHayirEnum.ehHayir;
                    NewField1117111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1117111131.TextFont.Name = "Arial";
                    NewField1117111131.TextFont.Bold = true;
                    NewField1117111131.TextFont.CharSet = 162;
                    NewField1117111131.Value = @"İlaç Fiyat
Farkı";

                    ERECETENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 15, 197, 20, false);
                    ERECETENO.Name = "ERECETENO";
                    ERECETENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERECETENO.TextFormat = @"dd/MM/yyyy";
                    ERECETENO.TextFont.Name = "Arial";
                    ERECETENO.TextFont.CharSet = 162;
                    ERECETENO.Value = @"{#ERECETENO#}";

                    NewField1111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 15, 166, 20, false);
                    NewField1111121.Name = "NewField1111121";
                    NewField1111121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121.TextFont.Name = "Arial";
                    NewField1111121.TextFont.Bold = true;
                    NewField1111121.TextFont.CharSet = 162;
                    NewField1111121.Value = @"EReçete No :";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 108, 157, 115, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"  İLAÇLAR";

                    TITLE_RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 53, 192, 103, false);
                    TITLE_RANK_NAME_SURNAME.Name = "TITLE_RANK_NAME_SURNAME";
                    TITLE_RANK_NAME_SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE_RANK_NAME_SURNAME.MultiLine = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.NoClip = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.WordBreak = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.TextFont.Name = "Arial";
                    TITLE_RANK_NAME_SURNAME.TextFont.Bold = true;
                    TITLE_RANK_NAME_SURNAME.TextFont.CharSet = 162;
                    TITLE_RANK_NAME_SURNAME.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 15, 46, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"REÇETE";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 20, 197, 25, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"T.C. Standart Form no 1.51001 FBT 040";

                    DRUGGIVINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 26, 197, 31, false);
                    DRUGGIVINGDATE.Name = "DRUGGIVINGDATE";
                    DRUGGIVINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGGIVINGDATE.Value = @"{#DRUGGIVINGDATE#}";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 108, 197, 115, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"TUTARI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    NewField11120.CalcValue = NewField11120.Value;
                    NewField11118.CalcValue = NewField11118.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField11116.CalcValue = NewField11116.Value;
                    NewField131111.CalcValue = NewField131111.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11114.CalcValue = NewField11114.Value;
                    NewField11117.CalcValue = NewField11117.Value;
                    NewField11119.CalcValue = NewField11119.Value;
                    NewField1111181.CalcValue = NewField1111181.Value;
                    NewField1111192.CalcValue = NewField1111192.Value;
                    PAYER.CalcValue = @" " + (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Payer) : "");
                    EXTERNALPHARMACY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Externalpharmacy) : "");
                    PRESCRIPTIONDATE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Prescriptiondate) : "");
                    PROCEDURESPECIALITY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Procedurespeciality) : "");
                    DIAGNOSIS.CalcValue = @"";
                    PATIENTNAME.CalcValue = @" " + (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Patient) : "");
                    PATIENTID.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.UniqueRefNo) : "");
                    REGISTRYNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Employmentrecordid) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.HospitalProtocolNo) : "");
                    PROVISIONNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.SPTSProvisionID) : "");
                    HOSPITAL.CalcValue = HOSPITAL.Value;
                    NewField171111.CalcValue = NewField171111.Value;
                    NewField1111171.CalcValue = NewField1111171.Value;
                    NewField11711111.CalcValue = NewField11711111.Value;
                    NewField11711112.CalcValue = NewField11711112.Value;
                    NewField11711113.CalcValue = NewField11711113.Value;
                    NewField131111711.CalcValue = NewField131111711.Value;
                    NewField131111712.CalcValue = NewField131111712.Value;
                    NewField1217111131.CalcValue = NewField1217111131.Value;
                    NewField1217111132.CalcValue = NewField1217111132.Value;
                    NewField1217111133.CalcValue = NewField1217111133.Value;
                    NewField1117111131.CalcValue = NewField1117111131.Value;
                    ERECETENO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.EReceteNo) : "");
                    NewField1111121.CalcValue = NewField1111121.Value;
                    NewField111.CalcValue = NewField111.Value;
                    TITLE_RANK_NAME_SURNAME.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    DRUGGIVINGDATE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Druggivingdate) : "");
                    NewField1112.CalcValue = NewField1112.Value;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField12,NewField11120,NewField11118,NewField11112,NewField11116,NewField131111,LOGO,NewField1,NewField11,NewField1111,NewField11111,NewField11114,NewField11117,NewField11119,NewField1111181,NewField1111192,PAYER,EXTERNALPHARMACY,PRESCRIPTIONDATE,PROCEDURESPECIALITY,DIAGNOSIS,PATIENTNAME,PATIENTID,REGISTRYNO,PROTOCOLNO,PROVISIONNO,HOSPITAL,NewField171111,NewField1111171,NewField11711111,NewField11711112,NewField11711113,NewField131111711,NewField131111712,NewField1217111131,NewField1217111132,NewField1217111133,NewField1117111131,ERECETENO,NewField1111121,NewField111,TITLE_RANK_NAME_SURNAME,NewField2,NewField3,DRUGGIVINGDATE,NewField1112,HOSPITALNAME};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
            string[] kelimeDizi = hospitalName.Split(' ');
            hospitalName = "";
            foreach (string s in kelimeDizi)
            {
                hospitalName += s.Trim() + " ";
            }
            HOSPITAL.CalcValue = hospitalName.ToString();
           
            TTObjectContext context = new TTObjectContext(true);
            string objectID = ((OutpatientPrescriptionReportByFormat)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            OutPatientPrescription deneme = (OutPatientPrescription)context.GetObject(new Guid(objectID),"OutPatientPrescription");
            Episode episode = deneme.Episode;
            string diagnoseName ="";
            foreach (DiagnosisGrid diagnose in episode.Diagnosis)
            {
                diagnoseName += (diagnose.Diagnose).ToString() + " \r\n";
                
            }
            DIAGNOSIS.CalcValue = diagnoseName + "  \r\n";
            
            
            TTObjectContext tto = new TTObjectContext(false);
            Prescription recete = (Prescription)tto.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.Value.ToString()), typeof(Prescription));
            ResUser doktor = (ResUser)tto.GetObject(recete.ProcedureDoctor.ObjectID, typeof(ResUser));
            this.TITLE_RANK_NAME_SURNAME.CalcValue = "";
            this.TITLE_RANK_NAME_SURNAME.CalcValue += (doktor.Title.HasValue ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(doktor.Title.Value)+" " : "");
           // this.TITLE_RANK_NAME_SURNAME.CalcValue += (doktor.Rank != null ? doktor.Rank.Name+" " : "");
            this.TITLE_RANK_NAME_SURNAME.CalcValue += (doktor.Name != null ? doktor.Name : "");
            this.TITLE_RANK_NAME_SURNAME.CalcValue += "\r\n";
            
            string mainSpeciality = "";
            string otherSpecialities = "";
            for(int x = 0; x<doktor.ResourceSpecialities.Count;x++)
            {
                if (doktor.ResourceSpecialities[x].MainSpeciality != null)
                {
                    if (doktor.ResourceSpecialities[x].MainSpeciality.Value)
                    {
                        mainSpeciality += (doktor.ResourceSpecialities[x].Speciality.Name.Contains("Uzm") ? doktor.ResourceSpecialities[x].Speciality.Name : doktor.ResourceSpecialities[x].Speciality.Name + " Uzm.");
                    }
                    else
                    {
                        otherSpecialities += (doktor.ResourceSpecialities[x].Speciality.Name.Contains("Uzm") ? doktor.ResourceSpecialities[x].Speciality.Name + "\r\n" : doktor.ResourceSpecialities[x].Speciality.Name + " Uzm.\r\n");
                    }
                }
            }

            this.TITLE_RANK_NAME_SURNAME.CalcValue += mainSpeciality + "\r\n" + otherSpecialities;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OutpatientPrescriptionReportByFormat MyParentReport
                {
                    get { return (OutpatientPrescriptionReportByFormat)ParentReport; }
                }
                
                public TTReportField NewField1111172;
                public TTReportField NewField12711111;
                public TTReportField NewField12711112;
                public TTReportField NewField12711113;
                public TTReportField NewField17811111;
                public TTReportField NewField18811111;
                public TTReportField NewField19811111;
                public TTReportField NewField10911111;
                public TTReportField TOTALDRUGPRICE;
                public TTReportField DISCOUNT;
                public TTReportField TOTALSOCIETYLOT;
                public TTReportField TOTALPATIENTLOT;
                public TTReportField NewField12711114;
                public TTReportField NewField111111721;
                public TTReportField NewField1127111111;
                public TTReportField TOTALPRICEDIFFERENCE;
                public TTReportField TOTALPATIENTLOT1;
                public TTReportField NewField141111721;
                public TTReportField NewField1127111141;
                public TTReportField NewField111111722;
                public TTReportField NewField1227111111;
                public TTReportField NewField14;
                public TTReportField NewField12711115;
                public TTReportField TITLE_RANK_NAME_SURNAME1;
                public TTReportField DIPLOMANO;
                public TTReportField NewField15;
                public TTReportField DIPLOMAREGISTERNO;
                public TTReportField TABIPTITLE;
                public TTReportField NewField17811112;
                public TTReportField NewField121111871; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 76;
                    RepeatCount = 0;
                    
                    NewField1111172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 7, 354, 12, false);
                    NewField1111172.Name = "NewField1111172";
                    NewField1111172.Visible = EvetHayirEnum.ehHayir;
                    NewField1111172.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111172.TextFont.Name = "Arial";
                    NewField1111172.TextFont.Bold = true;
                    NewField1111172.TextFont.CharSet = 162;
                    NewField1111172.Value = @"Toplam İlaç Fiyatı";

                    NewField12711111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 12, 354, 17, false);
                    NewField12711111.Name = "NewField12711111";
                    NewField12711111.Visible = EvetHayirEnum.ehHayir;
                    NewField12711111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711111.TextFont.Name = "Arial";
                    NewField12711111.TextFont.Bold = true;
                    NewField12711111.TextFont.CharSet = 162;
                    NewField12711111.Value = @"Hasta Katılım Payı";

                    NewField12711112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 17, 354, 22, false);
                    NewField12711112.Name = "NewField12711112";
                    NewField12711112.Visible = EvetHayirEnum.ehHayir;
                    NewField12711112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711112.TextFont.Name = "Arial";
                    NewField12711112.TextFont.Bold = true;
                    NewField12711112.TextFont.CharSet = 162;
                    NewField12711112.Value = @"İskonto";

                    NewField12711113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 22, 354, 27, false);
                    NewField12711113.Name = "NewField12711113";
                    NewField12711113.Visible = EvetHayirEnum.ehHayir;
                    NewField12711113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711113.TextFont.Name = "Arial";
                    NewField12711113.TextFont.Bold = true;
                    NewField12711113.TextFont.CharSet = 162;
                    NewField12711113.Value = @"Toplam Kurum Payı";

                    NewField17811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 354, 7, 356, 12, false);
                    NewField17811111.Name = "NewField17811111";
                    NewField17811111.Visible = EvetHayirEnum.ehHayir;
                    NewField17811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17811111.TextFont.Name = "Arial";
                    NewField17811111.TextFont.Bold = true;
                    NewField17811111.TextFont.CharSet = 162;
                    NewField17811111.Value = @":";

                    NewField18811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 354, 12, 356, 17, false);
                    NewField18811111.Name = "NewField18811111";
                    NewField18811111.Visible = EvetHayirEnum.ehHayir;
                    NewField18811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18811111.TextFont.Name = "Arial";
                    NewField18811111.TextFont.Bold = true;
                    NewField18811111.TextFont.CharSet = 162;
                    NewField18811111.Value = @":";

                    NewField19811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 354, 17, 356, 22, false);
                    NewField19811111.Name = "NewField19811111";
                    NewField19811111.Visible = EvetHayirEnum.ehHayir;
                    NewField19811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19811111.TextFont.Name = "Arial";
                    NewField19811111.TextFont.Bold = true;
                    NewField19811111.TextFont.CharSet = 162;
                    NewField19811111.Value = @":";

                    NewField10911111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 354, 22, 356, 27, false);
                    NewField10911111.Name = "NewField10911111";
                    NewField10911111.Visible = EvetHayirEnum.ehHayir;
                    NewField10911111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10911111.TextFont.Name = "Arial";
                    NewField10911111.TextFont.Bold = true;
                    NewField10911111.TextFont.CharSet = 162;
                    NewField10911111.Value = @":";

                    TOTALDRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 357, 7, 385, 12, false);
                    TOTALDRUGPRICE.Name = "TOTALDRUGPRICE";
                    TOTALDRUGPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDRUGPRICE.TextFormat = @"#,##0.#0";
                    TOTALDRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDRUGPRICE.TextFont.Name = "Arial";
                    TOTALDRUGPRICE.TextFont.Bold = true;
                    TOTALDRUGPRICE.TextFont.CharSet = 162;
                    TOTALDRUGPRICE.Value = @"";

                    DISCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 357, 17, 385, 22, false);
                    DISCOUNT.Name = "DISCOUNT";
                    DISCOUNT.Visible = EvetHayirEnum.ehHayir;
                    DISCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCOUNT.TextFormat = @"#,##0.#0";
                    DISCOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISCOUNT.TextFont.Name = "Arial";
                    DISCOUNT.TextFont.CharSet = 162;
                    DISCOUNT.Value = @"";

                    TOTALSOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 357, 22, 385, 27, false);
                    TOTALSOCIETYLOT.Name = "TOTALSOCIETYLOT";
                    TOTALSOCIETYLOT.Visible = EvetHayirEnum.ehHayir;
                    TOTALSOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALSOCIETYLOT.TextFormat = @"#,##0.#0";
                    TOTALSOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALSOCIETYLOT.TextFont.Name = "Arial";
                    TOTALSOCIETYLOT.TextFont.Bold = true;
                    TOTALSOCIETYLOT.TextFont.CharSet = 162;
                    TOTALSOCIETYLOT.Value = @"";

                    TOTALPATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 357, 12, 385, 17, false);
                    TOTALPATIENTLOT.Name = "TOTALPATIENTLOT";
                    TOTALPATIENTLOT.Visible = EvetHayirEnum.ehHayir;
                    TOTALPATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPATIENTLOT.TextFormat = @"#,##0.#0";
                    TOTALPATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPATIENTLOT.TextFont.Name = "Arial";
                    TOTALPATIENTLOT.TextFont.CharSet = 162;
                    TOTALPATIENTLOT.Value = @"{@sumof(PATIENTLOT)@}";

                    NewField12711114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 37, 314, 42, false);
                    NewField12711114.Name = "NewField12711114";
                    NewField12711114.Visible = EvetHayirEnum.ehHayir;
                    NewField12711114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711114.TextFont.Name = "Arial";
                    NewField12711114.TextFont.Bold = true;
                    NewField12711114.TextFont.CharSet = 162;
                    NewField12711114.Value = @"Aldığınız ilaçlar için ödemeniz gereken toplam fiyat farkı : ";

                    NewField111111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 42, 289, 47, false);
                    NewField111111721.Name = "NewField111111721";
                    NewField111111721.Visible = EvetHayirEnum.ehHayir;
                    NewField111111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111721.TextFont.Name = "Arial";
                    NewField111111721.TextFont.Bold = true;
                    NewField111111721.TextFont.CharSet = 162;
                    NewField111111721.Value = @"Aldığınız ilaçların hasta katılım payı tutarı : ";

                    NewField1127111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 47, 321, 52, false);
                    NewField1127111111.Name = "NewField1127111111";
                    NewField1127111111.Visible = EvetHayirEnum.ehHayir;
                    NewField1127111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111111.TextFont.Name = "Arial";
                    NewField1127111111.TextFont.Bold = true;
                    NewField1127111111.TextFont.CharSet = 162;
                    NewField1127111111.Value = @"Reçete Sahibinin İmzası";

                    TOTALPRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 37, 348, 42, false);
                    TOTALPRICEDIFFERENCE.Name = "TOTALPRICEDIFFERENCE";
                    TOTALPRICEDIFFERENCE.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICEDIFFERENCE.TextFont.Name = "Arial";
                    TOTALPRICEDIFFERENCE.TextFont.CharSet = 162;
                    TOTALPRICEDIFFERENCE.Value = @"";

                    TOTALPATIENTLOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 289, 42, 317, 47, false);
                    TOTALPATIENTLOT1.Name = "TOTALPATIENTLOT1";
                    TOTALPATIENTLOT1.Visible = EvetHayirEnum.ehHayir;
                    TOTALPATIENTLOT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPATIENTLOT1.TextFormat = @"#,##0.#0";
                    TOTALPATIENTLOT1.TextFont.Name = "Arial";
                    TOTALPATIENTLOT1.TextFont.CharSet = 162;
                    TOTALPATIENTLOT1.Value = @"{@sumof(PATIENTLOT)@}";

                    NewField141111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 348, 37, 358, 42, false);
                    NewField141111721.Name = "NewField141111721";
                    NewField141111721.Visible = EvetHayirEnum.ehHayir;
                    NewField141111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141111721.TextFont.Name = "Arial";
                    NewField141111721.TextFont.CharSet = 162;
                    NewField141111721.Value = @"TL'dir.";

                    NewField1127111141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 42, 327, 47, false);
                    NewField1127111141.Name = "NewField1127111141";
                    NewField1127111141.Visible = EvetHayirEnum.ehHayir;
                    NewField1127111141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111141.TextFont.Name = "Arial";
                    NewField1127111141.TextFont.CharSet = 162;
                    NewField1127111141.Value = @"TL'dir.";

                    NewField111111722 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 30, 536, 42, false);
                    NewField111111722.Name = "NewField111111722";
                    NewField111111722.Visible = EvetHayirEnum.ehHayir;
                    NewField111111722.TextFont.Name = "Arial";
                    NewField111111722.TextFont.Bold = true;
                    NewField111111722.TextFont.CharSet = 162;
                    NewField111111722.Value = @" REÇETE MUHTEVİYATINI TESLİM ALANIN ADI SOYADI VE  İMZASI:";

                    NewField1227111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 42, 536, 55, false);
                    NewField1227111111.Name = "NewField1227111111";
                    NewField1227111111.Visible = EvetHayirEnum.ehHayir;
                    NewField1227111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1227111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1227111111.TextFont.Name = "Arial";
                    NewField1227111111.TextFont.Bold = true;
                    NewField1227111111.TextFont.CharSet = 162;
                    NewField1227111111.Value = @" BAŞTABİP ONAY (KAŞE- İMZA):               
 ""YATAN HASTA, ECZANEMİZDE YOKTUR."" Kaşesi Basılacaktır.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 21, 246, 26, false);
                    NewField14.Name = "NewField14";
                    NewField14.Visible = EvetHayirEnum.ehHayir;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"D.Nu. ";

                    NewField12711115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 388, 5, 450, 10, false);
                    NewField12711115.Name = "NewField12711115";
                    NewField12711115.Visible = EvetHayirEnum.ehHayir;
                    NewField12711115.TextFont.Name = "Arial";
                    NewField12711115.TextFont.Bold = true;
                    NewField12711115.TextFont.CharSet = 162;
                    NewField12711115.Value = @"TABİP KAŞESİ (ISLAK İMZA)";

                    TITLE_RANK_NAME_SURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 388, 10, 450, 23, false);
                    TITLE_RANK_NAME_SURNAME1.Name = "TITLE_RANK_NAME_SURNAME1";
                    TITLE_RANK_NAME_SURNAME1.Visible = EvetHayirEnum.ehHayir;
                    TITLE_RANK_NAME_SURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE_RANK_NAME_SURNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME1.NoClip = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME1.TextFont.Name = "Arial";
                    TITLE_RANK_NAME_SURNAME1.TextFont.Bold = true;
                    TITLE_RANK_NAME_SURNAME1.TextFont.CharSet = 162;
                    TITLE_RANK_NAME_SURNAME1.Value = @"";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 21, 288, 26, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial";
                    DIPLOMANO.TextFont.Bold = true;
                    DIPLOMANO.TextFont.CharSet = 162;
                    DIPLOMANO.Value = @"{#DIPLOMANO#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 26, 246, 31, false);
                    NewField15.Name = "NewField15";
                    NewField15.Visible = EvetHayirEnum.ehHayir;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"D.Tes.Nu.:";

                    DIPLOMAREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 26, 288, 31, false);
                    DIPLOMAREGISTERNO.Name = "DIPLOMAREGISTERNO";
                    DIPLOMAREGISTERNO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMAREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO.TextFont.Name = "Arial";
                    DIPLOMAREGISTERNO.TextFont.Bold = true;
                    DIPLOMAREGISTERNO.TextFont.CharSet = 162;
                    DIPLOMAREGISTERNO.Value = @"{#DIPLOMAREGISTERNO#}";

                    TABIPTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 3, 238, 8, false);
                    TABIPTITLE.Name = "TABIPTITLE";
                    TABIPTITLE.Visible = EvetHayirEnum.ehHayir;
                    TABIPTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABIPTITLE.Value = @"{#TITLE#}";

                    NewField17811112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 21, 248, 26, false);
                    NewField17811112.Name = "NewField17811112";
                    NewField17811112.Visible = EvetHayirEnum.ehHayir;
                    NewField17811112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17811112.TextFont.Name = "Arial";
                    NewField17811112.TextFont.Bold = true;
                    NewField17811112.TextFont.CharSet = 162;
                    NewField17811112.Value = @":";

                    NewField121111871 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 26, 248, 31, false);
                    NewField121111871.Name = "NewField121111871";
                    NewField121111871.Visible = EvetHayirEnum.ehHayir;
                    NewField121111871.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121111871.TextFont.Name = "Arial";
                    NewField121111871.TextFont.Bold = true;
                    NewField121111871.TextFont.CharSet = 162;
                    NewField121111871.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    NewField1111172.CalcValue = NewField1111172.Value;
                    NewField12711111.CalcValue = NewField12711111.Value;
                    NewField12711112.CalcValue = NewField12711112.Value;
                    NewField12711113.CalcValue = NewField12711113.Value;
                    NewField17811111.CalcValue = NewField17811111.Value;
                    NewField18811111.CalcValue = NewField18811111.Value;
                    NewField19811111.CalcValue = NewField19811111.Value;
                    NewField10911111.CalcValue = NewField10911111.Value;
                    TOTALDRUGPRICE.CalcValue = @"";
                    DISCOUNT.CalcValue = @"";
                    TOTALSOCIETYLOT.CalcValue = @"";
                    TOTALPATIENTLOT.CalcValue = ParentGroup.FieldSums["PATIENTLOT"].Value.ToString();;
                    NewField12711114.CalcValue = NewField12711114.Value;
                    NewField111111721.CalcValue = NewField111111721.Value;
                    NewField1127111111.CalcValue = NewField1127111111.Value;
                    TOTALPRICEDIFFERENCE.CalcValue = @"";
                    TOTALPATIENTLOT1.CalcValue = ParentGroup.FieldSums["PATIENTLOT"].Value.ToString();;
                    NewField141111721.CalcValue = NewField141111721.Value;
                    NewField1127111141.CalcValue = NewField1127111141.Value;
                    NewField111111722.CalcValue = NewField111111722.Value;
                    NewField1227111111.CalcValue = NewField1227111111.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField12711115.CalcValue = NewField12711115.Value;
                    TITLE_RANK_NAME_SURNAME1.CalcValue = @"";
                    DIPLOMANO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.DiplomaNo) : "");
                    NewField15.CalcValue = NewField15.Value;
                    DIPLOMAREGISTERNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.DiplomaRegisterNo) : "");
                    TABIPTITLE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Title) : "");
                    NewField17811112.CalcValue = NewField17811112.Value;
                    NewField121111871.CalcValue = NewField121111871.Value;
                    return new TTReportObject[] { NewField1111172,NewField12711111,NewField12711112,NewField12711113,NewField17811111,NewField18811111,NewField19811111,NewField10911111,TOTALDRUGPRICE,DISCOUNT,TOTALSOCIETYLOT,TOTALPATIENTLOT,NewField12711114,NewField111111721,NewField1127111111,TOTALPRICEDIFFERENCE,TOTALPATIENTLOT1,NewField141111721,NewField1127111141,NewField111111722,NewField1227111111,NewField14,NewField12711115,TITLE_RANK_NAME_SURNAME1,DIPLOMANO,NewField15,DIPLOMAREGISTERNO,TABIPTITLE,NewField17811112,NewField121111871};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    /*                                       TTObjectContext tto = new TTObjectContext(false);
            Prescription recete = (Prescription)tto.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.Value.ToString()), typeof(Prescription));
            ResUser doktor = (ResUser)tto.GetObject(recete.ProcedureDoctor.ObjectID, typeof(ResUser));
            this.TITLE_RANK_NAME_SURNAME.CalcValue = "";
            this.TITLE_RANK_NAME_SURNAME.CalcValue += (doktor.Title.HasValue ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(doktor.Title.Value)+" " : "");
            this.TITLE_RANK_NAME_SURNAME.CalcValue += (doktor.Rank != null ? doktor.Rank.Name+" " : "");
            this.TITLE_RANK_NAME_SURNAME.CalcValue += (doktor.Name != null ? doktor.Name : "");
            this.TITLE_RANK_NAME_SURNAME.CalcValue += "\r\n";

            string mainSpeciality = "";
            string otherSpecialities = "";
            for(int x = 0; x<doktor.ResourceSpecialities.Count;x++)
            {
                if (doktor.ResourceSpecialities[x].MainSpeciality != null)
                {
                    if (doktor.ResourceSpecialities[x].MainSpeciality.Value)
                    {
                        mainSpeciality += (doktor.ResourceSpecialities[x].Speciality.Name.Contains("Uzm") ? doktor.ResourceSpecialities[x].Speciality.Name : doktor.ResourceSpecialities[x].Speciality.Name + " Uzm.");
                    }
                    else
                    {
                        otherSpecialities += (doktor.ResourceSpecialities[x].Speciality.Name.Contains("Uzm") ? doktor.ResourceSpecialities[x].Speciality.Name + "\r\n" : doktor.ResourceSpecialities[x].Speciality.Name + " Uzm.\r\n");
                    }
                }
            }

            this.TITLE_RANK_NAME_SURNAME.CalcValue += mainSpeciality + "\r\n" + otherSpecialities;*/
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public OutpatientPrescriptionReportByFormat MyParentReport
            {
                get { return (OutpatientPrescriptionReportByFormat)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUG { get {return Body().DRUG;} }
            public TTReportField DOSE { get {return Body().DOSE;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField USAGE { get {return Body().USAGE;} }
            public TTReportField WM { get {return Body().WM;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField DRUGPRICE { get {return Body().DRUGPRICE;} }
            public TTReportField PATIENTLOT { get {return Body().PATIENTLOT;} }
            public TTReportField SOCIETYLOT { get {return Body().SOCIETYLOT;} }
            public TTReportField DRUGEND { get {return Body().DRUGEND;} }
            public TTReportField VATRATE { get {return Body().VATRATE;} }
            public TTReportField PRICEDIFFERENCE { get {return Body().PRICEDIFFERENCE;} }
            public TTReportField DOSEAMOUNT { get {return Body().DOSEAMOUNT;} }
            public TTReportField FREQUENCY { get {return Body().FREQUENCY;} }
            public TTReportField WM1 { get {return Body().WM1;} }
            public TTReportField ROMEN { get {return Body().ROMEN;} }
            public TTReportField DRUG1 { get {return Body().DRUG1;} }
            public TTReportField USAGENOTE { get {return Body().USAGENOTE;} }
            public TTReportField PACKAGEAMOUNT { get {return Body().PACKAGEAMOUNT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField CURRENTPRICE11 { get {return Body().CURRENTPRICE11;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
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

                OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataSet_GetOutpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);    
                return new object[] {(dataSet_GetOutpatientPrescriptionReportQuery==null ? null : dataSet_GetOutpatientPrescriptionReportQuery.ObjectID)};
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
                public OutpatientPrescriptionReportByFormat MyParentReport
                {
                    get { return (OutpatientPrescriptionReportByFormat)ParentReport; }
                }
                
                public TTReportField DRUG;
                public TTReportField DOSE;
                public TTReportField COUNT;
                public TTReportField NewField11;
                public TTReportField USAGE;
                public TTReportField WM;
                public TTReportField UNITPRICE;
                public TTReportField DRUGPRICE;
                public TTReportField PATIENTLOT;
                public TTReportField SOCIETYLOT;
                public TTReportField DRUGEND;
                public TTReportField VATRATE;
                public TTReportField PRICEDIFFERENCE;
                public TTReportField DOSEAMOUNT;
                public TTReportField FREQUENCY;
                public TTReportField WM1;
                public TTReportField ROMEN;
                public TTReportField DRUG1;
                public TTReportField USAGENOTE;
                public TTReportField PACKAGEAMOUNT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportField CURRENTPRICE11;
                public TTReportShape NewLine121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    DRUG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 1, 157, 5, false);
                    DRUG.Name = "DRUG";
                    DRUG.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG.TextFont.Name = "Arial";
                    DRUG.TextFont.CharSet = 162;
                    DRUG.Value = @"";

                    DOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 7, 72, 11, false);
                    DOSE.Name = "DOSE";
                    DOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSE.TextFont.Name = "Arial";
                    DOSE.TextFont.CharSet = 162;
                    DOSE.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 28, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 7, 35, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S=";

                    USAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 7, 157, 11, false);
                    USAGE.Name = "USAGE";
                    USAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USAGE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    USAGE.MultiLine = EvetHayirEnum.ehEvet;
                    USAGE.NoClip = EvetHayirEnum.ehEvet;
                    USAGE.WordBreak = EvetHayirEnum.ehEvet;
                    USAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    USAGE.TextFont.Name = "Arial";
                    USAGE.TextFont.CharSet = 162;
                    USAGE.Value = @"";

                    WM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 7, 225, 12, false);
                    WM.Name = "WM";
                    WM.Visible = EvetHayirEnum.ehHayir;
                    WM.FieldType = ReportFieldTypeEnum.ftVariable;
                    WM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM.TextFont.Size = 8;
                    WM.TextFont.CharSet = 162;
                    WM.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 397, 2, 408, 7, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"";

                    DRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 14, 262, 22, false);
                    DRUGPRICE.Name = "DRUGPRICE";
                    DRUGPRICE.Visible = EvetHayirEnum.ehHayir;
                    DRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGPRICE.TextFormat = @"#,##0.#0";
                    DRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DRUGPRICE.TextFont.Name = "Arial";
                    DRUGPRICE.TextFont.CharSet = 162;
                    DRUGPRICE.Value = @"{#PARTA.CURRENTPRICE#}";

                    PATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 2, 273, 7, false);
                    PATIENTLOT.Name = "PATIENTLOT";
                    PATIENTLOT.Visible = EvetHayirEnum.ehHayir;
                    PATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTLOT.TextFormat = @"#,##0.#0";
                    PATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PATIENTLOT.TextFont.Name = "Arial";
                    PATIENTLOT.TextFont.CharSet = 162;
                    PATIENTLOT.Value = @"{#PARTA.RECEIVEDPRICE#}";

                    SOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 2, 286, 7, false);
                    SOCIETYLOT.Name = "SOCIETYLOT";
                    SOCIETYLOT.Visible = EvetHayirEnum.ehHayir;
                    SOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOCIETYLOT.TextFormat = @"#,##0.#0";
                    SOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SOCIETYLOT.TextFont.Name = "Arial";
                    SOCIETYLOT.TextFont.CharSet = 162;
                    SOCIETYLOT.Value = @"";

                    DRUGEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 287, 2, 296, 7, false);
                    DRUGEND.Name = "DRUGEND";
                    DRUGEND.Visible = EvetHayirEnum.ehHayir;
                    DRUGEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGEND.TextFont.Name = "Arial";
                    DRUGEND.TextFont.CharSet = 162;
                    DRUGEND.Value = @"";

                    VATRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 367, 3, 377, 8, false);
                    VATRATE.Name = "VATRATE";
                    VATRATE.Visible = EvetHayirEnum.ehHayir;
                    VATRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VATRATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    VATRATE.TextFont.Name = "Arial";
                    VATRATE.TextFont.CharSet = 162;
                    VATRATE.Value = @"";

                    PRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 2, 325, 7, false);
                    PRICEDIFFERENCE.Name = "PRICEDIFFERENCE";
                    PRICEDIFFERENCE.Visible = EvetHayirEnum.ehHayir;
                    PRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEDIFFERENCE.TextFormat = @"#,##0.#0";
                    PRICEDIFFERENCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICEDIFFERENCE.TextFont.Name = "Arial";
                    PRICEDIFFERENCE.TextFont.CharSet = 162;
                    PRICEDIFFERENCE.Value = @"";

                    DOSEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 2, 223, 7, false);
                    DOSEAMOUNT.Name = "DOSEAMOUNT";
                    DOSEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    DOSEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSEAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSEAMOUNT.TextFont.Name = "Arial";
                    DOSEAMOUNT.TextFont.CharSet = 162;
                    DOSEAMOUNT.Value = @"{#PARTA.DOSEAMOUNT#}";

                    FREQUENCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 2, 233, 7, false);
                    FREQUENCY.Name = "FREQUENCY";
                    FREQUENCY.Visible = EvetHayirEnum.ehHayir;
                    FREQUENCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FREQUENCY.TextFont.Name = "Arial";
                    FREQUENCY.TextFont.CharSet = 162;
                    FREQUENCY.Value = @"{#PARTA.FREQUENCY#}";

                    WM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 384, 2, 391, 7, false);
                    WM1.Name = "WM1";
                    WM1.Visible = EvetHayirEnum.ehHayir;
                    WM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM1.TextFont.Size = 8;
                    WM1.TextFont.CharSet = 162;
                    WM1.Value = @"X";

                    ROMEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 7, 295, 12, false);
                    ROMEN.Name = "ROMEN";
                    ROMEN.Visible = EvetHayirEnum.ehHayir;
                    ROMEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROMEN.Value = @"";

                    DRUG1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 7, 262, 12, false);
                    DRUG1.Name = "DRUG1";
                    DRUG1.Visible = EvetHayirEnum.ehHayir;
                    DRUG1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG1.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG1.TextFont.Size = 8;
                    DRUG1.TextFont.CharSet = 162;
                    DRUG1.Value = @"{#PARTA.DRUG#}";

                    USAGENOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 7, 244, 12, false);
                    USAGENOTE.Name = "USAGENOTE";
                    USAGENOTE.Visible = EvetHayirEnum.ehHayir;
                    USAGENOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USAGENOTE.Value = @"{#PARTA.USAGENOTE#}";

                    PACKAGEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 8, 329, 13, false);
                    PACKAGEAMOUNT.Name = "PACKAGEAMOUNT";
                    PACKAGEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    PACKAGEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGEAMOUNT.Value = @"{#PARTA.PACKAGEAMOUNT#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 157, 0, 157, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 0, 21, 13, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 0, 197, 13, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTPRICE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 197, 9, false);
                    CURRENTPRICE11.Name = "CURRENTPRICE11";
                    CURRENTPRICE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTPRICE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTPRICE11.Value = @"{#PARTA.CURRENTPRICE#}";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 13, 197, 13, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    DRUG.CalcValue = @"";
                    DOSE.CalcValue = @"";
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    NewField11.CalcValue = NewField11.Value;
                    USAGE.CalcValue = @"";
                    WM.CalcValue = @"";
                    UNITPRICE.CalcValue = @"";
                    DRUGPRICE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.CurrentPrice) : "");
                    PATIENTLOT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.ReceivedPrice) : "");
                    SOCIETYLOT.CalcValue = @"";
                    DRUGEND.CalcValue = @"";
                    VATRATE.CalcValue = @"";
                    PRICEDIFFERENCE.CalcValue = @"";
                    DOSEAMOUNT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.DoseAmount) : "");
                    FREQUENCY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Frequency) : "");
                    WM1.CalcValue = WM1.Value;
                    ROMEN.CalcValue = @"";
                    DRUG1.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Drug) : "");
                    USAGENOTE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.UsageNote) : "");
                    PACKAGEAMOUNT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.PackageAmount) : "");
                    CURRENTPRICE11.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.CurrentPrice) : "");
                    return new TTReportObject[] { DRUG,DOSE,COUNT,NewField11,USAGE,WM,UNITPRICE,DRUGPRICE,PATIENTLOT,SOCIETYLOT,DRUGEND,VATRATE,PRICEDIFFERENCE,DOSEAMOUNT,FREQUENCY,WM1,ROMEN,DRUG1,USAGENOTE,PACKAGEAMOUNT,CURRENTPRICE11};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    switch(FREQUENCY.CalcValue)
            {
                case "Q1H":
                    DOSE.CalcValue = "24x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q2H":
                    DOSE.CalcValue = "12x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q3H":
                    DOSE.CalcValue = "8x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q4H":
                    DOSE.CalcValue = "6x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q6H":
                    DOSE.CalcValue = "4x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q8H":
                    DOSE.CalcValue = "3x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q12H":
                    DOSE.CalcValue = "2x" + DOSEAMOUNT.CalcValue;
                    break;
                case "Q24H":
                    DOSE.CalcValue = "1x" + DOSEAMOUNT.CalcValue;
                    break;
            }
            
            int packageAmount = Convert.ToInt16(PACKAGEAMOUNT.CalcValue);
            //int dose = Convert.ToInt32(DOSEAMOUNT.CalcValue);
            DRUG.CalcValue = DRUG1.CalcValue +  "     D" + TTObjectClasses.Common.LatinToRomen(packageAmount) + "B" ;
            
            USAGE.CalcValue = USAGENOTE.CalcValue;
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

        public OutpatientPrescriptionReportByFormat()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "OUTPATIENTPRESCRIPTIONREPORTBYFORMAT";
            Caption = "Ayaktan Hasta Reçetesi Raporu ";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginTop = 10;
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