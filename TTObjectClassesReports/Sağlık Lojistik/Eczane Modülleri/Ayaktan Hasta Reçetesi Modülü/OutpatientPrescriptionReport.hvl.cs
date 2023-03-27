
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
    public partial class OutpatientPrescriptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public OutpatientPrescriptionReport MyParentReport
            {
                get { return (OutpatientPrescriptionReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField11113 { get {return Header().NewField11113;} }
            public TTReportField NewField11114 { get {return Header().NewField11114;} }
            public TTReportField NewField11115 { get {return Header().NewField11115;} }
            public TTReportField NewField11116 { get {return Header().NewField11116;} }
            public TTReportField NewField11117 { get {return Header().NewField11117;} }
            public TTReportField NewField11118 { get {return Header().NewField11118;} }
            public TTReportField NewField11119 { get {return Header().NewField11119;} }
            public TTReportField NewField11120 { get {return Header().NewField11120;} }
            public TTReportField NewField181111 { get {return Header().NewField181111;} }
            public TTReportField NewField1111181 { get {return Header().NewField1111181;} }
            public TTReportField NewField1111182 { get {return Header().NewField1111182;} }
            public TTReportField NewField1111183 { get {return Header().NewField1111183;} }
            public TTReportField NewField1111184 { get {return Header().NewField1111184;} }
            public TTReportField NewField1111185 { get {return Header().NewField1111185;} }
            public TTReportField NewField1111186 { get {return Header().NewField1111186;} }
            public TTReportField NewField1111187 { get {return Header().NewField1111187;} }
            public TTReportField NewField1111188 { get {return Header().NewField1111188;} }
            public TTReportField NewField1111189 { get {return Header().NewField1111189;} }
            public TTReportField NewField1111190 { get {return Header().NewField1111190;} }
            public TTReportField NewField1111191 { get {return Header().NewField1111191;} }
            public TTReportField NewField1111192 { get {return Header().NewField1111192;} }
            public TTReportField NewField1111193 { get {return Header().NewField1111193;} }
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
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                public OutpatientPrescriptionReport MyParentReport
                {
                    get { return (OutpatientPrescriptionReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField HOSPITALNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField11112;
                public TTReportField NewField11113;
                public TTReportField NewField11114;
                public TTReportField NewField11115;
                public TTReportField NewField11116;
                public TTReportField NewField11117;
                public TTReportField NewField11118;
                public TTReportField NewField11119;
                public TTReportField NewField11120;
                public TTReportField NewField181111;
                public TTReportField NewField1111181;
                public TTReportField NewField1111182;
                public TTReportField NewField1111183;
                public TTReportField NewField1111184;
                public TTReportField NewField1111185;
                public TTReportField NewField1111186;
                public TTReportField NewField1111187;
                public TTReportField NewField1111188;
                public TTReportField NewField1111189;
                public TTReportField NewField1111190;
                public TTReportField NewField1111191;
                public TTReportField NewField1111192;
                public TTReportField NewField1111193;
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
                public TTReportShape NewLine1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 116;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 15, 65, 35, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Arial";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 15, 195, 38, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 12;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 40, 62, 45, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Kurum";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 45, 62, 50, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Eczane Adı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 50, 62, 55, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Eczane İskonto Oranı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 55, 62, 60, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Reçete Tarihi";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 60, 62, 65, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Uzmanlık Dalı";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 65, 62, 70, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Tanılar";

                    NewField11113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 70, 62, 75, false);
                    NewField11113.Name = "NewField11113";
                    NewField11113.TextFont.Name = "Arial";
                    NewField11113.TextFont.Bold = true;
                    NewField11113.TextFont.CharSet = 162;
                    NewField11113.Value = @"Reçete Sahibi";

                    NewField11114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 75, 62, 80, false);
                    NewField11114.Name = "NewField11114";
                    NewField11114.TextFont.Name = "Arial";
                    NewField11114.TextFont.Bold = true;
                    NewField11114.TextFont.CharSet = 162;
                    NewField11114.Value = @"T.C. Kimlik Nu.";

                    NewField11115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 80, 62, 85, false);
                    NewField11115.Name = "NewField11115";
                    NewField11115.TextFont.Name = "Arial";
                    NewField11115.TextFont.Bold = true;
                    NewField11115.TextFont.CharSet = 162;
                    NewField11115.Value = @"Hak Sahibi Grubu";

                    NewField11116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 85, 62, 90, false);
                    NewField11116.Name = "NewField11116";
                    NewField11116.TextFont.Name = "Arial";
                    NewField11116.TextFont.Bold = true;
                    NewField11116.TextFont.CharSet = 162;
                    NewField11116.Value = @"XXXXXX";

                    NewField11117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 95, 62, 100, false);
                    NewField11117.Name = "NewField11117";
                    NewField11117.TextFont.Name = "Arial";
                    NewField11117.TextFont.Bold = true;
                    NewField11117.TextFont.CharSet = 162;
                    NewField11117.Value = @"Provizyon Nu.";

                    NewField11118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 55, 140, 60, false);
                    NewField11118.Name = "NewField11118";
                    NewField11118.TextFont.Name = "Arial";
                    NewField11118.TextFont.Bold = true;
                    NewField11118.TextFont.CharSet = 162;
                    NewField11118.Value = @"İlaç Veriliş Tarihi";

                    NewField11119 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 75, 140, 80, false);
                    NewField11119.Name = "NewField11119";
                    NewField11119.TextFont.Name = "Arial";
                    NewField11119.TextFont.Bold = true;
                    NewField11119.TextFont.CharSet = 162;
                    NewField11119.Value = @"Sicil Nu.";

                    NewField11120 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 95, 140, 100, false);
                    NewField11120.Name = "NewField11120";
                    NewField11120.TextFont.Name = "Arial";
                    NewField11120.TextFont.Bold = true;
                    NewField11120.TextFont.CharSet = 162;
                    NewField11120.Value = @"Protokol Nu.";

                    NewField181111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 40, 64, 45, false);
                    NewField181111.Name = "NewField181111";
                    NewField181111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181111.TextFont.Name = "Arial";
                    NewField181111.TextFont.Bold = true;
                    NewField181111.TextFont.CharSet = 162;
                    NewField181111.Value = @":";

                    NewField1111181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 45, 64, 50, false);
                    NewField1111181.Name = "NewField1111181";
                    NewField1111181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111181.TextFont.Name = "Arial";
                    NewField1111181.TextFont.Bold = true;
                    NewField1111181.TextFont.CharSet = 162;
                    NewField1111181.Value = @":";

                    NewField1111182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 50, 64, 55, false);
                    NewField1111182.Name = "NewField1111182";
                    NewField1111182.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111182.TextFont.Name = "Arial";
                    NewField1111182.TextFont.Bold = true;
                    NewField1111182.TextFont.CharSet = 162;
                    NewField1111182.Value = @":";

                    NewField1111183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 55, 64, 60, false);
                    NewField1111183.Name = "NewField1111183";
                    NewField1111183.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111183.TextFont.Name = "Arial";
                    NewField1111183.TextFont.Bold = true;
                    NewField1111183.TextFont.CharSet = 162;
                    NewField1111183.Value = @":";

                    NewField1111184 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 64, 65, false);
                    NewField1111184.Name = "NewField1111184";
                    NewField1111184.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111184.TextFont.Name = "Arial";
                    NewField1111184.TextFont.Bold = true;
                    NewField1111184.TextFont.CharSet = 162;
                    NewField1111184.Value = @":";

                    NewField1111185 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 65, 64, 70, false);
                    NewField1111185.Name = "NewField1111185";
                    NewField1111185.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111185.TextFont.Name = "Arial";
                    NewField1111185.TextFont.Bold = true;
                    NewField1111185.TextFont.CharSet = 162;
                    NewField1111185.Value = @":";

                    NewField1111186 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 70, 64, 75, false);
                    NewField1111186.Name = "NewField1111186";
                    NewField1111186.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111186.TextFont.Name = "Arial";
                    NewField1111186.TextFont.Bold = true;
                    NewField1111186.TextFont.CharSet = 162;
                    NewField1111186.Value = @":";

                    NewField1111187 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 75, 64, 80, false);
                    NewField1111187.Name = "NewField1111187";
                    NewField1111187.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111187.TextFont.Name = "Arial";
                    NewField1111187.TextFont.Bold = true;
                    NewField1111187.TextFont.CharSet = 162;
                    NewField1111187.Value = @":";

                    NewField1111188 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 80, 64, 85, false);
                    NewField1111188.Name = "NewField1111188";
                    NewField1111188.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111188.TextFont.Name = "Arial";
                    NewField1111188.TextFont.Bold = true;
                    NewField1111188.TextFont.CharSet = 162;
                    NewField1111188.Value = @":";

                    NewField1111189 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 85, 64, 90, false);
                    NewField1111189.Name = "NewField1111189";
                    NewField1111189.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111189.TextFont.Name = "Arial";
                    NewField1111189.TextFont.Bold = true;
                    NewField1111189.TextFont.CharSet = 162;
                    NewField1111189.Value = @":";

                    NewField1111190 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 95, 64, 100, false);
                    NewField1111190.Name = "NewField1111190";
                    NewField1111190.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111190.TextFont.Name = "Arial";
                    NewField1111190.TextFont.Bold = true;
                    NewField1111190.TextFont.CharSet = 162;
                    NewField1111190.Value = @":";

                    NewField1111191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 55, 142, 60, false);
                    NewField1111191.Name = "NewField1111191";
                    NewField1111191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111191.TextFont.Name = "Arial";
                    NewField1111191.TextFont.Bold = true;
                    NewField1111191.TextFont.CharSet = 162;
                    NewField1111191.Value = @":";

                    NewField1111192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 75, 142, 80, false);
                    NewField1111192.Name = "NewField1111192";
                    NewField1111192.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111192.TextFont.Name = "Arial";
                    NewField1111192.TextFont.Bold = true;
                    NewField1111192.TextFont.CharSet = 162;
                    NewField1111192.Value = @":";

                    NewField1111193 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 95, 142, 100, false);
                    NewField1111193.Name = "NewField1111193";
                    NewField1111193.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111193.TextFont.Name = "Arial";
                    NewField1111193.TextFont.Bold = true;
                    NewField1111193.TextFont.CharSet = 162;
                    NewField1111193.Value = @":";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 40, 195, 45, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Name = "Arial";
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYER#}";

                    EXTERNALPHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 45, 195, 50, false);
                    EXTERNALPHARMACY.Name = "EXTERNALPHARMACY";
                    EXTERNALPHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALPHARMACY.WordBreak = EvetHayirEnum.ehEvet;
                    EXTERNALPHARMACY.TextFont.Name = "Arial";
                    EXTERNALPHARMACY.TextFont.CharSet = 162;
                    EXTERNALPHARMACY.Value = @"{#EXTERNALPHARMACY#}";

                    DISCOUNTOFPHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 50, 110, 55, false);
                    DISCOUNTOFPHARMACY.Name = "DISCOUNTOFPHARMACY";
                    DISCOUNTOFPHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCOUNTOFPHARMACY.TextFont.Name = "Arial";
                    DISCOUNTOFPHARMACY.TextFont.CharSet = 162;
                    DISCOUNTOFPHARMACY.Value = @"";

                    PRESCRIPTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 55, 110, 60, false);
                    PRESCRIPTIONDATE.Name = "PRESCRIPTIONDATE";
                    PRESCRIPTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONDATE.TextFormat = @"dd/MM/yyyy";
                    PRESCRIPTIONDATE.TextFont.Name = "Arial";
                    PRESCRIPTIONDATE.TextFont.CharSet = 162;
                    PRESCRIPTIONDATE.Value = @"{#PRESCRIPTIONDATE#}";

                    DRUGGIVINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 55, 188, 60, false);
                    DRUGGIVINGDATE.Name = "DRUGGIVINGDATE";
                    DRUGGIVINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGGIVINGDATE.TextFormat = @"dd/MM/yyyy";
                    DRUGGIVINGDATE.TextFont.Name = "Arial";
                    DRUGGIVINGDATE.TextFont.CharSet = 162;
                    DRUGGIVINGDATE.Value = @"{#DRUGGIVINGDATE#}";

                    PROCEDURESPECIALITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 60, 195, 65, false);
                    PROCEDURESPECIALITY.Name = "PROCEDURESPECIALITY";
                    PROCEDURESPECIALITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURESPECIALITY.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDURESPECIALITY.TextFont.Name = "Arial";
                    PROCEDURESPECIALITY.TextFont.CharSet = 162;
                    PROCEDURESPECIALITY.Value = @"{#PROCEDURESPECIALITY#}";

                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 65, 195, 70, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.TextFont.Name = "Arial";
                    DIAGNOSIS.TextFont.CharSet = 162;
                    DIAGNOSIS.Value = @"{#FREEDIAGNOSIS#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 70, 195, 75, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENT#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 75, 110, 80, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.TextFont.Name = "Arial";
                    PATIENTID.TextFont.CharSet = 162;
                    PATIENTID.Value = @"{#UNIQUEREFNO#}";

                    REGISTRYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 75, 188, 80, false);
                    REGISTRYNO.Name = "REGISTRYNO";
                    REGISTRYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRYNO.TextFont.Name = "Arial";
                    REGISTRYNO.TextFont.CharSet = 162;
                    REGISTRYNO.Value = @"{#EMPLOYMENTRECORDID#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 95, 188, 100, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    PROVISIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 95, 110, 100, false);
                    PROVISIONNO.Name = "PROVISIONNO";
                    PROVISIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVISIONNO.TextFont.Name = "Arial";
                    PROVISIONNO.TextFont.CharSet = 162;
                    PROVISIONNO.Value = @"{#SPTSPROVISIONID#}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 80, 195, 85, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP.TextFont.Name = "Arial";
                    PATIENTGROUP.TextFont.CharSet = 162;
                    PATIENTGROUP.Value = @"{#PATIENTGROUP#}";

                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 85, 195, 95, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITAL.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"";

                    NewField171111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 105, 75, 114, false);
                    NewField171111.Name = "NewField171111";
                    NewField171111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171111.TextFont.Name = "Arial";
                    NewField171111.TextFont.Bold = true;
                    NewField171111.TextFont.CharSet = 162;
                    NewField171111.Value = @"Verilen İlaç";

                    NewField1111171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 105, 85, 114, false);
                    NewField1111171.Name = "NewField1111171";
                    NewField1111171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111171.TextFont.Name = "Arial";
                    NewField1111171.TextFont.Bold = true;
                    NewField1111171.TextFont.CharSet = 162;
                    NewField1111171.Value = @"Adet";

                    NewField11711111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 105, 95, 114, false);
                    NewField11711111.Name = "NewField11711111";
                    NewField11711111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711111.TextFont.Name = "Arial";
                    NewField11711111.TextFont.Bold = true;
                    NewField11711111.TextFont.CharSet = 162;
                    NewField11711111.Value = @"Doz";

                    NewField11711112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 105, 107, 114, false);
                    NewField11711112.Name = "NewField11711112";
                    NewField11711112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711112.TextFont.Name = "Arial";
                    NewField11711112.TextFont.Bold = true;
                    NewField11711112.TextFont.CharSet = 162;
                    NewField11711112.Value = @"H/A R";

                    NewField11711113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 105, 119, 114, false);
                    NewField11711113.Name = "NewField11711113";
                    NewField11711113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11711113.TextFont.Name = "Arial";
                    NewField11711113.TextFont.Bold = true;
                    NewField11711113.TextFont.CharSet = 162;
                    NewField11711113.Value = @"Birim
