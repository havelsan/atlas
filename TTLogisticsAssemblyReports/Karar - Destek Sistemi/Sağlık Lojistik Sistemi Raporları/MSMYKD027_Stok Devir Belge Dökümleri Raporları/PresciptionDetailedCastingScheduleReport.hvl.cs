
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
    /// Ayrıntılı Reçete  Döküm Çizelgesi
    /// </summary>
    public partial class PresciptionDetailedCastingScheduleReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PresciptionDetailedCastingScheduleReport MyParentReport
            {
                get { return (PresciptionDetailedCastingScheduleReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField OldOrderNO11 { get {return Header().OldOrderNO11;} }
            public TTReportField OldOrderNO111 { get {return Header().OldOrderNO111;} }
            public TTReportField OldOrderNO121 { get {return Header().OldOrderNO121;} }
            public TTReportField OldOrderNO1121 { get {return Header().OldOrderNO1121;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField KURUMKODU { get {return Header().KURUMKODU;} }
            public TTReportField OldOrderNO11112111 { get {return Header().OldOrderNO11112111;} }
            public TTReportField SAYMANLIKKODU { get {return Header().SAYMANLIKKODU;} }
            public TTReportField KODU { get {return Header().KODU;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
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
                public PresciptionDetailedCastingScheduleReport MyParentReport
                {
                    get { return (PresciptionDetailedCastingScheduleReport)ParentReport; }
                }
                
                public TTReportField ReportName1;
                public TTReportField OldOrderNO11;
                public TTReportField OldOrderNO111;
                public TTReportField OldOrderNO121;
                public TTReportField OldOrderNO1121;
                public TTReportField BIRLIK;
                public TTReportField SAYMANLIK;
                public TTReportField KURUMKODU;
                public TTReportField OldOrderNO11112111;
                public TTReportField SAYMANLIKKODU;
                public TTReportField KODU;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportField NewField11111111;
                public TTReportField MATERIAL; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 5, 291, 16, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Size = 12;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"AYRINTILI REÇETE DÖKÜM ÇİZELGESİ";

                    OldOrderNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 16, 72, 26, false);
                    OldOrderNO11.Name = "OldOrderNO11";
                    OldOrderNO11.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO11.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO11.TextFont.Name = "Arial";
                    OldOrderNO11.TextFont.Bold = true;
                    OldOrderNO11.TextFont.CharSet = 162;
                    OldOrderNO11.Value = @"Harcama Birimi Birlik/Kurumunun Adı";

                    OldOrderNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 72, 32, false);
                    OldOrderNO111.Name = "OldOrderNO111";
                    OldOrderNO111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO111.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO111.TextFont.Name = "Arial";
                    OldOrderNO111.TextFont.Bold = true;
                    OldOrderNO111.TextFont.CharSet = 162;
                    OldOrderNO111.Value = @"Taşınır Mal Saymanlığının Adı";

                    OldOrderNO121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 16, 217, 26, false);
                    OldOrderNO121.Name = "OldOrderNO121";
                    OldOrderNO121.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO121.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO121.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO121.TextFont.Name = "Arial";
                    OldOrderNO121.TextFont.Bold = true;
                    OldOrderNO121.TextFont.CharSet = 162;
                    OldOrderNO121.Value = @"KODU";

                    OldOrderNO1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 26, 217, 32, false);
                    OldOrderNO1121.Name = "OldOrderNO1121";
                    OldOrderNO1121.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1121.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO1121.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO1121.TextFont.Name = "Arial";
                    OldOrderNO1121.TextFont.Bold = true;
                    OldOrderNO1121.TextFont.CharSet = 162;
                    OldOrderNO1121.Value = @"KODU";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 16, 187, 26, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 26, 187, 32, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMANLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 247, 26, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KURUMKODU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMKODU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMKODU.TextFont.CharSet = 162;
                    KURUMKODU.Value = @"";

                    OldOrderNO11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 16, 267, 32, false);
                    OldOrderNO11112111.Name = "OldOrderNO11112111";
                    OldOrderNO11112111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO11112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11112111.TextFont.Name = "Arial";
                    OldOrderNO11112111.TextFont.Bold = true;
                    OldOrderNO11112111.TextFont.CharSet = 162;
                    OldOrderNO11112111.Value = @"YILI";

                    SAYMANLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 26, 247, 32, false);
                    SAYMANLIKKODU.Name = "SAYMANLIKKODU";
                    SAYMANLIKKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIKKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIKKODU.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMANLIKKODU.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMANLIKKODU.TextFont.CharSet = 162;
                    SAYMANLIKKODU.Value = @"";

                    KODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 16, 291, 32, false);
                    KODU.Name = "KODU";
                    KODU.DrawStyle = DrawStyleConstants.vbSolid;
                    KODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KODU.TextFont.CharSet = 162;
                    KODU.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 47, 32, 52, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.DrawWidth = 2;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" İşlem Tarihi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 47, 57, 52, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.DrawWidth = 2;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @" İşlem No";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 47, 111, 52, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.DrawWidth = 2;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @" İşlem ";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 47, 133, 52, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.DrawWidth = 2;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @" Reçete No";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 47, 199, 52, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.DrawWidth = 2;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @" Hasta Adı Soyadı";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 47, 268, 52, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.DrawWidth = 2;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @" Doktor Adı Soyadı";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 47, 291, 52, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111111.DrawWidth = 2;
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Name = "Arial";
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @" Miktar";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 39, 147, 44, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.ObjectDefName = "Material";
                    MATERIAL.DataMember = "NAME";
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 11;
                    MATERIAL.TextFont.Bold = true;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{@MATERIAL@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName1.CalcValue = ReportName1.Value;
                    OldOrderNO11.CalcValue = OldOrderNO11.Value;
                    OldOrderNO111.CalcValue = OldOrderNO111.Value;
                    OldOrderNO121.CalcValue = OldOrderNO121.Value;
                    OldOrderNO1121.CalcValue = OldOrderNO1121.Value;
                    BIRLIK.CalcValue = @"";
                    SAYMANLIK.CalcValue = @"";
                    KURUMKODU.CalcValue = @"";
                    OldOrderNO11112111.CalcValue = OldOrderNO11112111.Value;
                    SAYMANLIKKODU.CalcValue = @"";
                    KODU.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    MATERIAL.CalcValue = MyParentReport.RuntimeParameters.MATERIAL.ToString();
                    MATERIAL.PostFieldValueCalculation();
                    return new TTReportObject[] { ReportName1,OldOrderNO11,OldOrderNO111,OldOrderNO121,OldOrderNO1121,BIRLIK,SAYMANLIK,KURUMKODU,OldOrderNO11112111,SAYMANLIKKODU,KODU,NewField11,NewField111,NewField1111,NewField11111,NewField111111,NewField1111111,NewField11111111,MATERIAL};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string termID = ((PresciptionDetailedCastingScheduleReport)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(accountingTerm.EndDate != null)
            {
                int actionYear = Convert.ToDateTime(accountingTerm.EndDate).Year;
                this.KODU.CalcValue = actionYear.ToString() ;
                this.SAYMANLIK.CalcValue = accountingTerm.Accountancy.Name;
                this.BIRLIK.CalcValue = accountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                this.KURUMKODU.CalcValue = accountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                this.SAYMANLIKKODU.CalcValue = accountingTerm.Accountancy.AccountancyNO;
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PresciptionDetailedCastingScheduleReport MyParentReport
                {
                    get { return (PresciptionDetailedCastingScheduleReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PresciptionDetailedCastingScheduleReport MyParentReport
            {
                get { return (PresciptionDetailedCastingScheduleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONDESCRIPTION { get {return Body().ACTIONDESCRIPTION;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DOCKTORFULLNAME { get {return Body().DOCKTORFULLNAME;} }
            public TTReportField PATIENFULLNAME { get {return Body().PATIENFULLNAME;} }
            public TTReportField PRESCRIPTIONNO { get {return Body().PRESCRIPTIONNO;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
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
                list[0] = new TTReportNqlData<PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class>("PrescriptionConsumptionDocumentMaterialQuery", PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
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
                public PresciptionDetailedCastingScheduleReport MyParentReport
                {
                    get { return (PresciptionDetailedCastingScheduleReport)ParentReport; }
                }
                
                public TTReportField ACTIONDESCRIPTION;
                public TTReportField ACTIONID;
                public TTReportField AMOUNT;
                public TTReportField DOCKTORFULLNAME;
                public TTReportField PATIENFULLNAME;
                public TTReportField PRESCRIPTIONNO;
                public TTReportField ACTIONDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ACTIONDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 111, 5, false);
                    ACTIONDESCRIPTION.Name = "ACTIONDESCRIPTION";
                    ACTIONDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDESCRIPTION.TextFont.CharSet = 162;
                    ACTIONDESCRIPTION.Value = @"{#ACTIONDESCRIPTION#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 57, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 291, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DOCKTORFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 268, 5, false);
                    DOCKTORFULLNAME.Name = "DOCKTORFULLNAME";
                    DOCKTORFULLNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCKTORFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCKTORFULLNAME.TextFont.CharSet = 162;
                    DOCKTORFULLNAME.Value = @"{#DOCKTORFULLNAME#}";

                    PATIENFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 199, 5, false);
                    PATIENFULLNAME.Name = "PATIENFULLNAME";
                    PATIENFULLNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENFULLNAME.TextFont.CharSet = 162;
                    PATIENFULLNAME.Value = @"{#PATIENFULLNAME#}";

                    PRESCRIPTIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 132, 5, false);
                    PRESCRIPTIONNO.Name = "PRESCRIPTIONNO";
                    PRESCRIPTIONNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PRESCRIPTIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONNO.TextFont.CharSet = 162;
                    PRESCRIPTIONNO.Value = @"{#PRESCRIPTIONNO#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 32, 5, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFont.CharSet = 162;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class dataset_PrescriptionConsumptionDocumentMaterialQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class>(0);
                    ACTIONDESCRIPTION.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.ActionDescription) : "");
                    ACTIONID.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.ActionID) : "");
                    AMOUNT.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.Amount) : "");
                    DOCKTORFULLNAME.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.DocktorFullName) : "");
                    PATIENFULLNAME.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.PatienFullName) : "");
                    PRESCRIPTIONNO.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.PrescriptionNo) : "");
                    ACTIONDATE.CalcValue = (dataset_PrescriptionConsumptionDocumentMaterialQuery != null ? Globals.ToStringCore(dataset_PrescriptionConsumptionDocumentMaterialQuery.ActionDate) : "");
                    return new TTReportObject[] { ACTIONDESCRIPTION,ACTIONID,AMOUNT,DOCKTORFULLNAME,PATIENFULLNAME,PRESCRIPTIONNO,ACTIONDATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PresciptionDetailedCastingScheduleReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Devir Yapan Depoyu Seçiniz  :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Devir Yapan Dönemi Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Malzeme :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("af1a7c6a-7e8b-4bc1-ac89-f800f14f259b");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            Name = "PRESCIPTIONDETAILEDCASTINGSCHEDULEREPORT";
            Caption = "Ayrıntılı Reçete  Döküm Çizelgesi";
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