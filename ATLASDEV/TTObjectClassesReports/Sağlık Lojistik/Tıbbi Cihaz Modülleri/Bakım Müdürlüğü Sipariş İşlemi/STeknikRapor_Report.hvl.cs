
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
    /// Teknik Rapor (Ek-8.5)
    /// </summary>
    public partial class STeknikRapor : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public STeknikRapor MyParentReport
            {
                get { return (STeknikRapor)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField MALZEMENINKULLANILDIGIBIRLIK { get {return Header().MALZEMENINKULLANILDIGIBIRLIK;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField MARK { get {return Header().MARK;} }
            public TTReportField MODEL { get {return Header().MODEL;} }
            public TTReportField M1 { get {return Header().M1;} }
            public TTReportField SERIALNUMBER { get {return Header().SERIALNUMBER;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField NewField21_11 { get {return Footer().NewField21_11;} }
            public TTReportField NewField23_11 { get {return Footer().NewField23_11;} }
            public TTReportField TECHNAMESURNAME { get {return Footer().TECHNAMESURNAME;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportRTF DESCRIPTIONRTF1 { get {return Footer().DESCRIPTIONRTF1;} }
            public TTReportField NewField21_111 { get {return Footer().NewField21_111;} }
            public TTReportField NewField21_121 { get {return Footer().NewField21_121;} }
            public TTReportField TECHNAMESURNAME1 { get {return Footer().TECHNAMESURNAME1;} }
            public TTReportField SECNAMESURNAME { get {return Footer().SECNAMESURNAME;} }
            public TTReportField DEVNAMESURNAME { get {return Footer().DEVNAMESURNAME;} }
            public TTReportField NewField21_1111 { get {return Footer().NewField21_1111;} }
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
                list[0] = new TTReportNqlData<CMRAction.GetCMRActionQuery_Class>("GetCMRActionQuery", CMRAction.GetCMRActionQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public STeknikRapor MyParentReport
                {
                    get { return (STeknikRapor)ParentReport; }
                }
                
                public TTReportField REPORTNAME1;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField101;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField MALZEMENINKULLANILDIGIBIRLIK;
                public TTReportField REQUESTNO;
                public TTReportField NewField112;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField16;
                public TTReportField MATERIALNAME;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField M1;
                public TTReportField SERIALNUMBER;
                public TTReportField DATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 72;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 200, 13, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 11;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"TEKNİK RAPOR";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 61, 24, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"BİRLİĞİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 18, 62, 24, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 25, 62, 31, false);
                    NewField17.Name = "NewField17";
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 32, 61, 38, false);
                    NewField18.Name = "NewField18";
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"MALZEMENIN ADI";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 32, 62, 38, false);
                    NewField19.Name = "NewField19";
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @":";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 61, 45, false);
                    NewField101.Name = "NewField101";
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Bold = true;
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"MARKA / MODEL";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 39, 62, 45, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 61, 52, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"SERİ NO";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 46, 62, 52, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    MALZEMENINKULLANILDIGIBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 18, 175, 24, false);
                    MALZEMENINKULLANILDIGIBIRLIK.Name = "MALZEMENINKULLANILDIGIBIRLIK";
                    MALZEMENINKULLANILDIGIBIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMENINKULLANILDIGIBIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMENINKULLANILDIGIBIRLIK.TextFont.Name = "Arial";
                    MALZEMENINKULLANILDIGIBIRLIK.TextFont.CharSet = 162;
                    MALZEMENINKULLANILDIGIBIRLIK.Value = @"{#OWNERMILITARYUNIT#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 25, 175, 31, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.TextFont.Name = "Arial";
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 175, 71, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.Underline = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"AÇIKLAMALAR                                                          :";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 61, 59, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"TARİH";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 53, 62, 59, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 61, 31, false);
                    NewField16.Name = "NewField16";
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"SİPARİŞ NO";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 32, 175, 38, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#FIXEDASSETNAME#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 39, 114, 45, false);
                    MARK.Name = "MARK";
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARK.TextFont.Name = "Arial";
                    MARK.TextFont.CharSet = 162;
                    MARK.Value = @"{#MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 39, 175, 45, false);
                    MODEL.Name = "MODEL";
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MODEL.TextFont.Name = "Arial";
                    MODEL.TextFont.CharSet = 162;
                    MODEL.Value = @"{#MODEL#}";

                    M1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 39, 118, 45, false);
                    M1.Name = "M1";
                    M1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    M1.TextFont.Name = "Arial";
                    M1.TextFont.CharSet = 162;
                    M1.Value = @"/";

                    SERIALNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 46, 175, 52, false);
                    SERIALNUMBER.Name = "SERIALNUMBER";
                    SERIALNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNUMBER.TextFont.Name = "Arial";
                    SERIALNUMBER.TextFont.CharSet = 162;
                    SERIALNUMBER.Value = @"{#SERIALNUMBER#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 53, 175, 59, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetCMRActionQuery_Class dataset_GetCMRActionQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    MALZEMENINKULLANILDIGIBIRLIK.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Ownermilitaryunit) : "");
                    REQUESTNO.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.RequestNo) : "");
                    NewField112.CalcValue = NewField112.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField16.CalcValue = NewField16.Value;
                    MATERIALNAME.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Fixedassetname) : "");
                    MARK.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Mark) : "");
                    MODEL.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Model) : "");
                    M1.CalcValue = M1.Value;
                    SERIALNUMBER.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.SerialNumber) : "");
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    return new TTReportObject[] { REPORTNAME1,NewField14,NewField15,NewField17,NewField18,NewField19,NewField101,NewField111,NewField121,NewField131,MALZEMENINKULLANILDIGIBIRLIK,REQUESTNO,NewField112,NewField1121,NewField1131,NewField16,MATERIALNAME,MARK,MODEL,M1,SERIALNUMBER,DATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            if(cmrAction is Repair)
            {
                Repair repair = (Repair)cmrAction;
                DATE.CalcValue = repair.RequestDate.ToString();
            }
            else if(cmrAction is MaintenanceOrder)
            {
                MaintenanceOrder mo = (MaintenanceOrder)cmrAction;
                DATE.CalcValue = mo.RequestDate.ToString();
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public STeknikRapor MyParentReport
                {
                    get { return (STeknikRapor)ParentReport; }
                }
                
                public TTReportField NewField21_11;
                public TTReportField NewField23_11;
                public TTReportField TECHNAMESURNAME;
                public TTReportField ONAY;
                public TTReportRTF DESCRIPTIONRTF1;
                public TTReportField NewField21_111;
                public TTReportField NewField21_121;
                public TTReportField TECHNAMESURNAME1;
                public TTReportField SECNAMESURNAME;
                public TTReportField DEVNAMESURNAME;
                public TTReportField NewField21_1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 151;
                    RepeatCount = 0;
                    
                    NewField21_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 58, 87, false);
                    NewField21_11.Name = "NewField21_11";
                    NewField21_11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_11.TextFont.Name = "Arial";
                    NewField21_11.TextFont.Size = 11;
                    NewField21_11.TextFont.Bold = true;
                    NewField21_11.TextFont.CharSet = 162;
                    NewField21_11.Value = @"TEKNİSYEN";

                    NewField23_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 81, 155, 87, false);
                    NewField23_11.Name = "NewField23_11";
                    NewField23_11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23_11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23_11.TextFont.Name = "Arial";
                    NewField23_11.TextFont.Size = 11;
                    NewField23_11.TextFont.Bold = true;
                    NewField23_11.TextFont.CharSet = 162;
                    NewField23_11.Value = @"KISIM AMİRİ";

                    TECHNAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 96, 58, 110, false);
                    TECHNAMESURNAME.Name = "TECHNAMESURNAME";
                    TECHNAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TECHNAMESURNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    TECHNAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TECHNAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TECHNAMESURNAME.TextFont.Name = "Arial";
                    TECHNAMESURNAME.TextFont.Size = 11;
                    TECHNAMESURNAME.TextFont.CharSet = 162;
                    TECHNAMESURNAME.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 132, 139, 147, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftExpression;
                    ONAY.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONAY.TextFont.Name = "Arial";
                    ONAY.TextFont.Size = 11;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"";

                    DESCRIPTIONRTF1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 2, 200, 77, false);
                    DESCRIPTIONRTF1.Name = "DESCRIPTIONRTF1";
                    DESCRIPTIONRTF1.Value = @"";

                    NewField21_111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 81, 109, 87, false);
                    NewField21_111.Name = "NewField21_111";
                    NewField21_111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_111.TextFont.Name = "Arial";
                    NewField21_111.TextFont.Size = 11;
                    NewField21_111.TextFont.Bold = true;
                    NewField21_111.TextFont.CharSet = 162;
                    NewField21_111.Value = @"TEKNİSYEN";

                    NewField21_121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 81, 199, 87, false);
                    NewField21_121.Name = "NewField21_121";
                    NewField21_121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_121.TextFont.Name = "Arial";
                    NewField21_121.TextFont.Size = 11;
                    NewField21_121.TextFont.Bold = true;
                    NewField21_121.TextFont.CharSet = 162;
                    NewField21_121.Value = @"BÖLÜM AMİRİ";

                    TECHNAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 96, 109, 110, false);
                    TECHNAMESURNAME1.Name = "TECHNAMESURNAME1";
                    TECHNAMESURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TECHNAMESURNAME1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    TECHNAMESURNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TECHNAMESURNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TECHNAMESURNAME1.TextFont.Name = "Arial";
                    TECHNAMESURNAME1.TextFont.Size = 11;
                    TECHNAMESURNAME1.TextFont.CharSet = 162;
                    TECHNAMESURNAME1.Value = @"";

                    SECNAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 96, 155, 110, false);
                    SECNAMESURNAME.Name = "SECNAMESURNAME";
                    SECNAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECNAMESURNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    SECNAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SECNAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECNAMESURNAME.TextFont.Name = "Arial";
                    SECNAMESURNAME.TextFont.Size = 11;
                    SECNAMESURNAME.TextFont.CharSet = 162;
                    SECNAMESURNAME.Value = @"";

                    DEVNAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 96, 199, 110, false);
                    DEVNAMESURNAME.Name = "DEVNAMESURNAME";
                    DEVNAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEVNAMESURNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    DEVNAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEVNAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEVNAMESURNAME.TextFont.Name = "Arial";
                    DEVNAMESURNAME.TextFont.Size = 11;
                    DEVNAMESURNAME.TextFont.CharSet = 162;
                    DEVNAMESURNAME.Value = @"";

                    NewField21_1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 119, 127, 125, false);
                    NewField21_1111.Name = "NewField21_1111";
                    NewField21_1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_1111.TextFont.Name = "Arial";
                    NewField21_1111.TextFont.Size = 11;
                    NewField21_1111.TextFont.Bold = true;
                    NewField21_1111.TextFont.CharSet = 162;
                    NewField21_1111.Value = @"O N A Y";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetCMRActionQuery_Class dataset_GetCMRActionQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);
                    NewField21_11.CalcValue = NewField21_11.Value;
                    NewField23_11.CalcValue = NewField23_11.Value;
                    TECHNAMESURNAME.CalcValue = @"";
                    DESCRIPTIONRTF1.CalcValue = DESCRIPTIONRTF1.Value;
                    NewField21_111.CalcValue = NewField21_111.Value;
                    NewField21_121.CalcValue = NewField21_121.Value;
                    TECHNAMESURNAME1.CalcValue = @"";
                    SECNAMESURNAME.CalcValue = @"";
                    DEVNAMESURNAME.CalcValue = @"";
                    NewField21_1111.CalcValue = NewField21_1111.Value;
                    ONAY.CalcValue = @"";
                    return new TTReportObject[] { NewField21_11,NewField23_11,TECHNAMESURNAME,DESCRIPTIONRTF1,NewField21_111,NewField21_121,TECHNAMESURNAME1,SECNAMESURNAME,DEVNAMESURNAME,NewField21_1111,ONAY};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            if(cmrAction is Repair)
            {
                Repair repair = (Repair)cmrAction;
                DESCRIPTIONRTF1.Value = repair.HEKReportDescription;
            }
            else if(cmrAction is MaintenanceOrder)
            {
                MaintenanceOrder mo = (MaintenanceOrder)cmrAction;
                DESCRIPTIONRTF1.Value = mo.Description;
            }
#endregion PARTA FOOTER_PreScript
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    //            string objectID = ((TeknikRapor)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            TTObjectContext ctx = new TTObjectContext(true);
//            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
//            ResUser user = (ResUser)mo.GetState("DivisionSectionApproval", true).User.UserObject;
//            NAMESURNAME.CalcValue = user.Name.ToString();
//            TITLE.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public STeknikRapor MyParentReport
            {
                get { return (STeknikRapor)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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

                CMRAction.GetCMRActionQuery_Class dataSet_GetCMRActionQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);    
                return new object[] {(dataSet_GetCMRActionQuery==null ? null : dataSet_GetCMRActionQuery.ObjectID)};
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
                public STeknikRapor MyParentReport
                {
                    get { return (STeknikRapor)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public STeknikRapor()
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
            Name = "STEKNIKRAPOR";
            Caption = "Teknik Rapor (Ek-8.5)";
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