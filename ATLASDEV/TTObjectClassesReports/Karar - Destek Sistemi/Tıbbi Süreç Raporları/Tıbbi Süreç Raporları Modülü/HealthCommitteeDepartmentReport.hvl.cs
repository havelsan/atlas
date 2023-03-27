
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
    /// Sağlık Kurulu Bölüm Raporu
    /// </summary>
    public partial class HealthCommitteeDepartmentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("EE5AEA26-A6D9-4FF7-A10C-E575B7C35239");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeDepartmentReport MyParentReport
            {
                get { return (HealthCommitteeDepartmentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField RAPOR { get {return Body().RAPOR;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField USERNAME { get {return Body().USERNAME;} }
            public TTReportField USERSINIF { get {return Body().USERSINIF;} }
            public TTReportField USERRUTBE { get {return Body().USERRUTBE;} }
            public TTReportField USERSICILNO { get {return Body().USERSICILNO;} }
            public TTReportField PNAME { get {return Body().PNAME;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField USERGOREV { get {return Body().USERGOREV;} }
            public TTReportField USERUNVAN { get {return Body().USERUNVAN;} }
            public TTReportField PSURNAME { get {return Body().PSURNAME;} }
            public TTReportField BOLUMID { get {return Body().BOLUMID;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportRTF BOLUMRAPORRTF { get {return Body().BOLUMRAPORRTF;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetCurrentHCExamination_Class>("GetCurrentHCExamination", HealthCommitteeExamination.GetCurrentHCExamination((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HealthCommitteeDepartmentReport MyParentReport
                {
                    get { return (HealthCommitteeDepartmentReport)ParentReport; }
                }
                
                public TTReportField RAPORNO;
                public TTReportField BOLUM;
                public TTReportField RAPOR;
                public TTReportField RAPORTARIHI;
                public TTReportField USERNAME;
                public TTReportField USERSINIF;
                public TTReportField USERRUTBE;
                public TTReportField USERSICILNO;
                public TTReportField PNAME;
                public TTReportField DTARIH;
                public TTReportField TANI;
                public TTReportField MADDE;
                public TTReportField KARAR;
                public TTReportField USERGOREV;
                public TTReportField USERUNVAN;
                public TTReportField PSURNAME;
                public TTReportField BOLUMID;
                public TTReportField BOLUMRAPOR;
                public TTReportRTF BOLUMRAPORRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 21, 250, 25, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.Visible = EvetHayirEnum.ehHayir;
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 17, 250, 21, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.Visible = EvetHayirEnum.ehHayir;
                    BOLUM.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.Value = @"{#BOLUM#}";

                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 2, 250, 6, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.Visible = EvetHayirEnum.ehHayir;
                    RAPOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR.Value = @"{#RAPOR#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 8, 293, 12, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 24, 293, 28, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.Value = @"{#USERNAME#}";

                    USERSINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 12, 337, 16, false);
                    USERSINIF.Name = "USERSINIF";
                    USERSINIF.Visible = EvetHayirEnum.ehHayir;
                    USERSINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERSINIF.Value = @"{#USERSINIF#}";

                    USERRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 16, 337, 20, false);
                    USERRUTBE.Name = "USERRUTBE";
                    USERRUTBE.Visible = EvetHayirEnum.ehHayir;
                    USERRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERRUTBE.Value = @"{#USERRUTBE#}";

                    USERSICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 2, 337, 6, false);
                    USERSICILNO.Name = "USERSICILNO";
                    USERSICILNO.Visible = EvetHayirEnum.ehHayir;
                    USERSICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERSICILNO.Value = @"{#USERSICILNO#}";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 12, 250, 16, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.ObjectDefName = "Patient";
                    PNAME.DataMember = "NAME";
                    PNAME.Value = @"{#PATIENTOBJECTID#}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 26, 250, 30, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.ObjectDefName = "Patient";
                    DTARIH.DataMember = "BIRTHDATE";
                    DTARIH.Value = @"{#PATIENTOBJECTID#}";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 3, 293, 7, false);
                    TANI.Name = "TANI";
                    TANI.Visible = EvetHayirEnum.ehHayir;
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.TextFormat = @"NOCR/";
                    TANI.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 13, 293, 17, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FillStyle = FillStyleConstants.vbFSTransparent;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR,";
                    MADDE.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 18, 293, 22, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR ";
                    KARAR.Value = @"{#KARAR#}";

                    USERGOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 20, 337, 24, false);
                    USERGOREV.Name = "USERGOREV";
                    USERGOREV.Visible = EvetHayirEnum.ehHayir;
                    USERGOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERGOREV.Value = @"{#USERGOREV#}";

                    USERUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 6, 337, 10, false);
                    USERUNVAN.Name = "USERUNVAN";
                    USERUNVAN.Visible = EvetHayirEnum.ehHayir;
                    USERUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERUNVAN.TextFormat = @"NOCR/";
                    USERUNVAN.Value = @"{#USERUNVAN#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 25, 337, 29, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.ObjectDefName = "Patient";
                    PSURNAME.DataMember = "SURNAME";
                    PSURNAME.Value = @"{#PATIENTOBJECTID#}";

                    BOLUMID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 345, 20, 370, 25, false);
                    BOLUMID.Name = "BOLUMID";
                    BOLUMID.Visible = EvetHayirEnum.ehHayir;
                    BOLUMID.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMID.Value = @"{#BOLUMID#}";

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 204, 12, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 8;
                    BOLUMRAPOR.Value = @"";

                    BOLUMRAPORRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 7, 13, 204, 18, false);
                    BOLUMRAPORRTF.Name = "BOLUMRAPORRTF";
                    BOLUMRAPORRTF.EvaluateValue = EvetHayirEnum.ehEvet;
                    BOLUMRAPORRTF.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetCurrentHCExamination_Class dataset_GetCurrentHCExamination = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetCurrentHCExamination_Class>(0);
                    RAPORNO.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Raporno) : "");
                    BOLUM.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Bolum) : "");
                    RAPOR.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Rapor) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Raportarihi) : "");
                    USERNAME.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Username) : "");
                    USERSINIF.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Usersinif) : "");
                    USERRUTBE.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Userrutbe) : "");
                    USERSICILNO.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Usersicilno) : "");
                    PNAME.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Patientobjectid) : "");
                    PNAME.PostFieldValueCalculation();
                    DTARIH.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Patientobjectid) : "");
                    DTARIH.PostFieldValueCalculation();
                    TANI.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    KARAR.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Karar) : "");
                    USERGOREV.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Usergorev) : "");
                    USERUNVAN.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Userunvan) : "");
                    PSURNAME.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Patientobjectid) : "");
                    PSURNAME.PostFieldValueCalculation();
                    BOLUMID.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Bolumid) : "");
                    BOLUMRAPOR.CalcValue = BOLUMRAPOR.Value;
                    BOLUMRAPORRTF.CalcValue = BOLUMRAPORRTF.Value;
                    return new TTReportObject[] { RAPORNO,BOLUM,RAPOR,RAPORTARIHI,USERNAME,USERSINIF,USERRUTBE,USERSICILNO,PNAME,DTARIH,TANI,MADDE,KARAR,USERGOREV,USERUNVAN,PSURNAME,BOLUMID,BOLUMRAPOR,BOLUMRAPORRTF};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            string sDepartment = this.BOLUM.CalcValue;
