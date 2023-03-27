
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
    public partial class PrescriptionReportByDrungOrderIntroduction : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public PrescriptionTypeEnum? PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PrescriptionReportByDrungOrderIntroduction MyParentReport
            {
                get { return (PrescriptionReportByDrungOrderIntroduction)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField HOSPITALNAME1 { get {return Header().HOSPITALNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField121111 { get {return Header().NewField121111;} }
            public TTReportField NewField131111 { get {return Header().NewField131111;} }
            public TTReportField NewField141111 { get {return Header().NewField141111;} }
            public TTReportField NewField102111 { get {return Header().NewField102111;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField PRESCRIPTIONDATE { get {return Header().PRESCRIPTIONDATE;} }
            public TTReportField DIAGNOSIS { get {return Header().DIAGNOSIS;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField PATIENTID { get {return Header().PATIENTID;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField MEDULASAGLIKTESISKODU { get {return Header().MEDULASAGLIKTESISKODU;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportField ERECETENO { get {return Header().ERECETENO;} }
            public TTReportField NewField1111121 { get {return Header().NewField1111121;} }
            public TTReportField NewField11211113 { get {return Header().NewField11211113;} }
            public TTReportField PRESTYPE { get {return Header().PRESTYPE;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField111111721 { get {return Footer().NewField111111721;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public TTReportField NewField1227111111 { get {return Footer().NewField1227111111;} }
            public TTReportField TITLE_RANK_NAME_SURNAME { get {return Footer().TITLE_RANK_NAME_SURNAME;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField DIPLOMAREGISTERNO { get {return Footer().DIPLOMAREGISTERNO;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
                list[0] = new TTReportNqlData<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>("GetInpatientPrescriptionReportQuery", InpatientPrescription.GetInpatientPrescriptionReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PrescriptionReportByDrungOrderIntroduction MyParentReport
                {
                    get { return (PrescriptionReportByDrungOrderIntroduction)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField HOSPITALNAME1;
                public TTReportField NewField11;
                public TTReportField NewField11111;
                public TTReportField NewField121111;
                public TTReportField NewField131111;
                public TTReportField NewField141111;
                public TTReportField NewField102111;
                public TTReportField PAYER;
                public TTReportField PRESCRIPTIONDATE;
                public TTReportField DIAGNOSIS;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTID;
                public TTReportField PROTOCOLNO;
                public TTReportField HOSPITAL;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportField NewField12;
                public TTReportField MEDULASAGLIKTESISKODU;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportField ERECETENO;
                public TTReportField NewField1111121;
                public TTReportField NewField11211113;
                public TTReportField PRESTYPE;
                public TTReportShape NewLine1;
                public TTReportField OBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 75;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 66, 134, 71, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"GEREKLİ TEDAVİ (İLAÇ, PROTEZ VE TBB.MLZ.)";

                    HOSPITALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 134, 8, false);
                    HOSPITALNAME1.Name = "HOSPITALNAME1";
                    HOSPITALNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.TextFont.Name = "Arial";
                    HOSPITALNAME1.TextFont.Size = 11;
                    HOSPITALNAME1.TextFont.Bold = true;
                    HOSPITALNAME1.TextFont.CharSet = 162;
                    HOSPITALNAME1.Value = @"XXXXXX REÇETE KAĞIDI";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 38, 135, 47, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"DÜZENLEYEN SAĞLIK BİRLİK/KURUM ADI:";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 29, 135, 38, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"REÇETE TANZİM TARİHİ:";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 47, 135, 65, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 8;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"TANI:";

                    NewField131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 29, 75, 38, false);
                    NewField131111.Name = "NewField131111";
                    NewField131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131111.TextFont.Name = "Arial";
                    NewField131111.TextFont.Size = 8;
                    NewField131111.TextFont.Bold = true;
                    NewField131111.TextFont.CharSet = 162;
                    NewField131111.Value = @" HASTANIN ADI SOYADI:";

                    NewField141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 38, 75, 47, false);
                    NewField141111.Name = "NewField141111";
                    NewField141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141111.TextFont.Name = "Arial";
                    NewField141111.TextFont.Size = 8;
                    NewField141111.TextFont.Bold = true;
                    NewField141111.TextFont.CharSet = 162;
                    NewField141111.Value = @" T.C.KİMLİK NO:";

                    NewField102111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 47, 75, 56, false);
                    NewField102111.Name = "NewField102111";
                    NewField102111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102111.TextFont.Name = "Arial";
                    NewField102111.TextFont.Size = 8;
                    NewField102111.TextFont.Bold = true;
                    NewField102111.TextFont.CharSet = 162;
                    NewField102111.Value = @" PROTOKOL/KARANTİNA NO:";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 42, 133, 46, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYER#}";

                    PRESCRIPTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 33, 125, 37, false);
                    PRESCRIPTIONDATE.Name = "PRESCRIPTIONDATE";
                    PRESCRIPTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONDATE.TextFormat = @"dd/MM/yyyy";
                    PRESCRIPTIONDATE.TextFont.Size = 8;
                    PRESCRIPTIONDATE.TextFont.CharSet = 162;
                    PRESCRIPTIONDATE.Value = @"{#PRESCRIPTIONDATE#}";

                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 51, 134, 64, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.TextFont.Size = 8;
                    DIAGNOSIS.TextFont.CharSet = 162;
                    DIAGNOSIS.Value = @"";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 33, 69, 37, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Size = 8;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENT#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 42, 55, 46, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.TextFont.Size = 8;
                    PATIENTID.TextFont.CharSet = 162;
                    PATIENTID.Value = @"{#UNIQUEREFNO#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 51, 72, 55, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 7, 134, 23, false);
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

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 135, 65, 135, 75, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 65, 1, 75, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 70, 134, 74, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Rp.";

                    MEDULASAGLIKTESISKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 22, 89, 28, false);
                    MEDULASAGLIKTESISKODU.Name = "MEDULASAGLIKTESISKODU";
                    MEDULASAGLIKTESISKODU.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULASAGLIKTESISKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MEDULASAGLIKTESISKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEDULASAGLIKTESISKODU.TextFont.Size = 9;
                    MEDULASAGLIKTESISKODU.TextFont.CharSet = 162;
                    MEDULASAGLIKTESISKODU.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MEDULASAGLIKTESISKODU"", """")";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 2, 1, 32, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 135, 2, 135, 31, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 2, 135, 2, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    ERECETENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 3, 43, 7, false);
                    ERECETENO.Name = "ERECETENO";
                    ERECETENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERECETENO.TextFormat = @"dd/MM/yyyy";
                    ERECETENO.TextFont.Size = 8;
                    ERECETENO.TextFont.CharSet = 162;
                    ERECETENO.Value = @"{#ERECETENO#}";

                    NewField1111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 3, 21, 9, false);
                    NewField1111121.Name = "NewField1111121";
                    NewField1111121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121.TextFont.Name = "Arial";
                    NewField1111121.TextFont.Size = 8;
                    NewField1111121.TextFont.Bold = true;
                    NewField1111121.TextFont.CharSet = 162;
                    NewField1111121.Value = @"EReçete No :";

                    NewField11211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 8, 21, 14, false);
                    NewField11211113.Name = "NewField11211113";
                    NewField11211113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211113.TextFont.Name = "Arial";
                    NewField11211113.TextFont.Size = 8;
                    NewField11211113.TextFont.Bold = true;
                    NewField11211113.TextFont.CharSet = 162;
                    NewField11211113.Value = @"Reçete Tipi :";

                    PRESTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 8, 41, 13, false);
                    PRESTYPE.Name = "PRESTYPE";
                    PRESTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESTYPE.TextFont.Size = 7;
                    PRESTYPE.TextFont.CharSet = 162;
                    PRESTYPE.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 75, 135, 75, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 19, 179, 24, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetInpatientPrescriptionReportQuery_Class dataset_GetInpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    HOSPITALNAME1.CalcValue = HOSPITALNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField121111.CalcValue = NewField121111.Value;
                    NewField131111.CalcValue = NewField131111.Value;
                    NewField141111.CalcValue = NewField141111.Value;
                    NewField102111.CalcValue = NewField102111.Value;
                    PAYER.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.Payer) : "");
                    PRESCRIPTIONDATE.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.Prescriptiondate) : "");
                    DIAGNOSIS.CalcValue = @"";
                    PATIENTNAME.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.Patient) : "");
                    PATIENTID.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.UniqueRefNo) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.HospitalProtocolNo) : "");
                    NewField12.CalcValue = NewField12.Value;
                    ERECETENO.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.EReceteNo) : "");
                    NewField1111121.CalcValue = NewField1111121.Value;
                    NewField11211113.CalcValue = NewField11211113.Value;
                    PRESTYPE.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.ObjectID) : "");
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    MEDULASAGLIKTESISKODU.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    return new TTReportObject[] { NewField111,HOSPITALNAME1,NewField11,NewField11111,NewField121111,NewField131111,NewField141111,NewField102111,PAYER,PRESCRIPTIONDATE,DIAGNOSIS,PATIENTNAME,PATIENTID,PROTOCOLNO,NewField12,ERECETENO,NewField1111121,NewField11211113,PRESTYPE,OBJECTID,HOSPITAL,MEDULASAGLIKTESISKODU};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((PrescriptionReportByDrungOrderIntroduction)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InpatientPrescription deneme = (InpatientPrescription)context.GetObject(new Guid(objectID), "InpatientPrescription");
            Episode episode = deneme.Episode;
            string diagnoseName ="";
            foreach (DiagnosisGrid diagnose in episode.Diagnosis)
            {
                diagnoseName += (diagnose.Diagnose).ToString() + " \r\n";
            }
            DIAGNOSIS.CalcValue = diagnoseName + "  \r\n";
            
            if(deneme.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                PRESTYPE.CalcValue = "Normal Reçete";
            
            if(deneme.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                PRESTYPE.CalcValue = "Yeşil Reçete";
            
            if(deneme.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                PRESTYPE.CalcValue = "Turuncu Reçete";
            
            if(deneme.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                PRESTYPE.CalcValue = "Mor Reçete";
            
            if(deneme.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                PRESTYPE.CalcValue = "Kırmızı Reçete";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PrescriptionReportByDrungOrderIntroduction MyParentReport
                {
                    get { return (PrescriptionReportByDrungOrderIntroduction)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportField NewField111111721;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportField NewField1227111111;
                public TTReportField TITLE_RANK_NAME_SURNAME;
                public TTReportField DIPLOMANO;
                public TTReportField NewField15;
                public TTReportField DIPLOMAREGISTERNO;
                public TTReportShape NewLine2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 45;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 14, 112, 18, false);
                    NewField14.Name = "NewField14";
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Size = 7;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"D.Nu. :";

                    NewField111111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 19, 135, 31, false);
                    NewField111111721.Name = "NewField111111721";
                    NewField111111721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111721.TextFont.Size = 8;
                    NewField111111721.TextFont.Bold = true;
                    NewField111111721.TextFont.CharSet = 162;
                    NewField111111721.Value = @" REÇETE MUHTEVİYATINI TESLİM ALANIN ADI SOYADI VE  İMZASI:";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 0, 1, 26, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 135, -3, 135, 42, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1227111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 31, 135, 44, false);
                    NewField1227111111.Name = "NewField1227111111";
                    NewField1227111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1227111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1227111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1227111111.TextFont.Size = 8;
                    NewField1227111111.TextFont.Bold = true;
                    NewField1227111111.TextFont.CharSet = 162;
                    NewField1227111111.Value = @" BAŞTABİP ONAY (KAŞE- İMZA):               
 ""YATAN HASTA, ECZANEMİZDE YOKTUR."" Kaşesi Basılacaktır.";

                    TITLE_RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 134, 14, false);
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

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 14, 110, 18, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Size = 7;
                    DIPLOMANO.TextFont.CharSet = 162;
                    DIPLOMANO.Value = @"{#DIPLOMANO#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 14, 134, 18, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Size = 7;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"D.Tes.Nu.:";

                    DIPLOMAREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 14, 132, 18, false);
                    DIPLOMAREGISTERNO.Name = "DIPLOMAREGISTERNO";
                    DIPLOMAREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO.TextFont.Size = 7;
                    DIPLOMAREGISTERNO.TextFont.CharSet = 162;
                    DIPLOMAREGISTERNO.Value = @"{#DIPLOMAREGISTERNO#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 0, 135, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetInpatientPrescriptionReportQuery_Class dataset_GetInpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>(0);
                    NewField14.CalcValue = NewField14.Value;
                    NewField111111721.CalcValue = NewField111111721.Value;
                    NewField1227111111.CalcValue = NewField1227111111.Value;
                    TITLE_RANK_NAME_SURNAME.CalcValue = @"";
                    DIPLOMANO.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.DiplomaNo) : "");
                    NewField15.CalcValue = NewField15.Value;
                    DIPLOMAREGISTERNO.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.DiplomaRegisterNo) : "");
                    return new TTReportObject[] { NewField14,NewField111111721,NewField1227111111,TITLE_RANK_NAME_SURNAME,DIPLOMANO,NewField15,DIPLOMAREGISTERNO};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionReportByDrungOrderIntroduction MyParentReport
            {
                get { return (PrescriptionReportByDrungOrderIntroduction)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUG { get {return Body().DRUG;} }
            public TTReportField DOSE { get {return Body().DOSE;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField USAGE { get {return Body().USAGE;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
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

                InpatientPrescription.GetInpatientPrescriptionReportQuery_Class dataSet_GetInpatientPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>(0);    
                return new object[] {(dataSet_GetInpatientPrescriptionReportQuery==null ? null : dataSet_GetInpatientPrescriptionReportQuery.ObjectID)};
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
                public PrescriptionReportByDrungOrderIntroduction MyParentReport
                {
                    get { return (PrescriptionReportByDrungOrderIntroduction)ParentReport; }
                }
                
                public TTReportField DRUG;
                public TTReportField DOSE;
                public TTReportField COUNT;
                public TTReportField NewField1;
                public TTReportField USAGE;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
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
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    DRUG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 130, 5, false);
                    DRUG.Name = "DRUG";
                    DRUG.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG.TextFont.Size = 8;
                    DRUG.TextFont.CharSet = 162;
                    DRUG.Value = @"";

                    DOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 6, 34, 10, false);
                    DOSE.Name = "DOSE";
                    DOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSE.TextFont.Size = 8;
                    DOSE.TextFont.CharSet = 162;
                    DOSE.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 1, 7, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Size = 8;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 13, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S=";

                    USAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 6, 130, 10, false);
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

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 135, -2, 135, 13, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 0, 1, 13, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    WM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 9, 209, 14, false);
                    WM.Name = "WM";
                    WM.Visible = EvetHayirEnum.ehHayir;
                    WM.FieldType = ReportFieldTypeEnum.ftVariable;
                    WM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM.TextFont.Size = 8;
                    WM.TextFont.CharSet = 162;
                    WM.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 1, 186, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"";

                    DRUGPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 198, 6, false);
                    DRUGPRICE.Name = "DRUGPRICE";
                    DRUGPRICE.Visible = EvetHayirEnum.ehHayir;
                    DRUGPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGPRICE.TextFormat = @"#,##0.#0";
                    DRUGPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DRUGPRICE.TextFont.Name = "Arial";
                    DRUGPRICE.TextFont.CharSet = 162;
                    DRUGPRICE.Value = @"";

                    PATIENTLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 1, 210, 6, false);
                    PATIENTLOT.Name = "PATIENTLOT";
                    PATIENTLOT.Visible = EvetHayirEnum.ehHayir;
                    PATIENTLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTLOT.TextFormat = @"#,##0.#0";
                    PATIENTLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PATIENTLOT.TextFont.Name = "Arial";
                    PATIENTLOT.TextFont.CharSet = 162;
                    PATIENTLOT.Value = @"";

                    SOCIETYLOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 236, 6, false);
                    SOCIETYLOT.Name = "SOCIETYLOT";
                    SOCIETYLOT.Visible = EvetHayirEnum.ehHayir;
                    SOCIETYLOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOCIETYLOT.TextFormat = @"#,##0.#0";
                    SOCIETYLOT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SOCIETYLOT.TextFont.Name = "Arial";
                    SOCIETYLOT.TextFont.CharSet = 162;
                    SOCIETYLOT.Value = @"";

                    DRUGEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 33, 181, 38, false);
                    DRUGEND.Name = "DRUGEND";
                    DRUGEND.Visible = EvetHayirEnum.ehHayir;
                    DRUGEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGEND.TextFont.Name = "Arial";
                    DRUGEND.TextFont.CharSet = 162;
                    DRUGEND.Value = @"";

                    VATRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 9, 171, 14, false);
                    VATRATE.Name = "VATRATE";
                    VATRATE.Visible = EvetHayirEnum.ehHayir;
                    VATRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VATRATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    VATRATE.TextFont.Name = "Arial";
                    VATRATE.TextFont.CharSet = 162;
                    VATRATE.Value = @"";

                    PRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 9, 189, 14, false);
                    PRICEDIFFERENCE.Name = "PRICEDIFFERENCE";
                    PRICEDIFFERENCE.Visible = EvetHayirEnum.ehHayir;
                    PRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEDIFFERENCE.TextFormat = @"#,##0.#0";
                    PRICEDIFFERENCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICEDIFFERENCE.TextFont.Name = "Arial";
                    PRICEDIFFERENCE.TextFont.CharSet = 162;
                    PRICEDIFFERENCE.Value = @"";

                    DOSEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 160, 6, false);
                    DOSEAMOUNT.Name = "DOSEAMOUNT";
                    DOSEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    DOSEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSEAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOSEAMOUNT.TextFont.Name = "Arial";
                    DOSEAMOUNT.TextFont.CharSet = 162;
                    DOSEAMOUNT.Value = @"{#PARTA.DOSEAMOUNT#}";

                    FREQUENCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 170, 6, false);
                    FREQUENCY.Name = "FREQUENCY";
                    FREQUENCY.Visible = EvetHayirEnum.ehHayir;
                    FREQUENCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FREQUENCY.TextFont.Name = "Arial";
                    FREQUENCY.TextFont.CharSet = 162;
                    FREQUENCY.Value = @"{#PARTA.FREQUENCY#}";

                    WM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 9, 198, 14, false);
                    WM1.Name = "WM1";
                    WM1.Visible = EvetHayirEnum.ehHayir;
                    WM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WM1.TextFont.Size = 8;
                    WM1.TextFont.CharSet = 162;
                    WM1.Value = @"X";

                    ROMEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 17, 220, 22, false);
                    ROMEN.Name = "ROMEN";
                    ROMEN.Visible = EvetHayirEnum.ehHayir;
                    ROMEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROMEN.Value = @"";

                    DRUG1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 21, 167, 26, false);
                    DRUG1.Name = "DRUG1";
                    DRUG1.Visible = EvetHayirEnum.ehHayir;
                    DRUG1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUG1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUG1.WordBreak = EvetHayirEnum.ehEvet;
                    DRUG1.TextFont.Size = 8;
                    DRUG1.TextFont.CharSet = 162;
                    DRUG1.Value = @"{#PARTA.DRUG#}";

                    USAGENOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 32, 166, 37, false);
                    USAGENOTE.Name = "USAGENOTE";
                    USAGENOTE.Visible = EvetHayirEnum.ehHayir;
                    USAGENOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USAGENOTE.Value = @"{#PARTA.USAGENOTE#}";

                    PACKAGEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 18, 254, 23, false);
                    PACKAGEAMOUNT.Name = "PACKAGEAMOUNT";
                    PACKAGEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    PACKAGEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGEAMOUNT.Value = @"{#PARTA.PACKAGEAMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetInpatientPrescriptionReportQuery_Class dataset_GetInpatientPrescriptionReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>(0);
                    DRUG.CalcValue = @"";
                    DOSE.CalcValue = @"";
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    USAGE.CalcValue = @"";
                    WM.CalcValue = @"";
                    UNITPRICE.CalcValue = @"";
                    DRUGPRICE.CalcValue = @"";
                    PATIENTLOT.CalcValue = @"";
                    SOCIETYLOT.CalcValue = @"";
                    DRUGEND.CalcValue = @"";
                    VATRATE.CalcValue = @"";
                    PRICEDIFFERENCE.CalcValue = @"";
                    DOSEAMOUNT.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.DoseAmount) : "");
                    FREQUENCY.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.Frequency) : "");
                    WM1.CalcValue = WM1.Value;
                    ROMEN.CalcValue = @"";
                    DRUG1.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.Drug) : "");
                    USAGENOTE.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.UsageNote) : "");
                    PACKAGEAMOUNT.CalcValue = (dataset_GetInpatientPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionReportQuery.PackageAmount) : "");
                    return new TTReportObject[] { DRUG,DOSE,COUNT,NewField1,USAGE,WM,UNITPRICE,DRUGPRICE,PATIENTLOT,SOCIETYLOT,DRUGEND,VATRATE,PRICEDIFFERENCE,DOSEAMOUNT,FREQUENCY,WM1,ROMEN,DRUG1,USAGENOTE,PACKAGEAMOUNT};
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

        public PrescriptionReportByDrungOrderIntroduction()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("PRESCRIPTIONTYPE", "", "Reçete Tipi", @"", false, true, false, new Guid("5c575de3-430a-4947-9d86-9273d771d9ee"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PRESCRIPTIONTYPE"))
                _runtimeParameters.PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue(parameters["PRESCRIPTIONTYPE"]);
            Name = "PRESCRIPTIONREPORTBYDRUNGORDERINTRODUCTION";
            Caption = "İlaç Direktifi XXXXXX Reçete Kağıdı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            PaperSize = 11;
            p_PageWidth = 148;
            p_PageHeight = 210;
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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