
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
    /// Refakatçi Formu
    /// </summary>
    public partial class CompanionInformationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public CompanionInformationReport MyParentReport
            {
                get { return (CompanionInformationReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField1151 { get {return Footer().NewField1151;} }
            public TTReportField NewField1127111111 { get {return Footer().NewField1127111111;} }
            public TTReportField TITLE_RANK_NAME_SURNAME { get {return Footer().TITLE_RANK_NAME_SURNAME;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField DIPLOMAREGISTERNO { get {return Footer().DIPLOMAREGISTERNO;} }
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
                public CompanionInformationReport MyParentReport
                {
                    get { return (CompanionInformationReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public CompanionInformationReport MyParentReport
                {
                    get { return (CompanionInformationReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField1127111111;
                public TTReportField TITLE_RANK_NAME_SURNAME;
                public TTReportField DIPLOMANO;
                public TTReportField NewField1161;
                public TTReportField DIPLOMAREGISTERNO; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 27;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 12, 179, 17, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151.TextFont.Size = 8;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"D.Nu.      :";

                    NewField1127111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 2, 179, 7, false);
                    NewField1127111111.Name = "NewField1127111111";
                    NewField1127111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1127111111.TextFont.Bold = true;
                    NewField1127111111.TextFont.CharSet = 162;
                    NewField1127111111.Value = @"Sorumlu Doktor:";

                    TITLE_RANK_NAME_SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 7, 179, 12, false);
                    TITLE_RANK_NAME_SURNAME.Name = "TITLE_RANK_NAME_SURNAME";
                    TITLE_RANK_NAME_SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE_RANK_NAME_SURNAME.TextFont.Size = 8;
                    TITLE_RANK_NAME_SURNAME.TextFont.CharSet = 162;
                    TITLE_RANK_NAME_SURNAME.Value = @"";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 12, 179, 18, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Size = 8;
                    DIPLOMANO.TextFont.CharSet = 162;
                    DIPLOMANO.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 17, 179, 22, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"D.Tes.Nu.:";

                    DIPLOMAREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 17, 179, 22, false);
                    DIPLOMAREGISTERNO.Name = "DIPLOMAREGISTERNO";
                    DIPLOMAREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMAREGISTERNO.TextFont.Size = 8;
                    DIPLOMAREGISTERNO.TextFont.CharSet = 162;
                    DIPLOMAREGISTERNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1127111111.CalcValue = NewField1127111111.Value;
                    TITLE_RANK_NAME_SURNAME.CalcValue = @"";
                    DIPLOMANO.CalcValue = @"";
                    NewField1161.CalcValue = NewField1161.Value;
                    DIPLOMAREGISTERNO.CalcValue = @"";
                    return new TTReportObject[] { NewField1151,NewField1127111111,TITLE_RANK_NAME_SURNAME,DIPLOMANO,NewField1161,DIPLOMAREGISTERNO};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string objectID = ((CompanionInformationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    InPatientPhysicianApplication inPatientPhysicianApplication = (InPatientPhysicianApplication)context.GetObject(new Guid(objectID), "InPatientPhysicianApplication");

                    if(inPatientPhysicianApplication.ProcedureDoctor != null)
            {
                TITLE_RANK_NAME_SURNAME.CalcValue = "";
                if(inPatientPhysicianApplication.ProcedureDoctor.Title != null)
                    TITLE_RANK_NAME_SURNAME.CalcValue += (inPatientPhysicianApplication.ProcedureDoctor.Title).ToString()+" ";
                if(inPatientPhysicianApplication.ProcedureDoctor.Rank != null)
                    TITLE_RANK_NAME_SURNAME.CalcValue += (inPatientPhysicianApplication.ProcedureDoctor.Rank).ToString()+" ";
                if(inPatientPhysicianApplication.ProcedureDoctor.Name != null)
                    TITLE_RANK_NAME_SURNAME.CalcValue += (inPatientPhysicianApplication.ProcedureDoctor.Name).ToString()+" ";
            
                if(inPatientPhysicianApplication.ProcedureDoctor.DiplomaNo != null)
                    DIPLOMANO.CalcValue = (inPatientPhysicianApplication.ProcedureDoctor.DiplomaNo).ToString();
                if(inPatientPhysicianApplication.ProcedureDoctor.DiplomaRegisterNo != null)
                    DIPLOMAREGISTERNO.CalcValue = (inPatientPhysicianApplication.ProcedureDoctor.DiplomaRegisterNo).ToString();
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public CompanionInformationReport MyParentReport
            {
                get { return (CompanionInformationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField DATE_CONST12 { get {return Body().DATE_CONST12;} }
            public TTReportField DATE_CONST121 { get {return Body().DATE_CONST121;} }
            public TTReportField DATE_CONST1221 { get {return Body().DATE_CONST1221;} }
            public TTReportField DATE_CONST1222 { get {return Body().DATE_CONST1222;} }
            public TTReportField DATE_CONST1223 { get {return Body().DATE_CONST1223;} }
            public TTReportField DATE_CONST1121 { get {return Body().DATE_CONST1121;} }
            public TTReportField DATE_CONST13221 { get {return Body().DATE_CONST13221;} }
            public TTReportField DATE_CONST11211 { get {return Body().DATE_CONST11211;} }
            public TTReportField DATE_CONST13222 { get {return Body().DATE_CONST13222;} }
            public TTReportField DATE_CONST11212 { get {return Body().DATE_CONST11212;} }
            public TTReportField DATE_CONST13223 { get {return Body().DATE_CONST13223;} }
            public TTReportField DATE_CONST11213 { get {return Body().DATE_CONST11213;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField HASTATCNU { get {return Body().HASTATCNU;} }
            public TTReportField INPATIENTCLINIC { get {return Body().INPATIENTCLINIC;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField COMPANIONDATECOUNT { get {return Body().COMPANIONDATECOUNT;} }
            public TTReportField QUARANTINEINPATIENTDATE { get {return Body().QUARANTINEINPATIENTDATE;} }
            public TTReportField QUARANTINEDISCHARGEDATE { get {return Body().QUARANTINEDISCHARGEDATE;} }
            public TTReportField FKIMLIKNO { get {return Body().FKIMLIKNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField MEDICALREASON { get {return Body().MEDICALREASON;} }
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
                public CompanionInformationReport MyParentReport
                {
                    get { return (CompanionInformationReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField DATE_CONST12;
                public TTReportField DATE_CONST121;
                public TTReportField DATE_CONST1221;
                public TTReportField DATE_CONST1222;
                public TTReportField DATE_CONST1223;
                public TTReportField DATE_CONST1121;
                public TTReportField DATE_CONST13221;
                public TTReportField DATE_CONST11211;
                public TTReportField DATE_CONST13222;
                public TTReportField DATE_CONST11212;
                public TTReportField DATE_CONST13223;
                public TTReportField DATE_CONST11213;
                public TTReportField PATIENTNAME;
                public TTReportField HASTATCNU;
                public TTReportField INPATIENTCLINIC;
                public TTReportField COUNT;
                public TTReportField COMPANIONDATECOUNT;
                public TTReportField QUARANTINEINPATIENTDATE;
                public TTReportField QUARANTINEDISCHARGEDATE;
                public TTReportField FKIMLIKNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField MEDICALREASON; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 108;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 7, 157, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"REFAKATÇİ FORMU";

                    DATE_CONST12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 24, 77, 29, false);
                    DATE_CONST12.Name = "DATE_CONST12";
                    DATE_CONST12.TextFont.Name = "Arial";
                    DATE_CONST12.TextFont.Bold = true;
                    DATE_CONST12.TextFont.CharSet = 162;
                    DATE_CONST12.Value = @"Hastanın Adı Soyadı";

                    DATE_CONST121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 39, 77, 44, false);
                    DATE_CONST121.Name = "DATE_CONST121";
                    DATE_CONST121.TextFont.Name = "Arial";
                    DATE_CONST121.TextFont.Bold = true;
                    DATE_CONST121.TextFont.CharSet = 162;
                    DATE_CONST121.Value = @"Hastanın TC Kimlik Numarası";

                    DATE_CONST1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 24, 79, 29, false);
                    DATE_CONST1221.Name = "DATE_CONST1221";
                    DATE_CONST1221.TextFont.Name = "Arial";
                    DATE_CONST1221.TextFont.Bold = true;
                    DATE_CONST1221.TextFont.CharSet = 162;
                    DATE_CONST1221.Value = @":";

                    DATE_CONST1222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 39, 79, 44, false);
                    DATE_CONST1222.Name = "DATE_CONST1222";
                    DATE_CONST1222.TextFont.Name = "Arial";
                    DATE_CONST1222.TextFont.Bold = true;
                    DATE_CONST1222.TextFont.CharSet = 162;
                    DATE_CONST1222.Value = @":";

                    DATE_CONST1223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 53, 79, 58, false);
                    DATE_CONST1223.Name = "DATE_CONST1223";
                    DATE_CONST1223.TextFont.Name = "Arial";
                    DATE_CONST1223.TextFont.Bold = true;
                    DATE_CONST1223.TextFont.CharSet = 162;
                    DATE_CONST1223.Value = @":";

                    DATE_CONST1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 53, 77, 58, false);
                    DATE_CONST1121.Name = "DATE_CONST1121";
                    DATE_CONST1121.TextFont.Name = "Arial";
                    DATE_CONST1121.TextFont.Bold = true;
                    DATE_CONST1121.TextFont.CharSet = 162;
                    DATE_CONST1121.Value = @"Hastanın Yattığı Klinik";

                    DATE_CONST13221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 67, 79, 72, false);
                    DATE_CONST13221.Name = "DATE_CONST13221";
                    DATE_CONST13221.TextFont.Name = "Arial";
                    DATE_CONST13221.TextFont.Bold = true;
                    DATE_CONST13221.TextFont.CharSet = 162;
                    DATE_CONST13221.Value = @":";

                    DATE_CONST11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 67, 77, 72, false);
                    DATE_CONST11211.Name = "DATE_CONST11211";
                    DATE_CONST11211.TextFont.Name = "Arial";
                    DATE_CONST11211.TextFont.Bold = true;
                    DATE_CONST11211.TextFont.CharSet = 162;
                    DATE_CONST11211.Value = @"Hastanın Yattığı Süre";

                    DATE_CONST13222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 80, 79, 85, false);
                    DATE_CONST13222.Name = "DATE_CONST13222";
                    DATE_CONST13222.TextFont.Name = "Arial";
                    DATE_CONST13222.TextFont.Bold = true;
                    DATE_CONST13222.TextFont.CharSet = 162;
                    DATE_CONST13222.Value = @":";

                    DATE_CONST11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 80, 77, 85, false);
                    DATE_CONST11212.Name = "DATE_CONST11212";
                    DATE_CONST11212.TextFont.Name = "Arial";
                    DATE_CONST11212.TextFont.Bold = true;
                    DATE_CONST11212.TextFont.CharSet = 162;
                    DATE_CONST11212.Value = @"Refakatçinin Kaldığı Gün Sayısı";

                    DATE_CONST13223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 95, 134, 100, false);
                    DATE_CONST13223.Name = "DATE_CONST13223";
                    DATE_CONST13223.TextFont.Name = "Arial";
                    DATE_CONST13223.TextFont.Bold = true;
                    DATE_CONST13223.TextFont.CharSet = 162;
                    DATE_CONST13223.Value = @":";

                    DATE_CONST11213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 95, 132, 100, false);
                    DATE_CONST11213.Name = "DATE_CONST11213";
                    DATE_CONST11213.TextFont.Name = "Arial";
                    DATE_CONST11213.TextFont.Bold = true;
                    DATE_CONST11213.TextFont.CharSet = 162;
                    DATE_CONST11213.Value = @"Refakatçinin Kalmasına Gerek Görülen Tıbbi Endikasyon Sebebi";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 24, 179, 29, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"";

                    HASTATCNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 39, 179, 44, false);
                    HASTATCNU.Name = "HASTATCNU";
                    HASTATCNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNU.MultiLine = EvetHayirEnum.ehEvet;
                    HASTATCNU.TextFont.CharSet = 162;
                    HASTATCNU.Value = @"";

                    INPATIENTCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 53, 179, 62, false);
                    INPATIENTCLINIC.Name = "INPATIENTCLINIC";
                    INPATIENTCLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    INPATIENTCLINIC.MultiLine = EvetHayirEnum.ehEvet;
                    INPATIENTCLINIC.NoClip = EvetHayirEnum.ehEvet;
                    INPATIENTCLINIC.WordBreak = EvetHayirEnum.ehEvet;
                    INPATIENTCLINIC.ExpandTabs = EvetHayirEnum.ehEvet;
                    INPATIENTCLINIC.TextFont.CharSet = 162;
                    INPATIENTCLINIC.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 67, 179, 72, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.NoClip = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"";

                    COMPANIONDATECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 80, 179, 85, false);
                    COMPANIONDATECOUNT.Name = "COMPANIONDATECOUNT";
                    COMPANIONDATECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONDATECOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COMPANIONDATECOUNT.NoClip = EvetHayirEnum.ehEvet;
                    COMPANIONDATECOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COMPANIONDATECOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COMPANIONDATECOUNT.TextFont.CharSet = 162;
                    COMPANIONDATECOUNT.Value = @"";

                    QUARANTINEINPATIENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 44, 303, 50, false);
                    QUARANTINEINPATIENTDATE.Name = "QUARANTINEINPATIENTDATE";
                    QUARANTINEINPATIENTDATE.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEINPATIENTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    QUARANTINEINPATIENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEINPATIENTDATE.TextFormat = @"Short Date";
                    QUARANTINEINPATIENTDATE.TextFont.Size = 9;
                    QUARANTINEINPATIENTDATE.TextFont.CharSet = 162;
                    QUARANTINEINPATIENTDATE.Value = @"";

                    QUARANTINEDISCHARGEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 58, 292, 64, false);
                    QUARANTINEDISCHARGEDATE.Name = "QUARANTINEDISCHARGEDATE";
                    QUARANTINEDISCHARGEDATE.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEDISCHARGEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    QUARANTINEDISCHARGEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEDISCHARGEDATE.TextFormat = @"Short Date";
                    QUARANTINEDISCHARGEDATE.TextFont.Size = 9;
                    QUARANTINEDISCHARGEDATE.TextFont.CharSet = 162;
                    QUARANTINEDISCHARGEDATE.Value = @"";

                    FKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 71, 262, 76, false);
                    FKIMLIKNO.Name = "FKIMLIKNO";
                    FKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    FKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FKIMLIKNO.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 81, 262, 86, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"";

                    MEDICALREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 101, 179, 106, false);
                    MEDICALREASON.Name = "MEDICALREASON";
                    MEDICALREASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDICALREASON.MultiLine = EvetHayirEnum.ehEvet;
                    MEDICALREASON.NoClip = EvetHayirEnum.ehEvet;
                    MEDICALREASON.WordBreak = EvetHayirEnum.ehEvet;
                    MEDICALREASON.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEDICALREASON.TextFont.CharSet = 162;
                    MEDICALREASON.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    DATE_CONST12.CalcValue = DATE_CONST12.Value;
                    DATE_CONST121.CalcValue = DATE_CONST121.Value;
                    DATE_CONST1221.CalcValue = DATE_CONST1221.Value;
                    DATE_CONST1222.CalcValue = DATE_CONST1222.Value;
                    DATE_CONST1223.CalcValue = DATE_CONST1223.Value;
                    DATE_CONST1121.CalcValue = DATE_CONST1121.Value;
                    DATE_CONST13221.CalcValue = DATE_CONST13221.Value;
                    DATE_CONST11211.CalcValue = DATE_CONST11211.Value;
                    DATE_CONST13222.CalcValue = DATE_CONST13222.Value;
                    DATE_CONST11212.CalcValue = DATE_CONST11212.Value;
                    DATE_CONST13223.CalcValue = DATE_CONST13223.Value;
                    DATE_CONST11213.CalcValue = DATE_CONST11213.Value;
                    PATIENTNAME.CalcValue = @"";
                    HASTATCNU.CalcValue = @"";
                    INPATIENTCLINIC.CalcValue = @"";
                    COUNT.CalcValue = @"";
                    COMPANIONDATECOUNT.CalcValue = @"";
                    QUARANTINEINPATIENTDATE.CalcValue = @"";
                    QUARANTINEDISCHARGEDATE.CalcValue = @"";
                    FKIMLIKNO.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = @"";
                    MEDICALREASON.CalcValue = @"";
                    return new TTReportObject[] { NewField11,DATE_CONST12,DATE_CONST121,DATE_CONST1221,DATE_CONST1222,DATE_CONST1223,DATE_CONST1121,DATE_CONST13221,DATE_CONST11211,DATE_CONST13222,DATE_CONST11212,DATE_CONST13223,DATE_CONST11213,PATIENTNAME,HASTATCNU,INPATIENTCLINIC,COUNT,COMPANIONDATECOUNT,QUARANTINEINPATIENTDATE,QUARANTINEDISCHARGEDATE,FKIMLIKNO,TCKIMLIKNO,MEDICALREASON};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            Guid objectID =  new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString());
            InPatientPhysicianApplication inPatientPhysicianApplication = (InPatientPhysicianApplication)context.GetObject(objectID,typeof(InPatientPhysicianApplication));
            Episode episode = inPatientPhysicianApplication.Episode;
            Guid EPISODE = new Guid();
            EPISODE = inPatientPhysicianApplication.Episode.ObjectID;
            string patientNameSurname = String.Empty;
            if(episode.Patient.Name != null)
                patientNameSurname += episode.Patient.Name.ToString()+" ";
            if(episode.Patient.Surname != null)
                patientNameSurname += episode.Patient.Surname.ToString();
            PATIENTNAME.CalcValue = patientNameSurname;
            
            if(episode.Patient.ForeignUniqueRefNo != null)
                HASTATCNU.CalcValue = episode.Patient.ForeignUniqueRefNo.ToString();
            else if(episode.Patient.UniqueRefNo != null)
                HASTATCNU.CalcValue = episode.Patient.UniqueRefNo.ToString();
            if(episode.GetInPatientClinic() != null)
                INPATIENTCLINIC.CalcValue = (episode.GetInPatientClinic().Name).ToString();

            
            // XXXXXX 4
            // count += idi count = yapıldı
            long? count=0;
            //count += TTObjectClasses.Common.DateDiff(TTObjectClasses.Common.DateIntervalEnum.Day, Convert.ToDateTime(episode.QuarantineDischargeDate), Convert.ToDateTime(episode.QuarantineInPatientDate));
           // MT 23.9.2013 Bugünün tarihi sabit değil raporun alınduğu güne göre değişiyor. Bunun yerine hastanın taburcu olduğu tarih QuarantineDischargeDate kullanılmalı. Ama hasta buaşamada
           // taburcu edilmemiş oluyor. Bu tarih null geliyor. Hasta taburcu tarihi null değilse bunu alması null ise günün tarihini alması sağlandı (SON KARAR)
           if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
          {
                        InpatientAdmission inpAddmission = (InpatientAdmission)inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission;
                        if (inpAddmission.HospitalDischargeDate != null)
                            count = TTObjectClasses.Common.DateDiff(TTObjectClasses.Common.DateIntervalEnum.Day, Convert.ToDateTime(inpAddmission.HospitalDischargeDate.Value.Date), Convert.ToDateTime(inpAddmission.HospitalInPatientDate.Value.Date));
                        else
                            count = TTObjectClasses.Common.DateDiff(TTObjectClasses.Common.DateIntervalEnum.Day, Convert.ToDateTime(TTObjectClasses.Common.RecTime().Date), Convert.ToDateTime(inpAddmission.HospitalInPatientDate.Value.Date));
           }
            
            if(count==0)
                COUNT.CalcValue =" Günübirlik";
            else
                COUNT.CalcValue =" " + count.ToString() + " gün.";


            IBindingList companionApp = CompanionApplication.GetCompanionApplicationByEpisode(context, EPISODE.ToString());
            int stayingDayCount = 0;
            string medicalReasonForCompanion = string.Empty;
            foreach(CompanionApplication.GetCompanionApplicationByEpisode_Class comApp in companionApp)
            {
                // MT 23.9.2013 İptal edilen refakatçi gün sayısını hesaba katmaması sağlandı. Statestatus cancelled (= 4) olmadığı durumlarda
                // refakatçi gün sayısını arttırması sağlandı.
                if(comApp.StayingDateCount != null && comApp.Statestatus.ToString() != "4")
                    stayingDayCount += comApp.StayingDateCount.Value;
                
                if(comApp.MedicalReasonForCompanion != null && string.IsNullOrEmpty(medicalReasonForCompanion))
                {
                    medicalReasonForCompanion = comApp.MedicalReasonForCompanion.ToString();
                    MEDICALREASON.CalcValue = medicalReasonForCompanion;
                }
            }
            COMPANIONDATECOUNT.CalcValue = stayingDayCount.ToString();
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

        public CompanionInformationReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "ID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COMPANIONINFORMATIONREPORT";
            Caption = "Refakatçi Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 10;
            UserMarginTop = 10;
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