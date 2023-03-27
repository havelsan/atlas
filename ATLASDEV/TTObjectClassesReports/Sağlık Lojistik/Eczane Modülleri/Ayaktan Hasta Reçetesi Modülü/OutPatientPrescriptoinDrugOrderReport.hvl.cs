
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
    /// Ayaktan Hastalara Yazılan İlaç Reçetesi
    /// </summary>
    public partial class OutPatientPrescriptoinDrugOrderReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public OutPatientPrescriptoinDrugOrderReport MyParentReport
            {
                get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField DRUGNAME { get {return Header().DRUGNAME;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField ACTIVEING { get {return Header().ACTIVEING;} }
            public TTReportField CLINIC { get {return Header().CLINIC;} }
            public TTReportField CODEORNAME { get {return Header().CODEORNAME;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField DRUGNAME;
                public TTReportField AMOUNT;
                public TTReportField ACTIVEING;
                public TTReportField CLINIC;
                public TTReportField CODEORNAME; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 6, 245, 29, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + "" AYAKTAN HASTALARA YAZILAN İLAÇ LİSTESİ "" ";

                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 75, 35, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DRUGNAME.TextFont.Name = "Arial";
                    DRUGNAME.TextFont.Bold = true;
                    DRUGNAME.TextFont.CharSet = 162;
                    DRUGNAME.Value = @"İLAÇ ADI";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 30, 100, 35, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.Bold = true;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"KUTU ADEDİ";

                    ACTIVEING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 30, 143, 35, false);
                    ACTIVEING.Name = "ACTIVEING";
                    ACTIVEING.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIVEING.TextFont.Name = "Arial";
                    ACTIVEING.TextFont.Bold = true;
                    ACTIVEING.TextFont.CharSet = 162;
                    ACTIVEING.Value = @"ETKİN MADDE";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 30, 218, 35, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.DrawStyle = DrawStyleConstants.vbSolid;
                    CLINIC.TextFont.Name = "Arial";
                    CLINIC.TextFont.Bold = true;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"KLİNİK";

                    CODEORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 30, 291, 35, false);
                    CODEORNAME.Name = "CODEORNAME";
                    CODEORNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    CODEORNAME.TextFont.Name = "Arial";
                    CODEORNAME.TextFont.Bold = true;
                    CODEORNAME.TextFont.CharSet = 162;
                    CODEORNAME.Value = @"TANI VEYA ICD KODU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DRUGNAME.CalcValue = DRUGNAME.Value;
                    AMOUNT.CalcValue = AMOUNT.Value;
                    ACTIVEING.CalcValue = ACTIVEING.Value;
                    CLINIC.CalcValue = CLINIC.Value;
                    CODEORNAME.CalcValue = CODEORNAME.Value;
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + " AYAKTAN HASTALARA YAZILAN İLAÇ LİSTESİ " ;
                    return new TTReportObject[] { DRUGNAME,AMOUNT,ACTIVEING,CLINIC,CODEORNAME,HOSPITAL};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public OutPatientPrescriptoinDrugOrderReport MyParentReport
            {
                get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField DRUG { get {return Header().DRUG;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField CLINIC { get {return Header().CLINIC;} }
            public TTReportField PRESOBJECTID { get {return Header().PRESOBJECTID;} }
            public TTReportField DRUGOBJECTID { get {return Header().DRUGOBJECTID;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
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
                list[0] = new TTReportNqlData<OutPatientDrugOrder.GetDrugByDiagnosis_Class>("GetDrugByDiagnosis", OutPatientDrugOrder.GetDrugByDiagnosis((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                
                public TTReportField DRUG;
                public TTReportField AMOUNT;
                public TTReportField CLINIC;
                public TTReportField PRESOBJECTID;
                public TTReportField DRUGOBJECTID;
                public TTReportField NewField1;
                public TTReportField NewField11; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DRUG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 75, 5, false);
                    DRUG.Name = "DRUG";
                    DRUG.DrawStyle = DrawStyleConstants.vbSolid;
                    DRUG.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG.ObjectDefName = "DrugDefinition";
                    DRUG.DataMember = "NAME";
                    DRUG.Value = @"{#DRUG#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 100, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 218, 5, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.DrawStyle = DrawStyleConstants.vbSolid;
                    CLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINIC.ObjectDefName = "Resource";
                    CLINIC.DataMember = "NAME";
                    CLINIC.Value = @"{#CLINIC#}";

                    PRESOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 352, 1, 377, 6, false);
                    PRESOBJECTID.Name = "PRESOBJECTID";
                    PRESOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PRESOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESOBJECTID.Value = @"{#PRESOBJECTID#}";

                    DRUGOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 320, 1, 345, 6, false);
                    DRUGOBJECTID.Name = "DRUGOBJECTID";
                    DRUGOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DRUGOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGOBJECTID.Value = @"{#DRUG#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 143, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 291, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OutPatientDrugOrder.GetDrugByDiagnosis_Class dataset_GetDrugByDiagnosis = ParentGroup.rsGroup.GetCurrentRecord<OutPatientDrugOrder.GetDrugByDiagnosis_Class>(0);
                    DRUG.CalcValue = (dataset_GetDrugByDiagnosis != null ? Globals.ToStringCore(dataset_GetDrugByDiagnosis.Drug) : "");
                    DRUG.PostFieldValueCalculation();
                    AMOUNT.CalcValue = (dataset_GetDrugByDiagnosis != null ? Globals.ToStringCore(dataset_GetDrugByDiagnosis.Amount) : "");
                    CLINIC.CalcValue = (dataset_GetDrugByDiagnosis != null ? Globals.ToStringCore(dataset_GetDrugByDiagnosis.Clinic) : "");
                    CLINIC.PostFieldValueCalculation();
                    PRESOBJECTID.CalcValue = (dataset_GetDrugByDiagnosis != null ? Globals.ToStringCore(dataset_GetDrugByDiagnosis.Presobjectid) : "");
                    DRUGOBJECTID.CalcValue = (dataset_GetDrugByDiagnosis != null ? Globals.ToStringCore(dataset_GetDrugByDiagnosis.Drug) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { DRUG,AMOUNT,CLINIC,PRESOBJECTID,DRUGOBJECTID,NewField1,NewField11};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public OutPatientPrescriptoinDrugOrderReport MyParentReport
            {
                get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ETKINMADDE { get {return Header().ETKINMADDE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
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
                list[0] = new TTReportNqlData<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class>("GetDrugActiveIngReportQuery", DrugActiveIngredient.GetDrugActiveIngReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTB.DRUGOBJECTID.CalcValue)));
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
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                
                public TTReportField ETKINMADDE;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ETKINMADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 143, 5, false);
                    ETKINMADDE.Name = "ETKINMADDE";
                    ETKINMADDE.DrawStyle = DrawStyleConstants.vbSolid;
                    ETKINMADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ETKINMADDE.Value = @"{#ETKINMADDE#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 75, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 100, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 218, 5, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 291, 5, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugActiveIngredient.GetDrugActiveIngReportQuery_Class dataset_GetDrugActiveIngReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class>(0);
                    ETKINMADDE.CalcValue = (dataset_GetDrugActiveIngReportQuery != null ? Globals.ToStringCore(dataset_GetDrugActiveIngReportQuery.Etkinmadde) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    return new TTReportObject[] { ETKINMADDE,NewField11,NewField12,NewField13,NewField14};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public OutPatientPrescriptoinDrugOrderReport MyParentReport
            {
                get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
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
                list[0] = new TTReportNqlData<DiagnosisForPresc.GetDiagosisForPrescription_Class>("GetDiagosisForPrescription", DiagnosisForPresc.GetDiagosisForPrescription((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTB.PRESOBJECTID.CalcValue)));
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
                public OutPatientPrescriptoinDrugOrderReport MyParentReport
                {
                    get { return (OutPatientPrescriptoinDrugOrderReport)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField NAME;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField11;
                public TTReportField NewField131; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 233, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.Value = @"{#CODE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 291, 5, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 218, 0, 291, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 218, 0, 218, 5, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 218, 5, 291, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 75, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 100, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 143, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 218, 5, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisForPresc.GetDiagosisForPrescription_Class dataset_GetDiagosisForPrescription = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisForPresc.GetDiagosisForPrescription_Class>(0);
                    CODE.CalcValue = (dataset_GetDiagosisForPrescription != null ? Globals.ToStringCore(dataset_GetDiagosisForPrescription.Code) : "");
                    NAME.CalcValue = (dataset_GetDiagosisForPrescription != null ? Globals.ToStringCore(dataset_GetDiagosisForPrescription.Name) : "");
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { CODE,NAME,NewField111,NewField121,NewField11,NewField131};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //           TTObjectContext context = new TTObjectContext(true);
////           //string objectID = ((OutPatientPrescriptoinDrugOrderReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
////           OutPatientPrescription deneme = (OutPatientPrescription)context.GetObject(new Guid(objectID),"OutPatientPrescription");
////           Episode episode = deneme.Episode;
////           string diagnoseName =""; 
////           foreach (DiagnosisGrid diagnose in episode.Diagnosis)
////           {
////               diagnoseName += (diagnose.Diagnose).ToString()+ "\r\n";
////                   
////           }
////           DIAGNOSIS.CalcValue = diagnoseName;
//
//
//           BindingList<DrugActiveIngredient.GetDrugActiveIngReportQuery_Class> activeIngList = DrugActiveIngredient.GetDrugActiveIngReportQuery(this.DRUGDEF.CalcValue.ToString());
//           string activeIngName =""; 
//           foreach (DrugActiveIngredient.GetDrugActiveIngReportQuery_Class activeIng in activeIngList)
//           {
//            activeIngName =  activeIng.Etkinmadde.ToString()+ "\r\n";;
//           }
//           this.ETKENMADDE.CalcValue = activeIngName;
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

        public OutPatientPrescriptoinDrugOrderReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "OUTPATIENTPRESCRIPTOINDRUGORDERREPORT";
            Caption = "Ayaktan Hastalara Yazılan İlaç Reçetesi";
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