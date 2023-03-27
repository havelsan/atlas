
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
    /// Ortez-Protez İş Talep Formu
    /// </summary>
    public partial class OrthesisProsthesisRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public OrthesisProsthesisRequestReport MyParentReport
            {
                get { return (OrthesisProsthesisRequestReport)ParentReport; }
            }

            new public MASTERGroupHeader Header()
            {
                return (MASTERGroupHeader)_header;
            }

            new public MASTERGroupFooter Footer()
            {
                return (MASTERGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField ONTANI { get {return Header().ONTANI;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField NewField166 { get {return Header().NewField166;} }
            public TTReportField NewField165 { get {return Header().NewField165;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField194 { get {return Header().NewField194;} }
            public TTReportField NewField211 { get {return Header().NewField211;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField270 { get {return Header().NewField270;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField167 { get {return Header().NewField167;} }
            public TTReportField NewField178 { get {return Header().NewField178;} }
            public TTReportField NewField229 { get {return Header().NewField229;} }
            public TTReportField NewField173 { get {return Header().NewField173;} }
            public TTReportField NewField205 { get {return Header().NewField205;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public MASTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>("GetOrthesisProsthesisRequest", OrthesisProsthesisRequest.GetOrthesisProsthesisRequest((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MASTERGroupHeader(this);
                _footer = new MASTERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MASTERGroupHeader : TTReportSection
            {
                public OrthesisProsthesisRequestReport MyParentReport
                {
                    get { return (OrthesisProsthesisRequestReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField PNAME;
                public TTReportField ONTANI;
                public TTReportField ACIKLAMA;
                public TTReportField NewField166;
                public TTReportField NewField165;
                public TTReportField NewField17;
                public TTReportField NewField194;
                public TTReportField NewField211;
                public TTReportField TARIH;
                public TTReportField NewField270;
                public TTReportField NewField14;
                public TTReportField NewField161;
                public TTReportField FATHERNAME;
                public TTReportField NewField172;
                public TTReportField NewField167;
                public TTReportField NewField178;
                public TTReportField NewField229;
                public TTReportField NewField173;
                public TTReportField NewField205;
                public TTReportField NewField27;
                public TTReportField RAPORNO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXIL;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField1271; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 124;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 5, 156, 39, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%XXXXXXBASLIK%}
{%XXXXXXIL%}

ORTEZ-PROTEZ KISMI RAPORU-İŞ TALEP FORMU";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 46, 113, 51, false);
                    PNAME.Name = "PNAME";
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.Value = @"{%NAME%} {%SURNAME%}";

                    ONTANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 75, 349, 80, false);
                    ONTANI.Name = "ONTANI";
                    ONTANI.Visible = EvetHayirEnum.ehHayir;
                    ONTANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONTANI.MultiLine = EvetHayirEnum.ehEvet;
                    ONTANI.WordBreak = EvetHayirEnum.ehEvet;
                    ONTANI.Value = @"";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 109, 205, 121, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.Value = @"";

                    NewField166 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 46, 53, 51, false);
                    NewField166.Name = "NewField166";
                    NewField166.Value = @"Adı Soyadı           :";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 46, 157, 51, false);
                    NewField165.Name = "NewField165";
                    NewField165.Value = @"Doğum Yeri/Tarihi   :";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 61, 53, 66, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"Rütbesi              :";

                    NewField194 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 70, 249, 75, false);
                    NewField194.Name = "NewField194";
                    NewField194.Visible = EvetHayirEnum.ehHayir;
                    NewField194.Value = @"Tanı         :";

                    NewField211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 102, 57, 107, false);
                    NewField211.Name = "NewField211";
                    NewField211.Value = @"İşin Adı ve Ek Talepler";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 85, 205, 90, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.Value = @"{#ISLEMTARIHI#}";

                    NewField270 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 85, 161, 90, false);
                    NewField270.Name = "NewField270";
                    NewField270.Value = @"Tarih       :";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 39, 125, 44, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.Underline = true;
                    NewField14.Value = @"Klinik/Poliklinik Kısmı Tarafından Tanzim Edilecek";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 56, 53, 61, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @"Baba Adı             :";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 56, 113, 61, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.ObjectDefName = "Patient";
                    FATHERNAME.DataMember = "FATHERNAME";
                    FATHERNAME.Value = @"{#PID#}";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 66, 53, 71, false);
                    NewField172.Name = "NewField172";
                    NewField172.Value = @"Sicil No             :";

                    NewField167 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 51, 157, 56, false);
                    NewField167.Name = "NewField167";
                    NewField167.Value = @"Sağlık Fiş No       :";

                    NewField178 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 56, 157, 61, false);
                    NewField178.Name = "NewField178";
                    NewField178.Value = @"Emekli Sicil No     :";

                    NewField229 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 61, 157, 66, false);
                    NewField229.Name = "NewField229";
                    NewField229.Value = @"Hst Protokol No     :";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 71, 53, 76, false);
                    NewField173.Name = "NewField173";
                    NewField173.Value = @"Adresi/Tel No        :";

                    NewField205 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 85, 37, 90, false);
                    NewField205.Name = "NewField205";
                    NewField205.Value = @"Hyt.Rapor No :";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 91, 161, 96, false);
                    NewField27.Name = "NewField27";
                    NewField27.Value = @"Uz.Tbp.     :";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 85, 133, 90, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.Value = @"";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 14, 245, 19, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 20, 245, 25, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 58, 280, 63, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "Patient";
                    NAME.DataMember = "NAME";
                    NAME.Value = @"{#PID#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 63, 280, 68, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.Value = @"{#PID#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 51, 113, 56, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 51, 53, 56, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.Value = @"TC No                :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class dataset_GetOrthesisProsthesisRequest = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>(0);
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    HEADER.CalcValue = MyParentReport.MASTER.XXXXXXBASLIK.CalcValue + @"
" + MyParentReport.MASTER.XXXXXXIL.CalcValue + @"

ORTEZ-PROTEZ KISMI RAPORU-İŞ TALEP FORMU";
                    NAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    NAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    SURNAME.PostFieldValueCalculation();
                    PNAME.CalcValue = MyParentReport.MASTER.NAME.CalcValue + @" " + MyParentReport.MASTER.SURNAME.CalcValue;
                    ONTANI.CalcValue = @"";
                    ACIKLAMA.CalcValue = @"";
                    NewField166.CalcValue = NewField166.Value;
                    NewField165.CalcValue = NewField165.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField194.CalcValue = NewField194.Value;
                    NewField211.CalcValue = NewField211.Value;
                    TARIH.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Islemtarihi) : "");
                    NewField270.CalcValue = NewField270.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField161.CalcValue = NewField161.Value;
                    FATHERNAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    FATHERNAME.PostFieldValueCalculation();
                    NewField172.CalcValue = NewField172.Value;
                    NewField167.CalcValue = NewField167.Value;
                    NewField178.CalcValue = NewField178.Value;
                    NewField229.CalcValue = NewField229.Value;
                    NewField173.CalcValue = NewField173.Value;
                    NewField205.CalcValue = NewField205.Value;
                    NewField27.CalcValue = NewField27.Value;
                    RAPORNO.CalcValue = RAPORNO.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Tckimlikno) : "");
                    NewField1271.CalcValue = NewField1271.Value;
                    return new TTReportObject[] { XXXXXXBASLIK,XXXXXXIL,HEADER,NAME,SURNAME,PNAME,ONTANI,ACIKLAMA,NewField166,NewField165,NewField17,NewField194,NewField211,TARIH,NewField270,NewField14,NewField161,FATHERNAME,NewField172,NewField167,NewField178,NewField229,NewField173,NewField205,NewField27,RAPORNO,TCKIMLIKNO,NewField1271};
                }

                public override void RunScript()
                {
#region MASTER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((OrthesisProsthesisRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            OrthesisProsthesisRequest pRequest = (OrthesisProsthesisRequest)context.GetObject(new Guid(sObjectID),"OrthesisProsthesisRequest");
            
            if(pRequest == null)
                throw new Exception("Rapor Ortez Protez işlemi üzerinden alınmalıdır.\r\nReason: OrthesisProsthesisRequest is null");
            
            this.ACIKLAMA.Value = "";
            BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class> pProcedures = null;
            pProcedures = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction(sObjectID);
            foreach(OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class procedure in pProcedures)
            {
                this.ACIKLAMA.CalcValue += procedure.Procedurecode + " " + procedure.Procedurename + "\r\n";
            }
#endregion MASTER HEADER_Script
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public OrthesisProsthesisRequestReport MyParentReport
                {
                    get { return (OrthesisProsthesisRequestReport)ParentReport; }
                }
                 
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MASTERGroup MASTER;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisRequestReport MyParentReport
            {
                get { return (OrthesisProsthesisRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField140 { get {return Body().NewField140;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField143 { get {return Body().NewField143;} }
            public TTReportField NewField144 { get {return Body().NewField144;} }
            public TTReportField NewField145 { get {return Body().NewField145;} }
            public TTReportField NewField146 { get {return Body().NewField146;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField YAPILANIS { get {return Body().YAPILANIS;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
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
                public OrthesisProsthesisRequestReport MyParentReport
                {
                    get { return (OrthesisProsthesisRequestReport)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportField NewField140;
                public TTReportField NewField141;
                public TTReportField NewField143;
                public TTReportField NewField144;
                public TTReportField NewField145;
                public TTReportField NewField146;
                public TTReportField NewField125;
                public TTReportField YAPILANIS;
                public TTReportField DTARIH; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 50;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 126, 6, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.Underline = true;
                    NewField14.Value = @"Ortez-Protez Kısmı Tarafından Tanzim Edilecek";

                    NewField140 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 49, 14, false);
                    NewField140.Name = "NewField140";
                    NewField140.Value = @"Başvuru Tarihi    :";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 14, 49, 19, false);
                    NewField141.Name = "NewField141";
                    NewField141.Value = @"Ort.Pro.Kyt.No    :";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 19, 87, 24, false);
                    NewField143.Name = "NewField143";
                    NewField143.Value = @"%10 Mly.Alındı Makbuz No ve Tutarı  :";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 24, 49, 29, false);
                    NewField144.Name = "NewField144";
                    NewField144.Value = @"Görevli Personel  :";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 29, 49, 34, false);
                    NewField145.Name = "NewField145";
                    NewField145.TextFont.Underline = true;
                    NewField145.Value = @"Kısım Sorumlusu   :";

                    NewField146 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 34, 178, 39, false);
                    NewField146.Name = "NewField146";
                    NewField146.TextFont.Underline = true;
                    NewField146.Value = @"Teslim Alan  :";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 9, 138, 14, false);
                    NewField125.Name = "NewField125";
                    NewField125.Value = @"Yapılan İşlem :";

                    YAPILANIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 9, 212, 26, false);
                    YAPILANIS.Name = "YAPILANIS";
                    YAPILANIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAPILANIS.MultiLine = EvetHayirEnum.ehEvet;
                    YAPILANIS.NoClip = EvetHayirEnum.ehEvet;
                    YAPILANIS.WordBreak = EvetHayirEnum.ehEvet;
                    YAPILANIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    YAPILANIS.Value = @"{#MASTER.ACIKLAMA#}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 9, 93, 14, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.Value = @"{#MASTER.ISLEMTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class dataset_GetOrthesisProsthesisRequest = MyParentReport.MASTER.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>(0);
                    NewField14.CalcValue = NewField14.Value;
                    NewField140.CalcValue = NewField140.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField145.CalcValue = NewField145.Value;
                    NewField146.CalcValue = NewField146.Value;
                    NewField125.CalcValue = NewField125.Value;
                    YAPILANIS.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Aciklama) : "");
                    DTARIH.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Islemtarihi) : "");
                    return new TTReportObject[] { NewField14,NewField140,NewField141,NewField143,NewField144,NewField145,NewField146,NewField125,YAPILANIS,DTARIH};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OrthesisProsthesisRequestReport()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            MAIN = new MAINGroup(MASTER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ORTHESISPROSTHESISREQUESTREPORT";
            Caption = "Ortez-Protez İş Talep Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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