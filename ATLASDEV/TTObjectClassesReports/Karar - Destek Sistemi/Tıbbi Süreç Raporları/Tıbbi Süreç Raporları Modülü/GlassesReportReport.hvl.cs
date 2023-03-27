
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
    /// Gözlük Reçetesi
    /// </summary>
    public partial class GlassesReportReport : TTReport
    {
#region Methods
   public string doktorName = null, doktorRank = null, doktorRecordID = null, doktorSpeciality = null, diplomaRegisterNo = null, diplomaNo = null ;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public GlassesReportReport MyParentReport
            {
                get { return (GlassesReportReport)ParentReport; }
            }

            new public MASTERGroupHeader Header()
            {
                return (MASTERGroupHeader)_header;
            }

            new public MASTERGroupFooter Footer()
            {
                return (MASTERGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField labelDoctorSection { get {return Footer().labelDoctorSection;} }
            public TTReportField labelDoctorNameSurname { get {return Footer().labelDoctorNameSurname;} }
            public TTReportField labelDoctorRank { get {return Footer().labelDoctorRank;} }
            public TTReportField labelDoctorRecordID { get {return Footer().labelDoctorRecordID;} }
            public TTReportField labelDoctorWork { get {return Footer().labelDoctorWork;} }
            public TTReportField DOCTORNAME { get {return Footer().DOCTORNAME;} }
            public TTReportField DOCTORRANK { get {return Footer().DOCTORRANK;} }
            public TTReportField DOCTORRECORDID { get {return Footer().DOCTORRECORDID;} }
            public TTReportField DOCTORSPECIALITY { get {return Footer().DOCTORSPECIALITY;} }
            public TTReportField labelDoctorWork1 { get {return Footer().labelDoctorWork1;} }
            public TTReportField labelDoctorWork2 { get {return Footer().labelDoctorWork2;} }
            public TTReportField DIPLOMAREGISTERNO { get {return Footer().DIPLOMAREGISTERNO;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public MASTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MASTERGroupHeader(this);
                _footer = new MASTERGroupFooter(this);

            }

            public partial class MASTERGroupHeader : TTReportSection
            {
                public GlassesReportReport MyParentReport
                {
                    get { return (GlassesReportReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 28, 173, 36, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Size = 15;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"GÖZLÜK REÇETESİ";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 4, 173, 27, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 4, 46, 24, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    LOGO.CalcValue = LOGO.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField111,LOGO,XXXXXXBASLIK};
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public GlassesReportReport MyParentReport
                {
                    get { return (GlassesReportReport)ParentReport; }
                }
                
                public TTReportField labelDoctorSection;
                public TTReportField labelDoctorNameSurname;
                public TTReportField labelDoctorRank;
                public TTReportField labelDoctorRecordID;
                public TTReportField labelDoctorWork;
                public TTReportField DOCTORNAME;
                public TTReportField DOCTORRANK;
                public TTReportField DOCTORRECORDID;
                public TTReportField DOCTORSPECIALITY;
                public TTReportField labelDoctorWork1;
                public TTReportField labelDoctorWork2;
                public TTReportField DIPLOMAREGISTERNO;
                public TTReportField DIPLOMANO; 
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 42;
                    RepeatCount = 0;
                    
                    labelDoctorSection = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 5, 48, 10, false);
                    labelDoctorSection.Name = "labelDoctorSection";
                    labelDoctorSection.Value = @"Muayene Eden Tabip                : ";

                    labelDoctorNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 10, 48, 15, false);
                    labelDoctorNameSurname.Name = "labelDoctorNameSurname";
                    labelDoctorNameSurname.Value = @"Adı Soyadı                                  : ";

                    labelDoctorRank = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 48, 20, false);
                    labelDoctorRank.Name = "labelDoctorRank";
                    labelDoctorRank.Value = @"Sınıf ve Rütbe                             : ";

                    labelDoctorRecordID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 20, 48, 25, false);
                    labelDoctorRecordID.Name = "labelDoctorRecordID";
                    labelDoctorRecordID.Value = @"Sicil No                                       : ";

                    labelDoctorWork = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 48, 30, false);
                    labelDoctorWork.Name = "labelDoctorWork";
                    labelDoctorWork.Value = @"Uzmanlık Dalı                             : ";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 10, 119, 15, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.Value = @"";

                    DOCTORRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 15, 119, 20, false);
                    DOCTORRANK.Name = "DOCTORRANK";
                    DOCTORRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORRANK.Value = @"";

                    DOCTORRECORDID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 20, 119, 25, false);
                    DOCTORRECORDID.Name = "DOCTORRECORDID";
                    DOCTORRECORDID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORRECORDID.Value = @"";

                    DOCTORSPECIALITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 25, 119, 30, false);
                    DOCTORSPECIALITY.Name = "DOCTORSPECIALITY";
                    DOCTORSPECIALITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORSPECIALITY.Value = @"";

                    labelDoctorWork1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 10, 162, 15, false);
                    labelDoctorWork1.Name = "labelDoctorWork1";
                    labelDoctorWork1.Value = @"Diploma Sicil No                        : ";

                    labelDoctorWork2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 15, 162, 20, false);
                    labelDoctorWork2.Name = "labelDoctorWork2";
                    labelDoctorWork2.Value = @"Diploma Tescil No                      :";

                    DIPLOMAREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 10, 209, 15, false);
                    DIPLOMAREGISTERNO.Name = "DIPLOMAREGISTERNO";
                    DIPLOMAREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO.Value = @"";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 15, 209, 20, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    labelDoctorSection.CalcValue = labelDoctorSection.Value;
                    labelDoctorNameSurname.CalcValue = labelDoctorNameSurname.Value;
                    labelDoctorRank.CalcValue = labelDoctorRank.Value;
                    labelDoctorRecordID.CalcValue = labelDoctorRecordID.Value;
                    labelDoctorWork.CalcValue = labelDoctorWork.Value;
                    DOCTORNAME.CalcValue = @"";
                    DOCTORRANK.CalcValue = @"";
                    DOCTORRECORDID.CalcValue = @"";
                    DOCTORSPECIALITY.CalcValue = @"";
                    labelDoctorWork1.CalcValue = labelDoctorWork1.Value;
                    labelDoctorWork2.CalcValue = labelDoctorWork2.Value;
                    DIPLOMAREGISTERNO.CalcValue = @"";
                    DIPLOMANO.CalcValue = @"";
                    return new TTReportObject[] { labelDoctorSection,labelDoctorNameSurname,labelDoctorRank,labelDoctorRecordID,labelDoctorWork,DOCTORNAME,DOCTORRANK,DOCTORRECORDID,DOCTORSPECIALITY,labelDoctorWork1,labelDoctorWork2,DIPLOMAREGISTERNO,DIPLOMANO};
                }

                public override void RunScript()
                {
#region MASTER FOOTER_Script
                    this.DOCTORNAME.CalcValue = ((GlassesReportReport)ParentReport).doktorName;
  this.DOCTORRANK.CalcValue = ((GlassesReportReport)ParentReport).doktorRank;
  this.DOCTORRECORDID.CalcValue =  ((GlassesReportReport)ParentReport).doktorRecordID ;
  this.DOCTORSPECIALITY.CalcValue = ((GlassesReportReport)ParentReport).doktorSpeciality;    
  this.DIPLOMAREGISTERNO.CalcValue =  ((GlassesReportReport)ParentReport).diplomaRegisterNo;
this.DIPLOMANO.CalcValue =  ((GlassesReportReport)ParentReport).diplomaNo;
#endregion MASTER FOOTER_Script
                }
            }

        }

        public MASTERGroup MASTER;

        public partial class MAINGroup : TTReportGroup
        {
            public GlassesReportReport MyParentReport
            {
                get { return (GlassesReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField labelPatientSection { get {return Body().labelPatientSection;} }
            public TTReportField labelPatientNameSurname { get {return Body().labelPatientNameSurname;} }
            public TTReportField labelPatientFatherName { get {return Body().labelPatientFatherName;} }
            public TTReportField labelPatientCityOfBirth { get {return Body().labelPatientCityOfBirth;} }
            public TTReportField labelPatientRelationship { get {return Body().labelPatientRelationship;} }
            public TTReportField labelPatientTreatmentClinic { get {return Body().labelPatientTreatmentClinic;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField BIRTHINFO { get {return Body().BIRTHINFO;} }
            public TTReportField RELATIONSHIP { get {return Body().RELATIONSHIP;} }
            public TTReportField MASTERRESOURCE { get {return Body().MASTERRESOURCE;} }
            public TTReportField labelProtocolNo { get {return Body().labelProtocolNo;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField labelDate { get {return Body().labelDate;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportShape NewRect2 { get {return Body().NewRect2;} }
            public TTReportShape NewRect12 { get {return Body().NewRect12;} }
            public TTReportShape NewRect3 { get {return Body().NewRect3;} }
            public TTReportShape NewRect13 { get {return Body().NewRect13;} }
            public TTReportShape NewRect131 { get {return Body().NewRect131;} }
            public TTReportShape NewRect132 { get {return Body().NewRect132;} }
            public TTReportShape NewRect133 { get {return Body().NewRect133;} }
            public TTReportShape NewRect1331 { get {return Body().NewRect1331;} }
            public TTReportShape NewRect1332 { get {return Body().NewRect1332;} }
            public TTReportShape NewRect1333 { get {return Body().NewRect1333;} }
            public TTReportShape NewRect1334 { get {return Body().NewRect1334;} }
            public TTReportShape NewRect1335 { get {return Body().NewRect1335;} }
            public TTReportShape NewRect1336 { get {return Body().NewRect1336;} }
            public TTReportShape NewRect1337 { get {return Body().NewRect1337;} }
            public TTReportShape NewRect1338 { get {return Body().NewRect1338;} }
            public TTReportShape NewRect1339 { get {return Body().NewRect1339;} }
            public TTReportShape NewRect1340 { get {return Body().NewRect1340;} }
            public TTReportShape NewRect11331 { get {return Body().NewRect11331;} }
            public TTReportShape NewRect12331 { get {return Body().NewRect12331;} }
            public TTReportShape NewRect13331 { get {return Body().NewRect13331;} }
            public TTReportShape NewRect14331 { get {return Body().NewRect14331;} }
            public TTReportShape NewRect15331 { get {return Body().NewRect15331;} }
            public TTReportShape NewRect16331 { get {return Body().NewRect16331;} }
            public TTReportShape NewRect17331 { get {return Body().NewRect17331;} }
            public TTReportShape NewRect18331 { get {return Body().NewRect18331;} }
            public TTReportShape NewRect19331 { get {return Body().NewRect19331;} }
            public TTReportShape NewRect1341 { get {return Body().NewRect1341;} }
            public TTReportShape NewRect11332 { get {return Body().NewRect11332;} }
            public TTReportShape NewRect12332 { get {return Body().NewRect12332;} }
            public TTReportShape NewRect13332 { get {return Body().NewRect13332;} }
            public TTReportShape NewRect14332 { get {return Body().NewRect14332;} }
            public TTReportShape NewRect15332 { get {return Body().NewRect15332;} }
            public TTReportShape NewRect16332 { get {return Body().NewRect16332;} }
            public TTReportShape NewRect17332 { get {return Body().NewRect17332;} }
            public TTReportShape NewRect18332 { get {return Body().NewRect18332;} }
            public TTReportShape NewRect19332 { get {return Body().NewRect19332;} }
            public TTReportShape NewRect1342 { get {return Body().NewRect1342;} }
            public TTReportShape NewRect4 { get {return Body().NewRect4;} }
            public TTReportShape NewRect15 { get {return Body().NewRect15;} }
            public TTReportShape NewRect16 { get {return Body().NewRect16;} }
            public TTReportShape NewRect17 { get {return Body().NewRect17;} }
            public TTReportShape NewRect151 { get {return Body().NewRect151;} }
            public TTReportShape NewRect1151 { get {return Body().NewRect1151;} }
            public TTReportShape NewRect1152 { get {return Body().NewRect1152;} }
            public TTReportShape NewRect1153 { get {return Body().NewRect1153;} }
            public TTReportShape NewRect13511 { get {return Body().NewRect13511;} }
            public TTReportShape NewRect13512 { get {return Body().NewRect13512;} }
            public TTReportShape NewRect13513 { get {return Body().NewRect13513;} }
            public TTReportShape NewRect131531 { get {return Body().NewRect131531;} }
            public TTReportShape NewRect131532 { get {return Body().NewRect131532;} }
            public TTReportField labelVitrum { get {return Body().labelVitrum;} }
            public TTReportField labelFar { get {return Body().labelFar;} }
            public TTReportField labelNear { get {return Body().labelNear;} }
            public TTReportField labelPerminent { get {return Body().labelPerminent;} }
            public TTReportField labelRight { get {return Body().labelRight;} }
            public TTReportShape NewRect14 { get {return Body().NewRect14;} }
            public TTReportField labelLeft { get {return Body().labelLeft;} }
            public TTReportField labelSphRight { get {return Body().labelSphRight;} }
            public TTReportShape NewRect12431 { get {return Body().NewRect12431;} }
            public TTReportField labelCylRight { get {return Body().labelCylRight;} }
            public TTReportShape NewRect12432 { get {return Body().NewRect12432;} }
            public TTReportField labelAxRight1 { get {return Body().labelAxRight1;} }
            public TTReportShape NewRect12433 { get {return Body().NewRect12433;} }
            public TTReportField labelPrisRight { get {return Body().labelPrisRight;} }
            public TTReportShape NewRect12434 { get {return Body().NewRect12434;} }
            public TTReportField labelBasisRight { get {return Body().labelBasisRight;} }
            public TTReportShape NewRect12435 { get {return Body().NewRect12435;} }
            public TTReportField labelSphLeft { get {return Body().labelSphLeft;} }
            public TTReportShape NewRect12436 { get {return Body().NewRect12436;} }
            public TTReportField labelCylLeft { get {return Body().labelCylLeft;} }
            public TTReportShape NewRect12437 { get {return Body().NewRect12437;} }
            public TTReportField labelAxLeft { get {return Body().labelAxLeft;} }
            public TTReportShape NewRect12438 { get {return Body().NewRect12438;} }
            public TTReportField labelPrisLeft { get {return Body().labelPrisLeft;} }
            public TTReportShape NewRect12439 { get {return Body().NewRect12439;} }
            public TTReportField labelBasisLeft { get {return Body().labelBasisLeft;} }
            public TTReportField labelColorAndType { get {return Body().labelColorAndType;} }
            public TTReportField labelPupillierDistance { get {return Body().labelPupillierDistance;} }
            public TTReportField labelBorder { get {return Body().labelBorder;} }
            public TTReportField SPHRIGHTFAR { get {return Body().SPHRIGHTFAR;} }
            public TTReportField CYLRIGHTFAR { get {return Body().CYLRIGHTFAR;} }
            public TTReportField AXRIGHTFAR { get {return Body().AXRIGHTFAR;} }
            public TTReportField PRISRIGHTFAR { get {return Body().PRISRIGHTFAR;} }
            public TTReportField BASISRIGHTFAR { get {return Body().BASISRIGHTFAR;} }
            public TTReportField SPHLEFTFAR { get {return Body().SPHLEFTFAR;} }
            public TTReportField CYLLEFTFAR { get {return Body().CYLLEFTFAR;} }
            public TTReportField AXLEFTFAR { get {return Body().AXLEFTFAR;} }
            public TTReportField PRISLEFTFAR { get {return Body().PRISLEFTFAR;} }
            public TTReportField BASISLEFTFAR { get {return Body().BASISLEFTFAR;} }
            public TTReportField SPHRIGHTNEAR { get {return Body().SPHRIGHTNEAR;} }
            public TTReportField CYLRIGHTNEAR { get {return Body().CYLRIGHTNEAR;} }
            public TTReportField AXRIGHTNEAR { get {return Body().AXRIGHTNEAR;} }
            public TTReportField PRISRIGHTNEAR { get {return Body().PRISRIGHTNEAR;} }
            public TTReportField BASISRIGHTNEAR { get {return Body().BASISRIGHTNEAR;} }
            public TTReportField SPHLEFTNEAR { get {return Body().SPHLEFTNEAR;} }
            public TTReportField CYLLEFTNEAR { get {return Body().CYLLEFTNEAR;} }
            public TTReportField AXLEFTNEAR { get {return Body().AXLEFTNEAR;} }
            public TTReportField PRISLEFTNEAR { get {return Body().PRISLEFTNEAR;} }
            public TTReportField BASISLEFTNEAR { get {return Body().BASISLEFTNEAR;} }
            public TTReportField SPHRIGHTPERMINENT { get {return Body().SPHRIGHTPERMINENT;} }
            public TTReportField CYLRIGHTPERMINENT { get {return Body().CYLRIGHTPERMINENT;} }
            public TTReportField AXRIGHTPERMINENT { get {return Body().AXRIGHTPERMINENT;} }
            public TTReportField PRISRIGHTPERMINENT { get {return Body().PRISRIGHTPERMINENT;} }
            public TTReportField BASISRIGHTPERMINENT { get {return Body().BASISRIGHTPERMINENT;} }
            public TTReportField SPHLEFTPERMINENT { get {return Body().SPHLEFTPERMINENT;} }
            public TTReportField CYLLEFTPERMINENT { get {return Body().CYLLEFTPERMINENT;} }
            public TTReportField AXLEFTPERMINENT { get {return Body().AXLEFTPERMINENT;} }
            public TTReportField PRISLEFTPERMINENT { get {return Body().PRISLEFTPERMINENT;} }
            public TTReportField BASISLEFTPERMINENT { get {return Body().BASISLEFTPERMINENT;} }
            public TTReportField COLORFAR { get {return Body().COLORFAR;} }
            public TTReportField COLORNEAR { get {return Body().COLORNEAR;} }
            public TTReportField DISTANCEFAR { get {return Body().DISTANCEFAR;} }
            public TTReportField DISTANCENEAR { get {return Body().DISTANCENEAR;} }
            public TTReportField DISTANCEPERMINENT { get {return Body().DISTANCEPERMINENT;} }
            public TTReportField BORDERFAR { get {return Body().BORDERFAR;} }
            public TTReportField BORDERNEAR { get {return Body().BORDERNEAR;} }
            public TTReportField BORDERPERMINENT { get {return Body().BORDERPERMINENT;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportShape NewCircle2 { get {return Body().NewCircle2;} }
            public TTReportShape NewCircle12 { get {return Body().NewCircle12;} }
            public TTReportShape NewCircle11 { get {return Body().NewCircle11;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField labelRightNum11 { get {return Body().labelRightNum11;} }
            public TTReportField labelRightNum13 { get {return Body().labelRightNum13;} }
            public TTReportField labelRightNum12 { get {return Body().labelRightNum12;} }
            public TTReportField labelRightNum1 { get {return Body().labelRightNum1;} }
            public TTReportShape NewCircle111 { get {return Body().NewCircle111;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportField labelLeftNum1 { get {return Body().labelLeftNum1;} }
            public TTReportField labelLeftNum3 { get {return Body().labelLeftNum3;} }
            public TTReportField labelLeftNum2 { get {return Body().labelLeftNum2;} }
            public TTReportField labelLeftNum { get {return Body().labelLeftNum;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField SECDIAGNOSIS { get {return Body().SECDIAGNOSIS;} }
            public TTReportField GLASSRIGHTTYPEFAR { get {return Body().GLASSRIGHTTYPEFAR;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField RENKVECINSUZAKSAG { get {return Body().RENKVECINSUZAKSAG;} }
            public TTReportField GLASSRIGHTTYPENEAR { get {return Body().GLASSRIGHTTYPENEAR;} }
            public TTReportField GLASSLEFTTYPEFAR { get {return Body().GLASSLEFTTYPEFAR;} }
            public TTReportField GLASSLEFTTYPENEAR { get {return Body().GLASSLEFTTYPENEAR;} }
            public TTReportField GLASSCOLORRIGHTFAR { get {return Body().GLASSCOLORRIGHTFAR;} }
            public TTReportField RENKVECINSYAKINSAG { get {return Body().RENKVECINSYAKINSAG;} }
            public TTReportField GLASSCOLORRIGHTNEAR { get {return Body().GLASSCOLORRIGHTNEAR;} }
            public TTReportField COLORPERMINENT { get {return Body().COLORPERMINENT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField RENKVECINSUZAKSOL { get {return Body().RENKVECINSUZAKSOL;} }
            public TTReportField GLASSCOLORLEFTFAR { get {return Body().GLASSCOLORLEFTFAR;} }
            public TTReportField RENKVECINSYAKINSAG1 { get {return Body().RENKVECINSYAKINSAG1;} }
            public TTReportField GLASSCOLORLEFTNEAR { get {return Body().GLASSCOLORLEFTNEAR;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
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
                list[0] = new TTReportNqlData<GlassesReport.GetGlassesReport_Class>("GetGlassesReport", GlassesReport.GetGlassesReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public GlassesReportReport MyParentReport
                {
                    get { return (GlassesReportReport)ParentReport; }
                }
                
                public TTReportField labelPatientSection;
                public TTReportField labelPatientNameSurname;
                public TTReportField labelPatientFatherName;
                public TTReportField labelPatientCityOfBirth;
                public TTReportField labelPatientRelationship;
                public TTReportField labelPatientTreatmentClinic;
                public TTReportField PATIENTNAME;
                public TTReportField FATHERNAME;
                public TTReportField BIRTHINFO;
                public TTReportField RELATIONSHIP;
                public TTReportField MASTERRESOURCE;
                public TTReportField labelProtocolNo;
                public TTReportField PROTOCOLNO;
                public TTReportField labelDate;
                public TTReportField DATE;
                public TTReportShape NewRect1;
                public TTReportShape NewRect2;
                public TTReportShape NewRect12;
                public TTReportShape NewRect3;
                public TTReportShape NewRect13;
                public TTReportShape NewRect131;
                public TTReportShape NewRect132;
                public TTReportShape NewRect133;
                public TTReportShape NewRect1331;
                public TTReportShape NewRect1332;
                public TTReportShape NewRect1333;
                public TTReportShape NewRect1334;
                public TTReportShape NewRect1335;
                public TTReportShape NewRect1336;
                public TTReportShape NewRect1337;
                public TTReportShape NewRect1338;
                public TTReportShape NewRect1339;
                public TTReportShape NewRect1340;
                public TTReportShape NewRect11331;
                public TTReportShape NewRect12331;
                public TTReportShape NewRect13331;
                public TTReportShape NewRect14331;
                public TTReportShape NewRect15331;
                public TTReportShape NewRect16331;
                public TTReportShape NewRect17331;
                public TTReportShape NewRect18331;
                public TTReportShape NewRect19331;
                public TTReportShape NewRect1341;
                public TTReportShape NewRect11332;
                public TTReportShape NewRect12332;
                public TTReportShape NewRect13332;
                public TTReportShape NewRect14332;
                public TTReportShape NewRect15332;
                public TTReportShape NewRect16332;
                public TTReportShape NewRect17332;
                public TTReportShape NewRect18332;
                public TTReportShape NewRect19332;
                public TTReportShape NewRect1342;
                public TTReportShape NewRect4;
                public TTReportShape NewRect15;
                public TTReportShape NewRect16;
                public TTReportShape NewRect17;
                public TTReportShape NewRect151;
                public TTReportShape NewRect1151;
                public TTReportShape NewRect1152;
                public TTReportShape NewRect1153;
                public TTReportShape NewRect13511;
                public TTReportShape NewRect13512;
                public TTReportShape NewRect13513;
                public TTReportShape NewRect131531;
                public TTReportShape NewRect131532;
                public TTReportField labelVitrum;
                public TTReportField labelFar;
                public TTReportField labelNear;
                public TTReportField labelPerminent;
                public TTReportField labelRight;
                public TTReportShape NewRect14;
                public TTReportField labelLeft;
                public TTReportField labelSphRight;
                public TTReportShape NewRect12431;
                public TTReportField labelCylRight;
                public TTReportShape NewRect12432;
                public TTReportField labelAxRight1;
                public TTReportShape NewRect12433;
                public TTReportField labelPrisRight;
                public TTReportShape NewRect12434;
                public TTReportField labelBasisRight;
                public TTReportShape NewRect12435;
                public TTReportField labelSphLeft;
                public TTReportShape NewRect12436;
                public TTReportField labelCylLeft;
                public TTReportShape NewRect12437;
                public TTReportField labelAxLeft;
                public TTReportShape NewRect12438;
                public TTReportField labelPrisLeft;
                public TTReportShape NewRect12439;
                public TTReportField labelBasisLeft;
                public TTReportField labelColorAndType;
                public TTReportField labelPupillierDistance;
                public TTReportField labelBorder;
                public TTReportField SPHRIGHTFAR;
                public TTReportField CYLRIGHTFAR;
                public TTReportField AXRIGHTFAR;
                public TTReportField PRISRIGHTFAR;
                public TTReportField BASISRIGHTFAR;
                public TTReportField SPHLEFTFAR;
                public TTReportField CYLLEFTFAR;
                public TTReportField AXLEFTFAR;
                public TTReportField PRISLEFTFAR;
                public TTReportField BASISLEFTFAR;
                public TTReportField SPHRIGHTNEAR;
                public TTReportField CYLRIGHTNEAR;
                public TTReportField AXRIGHTNEAR;
                public TTReportField PRISRIGHTNEAR;
                public TTReportField BASISRIGHTNEAR;
                public TTReportField SPHLEFTNEAR;
                public TTReportField CYLLEFTNEAR;
                public TTReportField AXLEFTNEAR;
                public TTReportField PRISLEFTNEAR;
                public TTReportField BASISLEFTNEAR;
                public TTReportField SPHRIGHTPERMINENT;
                public TTReportField CYLRIGHTPERMINENT;
                public TTReportField AXRIGHTPERMINENT;
                public TTReportField PRISRIGHTPERMINENT;
                public TTReportField BASISRIGHTPERMINENT;
                public TTReportField SPHLEFTPERMINENT;
                public TTReportField CYLLEFTPERMINENT;
                public TTReportField AXLEFTPERMINENT;
                public TTReportField PRISLEFTPERMINENT;
                public TTReportField BASISLEFTPERMINENT;
                public TTReportField COLORFAR;
                public TTReportField COLORNEAR;
                public TTReportField DISTANCEFAR;
                public TTReportField DISTANCENEAR;
                public TTReportField DISTANCEPERMINENT;
                public TTReportField BORDERFAR;
                public TTReportField BORDERNEAR;
                public TTReportField BORDERPERMINENT;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportShape NewCircle2;
                public TTReportShape NewCircle12;
                public TTReportShape NewCircle11;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField labelRightNum11;
                public TTReportField labelRightNum13;
                public TTReportField labelRightNum12;
                public TTReportField labelRightNum1;
                public TTReportShape NewCircle111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine1111;
                public TTReportField labelLeftNum1;
                public TTReportField labelLeftNum3;
                public TTReportField labelLeftNum2;
                public TTReportField labelLeftNum;
                public TTReportField NewField11;
                public TTReportShape NewLine12;
                public TTReportField SECDIAGNOSIS;
                public TTReportField GLASSRIGHTTYPEFAR;
                public TTReportField NewField2;
                public TTReportField RENKVECINSUZAKSAG;
                public TTReportField GLASSRIGHTTYPENEAR;
                public TTReportField GLASSLEFTTYPEFAR;
                public TTReportField GLASSLEFTTYPENEAR;
                public TTReportField GLASSCOLORRIGHTFAR;
                public TTReportField RENKVECINSYAKINSAG;
                public TTReportField GLASSCOLORRIGHTNEAR;
                public TTReportField COLORPERMINENT;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField RENKVECINSUZAKSOL;
                public TTReportField GLASSCOLORLEFTFAR;
                public TTReportField RENKVECINSYAKINSAG1;
                public TTReportField GLASSCOLORLEFTNEAR;
                public TTReportField NewField3; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 184;
                    RepeatCount = 0;
                    
                    labelPatientSection = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 12, 48, 17, false);
                    labelPatientSection.Name = "labelPatientSection";
                    labelPatientSection.Value = @"Hastanın                                     : ";

                    labelPatientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 17, 48, 22, false);
                    labelPatientNameSurname.Name = "labelPatientNameSurname";
                    labelPatientNameSurname.Value = @"Adı Soyadı                                  : ";

                    labelPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 32, 48, 37, false);
                    labelPatientFatherName.Name = "labelPatientFatherName";
                    labelPatientFatherName.Value = @"Baba Adı                                    : ";

                    labelPatientCityOfBirth = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 37, 48, 43, false);
                    labelPatientCityOfBirth.Name = "labelPatientCityOfBirth";
                    labelPatientCityOfBirth.Value = @"Doğum Yeri ve Tarihi                 : ";

                    labelPatientRelationship = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 47, 48, 52, false);
                    labelPatientRelationship.Name = "labelPatientRelationship";
                    labelPatientRelationship.Value = @"Akrabalık Derecesi                     : ";

                    labelPatientTreatmentClinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 52, 48, 57, false);
                    labelPatientTreatmentClinic.Name = "labelPatientTreatmentClinic";
                    labelPatientTreatmentClinic.Value = @"Muayeneye Gönderen Makam  : ";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 17, 207, 22, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.ObjectDefName = "Patient";
                    PATIENTNAME.DataMember = "PatientIDandFullName";
                    PATIENTNAME.Value = @"{#PATIENTOBJECTID#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 32, 207, 37, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 37, 207, 42, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.Value = @"{%DYER%}\{%DTARIH%}";

                    RELATIONSHIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 47, 207, 52, false);
                    RELATIONSHIP.Name = "RELATIONSHIP";
                    RELATIONSHIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    RELATIONSHIP.Value = @"{#RELATIONSHIP#}";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 52, 207, 57, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.Value = @"{#MASTERRES#}";

                    labelProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 31, 6, false);
                    labelProtocolNo.Name = "labelProtocolNo";
                    labelProtocolNo.Value = @"Protokol No: ";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 64, 6, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.Value = @"{#PROTOCOLNO#}";

                    labelDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 172, 6, false);
                    labelDate.Name = "labelDate";
                    labelDate.Value = @"Tarih    : ";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 1, 206, 6, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.Value = @"{#REPORTDATE#}";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 141, 204, 180, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 164, 204, 173, false);
                    NewRect2.Name = "NewRect2";
                    NewRect2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 155, 204, 164, false);
                    NewRect12.Name = "NewRect12";
                    NewRect12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 141, 20, 153, false);
                    NewRect3.Name = "NewRect3";
                    NewRect3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 153, 20, 162, false);
                    NewRect13.Name = "NewRect13";
                    NewRect13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 162, 20, 171, false);
                    NewRect131.Name = "NewRect131";
                    NewRect131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 171, 20, 180, false);
                    NewRect132.Name = "NewRect132";
                    NewRect132.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 153, 29, 162, false);
                    NewRect133.Name = "NewRect133";
                    NewRect133.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 29, 153, 38, 162, false);
                    NewRect1331.Name = "NewRect1331";
                    NewRect1331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 38, 153, 47, 162, false);
                    NewRect1332.Name = "NewRect1332";
                    NewRect1332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1333 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 47, 153, 56, 162, false);
                    NewRect1333.Name = "NewRect1333";
                    NewRect1333.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1334 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 56, 153, 65, 162, false);
                    NewRect1334.Name = "NewRect1334";
                    NewRect1334.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1335 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 88, 153, 97, 162, false);
                    NewRect1335.Name = "NewRect1335";
                    NewRect1335.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1336 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 97, 153, 106, 162, false);
                    NewRect1336.Name = "NewRect1336";
                    NewRect1336.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1337 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 106, 153, 115, 162, false);
                    NewRect1337.Name = "NewRect1337";
                    NewRect1337.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1338 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 115, 153, 124, 162, false);
                    NewRect1338.Name = "NewRect1338";
                    NewRect1338.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1339 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 124, 153, 133, 162, false);
                    NewRect1339.Name = "NewRect1339";
                    NewRect1339.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1340 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 162, 29, 171, false);
                    NewRect1340.Name = "NewRect1340";
                    NewRect1340.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 29, 162, 38, 171, false);
                    NewRect11331.Name = "NewRect11331";
                    NewRect11331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect12331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 38, 162, 47, 171, false);
                    NewRect12331.Name = "NewRect12331";
                    NewRect12331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 47, 162, 56, 171, false);
                    NewRect13331.Name = "NewRect13331";
                    NewRect13331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect14331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 56, 162, 65, 171, false);
                    NewRect14331.Name = "NewRect14331";
                    NewRect14331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect15331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 88, 162, 97, 171, false);
                    NewRect15331.Name = "NewRect15331";
                    NewRect15331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect16331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 97, 162, 106, 171, false);
                    NewRect16331.Name = "NewRect16331";
                    NewRect16331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect17331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 106, 162, 115, 171, false);
                    NewRect17331.Name = "NewRect17331";
                    NewRect17331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect18331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 115, 162, 124, 171, false);
                    NewRect18331.Name = "NewRect18331";
                    NewRect18331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect19331 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 124, 162, 133, 171, false);
                    NewRect19331.Name = "NewRect19331";
                    NewRect19331.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1341 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 171, 29, 180, false);
                    NewRect1341.Name = "NewRect1341";
                    NewRect1341.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 29, 171, 38, 180, false);
                    NewRect11332.Name = "NewRect11332";
                    NewRect11332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect12332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 38, 171, 47, 180, false);
                    NewRect12332.Name = "NewRect12332";
                    NewRect12332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 47, 171, 56, 180, false);
                    NewRect13332.Name = "NewRect13332";
                    NewRect13332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect14332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 56, 171, 65, 180, false);
                    NewRect14332.Name = "NewRect14332";
                    NewRect14332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect15332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 88, 171, 97, 180, false);
                    NewRect15332.Name = "NewRect15332";
                    NewRect15332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect16332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 97, 171, 106, 180, false);
                    NewRect16332.Name = "NewRect16332";
                    NewRect16332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect17332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 106, 171, 115, 180, false);
                    NewRect17332.Name = "NewRect17332";
                    NewRect17332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect18332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 115, 171, 124, 180, false);
                    NewRect18332.Name = "NewRect18332";
                    NewRect18332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect19332 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 124, 171, 133, 180, false);
                    NewRect19332.Name = "NewRect19332";
                    NewRect19332.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1342 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 149, 29, 153, false);
                    NewRect1342.Name = "NewRect1342";
                    NewRect1342.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 141, 88, 149, false);
                    NewRect4.Name = "NewRect4";
                    NewRect4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 237, 60, 274, 72, false);
                    NewRect15.Name = "NewRect15";
                    NewRect15.Visible = EvetHayirEnum.ehHayir;
                    NewRect15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 141, 184, 153, false);
                    NewRect16.Name = "NewRect16";
                    NewRect16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 184, 141, 207, 153, false);
                    NewRect17.Name = "NewRect17";
                    NewRect17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 237, 72, 274, 81, false);
                    NewRect151.Name = "NewRect151";
                    NewRect151.Visible = EvetHayirEnum.ehHayir;
                    NewRect151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 237, 81, 274, 90, false);
                    NewRect1151.Name = "NewRect1151";
                    NewRect1151.Visible = EvetHayirEnum.ehHayir;
                    NewRect1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1152 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 237, 90, 274, 99, false);
                    NewRect1152.Name = "NewRect1152";
                    NewRect1152.Visible = EvetHayirEnum.ehHayir;
                    NewRect1152.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1153 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 153, 188, 162, false);
                    NewRect1153.Name = "NewRect1153";
                    NewRect1153.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 162, 188, 171, false);
                    NewRect13511.Name = "NewRect13511";
                    NewRect13511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 171, 188, 180, false);
                    NewRect13512.Name = "NewRect13512";
                    NewRect13512.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13513 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 184, 153, 207, 162, false);
                    NewRect13513.Name = "NewRect13513";
                    NewRect13513.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect131531 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 184, 162, 207, 171, false);
                    NewRect131531.Name = "NewRect131531";
                    NewRect131531.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect131532 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 184, 171, 207, 180, false);
                    NewRect131532.Name = "NewRect131532";
                    NewRect131532.DrawStyle = DrawStyleConstants.vbSolid;

                    labelVitrum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 141, 20, 153, false);
                    labelVitrum.Name = "labelVitrum";
                    labelVitrum.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelVitrum.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelVitrum.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelVitrum.Value = @"VİTRUM";

                    labelFar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 153, 20, 162, false);
                    labelFar.Name = "labelFar";
                    labelFar.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelFar.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelFar.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelFar.Value = @"UZAK";

                    labelNear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 162, 20, 171, false);
                    labelNear.Name = "labelNear";
                    labelNear.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelNear.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelNear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelNear.Value = @"YAKIN";

                    labelPerminent = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 171, 20, 180, false);
                    labelPerminent.Name = "labelPerminent";
                    labelPerminent.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelPerminent.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPerminent.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelPerminent.Value = @"DAİMİ";

                    labelRight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 141, 88, 149, false);
                    labelRight.Name = "labelRight";
                    labelRight.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelRight.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelRight.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelRight.Value = @"SAĞ";

                    NewRect14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 88, 141, 156, 149, false);
                    NewRect14.Name = "NewRect14";
                    NewRect14.DrawStyle = DrawStyleConstants.vbSolid;

                    labelLeft = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 141, 156, 149, false);
                    labelLeft.Name = "labelLeft";
                    labelLeft.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelLeft.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelLeft.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelLeft.Value = @"SOL";

                    labelSphRight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 149, 29, 152, false);
                    labelSphRight.Name = "labelSphRight";
                    labelSphRight.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelSphRight.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelSphRight.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelSphRight.Value = @"SPH.";

                    NewRect12431 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 29, 149, 38, 153, false);
                    NewRect12431.Name = "NewRect12431";
                    NewRect12431.DrawStyle = DrawStyleConstants.vbSolid;

                    labelCylRight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 149, 38, 152, false);
                    labelCylRight.Name = "labelCylRight";
                    labelCylRight.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelCylRight.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelCylRight.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelCylRight.Value = @"CYL.";

                    NewRect12432 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 38, 149, 47, 153, false);
                    NewRect12432.Name = "NewRect12432";
                    NewRect12432.DrawStyle = DrawStyleConstants.vbSolid;

                    labelAxRight1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 149, 47, 152, false);
                    labelAxRight1.Name = "labelAxRight1";
                    labelAxRight1.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelAxRight1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelAxRight1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelAxRight1.Value = @"AX.";

                    NewRect12433 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 47, 149, 56, 153, false);
                    NewRect12433.Name = "NewRect12433";
                    NewRect12433.DrawStyle = DrawStyleConstants.vbSolid;

                    labelPrisRight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 149, 56, 152, false);
                    labelPrisRight.Name = "labelPrisRight";
                    labelPrisRight.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelPrisRight.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPrisRight.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelPrisRight.Value = @"PRIS.";

                    NewRect12434 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 56, 149, 65, 153, false);
                    NewRect12434.Name = "NewRect12434";
                    NewRect12434.DrawStyle = DrawStyleConstants.vbSolid;

                    labelBasisRight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 149, 65, 152, false);
                    labelBasisRight.Name = "labelBasisRight";
                    labelBasisRight.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelBasisRight.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelBasisRight.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelBasisRight.Value = @"BASIS";

                    NewRect12435 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 88, 149, 97, 153, false);
                    NewRect12435.Name = "NewRect12435";
                    NewRect12435.DrawStyle = DrawStyleConstants.vbSolid;

                    labelSphLeft = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 149, 97, 152, false);
                    labelSphLeft.Name = "labelSphLeft";
                    labelSphLeft.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelSphLeft.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelSphLeft.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelSphLeft.Value = @"SPH.";

                    NewRect12436 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 97, 149, 106, 153, false);
                    NewRect12436.Name = "NewRect12436";
                    NewRect12436.DrawStyle = DrawStyleConstants.vbSolid;

                    labelCylLeft = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 149, 106, 152, false);
                    labelCylLeft.Name = "labelCylLeft";
                    labelCylLeft.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelCylLeft.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelCylLeft.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelCylLeft.Value = @"CYL.";

                    NewRect12437 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 106, 149, 115, 153, false);
                    NewRect12437.Name = "NewRect12437";
                    NewRect12437.DrawStyle = DrawStyleConstants.vbSolid;

                    labelAxLeft = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 149, 115, 152, false);
                    labelAxLeft.Name = "labelAxLeft";
                    labelAxLeft.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelAxLeft.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelAxLeft.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelAxLeft.Value = @"AX.";

                    NewRect12438 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 115, 149, 124, 153, false);
                    NewRect12438.Name = "NewRect12438";
                    NewRect12438.DrawStyle = DrawStyleConstants.vbSolid;

                    labelPrisLeft = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 149, 124, 152, false);
                    labelPrisLeft.Name = "labelPrisLeft";
                    labelPrisLeft.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelPrisLeft.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPrisLeft.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelPrisLeft.Value = @"PRIS.";

                    NewRect12439 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 124, 149, 133, 153, false);
                    NewRect12439.Name = "NewRect12439";
                    NewRect12439.DrawStyle = DrawStyleConstants.vbSolid;

                    labelBasisLeft = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 149, 133, 152, false);
                    labelBasisLeft.Name = "labelBasisLeft";
                    labelBasisLeft.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelBasisLeft.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelBasisLeft.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelBasisLeft.Value = @"BASIS";

                    labelColorAndType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 60, 274, 72, false);
                    labelColorAndType.Name = "labelColorAndType";
                    labelColorAndType.Visible = EvetHayirEnum.ehHayir;
                    labelColorAndType.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelColorAndType.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelColorAndType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelColorAndType.Value = @"Rengi ve Cinsi";

                    labelPupillierDistance = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 141, 183, 153, false);
                    labelPupillierDistance.Name = "labelPupillierDistance";
                    labelPupillierDistance.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelPupillierDistance.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelPupillierDistance.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelPupillierDistance.Value = @"Pupiller Mesafesi";

                    labelBorder = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 141, 206, 153, false);
                    labelBorder.Name = "labelBorder";
                    labelBorder.FillStyle = FillStyleConstants.vbFSTransparent;
                    labelBorder.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelBorder.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelBorder.Value = @"Çerçeve";

                    SPHRIGHTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 153, 29, 162, false);
                    SPHRIGHTFAR.Name = "SPHRIGHTFAR";
                    SPHRIGHTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    SPHRIGHTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPHRIGHTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPHRIGHTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPHRIGHTFAR.Value = @"{#SPHRIGHTFAR#}";

                    CYLRIGHTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 153, 38, 162, false);
                    CYLRIGHTFAR.Name = "CYLRIGHTFAR";
                    CYLRIGHTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    CYLRIGHTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CYLRIGHTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CYLRIGHTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CYLRIGHTFAR.Value = @"{#CYLRIGHTFAR#}";

                    AXRIGHTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 153, 47, 162, false);
                    AXRIGHTFAR.Name = "AXRIGHTFAR";
                    AXRIGHTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    AXRIGHTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    AXRIGHTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AXRIGHTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AXRIGHTFAR.Value = @"{#AXRIGHTFAR#}";

                    PRISRIGHTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 153, 56, 162, false);
                    PRISRIGHTFAR.Name = "PRISRIGHTFAR";
                    PRISRIGHTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    PRISRIGHTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRISRIGHTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRISRIGHTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRISRIGHTFAR.Value = @"{#PRISRIGHTFAR#}";

                    BASISRIGHTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 153, 65, 162, false);
                    BASISRIGHTFAR.Name = "BASISRIGHTFAR";
                    BASISRIGHTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASISRIGHTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASISRIGHTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASISRIGHTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASISRIGHTFAR.Value = @"{#BASISRIGHTFAR#}";

                    SPHLEFTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 153, 97, 162, false);
                    SPHLEFTFAR.Name = "SPHLEFTFAR";
                    SPHLEFTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    SPHLEFTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPHLEFTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPHLEFTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPHLEFTFAR.Value = @"{#SPHLEFTFAR#}";

                    CYLLEFTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 153, 106, 162, false);
                    CYLLEFTFAR.Name = "CYLLEFTFAR";
                    CYLLEFTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    CYLLEFTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CYLLEFTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CYLLEFTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CYLLEFTFAR.Value = @"{#CYLLEFTFAR#}";

                    AXLEFTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 153, 115, 162, false);
                    AXLEFTFAR.Name = "AXLEFTFAR";
                    AXLEFTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    AXLEFTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    AXLEFTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AXLEFTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AXLEFTFAR.Value = @"{#AXLEFTFAR#}";

                    PRISLEFTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 153, 124, 162, false);
                    PRISLEFTFAR.Name = "PRISLEFTFAR";
                    PRISLEFTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    PRISLEFTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRISLEFTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRISLEFTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRISLEFTFAR.Value = @"{#PRISLEFTFAR#}";

                    BASISLEFTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 153, 133, 162, false);
                    BASISLEFTFAR.Name = "BASISLEFTFAR";
                    BASISLEFTFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASISLEFTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASISLEFTFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASISLEFTFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASISLEFTFAR.Value = @"{#BASISLEFTFAR#}";

                    SPHRIGHTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 162, 29, 171, false);
                    SPHRIGHTNEAR.Name = "SPHRIGHTNEAR";
                    SPHRIGHTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    SPHRIGHTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPHRIGHTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPHRIGHTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPHRIGHTNEAR.Value = @"{#SPHRIGHTNEAR#}";

                    CYLRIGHTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 162, 38, 171, false);
                    CYLRIGHTNEAR.Name = "CYLRIGHTNEAR";
                    CYLRIGHTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    CYLRIGHTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CYLRIGHTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CYLRIGHTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CYLRIGHTNEAR.Value = @"{#CYLRIGHTNEAR#}";

                    AXRIGHTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 162, 47, 171, false);
                    AXRIGHTNEAR.Name = "AXRIGHTNEAR";
                    AXRIGHTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    AXRIGHTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    AXRIGHTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AXRIGHTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AXRIGHTNEAR.Value = @"{#AXRIGHTNEAR#}";

                    PRISRIGHTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 162, 56, 171, false);
                    PRISRIGHTNEAR.Name = "PRISRIGHTNEAR";
                    PRISRIGHTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    PRISRIGHTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRISRIGHTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRISRIGHTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRISRIGHTNEAR.Value = @"{#PRISRIGHTNEAR#}";

                    BASISRIGHTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 162, 65, 171, false);
                    BASISRIGHTNEAR.Name = "BASISRIGHTNEAR";
                    BASISRIGHTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASISRIGHTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASISRIGHTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASISRIGHTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASISRIGHTNEAR.Value = @"{#BASISRIGHTNEAR#}";

                    SPHLEFTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 162, 97, 171, false);
                    SPHLEFTNEAR.Name = "SPHLEFTNEAR";
                    SPHLEFTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    SPHLEFTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPHLEFTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPHLEFTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPHLEFTNEAR.Value = @"{#SPHLEFTNEAR#}";

                    CYLLEFTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 162, 106, 171, false);
                    CYLLEFTNEAR.Name = "CYLLEFTNEAR";
                    CYLLEFTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    CYLLEFTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CYLLEFTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CYLLEFTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CYLLEFTNEAR.Value = @"{#CYLLEFTNEAR#}";

                    AXLEFTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 162, 115, 171, false);
                    AXLEFTNEAR.Name = "AXLEFTNEAR";
                    AXLEFTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    AXLEFTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    AXLEFTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AXLEFTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AXLEFTNEAR.Value = @"{#AXLEFTNEAR#}";

                    PRISLEFTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 162, 124, 171, false);
                    PRISLEFTNEAR.Name = "PRISLEFTNEAR";
                    PRISLEFTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    PRISLEFTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRISLEFTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRISLEFTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRISLEFTNEAR.Value = @"{#PRISLEFTNEAR#}";

                    BASISLEFTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 162, 133, 171, false);
                    BASISLEFTNEAR.Name = "BASISLEFTNEAR";
                    BASISLEFTNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASISLEFTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASISLEFTNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASISLEFTNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASISLEFTNEAR.Value = @"{#BASISLEFTNEAR#}";

                    SPHRIGHTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 171, 29, 180, false);
                    SPHRIGHTPERMINENT.Name = "SPHRIGHTPERMINENT";
                    SPHRIGHTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    SPHRIGHTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPHRIGHTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPHRIGHTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPHRIGHTPERMINENT.Value = @"{#SPHRIGHTPERMINENT#}";

                    CYLRIGHTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 171, 38, 180, false);
                    CYLRIGHTPERMINENT.Name = "CYLRIGHTPERMINENT";
                    CYLRIGHTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    CYLRIGHTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CYLRIGHTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CYLRIGHTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CYLRIGHTPERMINENT.Value = @"{#CYLRIGHTPERMINENT#}";

                    AXRIGHTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 171, 47, 180, false);
                    AXRIGHTPERMINENT.Name = "AXRIGHTPERMINENT";
                    AXRIGHTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    AXRIGHTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AXRIGHTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AXRIGHTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AXRIGHTPERMINENT.Value = @"{#AXRIGHTPERMINENT#}";

                    PRISRIGHTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 171, 56, 180, false);
                    PRISRIGHTPERMINENT.Name = "PRISRIGHTPERMINENT";
                    PRISRIGHTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    PRISRIGHTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRISRIGHTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRISRIGHTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRISRIGHTPERMINENT.Value = @"{#PRISRIGHTPERMINENT#}";

                    BASISRIGHTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 171, 65, 180, false);
                    BASISRIGHTPERMINENT.Name = "BASISRIGHTPERMINENT";
                    BASISRIGHTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASISRIGHTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASISRIGHTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASISRIGHTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASISRIGHTPERMINENT.Value = @"{#BASISRIGHTPERMINENT#}";

                    SPHLEFTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 171, 97, 180, false);
                    SPHLEFTPERMINENT.Name = "SPHLEFTPERMINENT";
                    SPHLEFTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    SPHLEFTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPHLEFTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPHLEFTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPHLEFTPERMINENT.Value = @"{#SPHLEFTPERMINENT#}";

                    CYLLEFTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 171, 106, 180, false);
                    CYLLEFTPERMINENT.Name = "CYLLEFTPERMINENT";
                    CYLLEFTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    CYLLEFTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CYLLEFTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CYLLEFTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CYLLEFTPERMINENT.Value = @"{#CYLLEFTPERMINENT#}";

                    AXLEFTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 171, 115, 180, false);
                    AXLEFTPERMINENT.Name = "AXLEFTPERMINENT";
                    AXLEFTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    AXLEFTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AXLEFTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AXLEFTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AXLEFTPERMINENT.Value = @"{#AXLEFTPERMINENT#}";

                    PRISLEFTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 171, 124, 180, false);
                    PRISLEFTPERMINENT.Name = "PRISLEFTPERMINENT";
                    PRISLEFTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    PRISLEFTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRISLEFTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRISLEFTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRISLEFTPERMINENT.Value = @"{#PRISLEFTPERMINENT#}";

                    BASISLEFTPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 171, 133, 180, false);
                    BASISLEFTPERMINENT.Name = "BASISLEFTPERMINENT";
                    BASISLEFTPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASISLEFTPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASISLEFTPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASISLEFTPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASISLEFTPERMINENT.Value = @"{#BASISLEFTPERMINENT#}";

                    COLORFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 72, 274, 81, false);
                    COLORFAR.Name = "COLORFAR";
                    COLORFAR.Visible = EvetHayirEnum.ehHayir;
                    COLORFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    COLORFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    COLORFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLORFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLORFAR.ObjectDefName = "GlassColorAndTypeEnum";
                    COLORFAR.DataMember = "DISPLAYTEXT";
                    COLORFAR.Value = @"{#GLASSCOLORANDTYPEFAR#}";

                    COLORNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 81, 274, 90, false);
                    COLORNEAR.Name = "COLORNEAR";
                    COLORNEAR.Visible = EvetHayirEnum.ehHayir;
                    COLORNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    COLORNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    COLORNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLORNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLORNEAR.ObjectDefName = "GlassColorAndTypeEnum";
                    COLORNEAR.DataMember = "DISPLAYTEXT";
                    COLORNEAR.Value = @"{#GLASSCOLORANDTYPENEAR#}";

                    DISTANCEFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 153, 184, 162, false);
                    DISTANCEFAR.Name = "DISTANCEFAR";
                    DISTANCEFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    DISTANCEFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTANCEFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTANCEFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTANCEFAR.Value = @"{#PUPILLERDISTANCEFAR#}";

                    DISTANCENEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 162, 184, 171, false);
                    DISTANCENEAR.Name = "DISTANCENEAR";
                    DISTANCENEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    DISTANCENEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTANCENEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTANCENEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTANCENEAR.Value = @"{#PUPILLERDISTANCENEAR#}";

                    DISTANCEPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 171, 184, 180, false);
                    DISTANCEPERMINENT.Name = "DISTANCEPERMINENT";
                    DISTANCEPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DISTANCEPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTANCEPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTANCEPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTANCEPERMINENT.Value = @"{#PUPILLERDISTANCEPERMINENT#}";

                    BORDERFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 153, 207, 162, false);
                    BORDERFAR.Name = "BORDERFAR";
                    BORDERFAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BORDERFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BORDERFAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BORDERFAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BORDERFAR.Value = @"";

                    BORDERNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 162, 207, 171, false);
                    BORDERNEAR.Name = "BORDERNEAR";
                    BORDERNEAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BORDERNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BORDERNEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BORDERNEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BORDERNEAR.Value = @"";

                    BORDERPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 171, 207, 180, false);
                    BORDERPERMINENT.Name = "BORDERPERMINENT";
                    BORDERPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    BORDERPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BORDERPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BORDERPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BORDERPERMINENT.Value = @"";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 2, 251, 7, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.TextFont.CharSet = 162;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 7, 251, 12, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Size = 9;
                    DYER.TextFont.CharSet = 162;
                    DYER.Value = @"{#CITYOFBIRTH#}";

                    NewCircle2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 95, 100, 122, 117, false);
                    NewCircle2.Name = "NewCircle2";
                    NewCircle2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewCircle12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 95, 106, 123, 119, false);
                    NewCircle12.Name = "NewCircle12";
                    NewCircle12.ForeColor = System.Drawing.Color.White;

                    NewCircle11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 62, 95, 98, 129, false);
                    NewCircle11.Name = "NewCircle11";
                    NewCircle11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 58, 112, 103, 112, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 80, 112, 80, 132, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    labelRightNum11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 109, 58, 114, false);
                    labelRightNum11.Name = "labelRightNum11";
                    labelRightNum11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelRightNum11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelRightNum11.Value = @"0°";

                    labelRightNum13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 109, 110, 114, false);
                    labelRightNum13.Name = "labelRightNum13";
                    labelRightNum13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelRightNum13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelRightNum13.Value = @"180°";

                    labelRightNum12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 132, 83, 137, false);
                    labelRightNum12.Name = "labelRightNum12";
                    labelRightNum12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelRightNum12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelRightNum12.Value = @"90°";

                    labelRightNum1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 103, 86, 108, false);
                    labelRightNum1.Name = "labelRightNum1";
                    labelRightNum1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelRightNum1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelRightNum1.TextFont.Size = 14;
                    labelRightNum1.TextFont.Bold = true;
                    labelRightNum1.TextFont.CharSet = 162;
                    labelRightNum1.Value = @"SAĞ";

                    NewCircle111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 119, 95, 155, 129, false);
                    NewCircle111.Name = "NewCircle111";
                    NewCircle111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 112, 160, 112, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 137, 112, 137, 132, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    labelLeftNum1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 109, 115, 114, false);
                    labelLeftNum1.Name = "labelLeftNum1";
                    labelLeftNum1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelLeftNum1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelLeftNum1.Value = @"0°";

                    labelLeftNum3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 109, 167, 114, false);
                    labelLeftNum3.Name = "labelLeftNum3";
                    labelLeftNum3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelLeftNum3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelLeftNum3.Value = @"180°";

                    labelLeftNum2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 132, 140, 137, false);
                    labelLeftNum2.Name = "labelLeftNum2";
                    labelLeftNum2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelLeftNum2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelLeftNum2.Value = @"90°";

                    labelLeftNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 103, 143, 108, false);
                    labelLeftNum.Name = "labelLeftNum";
                    labelLeftNum.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    labelLeftNum.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    labelLeftNum.TextFont.Size = 14;
                    labelLeftNum.TextFont.Bold = true;
                    labelLeftNum.TextFont.CharSet = 162;
                    labelLeftNum.Value = @"SOL";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 64, 48, 68, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Tanı";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 68, 47, 68, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 69, 207, 85, false);
                    SECDIAGNOSIS.Name = "SECDIAGNOSIS";
                    SECDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.TextFont.CharSet = 162;
                    SECDIAGNOSIS.Value = @"";

                    GLASSRIGHTTYPEFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 144, 240, 149, false);
                    GLASSRIGHTTYPEFAR.Name = "GLASSRIGHTTYPEFAR";
                    GLASSRIGHTTYPEFAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSRIGHTTYPEFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSRIGHTTYPEFAR.ObjectDefName = "GlassTypeEnum";
                    GLASSRIGHTTYPEFAR.DataMember = "DISPLAYTEXT";
                    GLASSRIGHTTYPEFAR.Value = @"{#GLASSRIGHTTYPEFAR#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 149, 88, 153, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.Value = @"CİNSİ VE RENK";

                    RENKVECINSUZAKSAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 153, 88, 162, false);
                    RENKVECINSUZAKSAG.Name = "RENKVECINSUZAKSAG";
                    RENKVECINSUZAKSAG.DrawStyle = DrawStyleConstants.vbSolid;
                    RENKVECINSUZAKSAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    RENKVECINSUZAKSAG.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RENKVECINSUZAKSAG.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RENKVECINSUZAKSAG.TextFont.Size = 8;
                    RENKVECINSUZAKSAG.TextFont.CharSet = 162;
                    RENKVECINSUZAKSAG.Value = @"{%COLORFAR%} {%GLASSRIGHTTYPEFAR%}/{%GLASSCOLORRIGHTFAR%}";

                    GLASSRIGHTTYPENEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 150, 240, 155, false);
                    GLASSRIGHTTYPENEAR.Name = "GLASSRIGHTTYPENEAR";
                    GLASSRIGHTTYPENEAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSRIGHTTYPENEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSRIGHTTYPENEAR.ObjectDefName = "GlassTypeEnum";
                    GLASSRIGHTTYPENEAR.DataMember = "DISPLAYTEXT";
                    GLASSRIGHTTYPENEAR.Value = @"{#GLASSRIGHTTYPENEAR#}";

                    GLASSLEFTTYPEFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 156, 240, 161, false);
                    GLASSLEFTTYPEFAR.Name = "GLASSLEFTTYPEFAR";
                    GLASSLEFTTYPEFAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSLEFTTYPEFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSLEFTTYPEFAR.ObjectDefName = "GlassTypeEnum";
                    GLASSLEFTTYPEFAR.DataMember = "DISPLAYTEXT";
                    GLASSLEFTTYPEFAR.Value = @"{#GLASSLEFTTYPEFAR#}";

                    GLASSLEFTTYPENEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 162, 241, 167, false);
                    GLASSLEFTTYPENEAR.Name = "GLASSLEFTTYPENEAR";
                    GLASSLEFTTYPENEAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSLEFTTYPENEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSLEFTTYPENEAR.ObjectDefName = "GlassTypeEnum";
                    GLASSLEFTTYPENEAR.DataMember = "DISPLAYTEXT";
                    GLASSLEFTTYPENEAR.Value = @"{#GLASSLEFTTYPENEAR#}";

                    GLASSCOLORRIGHTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 145, 271, 150, false);
                    GLASSCOLORRIGHTFAR.Name = "GLASSCOLORRIGHTFAR";
                    GLASSCOLORRIGHTFAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSCOLORRIGHTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSCOLORRIGHTFAR.ObjectDefName = "GlassColorEnum";
                    GLASSCOLORRIGHTFAR.DataMember = "DISPLAYTEXT";
                    GLASSCOLORRIGHTFAR.Value = @"{#GLASSCOLORRIGHTFAR#}";

                    RENKVECINSYAKINSAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 162, 88, 171, false);
                    RENKVECINSYAKINSAG.Name = "RENKVECINSYAKINSAG";
                    RENKVECINSYAKINSAG.DrawStyle = DrawStyleConstants.vbSolid;
                    RENKVECINSYAKINSAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    RENKVECINSYAKINSAG.TextFont.Size = 8;
                    RENKVECINSYAKINSAG.TextFont.CharSet = 162;
                    RENKVECINSYAKINSAG.Value = @"{%COLORNEAR%} {%GLASSRIGHTTYPENEAR%}/{%GLASSCOLORRIGHTNEAR%}";

                    GLASSCOLORRIGHTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 151, 271, 156, false);
                    GLASSCOLORRIGHTNEAR.Name = "GLASSCOLORRIGHTNEAR";
                    GLASSCOLORRIGHTNEAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSCOLORRIGHTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSCOLORRIGHTNEAR.ObjectDefName = "GlassColorEnum";
                    GLASSCOLORRIGHTNEAR.DataMember = "DISPLAYTEXT";
                    GLASSCOLORRIGHTNEAR.Value = @"{#GLASSCOLORRIGHTNEAR#}";

                    COLORPERMINENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 90, 274, 99, false);
                    COLORPERMINENT.Name = "COLORPERMINENT";
                    COLORPERMINENT.Visible = EvetHayirEnum.ehHayir;
                    COLORPERMINENT.FillStyle = FillStyleConstants.vbFSTransparent;
                    COLORPERMINENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COLORPERMINENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLORPERMINENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLORPERMINENT.ObjectDefName = "GlassColorAndTypeEnum";
                    COLORPERMINENT.DataMember = "DISPLAYTEXT";
                    COLORPERMINENT.Value = @"{#GLASSCOLORANDTYPEPERMINENT#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 171, 88, 180, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{%COLORPERMINENT%}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 149, 156, 153, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.Value = @"CİNSİ VE RENK";

                    RENKVECINSUZAKSOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 153, 156, 162, false);
                    RENKVECINSUZAKSOL.Name = "RENKVECINSUZAKSOL";
                    RENKVECINSUZAKSOL.DrawStyle = DrawStyleConstants.vbSolid;
                    RENKVECINSUZAKSOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    RENKVECINSUZAKSOL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RENKVECINSUZAKSOL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RENKVECINSUZAKSOL.TextFont.Size = 8;
                    RENKVECINSUZAKSOL.TextFont.CharSet = 162;
                    RENKVECINSUZAKSOL.Value = @"{%COLORFAR%} {{%GLASSLEFTTYPEFAR%}/{%GLASSCOLORLEFTFAR%}";

                    GLASSCOLORLEFTFAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 157, 271, 162, false);
                    GLASSCOLORLEFTFAR.Name = "GLASSCOLORLEFTFAR";
                    GLASSCOLORLEFTFAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSCOLORLEFTFAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSCOLORLEFTFAR.ObjectDefName = "GlassColorEnum";
                    GLASSCOLORLEFTFAR.DataMember = "DISPLAYTEXT";
                    GLASSCOLORLEFTFAR.Value = @"{#GLASSCOLORLEFTFAR#}";

                    RENKVECINSYAKINSAG1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 162, 156, 171, false);
                    RENKVECINSYAKINSAG1.Name = "RENKVECINSYAKINSAG1";
                    RENKVECINSYAKINSAG1.DrawStyle = DrawStyleConstants.vbSolid;
                    RENKVECINSYAKINSAG1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RENKVECINSYAKINSAG1.TextFont.Size = 8;
                    RENKVECINSYAKINSAG1.TextFont.CharSet = 162;
                    RENKVECINSYAKINSAG1.Value = @"{%COLORNEAR%} {%GLASSLEFTTYPENEAR%}/{%GLASSCOLORLEFTNEAR%}";

                    GLASSCOLORLEFTNEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 163, 271, 168, false);
                    GLASSCOLORLEFTNEAR.Name = "GLASSCOLORLEFTNEAR";
                    GLASSCOLORLEFTNEAR.Visible = EvetHayirEnum.ehHayir;
                    GLASSCOLORLEFTNEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASSCOLORLEFTNEAR.ObjectDefName = "GlassColorEnum";
                    GLASSCOLORLEFTNEAR.DataMember = "DISPLAYTEXT";
                    GLASSCOLORLEFTNEAR.Value = @"{#GLASSCOLORLEFTNEAR#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 171, 156, 180, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.TextFont.Size = 8;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"{%COLORPERMINENT%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GlassesReport.GetGlassesReport_Class dataset_GetGlassesReport = ParentGroup.rsGroup.GetCurrentRecord<GlassesReport.GetGlassesReport_Class>(0);
                    labelPatientSection.CalcValue = labelPatientSection.Value;
                    labelPatientNameSurname.CalcValue = labelPatientNameSurname.Value;
                    labelPatientFatherName.CalcValue = labelPatientFatherName.Value;
                    labelPatientCityOfBirth.CalcValue = labelPatientCityOfBirth.Value;
                    labelPatientRelationship.CalcValue = labelPatientRelationship.Value;
                    labelPatientTreatmentClinic.CalcValue = labelPatientTreatmentClinic.Value;
                    PATIENTNAME.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.Patientobjectid) : "");
                    PATIENTNAME.PostFieldValueCalculation();
                    FATHERNAME.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.FatherName) : "");
                    DYER.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.Cityofbirth) : "");
                    DTARIH.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BirthDate) : "");
                    BIRTHINFO.CalcValue = MyParentReport.MAIN.DYER.CalcValue + @"\" + MyParentReport.MAIN.DTARIH.FormattedValue;
                    RELATIONSHIP.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.Relationship) : "");
                    MASTERRESOURCE.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.Masterres) : "");
                    labelProtocolNo.CalcValue = labelProtocolNo.Value;
                    PROTOCOLNO.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.ProtocolNo) : "");
                    labelDate.CalcValue = labelDate.Value;
                    DATE.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.ReportDate) : "");
                    labelVitrum.CalcValue = labelVitrum.Value;
                    labelFar.CalcValue = labelFar.Value;
                    labelNear.CalcValue = labelNear.Value;
                    labelPerminent.CalcValue = labelPerminent.Value;
                    labelRight.CalcValue = labelRight.Value;
                    labelLeft.CalcValue = labelLeft.Value;
                    labelSphRight.CalcValue = labelSphRight.Value;
                    labelCylRight.CalcValue = labelCylRight.Value;
                    labelAxRight1.CalcValue = labelAxRight1.Value;
                    labelPrisRight.CalcValue = labelPrisRight.Value;
                    labelBasisRight.CalcValue = labelBasisRight.Value;
                    labelSphLeft.CalcValue = labelSphLeft.Value;
                    labelCylLeft.CalcValue = labelCylLeft.Value;
                    labelAxLeft.CalcValue = labelAxLeft.Value;
                    labelPrisLeft.CalcValue = labelPrisLeft.Value;
                    labelBasisLeft.CalcValue = labelBasisLeft.Value;
                    labelColorAndType.CalcValue = labelColorAndType.Value;
                    labelPupillierDistance.CalcValue = labelPupillierDistance.Value;
                    labelBorder.CalcValue = labelBorder.Value;
                    SPHRIGHTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.SphRightFar) : "");
                    CYLRIGHTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.CylRightFar) : "");
                    AXRIGHTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.AxRightFar) : "");
                    PRISRIGHTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PrisRightFar) : "");
                    BASISRIGHTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BasisRightFar) : "");
                    SPHLEFTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.SphLeftFar) : "");
                    CYLLEFTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.CylLeftFar) : "");
                    AXLEFTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.AxLeftFar) : "");
                    PRISLEFTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PrisLeftFar) : "");
                    BASISLEFTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BasisLeftFar) : "");
                    SPHRIGHTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.SphRightNear) : "");
                    CYLRIGHTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.CylRightNear) : "");
                    AXRIGHTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.AxRightNear) : "");
                    PRISRIGHTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PrisRightNear) : "");
                    BASISRIGHTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BasisRightNear) : "");
                    SPHLEFTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.SphLeftNear) : "");
                    CYLLEFTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.CylLeftNear) : "");
                    AXLEFTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.AxLeftNear) : "");
                    PRISLEFTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PrisLeftNear) : "");
                    BASISLEFTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BasisLeftNear) : "");
                    SPHRIGHTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.SphRightPerminent) : "");
                    CYLRIGHTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.CylRightPerminent) : "");
                    AXRIGHTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.AxRightPerminent) : "");
                    PRISRIGHTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PrisRightPerminent) : "");
                    BASISRIGHTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BasisRightPerminent) : "");
                    SPHLEFTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.SphLeftPerminent) : "");
                    CYLLEFTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.CylLeftPerminent) : "");
                    AXLEFTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.AxLeftPerminent) : "");
                    PRISLEFTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PrisLeftPerminent) : "");
                    BASISLEFTPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.BasisLeftPerminent) : "");
                    COLORFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorAndTypeFar) : "");
                    COLORFAR.PostFieldValueCalculation();
                    COLORNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorAndTypeNear) : "");
                    COLORNEAR.PostFieldValueCalculation();
                    DISTANCEFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PupillerDistanceFar) : "");
                    DISTANCENEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PupillerDistanceNear) : "");
                    DISTANCEPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.PupillerDistancePerminent) : "");
                    BORDERFAR.CalcValue = @"";
                    BORDERNEAR.CalcValue = @"";
                    BORDERPERMINENT.CalcValue = @"";
                    labelRightNum11.CalcValue = labelRightNum11.Value;
                    labelRightNum13.CalcValue = labelRightNum13.Value;
                    labelRightNum12.CalcValue = labelRightNum12.Value;
                    labelRightNum1.CalcValue = labelRightNum1.Value;
                    labelLeftNum1.CalcValue = labelLeftNum1.Value;
                    labelLeftNum3.CalcValue = labelLeftNum3.Value;
                    labelLeftNum2.CalcValue = labelLeftNum2.Value;
                    labelLeftNum.CalcValue = labelLeftNum.Value;
                    NewField11.CalcValue = NewField11.Value;
                    SECDIAGNOSIS.CalcValue = @"";
                    GLASSRIGHTTYPEFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassRightTypeFar) : "");
                    GLASSRIGHTTYPEFAR.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    GLASSCOLORRIGHTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorRightFar) : "");
                    GLASSCOLORRIGHTFAR.PostFieldValueCalculation();
                    RENKVECINSUZAKSAG.CalcValue = MyParentReport.MAIN.COLORFAR.CalcValue + @" " + MyParentReport.MAIN.GLASSRIGHTTYPEFAR.CalcValue + @"/" + MyParentReport.MAIN.GLASSCOLORRIGHTFAR.CalcValue;
                    GLASSRIGHTTYPENEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassRightTypeNear) : "");
                    GLASSRIGHTTYPENEAR.PostFieldValueCalculation();
                    GLASSLEFTTYPEFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassLeftTypeFar) : "");
                    GLASSLEFTTYPEFAR.PostFieldValueCalculation();
                    GLASSLEFTTYPENEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassLeftTypeNear) : "");
                    GLASSLEFTTYPENEAR.PostFieldValueCalculation();
                    GLASSCOLORRIGHTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorRightNear) : "");
                    GLASSCOLORRIGHTNEAR.PostFieldValueCalculation();
                    RENKVECINSYAKINSAG.CalcValue = MyParentReport.MAIN.COLORNEAR.CalcValue + @" " + MyParentReport.MAIN.GLASSRIGHTTYPENEAR.CalcValue + @"/" + MyParentReport.MAIN.GLASSCOLORRIGHTNEAR.CalcValue;
                    COLORPERMINENT.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorAndTypePerminent) : "");
                    COLORPERMINENT.PostFieldValueCalculation();
                    NewField1.CalcValue = MyParentReport.MAIN.COLORPERMINENT.CalcValue;
                    NewField12.CalcValue = NewField12.Value;
                    GLASSCOLORLEFTFAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorLeftFar) : "");
                    GLASSCOLORLEFTFAR.PostFieldValueCalculation();
                    RENKVECINSUZAKSOL.CalcValue = MyParentReport.MAIN.COLORFAR.CalcValue + @" {" + MyParentReport.MAIN.GLASSLEFTTYPEFAR.CalcValue + @"/" + MyParentReport.MAIN.GLASSCOLORLEFTFAR.CalcValue;
                    GLASSCOLORLEFTNEAR.CalcValue = (dataset_GetGlassesReport != null ? Globals.ToStringCore(dataset_GetGlassesReport.GlassColorLeftNear) : "");
                    GLASSCOLORLEFTNEAR.PostFieldValueCalculation();
                    RENKVECINSYAKINSAG1.CalcValue = MyParentReport.MAIN.COLORNEAR.CalcValue + @" " + MyParentReport.MAIN.GLASSLEFTTYPENEAR.CalcValue + @"/" + MyParentReport.MAIN.GLASSCOLORLEFTNEAR.CalcValue;
                    NewField3.CalcValue = MyParentReport.MAIN.COLORPERMINENT.CalcValue;
                    return new TTReportObject[] { labelPatientSection,labelPatientNameSurname,labelPatientFatherName,labelPatientCityOfBirth,labelPatientRelationship,labelPatientTreatmentClinic,PATIENTNAME,FATHERNAME,DYER,DTARIH,BIRTHINFO,RELATIONSHIP,MASTERRESOURCE,labelProtocolNo,PROTOCOLNO,labelDate,DATE,labelVitrum,labelFar,labelNear,labelPerminent,labelRight,labelLeft,labelSphRight,labelCylRight,labelAxRight1,labelPrisRight,labelBasisRight,labelSphLeft,labelCylLeft,labelAxLeft,labelPrisLeft,labelBasisLeft,labelColorAndType,labelPupillierDistance,labelBorder,SPHRIGHTFAR,CYLRIGHTFAR,AXRIGHTFAR,PRISRIGHTFAR,BASISRIGHTFAR,SPHLEFTFAR,CYLLEFTFAR,AXLEFTFAR,PRISLEFTFAR,BASISLEFTFAR,SPHRIGHTNEAR,CYLRIGHTNEAR,AXRIGHTNEAR,PRISRIGHTNEAR,BASISRIGHTNEAR,SPHLEFTNEAR,CYLLEFTNEAR,AXLEFTNEAR,PRISLEFTNEAR,BASISLEFTNEAR,SPHRIGHTPERMINENT,CYLRIGHTPERMINENT,AXRIGHTPERMINENT,PRISRIGHTPERMINENT,BASISRIGHTPERMINENT,SPHLEFTPERMINENT,CYLLEFTPERMINENT,AXLEFTPERMINENT,PRISLEFTPERMINENT,BASISLEFTPERMINENT,COLORFAR,COLORNEAR,DISTANCEFAR,DISTANCENEAR,DISTANCEPERMINENT,BORDERFAR,BORDERNEAR,BORDERPERMINENT,labelRightNum11,labelRightNum13,labelRightNum12,labelRightNum1,labelLeftNum1,labelLeftNum3,labelLeftNum2,labelLeftNum,NewField11,SECDIAGNOSIS,GLASSRIGHTTYPEFAR,NewField2,GLASSCOLORRIGHTFAR,RENKVECINSUZAKSAG,GLASSRIGHTTYPENEAR,GLASSLEFTTYPEFAR,GLASSLEFTTYPENEAR,GLASSCOLORRIGHTNEAR,RENKVECINSYAKINSAG,COLORPERMINENT,NewField1,NewField12,GLASSCOLORLEFTFAR,RENKVECINSUZAKSOL,GLASSCOLORLEFTNEAR,RENKVECINSYAKINSAG1,NewField3};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((GlassesReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            GlassesReport gr = (GlassesReport)context.GetObject(new Guid(sObjectID),"GlassesReport");
            
            Episode episode = gr.Episode;
            //this.MILITARYUNIT.CalcValue = " " + (episode.MilitaryUnit == null ? (episode.Patient.MilitaryUnit == null ? "" : episode.Patient.MilitaryUnit.Name) : episode.MilitaryUnit.Name);
            
            bool borderFar = false;
            bool borderNear = false;
            bool borderPerminent = false;
            
            if(gr.BorderFar != null)
                borderFar = gr.BorderFar.Value;
            if(gr.BorderNear != null)
                borderNear = gr.BorderNear.Value;
            if(gr.BorderPerminent != null)
                borderPerminent = gr.BorderPerminent.Value;
            
            if(borderFar)
                this.BORDERFAR.CalcValue = "VERİLECEK";
            if(borderNear)
                this.BORDERNEAR.CalcValue = "VERİLECEK";
            if(borderPerminent)
                this.BORDERPERMINENT.CalcValue = "VERİLECEK";
            
            int cnt = 1;
            this.SECDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> secDiagnosis = null;
            secDiagnosis = DiagnosisGrid.GetSecDiagnosisByEpisodeAction(gr.ObjectID.ToString());
            foreach(DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class secDiagnosisGrid in secDiagnosis)
            {
                this.SECDIAGNOSIS.CalcValue += cnt + ". " + secDiagnosisGrid.Code + " " + secDiagnosisGrid.Diagnosename;
                this.SECDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            ((GlassesReportReport)ParentReport).doktorName = gr.ProcedureDoctor.Name;
            ((GlassesReportReport)ParentReport).doktorRank = gr.ProcedureDoctor.MilitaryClass != null ? gr.ProcedureDoctor.MilitaryClass.Name : null;
            ((GlassesReportReport)ParentReport).doktorRank += gr.ProcedureDoctor.Rank != null ? " " + gr.ProcedureDoctor.Rank.Name : null;
            ((GlassesReportReport)ParentReport).doktorRecordID = gr.ProcedureDoctor.EmploymentRecordID;
            foreach(ResourceSpecialityGrid speciality in gr.ProcedureDoctor.ResourceSpecialities)
            {
                if(speciality.MainSpeciality == true)
                    ((GlassesReportReport)ParentReport).doktorSpeciality = speciality.Speciality != null ?  speciality.Speciality.Name : null;
            }
            if(  ((GlassesReportReport)ParentReport).doktorSpeciality == null)
                ((GlassesReportReport)ParentReport).doktorSpeciality =  gr.ProcedureDoctor.ResourceSpecialities.Count > 0 ? gr.ProcedureDoctor.ResourceSpecialities[0].Speciality != null ? gr.ProcedureDoctor.ResourceSpecialities[0].Speciality.Name : null : null;
            ((GlassesReportReport)ParentReport).diplomaRegisterNo = gr.ProcedureDoctor.DiplomaRegisterNo;
            ((GlassesReportReport)ParentReport).diplomaNo = gr.ProcedureDoctor.DiplomaNo;
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

        public GlassesReportReport()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            MAIN = new MAINGroup(MASTER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "GLASSESREPORTREPORT";
            Caption = "Gözlük Reçetesi";
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