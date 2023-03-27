
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
    /// Dış Tetkik İstek Formu
    /// </summary>
    public partial class InternalProcedureRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public InternalProcedureRequestReport MyParentReport
            {
                get { return (InternalProcedureRequestReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
            public TTReportField NewField1101 { get {return Footer().NewField1101;} }
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
                list[0] = new TTReportNqlData<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class>("GetInternalProcedureRequestInfo", InternalProcedureRequest.GetInternalProcedureRequestInfo((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InternalProcedureRequestReport MyParentReport
                {
                    get { return (InternalProcedureRequestReport)ParentReport; }
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
                public InternalProcedureRequestReport MyParentReport
                {
                    get { return (InternalProcedureRequestReport)ParentReport; }
                }
                
                public TTReportField ISTEKDR;
                public TTReportField NewField1101; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 32;
                    RepeatCount = 0;
                    
                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 75, 29, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Name = "Arial Narrow";
                    ISTEKDR.TextFont.Size = 9;
                    ISTEKDR.Value = @"";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 82, 7, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.TextFont.Name = "Arial Narrow";
                    NewField1101.TextFont.Size = 9;
                    NewField1101.TextFont.Bold = true;
                    NewField1101.Value = @"İstek Yapan Tabip";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InternalProcedureRequest.GetInternalProcedureRequestInfo_Class dataset_GetInternalProcedureRequestInfo = ParentGroup.rsGroup.GetCurrentRecord<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class>(0);
                    ISTEKDR.CalcValue = @"";
                    NewField1101.CalcValue = NewField1101.Value;
                    return new TTReportObject[] { ISTEKDR,NewField1101};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((InternalProcedureRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalProcedureRequest internalProcedureRequest = (InternalProcedureRequest)objectContext.GetObject(new Guid(objectID),typeof(InternalProcedureRequest).Name);                        
            
            if(internalProcedureRequest.RequestDoctor!=null)
                this.ISTEKDR.CalcValue = internalProcedureRequest.RequestDoctor.SignatureBlock;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class SUBGroup : TTReportGroup
        {
            public InternalProcedureRequestReport MyParentReport
            {
                get { return (InternalProcedureRequestReport)ParentReport; }
            }

            new public SUBGroupHeader Header()
            {
                return (SUBGroupHeader)_header;
            }

            new public SUBGroupFooter Footer()
            {
                return (SUBGroupFooter)_footer;
            }

            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField BİRİMPRTNO { get {return Header().BİRİMPRTNO;} }
            public TTReportField KARANTİNARAPNO { get {return Header().KARANTİNARAPNO;} }
            public TTReportField sag { get {return Header().sag;} }
            public TTReportField HEADER1 { get {return Header().HEADER1;} }
            public TTReportField NOT { get {return Header().NOT;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NUM { get {return Header().NUM;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField QUARANTINEPROTOCOLNO { get {return Header().QUARANTINEPROTOCOLNO;} }
            public TTReportField ACTIONDATE2 { get {return Header().ACTIONDATE2;} }
            public TTReportField date { get {return Header().date;} }
            public TTReportField RUTBE { get {return Header().RUTBE;} }
            public TTReportField SINIF { get {return Header().SINIF;} }
            public TTReportField XXXXXXLIKSUBE1 { get {return Header().XXXXXXLIKSUBE1;} }
            public TTReportField BIRLIK2 { get {return Header().BIRLIK2;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField DAGITIM11 { get {return Header().DAGITIM11;} }
            public TTReportField DAGITIM12 { get {return Header().DAGITIM12;} }
            public TTReportField DAGITIM13 { get {return Header().DAGITIM13;} }
            public TTReportField BIRTHINFO { get {return Header().BIRTHINFO;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1251 { get {return Header().NewField1251;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField NewField1291 { get {return Header().NewField1291;} }
            public TTReportField NewField1301 { get {return Header().NewField1301;} }
            public TTReportField NewField1381 { get {return Header().NewField1381;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportField SINRUT { get {return Header().SINRUT;} }
            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField11921 { get {return Header().NewField11921;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField DIAGNOSE { get {return Header().DIAGNOSE;} }
            public TTReportField OBJID { get {return Header().OBJID;} }
            public TTReportField lblTests1 { get {return Header().lblTests1;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportField lblHIZMETEOZEL { get {return Header().lblHIZMETEOZEL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField ONAY { get {return Header().ONAY;} }
            public TTReportField ONAYUNVAN { get {return Header().ONAYUNVAN;} }
            public TTReportField ONAYUNVAN2 { get {return Header().ONAYUNVAN2;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportField NewField1117111 { get {return Footer().NewField1117111;} }
            public TTReportField PREDIAGNOSE { get {return Footer().PREDIAGNOSE;} }
            public SUBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SUBGroupHeader(this);
                _footer = new SUBGroupFooter(this);

            }

            public partial class SUBGroupHeader : TTReportSection
            {
                public InternalProcedureRequestReport MyParentReport
                {
                    get { return (InternalProcedureRequestReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField BİRİMPRTNO;
                public TTReportField KARANTİNARAPNO;
                public TTReportField sag;
                public TTReportField HEADER1;
                public TTReportField NOT;
                public TTReportField KONU;
                public TTReportField ACTIONID;
                public TTReportShape NewLine12;
                public TTReportField NUM;
                public TTReportField BIRIMADI;
                public TTReportField HASTANO;
                public TTReportField KURUM;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField QUARANTINEPROTOCOLNO;
                public TTReportField ACTIONDATE2;
                public TTReportField date;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField XXXXXXLIKSUBE1;
                public TTReportField BIRLIK2;
                public TTReportField MAKAM;
                public TTReportField ADSOYAD;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField SURNAME;
                public TTReportField NAME;
                public TTReportField DAGITIM11;
                public TTReportField DAGITIM12;
                public TTReportField DAGITIM13;
                public TTReportField BIRTHINFO;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField FATHERNAME;
                public TTReportField NewField1221;
                public TTReportField NewField1241;
                public TTReportField NewField1251;
                public TTReportField NewField1261;
                public TTReportField NewField1291;
                public TTReportField NewField1301;
                public TTReportField NewField1381;
                public TTReportShape NewLine131;
                public TTReportField SINRUT;
                public TTReportField FULLNAME;
                public TTReportField NewField11711;
                public TTReportField NewField11921;
                public TTReportField NewField111711;
                public TTReportField DIAGNOSE;
                public TTReportField OBJID;
                public TTReportField lblTests1;
                public TTReportShape NewLine1121;
                public TTReportField lblHIZMETEOZEL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField BASLIK;
                public TTReportField ONAY;
                public TTReportField ONAYUNVAN;
                public TTReportField ONAYUNVAN2;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField BIRLIK;
                public TTReportField NewField143;
                public TTReportField NewField133; 
                public SUBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 183;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 35, 199, 39, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDATE.Value = @"{#HEADER.ACTIONDATE#}";

                    BİRİMPRTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 11, 241, 15, false);
                    BİRİMPRTNO.Name = "BİRİMPRTNO";
                    BİRİMPRTNO.Visible = EvetHayirEnum.ehHayir;
                    BİRİMPRTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BİRİMPRTNO.Value = @"";

                    KARANTİNARAPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 12, 33, 16, false);
                    KARANTİNARAPNO.Name = "KARANTİNARAPNO";
                    KARANTİNARAPNO.Visible = EvetHayirEnum.ehHayir;
                    KARANTİNARAPNO.Value = @"{%KARANTİNARAPNO%}";

                    sag = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 41, 199, 45, false);
                    sag.Name = "sag";
                    sag.FieldType = ReportFieldTypeEnum.ftVariable;
                    sag.TextFont.Name = "Arial Narrow";
                    sag.Value = @"SAĞ:9042-{%QUARANTINEPROTOCOLNO%}-{%ACTIONDATE2%}/{%BIRIMADI%}-{%ACTIONID%}";

                    HEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 51, 199, 56, false);
                    HEADER1.Name = "HEADER1";
                    HEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HEADER1.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER1.TextFont.Name = "Arial Narrow";
                    HEADER1.TextFont.Bold = true;
                    HEADER1.Value = @"BAŞTABİPLİĞE";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 63, 199, 81, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Name = "Arial Narrow";
                    NOT.Value = @"Aşağıda açık kimliği ve ön tanısı yazılı personele istenen laboratuvar tetkiklerinin yapılarak sonucun bildirilmesini arz/rica ederim.
";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 45, 199, 49, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Arial Narrow";
                    KONU.Value = @"KONU: Tetkik İstek";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 18, 32, 22, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.Value = @"{#HEADER.ID#}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 152, 99, 152, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 17, 226, 21, false);
                    NUM.Name = "NUM";
                    NUM.Visible = EvetHayirEnum.ehHayir;
                    NUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUM.Value = @"";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 9, 33, 13, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.ObjectDefName = "InternalProcedureRequest";
                    BIRIMADI.DataMember = "FROMRESOURCE.NAME";
                    BIRIMADI.TextFont.Name = "Arial";
                    BIRIMADI.Value = @"{@TTOBJECTID@}";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 90, 32, 94, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.Value = @"";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 8, 206, 13, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 13, 206, 18, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 18, 206, 23, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    QUARANTINEPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 22, 39, 26, false);
                    QUARANTINEPROTOCOLNO.Name = "QUARANTINEPROTOCOLNO";
                    QUARANTINEPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEPROTOCOLNO.TextFont.Name = "Arial Narrow";
                    QUARANTINEPROTOCOLNO.TextFont.Size = 9;
                    QUARANTINEPROTOCOLNO.Value = @"{#HEADER.QUARANTINEPROTOCOLNO#}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 57, 120, 62, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.TextFont.Name = "Arial Narrow";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.Value = @"{#HEADER.QUARANTINEINPATIENTDATE#}";

                    date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 84, 42, 89, false);
                    date.Name = "date";
                    date.Visible = EvetHayirEnum.ehHayir;
                    date.FieldType = ReportFieldTypeEnum.ftVariable;
                    date.TextFormat = @"Short Date";
                    date.TextFont.Name = "Arial Narrow";
                    date.TextFont.Size = 9;
                    date.Value = @"{#HEADER.QUARANTINEINPATIENTDATE#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 123, 198, 128, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial Narrow";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.Value = @"";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 118, 199, 123, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Name = "Arial Narrow";
                    SINIF.TextFont.Size = 9;
                    SINIF.Value = @"";

                    XXXXXXLIKSUBE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 128, 200, 132, false);
                    XXXXXXLIKSUBE1.Name = "XXXXXXLIKSUBE1";
                    XXXXXXLIKSUBE1.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXLIKSUBE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE1.TextFont.Name = "Arial Narrow";
                    XXXXXXLIKSUBE1.TextFont.Size = 9;
                    XXXXXXLIKSUBE1.Value = @"";

                    BIRLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 132, 200, 136, false);
                    BIRLIK2.Name = "BIRLIK2";
                    BIRLIK2.Visible = EvetHayirEnum.ehHayir;
                    BIRLIK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK2.TextFont.Name = "Arial Narrow";
                    BIRLIK2.TextFont.Size = 9;
                    BIRLIK2.Value = @"";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 136, 199, 140, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 9;
                    MAKAM.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 114, 205, 118, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.Visible = EvetHayirEnum.ehHayir;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{%NAME%} {%SURNAME%}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 152, 204, 156, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"dd/MM/yyyy";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#HEADER.PATIENTBIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 148, 204, 152, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#HEADER.PATIENTCITYOFBIRTH#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 144, 202, 148, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Arial Narrow";
                    SURNAME.TextFont.Size = 9;
                    SURNAME.Value = @"{#HEADER.PATIENTSURNAME#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 140, 205, 144, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#HEADER.PATIENTNAME#}";

                    DAGITIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 156, 199, 162, false);
                    DAGITIM11.Name = "DAGITIM11";
                    DAGITIM11.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM11.TextFont.Name = "Arial Narrow";
                    DAGITIM11.TextFont.Size = 9;
                    DAGITIM11.Value = @"{%MAKAM%}";

                    DAGITIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 162, 199, 167, false);
                    DAGITIM12.Name = "DAGITIM12";
                    DAGITIM12.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM12.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM12.TextFont.Name = "Arial Narrow";
                    DAGITIM12.TextFont.Size = 9;
                    DAGITIM12.Value = @"";

                    DAGITIM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 167, 199, 172, false);
                    DAGITIM13.Name = "DAGITIM13";
                    DAGITIM13.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM13.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM13.TextFont.Name = "Arial Narrow";
                    DAGITIM13.TextFont.Size = 9;
                    DAGITIM13.Value = @"";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 136, 163, 140, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.TextFont.Name = "Arial Narrow";
                    BIRTHINFO.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 121, 55, 125, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Name = "Arial Narrow";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.Value = @"Sınıf ve Rütbesi";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 136, 55, 140, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.Size = 9;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @"Doğum Yeri ve Tarihi";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 131, 163, 135, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.Value = @"{#HEADER.FATHERNAME#}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 116, 55, 120, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @"Adı Soyadı";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 121, 58, 125, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.Value = @":";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 116, 58, 120, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.TextFont.Name = "Arial Narrow";
                    NewField1251.Value = @":";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 131, 55, 135, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.TextFont.Name = "Arial Narrow";
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.Value = @"Baba Adı";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 136, 58, 140, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.Name = "Arial Narrow";
                    NewField1291.Value = @":";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 131, 58, 135, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.TextFont.Name = "Arial Narrow";
                    NewField1301.Value = @":";

                    NewField1381 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 105, 56, 109, false);
                    NewField1381.Name = "NewField1381";
                    NewField1381.TextFont.Name = "Arial Narrow";
                    NewField1381.TextFont.Bold = true;
                    NewField1381.Value = @"Kimliği";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 110, 103, 110, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 121, 163, 125, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.Value = @"";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 116, 163, 120, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Arial Narrow";
                    FULLNAME.Value = @"{%NAME%} {%SURNAME%}";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 141, 55, 145, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial Narrow";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @"Kabul Sebebi";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 141, 58, 145, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.TextFont.Name = "Arial Narrow";
                    NewField11921.Value = @":";

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 147, 114, 151, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Name = "Arial Narrow";
                    NewField111711.TextFont.Size = 9;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.Value = @"Ön Tanı";

                    DIAGNOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 153, 174, 172, false);
                    DIAGNOSE.Name = "DIAGNOSE";
                    DIAGNOSE.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSE.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSE.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSE.TextFont.Name = "Arial Narrow";
                    DIAGNOSE.Value = @"";

                    OBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 155, 246, 159, false);
                    OBJID.Name = "OBJID";
                    OBJID.Visible = EvetHayirEnum.ehHayir;
                    OBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJID.TextFont.Name = "Arial Narrow";
                    OBJID.TextFont.Size = 9;
                    OBJID.Value = @"{#HEADER.OBJECTID#}";

                    lblTests1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 177, 114, 181, false);
                    lblTests1.Name = "lblTests1";
                    lblTests1.TextFont.Name = "Arial Narrow";
                    lblTests1.TextFont.Size = 9;
                    lblTests1.TextFont.Bold = true;
                    lblTests1.Value = @"İstenen Tetkikler";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 182, 99, 182, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    lblHIZMETEOZEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 35, 9, false);
                    lblHIZMETEOZEL.Name = "lblHIZMETEOZEL";
                    lblHIZMETEOZEL.TextFont.Name = "Arial Narrow";
                    lblHIZMETEOZEL.TextFont.Size = 11;
                    lblHIZMETEOZEL.TextFont.Bold = true;
                    lblHIZMETEOZEL.TextFont.Underline = true;
                    lblHIZMETEOZEL.Value = @"HİZMETE ÖZEL";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 3, 181, 25, false);
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

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 26, 181, 33, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaBottom;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Arial Narrow";
                    BASLIK.TextFont.Size = 15;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"DİĞER XXXXXXLERDEN TETKİK İSTEK RAPORU";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 89, 199, 94, false);
                    ONAY.Name = "ONAY";
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.Value = @"";

                    ONAYUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 94, 199, 99, false);
                    ONAYUNVAN.Name = "ONAYUNVAN";
                    ONAYUNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.NoClip = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.TextFont.Name = "Arial Narrow";
                    ONAYUNVAN.TextFont.Size = 9;
                    ONAYUNVAN.Value = @"";

                    ONAYUNVAN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 99, 199, 104, false);
                    ONAYUNVAN2.Name = "ONAYUNVAN2";
                    ONAYUNVAN2.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.NoClip = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.TextFont.Name = "Arial Narrow";
                    ONAYUNVAN2.TextFont.Size = 9;
                    ONAYUNVAN2.Value = @"";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 111, 163, 115, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 111, 55, 115, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 111, 58, 115, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 105, 59, 109, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @":";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 126, 163, 130, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 126, 55, 130, false);
                    NewField143.Name = "NewField143";
                    NewField143.TextFont.Name = "Arial Narrow";
                    NewField143.TextFont.Size = 9;
                    NewField143.TextFont.Bold = true;
                    NewField143.Value = @"Birliği";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 126, 58, 130, false);
                    NewField133.Name = "NewField133";
                    NewField133.TextFont.Name = "Arial Narrow";
                    NewField133.TextFont.Size = 9;
                    NewField133.TextFont.Bold = true;
                    NewField133.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InternalProcedureRequest.GetInternalProcedureRequestInfo_Class dataset_GetInternalProcedureRequestInfo = MyParentReport.HEADER.rsGroup.GetCurrentRecord<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.ActionDate) : "");
                    BİRİMPRTNO.CalcValue = @"";
                    KARANTİNARAPNO.CalcValue = KARANTİNARAPNO.Value;
                    QUARANTINEPROTOCOLNO.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.QuarantineProtocolNo) : "");
                    ACTIONDATE2.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.Quarantineinpatientdate) : "");
                    BIRIMADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BIRIMADI.PostFieldValueCalculation();
                    ACTIONID.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.ID) : "");
                    sag.CalcValue = @"SAĞ:9042-" + MyParentReport.SUB.QUARANTINEPROTOCOLNO.CalcValue + @"-" + MyParentReport.SUB.ACTIONDATE2.FormattedValue + @"/" + MyParentReport.SUB.BIRIMADI.CalcValue + @"-" + MyParentReport.SUB.ACTIONID.CalcValue;
                    HEADER1.CalcValue = HEADER1.Value;
                    NOT.CalcValue = @"Aşağıda açık kimliği ve ön tanısı yazılı personele istenen laboratuvar tetkiklerinin yapılarak sonucun bildirilmesini arz/rica ederim.
";
                    KONU.CalcValue = @"KONU: Tetkik İstek";
                    NUM.CalcValue = @"";
                    HASTANO.CalcValue = HASTANO.Value;
                    date.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.Quarantineinpatientdate) : "");
                    RUTBE.CalcValue = @"";
                    SINIF.CalcValue = @"";
                    XXXXXXLIKSUBE1.CalcValue = @"";
                    BIRLIK2.CalcValue = @"";
                    MAKAM.CalcValue = @"";
                    NAME.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.Patientname) : "");
                    SURNAME.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.Patientsurname) : "");
                    ADSOYAD.CalcValue = MyParentReport.SUB.NAME.CalcValue + @" " + MyParentReport.SUB.SURNAME.CalcValue;
                    DTARIH.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.Patientbirthdate) : "");
                    DYER.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.Patientcityofbirth) : "");
                    DAGITIM11.CalcValue = MyParentReport.SUB.MAKAM.CalcValue;
                    DAGITIM12.CalcValue = @"";
                    DAGITIM13.CalcValue = @"";
                    BIRTHINFO.CalcValue = MyParentReport.SUB.DYER.CalcValue + @" / " + MyParentReport.SUB.DTARIH.FormattedValue;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    FATHERNAME.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.FatherName) : "");
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField1301.CalcValue = NewField1301.Value;
                    NewField1381.CalcValue = NewField1381.Value;
                    SINRUT.CalcValue = @"";
                    FULLNAME.CalcValue = MyParentReport.SUB.NAME.CalcValue + @" " + MyParentReport.SUB.SURNAME.CalcValue;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField11921.CalcValue = NewField11921.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    DIAGNOSE.CalcValue = DIAGNOSE.Value;
                    OBJID.CalcValue = (dataset_GetInternalProcedureRequestInfo != null ? Globals.ToStringCore(dataset_GetInternalProcedureRequestInfo.ObjectID) : "");
                    lblTests1.CalcValue = lblTests1.Value;
                    lblHIZMETEOZEL.CalcValue = lblHIZMETEOZEL.Value;
                    BASLIK.CalcValue = BASLIK.Value;
                    ONAY.CalcValue = ONAY.Value;
                    ONAYUNVAN.CalcValue = ONAYUNVAN.Value;
                    ONAYUNVAN2.CalcValue = ONAYUNVAN2.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    BIRLIK.CalcValue = @"";
                    NewField143.CalcValue = NewField143.Value;
                    NewField133.CalcValue = NewField133.Value;
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { ACTIONDATE,BİRİMPRTNO,KARANTİNARAPNO,QUARANTINEPROTOCOLNO,ACTIONDATE2,BIRIMADI,ACTIONID,sag,HEADER1,NOT,KONU,NUM,HASTANO,date,RUTBE,SINIF,XXXXXXLIKSUBE1,BIRLIK2,MAKAM,NAME,SURNAME,ADSOYAD,DTARIH,DYER,DAGITIM11,DAGITIM12,DAGITIM13,BIRTHINFO,NewField1161,NewField1171,FATHERNAME,NewField1221,NewField1241,NewField1251,NewField1261,NewField1291,NewField1301,NewField1381,SINRUT,FULLNAME,NewField11711,NewField11921,NewField111711,DIAGNOSE,OBJID,lblTests1,lblHIZMETEOZEL,BASLIK,ONAY,ONAYUNVAN,ONAYUNVAN2,UNIQUEREFNO,LBLUNIQUEREFNO,NewField1131,NewField1141,BIRLIK,NewField143,NewField133,KURUM,SITENAME,SITECITY,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region SUB HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((InternalProcedureRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalProcedureRequest internalProcedureRequest = (InternalProcedureRequest)objectContext.GetObject(new Guid(objectID),typeof(InternalProcedureRequest).Name);
            
            if (internalProcedureRequest.Episode.Patient.Foreign == true)
                this.HASTANO.CalcValue = internalProcedureRequest.Episode.Patient.ForeignUniqueRefNo.ToString();
            else
                this.HASTANO.CalcValue = internalProcedureRequest.Episode.Patient.UniqueRefNo.ToString();
            
            foreach (DiagnosisGrid pdG in internalProcedureRequest.Episode.Diagnosis)
            {
                if(pdG.DiagnosisType==DiagnosisTypeEnum.Primer)
                {
                    if(!String.IsNullOrEmpty(this.DIAGNOSE.CalcValue))
                        this.DIAGNOSE.CalcValue += "   -   ";
                    if(pdG.Diagnose!=null)
                        this.DIAGNOSE.CalcValue += pdG.Diagnose.Code + " " + pdG.Diagnose.Name;
                }
            }
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION","HEADDOCTOR") == "IITABIP")
            {
                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIP","").ToString();
                this.ONAYUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIPUNVANI","").ToString();
                this.ONAYUNVAN2.CalcValue = "II.Tabip";
                
            }
            else
            {
                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","").ToString();
                this.ONAYUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL","").ToString();
                this.ONAYUNVAN2.CalcValue = "Baştabip";
            }
            
            foreach(SubActionProcedure subProcedure in internalProcedureRequest.SubactionProcedures)
            {
                InternalSubActionProcedure internalSubActionProcedure = subProcedure as InternalSubActionProcedure;
                if(internalSubActionProcedure != null)
                    this.HEADER1.CalcValue = internalProcedureRequest.OtherHospital.Name;
            }
            
//            this.SINRUT.CalcValue = internalProcedureRequest.Episode.ClassRankInfoForReport;
            
            if (internalProcedureRequest.Episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = " " + internalProcedureRequest.Episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hastalar)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = " " + internalProcedureRequest.Episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
            
            //            this.BIRLIK.CalcValue = " " + (internalProcedureRequest.Episode.MilitaryUnit == null ? (internalProcedureRequest.Episode.Patient.MilitaryUnit == null ? "" : internalProcedureRequest.Episode.Patient.MilitaryUnit.Name) : internalProcedureRequest.Episode.MilitaryUnit.Name);
#endregion SUB HEADER_Script
                }
            }
            public partial class SUBGroupFooter : TTReportSection
            {
                public InternalProcedureRequestReport MyParentReport
                {
                    get { return (InternalProcedureRequestReport)ParentReport; }
                }
                
                public TTReportShape NewLine121;
                public TTReportField NewField1117111;
                public TTReportField PREDIAGNOSE; 
                public SUBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 28;
                    RepeatCount = 0;
                    
                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 6, 99, 6, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 114, 5, false);
                    NewField1117111.Name = "NewField1117111";
                    NewField1117111.TextFont.Name = "Arial Narrow";
                    NewField1117111.TextFont.Size = 9;
                    NewField1117111.TextFont.Bold = true;
                    NewField1117111.Value = @"Kısa Anamnez ve Klinik Bulgular";

                    PREDIAGNOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 174, 26, false);
                    PREDIAGNOSE.Name = "PREDIAGNOSE";
                    PREDIAGNOSE.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSE.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSE.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSE.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSE.TextFont.Name = "Arial Narrow";
                    PREDIAGNOSE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1117111.CalcValue = NewField1117111.Value;
                    PREDIAGNOSE.CalcValue = PREDIAGNOSE.Value;
                    return new TTReportObject[] { NewField1117111,PREDIAGNOSE};
                }

                public override void RunScript()
                {
#region SUB FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((InternalProcedureRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalProcedureRequest internalProcedureRequest = (InternalProcedureRequest)objectContext.GetObject(new Guid(objectID),typeof(InternalProcedureRequest).Name);
            
            if(internalProcedureRequest.PreDiagnosisString!=null)
                this.PREDIAGNOSE.CalcValue = internalProcedureRequest.PreDiagnosisString;
#endregion SUB FOOTER_Script
                }
            }

        }

        public SUBGroup SUB;

        public partial class MAINGroup : TTReportGroup
        {
            public InternalProcedureRequestReport MyParentReport
            {
                get { return (InternalProcedureRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TEST { get {return Body().TEST;} }
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
                list[0] = new TTReportNqlData<InternalSubActionProcedure.GetInternalSubActionProcedures_Class>("GetInternalSubActionProcedures", InternalSubActionProcedure.GetInternalSubActionProcedures((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InternalProcedureRequestReport MyParentReport
                {
                    get { return (InternalProcedureRequestReport)ParentReport; }
                }
                
                public TTReportField TEST; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TEST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 174, 6, false);
                    TEST.Name = "TEST";
                    TEST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEST.TextFont.Name = "Arial Narrow";
                    TEST.Value = @"{#TESTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InternalSubActionProcedure.GetInternalSubActionProcedures_Class dataset_GetInternalSubActionProcedures = ParentGroup.rsGroup.GetCurrentRecord<InternalSubActionProcedure.GetInternalSubActionProcedures_Class>(0);
                    TEST.CalcValue = (dataset_GetInternalSubActionProcedures != null ? Globals.ToStringCore(dataset_GetInternalSubActionProcedures.Testname) : "");
                    return new TTReportObject[] { TEST};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InternalProcedureRequestReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            SUB = new SUBGroup(HEADER,"SUB");
            MAIN = new MAINGroup(SUB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INTERNALPROCEDUREREQUESTREPORT";
            Caption = "Dış Tetkik İstek Formu";
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