Fiyat";

                    NewField131111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 105, 131, 114, false);
                    NewField131111711.Name = "NewField131111711";
                    NewField131111711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131111711.TextFont.Name = "Arial";
                    NewField131111711.TextFont.Bold = true;
                    NewField131111711.TextFont.CharSet = 162;
                    NewField131111711.Value = @"İlaç
Fiyatı";

                    NewField131111712 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 105, 143, 114, false);
                    NewField131111712.Name = "NewField131111712";
                    NewField131111712.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131111712.TextFont.Name = "Arial";
                    NewField131111712.TextFont.Bold = true;
                    NewField131111712.TextFont.CharSet = 162;
                    NewField131111712.Value = @"Hasta
Payı";

                    NewField1217111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 105, 156, 114, false);
                    NewField1217111131.Name = "NewField1217111131";
                    NewField1217111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1217111131.TextFont.Name = "Arial";
                    NewField1217111131.TextFont.Bold = true;
                    NewField1217111131.TextFont.CharSet = 162;
                    NewField1217111131.Value = @"Kurum
Payı";

                    NewField1217111132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 105, 166, 114, false);
                    NewField1217111132.Name = "NewField1217111132";
                    NewField1217111132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1217111132.TextFont.Name = "Arial";
                    NewField1217111132.TextFont.Bold = true;
                    NewField1217111132.TextFont.CharSet = 162;
                    NewField1217111132.Value = @"İlaç
