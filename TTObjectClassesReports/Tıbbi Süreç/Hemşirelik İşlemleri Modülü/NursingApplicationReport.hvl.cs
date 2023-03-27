
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
    /// Hemşirelik Gözlem Raporu
    /// </summary>
    public partial class NursingApplicationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingApplicationReport MyParentReport
            {
                get { return (NursingApplicationReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField BASLIK1 { get {return Header().BASLIK1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public NursingApplicationReport MyParentReport
                {
                    get { return (NursingApplicationReport)ParentReport; }
                }
                
                public TTReportField BASLIK1;
                public TTReportField XXXXXXBASLIK; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 204, 24, false);
                    BASLIK1.Name = "BASLIK1";
                    BASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK1.TextFont.Name = "Calibri";
                    BASLIK1.TextFont.Size = 12;
                    BASLIK1.TextFont.Bold = true;
                    BASLIK1.TextFont.CharSet = 162;
                    BASLIK1.Value = @"HEMŞİRELİK GÖZLEM RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 204, 16, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Calibri";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK1.CalcValue = BASLIK1.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { BASLIK1,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingApplicationReport MyParentReport
                {
                    get { return (NursingApplicationReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 202, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingApplicationReport MyParentReport
            {
                get { return (NursingApplicationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField PROCEDUREOBJECT { get {return Body().PROCEDUREOBJECT;} }
            public TTReportField RESULT { get {return Body().RESULT;} }
            public TTReportField NOTE { get {return Body().NOTE;} }
            public TTReportField LabelExecutionDate { get {return Body().LabelExecutionDate;} }
            public TTReportField LabelProcedureObject { get {return Body().LabelProcedureObject;} }
            public TTReportField LabelResult { get {return Body().LabelResult;} }
            public TTReportField LabelNurseNote { get {return Body().LabelNurseNote;} }
            public TTReportField LabelHeader1 { get {return Body().LabelHeader1;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class>("GetByNursingApplicationNursingProcedure", NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NursingApplicationReport MyParentReport
                {
                    get { return (NursingApplicationReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField PROCEDUREOBJECT;
                public TTReportField RESULT;
                public TTReportField NOTE;
                public TTReportField LabelExecutionDate;
                public TTReportField LabelProcedureObject;
                public TTReportField LabelResult;
                public TTReportField LabelNurseNote;
                public TTReportField LabelHeader1;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 68;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 13, 204, 18, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    PROCEDUREOBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 20, 204, 25, false);
                    PROCEDUREOBJECT.Name = "PROCEDUREOBJECT";
                    PROCEDUREOBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECT.ObjectDefName = "NursingProcedureDefinition";
                    PROCEDUREOBJECT.DataMember = "NAME";
                    PROCEDUREOBJECT.Value = @"{#PROCEDUREOBJECT#}";

                    RESULT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 27, 204, 32, false);
                    RESULT.Name = "RESULT";
                    RESULT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESULT.Value = @"{#RESULT#}";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 204, 63, false);
                    NOTE.Name = "NOTE";
                    NOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTE.Value = @"{#NOTE#}";

                    LabelExecutionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 13, 175, 18, false);
                    LabelExecutionDate.Name = "LabelExecutionDate";
                    LabelExecutionDate.TextFont.Name = "Calibri";
                    LabelExecutionDate.TextFont.Size = 9;
                    LabelExecutionDate.TextFont.Bold = true;
                    LabelExecutionDate.TextFont.CharSet = 162;
                    LabelExecutionDate.Value = @"Uygulama Zamanı:";

                    LabelProcedureObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 54, 25, false);
                    LabelProcedureObject.Name = "LabelProcedureObject";
                    LabelProcedureObject.TextFont.Name = "Calibri";
                    LabelProcedureObject.TextFont.Size = 9;
                    LabelProcedureObject.TextFont.Bold = true;
                    LabelProcedureObject.TextFont.CharSet = 162;
                    LabelProcedureObject.Value = @"Hemşire Takip Gözlem";

                    LabelResult = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 22, 32, false);
                    LabelResult.Name = "LabelResult";
                    LabelResult.TextFont.Name = "Calibri";
                    LabelResult.TextFont.Size = 9;
                    LabelResult.TextFont.Bold = true;
                    LabelResult.TextFont.CharSet = 162;
                    LabelResult.Value = @"Sonuç:";

                    LabelNurseNote = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 32, 39, false);
                    LabelNurseNote.Name = "LabelNurseNote";
                    LabelNurseNote.TextFont.Name = "Calibri";
                    LabelNurseNote.TextFont.Size = 9;
                    LabelNurseNote.TextFont.Bold = true;
                    LabelNurseNote.TextFont.CharSet = 162;
                    LabelNurseNote.Value = @"Hemşire Notu:";

                    LabelHeader1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 45, 13, false);
                    LabelHeader1.Name = "LabelHeader1";
                    LabelHeader1.TextFont.Name = "Calibri";
                    LabelHeader1.TextFont.Size = 9;
                    LabelHeader1.TextFont.Bold = true;
                    LabelHeader1.TextFont.Underline = true;
                    LabelHeader1.TextFont.CharSet = 162;
                    LabelHeader1.Value = @"Hemşire Takip Gözlem";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 66, 205, 66, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class dataset_GetByNursingApplicationNursingProcedure = ParentGroup.rsGroup.GetCurrentRecord<NursingApplicationNursingProcedure.GetByNursingApplicationNursingProcedure_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetByNursingApplicationNursingProcedure != null ? Globals.ToStringCore(dataset_GetByNursingApplicationNursingProcedure.ActionDate) : "");
                    PROCEDUREOBJECT.CalcValue = (dataset_GetByNursingApplicationNursingProcedure != null ? Globals.ToStringCore(dataset_GetByNursingApplicationNursingProcedure.ProcedureObject) : "");
                    PROCEDUREOBJECT.PostFieldValueCalculation();
                    RESULT.CalcValue = (dataset_GetByNursingApplicationNursingProcedure != null ? Globals.ToStringCore(dataset_GetByNursingApplicationNursingProcedure.Result) : "");
                    NOTE.CalcValue = (dataset_GetByNursingApplicationNursingProcedure != null ? Globals.ToStringCore(dataset_GetByNursingApplicationNursingProcedure.Note) : "");
                    LabelExecutionDate.CalcValue = LabelExecutionDate.Value;
                    LabelProcedureObject.CalcValue = LabelProcedureObject.Value;
                    LabelResult.CalcValue = LabelResult.Value;
                    LabelNurseNote.CalcValue = LabelNurseNote.Value;
                    LabelHeader1.CalcValue = LabelHeader1.Value;
                    return new TTReportObject[] { ACTIONDATE,PROCEDUREOBJECT,RESULT,NOTE,LabelExecutionDate,LabelProcedureObject,LabelResult,LabelNurseNote,LabelHeader1};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public NursingApplicationReport MyParentReport
            {
                get { return (NursingApplicationReport)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField RRHYTHMOFPATIENT { get {return Body().RRHYTHMOFPATIENT;} }
            public TTReportField PLACEHARSHNESSTIMEOFPAIN { get {return Body().PLACEHARSHNESSTIMEOFPAIN;} }
            public TTReportField VENTULATORMODS { get {return Body().VENTULATORMODS;} }
            public TTReportField EDEMATRACING { get {return Body().EDEMATRACING;} }
            public TTReportField VENTRAL { get {return Body().VENTRAL;} }
            public TTReportField CRUS { get {return Body().CRUS;} }
            public TTReportField ARM { get {return Body().ARM;} }
            public TTReportField BRAINS { get {return Body().BRAINS;} }
            public TTReportField LabelHeader2 { get {return Body().LabelHeader2;} }
            public TTReportField LabelDate { get {return Body().LabelDate;} }
            public TTReportField LabelRrhythmOfPatient { get {return Body().LabelRrhythmOfPatient;} }
            public TTReportField LabelVentulator { get {return Body().LabelVentulator;} }
            public TTReportField LabelPainLocale { get {return Body().LabelPainLocale;} }
            public TTReportField LabelHead { get {return Body().LabelHead;} }
            public TTReportField LabelArm { get {return Body().LabelArm;} }
            public TTReportField LabelLeg { get {return Body().LabelLeg;} }
            public TTReportField LabelVentral { get {return Body().LabelVentral;} }
            public TTReportField LabelPayment { get {return Body().LabelPayment;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
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
                list[0] = new TTReportNqlData<NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class>("GetByNursingDayToDayInvestigation", NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public NursingApplicationReport MyParentReport
                {
                    get { return (NursingApplicationReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField RRHYTHMOFPATIENT;
                public TTReportField PLACEHARSHNESSTIMEOFPAIN;
                public TTReportField VENTULATORMODS;
                public TTReportField EDEMATRACING;
                public TTReportField VENTRAL;
                public TTReportField CRUS;
                public TTReportField ARM;
                public TTReportField BRAINS;
                public TTReportField LabelHeader2;
                public TTReportField LabelDate;
                public TTReportField LabelRrhythmOfPatient;
                public TTReportField LabelVentulator;
                public TTReportField LabelPainLocale;
                public TTReportField LabelHead;
                public TTReportField LabelArm;
                public TTReportField LabelLeg;
                public TTReportField LabelVentral;
                public TTReportField LabelPayment;
                public TTReportShape NewLine11; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 37;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 11, 203, 16, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    RRHYTHMOFPATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 20, 69, 25, false);
                    RRHYTHMOFPATIENT.Name = "RRHYTHMOFPATIENT";
                    RRHYTHMOFPATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RRHYTHMOFPATIENT.Value = @"{#RRHYTHMOFPATIENT#}";

                    PLACEHARSHNESSTIMEOFPAIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 26, 69, 31, false);
                    PLACEHARSHNESSTIMEOFPAIN.Name = "PLACEHARSHNESSTIMEOFPAIN";
                    PLACEHARSHNESSTIMEOFPAIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    PLACEHARSHNESSTIMEOFPAIN.Value = @"{#PLACEHARSHNESSTIMEOFPAIN#}";

                    VENTULATORMODS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 20, 117, 25, false);
                    VENTULATORMODS.Name = "VENTULATORMODS";
                    VENTULATORMODS.FieldType = ReportFieldTypeEnum.ftVariable;
                    VENTULATORMODS.Value = @"{#VENTULATORMODS#}";

                    EDEMATRACING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 26, 117, 31, false);
                    EDEMATRACING.Name = "EDEMATRACING";
                    EDEMATRACING.FieldType = ReportFieldTypeEnum.ftVariable;
                    EDEMATRACING.Value = @"{#EDEMATRACING#}";

                    VENTRAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 20, 154, 25, false);
                    VENTRAL.Name = "VENTRAL";
                    VENTRAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    VENTRAL.Value = @"{#VENTRAL#}";

                    CRUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 26, 154, 31, false);
                    CRUS.Name = "CRUS";
                    CRUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CRUS.Value = @"{#CRUS#}";

                    ARM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 20, 184, 25, false);
                    ARM.Name = "ARM";
                    ARM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARM.Value = @"{#ARM#}";

                    BRAINS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 26, 184, 31, false);
                    BRAINS.Name = "BRAINS";
                    BRAINS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRAINS.Value = @"{#BRAINS#}";

                    LabelHeader2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 45, 10, false);
                    LabelHeader2.Name = "LabelHeader2";
                    LabelHeader2.TextFont.Name = "Calibri";
                    LabelHeader2.TextFont.Size = 9;
                    LabelHeader2.TextFont.Bold = true;
                    LabelHeader2.TextFont.Underline = true;
                    LabelHeader2.TextFont.CharSet = 162;
                    LabelHeader2.Value = @"Günlük Gözlem";

                    LabelDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 11, 171, 16, false);
                    LabelDate.Name = "LabelDate";
                    LabelDate.TextFont.Name = "Calibri";
                    LabelDate.TextFont.Size = 9;
                    LabelDate.TextFont.Bold = true;
                    LabelDate.TextFont.CharSet = 162;
                    LabelDate.Value = @"Tarih:";

                    LabelRrhythmOfPatient = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 20, 47, 25, false);
                    LabelRrhythmOfPatient.Name = "LabelRrhythmOfPatient";
                    LabelRrhythmOfPatient.TextFont.Name = "Calibri";
                    LabelRrhythmOfPatient.TextFont.Size = 9;
                    LabelRrhythmOfPatient.TextFont.Bold = true;
                    LabelRrhythmOfPatient.TextFont.CharSet = 162;
                    LabelRrhythmOfPatient.Value = @"Hastanın Ritmi                  :";

                    LabelVentulator = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 20, 96, 25, false);
                    LabelVentulator.Name = "LabelVentulator";
                    LabelVentulator.TextFont.Name = "Calibri";
                    LabelVentulator.TextFont.Size = 9;
                    LabelVentulator.TextFont.Bold = true;
                    LabelVentulator.TextFont.CharSet = 162;
                    LabelVentulator.Value = @"Ventülatör Modları:";

                    LabelPainLocale = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 26, 47, 31, false);
                    LabelPainLocale.Name = "LabelPainLocale";
                    LabelPainLocale.TextFont.Name = "Calibri";
                    LabelPainLocale.TextFont.Size = 9;
                    LabelPainLocale.TextFont.Bold = true;
                    LabelPainLocale.TextFont.CharSet = 162;
                    LabelPainLocale.Value = @"Ağrının Yeri-Şiddeti-Süresi:";

                    LabelHead = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 26, 165, 31, false);
                    LabelHead.Name = "LabelHead";
                    LabelHead.TextFont.Name = "Calibri";
                    LabelHead.TextFont.Size = 9;
                    LabelHead.TextFont.Bold = true;
                    LabelHead.TextFont.CharSet = 162;
                    LabelHead.Value = @"Kafa:";

                    LabelArm = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 20, 165, 25, false);
                    LabelArm.Name = "LabelArm";
                    LabelArm.TextFont.Name = "Calibri";
                    LabelArm.TextFont.Size = 9;
                    LabelArm.TextFont.Bold = true;
                    LabelArm.TextFont.CharSet = 162;
                    LabelArm.Value = @"Kol  :";

                    LabelLeg = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 26, 130, 31, false);
                    LabelLeg.Name = "LabelLeg";
                    LabelLeg.TextFont.Name = "Calibri";
                    LabelLeg.TextFont.Size = 9;
                    LabelLeg.TextFont.Bold = true;
                    LabelLeg.TextFont.CharSet = 162;
                    LabelLeg.Value = @"Bacak  :";

                    LabelVentral = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 20, 130, 25, false);
                    LabelVentral.Name = "LabelVentral";
                    LabelVentral.TextFont.Name = "Calibri";
                    LabelVentral.TextFont.Size = 9;
                    LabelVentral.TextFont.Bold = true;
                    LabelVentral.TextFont.CharSet = 162;
                    LabelVentral.Value = @"Karın   :";

                    LabelPayment = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 26, 96, 31, false);
                    LabelPayment.Name = "LabelPayment";
                    LabelPayment.TextFont.Name = "Calibri";
                    LabelPayment.TextFont.Size = 9;
                    LabelPayment.TextFont.Bold = true;
                    LabelPayment.TextFont.CharSet = 162;
                    LabelPayment.Value = @"Ödem Takibi          :";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 35, 203, 35, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class dataset_GetByNursingDayToDayInvestigation = ParentGroup.rsGroup.GetCurrentRecord<NursingDayToDayInvestigation.GetByNursingDayToDayInvestigation_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.ActionDate) : "");
                    RRHYTHMOFPATIENT.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.RrhythmOfPatient) : "");
                    PLACEHARSHNESSTIMEOFPAIN.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.PlaceHarshnessTimeOfPain) : "");
                    VENTULATORMODS.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.VentulatorMods) : "");
                    EDEMATRACING.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.EdemaTracing) : "");
                    VENTRAL.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.Ventral) : "");
                    CRUS.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.Crus) : "");
                    ARM.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.Arm) : "");
                    BRAINS.CalcValue = (dataset_GetByNursingDayToDayInvestigation != null ? Globals.ToStringCore(dataset_GetByNursingDayToDayInvestigation.Brains) : "");
                    LabelHeader2.CalcValue = LabelHeader2.Value;
                    LabelDate.CalcValue = LabelDate.Value;
                    LabelRrhythmOfPatient.CalcValue = LabelRrhythmOfPatient.Value;
                    LabelVentulator.CalcValue = LabelVentulator.Value;
                    LabelPainLocale.CalcValue = LabelPainLocale.Value;
                    LabelHead.CalcValue = LabelHead.Value;
                    LabelArm.CalcValue = LabelArm.Value;
                    LabelLeg.CalcValue = LabelLeg.Value;
                    LabelVentral.CalcValue = LabelVentral.Value;
                    LabelPayment.CalcValue = LabelPayment.Value;
                    return new TTReportObject[] { ACTIONDATE,RRHYTHMOFPATIENT,PLACEHARSHNESSTIMEOFPAIN,VENTULATORMODS,EDEMATRACING,VENTRAL,CRUS,ARM,BRAINS,LabelHeader2,LabelDate,LabelRrhythmOfPatient,LabelVentulator,LabelPainLocale,LabelHead,LabelArm,LabelLeg,LabelVentral,LabelPayment};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class NURSINGGroup : TTReportGroup
        {
            public NursingApplicationReport MyParentReport
            {
                get { return (NursingApplicationReport)ParentReport; }
            }

            new public NURSINGGroupBody Body()
            {
                return (NURSINGGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField LblDateHour11 { get {return Body().LblDateHour11;} }
            public TTReportField LblDescription { get {return Body().LblDescription;} }
            public TTReportField Date { get {return Body().Date;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public NURSINGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NURSINGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NursingAppliProgress.GetNursingApplicationProgress_Class>("GetNursingApplicationProgress", NursingAppliProgress.GetNursingApplicationProgress((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new NURSINGGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NURSINGGroupBody : TTReportSection
            {
                public NursingApplicationReport MyParentReport
                {
                    get { return (NursingApplicationReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField LblDateHour11;
                public TTReportField LblDescription;
                public TTReportField Date;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine1111; 
                public NURSINGGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 22;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 35, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Calibri";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Hemşire Gözlem";

                    LblDateHour11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 35, 15, false);
                    LblDateHour11.Name = "LblDateHour11";
                    LblDateHour11.TextFont.Name = "Calibri";
                    LblDateHour11.TextFont.Size = 9;
                    LblDateHour11.TextFont.Bold = true;
                    LblDateHour11.TextFont.CharSet = 162;
                    LblDateHour11.Value = @"Tarih";

                    LblDescription = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 10, 87, 15, false);
                    LblDescription.Name = "LblDescription";
                    LblDescription.TextFont.Name = "Calibri";
                    LblDescription.TextFont.Size = 9;
                    LblDescription.TextFont.Bold = true;
                    LblDescription.TextFont.CharSet = 162;
                    LblDescription.Value = @"Açıklama";

                    Date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 35, 21, false);
                    Date.Name = "Date";
                    Date.FieldType = ReportFieldTypeEnum.ftVariable;
                    Date.TextFormat = @"dd/MM/yyyy";
                    Date.TextFont.Name = "Calibri";
                    Date.TextFont.Size = 9;
                    Date.TextFont.CharSet = 162;
                    Date.Value = @"{#PROGRESSDATE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 16, 187, 21, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Calibri";
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 202, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingAppliProgress.GetNursingApplicationProgress_Class dataset_GetNursingApplicationProgress = ParentGroup.rsGroup.GetCurrentRecord<NursingAppliProgress.GetNursingApplicationProgress_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    LblDateHour11.CalcValue = LblDateHour11.Value;
                    LblDescription.CalcValue = LblDescription.Value;
                    Date.CalcValue = (dataset_GetNursingApplicationProgress != null ? Globals.ToStringCore(dataset_GetNursingApplicationProgress.ProgressDate) : "");
                    DESCRIPTION.CalcValue = (dataset_GetNursingApplicationProgress != null ? Globals.ToStringCore(dataset_GetNursingApplicationProgress.Description) : "");
                    return new TTReportObject[] { NewField1,LblDateHour11,LblDescription,Date,DESCRIPTION};
                }
            }

        }

        public NURSINGGroup NURSING;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingApplicationReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            NURSING = new NURSINGGroup(HEADER,"NURSING");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGAPPLICATIONREPORT";
            Caption = "Hemşirelik Gözlem Raporu";
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