
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
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi Raporu
    /// </summary>
    public partial class HCFromOtherHospitalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("EE5AEA26-A6D9-4FF7-A10C-E575B7C35239");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HCFromOtherHospitalReport MyParentReport
            {
                get { return (HCFromOtherHospitalReport)ParentReport; }
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
                list[0] = new TTReportNqlData<HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class>("GetCurrentHCEFromOtherHospital", HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCFromOtherHospitalReport MyParentReport
                {
                    get { return (HCFromOtherHospitalReport)ParentReport; }
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
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 126;
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

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 38, 250, 42, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 59, 250, 63, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.Value = @"{#USERNAME#}";

                    USERSINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 76, 250, 80, false);
                    USERSINIF.Name = "USERSINIF";
                    USERSINIF.Visible = EvetHayirEnum.ehHayir;
                    USERSINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERSINIF.Value = @"{#USERSINIF#}";

                    USERRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 80, 250, 84, false);
                    USERRUTBE.Name = "USERRUTBE";
                    USERRUTBE.Visible = EvetHayirEnum.ehHayir;
                    USERRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERRUTBE.Value = @"{#USERRUTBE#}";

                    USERSICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 66, 250, 70, false);
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

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 33, 250, 37, false);
                    TANI.Name = "TANI";
                    TANI.Visible = EvetHayirEnum.ehHayir;
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.TextFormat = @"NOCR/";
                    TANI.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 43, 250, 47, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FillStyle = FillStyleConstants.vbFSTransparent;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR,";
                    MADDE.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 48, 250, 52, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR ";
                    KARAR.Value = @"{#KARAR#}";

                    USERGOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 84, 250, 88, false);
                    USERGOREV.Name = "USERGOREV";
                    USERGOREV.Visible = EvetHayirEnum.ehHayir;
                    USERGOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERGOREV.Value = @"{#USERGOREV#}";

                    USERUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 70, 250, 74, false);
                    USERUNVAN.Name = "USERUNVAN";
                    USERUNVAN.Visible = EvetHayirEnum.ehHayir;
                    USERUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERUNVAN.TextFormat = @"NOCR/";
                    USERUNVAN.Value = @"{#USERUNVAN#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 89, 250, 93, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.ObjectDefName = "Patient";
                    PSURNAME.DataMember = "SURNAME";
                    PSURNAME.Value = @"{#PATIENTOBJECTID#}";

                    BOLUMID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 94, 236, 99, false);
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class dataset_GetCurrentHCEFromOtherHospital = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class>(0);
                    RAPORNO.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Raporno) : "");
                    BOLUM.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Bolum) : "");
                    RAPOR.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Rapor) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Raportarihi) : "");
                    USERNAME.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Username) : "");
                    USERSINIF.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Usersinif) : "");
                    USERRUTBE.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Userrutbe) : "");
                    USERSICILNO.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Usersicilno) : "");
                    PNAME.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Patientobjectid) : "");
                    PNAME.PostFieldValueCalculation();
                    DTARIH.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Patientobjectid) : "");
                    DTARIH.PostFieldValueCalculation();
                    TANI.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    KARAR.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Karar) : "");
                    USERGOREV.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Usergorev) : "");
                    USERUNVAN.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Userunvan) : "");
                    PSURNAME.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Patientobjectid) : "");
                    PSURNAME.PostFieldValueCalculation();
                    BOLUMID.CalcValue = (dataset_GetCurrentHCEFromOtherHospital != null ? Globals.ToStringCore(dataset_GetCurrentHCEFromOtherHospital.Bolumid) : "");
                    BOLUMRAPOR.CalcValue = BOLUMRAPOR.Value;
                    return new TTReportObject[] { RAPORNO,BOLUM,RAPOR,RAPORTARIHI,USERNAME,USERSINIF,USERRUTBE,USERSICILNO,PNAME,DTARIH,TANI,MADDE,KARAR,USERGOREV,USERUNVAN,PSURNAME,BOLUMID,BOLUMRAPOR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                    string sDepartment = this.BOLUM.CalcValue;
//            string sDepReport = "";
//            string sNewLine = System.Environment.NewLine;
//            string sObjectID = ((HCFromOtherHospitalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HealthCommitteeExaminationFromOtherHospitals hcexam = (HealthCommitteeExaminationFromOtherHospitals)context.GetObject(new Guid(sObjectID),"HealthCommitteeExaminationFromOtherHospitals");
//             
//            string dogumUlke = this.DYERULKE.CalcValue;
//            string dogumIl = this.DYERIL.CalcValue;
//            string dogumIlce = this.DYERILCE.CalcValue;
//            string dogumYeri = "";
//            
//            if (dogumIlce.Trim() != "" )
//            {
//                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
//                    dogumYeri = dogumIlce;
//                else
//                    dogumYeri = dogumIl;
//            }
//            else if (dogumIl.Trim() != "")
//                dogumYeri = dogumIl;
//            else
//                dogumYeri = dogumUlke;
//            
//            sDepReport += this.PNAME.CalcValue + " " + this.PSURNAME.CalcValue + "-";
//            sDepReport += dogumYeri + "," + this.DTARIH.FormattedValue + sNewLine;
//            sDepReport += sDepartment + " RAPORU:";
//            sDepReport += "(" + this.RAPORNO.CalcValue;
//            sDepReport += "/" + this.RAPORTARIHI.FormattedValue + ")";
//            //   sDepReport += " " + TTObjectClasses.Common.GetTextOfRTFString(this.RAPOR.CalcValue) + sNewLine;
//            if(hcexam.Report != null) 
//                sDepReport += " " + TTObjectClasses.Common.GetTextOfRTFString(hcexam.Report.ToString()) + sNewLine;
//            else
//                sDepReport += sNewLine;
//            
//            //Tanı
//            int nCount = 1;
//            this.TANI.CalcValue = "";
//            
//            BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> pDiagnosis = null;
//            pDiagnosis = DiagnosisGrid.GetPreDiagnosisByEpisodeAction(sObjectID);
//            foreach(DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class pGrid in pDiagnosis)
//            {
//                this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Code + " " + pGrid.Diagnosename;
//                if (pGrid.FreeDiagnosis != null)
//                    this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
//                this.TANI.CalcValue += "\r\n";
//                nCount++;
//            }
//            
//            BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> sDiagnosis = null;
//            sDiagnosis = DiagnosisGrid.GetSecDiagnosisByEpisodeAction(sObjectID);
//            foreach(DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class sGrid in sDiagnosis)
//            {
//                this.TANI.CalcValue += nCount.ToString() + "- " + sGrid.Code + " " + sGrid.Diagnosename;
//                if (sGrid.FreeDiagnosis != null)
//                    this.TANI.CalcValue += " (" + sGrid.FreeDiagnosis + ")";
//                this.TANI.CalcValue += "\r\n";
//                nCount++;
//            }
//           
//            //Madde-Dilim-Fıkra
//            string maddeDilimFikra = "[";
//            BindingList<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class> theAnectodes = null;
//            theAnectodes = HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID(sObjectID);
//            foreach(HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class theAnectode in theAnectodes)
//            {
//                maddeDilimFikra += theAnectode.Matter+"/"+theAnectode.Slice+"/"+theAnectode.Anectode;
//                maddeDilimFikra += "  ";
//            }
//            
//            if (theAnectodes.Count > 0)
//                maddeDilimFikra = maddeDilimFikra.Substring(0,maddeDilimFikra.Length-2);
//            
//            maddeDilimFikra += "]";
//            this.MADDE.CalcValue = maddeDilimFikra;
//            
//            //TODO: buraya hangi resource lar için "TANI ve KARAR" teklifi yazılacağı şartı eklenmeli
//            //if(this.BOLUMID.CalcValue == "...")
//            //{
//            sDepReport += "\r\nTANI VE KARAR TEKLİFİ:\r\n" + this.TANI.CalcValue + "\r\n";
//            sDepReport += "(" + this.MADDE.CalcValue + ")\r\n";
//            sDepReport += this.KARAR.CalcValue + sNewLine + sNewLine;
//            //}
//            
//            //UserName,title and specialty
//            for(int i = 0; i<30; i++)
//                sDepReport += " ";
//           
//
//            if (hcexam.DrName != null)
//            {
//                sDepReport += hcexam.DrName + "\r\n";
//                
//                for(int i = 0; i<30; i++)
//                    sDepReport += " ";
//                
//                if (hcexam.DrTitle != null)
//                    sDepReport += hcexam.DrTitle;
//                
//                //if (hcexam.ProcedureDoctor.Rank != null)
//                //    sDepReport += hcexam.ProcedureDoctor.Rank.ShortName;
//                
//                if (hcexam.DrEmploymentRecordID != null)
//                    sDepReport += "(" + hcexam.DrEmploymentRecordID + ")";
//                
//                if (hcexam.DrSpeciality != null)
//                {
//                    sDepReport += "\r\n";
//                    
//                    for(int i = 0; i<30; i++)
//                        sDepReport += " ";
//                    if(hcexam.DrSpeciality.Name != null)
//                        sDepReport += hcexam.DrSpeciality.Name + " Uzmanı";
//                }
//            }
//            
//            this.BOLUMRAPOR.CalcValue = sDepReport;
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

        public HCFromOtherHospitalReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "EE5AEA26-A6D9-4FF7-A10C-E575B7C35239", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCFROMOTHERHOSPITALREPORT";
            Caption = "Diğer XXXXXXlerden Sağlık Kurulu Muayenesi Raporu";
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