//            string sDepReport = string.Empty;
//            string sNewLine = System.Environment.NewLine;
//            string sObjectID = ((HealthCommitteeDepartmentReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HealthCommitteeExamination hcexam = (HealthCommitteeExamination)context.GetObject(new Guid(sObjectID),"HealthCommitteeExamination");
//            
////            string dogumUlke = this.DYERULKE.CalcValue;
////            string dogumIl = this.DYERIL.CalcValue;
////            string dogumIlce = this.DYERILCE.CalcValue;
////            string dogumYeri = "";
////            
////            if (dogumIlce.Trim() != "" )
////            {
////                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
////                    dogumYeri = dogumIlce;
////                else
////                    dogumYeri = dogumIl;
////            }
////            else if (dogumIl.Trim() != "")
////                dogumYeri = dogumIl;
////            else
////                dogumYeri = dogumUlke;
//            
//            sDepReport += this.PNAME.CalcValue + " " + this.PSURNAME.CalcValue + "-";
//            sDepReport += dogumYeri + "," + this.DTARIH.FormattedValue + sNewLine;
//            sDepReport += sDepartment + " RAPORU:";
//            sDepReport += "(" + this.RAPORNO.CalcValue;
//            sDepReport += "/" + this.RAPORTARIHI.FormattedValue + ")";
//            
//            this.BOLUMRAPOR.CalcValue = sDepReport;
//            
//            if(hcexam.Report != null)
//            {
//                string report = hcexam.Report.ToString();
//                report = report.Replace("Tahoma","Arial Narrow");  // font değiştirilir
//                report = report.Replace("\\fs20","\\fs16");        // font size değiştirilir
//                this.BOLUMRAPORRTF.CalcValue = report;
//            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeDepartmentReport MyParentReport
            {
                get { return (HealthCommitteeDepartmentReport)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetCurrentHCExamination_Class>("GetCurrentHCExamination", HealthCommitteeExamination.GetCurrentHCExamination((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HealthCommitteeDepartmentReport MyParentReport
                {
                    get { return (HealthCommitteeDepartmentReport)ParentReport; }
                }
                
                public TTReportField BOLUMRAPOR;
                public TTReportField TANI;
                public TTReportField MADDE;
                public TTReportField KARAR; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 204, 6, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 8;
                    BOLUMRAPOR.Value = @"";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 250, 5, false);
                    TANI.Name = "TANI";
                    TANI.Visible = EvetHayirEnum.ehHayir;
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.TextFormat = @"NOCR/";
                    TANI.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 1, 293, 5, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FillStyle = FillStyleConstants.vbFSTransparent;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR,";
                    MADDE.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 337, 5, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR ";
                    KARAR.Value = @"{#KARAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetCurrentHCExamination_Class dataset_GetCurrentHCExamination = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetCurrentHCExamination_Class>(0);
                    BOLUMRAPOR.CalcValue = BOLUMRAPOR.Value;
                    TANI.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    KARAR.CalcValue = (dataset_GetCurrentHCExamination != null ? Globals.ToStringCore(dataset_GetCurrentHCExamination.Karar) : "");
                    return new TTReportObject[] { BOLUMRAPOR,TANI,MADDE,KARAR};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    string sDepReport = string.Empty;
            string sNewLine = System.Environment.NewLine;
            string sObjectID = ((HealthCommitteeDepartmentReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext context = new TTObjectContext(true);
            HealthCommitteeExamination hcexam = (HealthCommitteeExamination)context.GetObject(new Guid(sObjectID),"HealthCommitteeExamination");
            
            //Tanı
            int nCount = 1;
            this.TANI.CalcValue = "";
            
            BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> pDiagnosis = null;
            pDiagnosis = DiagnosisGrid.GetPreDiagnosisByEpisodeAction(sObjectID);
            foreach(DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class pGrid in pDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Code + " " + pGrid.Diagnosename;
                if (pGrid.FreeDiagnosis != null)
                    this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                this.TANI.CalcValue += "\r\n";
                nCount++;
            }
            
            BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> sDiagnosis = null;
            sDiagnosis = DiagnosisGrid.GetSecDiagnosisByEpisodeAction(sObjectID);
            foreach(DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class sGrid in sDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- " + sGrid.Code + " " + sGrid.Diagnosename;
                if (sGrid.FreeDiagnosis != null)
                    this.TANI.CalcValue += " (" + sGrid.FreeDiagnosis + ")";
                this.TANI.CalcValue += "\r\n";
                nCount++;
            }
            
            //Madde-Dilim-Fıkra
            string maddeDilimFikra = "[";
            BindingList<HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID_Class> theAnectodes = null;
            theAnectodes = HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID(sObjectID);
            foreach(HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID_Class theAnectode in theAnectodes)
            {
                maddeDilimFikra += theAnectode.Matter+"/"+theAnectode.Slice+"/"+theAnectode.Anectode;
                maddeDilimFikra += "  ";
            }
            
            if (theAnectodes.Count > 0)
                maddeDilimFikra = maddeDilimFikra.Substring(0,maddeDilimFikra.Length-2);
            
            maddeDilimFikra += "]";
            this.MADDE.CalcValue = maddeDilimFikra;
            
            sDepReport += "TANI VE KARAR TEKLİFİ:\r\n" + this.TANI.CalcValue + "\r\n";
            sDepReport += "(" + this.MADDE.CalcValue + ")\r\n";
            sDepReport += this.KARAR.CalcValue + sNewLine + sNewLine;
            
            //UserName,Rank,Class and title
            for(int i = 0; i<30; i++)
                sDepReport += " ";
            
            if (hcexam.ProcedureDoctor != null)
            {
                sDepReport += hcexam.ProcedureDoctor.Name + "\r\n";
                
                for(int i = 0; i<30; i++)
                    sDepReport += " ";
                
                if (hcexam.ProcedureDoctor.Title.HasValue)
                    sDepReport += TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcexam.ProcedureDoctor.Title.Value);
                
                if (hcexam.ProcedureDoctor.Rank != null)
                    sDepReport += hcexam.ProcedureDoctor.Rank.ShortName;
                
                if (hcexam.ProcedureDoctor.EmploymentRecordID != null)
                    sDepReport += "(" + hcexam.ProcedureDoctor.EmploymentRecordID + ")";
                
                if (hcexam.ProcedureDoctor.GetSpeciality() != null)
                {
                    sDepReport += "\r\n";
                    
                    for(int i = 0; i<30; i++)
                        sDepReport += " ";
                    
                    sDepReport += hcexam.ProcedureDoctor.GetSpeciality().Name + " Uzmanı";
                }               
              
            }
            
            this.BOLUMRAPOR.CalcValue = sDepReport;
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeDepartmentReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            PARTA = new PARTAGroup(this,"PARTA");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "EE5AEA26-A6D9-4FF7-A10C-E575B7C35239", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEDEPARTMENTREPORT";
            Caption = "Sağlık Kurulu Bölüm Raporu";
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