Bitiş";

                    NewField1217111133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 105, 177, 114, false);
                    NewField1217111133.Name = "NewField1217111133";
                    NewField1217111133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1217111133.TextFont.Name = "Arial";
                    NewField1217111133.TextFont.Bold = true;
                    NewField1217111133.TextFont.CharSet = 162;
                    NewField1217111133.Value = @"KDV
Oranı";

                    NewField1117111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 105, 195, 114, false);
                    NewField1117111131.Name = "NewField1117111131";
                    NewField1117111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1117111131.TextFont.Name = "Arial";
                    NewField1117111131.TextFont.Bold = true;
                    NewField1117111131.TextFont.CharSet = 162;
                    NewField1117111131.Value = @"İlaç Fiyat
Farkı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 114, 195, 114, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField11113.CalcValue = NewField11113.Value;
                    NewField11114.CalcValue = NewField11114.Value;
                    NewField11115.CalcValue = NewField11115.Value;
                    NewField11116.CalcValue = NewField11116.Value;
                    NewField11117.CalcValue = NewField11117.Value;
                    NewField11118.CalcValue = NewField11118.Value;
                    NewField11119.CalcValue = NewField11119.Value;
                    NewField11120.CalcValue = NewField11120.Value;
                    NewField181111.CalcValue = NewField181111.Value;
                    NewField1111181.CalcValue = NewField1111181.Value;
                    NewField1111182.CalcValue = NewField1111182.Value;
                    NewField1111183.CalcValue = NewField1111183.Value;
                    NewField1111184.CalcValue = NewField1111184.Value;
                    NewField1111185.CalcValue = NewField1111185.Value;
                    NewField1111186.CalcValue = NewField1111186.Value;
                    NewField1111187.CalcValue = NewField1111187.Value;
                    NewField1111188.CalcValue = NewField1111188.Value;
                    NewField1111189.CalcValue = NewField1111189.Value;
                    NewField1111190.CalcValue = NewField1111190.Value;
                    NewField1111191.CalcValue = NewField1111191.Value;
                    NewField1111192.CalcValue = NewField1111192.Value;
                    NewField1111193.CalcValue = NewField1111193.Value;
                    PAYER.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Payer) : "");
                    EXTERNALPHARMACY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Externalpharmacy) : "");
                    DISCOUNTOFPHARMACY.CalcValue = @"";
                    PRESCRIPTIONDATE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Prescriptiondate) : "");
                    DRUGGIVINGDATE.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Druggivingdate) : "");
                    PROCEDURESPECIALITY.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Procedurespeciality) : "");
                    DIAGNOSIS.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.FreeDiagnosis) : "");
                    PATIENTNAME.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Patient) : "");
                    PATIENTID.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.UniqueRefNo) : "");
                    REGISTRYNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Employmentrecordid) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.HospitalProtocolNo) : "");
                    PROVISIONNO.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.SPTSProvisionID) : "");
                    PATIENTGROUP.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Patientgroup) : "");
                    PATIENTGROUP.PostFieldValueCalculation();
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
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField1,NewField11,NewField111,NewField1111,NewField11111,NewField11112,NewField11113,NewField11114,NewField11115,NewField11116,NewField11117,NewField11118,NewField11119,NewField11120,NewField181111,NewField1111181,NewField1111182,NewField1111183,NewField1111184,NewField1111185,NewField1111186,NewField1111187,NewField1111188,NewField1111189,NewField1111190,NewField1111191,NewField1111192,NewField1111193,PAYER,EXTERNALPHARMACY,DISCOUNTOFPHARMACY,PRESCRIPTIONDATE,DRUGGIVINGDATE,PROCEDURESPECIALITY,DIAGNOSIS,PATIENTNAME,PATIENTID,REGISTRYNO,PROTOCOLNO,PROVISIONNO,PATIENTGROUP,HOSPITAL,NewField171111,NewField1111171,NewField11711111,NewField11711112,NewField11711113,NewField131111711,NewField131111712,NewField1217111131,NewField1217111132,NewField1217111133,NewField1117111131,HOSPITALNAME};
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
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OutpatientPrescriptionReport MyParentReport
                {
                    get { return (OutpatientPrescriptionReport)ParentReport; }
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
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 52;
                    RepeatCount = 0;
                    
                    NewField1111172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 5, 164, 10, false);
                    NewField1111172.Name = "NewField1111172";
                    NewField1111172.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111172.TextFont.Name = "Arial";
                    NewField1111172.TextFont.Bold = true;
                    NewField1111172.TextFont.CharSet = 162;
                    NewField1111172.Value = @"Toplam İlaç Fiyatı";

                    NewField12711111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 10, 164, 15, false);
                    NewField12711111.Name = "NewField12711111";
                    NewField12711111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711111.TextFont.Name = "Arial";
                    NewField12711111.TextFont.Bold = true;
                    NewField12711111.TextFont.CharSet = 162;
                    NewField12711111.Value = @"Hasta Katılım Payı";

                    NewField12711112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 15, 164, 20, false);
                    NewField12711112.Name = "NewField12711112";
                    NewField12711112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711112.TextFont.Name = "Arial";
                    NewField12711112.TextFont.Bold = true;
                    NewField12711112.TextFont.CharSet = 162;
                    NewField12711112.Value = @"İskonto";

                    NewField12711113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 20, 164, 25, false);
                    NewField12711113.Name = "NewField12711113";
                    NewField12711113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12711113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711113.TextFont.Name = "Arial";
                    NewField12711113.TextFont.Bold = true;
                    NewField12711113.TextFont.CharSet = 162;
                    NewField12711113.Value = @"Toplam Kurum Payı";

                    NewField17811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 5, 166, 10, false);
                    NewField17811111.Name = "NewField17811111";
                    NewField17811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17811111.TextFont.Name = "Arial";
                    NewField17811111.TextFont.Bold = true;
                    NewField17811111.TextFont.CharSet = 162;
                    NewField17811111.Value = @":";

                    NewField18811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 10, 166, 15, false);
                    NewField18811111.Name = "NewField18811111";
                    NewField18811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18811111.TextFont.Name = "Arial";
                    NewField18811111.TextFont.Bold = true;
                    NewField18811111.TextFont.CharSet = 162;
                    NewField18811111.Value = @":";

                    NewField19811111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 15, 166, 20, false);
                    NewField19811111.Name = "NewField19811111";
                    NewField19811111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19811111.TextFont.Name = "Arial";
                    NewField19811111.TextFont.Bold = true;
                    NewField19811111.TextFont.CharSet = 162;
                    NewField19811111.Value = @":";

                    NewField10911111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 20, 166, 25, false);
                    NewField10911111.Name = "NewField10911111";
                    NewField10911111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10911111.TextFont.Name = "Arial";
                    NewField10911111.TextFont.Bold = true;
                    NewField10911111.TextFont.CharSet = 162;
                    NewField10911111.Value = @":";

                    TOTALDRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 5, 195, 10, false);
                    TOTALDRUGPRICE.Name = "TOTALDRUGPRICE";
                    TOTALDRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDRUGPRICE.TextFormat = @"#,##0.#0";
                    TOTALDRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDRUGPRICE.TextFont.Name = "Arial";
                    TOTALDRUGPRICE.TextFont.Bold = true;
                    TOTALDRUGPRICE.TextFont.CharSet = 162;
                    TOTALDRUGPRICE.Value = @"{@sumof(DRUGPRICE)@}";

                    DISCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 15, 195, 20, false);
                    DISCOUNT.Name = "DISCOUNT";
                    DISCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCOUNT.TextFormat = @"#,##0.#0";
                    DISCOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISCOUNT.TextFont.Name = "Arial";
                    DISCOUNT.TextFont.CharSet = 162;
                    DISCOUNT.Value = @"";

                    TOTALSOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 20, 195, 25, false);
                    TOTALSOCIETYLOT.Name = "TOTALSOCIETYLOT";
                    TOTALSOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALSOCIETYLOT.TextFormat = @"#,##0.#0";
                    TOTALSOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALSOCIETYLOT.TextFont.Name = "Arial";
                    TOTALSOCIETYLOT.TextFont.Bold = true;
                    TOTALSOCIETYLOT.TextFont.CharSet = 162;
                    TOTALSOCIETYLOT.Value = @"";

                    TOTALPATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 10, 195, 15, false);
                    TOTALPATIENTLOT.Name = "TOTALPATIENTLOT";
                    TOTALPATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPATIENTLOT.TextFormat = @"#,##0.#0";
                    TOTALPATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPATIENTLOT.TextFont.Name = "Arial";
                    TOTALPATIENTLOT.TextFont.CharSet = 162;
                    TOTALPATIENTLOT.Value = @"{@sumof(PATIENTLOT)@}";

                    NewField12711114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 35, 124, 40, false);
                    NewField12711114.Name = "NewField12711114";
                    NewField12711114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711114.TextFont.Name = "Arial";
                    NewField12711114.TextFont.Bold = true;
                    NewField12711114.TextFont.CharSet = 162;
                    NewField12711114.Value = @"Aldığınız ilaçlar için ödemeniz gereken toplam fiyat farkı : ";

                    NewField111111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 40, 99, 45, false);
                    NewField111111721.Name = "NewField111111721";
                    NewField111111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111721.TextFont.Name = "Arial";
                    NewField111111721.TextFont.Bold = true;
                    NewField111111721.TextFont.CharSet = 162;
                    NewField111111721.Value = @"Aldığınız ilaçların hasta katılım payı tutarı : ";

                    NewField1127111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 45, 131, 50, false);
                    NewField1127111111.Name = "NewField1127111111";
                    NewField1127111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111111.TextFont.Name = "Arial";
                    NewField1127111111.TextFont.Bold = true;
                    NewField1127111111.TextFont.CharSet = 162;
                    NewField1127111111.Value = @"Reçete Sahibinin İmzası";

                    TOTALPRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 35, 158, 40, false);
                    TOTALPRICEDIFFERENCE.Name = "TOTALPRICEDIFFERENCE";
                    TOTALPRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICEDIFFERENCE.TextFont.Name = "Arial";
                    TOTALPRICEDIFFERENCE.TextFont.CharSet = 162;
                    TOTALPRICEDIFFERENCE.Value = @"";

                    TOTALPATIENTLOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 40, 127, 45, false);
                    TOTALPATIENTLOT1.Name = "TOTALPATIENTLOT1";
                    TOTALPATIENTLOT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPATIENTLOT1.TextFormat = @"#,##0.#0";
                    TOTALPATIENTLOT1.TextFont.Name = "Arial";
                    TOTALPATIENTLOT1.TextFont.CharSet = 162;
                    TOTALPATIENTLOT1.Value = @"{@sumof(PATIENTLOT)@}";

                    NewField141111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 35, 168, 40, false);
                    NewField141111721.Name = "NewField141111721";
                    NewField141111721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141111721.TextFont.Name = "Arial";
                    NewField141111721.TextFont.CharSet = 162;
                    NewField141111721.Value = @"TL'dir.";

                    NewField1127111141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 40, 137, 45, false);
                    NewField1127111141.Name = "NewField1127111141";
                    NewField1127111141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111141.TextFont.Name = "Arial";
                    NewField1127111141.TextFont.CharSet = 162;
                    NewField1127111141.Value = @"TL'dir.";

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
                    return new TTReportObject[] { NewField1111172,NewField12711111,NewField12711112,NewField12711113,NewField17811111,NewField18811111,NewField19811111,NewField10911111,TOTALDRUGPRICE,DISCOUNT,TOTALSOCIETYLOT,TOTALPATIENTLOT,NewField12711114,NewField111111721,NewField1127111111,TOTALPRICEDIFFERENCE,TOTALPATIENTLOT1,NewField141111721,NewField1127111141};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public OutpatientPrescriptionReport MyParentReport
            {
                get { return (OutpatientPrescriptionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUG { get {return Body().DRUG;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DOSE { get {return Body().DOSE;} }
            public TTReportField WM { get {return Body().WM;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField DRUGPRICE { get {return Body().DRUGPRICE;} }
            public TTReportField PATIENTLOT { get {return Body().PATIENTLOT;} }
            public TTReportField SOCIETYLOT { get {return Body().SOCIETYLOT;} }
            public TTReportField DRUGEND { get {return Body().DRUGEND;} }
            public TTReportField VATRATE { get {return Body().VATRATE;} }
            public TTReportField PRICEDIFFERENCE { get {return Body().PRICEDIFFERENCE;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField DOSEAMOUNT { get {return Body().DOSEAMOUNT;} }
            public TTReportField FREQUENCY { get {return Body().FREQUENCY;} }
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
                public OutpatientPrescriptionReport MyParentReport
                {
                    get { return (OutpatientPrescriptionReport)ParentReport; }
                }
                
                public TTReportField DRUG;
                public TTReportField AMOUNT;
                public TTReportField DOSE;
                public TTReportField WM;
                public TTReportField UNITPRICE;
                public TTReportField DRUGPRICE;
                public TTReportField PATIENTLOT;
                public TTReportField SOCIETYLOT;
                public TTReportField DRUGEND;
                public TTReportField VATRATE;
                public TTReportField PRICEDIFFERENCE;
                public TTReportShape NewLine11;
                public TTReportField DOSEAMOUNT;
                public TTReportField FREQUENCY; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    DRUG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 75, 6, false);
                    DRUG.Name = "DRUG";
                    DRUG.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG.TextFont.Name = "Arial";
                    DRUG.TextFont.CharSet = 162;
                    DRUG.Value = @"{#PARTA.DRUG#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 1, 85, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PARTA.AMOUNT#}";

                    DOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 1, 95, 6, false);
                    DOSE.Name = "DOSE";
                    DOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSE.TextFont.Name = "Arial";
                    DOSE.TextFont.CharSet = 162;
                    DOSE.Value = @"";

                    WM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 1, 107, 6, false);
                    WM.Name = "WM";
                    WM.FieldType = ReportFieldTypeEnum.ftVariable;
                    WM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM.TextFont.Name = "Arial";
                    WM.TextFont.CharSet = 162;
                    WM.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 1, 119, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#PARTA.UNITPRICE#}";

                    DRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 1, 131, 6, false);
                    DRUGPRICE.Name = "DRUGPRICE";
                    DRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGPRICE.TextFormat = @"#,##0.#0";
                    DRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DRUGPRICE.TextFont.Name = "Arial";
                    DRUGPRICE.TextFont.CharSet = 162;
                    DRUGPRICE.Value = @"{#PARTA.PRICE#}";

                    PATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 1, 143, 6, false);
                    PATIENTLOT.Name = "PATIENTLOT";
                    PATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTLOT.TextFormat = @"#,##0.#0";
                    PATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PATIENTLOT.TextFont.Name = "Arial";
                    PATIENTLOT.TextFont.CharSet = 162;
                    PATIENTLOT.Value = @"{#PARTA.RECEIVEDPRICE#}";

                    SOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 156, 6, false);
                    SOCIETYLOT.Name = "SOCIETYLOT";
                    SOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOCIETYLOT.TextFormat = @"#,##0.#0";
                    SOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SOCIETYLOT.TextFont.Name = "Arial";
                    SOCIETYLOT.TextFont.CharSet = 162;
                    SOCIETYLOT.Value = @"";

                    DRUGEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 166, 6, false);
                    DRUGEND.Name = "DRUGEND";
                    DRUGEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGEND.TextFont.Name = "Arial";
                    DRUGEND.TextFont.CharSet = 162;
                    DRUGEND.Value = @"";

                    VATRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 177, 6, false);
                    VATRATE.Name = "VATRATE";
                    VATRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VATRATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    VATRATE.TextFont.Name = "Arial";
                    VATRATE.TextFont.CharSet = 162;
                    VATRATE.Value = @"";

                    PRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 1, 195, 6, false);
                    PRICEDIFFERENCE.Name = "PRICEDIFFERENCE";
                    PRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEDIFFERENCE.TextFormat = @"#,##0.#0";
                    PRICEDIFFERENCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICEDIFFERENCE.TextFont.Name = "Arial";
                    PRICEDIFFERENCE.TextFont.CharSet = 162;
                    PRICEDIFFERENCE.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 6, 195, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    DOSEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 223, 6, false);
                    DOSEAMOUNT.Name = "DOSEAMOUNT";
                    DOSEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    DOSEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSEAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSEAMOUNT.TextFont.Name = "Arial";
                    DOSEAMOUNT.TextFont.CharSet = 162;
                    DOSEAMOUNT.Value = @"{#PARTA.DOSEAMOUNT#}";

                    FREQUENCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 1, 234, 6, false);
                    FREQUENCY.Name = "FREQUENCY";
                    FREQUENCY.Visible = EvetHayirEnum.ehHayir;
                    FREQUENCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FREQUENCY.TextFont.Name = "Arial";
                    FREQUENCY.TextFont.CharSet = 162;
                    FREQUENCY.Value = @"{#PARTA.FREQUENCY#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class dataset_GetOutpatientPrescriptionReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(0);
                    DRUG.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Drug) : "");
                    AMOUNT.CalcValue = (dataset_GetOutpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetOutpatientPrescriptionReportQuery.Amount) : "");
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
                    return new TTReportObject[] { DRUG,AMOUNT,DOSE,WM,UNITPRICE,DRUGPRICE,PATIENTLOT,SOCIETYLOT,DRUGEND,VATRATE,PRICEDIFFERENCE,DOSEAMOUNT,FREQUENCY};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    switch(FREQUENCY.CalcValue)
            {
                case "Q12H":
                    DOSE.CalcValue = "2x" + DOSEAMOUNT.CalcValue;
                    break;
                    
                case "Q2H":
                    DOSE.CalcValue = "12x" + DOSEAMOUNT.CalcValue;
                    break;
                    
                case "Q24H":
                    DOSE.CalcValue = "1x" + DOSEAMOUNT.CalcValue;
                    break;
                    
                case "Q3H":
                    DOSE.CalcValue = "8x" + DOSEAMOUNT.CalcValue;
                    break;
                    
                case "Q6H":
                    DOSE.CalcValue = "4x" + DOSEAMOUNT.CalcValue;
                    break;
                    
                case "Q8H":
                    DOSE.CalcValue = "3x" + DOSEAMOUNT.CalcValue;
                    break;
            }
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

        public OutpatientPrescriptionReport()
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
            Name = "OUTPATIENTPRESCRIPTIONREPORT";
            Caption = "Ayaktan Hasta Reçetesi Raporu";
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