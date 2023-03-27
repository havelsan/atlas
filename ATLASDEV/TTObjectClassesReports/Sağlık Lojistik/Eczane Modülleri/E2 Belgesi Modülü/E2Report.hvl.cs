
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
    /// E2 TEVHİT CETVELİ
    /// </summary>
    public partial class E2Report : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public E2Report MyParentReport
            {
                get { return (E2Report)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField SDATE { get {return Header().SDATE;} }
            public TTReportField EDATE { get {return Header().EDATE;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField55 { get {return Header().NewField55;} }
            public TTReportField REGISTRATIONANDSEQUENCENUMBER { get {return Header().REGISTRATIONANDSEQUENCENUMBER;} }
            public TTReportField FILLDATE { get {return Header().FILLDATE;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportField NewField145 { get {return Header().NewField145;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public TTReportField NewField7 { get {return Footer().NewField7;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField CHIEF { get {return Footer().CHIEF;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField PHARMACY { get {return Footer().PHARMACY;} }
            public TTReportField APPROVAL { get {return Footer().APPROVAL;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<E2.GetE2ReportQuery_Class>("GetE2ReportQuery", E2.GetE2ReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public E2Report MyParentReport
                {
                    get { return (E2Report)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField SDATE;
                public TTReportField EDATE;
                public TTReportField NewField44;
                public TTReportField NewField55;
                public TTReportField REGISTRATIONANDSEQUENCENUMBER;
                public TTReportField FILLDATE;
                public TTReportField HOSPITALNAME;
                public TTReportField LOGO;
                public TTReportField NewField144;
                public TTReportField NewField145; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 49, 200, 54, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 11;
                    DESCRIPTION.Value = @"{%SDATE%} - {%EDATE%} TARİHLERİ ARASI E2 TEVHİT CETVELİ";

                    SDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 59, 104, 63, false);
                    SDATE.Name = "SDATE";
                    SDATE.Visible = EvetHayirEnum.ehHayir;
                    SDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SDATE.TextFormat = @"dd/MM/yyyy";
                    SDATE.Value = @"{#STARTDATE#}";

                    EDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 59, 117, 63, false);
                    EDATE.Name = "EDATE";
                    EDATE.Visible = EvetHayirEnum.ehHayir;
                    EDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EDATE.TextFormat = @"dd/MM/yyyy";
                    EDATE.Value = @"{#ENDDATE#}";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 59, 154, 64, false);
                    NewField44.Name = "NewField44";
                    NewField44.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField44.TextFont.Name = "Arial";
                    NewField44.TextFont.Bold = true;
                    NewField44.Value = @"Belge Kayıt Nu.";

                    NewField55 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 65, 154, 70, false);
                    NewField55.Name = "NewField55";
                    NewField55.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField55.TextFont.Name = "Arial";
                    NewField55.TextFont.Bold = true;
                    NewField55.Value = @"Belge Kayıt Tarihi";

                    REGISTRATIONANDSEQUENCENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 59, 200, 64, false);
                    REGISTRATIONANDSEQUENCENUMBER.Name = "REGISTRATIONANDSEQUENCENUMBER";
                    REGISTRATIONANDSEQUENCENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONANDSEQUENCENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONANDSEQUENCENUMBER.TextFont.Name = "Arial";
                    REGISTRATIONANDSEQUENCENUMBER.Value = @" {#REGISTRATIONNUMBER#} / {#SEQUENCENUMBER#}";

                    FILLDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 65, 200, 70, false);
                    FILLDATE.Name = "FILLDATE";
                    FILLDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FILLDATE.TextFormat = @"dd/MM/yyyy";
                    FILLDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FILLDATE.TextFont.Name = "Arial";
                    FILLDATE.Value = @"{#FILLINGDATE#}";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 25, 200, 48, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 12;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 25, 60, 44, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Arial Narrow";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 59, 155, 64, false);
                    NewField144.Name = "NewField144";
                    NewField144.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField144.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField144.TextFont.Name = "Arial";
                    NewField144.TextFont.Bold = true;
                    NewField144.Value = @":";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 65, 155, 70, false);
                    NewField145.Name = "NewField145";
                    NewField145.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField145.TextFont.Name = "Arial";
                    NewField145.TextFont.Bold = true;
                    NewField145.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    E2.GetE2ReportQuery_Class dataset_GetE2ReportQuery = ParentGroup.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);
                    SDATE.CalcValue = (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.StartDate) : "");
                    EDATE.CalcValue = (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.EndDate) : "");
                    DESCRIPTION.CalcValue = MyParentReport.PARTB.SDATE.FormattedValue + @" - " + MyParentReport.PARTB.EDATE.FormattedValue + @" TARİHLERİ ARASI E2 TEVHİT CETVELİ";
                    NewField44.CalcValue = NewField44.Value;
                    NewField55.CalcValue = NewField55.Value;
                    REGISTRATIONANDSEQUENCENUMBER.CalcValue = @" " + (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.RegistrationNumber) : "") + @" / " + (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.SequenceNumber) : "");
                    FILLDATE.CalcValue = (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.FillingDate) : "");
                    LOGO.CalcValue = LOGO.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField145.CalcValue = NewField145.Value;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { SDATE,EDATE,DESCRIPTION,NewField44,NewField55,REGISTRATIONANDSEQUENCENUMBER,FILLDATE,LOGO,NewField144,NewField145,HOSPITALNAME};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public E2Report MyParentReport
                {
                    get { return (E2Report)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine1;
                public TTReportField CHIEF;
                public TTReportField ACCOUNTANT;
                public TTReportField PHARMACY;
                public TTReportField APPROVAL; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 74;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 24, 200, 29, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.Value = @"Başeczacı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 24, 132, 29, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.Value = @"Sayman";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 24, 64, 29, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.Value = @"Eczane Şefi";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 44, 132, 49, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.Value = @"Onay";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 2, 200, 7, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.Value = @"* Bu çizelge her ay sonunda eczacı tarafından 3 nüsha hazırlanır.";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 200, 12, false);
                    NewField8.Name = "NewField8";
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.Value = @"* 3. nüshası eczacıda belge kayıt numarası verilene kadar takip için bekletilir.";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 12, 200, 17, false);
                    NewField9.Name = "NewField9";
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.MultiLine = EvetHayirEnum.ehEvet;
                    NewField9.WordBreak = EvetHayirEnum.ehEvet;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.Value = @"* 1. ve 2. nüshası saymanlığa verilir. Belge kayıt numarası verildikten sonra 2. nüshası eczacıya teslim edilir.";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 17, 200, 22, false);
                    NewField10.Name = "NewField10";
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.Value = @"* Bu belge teftişe tabii olup istendiğinde müfettişe verilmek üzere dosyada muhafaza edilir.";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 64, 200, 69, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.Name = "Arial Narrow";
                    PAGENUMBER.Value = @"Sayfa : {@pagenumber@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 200, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    CHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 29, 64, 44, false);
                    CHIEF.Name = "CHIEF";
                    CHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHIEF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHIEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    CHIEF.WordBreak = EvetHayirEnum.ehEvet;
                    CHIEF.TextFont.Name = "Arial";
                    CHIEF.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 29, 132, 44, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.TextFont.Name = "Arial";
                    ACCOUNTANT.Value = @"";

                    PHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 29, 200, 44, false);
                    PHARMACY.Name = "PHARMACY";
                    PHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHARMACY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PHARMACY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PHARMACY.MultiLine = EvetHayirEnum.ehEvet;
                    PHARMACY.WordBreak = EvetHayirEnum.ehEvet;
                    PHARMACY.TextFont.Name = "Arial";
                    PHARMACY.Value = @"";

                    APPROVAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 49, 132, 64, false);
                    APPROVAL.Name = "APPROVAL";
                    APPROVAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPROVAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    APPROVAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    APPROVAL.MultiLine = EvetHayirEnum.ehEvet;
                    APPROVAL.WordBreak = EvetHayirEnum.ehEvet;
                    APPROVAL.TextFont.Name = "Arial";
                    APPROVAL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    E2.GetE2ReportQuery_Class dataset_GetE2ReportQuery = ParentGroup.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    PAGENUMBER.CalcValue = @"Sayfa : " + ParentReport.CurrentPageNumber.ToString();
                    CHIEF.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    PHARMACY.CalcValue = @"";
                    APPROVAL.CalcValue = @"";
                    return new TTReportObject[] { NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,PAGENUMBER,CHIEF,ACCOUNTANT,PHARMACY,APPROVAL};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((E2Report)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            E2 eSchedule = (E2)ctx.GetObject(new Guid(objectID), typeof(E2));
            ResUser user;
            
            if(eSchedule.GetState("Record", true) != null)
            {
                user = (ResUser)eSchedule.GetState("Record", true).User.UserObject;
                
                if(user.Title != null)
                    CHIEF.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString() + "\n" + user.Name.ToString();
                else
                    CHIEF.CalcValue = user.Name.ToString();
                
                if(user.Rank != null)
                    CHIEF.CalcValue = CHIEF.CalcValue + "\n" + user.Rank.Name.ToString();
            }
            
            if(eSchedule.GetState("AccountancyApproval", true) != null)
            {
                user = (ResUser)eSchedule.GetState("AccountancyApproval", true).User.UserObject;
                
                if(user.Title != null)
                    ACCOUNTANT.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString() + "\n" + user.Name.ToString();
                else
                    ACCOUNTANT.CalcValue = user.Name.ToString();
                
                if(user.Rank != null)
                    ACCOUNTANT.CalcValue = ACCOUNTANT.CalcValue + "\n" + user.Rank.Name.ToString();
            }
            
            if(eSchedule.GetState("PharmacyApproval", true) != null)
            {
                user = (ResUser)eSchedule.GetState("PharmacyApproval", true).User.UserObject;
                
                if(user.Title != null)
                    PHARMACY.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString() + "\n" + user.Name.ToString();
                else
                    PHARMACY.CalcValue = user.Name.ToString();
                
                if(user.Rank != null)
                    PHARMACY.CalcValue = PHARMACY.CalcValue + "\n" + user.Rank.Name.ToString();
            }
            
            if(eSchedule.GetState("MedicalSuperintendentApproval", true) != null)
            {
                user = (ResUser)eSchedule.GetState("MedicalSuperintendentApproval", true).User.UserObject;
                
                if(user.Title != null)
                    APPROVAL.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString() + "\n" + user.Name.ToString();
                else
                    APPROVAL.CalcValue = user.Name.ToString();
                
                if(user.Rank != null)
                    APPROVAL.CalcValue = APPROVAL.CalcValue + "\n" + user.Rank.Name.ToString();
            }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public E2Report MyParentReport
            {
                get { return (E2Report)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField YALNIZ { get {return Footer().YALNIZ;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                E2.GetE2ReportQuery_Class dataSet_GetE2ReportQuery = ParentGroup.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);    
                return new object[] {(dataSet_GetE2ReportQuery==null ? null : dataSet_GetE2ReportQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public E2Report MyParentReport
                {
                    get { return (E2Report)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 200, 6, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField0.TextFont.Name = "Arial";
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"Miktarı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 180, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Ölçü";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 160, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İlaçların İsimleri";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 32, 6, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"S. Nu.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    E2.GetE2ReportQuery_Class dataset_GetE2ReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField0,NewField1,NewField2,NewField3};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //            Stop
//RefType = h.GetParameter("STOCK","REFERENCEDETAILTYPE",False,"STOCKCARD")
//If CStr(RefType) = "STOCKCARD" Then
//sql = sql & "Select SUM(D.AMOUNT) AS AMOUNT,D.STOCKCARDID,C.MAINCLASSID,C.CLASSID,C.ORDERNO "
//sql = sql & "FROM STOCKMAINTRANSACTIONDETAIL D, STOCKCARD C "
//sql = sql & "WHERE D.STOCKCARDID=C.ID "
//sql = sql & "And D.CANCELLED=0 "
//sql = sql & "And D.MAINTRANSACTIONID = @STOCKMAINTRANSACTIONID@ "
//sql = sql & "And D.AMOUNT <> 0 "
//sql = sql & "GROUP BY D.STOCKCARDID,C.MAINCLASSID,C.CLASSID,C.ORDERNO "
//sql = sql & "ORDER BY D.STOCKCARDID,C.MAINCLASSID,C.CLASSID,C.ORDERNO "
//Else 
//sql = sql & "Select D.* FROM STOCKMAINTRANSACTIONDETAIL D, STOCKCARD C "
//sql = sql & "WHERE D.STOCKCARDID=C.ID "
//sql = sql & "And D.CANCELLED=0 "
//sql = sql & "And D.MAINTRANSACTIONID = @STOCKMAINTRANSACTIONID@ "
//sql = sql & "And D.AMOUNT <> 0 "
//sql = sql & "ORDER BY D.STOCKCARDID,C.MAINCLASSID,C.CLASSID,C.ORDERNO "
//End If
//RepG.Subgroup.QueryString = Sql
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public E2Report MyParentReport
                {
                    get { return (E2Report)ParentReport; }
                }
                
                public TTReportField YALNIZ;
                public TTReportField COUNTTEXT; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    YALNIZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 200, 6, false);
                    YALNIZ.Name = "YALNIZ";
                    YALNIZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    YALNIZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YALNIZ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YALNIZ.TextFont.Name = "Arial";
                    YALNIZ.Value = @"/////////////////////////////////////////////////////////////////////////////////////////////Yalnız {@subgroupcount@} ({%COUNTTEXT%}) kalemdir. /////////////////////////////////////////////////////////////////////////////////////////////";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 0, 225, 5, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.TextFormat = @"NUMBERTEXT";
                    COUNTTEXT.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    E2.GetE2ReportQuery_Class dataset_GetE2ReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);
                    COUNTTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    YALNIZ.CalcValue = @"/////////////////////////////////////////////////////////////////////////////////////////////Yalnız " + (ParentGroup.SubGroupCount - 1).ToString() + @" (" + MyParentReport.PARTA.COUNTTEXT.FormattedValue + @") kalemdir. /////////////////////////////////////////////////////////////////////////////////////////////";
                    return new TTReportObject[] { COUNTTEXT,YALNIZ};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public E2Report MyParentReport
            {
                get { return (E2Report)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField DRUGNAME { get {return Body().DRUGNAME;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
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

                E2.GetE2ReportQuery_Class dataSet_GetE2ReportQuery = ParentGroup.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);    
                return new object[] {(dataSet_GetE2ReportQuery==null ? null : dataSet_GetE2ReportQuery.ObjectID)};
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
                public E2Report MyParentReport
                {
                    get { return (E2Report)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField ORDERNO;
                public TTReportField DRUGNAME;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 200, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"###,##0";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{#PARTB.AMOUNT#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 180, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.Value = @"{#PARTB.DISTRIBUTIONTYPE#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 32, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@counter@}";

                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 160, 5, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUGNAME.TextFont.Name = "Arial";
                    DRUGNAME.Value = @" {#PARTB.NATOSTOCKNO#} {#PARTB.MATERIAL#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 20, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 180, 0, 180, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 0, 160, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 32, 0, 32, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    E2.GetE2ReportQuery_Class dataset_GetE2ReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<E2.GetE2ReportQuery_Class>(0);
                    AMOUNT.CalcValue = (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.Amount) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.DistributionType) : "");
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    DRUGNAME.CalcValue = @" " + (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.NATOStockNO) : "") + @" " + (dataset_GetE2ReportQuery != null ? Globals.ToStringCore(dataset_GetE2ReportQuery.Material) : "");
                    return new TTReportObject[] { AMOUNT,DISTRIBUTIONTYPE,ORDERNO,DRUGNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public E2Report()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "E2 Çizelgesi", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "E2REPORT";
            Caption = "E2 TEVHİT CETVELİ";
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
            fd.TextFont.Name = "Courier New";
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