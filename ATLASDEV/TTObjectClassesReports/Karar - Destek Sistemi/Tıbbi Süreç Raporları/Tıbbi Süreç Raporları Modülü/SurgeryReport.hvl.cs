
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
    /// Ameliyat Raporu
    /// </summary>
    public partial class SurgeryReport : TTReport
    {
#region Methods
   public string a = string.Empty;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class SARFMALZEMEGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public SARFMALZEMEGroupBody Body()
            {
                return (SARFMALZEMEGroupBody)_body;
            }
            public TTReportField SUTISIM { get {return Body().SUTISIM;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField OLCUBIRIMI { get {return Body().OLCUBIRIMI;} }
            public TTReportField UBB { get {return Body().UBB;} }
            public SARFMALZEMEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SARFMALZEMEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Surgery.DirectPurchaseExpenditureInfoNQL_Class>("DirectPurchaseExpenditureInfoNQL", Surgery.DirectPurchaseExpenditureInfoNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SARFMALZEMEGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SARFMALZEMEGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField SUTISIM;
                public TTReportField MIKTAR;
                public TTReportField OLCUBIRIMI;
                public TTReportField UBB; 
                public SARFMALZEMEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SUTISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 229, 5, false);
                    SUTISIM.Name = "SUTISIM";
                    SUTISIM.Visible = EvetHayirEnum.ehHayir;
                    SUTISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTISIM.MultiLine = EvetHayirEnum.ehEvet;
                    SUTISIM.WordBreak = EvetHayirEnum.ehEvet;
                    SUTISIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTISIM.TextFont.Name = "Arial";
                    SUTISIM.TextFont.Size = 8;
                    SUTISIM.Value = @"{#SUTISIM#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 1, 248, 5, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.Visible = EvetHayirEnum.ehHayir;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.Value = @"{#MIKTAR#}";

                    OLCUBIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 6, 248, 10, false);
                    OLCUBIRIMI.Name = "OLCUBIRIMI";
                    OLCUBIRIMI.Visible = EvetHayirEnum.ehHayir;
                    OLCUBIRIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ObjectDefName = "DistributionTypeDefinition";
                    OLCUBIRIMI.DataMember = "DISTRIBUTIONTYPE";
                    OLCUBIRIMI.TextFont.Name = "Arial";
                    OLCUBIRIMI.TextFont.Size = 8;
                    OLCUBIRIMI.Value = @"{#OLCUBIRIMI#}";

                    UBB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 6, 229, 10, false);
                    UBB.Name = "UBB";
                    UBB.Visible = EvetHayirEnum.ehHayir;
                    UBB.FieldType = ReportFieldTypeEnum.ftVariable;
                    UBB.MultiLine = EvetHayirEnum.ehEvet;
                    UBB.WordBreak = EvetHayirEnum.ehEvet;
                    UBB.ExpandTabs = EvetHayirEnum.ehEvet;
                    UBB.ObjectDefName = "ProductDefinition";
                    UBB.DataMember = "PRODUCTNUMBER";
                    UBB.TextFont.Name = "Arial";
                    UBB.TextFont.Size = 8;
                    UBB.Value = @"{#UBB#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.DirectPurchaseExpenditureInfoNQL_Class dataset_DirectPurchaseExpenditureInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<Surgery.DirectPurchaseExpenditureInfoNQL_Class>(0);
                    SUTISIM.CalcValue = (dataset_DirectPurchaseExpenditureInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseExpenditureInfoNQL.Sutisim) : "");
                    MIKTAR.CalcValue = (dataset_DirectPurchaseExpenditureInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseExpenditureInfoNQL.Miktar) : "");
                    OLCUBIRIMI.CalcValue = (dataset_DirectPurchaseExpenditureInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseExpenditureInfoNQL.Olcubirimi) : "");
                    OLCUBIRIMI.PostFieldValueCalculation();
                    UBB.CalcValue = (dataset_DirectPurchaseExpenditureInfoNQL != null ? Globals.ToStringCore(dataset_DirectPurchaseExpenditureInfoNQL.Ubb) : "");
                    UBB.PostFieldValueCalculation();
                    return new TTReportObject[] { SUTISIM,MIKTAR,OLCUBIRIMI,UBB};
                }

                public override void RunScript()
                {
#region SARFMALZEME BODY_Script
                    ((SurgeryReport)ParentReport).a += "" + this.SUTISIM.CalcValue + " - " + this.UBB.CalcValue + " - " + this.MIKTAR.CalcValue + " " + this.OLCUBIRIMI.CalcValue + ", ";
               //
#endregion SARFMALZEME BODY_Script
                }
            }

        }

        public SARFMALZEMEGroup SARFMALZEME;

        public partial class HEADERGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField FatherName { get {return Header().FatherName;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField BirthPlaceAndDate { get {return Header().BirthPlaceAndDate;} }
            public TTReportField NewField71 { get {return Header().NewField71;} }
            public TTReportField PatientTCNo { get {return Header().PatientTCNo;} }
            public TTReportField NewField81 { get {return Header().NewField81;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Surgery.SurgeryReportNQL_Class>("SurgeryReportNQL2", Surgery.SurgeryReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField PatientName;
                public TTReportField NewField4;
                public TTReportField NewField7;
                public TTReportField FatherName;
                public TTReportField NewField3;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField BirthPlaceAndDate;
                public TTReportField NewField71;
                public TTReportField PatientTCNo;
                public TTReportField NewField81;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO;
                public TTReportField BirthDate; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 79;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 34, 188, 42, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"AMELİYAT RAPORU";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 63, 47, 68, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Hasta Adı";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 63, 114, 68, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 9;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 68, 47, 73, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Baba Adı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 73, 47, 78, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Doğum Yeri / Tarihi";

                    FatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 68, 114, 73, false);
                    FatherName.Name = "FatherName";
                    FatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FatherName.TextFont.Name = "Arial Narrow";
                    FatherName.TextFont.Size = 9;
                    FatherName.Value = @"{#FATHERNAME#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 63, 50, 68, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 68, 50, 73, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Size = 11;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 73, 50, 78, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 11;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @":";

                    BirthPlaceAndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 73, 114, 78, false);
                    BirthPlaceAndDate.Name = "BirthPlaceAndDate";
                    BirthPlaceAndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlaceAndDate.TextFont.Name = "Arial Narrow";
                    BirthPlaceAndDate.TextFont.Size = 9;
                    BirthPlaceAndDate.Value = @"{#CITYNAME#} - {#TOWNNAME#} / {%BirthDate%}";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 47, 63, false);
                    NewField71.Name = "NewField71";
                    NewField71.TextFont.Name = "Arial Narrow";
                    NewField71.TextFont.Size = 11;
                    NewField71.TextFont.Bold = true;
                    NewField71.Value = @"Hasta T.C. No";

                    PatientTCNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 58, 114, 63, false);
                    PatientTCNo.Name = "PatientTCNo";
                    PatientTCNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientTCNo.TextFont.Name = "Arial Narrow";
                    PatientTCNo.TextFont.Size = 9;
                    PatientTCNo.Value = @"{#UNIQUEREFNO#}";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 58, 50, 63, false);
                    NewField81.Name = "NewField81";
                    NewField81.TextFont.Name = "Arial Narrow";
                    NewField81.TextFont.Size = 11;
                    NewField81.TextFont.Bold = true;
                    NewField81.Value = @":";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 188, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"LOGO";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 60, 248, 65, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.Visible = EvetHayirEnum.ehHayir;
                    BirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthDate.TextFormat = @"Medium Date";
                    BirthDate.TextFont.Name = "Arial Narrow";
                    BirthDate.TextFont.Size = 9;
                    BirthDate.Value = @"{#BIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryReportNQL_Class dataset_SurgeryReportNQL2 = ParentGroup.rsGroup.GetCurrentRecord<Surgery.SurgeryReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PatientName.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Name) : "") + @" " + (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Surname) : "");
                    NewField4.CalcValue = NewField4.Value;
                    NewField7.CalcValue = NewField7.Value;
                    FatherName.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.FatherName) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    BirthDate.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.BirthDate) : "");
                    BirthPlaceAndDate.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Cityname) : "") + @" - " + (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Townname) : "") + @" / " + MyParentReport.HEADER.BirthDate.FormattedValue;
                    NewField71.CalcValue = NewField71.Value;
                    PatientTCNo.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.UniqueRefNo) : "");
                    NewField81.CalcValue = NewField81.Value;
                    LOGO.CalcValue = LOGO.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField2,PatientName,NewField4,NewField7,FatherName,NewField3,NewField21,NewField22,BirthDate,BirthPlaceAndDate,NewField71,PatientTCNo,NewField81,LOGO,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField RAPORBOLUMU { get {return Header().RAPORBOLUMU;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField ISTEKDR1 { get {return Footer().ISTEKDR1;} }
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
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField RAPORBOLUMU; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPORBOLUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 202, 6, false);
                    RAPORBOLUMU.Name = "RAPORBOLUMU";
                    RAPORBOLUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORBOLUMU.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORBOLUMU.TextFormat = @"Medium Date";
                    RAPORBOLUMU.TextFont.Name = "Arial Narrow";
                    RAPORBOLUMU.TextFont.Size = 11;
                    RAPORBOLUMU.TextFont.Bold = true;
                    RAPORBOLUMU.Value = @"{#HEADER.FROMRES#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryReportNQL_Class dataset_SurgeryReportNQL2 = MyParentReport.HEADER.rsGroup.GetCurrentRecord<Surgery.SurgeryReportNQL_Class>(0);
                    RAPORBOLUMU.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Fromres) : "");
                    return new TTReportObject[] { RAPORBOLUMU};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField UZMANLIKDAL;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO;
                public TTReportField ISTEKDR1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 27;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 2, 65, 6, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#HEADER.SPECIALITY#}";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 37, 10, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#HEADER.RANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 37, 6, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#HEADER.MILITARYCLASS#}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 37, 14, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#HEADER.WORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 14, 65, 18, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#HEADER.DIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 6, 65, 10, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 37, 18, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 37, 22, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#HEADER.TITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 10, 65, 14, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#HEADER.EMPLOYMENTRECORDID#}";

                    ISTEKDR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 4, 184, 21, false);
                    ISTEKDR1.Name = "ISTEKDR1";
                    ISTEKDR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR1.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR1.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR1.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR1.TextFont.Name = "Arial Narrow";
                    ISTEKDR1.TextFont.Size = 9;
                    ISTEKDR1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryReportNQL_Class dataset_SurgeryReportNQL2 = MyParentReport.HEADER.rsGroup.GetCurrentRecord<Surgery.SurgeryReportNQL_Class>(0);
                    UZMANLIKDAL.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Speciality) : "");
                    RUTBEONAY.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Rank) : "");
                    SINIFONAY.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Militaryclass) : "");
                    GOREV.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Work) : "");
                    DIPLOMANO.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.DiplomaNo) : "");
                    UNVAN.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Title) : "");
                    SICILNO.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.EmploymentRecordID) : "");
                    ISTEKDR1.CalcValue = @"";
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { UZMANLIKDAL,RUTBEONAY,SINIFONAY,GOREV,DIPLOMANO,UNVAN,SICILNO,ISTEKDR1,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((SurgeryReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Surgery surgery = (Surgery)objectContext.GetObject(new Guid(objectID), "Surgery");

            if (surgery.ProcedureDoctor != null)
                this.ISTEKDR1.CalcValue = surgery.ProcedureDoctor.SignatureBlock;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RAPORTARIH { get {return Body().RAPORTARIH;} }
            public TTReportField LBL1 { get {return Body().LBL1;} }
            public TTReportField LBL2 { get {return Body().LBL2;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField LBL3 { get {return Body().LBL3;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField ASA { get {return Body().ASA;} }
            public TTReportField LBL11 { get {return Body().LBL11;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField ASAEnum { get {return Body().ASAEnum;} }
            public TTReportField AMELİYATTARIH { get {return Body().AMELİYATTARIH;} }
            public TTReportField LBL12 { get {return Body().LBL12;} }
            public TTReportField NewField1322 { get {return Body().NewField1322;} }
            public TTReportField LBL111 { get {return Body().LBL111;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField ANESTHESIATECHNIQUE { get {return Body().ANESTHESIATECHNIQUE;} }
            public TTReportField NewField12231 { get {return Body().NewField12231;} }
            public TTReportField SurgeryReport { get {return Body().SurgeryReport;} }
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
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField RAPORTARIH;
                public TTReportField LBL1;
                public TTReportField LBL2;
                public TTReportField RAPORNO;
                public TTReportField LBL3;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField ASA;
                public TTReportField LBL11;
                public TTReportField NewField1321;
                public TTReportField ASAEnum;
                public TTReportField AMELİYATTARIH;
                public TTReportField LBL12;
                public TTReportField NewField1322;
                public TTReportField LBL111;
                public TTReportField NewField11231;
                public TTReportField ANESTHESIATECHNIQUE;
                public TTReportField NewField12231;
                public TTReportField SurgeryReport; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 60;
                    RepeatCount = 0;
                    
                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 14, 105, 20, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"Medium Date";
                    RAPORTARIH.TextFont.Name = "Arial Narrow";
                    RAPORTARIH.TextFont.Size = 9;
                    RAPORTARIH.Value = @"{#HEADER.SURGERYREPORTDATE#}";

                    LBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 44, 20, false);
                    LBL1.Name = "LBL1";
                    LBL1.TextFont.Name = "Arial Narrow";
                    LBL1.TextFont.Size = 11;
                    LBL1.TextFont.Bold = true;
                    LBL1.Value = @"Rapor Tarih      ";

                    LBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 44, 14, false);
                    LBL2.Name = "LBL2";
                    LBL2.TextFont.Name = "Arial Narrow";
                    LBL2.TextFont.Size = 11;
                    LBL2.TextFont.Bold = true;
                    LBL2.Value = @"Ameliyat Rapor No";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 8, 105, 14, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 9;
                    RAPORNO.Value = @"{#HEADER.SURGERYREPORTNO#}";

                    LBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 44, 26, false);
                    LBL3.Name = "LBL3";
                    LBL3.TextFont.Name = "Arial Narrow";
                    LBL3.TextFont.Size = 11;
                    LBL3.TextFont.Bold = true;
                    LBL3.Value = @"Rapor            ";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 20, 50, 26, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 14, 50, 20, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.Size = 11;
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @":";

                    ASA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 9, 233, 14, false);
                    ASA.Name = "ASA";
                    ASA.Visible = EvetHayirEnum.ehHayir;
                    ASA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASA.TextFormat = @"Medium Date";
                    ASA.ObjectDefName = "AnesthesiaAndReanimation";
                    ASA.DataMember = "ASATYPE";
                    ASA.TextFont.Name = "Arial Narrow";
                    ASA.TextFont.Size = 9;
                    ASA.Value = @"{#HEADER.ANESTHESIAANDREANIMATION#}";

                    LBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 136, 14, false);
                    LBL11.Name = "LBL11";
                    LBL11.TextFont.Name = "Arial Narrow";
                    LBL11.TextFont.Size = 11;
                    LBL11.TextFont.Bold = true;
                    LBL11.Value = @"ASA Kriteri    ";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 8, 140, 14, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Size = 11;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.Value = @":";

                    ASAEnum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 8, 202, 14, false);
                    ASAEnum.Name = "ASAEnum";
                    ASAEnum.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASAEnum.TextFormat = @"Medium Date";
                    ASAEnum.ObjectDefName = "AnesthesiaASATypeEnum";
                    ASAEnum.DataMember = "DISPLAYTEXT";
                    ASAEnum.TextFont.Name = "Arial Narrow";
                    ASAEnum.TextFont.Size = 9;
                    ASAEnum.Value = @"{#HEADER.ASATYPE#}";

                    AMELİYATTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 2, 105, 8, false);
                    AMELİYATTARIH.Name = "AMELİYATTARIH";
                    AMELİYATTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMELİYATTARIH.TextFormat = @"Medium Date";
                    AMELİYATTARIH.TextFont.Name = "Arial Narrow";
                    AMELİYATTARIH.TextFont.Size = 9;
                    AMELİYATTARIH.Value = @"{#HEADER.SURGERYSTARTTIME#}";

                    LBL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 44, 8, false);
                    LBL12.Name = "LBL12";
                    LBL12.TextFont.Name = "Arial Narrow";
                    LBL12.TextFont.Size = 11;
                    LBL12.TextFont.Bold = true;
                    LBL12.Value = @"Ameliyat Tarih      ";

                    NewField1322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 2, 50, 8, false);
                    NewField1322.Name = "NewField1322";
                    NewField1322.TextFont.Name = "Arial Narrow";
                    NewField1322.TextFont.Size = 11;
                    NewField1322.TextFont.Bold = true;
                    NewField1322.Value = @":";

                    LBL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 2, 136, 8, false);
                    LBL111.Name = "LBL111";
                    LBL111.TextFont.Name = "Arial Narrow";
                    LBL111.TextFont.Size = 11;
                    LBL111.TextFont.Bold = true;
                    LBL111.Value = @"Anestezi Tekniği";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 2, 140, 8, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Name = "Arial Narrow";
                    NewField11231.TextFont.Size = 11;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.Value = @":";

                    ANESTHESIATECHNIQUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 2, 202, 8, false);
                    ANESTHESIATECHNIQUE.Name = "ANESTHESIATECHNIQUE";
                    ANESTHESIATECHNIQUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANESTHESIATECHNIQUE.TextFormat = @"Medium Date";
                    ANESTHESIATECHNIQUE.ObjectDefName = "AnesthesiaTechniqueEnum";
                    ANESTHESIATECHNIQUE.DataMember = "DISPLAYTEXT";
                    ANESTHESIATECHNIQUE.TextFont.Name = "Arial Narrow";
                    ANESTHESIATECHNIQUE.TextFont.Size = 9;
                    ANESTHESIATECHNIQUE.Value = @"{#HEADER.ANESTHESIATECHNIQUE#}";

                    NewField12231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 8, 50, 14, false);
                    NewField12231.Name = "NewField12231";
                    NewField12231.TextFont.Name = "Arial Narrow";
                    NewField12231.TextFont.Size = 11;
                    NewField12231.TextFont.Bold = true;
                    NewField12231.Value = @":";

                    SurgeryReport = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 202, 59, false);
                    SurgeryReport.Name = "SurgeryReport";
                    SurgeryReport.TextFormat = @"Medium Date";
                    SurgeryReport.MultiLine = EvetHayirEnum.ehEvet;
                    SurgeryReport.NoClip = EvetHayirEnum.ehEvet;
                    SurgeryReport.WordBreak = EvetHayirEnum.ehEvet;
                    SurgeryReport.ExpandTabs = EvetHayirEnum.ehEvet;
                    SurgeryReport.TextFont.Name = "Arial Narrow";
                    SurgeryReport.TextFont.Size = 9;
                    SurgeryReport.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryReportNQL_Class dataset_SurgeryReportNQL2 = MyParentReport.HEADER.rsGroup.GetCurrentRecord<Surgery.SurgeryReportNQL_Class>(0);
                    RAPORTARIH.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.SurgeryReportDate) : "");
                    LBL1.CalcValue = LBL1.Value;
                    LBL2.CalcValue = LBL2.Value;
                    RAPORNO.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.SurgeryReportNo) : "");
                    LBL3.CalcValue = LBL3.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    ASA.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.Anesthesiaandreanimation) : "");
                    ASA.PostFieldValueCalculation();
                    LBL11.CalcValue = LBL11.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    ASAEnum.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.ASAType) : "");
                    ASAEnum.PostFieldValueCalculation();
                    AMELİYATTARIH.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.SurgeryStartTime) : "");
                    LBL12.CalcValue = LBL12.Value;
                    NewField1322.CalcValue = NewField1322.Value;
                    LBL111.CalcValue = LBL111.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    ANESTHESIATECHNIQUE.CalcValue = (dataset_SurgeryReportNQL2 != null ? Globals.ToStringCore(dataset_SurgeryReportNQL2.AnesthesiaTechnique) : "");
                    ANESTHESIATECHNIQUE.PostFieldValueCalculation();
                    NewField12231.CalcValue = NewField12231.Value;
                    SurgeryReport.CalcValue = SurgeryReport.Value;
                    return new TTReportObject[] { RAPORTARIH,LBL1,LBL2,RAPORNO,LBL3,NewField122,NewField123,ASA,LBL11,NewField1321,ASAEnum,AMELİYATTARIH,LBL12,NewField1322,LBL111,NewField11231,ANESTHESIATECHNIQUE,NewField12231,SurgeryReport};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SurgeryReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Surgery surgery = (Surgery)context.GetObject(new Guid(sObjectID),"Surgery");
            if(surgery.SurgeryReport != null)
                this.SurgeryReport.Value = TTReportTool.TTReport.HTMLtoText(surgery.SurgeryReport.ToString()) + "\r\n";
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            string b = ((SurgeryReport)ParentReport).a;
//            if(b.Length > 0)
//            {
//                this.MALZEME.CalcValue = "Ameliyat işleminde; " + b.Substring(0,b.Length-2) + " malzemeleri kullanımmıştır.";
//                ((SurgeryReport)ParentReport).a = "";
//            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class AMELIYATUSTGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public AMELIYATUSTGroupHeader Header()
            {
                return (AMELIYATUSTGroupHeader)_header;
            }

            new public AMELIYATUSTGroupFooter Footer()
            {
                return (AMELIYATUSTGroupFooter)_footer;
            }

            public TTReportField LBL1131 { get {return Header().LBL1131;} }
            public AMELIYATUSTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATUSTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new AMELIYATUSTGroupHeader(this);
                _footer = new AMELIYATUSTGroupFooter(this);

            }

            public partial class AMELIYATUSTGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField LBL1131; 
                public AMELIYATUSTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBL1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 201, 6, false);
                    LBL1131.Name = "LBL1131";
                    LBL1131.TextFont.Name = "Arial Narrow";
                    LBL1131.TextFont.Size = 11;
                    LBL1131.TextFont.Bold = true;
                    LBL1131.Value = @"Ameliyat Adı   ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL1131.CalcValue = LBL1131.Value;
                    return new TTReportObject[] { LBL1131};
                }
            }
            public partial class AMELIYATUSTGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                 
                public AMELIYATUSTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public AMELIYATUSTGroup AMELIYATUST;

        public partial class AMELIYATGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public AMELIYATGroupBody Body()
            {
                return (AMELIYATGroupBody)_body;
            }
            public TTReportField AMELIYATISLEMI { get {return Body().AMELIYATISLEMI;} }
            public AMELIYATGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MainSurgeryProcedure.GetByMainSurgery_Class>("GetByMainSurgery", MainSurgeryProcedure.GetByMainSurgery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new AMELIYATGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class AMELIYATGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField AMELIYATISLEMI; 
                public AMELIYATGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    AMELIYATISLEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 201, 6, false);
                    AMELIYATISLEMI.Name = "AMELIYATISLEMI";
                    AMELIYATISLEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMELIYATISLEMI.TextFont.Name = "Arial Narrow";
                    AMELIYATISLEMI.TextFont.Size = 9;
                    AMELIYATISLEMI.Value = @"{#PROCEDURENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainSurgeryProcedure.GetByMainSurgery_Class dataset_GetByMainSurgery = ParentGroup.rsGroup.GetCurrentRecord<MainSurgeryProcedure.GetByMainSurgery_Class>(0);
                    AMELIYATISLEMI.CalcValue = (dataset_GetByMainSurgery != null ? Globals.ToStringCore(dataset_GetByMainSurgery.Procedurename) : "");
                    return new TTReportObject[] { AMELIYATISLEMI};
                }
            }

        }

        public AMELIYATGroup AMELIYAT;

        public partial class AMELIYATEKIPUSTGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public AMELIYATEKIPUSTGroupHeader Header()
            {
                return (AMELIYATEKIPUSTGroupHeader)_header;
            }

            new public AMELIYATEKIPUSTGroupFooter Footer()
            {
                return (AMELIYATEKIPUSTGroupFooter)_footer;
            }

            public TTReportField LBL131 { get {return Header().LBL131;} }
            public AMELIYATEKIPUSTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATEKIPUSTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new AMELIYATEKIPUSTGroupHeader(this);
                _footer = new AMELIYATEKIPUSTGroupFooter(this);

            }

            public partial class AMELIYATEKIPUSTGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField LBL131; 
                public AMELIYATEKIPUSTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBL131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 193, 6, false);
                    LBL131.Name = "LBL131";
                    LBL131.TextFont.Name = "Arial Narrow";
                    LBL131.TextFont.Size = 11;
                    LBL131.TextFont.Bold = true;
                    LBL131.Value = @"Ameliyata Katılan Ekip      ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL131.CalcValue = LBL131.Value;
                    return new TTReportObject[] { LBL131};
                }
            }
            public partial class AMELIYATEKIPUSTGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                 
                public AMELIYATEKIPUSTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public AMELIYATEKIPUSTGroup AMELIYATEKIPUST;

        public partial class AMELIYATEKIPGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public AMELIYATEKIPGroupBody Body()
            {
                return (AMELIYATEKIPGroupBody)_body;
            }
            public TTReportField PERSONEL { get {return Body().PERSONEL;} }
            public TTReportField ROLE { get {return Body().ROLE;} }
            public TTReportField UNVAN { get {return Body().UNVAN;} }
            public AMELIYATEKIPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATEKIPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SurgeryPersonnel.GetAllPersonelBySurgery_Class>("GetAllPersonelBySurgery", SurgeryPersonnel.GetAllPersonelBySurgery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new AMELIYATEKIPGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class AMELIYATEKIPGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField PERSONEL;
                public TTReportField ROLE;
                public TTReportField UNVAN; 
                public AMELIYATEKIPGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    PERSONEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 1, 112, 6, false);
                    PERSONEL.Name = "PERSONEL";
                    PERSONEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONEL.TextFont.Name = "Arial Narrow";
                    PERSONEL.TextFont.Size = 9;
                    PERSONEL.Value = @"{#PERSONNELNAME#}";

                    ROLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 1, 160, 6, false);
                    ROLE.Name = "ROLE";
                    ROLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROLE.ObjectDefName = "SurgeryRoleEnum";
                    ROLE.DataMember = "DISPLAYTEXT";
                    ROLE.TextFont.Name = "Arial Narrow";
                    ROLE.TextFont.Size = 9;
                    ROLE.Value = @"{#ROLE#}";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 39, 6, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.ObjectDefName = "UserTitleEnum";
                    UNVAN.DataMember = "DISPLAYTEXT";
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#TITLE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SurgeryPersonnel.GetAllPersonelBySurgery_Class dataset_GetAllPersonelBySurgery = ParentGroup.rsGroup.GetCurrentRecord<SurgeryPersonnel.GetAllPersonelBySurgery_Class>(0);
                    PERSONEL.CalcValue = (dataset_GetAllPersonelBySurgery != null ? Globals.ToStringCore(dataset_GetAllPersonelBySurgery.Personnelname) : "");
                    ROLE.CalcValue = (dataset_GetAllPersonelBySurgery != null ? Globals.ToStringCore(dataset_GetAllPersonelBySurgery.Role) : "");
                    ROLE.PostFieldValueCalculation();
                    UNVAN.CalcValue = (dataset_GetAllPersonelBySurgery != null ? Globals.ToStringCore(dataset_GetAllPersonelBySurgery.Title) : "");
                    UNVAN.PostFieldValueCalculation();
                    return new TTReportObject[] { PERSONEL,ROLE,UNVAN};
                }
            }

        }

        public AMELIYATEKIPGroup AMELIYATEKIP;

        public partial class ANSETEZIUSTGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public ANSETEZIUSTGroupHeader Header()
            {
                return (ANSETEZIUSTGroupHeader)_header;
            }

            new public ANSETEZIUSTGroupFooter Footer()
            {
                return (ANSETEZIUSTGroupFooter)_footer;
            }

            public TTReportField LBL131 { get {return Header().LBL131;} }
            public ANSETEZIUSTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANSETEZIUSTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ANSETEZIUSTGroupHeader(this);
                _footer = new ANSETEZIUSTGroupFooter(this);

            }

            public partial class ANSETEZIUSTGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField LBL131; 
                public ANSETEZIUSTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBL131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 193, 6, false);
                    LBL131.Name = "LBL131";
                    LBL131.TextFont.Name = "Arial Narrow";
                    LBL131.TextFont.Size = 11;
                    LBL131.TextFont.Bold = true;
                    LBL131.Value = @"Anesteziye Katılan Ekip      ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL131.CalcValue = LBL131.Value;
                    return new TTReportObject[] { LBL131};
                }
            }
            public partial class ANSETEZIUSTGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                 
                public ANSETEZIUSTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ANSETEZIUSTGroup ANSETEZIUST;

        public partial class ANESTEZIGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public ANESTEZIGroupBody Body()
            {
                return (ANESTEZIGroupBody)_body;
            }
            public TTReportField PERSONELANESTEZI { get {return Body().PERSONELANESTEZI;} }
            public TTReportField ROLEANESTEZİ { get {return Body().ROLEANESTEZİ;} }
            public TTReportField UNVANANESTEZİ { get {return Body().UNVANANESTEZİ;} }
            public ANESTEZIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANESTEZIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AnesthesiaPersonnel.GetBySurgery_Class>("GetBySurgery", AnesthesiaPersonnel.GetBySurgery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ANESTEZIGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ANESTEZIGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField PERSONELANESTEZI;
                public TTReportField ROLEANESTEZİ;
                public TTReportField UNVANANESTEZİ; 
                public ANESTEZIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    PERSONELANESTEZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 1, 112, 6, false);
                    PERSONELANESTEZI.Name = "PERSONELANESTEZI";
                    PERSONELANESTEZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONELANESTEZI.TextFont.Name = "Arial Narrow";
                    PERSONELANESTEZI.TextFont.Size = 9;
                    PERSONELANESTEZI.Value = @"{#NAME#}";

                    ROLEANESTEZİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 1, 160, 6, false);
                    ROLEANESTEZİ.Name = "ROLEANESTEZİ";
                    ROLEANESTEZİ.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROLEANESTEZİ.TextFont.Name = "Arial Narrow";
                    ROLEANESTEZİ.TextFont.Size = 9;
                    ROLEANESTEZİ.Value = @"{#ROLE#}";

                    UNVANANESTEZİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 39, 6, false);
                    UNVANANESTEZİ.Name = "UNVANANESTEZİ";
                    UNVANANESTEZİ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVANANESTEZİ.ObjectDefName = "UserTitleEnum";
                    UNVANANESTEZİ.DataMember = "DISPLAYTEXT";
                    UNVANANESTEZİ.TextFont.Name = "Arial Narrow";
                    UNVANANESTEZİ.TextFont.Size = 9;
                    UNVANANESTEZİ.Value = @"{#TITLE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnesthesiaPersonnel.GetBySurgery_Class dataset_GetBySurgery = ParentGroup.rsGroup.GetCurrentRecord<AnesthesiaPersonnel.GetBySurgery_Class>(0);
                    PERSONELANESTEZI.CalcValue = (dataset_GetBySurgery != null ? Globals.ToStringCore(dataset_GetBySurgery.Name) : "");
                    ROLEANESTEZİ.CalcValue = (dataset_GetBySurgery != null ? Globals.ToStringCore(dataset_GetBySurgery.Role) : "");
                    UNVANANESTEZİ.CalcValue = (dataset_GetBySurgery != null ? Globals.ToStringCore(dataset_GetBySurgery.Title) : "");
                    UNVANANESTEZİ.PostFieldValueCalculation();
                    return new TTReportObject[] { PERSONELANESTEZI,ROLEANESTEZİ,UNVANANESTEZİ};
                }
            }

        }

        public ANESTEZIGroup ANESTEZI;

        public partial class SUBMAINAGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public SUBMAINAGroupHeader Header()
            {
                return (SUBMAINAGroupHeader)_header;
            }

            new public SUBMAINAGroupFooter Footer()
            {
                return (SUBMAINAGroupFooter)_footer;
            }

            public TTReportField RAPORSUBBOLUMU { get {return Header().RAPORSUBBOLUMU;} }
            public TTReportField SUBSURGERYOBJECTID { get {return Header().SUBSURGERYOBJECTID;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField ISTEKDR11 { get {return Footer().ISTEKDR11;} }
            public SUBMAINAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBMAINAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>("SubSurgeryReportBySurgeryNQL", SubSurgery.SubSurgeryReportBySurgeryNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SUBMAINAGroupHeader(this);
                _footer = new SUBMAINAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SUBMAINAGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField RAPORSUBBOLUMU;
                public TTReportField SUBSURGERYOBJECTID; 
                public SUBMAINAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORSUBBOLUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 198, 18, false);
                    RAPORSUBBOLUMU.Name = "RAPORSUBBOLUMU";
                    RAPORSUBBOLUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSUBBOLUMU.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSUBBOLUMU.TextFormat = @"Medium Date";
                    RAPORSUBBOLUMU.TextFont.Name = "Arial Narrow";
                    RAPORSUBBOLUMU.TextFont.Size = 11;
                    RAPORSUBBOLUMU.TextFont.Bold = true;
                    RAPORSUBBOLUMU.Value = @"{#SUBFROMRES#}";

                    SUBSURGERYOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 239, 5, false);
                    SUBSURGERYOBJECTID.Name = "SUBSURGERYOBJECTID";
                    SUBSURGERYOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    SUBSURGERYOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBSURGERYOBJECTID.TextFont.Name = "Arial Narrow";
                    SUBSURGERYOBJECTID.TextFont.Size = 9;
                    SUBSURGERYOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgery.SubSurgeryReportBySurgeryNQL_Class dataset_SubSurgeryReportBySurgeryNQL = ParentGroup.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>(0);
                    RAPORSUBBOLUMU.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Subfromres) : "");
                    SUBSURGERYOBJECTID.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.ObjectID) : "");
                    return new TTReportObject[] { RAPORSUBBOLUMU,SUBSURGERYOBJECTID};
                }
            }
            public partial class SUBMAINAGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField UZMANLIKDAL;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO;
                public TTReportField ISTEKDR11; 
                public SUBMAINAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 65, 5, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#SPECIALITY#}";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 5, 37, 9, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#RANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 37, 5, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#MILITARYCLASS#}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 9, 37, 13, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#WORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 13, 65, 17, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 5, 65, 9, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 37, 17, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 37, 21, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#TITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 9, 65, 13, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#EMPLOYMENTRECORDID#}";

                    ISTEKDR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 2, 187, 19, false);
                    ISTEKDR11.Name = "ISTEKDR11";
                    ISTEKDR11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR11.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR11.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR11.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR11.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR11.TextFont.Name = "Arial Narrow";
                    ISTEKDR11.TextFont.Size = 9;
                    ISTEKDR11.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgery.SubSurgeryReportBySurgeryNQL_Class dataset_SubSurgeryReportBySurgeryNQL = ParentGroup.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>(0);
                    UZMANLIKDAL.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Speciality) : "");
                    RUTBEONAY.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Rank) : "");
                    SINIFONAY.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Militaryclass) : "");
                    GOREV.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Work) : "");
                    DIPLOMANO.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.DiplomaNo) : "");
                    UNVAN.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Title) : "");
                    SICILNO.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.EmploymentRecordID) : "");
                    ISTEKDR11.CalcValue = @"";
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { UZMANLIKDAL,RUTBEONAY,SINIFONAY,GOREV,DIPLOMANO,UNVAN,SICILNO,ISTEKDR11,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region SUBMAINA FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((SurgeryReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Surgery surgery = (Surgery)objectContext.GetObject(new Guid(objectID), "Surgery");

            if (surgery.ProcedureDoctor != null)
                this.ISTEKDR11.CalcValue = surgery.ProcedureDoctor.SignatureBlock;
#endregion SUBMAINA FOOTER_Script
                }
            }

        }

        public SUBMAINAGroup SUBMAINA;

        public partial class SUBMAINGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public SUBMAINGroupBody Body()
            {
                return (SUBMAINGroupBody)_body;
            }
            public TTReportField RAPORTARIH { get {return Body().RAPORTARIH;} }
            public TTReportField LBL1 { get {return Body().LBL1;} }
            public TTReportField LBL2 { get {return Body().LBL2;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField LBL3 { get {return Body().LBL3;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField SubSurgeryRepor { get {return Body().SubSurgeryRepor;} }
            public SUBMAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBMAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Surgery.SurgeryReportNQL_Class>("SurgeryReportNQL", Surgery.SurgeryReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SUBMAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SUBMAINGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField RAPORTARIH;
                public TTReportField LBL1;
                public TTReportField LBL2;
                public TTReportField RAPORNO;
                public TTReportField LBL3;
                public TTReportField NewField1221;
                public TTReportField NewField1321;
                public TTReportField SubSurgeryRepor; 
                public SUBMAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 56;
                    RepeatCount = 0;
                    
                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 2, 105, 7, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"Medium Date";
                    RAPORTARIH.TextFont.Name = "Arial Narrow";
                    RAPORTARIH.TextFont.Size = 9;
                    RAPORTARIH.Value = @"{#SUBMAINA.SUBSURGERYREPORTDATE#}";

                    LBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 43, 7, false);
                    LBL1.Name = "LBL1";
                    LBL1.TextFont.Name = "Arial Narrow";
                    LBL1.TextFont.Size = 11;
                    LBL1.TextFont.Bold = true;
                    LBL1.Value = @"Rapor Tarih      ";

                    LBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 2, 141, 7, false);
                    LBL2.Name = "LBL2";
                    LBL2.TextFont.Name = "Arial Narrow";
                    LBL2.TextFont.Size = 11;
                    LBL2.TextFont.Bold = true;
                    LBL2.Value = @"Ameliyat Rapor No:";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, -11, 202, -6, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 9;
                    RAPORNO.Value = @"{#SUBMAINA.SUBSURGERYREPORTNO#}";

                    LBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 43, 18, false);
                    LBL3.Name = "LBL3";
                    LBL3.TextFont.Name = "Arial Narrow";
                    LBL3.TextFont.Size = 11;
                    LBL3.TextFont.Bold = true;
                    LBL3.Value = @"Rapor            ";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 13, 49, 18, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 11;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 2, 49, 7, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Size = 11;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.Value = @":";

                    SubSurgeryRepor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 202, 52, false);
                    SubSurgeryRepor.Name = "SubSurgeryRepor";
                    SubSurgeryRepor.TextFormat = @"Medium Date";
                    SubSurgeryRepor.MultiLine = EvetHayirEnum.ehEvet;
                    SubSurgeryRepor.NoClip = EvetHayirEnum.ehEvet;
                    SubSurgeryRepor.WordBreak = EvetHayirEnum.ehEvet;
                    SubSurgeryRepor.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubSurgeryRepor.TextFont.Name = "Arial Narrow";
                    SubSurgeryRepor.TextFont.Size = 9;
                    SubSurgeryRepor.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryReportNQL_Class dataset_SurgeryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Surgery.SurgeryReportNQL_Class>(0);
                    SubSurgery.SubSurgeryReportBySurgeryNQL_Class dataset_SubSurgeryReportBySurgeryNQL = MyParentReport.SUBMAINA.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportBySurgeryNQL_Class>(0);
                    RAPORTARIH.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Subsurgeryreportdate) : "");
                    LBL1.CalcValue = LBL1.Value;
                    LBL2.CalcValue = LBL2.Value;
                    RAPORNO.CalcValue = (dataset_SubSurgeryReportBySurgeryNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportBySurgeryNQL.Subsurgeryreportno) : "");
                    LBL3.CalcValue = LBL3.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    SubSurgeryRepor.CalcValue = SubSurgeryRepor.Value;
                    return new TTReportObject[] { RAPORTARIH,LBL1,LBL2,RAPORNO,LBL3,NewField1221,NewField1321,SubSurgeryRepor};
                }
                public override void RunPreScript()
                {
#region SUBMAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SurgeryReport)ParentReport).SUBMAINA.SUBSURGERYOBJECTID.CalcValue;// this.SUBSURGERYOBJECTID.CalcValue;
            SubSurgery subSurgery = (SubSurgery)context.GetObject(new Guid(sObjectID),"Subsurgery");
            if(subSurgery.SurgeryReport != null)
                 this.SubSurgeryRepor.Value = TTReportTool.TTReport.HTMLtoText(subSurgery.SurgeryReport.ToString()) + "\r\n";
#endregion SUBMAIN BODY_PreScript
                }
            }

        }

        public SUBMAINGroup SUBMAIN;

        public partial class SUBAMELIYATUSTGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public SUBAMELIYATUSTGroupHeader Header()
            {
                return (SUBAMELIYATUSTGroupHeader)_header;
            }

            new public SUBAMELIYATUSTGroupFooter Footer()
            {
                return (SUBAMELIYATUSTGroupFooter)_footer;
            }

            public TTReportField LBL1131 { get {return Header().LBL1131;} }
            public SUBAMELIYATUSTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBAMELIYATUSTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SUBAMELIYATUSTGroupHeader(this);
                _footer = new SUBAMELIYATUSTGroupFooter(this);

            }

            public partial class SUBAMELIYATUSTGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField LBL1131; 
                public SUBAMELIYATUSTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBL1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 201, 6, false);
                    LBL1131.Name = "LBL1131";
                    LBL1131.TextFont.Name = "Arial Narrow";
                    LBL1131.TextFont.Size = 11;
                    LBL1131.TextFont.Bold = true;
                    LBL1131.Value = @"Ameliyat Adı   ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL1131.CalcValue = LBL1131.Value;
                    return new TTReportObject[] { LBL1131};
                }
            }
            public partial class SUBAMELIYATUSTGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                 
                public SUBAMELIYATUSTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public SUBAMELIYATUSTGroup SUBAMELIYATUST;

        public partial class SUBAMELIYATGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public SUBAMELIYATGroupBody Body()
            {
                return (SUBAMELIYATGroupBody)_body;
            }
            public TTReportField EKAMELIYATISLEMI { get {return Body().EKAMELIYATISLEMI;} }
            public SUBAMELIYATGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBAMELIYATGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SubSurgeryProcedure.GetBySubSurgery_Class>("GetBySubSurgery", SubSurgeryProcedure.GetBySubSurgery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.SUBMAINA.SUBSURGERYOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SUBAMELIYATGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SUBAMELIYATGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField EKAMELIYATISLEMI; 
                public SUBAMELIYATGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    EKAMELIYATISLEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 201, 6, false);
                    EKAMELIYATISLEMI.Name = "EKAMELIYATISLEMI";
                    EKAMELIYATISLEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKAMELIYATISLEMI.TextFont.Name = "Arial Narrow";
                    EKAMELIYATISLEMI.TextFont.Size = 9;
                    EKAMELIYATISLEMI.Value = @"{#PROCEDURENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgeryProcedure.GetBySubSurgery_Class dataset_GetBySubSurgery = ParentGroup.rsGroup.GetCurrentRecord<SubSurgeryProcedure.GetBySubSurgery_Class>(0);
                    EKAMELIYATISLEMI.CalcValue = (dataset_GetBySubSurgery != null ? Globals.ToStringCore(dataset_GetBySubSurgery.Procedurename) : "");
                    return new TTReportObject[] { EKAMELIYATISLEMI};
                }
            }

        }

        public SUBAMELIYATGroup SUBAMELIYAT;

        public partial class ConsultationHeaderGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public ConsultationHeaderGroupHeader Header()
            {
                return (ConsultationHeaderGroupHeader)_header;
            }

            new public ConsultationHeaderGroupFooter Footer()
            {
                return (ConsultationHeaderGroupFooter)_footer;
            }

            public TTReportField KonsültasyonBaşlık { get {return Header().KonsültasyonBaşlık;} }
            public TTReportField CONSOBJECT { get {return Header().CONSOBJECT;} }
            public ConsultationHeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ConsultationHeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Consultation.GetByMasterActionNQL_Class>("GetByMasterActionNQL2", Consultation.GetByMasterActionNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ConsultationHeaderGroupHeader(this);
                _footer = new ConsultationHeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ConsultationHeaderGroupHeader : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField KonsültasyonBaşlık;
                public TTReportField CONSOBJECT; 
                public ConsultationHeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    KonsültasyonBaşlık = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 198, 9, false);
                    KonsültasyonBaşlık.Name = "KonsültasyonBaşlık";
                    KonsültasyonBaşlık.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    KonsültasyonBaşlık.TextFormat = @"Medium Date";
                    KonsültasyonBaşlık.TextFont.Name = "Arial Narrow";
                    KonsültasyonBaşlık.TextFont.Size = 11;
                    KonsültasyonBaşlık.TextFont.Bold = true;
                    KonsültasyonBaşlık.Value = @"Ameliyat Sırasında Konsültasyonlar";

                    CONSOBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 239, 4, false);
                    CONSOBJECT.Name = "CONSOBJECT";
                    CONSOBJECT.Visible = EvetHayirEnum.ehHayir;
                    CONSOBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSOBJECT.TextFont.Name = "Arial Narrow";
                    CONSOBJECT.TextFont.Size = 9;
                    CONSOBJECT.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Consultation.GetByMasterActionNQL_Class dataset_GetByMasterActionNQL2 = ParentGroup.rsGroup.GetCurrentRecord<Consultation.GetByMasterActionNQL_Class>(0);
                    KonsültasyonBaşlık.CalcValue = KonsültasyonBaşlık.Value;
                    CONSOBJECT.CalcValue = (dataset_GetByMasterActionNQL2 != null ? Globals.ToStringCore(dataset_GetByMasterActionNQL2.ObjectID) : "");
                    return new TTReportObject[] { KonsültasyonBaşlık,CONSOBJECT};
                }
            }
            public partial class ConsultationHeaderGroupFooter : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                 
                public ConsultationHeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ConsultationHeaderGroup ConsultationHeader;

        public partial class ConsultationGGroup : TTReportGroup
        {
            public SurgeryReport MyParentReport
            {
                get { return (SurgeryReport)ParentReport; }
            }

            new public ConsultationGGroupBody Body()
            {
                return (ConsultationGGroupBody)_body;
            }
            public TTReportField KonsBolum { get {return Body().KonsBolum;} }
            public TTReportField LBL11 { get {return Body().LBL11;} }
            public TTReportField LBL13 { get {return Body().LBL13;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField Consultation { get {return Body().Consultation;} }
            public ConsultationGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ConsultationGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ConsultationGGroupBody(this);
            }

            public partial class ConsultationGGroupBody : TTReportSection
            {
                public SurgeryReport MyParentReport
                {
                    get { return (SurgeryReport)ParentReport; }
                }
                
                public TTReportField KonsBolum;
                public TTReportField LBL11;
                public TTReportField LBL13;
                public TTReportField NewField11221;
                public TTReportField NewField11231;
                public TTReportField Consultation; 
                public ConsultationGGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 51;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KonsBolum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 1, 140, 6, false);
                    KonsBolum.Name = "KonsBolum";
                    KonsBolum.FieldType = ReportFieldTypeEnum.ftVariable;
                    KonsBolum.TextFormat = @"Medium Date";
                    KonsBolum.TextFont.Name = "Arial Narrow";
                    KonsBolum.TextFont.Size = 9;
                    KonsBolum.Value = @"{#ConsultationHeader.OBJECTID#}";

                    LBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 78, 6, false);
                    LBL11.Name = "LBL11";
                    LBL11.TextFont.Name = "Arial Narrow";
                    LBL11.TextFont.Size = 11;
                    LBL11.TextFont.Bold = true;
                    LBL11.Value = @"Konsültasyonu Yapan Bölüm   ";

                    LBL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 78, 17, false);
                    LBL13.Name = "LBL13";
                    LBL13.TextFont.Name = "Arial Narrow";
                    LBL13.TextFont.Size = 11;
                    LBL13.TextFont.Bold = true;
                    LBL13.Value = @"Konsültasyon Sonuç ve Önerileri           ";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 12, 83, 17, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 11;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.Value = @":";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 83, 6, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Name = "Arial Narrow";
                    NewField11231.TextFont.Size = 11;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.Value = @":";

                    Consultation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 18, 200, 50, false);
                    Consultation.Name = "Consultation";
                    Consultation.TextFormat = @"Medium Date";
                    Consultation.MultiLine = EvetHayirEnum.ehEvet;
                    Consultation.NoClip = EvetHayirEnum.ehEvet;
                    Consultation.WordBreak = EvetHayirEnum.ehEvet;
                    Consultation.ExpandTabs = EvetHayirEnum.ehEvet;
                    Consultation.TextFont.Name = "Arial Narrow";
                    Consultation.TextFont.Size = 9;
                    Consultation.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Consultation.GetByMasterActionNQL_Class dataset_GetByMasterActionNQL2 = MyParentReport.ConsultationHeader.rsGroup.GetCurrentRecord<Consultation.GetByMasterActionNQL_Class>(0);
                    KonsBolum.CalcValue = (dataset_GetByMasterActionNQL2 != null ? Globals.ToStringCore(dataset_GetByMasterActionNQL2.ObjectID) : "");
                    LBL11.CalcValue = LBL11.Value;
                    LBL13.CalcValue = LBL13.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    Consultation.CalcValue = Consultation.Value;
                    return new TTReportObject[] { KonsBolum,LBL11,LBL13,NewField11221,NewField11231,Consultation};
                }
                public override void RunPreScript()
                {
#region CONSULTATIONG BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SurgeryReport)ParentReport).ConsultationHeader.CONSOBJECT.CalcValue;//
            Consultation consultation = (Consultation)context.GetObject(new Guid(sObjectID),"Consultation");
            if(consultation.ConsultationResultAndOffers != null)
                this.Consultation.Value = TTReportTool.TTReport.HTMLtoText(consultation.ConsultationResultAndOffers.ToString()) + "\r\n";
#endregion CONSULTATIONG BODY_PreScript
                }
            }

        }

        public ConsultationGGroup ConsultationG;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SurgeryReport()
        {
            SARFMALZEME = new SARFMALZEMEGroup(this,"SARFMALZEME");
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            AMELIYATUST = new AMELIYATUSTGroup(PARTA,"AMELIYATUST");
            AMELIYAT = new AMELIYATGroup(AMELIYATUST,"AMELIYAT");
            AMELIYATEKIPUST = new AMELIYATEKIPUSTGroup(PARTA,"AMELIYATEKIPUST");
            AMELIYATEKIP = new AMELIYATEKIPGroup(AMELIYATEKIPUST,"AMELIYATEKIP");
            ANSETEZIUST = new ANSETEZIUSTGroup(PARTA,"ANSETEZIUST");
            ANESTEZI = new ANESTEZIGroup(ANSETEZIUST,"ANESTEZI");
            SUBMAINA = new SUBMAINAGroup(HEADER,"SUBMAINA");
            SUBMAIN = new SUBMAINGroup(SUBMAINA,"SUBMAIN");
            SUBAMELIYATUST = new SUBAMELIYATUSTGroup(SUBMAINA,"SUBAMELIYATUST");
            SUBAMELIYAT = new SUBAMELIYATGroup(SUBAMELIYATUST,"SUBAMELIYAT");
            ConsultationHeader = new ConsultationHeaderGroup(HEADER,"ConsultationHeader");
            ConsultationG = new ConsultationGGroup(ConsultationHeader,"ConsultationG");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Ameliyat", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SURGERYREPORT";
            Caption = "Ameliyat Raporu";
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