
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
    /// XXXXXX Reçete Kağıdı
    /// </summary>
    public partial class PrescriptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PrescriptionReport MyParentReport
            {
                get { return (PrescriptionReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField11113 { get {return Header().NewField11113;} }
            public TTReportField NewField11114 { get {return Header().NewField11114;} }
            public TTReportField NewField11115 { get {return Header().NewField11115;} }
            public TTReportField NewField11119 { get {return Header().NewField11119;} }
            public TTReportField NewField11120 { get {return Header().NewField11120;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField EXTERNALPHARMACY { get {return Header().EXTERNALPHARMACY;} }
            public TTReportField DISCOUNTOFPHARMACY { get {return Header().DISCOUNTOFPHARMACY;} }
            public TTReportField PRESCRIPTIONDATE { get {return Header().PRESCRIPTIONDATE;} }
            public TTReportField DRUGGIVINGDATE { get {return Header().DRUGGIVINGDATE;} }
            public TTReportField PROCEDURESPECIALITY { get {return Header().PROCEDURESPECIALITY;} }
            public TTReportField DIAGNOSIS { get {return Header().DIAGNOSIS;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField PATIENTID { get {return Header().PATIENTID;} }
            public TTReportField REGISTRYNO { get {return Header().REGISTRYNO;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField PROVISIONNO { get {return Header().PROVISIONNO;} }
            public TTReportField PATIENTGROUP { get {return Header().PATIENTGROUP;} }
            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField PMILITARYCLASS { get {return Header().PMILITARYCLASS;} }
            public TTReportField MEDULASAGLIKTESISKODU { get {return Header().MEDULASAGLIKTESISKODU;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportField ERECETENO { get {return Header().ERECETENO;} }
            public TTReportField NewField121111 { get {return Header().NewField121111;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
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
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportField NewField111111722 { get {return Footer().NewField111111722;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField11311 { get {return Footer().NewField11311;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField TITLE_RANK_NAME_SURNAME { get {return Footer().TITLE_RANK_NAME_SURNAME;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField DIPLOMAREGISTERNO { get {return Footer().DIPLOMAREGISTERNO;} }
            public TTReportField TABIPTITLE { get {return Footer().TABIPTITLE;} }
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
                public PrescriptionReport MyParentReport
                {
                    get { return (PrescriptionReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField LOGO;
                public TTReportField HOSPITALNAME;
                public TTReportField NewField1;
                public TTReportField NewField1111;
                public TTReportField NewField11112;
                public TTReportField NewField11113;
                public TTReportField NewField11114;
                public TTReportField NewField11115;
                public TTReportField NewField11119;
                public TTReportField NewField11120;
                public TTReportField PAYER;
                public TTReportField EXTERNALPHARMACY;
                public TTReportField DISCOUNTOFPHARMACY;
                public TTReportField PRESCRIPTIONDATE;
                public TTReportField DRUGGIVINGDATE;
                public TTReportField PROCEDURESPECIALITY;
                public TTReportField DIAGNOSIS;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTID;
                public TTReportField REGISTRYNO;
                public TTReportField PROTOCOLNO;
                public TTReportField PROVISIONNO;
                public TTReportField PATIENTGROUP;
                public TTReportField HOSPITAL;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportField NewField2;
                public TTReportField PMILITARYCLASS;
                public TTReportField MEDULASAGLIKTESISKODU;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportField ERECETENO;
                public TTReportField NewField121111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 80;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 72, 138, 77, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"GEREKLİ TEDAVİ (İLAÇ, PROTEZ VE TBB.MLZ.)";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 11, 344, 31, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.TextFont.Name = "Arial";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 8, 138, 14, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 11;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"XXXXXX REÇETE KAĞIDI";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 44, 138, 53, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"DÜZENLEYEN SAĞLIK BİRLİK/KURUM ADI:";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 35, 138, 44, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"REÇETE TANZİM TARİHİ:";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 53, 138, 71, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Size = 8;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"TANI:";

                    NewField11113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 35, 78, 44, false);
                    NewField11113.Name = "NewField11113";
                    NewField11113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11113.TextFont.Name = "Arial";
                    NewField11113.TextFont.Size = 8;
                    NewField11113.TextFont.Bold = true;
                    NewField11113.TextFont.CharSet = 162;
                    NewField11113.Value = @" HASTANIN ADI SOYADI:";

                    NewField11114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 44, 78, 53, false);
                    NewField11114.Name = "NewField11114";
                    NewField11114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114.TextFont.Name = "Arial";
                    NewField11114.TextFont.Size = 8;
                    NewField11114.TextFont.Bold = true;
                    NewField11114.TextFont.CharSet = 162;
                    NewField11114.Value = @" T.C.KİMLİK NO:";

                    NewField11115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 62, 78, 71, false);
                    NewField11115.Name = "NewField11115";
                    NewField11115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11115.TextFont.Name = "Arial";
                    NewField11115.TextFont.Size = 8;
                    NewField11115.TextFont.Bold = true;
                    NewField11115.TextFont.CharSet = 162;
                    NewField11115.Value = @" HASTANIN BAĞLI OLDUĞU KUVVET :";

                    NewField11119 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 6, 282, 16, false);
                    NewField11119.Name = "NewField11119";
                    NewField11119.Visible = EvetHayirEnum.ehHayir;
                    NewField11119.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11119.TextFont.Name = "Arial";
                    NewField11119.TextFont.Size = 8;
                    NewField11119.TextFont.Bold = true;
                    NewField11119.TextFont.CharSet = 162;
                    NewField11119.Value = @"KURUM SİCİL/TAHSİS NO:";

                    NewField11120 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 53, 78, 62, false);
                    NewField11120.Name = "NewField11120";
                    NewField11120.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120.TextFont.Name = "Arial";
                    NewField11120.TextFont.Size = 8;
                    NewField11120.TextFont.Bold = true;
                    NewField11120.TextFont.CharSet = 162;
                    NewField11120.Value = @" PROTOKOL/KARANTİNA NO:";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 48, 136, 52, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYER#}";

                    EXTERNALPHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 43, 301, 48, false);
                    EXTERNALPHARMACY.Name = "EXTERNALPHARMACY";
                    EXTERNALPHARMACY.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALPHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALPHARMACY.WordBreak = EvetHayirEnum.ehEvet;
                    EXTERNALPHARMACY.TextFont.Name = "Arial";
                    EXTERNALPHARMACY.TextFont.CharSet = 162;
                    EXTERNALPHARMACY.Value = @"{#EXTERNALPHARMACY#}";

                    DISCOUNTOFPHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 48, 216, 53, false);
                    DISCOUNTOFPHARMACY.Name = "DISCOUNTOFPHARMACY";
                    DISCOUNTOFPHARMACY.Visible = EvetHayirEnum.ehHayir;
                    DISCOUNTOFPHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCOUNTOFPHARMACY.TextFont.Name = "Arial";
                    DISCOUNTOFPHARMACY.TextFont.CharSet = 162;
                    DISCOUNTOFPHARMACY.Value = @"";

                    PRESCRIPTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 39, 128, 43, false);
                    PRESCRIPTIONDATE.Name = "PRESCRIPTIONDATE";
                    PRESCRIPTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONDATE.TextFormat = @"dd/MM/yyyy";
                    PRESCRIPTIONDATE.TextFont.Size = 8;
                    PRESCRIPTIONDATE.TextFont.CharSet = 162;
                    PRESCRIPTIONDATE.Value = @"{#PRESCRIPTIONDATE#}";

                    DRUGGIVINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 53, 285, 58, false);
                    DRUGGIVINGDATE.Name = "DRUGGIVINGDATE";
                    DRUGGIVINGDATE.Visible = EvetHayirEnum.ehHayir;
                    DRUGGIVINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGGIVINGDATE.TextFormat = @"dd/MM/yyyy";
                    DRUGGIVINGDATE.TextFont.Name = "Arial";
                    DRUGGIVINGDATE.TextFont.CharSet = 162;
                    DRUGGIVINGDATE.Value = @"{#DRUGGIVINGDATE#}";

                    PROCEDURESPECIALITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 58, 301, 63, false);
                    PROCEDURESPECIALITY.Name = "PROCEDURESPECIALITY";
                    PROCEDURESPECIALITY.Visible = EvetHayirEnum.ehHayir;
                    PROCEDURESPECIALITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURESPECIALITY.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDURESPECIALITY.TextFont.Name = "Arial";
                    PROCEDURESPECIALITY.TextFont.CharSet = 162;
                    PROCEDURESPECIALITY.Value = @"{#PROCEDURESPECIALITY#}";

                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 57, 137, 70, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.TextFont.Size = 8;
                    DIAGNOSIS.TextFont.CharSet = 162;
                    DIAGNOSIS.Value = @"";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 39, 73, 43, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Size = 8;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENT#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 48, 59, 52, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.TextFont.Size = 8;
                    PATIENTID.TextFont.CharSet = 162;
                    PATIENTID.Value = @"{#UNIQUEREFNO#}";

                    REGISTRYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 11, 274, 15, false);
                    REGISTRYNO.Name = "REGISTRYNO";
                    REGISTRYNO.Visible = EvetHayirEnum.ehHayir;
                    REGISTRYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRYNO.TextFont.Size = 8;
                    REGISTRYNO.TextFont.CharSet = 162;
                    REGISTRYNO.Value = @"{#EMPLOYMENTRECORDID#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 57, 76, 61, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    PROVISIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 33, 204, 38, false);
                    PROVISIONNO.Name = "PROVISIONNO";
                    PROVISIONNO.Visible = EvetHayirEnum.ehHayir;
                    PROVISIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVISIONNO.TextFont.Name = "Arial";
                    PROVISIONNO.TextFont.CharSet = 162;
                    PROVISIONNO.Value = @"{#SPTSPROVISIONID#}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 23, 289, 28, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.Visible = EvetHayirEnum.ehHayir;
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP.TextFont.Name = "Arial";
                    PATIENTGROUP.TextFont.CharSet = 162;
                    PATIENTGROUP.Value = @"{#PATIENTGROUP#}";

                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 14, 138, 30, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITAL.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 11;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 138, 67, 138, 82, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 71, 5, 81, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 76, 138, 80, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Rp.";

                    PMILITARYCLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 66, 76, 70, false);
                    PMILITARYCLASS.Name = "PMILITARYCLASS";
                    PMILITARYCLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PMILITARYCLASS.ObjectDefName = "ForcesCommand";
                    PMILITARYCLASS.DataMember = "NAME";
                    PMILITARYCLASS.TextFont.Size = 8;
                    PMILITARYCLASS.TextFont.CharSet = 162;
                    PMILITARYCLASS.Value = @"{#PATIENTFORCE#}";

                    MEDULASAGLIKTESISKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 28, 93, 34, false);
                    MEDULASAGLIKTESISKODU.Name = "MEDULASAGLIKTESISKODU";
                    MEDULASAGLIKTESISKODU.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULASAGLIKTESISKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MEDULASAGLIKTESISKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEDULASAGLIKTESISKODU.TextFont.Size = 9;
                    MEDULASAGLIKTESISKODU.TextFont.CharSet = 162;
                    MEDULASAGLIKTESISKODU.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MEDULASAGLIKTESISKODU"", """")";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 8, 5, 38, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 138, 8, 138, 37, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 8, 138, 8, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    ERECETENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 9, 47, 13, false);
                    ERECETENO.Name = "ERECETENO";
                    ERECETENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERECETENO.TextFormat = @"dd/MM/yyyy";
                    ERECETENO.TextFont.Size = 8;
                    ERECETENO.TextFont.CharSet = 162;
                    ERECETENO.Value = @"{#ERECETENO#}";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 25, 15, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 8;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"EReçete No :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    LOGO.CalcValue = LOGO.Value;
                    HOSPITALNAME.CalcValue = HOSPITALNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField11113.CalcValue = NewField11113.Value;
                    NewField11114.CalcValue = NewField11114.Value;
                    NewField11115.CalcValue = NewField11115.Value;
                    NewField11119.CalcValue = NewField11119.Value;
                    NewField11120.CalcValue = NewField11120.Value;
                    PAYER.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Payer) : "");
                    EXTERNALPHARMACY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Externalpharmacy) : "");
                    DISCOUNTOFPHARMACY.CalcValue = @"";
                    PRESCRIPTIONDATE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Prescriptiondate) : "");
                    DRUGGIVINGDATE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Druggivingdate) : "");
                    PROCEDURESPECIALITY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Procedurespeciality) : "");
                    DIAGNOSIS.CalcValue = @"";
                    PATIENTNAME.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Patient) : "");
                    PATIENTID.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.UniqueRefNo) : "");
                    REGISTRYNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Employmentrecordid) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.HospitalProtocolNo) : "");
                    PROVISIONNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.SPTSProvisionID) : "");
                    PATIENTGROUP.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Patientgroup) : "");
                    PATIENTGROUP.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    PMILITARYCLASS.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Patientforce) : "");
                    PMILITARYCLASS.PostFieldValueCalculation();
                    ERECETENO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.EReceteNo) : "");
                    NewField121111.CalcValue = NewField121111.Value;
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    MEDULASAGLIKTESISKODU.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    return new TTReportObject[] { NewField11,LOGO,HOSPITALNAME,NewField1,NewField1111,NewField11112,NewField11113,NewField11114,NewField11115,NewField11119,NewField11120,PAYER,EXTERNALPHARMACY,DISCOUNTOFPHARMACY,PRESCRIPTIONDATE,DRUGGIVINGDATE,PROCEDURESPECIALITY,DIAGNOSIS,PATIENTNAME,PATIENTID,REGISTRYNO,PROTOCOLNO,PROVISIONNO,PATIENTGROUP,NewField2,PMILITARYCLASS,ERECETENO,NewField121111,HOSPITAL,MEDULASAGLIKTESISKODU};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((PrescriptionReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
           OutPatientPrescription deneme = (OutPatientPrescription)context.GetObject(new Guid(objectID),"OutPatientPrescription");
           Episode episode = deneme.Episode;
           string diagnoseName =""; 
           foreach (DiagnosisGrid diagnose in episode.Diagnosis)
           {
               diagnoseName += (diagnose.Diagnose).ToString() + " \r\n";
                   
           }
           DIAGNOSIS.CalcValue = diagnoseName + "  \r\n";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PrescriptionReport MyParentReport
                {
                    get { return (PrescriptionReport)ParentReport; }
                }
                
                public TTReportField NewField4;
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
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportField NewField111111722;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField14;
                public TTReportField TITLE_RANK_NAME_SURNAME;
                public TTReportField DIPLOMANO;
                public TTReportField NewField5;
                public TTReportField DIPLOMAREGISTERNO;
                public TTReportField TABIPTITLE; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 58;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 19, 117, 23, false);
                    NewField4.Name = "NewField4";
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Size = 7;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"D.Nu. :";

                    NewField1111172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 138, 6, false);
                    NewField1111172.Name = "NewField1111172";
                    NewField1111172.TextFont.Size = 7;
                    NewField1111172.TextFont.Bold = true;
                    NewField1111172.TextFont.CharSet = 162;
                    NewField1111172.Value = @"TABİP KAŞESİ (ISLAK İMZA)";

                    NewField12711111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 24, 138, 36, false);
                    NewField12711111.Name = "NewField12711111";
                    NewField12711111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12711111.TextFont.Size = 8;
                    NewField12711111.TextFont.Bold = true;
                    NewField12711111.TextFont.CharSet = 162;
                    NewField12711111.Value = @" REÇETE MUHTEVİYATINI TESLİM ALANIN ADI SOYADI VE  İMZASI:";

                    NewField12711112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 8, 193, 13, false);
                    NewField12711112.Name = "NewField12711112";
                    NewField12711112.Visible = EvetHayirEnum.ehHayir;
                    NewField12711112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711112.TextFont.Name = "Arial";
                    NewField12711112.TextFont.Bold = true;
                    NewField12711112.TextFont.CharSet = 162;
                    NewField12711112.Value = @"İskonto";

                    NewField12711113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 13, 193, 18, false);
                    NewField12711113.Name = "NewField12711113";
                    NewField12711113.Visible = EvetHayirEnum.ehHayir;
                    NewField12711113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711113.TextFont.Name = "Arial";
                    NewField12711113.TextFont.Bold = true;
                    NewField12711113.TextFont.CharSet = 162;
                    NewField12711113.Value = @"Toplam Kurum Payı";

                    NewField17811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 1, 254, 6, false);
                    NewField17811111.Name = "NewField17811111";
                    NewField17811111.Visible = EvetHayirEnum.ehHayir;
                    NewField17811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17811111.TextFont.Name = "Arial";
                    NewField17811111.TextFont.Bold = true;
                    NewField17811111.TextFont.CharSet = 162;
                    NewField17811111.Value = @":";

                    NewField18811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 3, 195, 8, false);
                    NewField18811111.Name = "NewField18811111";
                    NewField18811111.Visible = EvetHayirEnum.ehHayir;
                    NewField18811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18811111.TextFont.Name = "Arial";
                    NewField18811111.TextFont.Bold = true;
                    NewField18811111.TextFont.CharSet = 162;
                    NewField18811111.Value = @":";

                    NewField19811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 8, 195, 13, false);
                    NewField19811111.Name = "NewField19811111";
                    NewField19811111.Visible = EvetHayirEnum.ehHayir;
                    NewField19811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19811111.TextFont.Name = "Arial";
                    NewField19811111.TextFont.Bold = true;
                    NewField19811111.TextFont.CharSet = 162;
                    NewField19811111.Value = @":";

                    NewField10911111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 13, 195, 18, false);
                    NewField10911111.Name = "NewField10911111";
                    NewField10911111.Visible = EvetHayirEnum.ehHayir;
                    NewField10911111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10911111.TextFont.Name = "Arial";
                    NewField10911111.TextFont.Bold = true;
                    NewField10911111.TextFont.CharSet = 162;
                    NewField10911111.Value = @":";

                    TOTALDRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 1, 283, 6, false);
                    TOTALDRUGPRICE.Name = "TOTALDRUGPRICE";
                    TOTALDRUGPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDRUGPRICE.TextFormat = @"#,##0.#0";
                    TOTALDRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDRUGPRICE.TextFont.Name = "Arial";
                    TOTALDRUGPRICE.TextFont.Bold = true;
                    TOTALDRUGPRICE.TextFont.CharSet = 162;
                    TOTALDRUGPRICE.Value = @"{@sumof(DRUGPRICE)@}";

                    DISCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 8, 224, 13, false);
                    DISCOUNT.Name = "DISCOUNT";
                    DISCOUNT.Visible = EvetHayirEnum.ehHayir;
                    DISCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCOUNT.TextFormat = @"#,##0.#0";
                    DISCOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISCOUNT.TextFont.Name = "Arial";
                    DISCOUNT.TextFont.CharSet = 162;
                    DISCOUNT.Value = @"";

                    TOTALSOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 13, 224, 18, false);
                    TOTALSOCIETYLOT.Name = "TOTALSOCIETYLOT";
                    TOTALSOCIETYLOT.Visible = EvetHayirEnum.ehHayir;
                    TOTALSOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALSOCIETYLOT.TextFormat = @"#,##0.#0";
                    TOTALSOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALSOCIETYLOT.TextFont.Name = "Arial";
                    TOTALSOCIETYLOT.TextFont.Bold = true;
                    TOTALSOCIETYLOT.TextFont.CharSet = 162;
                    TOTALSOCIETYLOT.Value = @"";

                    TOTALPATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 3, 224, 8, false);
                    TOTALPATIENTLOT.Name = "TOTALPATIENTLOT";
                    TOTALPATIENTLOT.Visible = EvetHayirEnum.ehHayir;
                    TOTALPATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPATIENTLOT.TextFormat = @"#,##0.#0";
                    TOTALPATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPATIENTLOT.TextFont.Name = "Arial";
                    TOTALPATIENTLOT.TextFont.CharSet = 162;
                    TOTALPATIENTLOT.Value = @"{@sumof(PATIENTLOT)@}";

                    NewField12711114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 23, 255, 28, false);
                    NewField12711114.Name = "NewField12711114";
                    NewField12711114.Visible = EvetHayirEnum.ehHayir;
                    NewField12711114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711114.TextFont.Name = "Arial";
                    NewField12711114.TextFont.Bold = true;
                    NewField12711114.TextFont.CharSet = 162;
                    NewField12711114.Value = @"Aldığınız ilaçlar için ödemeniz gereken toplam fiyat farkı : ";

                    NewField111111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 28, 230, 33, false);
                    NewField111111721.Name = "NewField111111721";
                    NewField111111721.Visible = EvetHayirEnum.ehHayir;
                    NewField111111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111721.TextFont.Name = "Arial";
                    NewField111111721.TextFont.Bold = true;
                    NewField111111721.TextFont.CharSet = 162;
                    NewField111111721.Value = @"Aldığınız ilaçların hasta katılım payı tutarı : ";

                    NewField1127111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 33, 262, 38, false);
                    NewField1127111111.Name = "NewField1127111111";
                    NewField1127111111.Visible = EvetHayirEnum.ehHayir;
                    NewField1127111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111111.TextFont.Name = "Arial";
                    NewField1127111111.TextFont.Bold = true;
                    NewField1127111111.TextFont.CharSet = 162;
                    NewField1127111111.Value = @"Reçete Sahibinin İmzası";

                    TOTALPRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 23, 289, 28, false);
                    TOTALPRICEDIFFERENCE.Name = "TOTALPRICEDIFFERENCE";
                    TOTALPRICEDIFFERENCE.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICEDIFFERENCE.TextFont.Name = "Arial";
                    TOTALPRICEDIFFERENCE.TextFont.CharSet = 162;
                    TOTALPRICEDIFFERENCE.Value = @"";

                    TOTALPATIENTLOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 28, 258, 33, false);
                    TOTALPATIENTLOT1.Name = "TOTALPATIENTLOT1";
                    TOTALPATIENTLOT1.Visible = EvetHayirEnum.ehHayir;
                    TOTALPATIENTLOT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPATIENTLOT1.TextFormat = @"#,##0.#0";
                    TOTALPATIENTLOT1.TextFont.Name = "Arial";
                    TOTALPATIENTLOT1.TextFont.CharSet = 162;
                    TOTALPATIENTLOT1.Value = @"{@sumof(PATIENTLOT)@}";

                    NewField141111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 33, 273, 38, false);
                    NewField141111721.Name = "NewField141111721";
                    NewField141111721.Visible = EvetHayirEnum.ehHayir;
                    NewField141111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141111721.TextFont.Name = "Arial";
                    NewField141111721.TextFont.CharSet = 162;
                    NewField141111721.Value = @"TL'dir.";

                    NewField1127111141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 28, 268, 33, false);
                    NewField1127111141.Name = "NewField1127111141";
                    NewField1127111141.Visible = EvetHayirEnum.ehHayir;
                    NewField1127111141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111141.TextFont.Name = "Arial";
                    NewField1127111141.TextFont.CharSet = 162;
                    NewField1127111141.Value = @"TL'dir.";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, -67, 5, 28, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 138, -66, 138, 49, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111111722 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 36, 138, 49, false);
                    NewField111111722.Name = "NewField111111722";
                    NewField111111722.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111722.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111722.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111722.TextFont.Size = 8;
                    NewField111111722.TextFont.Bold = true;
                    NewField111111722.TextFont.CharSet = 162;
                    NewField111111722.Value = @" BAŞTABİP ONAY (KAŞE- İMZA):               
 ""YATAN HASTA, ECZANEMİZDE YOKTUR."" Kaşesi Basılacaktır.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 45, 296, 50, false);
                    NewField3.Name = "NewField3";
                    NewField3.Visible = EvetHayirEnum.ehHayir;
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.TextFont.Size = 7;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"(2) Günübirlik Tedavide Kullanılan İlaçlar İçin Düzenlendiğinde  ""GÜNÜBİRLİK TEDAVİ İÇİNDİR"" Kaşesi Basılacaktır.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 50, 296, 55, false);
                    NewField13.Name = "NewField13";
                    NewField13.Visible = EvetHayirEnum.ehHayir;
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Size = 7;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"(3) Asistanlar İçin İhtisas Yapılan Uzm.Dalı, Tabibin Dip.No., Sağlık Bakanlığınca Verilen Doktor Diploma Tescil No. yazılacaktır.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 55, 296, 60, false);
                    NewField131.Name = "NewField131";
                    NewField131.Visible = EvetHayirEnum.ehHayir;
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Size = 7;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"(4) Sosyal Güvencesi Bulunmayan Hastalar İçin ""XXXXXX'YE FATURA EDİLEMEZ"" Kaşesi Basılacaktır.";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 60, 296, 68, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.Visible = EvetHayirEnum.ehHayir;
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1131.TextFont.Size = 7;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"(5) Diğer Ülkelerle Yapılan Sosyal Güvenlik Sözleşmeleri Kapsamında Sağlık Hizmeti Verilen Kişiler İçin Reçete Düzenlendiğinde ""Hastanın Statüsü"" bölümünde ilgili ülke adı belirtilecektir. ";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 68, 296, 76, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.Visible = EvetHayirEnum.ehHayir;
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11311.TextFont.Size = 7;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"(6) Ayakta Tedavilerde Sağlık Teşkili Tarafından Verilemeyen İlaçlar İçin ""?.... Kalem İlaçlar Yoktur."" Kaşesi ve İmzası, Birlik/Kurum Tarafından Reçete Arkasına Yapılacaktır. Baştabip Onay ve Birlik Mühürü Aranmayacaktır.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 37, 296, 45, false);
                    NewField14.Name = "NewField14";
                    NewField14.Visible = EvetHayirEnum.ehHayir;
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Size = 7;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"(1) Ayaktan Hasta Reçetelerinde Kurum Baştabibinin Onayı ve Mührü Aranmayacak, Ancak Yatan Hasta Reçetesi Kurum Tarafından Temin Edilemediği Takdirde ""YATAN HASTA, ECZANEMİZDE YOKTUR"" Kaşesi Basılacaktır.";

                    TITLE_RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 6, 138, 19, false);
                    TITLE_RANK_NAME_SURNAME.Name = "TITLE_RANK_NAME_SURNAME";
                    TITLE_RANK_NAME_SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE_RANK_NAME_SURNAME.MultiLine = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.NoClip = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.WordBreak = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    TITLE_RANK_NAME_SURNAME.TextFont.Size = 7;
                    TITLE_RANK_NAME_SURNAME.TextFont.Bold = true;
                    TITLE_RANK_NAME_SURNAME.TextFont.CharSet = 162;
                    TITLE_RANK_NAME_SURNAME.Value = @"";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 19, 115, 23, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Size = 7;
                    DIPLOMANO.TextFont.CharSet = 162;
                    DIPLOMANO.Value = @"{#DIPLOMANO#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 19, 138, 23, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 7;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"D.Tes.Nu.:";

                    DIPLOMAREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 19, 136, 23, false);
                    DIPLOMAREGISTERNO.Name = "DIPLOMAREGISTERNO";
                    DIPLOMAREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO.TextFont.Size = 7;
                    DIPLOMAREGISTERNO.TextFont.CharSet = 162;
                    DIPLOMAREGISTERNO.Value = @"{#DIPLOMAREGISTERNO#}";

                    TABIPTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 2, 176, 7, false);
                    TABIPTITLE.Name = "TABIPTITLE";
                    TABIPTITLE.Visible = EvetHayirEnum.ehHayir;
                    TABIPTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABIPTITLE.Value = @"{#TITLE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    NewField4.CalcValue = NewField4.Value;
                    NewField1111172.CalcValue = NewField1111172.Value;
                    NewField12711111.CalcValue = NewField12711111.Value;
                    NewField12711112.CalcValue = NewField12711112.Value;
                    NewField12711113.CalcValue = NewField12711113.Value;
                    NewField17811111.CalcValue = NewField17811111.Value;
                    NewField18811111.CalcValue = NewField18811111.Value;
                    NewField19811111.CalcValue = NewField19811111.Value;
                    NewField10911111.CalcValue = NewField10911111.Value;
                    TOTALDRUGPRICE.CalcValue = ParentGroup.FieldSums["DRUGPRICE"].Value.ToString();;
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
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField14.CalcValue = NewField14.Value;
                    TITLE_RANK_NAME_SURNAME.CalcValue = @"";
                    DIPLOMANO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.DiplomaNo) : "");
                    NewField5.CalcValue = NewField5.Value;
                    DIPLOMAREGISTERNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.DiplomaRegisterNo) : "");
                    TABIPTITLE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Title) : "");
                    return new TTReportObject[] { NewField4,NewField1111172,NewField12711111,NewField12711112,NewField12711113,NewField17811111,NewField18811111,NewField19811111,NewField10911111,TOTALDRUGPRICE,DISCOUNT,TOTALSOCIETYLOT,TOTALPATIENTLOT,NewField12711114,NewField111111721,NewField1127111111,TOTALPRICEDIFFERENCE,TOTALPATIENTLOT1,NewField141111721,NewField1127111141,NewField111111722,NewField3,NewField13,NewField131,NewField1131,NewField11311,NewField14,TITLE_RANK_NAME_SURNAME,DIPLOMANO,NewField5,DIPLOMAREGISTERNO,TABIPTITLE};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext tto = new TTObjectContext(false);
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

                    this.TITLE_RANK_NAME_SURNAME.CalcValue += mainSpeciality + "\r\n" + otherSpecialities;


                    //this.TITLE_RANK_NAME_SURNAME.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(recete.ProcedureDoctor.Title.Value).DisplayText + " " + recete.ProcedureDoctor.Rank.ToString() + " " + recete.ProcedureDoctor.Name;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionReport MyParentReport
            {
                get { return (PrescriptionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUG { get {return Body().DRUG;} }
            public TTReportField DOSE { get {return Body().DOSE;} }
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
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField ROMEN { get {return Body().ROMEN;} }
            public TTReportField DRUG1 { get {return Body().DRUG1;} }
            public TTReportField USAGE { get {return Body().USAGE;} }
            public TTReportField USAGENOTE { get {return Body().USAGENOTE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField PACKAGEAMOUNT { get {return Body().PACKAGEAMOUNT;} }
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
                public PrescriptionReport MyParentReport
                {
                    get { return (PrescriptionReport)ParentReport; }
                }
                
                public TTReportField DRUG;
                public TTReportField DOSE;
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
                public TTReportField COUNT;
                public TTReportField NewField1;
                public TTReportField ROMEN;
                public TTReportField DRUG1;
                public TTReportField USAGE;
                public TTReportField USAGENOTE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField PACKAGEAMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    DRUG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 138, 4, false);
                    DRUG.Name = "DRUG";
                    DRUG.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG.TextFont.Size = 8;
                    DRUG.TextFont.CharSet = 162;
                    DRUG.Value = @"";

                    DOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 5, 42, 9, false);
                    DOSE.Name = "DOSE";
                    DOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSE.TextFont.Size = 8;
                    DOSE.TextFont.CharSet = 162;
                    DOSE.Value = @"";

                    WM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 1, 286, 6, false);
                    WM.Name = "WM";
                    WM.Visible = EvetHayirEnum.ehHayir;
                    WM.FieldType = ReportFieldTypeEnum.ftVariable;
                    WM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM.TextFont.Size = 8;
                    WM.TextFont.CharSet = 162;
                    WM.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 190, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#PARTA.UNITPRICE#}";

                    DRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 1, 202, 6, false);
                    DRUGPRICE.Name = "DRUGPRICE";
                    DRUGPRICE.Visible = EvetHayirEnum.ehHayir;
                    DRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGPRICE.TextFormat = @"#,##0.#0";
                    DRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DRUGPRICE.TextFont.Name = "Arial";
                    DRUGPRICE.TextFont.CharSet = 162;
                    DRUGPRICE.Value = @"{#PARTA.PRICE#}";

                    PATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 1, 214, 6, false);
                    PATIENTLOT.Name = "PATIENTLOT";
                    PATIENTLOT.Visible = EvetHayirEnum.ehHayir;
                    PATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTLOT.TextFormat = @"#,##0.#0";
                    PATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PATIENTLOT.TextFont.Name = "Arial";
                    PATIENTLOT.TextFont.CharSet = 162;
                    PATIENTLOT.Value = @"{#PARTA.RECEIVEDPRICE#}";

                    SOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 227, 6, false);
                    SOCIETYLOT.Name = "SOCIETYLOT";
                    SOCIETYLOT.Visible = EvetHayirEnum.ehHayir;
                    SOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOCIETYLOT.TextFormat = @"#,##0.#0";
                    SOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SOCIETYLOT.TextFont.Name = "Arial";
                    SOCIETYLOT.TextFont.CharSet = 162;
                    SOCIETYLOT.Value = @"";

                    DRUGEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 1, 237, 6, false);
                    DRUGEND.Name = "DRUGEND";
                    DRUGEND.Visible = EvetHayirEnum.ehHayir;
                    DRUGEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGEND.TextFont.Name = "Arial";
                    DRUGEND.TextFont.CharSet = 162;
                    DRUGEND.Value = @"";

                    VATRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 1, 248, 6, false);
                    VATRATE.Name = "VATRATE";
                    VATRATE.Visible = EvetHayirEnum.ehHayir;
                    VATRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VATRATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    VATRATE.TextFont.Name = "Arial";
                    VATRATE.TextFont.CharSet = 162;
                    VATRATE.Value = @"";

                    PRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 1, 266, 6, false);
                    PRICEDIFFERENCE.Name = "PRICEDIFFERENCE";
                    PRICEDIFFERENCE.Visible = EvetHayirEnum.ehHayir;
                    PRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEDIFFERENCE.TextFormat = @"#,##0.#0";
                    PRICEDIFFERENCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICEDIFFERENCE.TextFont.Name = "Arial";
                    PRICEDIFFERENCE.TextFont.CharSet = 162;
                    PRICEDIFFERENCE.Value = @"";

                    DOSEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 1, 164, 6, false);
                    DOSEAMOUNT.Name = "DOSEAMOUNT";
                    DOSEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    DOSEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSEAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSEAMOUNT.TextFont.Name = "Arial";
                    DOSEAMOUNT.TextFont.CharSet = 162;
                    DOSEAMOUNT.Value = @"{#PARTA.DOSEAMOUNT#}";

                    FREQUENCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 1, 174, 6, false);
                    FREQUENCY.Name = "FREQUENCY";
                    FREQUENCY.Visible = EvetHayirEnum.ehHayir;
                    FREQUENCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FREQUENCY.TextFont.Name = "Arial";
                    FREQUENCY.TextFont.CharSet = 162;
                    FREQUENCY.Value = @"{#PARTA.FREQUENCY#}";

                    WM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 1, 275, 6, false);
                    WM1.Name = "WM1";
                    WM1.Visible = EvetHayirEnum.ehHayir;
                    WM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM1.TextFont.Size = 8;
                    WM1.TextFont.CharSet = 162;
                    WM1.Value = @"X";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 15, 4, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Size = 8;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 5, 21, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S=";

                    ROMEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 327, 1, 356, 6, false);
                    ROMEN.Name = "ROMEN";
                    ROMEN.Visible = EvetHayirEnum.ehHayir;
                    ROMEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROMEN.Value = @"";

                    DRUG1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 1, 323, 6, false);
                    DRUG1.Name = "DRUG1";
                    DRUG1.Visible = EvetHayirEnum.ehHayir;
                    DRUG1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG1.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG1.TextFont.Size = 8;
                    DRUG1.TextFont.CharSet = 162;
                    DRUG1.Value = @"{#PARTA.DRUG#}";

                    USAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 5, 138, 9, false);
                    USAGE.Name = "USAGE";
                    USAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USAGE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    USAGE.MultiLine = EvetHayirEnum.ehEvet;
                    USAGE.NoClip = EvetHayirEnum.ehEvet;
                    USAGE.WordBreak = EvetHayirEnum.ehEvet;
                    USAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    USAGE.TextFont.Size = 8;
                    USAGE.TextFont.CharSet = 162;
                    USAGE.Value = @"";

                    USAGENOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 1, 305, 6, false);
                    USAGENOTE.Name = "USAGENOTE";
                    USAGENOTE.Visible = EvetHayirEnum.ehHayir;
                    USAGENOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USAGENOTE.Value = @"{#PARTA.USAGENOTE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 138, -1, 138, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, -1, 5, 11, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PACKAGEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 361, 2, 390, 7, false);
                    PACKAGEAMOUNT.Name = "PACKAGEAMOUNT";
                    PACKAGEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    PACKAGEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGEAMOUNT.Value = @"{#PARTA.PACKAGEAMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    DRUG.CalcValue = @"";
                    DOSE.CalcValue = @"";
                    WM.CalcValue = @"";
                    UNITPRICE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.UnitPrice) : "");
                    DRUGPRICE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Price) : "");
                    PATIENTLOT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.ReceivedPrice) : "");
                    SOCIETYLOT.CalcValue = @"";
                    DRUGEND.CalcValue = @"";
                    VATRATE.CalcValue = @"";
                    PRICEDIFFERENCE.CalcValue = @"";
                    DOSEAMOUNT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.DoseAmount) : "");
                    FREQUENCY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Frequency) : "");
                    WM1.CalcValue = WM1.Value;
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    ROMEN.CalcValue = @"";
                    DRUG1.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Drug) : "");
                    USAGE.CalcValue = @"";
                    USAGENOTE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.UsageNote) : "");
                    PACKAGEAMOUNT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.PackageAmount) : "");
                    return new TTReportObject[] { DRUG,DOSE,WM,UNITPRICE,DRUGPRICE,PATIENTLOT,SOCIETYLOT,DRUGEND,VATRATE,PRICEDIFFERENCE,DOSEAMOUNT,FREQUENCY,WM1,COUNT,NewField1,ROMEN,DRUG1,USAGE,USAGENOTE,PACKAGEAMOUNT};
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
            DRUG.CalcValue = DRUG1.CalcValue + "     D" + TTObjectClasses.Common.LatinToRomen(packageAmount) + "B (" +TTReportTool.Common.SpellNumber(packageAmount.ToString())+")";
            
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

        public PrescriptionReport()
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
            Name = "PRESCRIPTIONREPORT";
            Caption = "XXXXXX Reçete Kağıdı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 11;
            UserMarginLeft = 3;
            UserMarginTop = 6;
            p_PageWidth = 148;
            p_PageHeight = 210;
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