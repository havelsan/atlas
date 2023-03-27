
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
    /// Ortez Protez reçete
    /// </summary>
    public partial class OrthesisProsthesisReceptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public OrthesisProsthesisReceptionReport MyParentReport
            {
                get { return (OrthesisProsthesisReceptionReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField Reçete { get {return Header().Reçete;} }
            public TTReportField lblTesis { get {return Header().lblTesis;} }
            public TTReportField TesisKodu { get {return Header().TesisKodu;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField lblBasvuru { get {return Footer().lblBasvuru;} }
            public TTReportField lblTeslim1 { get {return Footer().lblTeslim1;} }
            public TTReportField lblUrun1 { get {return Footer().lblUrun1;} }
            public TTReportField lblTeslimAlan1 { get {return Footer().lblTeslimAlan1;} }
            public TTReportField lblAdSoyad1 { get {return Footer().lblAdSoyad1;} }
            public TTReportField lblTcYakın1 { get {return Footer().lblTcYakın1;} }
            public TTReportField lblTelNo1 { get {return Footer().lblTelNo1;} }
            public TTReportField lblAdres1 { get {return Footer().lblAdres1;} }
            public TTReportField lblSbt1 { get {return Footer().lblSbt1;} }
            public TTReportField lblSabit12 { get {return Footer().lblSabit12;} }
            public TTReportField MobilePhone1 { get {return Footer().MobilePhone1;} }
            public TTReportField PatientAdress1 { get {return Footer().PatientAdress1;} }
            public TTReportField lblSabit13 { get {return Footer().lblSabit13;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>("GetOrthesisRceptionReportInfo", OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public OrthesisProsthesisReceptionReport MyParentReport
                {
                    get { return (OrthesisProsthesisReceptionReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField Reçete;
                public TTReportField lblTesis;
                public TTReportField TesisKodu;
                public TTReportField LOGO; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 58;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 4, 197, 45, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Reçete = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 47, 126, 52, false);
                    Reçete.Name = "Reçete";
                    Reçete.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Reçete.TextFont.Name = "Arial";
                    Reçete.TextFont.Size = 12;
                    Reçete.TextFont.Bold = true;
                    Reçete.TextFont.CharSet = 162;
                    Reçete.Value = @"Reçete";

                    lblTesis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 47, 169, 52, false);
                    lblTesis.Name = "lblTesis";
                    lblTesis.Value = @"Medula Tesis Kodu";

                    TesisKodu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 47, 200, 52, false);
                    TesisKodu.Name = "TesisKodu";
                    TesisKodu.FieldType = ReportFieldTypeEnum.ftExpression;
                    TesisKodu.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MEDULASAGLIKTESISKODU"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 38, 32, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    Reçete.CalcValue = Reçete.Value;
                    lblTesis.CalcValue = lblTesis.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    TesisKodu.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    return new TTReportObject[] { Reçete,lblTesis,LOGO,XXXXXXBASLIK,TesisKodu};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public OrthesisProsthesisReceptionReport MyParentReport
                {
                    get { return (OrthesisProsthesisReceptionReport)ParentReport; }
                }
                
                public TTReportField lblBasvuru;
                public TTReportField lblTeslim1;
                public TTReportField lblUrun1;
                public TTReportField lblTeslimAlan1;
                public TTReportField lblAdSoyad1;
                public TTReportField lblTcYakın1;
                public TTReportField lblTelNo1;
                public TTReportField lblAdres1;
                public TTReportField lblSbt1;
                public TTReportField lblSabit12;
                public TTReportField MobilePhone1;
                public TTReportField PatientAdress1;
                public TTReportField lblSabit13;
                public TTReportField NewField11; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 72;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblBasvuru = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 34, 6, false);
                    lblBasvuru.Name = "lblBasvuru";
                    lblBasvuru.Value = @"Başvuru Tarihi:";

                    lblTeslim1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 34, 12, false);
                    lblTeslim1.Name = "lblTeslim1";
                    lblTeslim1.Value = @"Teslim Tarihi:";

                    lblUrun1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 13, 34, 18, false);
                    lblUrun1.Name = "lblUrun1";
                    lblUrun1.Value = @"Ürün Bilgileri:";

                    lblTeslimAlan1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 190, 5, false);
                    lblTeslimAlan1.Name = "lblTeslimAlan1";
                    lblTeslimAlan1.TextFont.Name = "Arial";
                    lblTeslimAlan1.TextFont.Bold = true;
                    lblTeslimAlan1.TextFont.CharSet = 162;
                    lblTeslimAlan1.Value = @"Teslim Alan Bilgileri (Hasta / Hasta Yakını)";

                    lblAdSoyad1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 6, 140, 11, false);
                    lblAdSoyad1.Name = "lblAdSoyad1";
                    lblAdSoyad1.Value = @"Adı ve Soyadı:";

                    lblTcYakın1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 11, 140, 16, false);
                    lblTcYakın1.Name = "lblTcYakın1";
                    lblTcYakın1.Value = @"T.C Kimlik No:";

                    lblTelNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 16, 140, 21, false);
                    lblTelNo1.Name = "lblTelNo1";
                    lblTelNo1.Value = @"Tel No:";

                    lblAdres1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 21, 140, 26, false);
                    lblAdres1.Name = "lblAdres1";
                    lblAdres1.Value = @"Adresi:";

                    lblSbt1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 41, 40, 46, false);
                    lblSbt1.Name = "lblSbt1";
                    lblSbt1.TextFont.Name = "Arial";
                    lblSbt1.TextFont.Bold = true;
                    lblSbt1.TextFont.CharSet = 162;
                    lblSbt1.Value = @"Engin ASLAN";

                    lblSabit12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 46, 52, 54, false);
                    lblSabit12.Name = "lblSabit12";
                    lblSabit12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblSabit12.MultiLine = EvetHayirEnum.ehEvet;
                    lblSabit12.Value = @"Gaziler Fizik Tedavi ve Reh.E.A.H
Ortez-Protez Birim Sorumlusu";

                    MobilePhone1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 16, 166, 21, false);
                    MobilePhone1.Name = "MobilePhone1";
                    MobilePhone1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MobilePhone1.Value = @"{#MOBILEPHONE#}";

                    PatientAdress1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 21, 190, 40, false);
                    PatientAdress1.Name = "PatientAdress1";
                    PatientAdress1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientAdress1.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAdress1.NoClip = EvetHayirEnum.ehEvet;
                    PatientAdress1.WordBreak = EvetHayirEnum.ehEvet;
                    PatientAdress1.Value = @"{#HOMEADDRESS#}";

                    lblSabit13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 48, 206, 53, false);
                    lblSabit13.Name = "lblSabit13";
                    lblSabit13.Value = @"... Adet cihazı Teslim Aldım.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 58, 209, 67, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    lblBasvuru.CalcValue = lblBasvuru.Value;
                    lblTeslim1.CalcValue = lblTeslim1.Value;
                    lblUrun1.CalcValue = lblUrun1.Value;
                    lblTeslimAlan1.CalcValue = lblTeslimAlan1.Value;
                    lblAdSoyad1.CalcValue = lblAdSoyad1.Value;
                    lblTcYakın1.CalcValue = lblTcYakın1.Value;
                    lblTelNo1.CalcValue = lblTelNo1.Value;
                    lblAdres1.CalcValue = lblAdres1.Value;
                    lblSbt1.CalcValue = lblSbt1.Value;
                    lblSabit12.CalcValue = lblSabit12.Value;
                    MobilePhone1.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.MobilePhone) : "");
                    PatientAdress1.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.HomeAddress) : "");
                    lblSabit13.CalcValue = lblSabit13.Value;
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { lblBasvuru,lblTeslim1,lblUrun1,lblTeslimAlan1,lblAdSoyad1,lblTcYakın1,lblTelNo1,lblAdres1,lblSbt1,lblSabit12,MobilePhone1,PatientAdress1,lblSabit13,NewField11};
                }
            }

        }

        public HeaderGroup Header;

        public partial class PatientGroup : TTReportGroup
        {
            public OrthesisProsthesisReceptionReport MyParentReport
            {
                get { return (OrthesisProsthesisReceptionReport)ParentReport; }
            }

            new public PatientGroupHeader Header()
            {
                return (PatientGroupHeader)_header;
            }

            new public PatientGroupFooter Footer()
            {
                return (PatientGroupFooter)_footer;
            }

            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField PSURNAME { get {return Header().PSURNAME;} }
            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField PDATE { get {return Header().PDATE;} }
            public TTReportField TC { get {return Header().TC;} }
            public TTReportField SIGNATURE { get {return Header().SIGNATURE;} }
            public TTReportField DIAGNOSISFIELD { get {return Header().DIAGNOSISFIELD;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField11461 { get {return Header().NewField11461;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField ReceptionNo { get {return Header().ReceptionNo;} }
            public TTReportField ReportNo { get {return Header().ReportNo;} }
            public TTReportField lblPAtientName { get {return Header().lblPAtientName;} }
            public TTReportField lblTC { get {return Header().lblTC;} }
            public TTReportField lblPayer { get {return Header().lblPayer;} }
            public TTReportField ProtocolNo { get {return Header().ProtocolNo;} }
            public TTReportField lblDate { get {return Header().lblDate;} }
            public TTReportField lblIslemNo { get {return Header().lblIslemNo;} }
            public TTReportField lblRaporNo { get {return Header().lblRaporNo;} }
            public TTReportField lblHastaProtNo { get {return Header().lblHastaProtNo;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine151 { get {return Header().NewLine151;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField LblKod { get {return Header().LblKod;} }
            public TTReportField LblMiktar { get {return Header().LblMiktar;} }
            public TTReportField LblTaraf { get {return Header().LblTaraf;} }
            public TTReportField LblMalzeme { get {return Header().LblMalzeme;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine141 { get {return Footer().NewLine141;} }
            public PatientGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PatientGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>("GetOrthesisRceptionReportInfo", OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PatientGroupHeader(this);
                _footer = new PatientGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PatientGroupHeader : TTReportSection
            {
                public OrthesisProsthesisReceptionReport MyParentReport
                {
                    get { return (OrthesisProsthesisReceptionReport)ParentReport; }
                }
                
                public TTReportField PNAME;
                public TTReportField PSURNAME;
                public TTReportField FULLNAME;
                public TTReportField PDATE;
                public TTReportField TC;
                public TTReportField SIGNATURE;
                public TTReportField DIAGNOSISFIELD;
                public TTReportField NewField11431;
                public TTReportField NewField11461;
                public TTReportField PAYER;
                public TTReportField ReceptionNo;
                public TTReportField ReportNo;
                public TTReportField lblPAtientName;
                public TTReportField lblTC;
                public TTReportField lblPayer;
                public TTReportField ProtocolNo;
                public TTReportField lblDate;
                public TTReportField lblIslemNo;
                public TTReportField lblRaporNo;
                public TTReportField lblHastaProtNo;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine16;
                public TTReportShape NewLine151;
                public TTReportShape NewLine3;
                public TTReportShape NewLine12;
                public TTReportField LblKod;
                public TTReportField LblMiktar;
                public TTReportField LblTaraf;
                public TTReportField LblMalzeme;
                public TTReportShape NewLine4; 
                public PatientGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 2, 232, 7, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.Value = @"{#NAME#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 10, 234, 15, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.Value = @"{#SURNAME#}";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 4, 91, 9, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"{%PNAME%} {%PSURNAME%}";

                    PDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 4, 205, 9, false);
                    PDATE.Name = "PDATE";
                    PDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PDATE.TextFormat = @"dd/MM/yyyy";
                    PDATE.Value = @"{#ISLEMTARIHI#}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 10, 91, 15, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.Value = @"{#TCKIMLIKNO#}";

                    SIGNATURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 31, 205, 62, false);
                    SIGNATURE.Name = "SIGNATURE";
                    SIGNATURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNATURE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIGNATURE.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNATURE.NoClip = EvetHayirEnum.ehEvet;
                    SIGNATURE.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNATURE.Value = @"";

                    DIAGNOSISFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 30, 91, 61, false);
                    DIAGNOSISFIELD.Name = "DIAGNOSISFIELD";
                    DIAGNOSISFIELD.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.Value = @"";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 26, 34, 31, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.TextFont.Bold = true;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"Tanı";

                    NewField11461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 26, 140, 31, false);
                    NewField11461.Name = "NewField11461";
                    NewField11461.TextFont.Bold = true;
                    NewField11461.TextFont.CharSet = 162;
                    NewField11461.Value = @"Hekim Kaşe İmza";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 15, 108, 24, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.Value = @"{#PAYER#}";

                    ReceptionNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 10, 205, 15, false);
                    ReceptionNo.Name = "ReceptionNo";
                    ReceptionNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReceptionNo.Value = @"{#KABUL#}";

                    ReportNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 15, 205, 20, false);
                    ReportNo.Name = "ReportNo";
                    ReportNo.Value = @"";

                    lblPAtientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 34, 9, false);
                    lblPAtientName.Name = "lblPAtientName";
                    lblPAtientName.Value = @"Adı Soyadı :";

                    lblTC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 34, 15, false);
                    lblTC.Name = "lblTC";
                    lblTC.Value = @"T.C. Kimlik No
";

                    lblPayer = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 34, 20, false);
                    lblPayer.Name = "lblPayer";
                    lblPayer.MultiLine = EvetHayirEnum.ehEvet;
                    lblPayer.NoClip = EvetHayirEnum.ehEvet;
                    lblPayer.WordBreak = EvetHayirEnum.ehEvet;
                    lblPayer.Value = @"Hastanın Kurumu";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 20, 205, 25, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNo.Value = @"{#PROTOCOLNO#}";

                    lblDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 4, 140, 9, false);
                    lblDate.Name = "lblDate";
                    lblDate.Value = @"Tarih";

                    lblIslemNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 10, 140, 15, false);
                    lblIslemNo.Name = "lblIslemNo";
                    lblIslemNo.Value = @"İşlem No";

                    lblRaporNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 15, 140, 20, false);
                    lblRaporNo.Name = "lblRaporNo";
                    lblRaporNo.Value = @"Rapor No";

                    lblHastaProtNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 20, 140, 25, false);
                    lblHastaProtNo.Name = "lblHastaProtNo";
                    lblHastaProtNo.Value = @"Hast. Prot. No";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 15, 204, 15, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 10, 205, 10, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 111, 20, 204, 20, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 25, 205, 25, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 4, 8, 62, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 57, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 205, 4, 205, 62, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 62, 205, 62, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 4, 205, 4, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 111, 4, 111, 62, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    LblKod = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 66, 33, 71, false);
                    LblKod.Name = "LblKod";
                    LblKod.TextFont.Name = "Arial";
                    LblKod.TextFont.Size = 11;
                    LblKod.TextFont.Bold = true;
                    LblKod.TextFont.CharSet = 162;
                    LblKod.Value = @"KOD";

                    LblMiktar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 66, 171, 71, false);
                    LblMiktar.Name = "LblMiktar";
                    LblMiktar.TextFont.Name = "Arial";
                    LblMiktar.TextFont.Bold = true;
                    LblMiktar.TextFont.CharSet = 162;
                    LblMiktar.Value = @"Miktar";

                    LblTaraf = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 66, 203, 71, false);
                    LblTaraf.Name = "LblTaraf";
                    LblTaraf.TextFont.Name = "Arial";
                    LblTaraf.TextFont.Bold = true;
                    LblTaraf.TextFont.CharSet = 162;
                    LblTaraf.Value = @"Taraf";

                    LblMalzeme = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 66, 137, 71, false);
                    LblMalzeme.Name = "LblMalzeme";
                    LblMalzeme.TextFont.Name = "Arial";
                    LblMalzeme.TextFont.Bold = true;
                    LblMalzeme.TextFont.CharSet = 162;
                    LblMalzeme.Value = @"Malzeme";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 64, 205, 64, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    PNAME.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Name) : "");
                    PSURNAME.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Surname) : "");
                    FULLNAME.CalcValue = MyParentReport.Patient.PNAME.CalcValue + @" " + MyParentReport.Patient.PSURNAME.CalcValue;
                    PDATE.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Islemtarihi) : "");
                    TC.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Tckimlikno) : "");
                    SIGNATURE.CalcValue = @"";
                    DIAGNOSISFIELD.CalcValue = DIAGNOSISFIELD.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField11461.CalcValue = NewField11461.Value;
                    PAYER.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Payer) : "");
                    ReceptionNo.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Kabul) : "");
                    ReportNo.CalcValue = ReportNo.Value;
                    lblPAtientName.CalcValue = lblPAtientName.Value;
                    lblTC.CalcValue = lblTC.Value;
                    lblPayer.CalcValue = lblPayer.Value;
                    ProtocolNo.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.ProtocolNo) : "");
                    lblDate.CalcValue = lblDate.Value;
                    lblIslemNo.CalcValue = lblIslemNo.Value;
                    lblRaporNo.CalcValue = lblRaporNo.Value;
                    lblHastaProtNo.CalcValue = lblHastaProtNo.Value;
                    LblKod.CalcValue = LblKod.Value;
                    LblMiktar.CalcValue = LblMiktar.Value;
                    LblTaraf.CalcValue = LblTaraf.Value;
                    LblMalzeme.CalcValue = LblMalzeme.Value;
                    return new TTReportObject[] { PNAME,PSURNAME,FULLNAME,PDATE,TC,SIGNATURE,DIAGNOSISFIELD,NewField11431,NewField11461,PAYER,ReceptionNo,ReportNo,lblPAtientName,lblTC,lblPayer,ProtocolNo,lblDate,lblIslemNo,lblRaporNo,lblHastaProtNo,LblKod,LblMiktar,LblTaraf,LblMalzeme};
                }

                public override void RunScript()
                {
#region PATIENT HEADER_Script
                    string diagnoseStr= "";
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((OrthesisProsthesisReceptionReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            OrthesisProsthesisRequest p = (OrthesisProsthesisRequest)context.GetObject(new Guid(sObjectID), "OrthesisProsthesisRequest");
            
            if(p.Diagnosis.Count>0)// Buradan tanı girişi yapılmadıysa episodedaki kesin  tanılara bakar
            {
                foreach( DiagnosisGrid diagnosis in p.Diagnosis)
                {
                    diagnoseStr = diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name  + "-" +  diagnosis.FreeDiagnosis + "; " + "\n" + diagnoseStr ;
                }
            }
            else
            {
                foreach( DiagnosisGrid diagnosis in p.Episode.Diagnosis)
                {
                    diagnoseStr = diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name  + "-" +  diagnosis.FreeDiagnosis + "; " + "\n" + diagnoseStr ;
                }
            }
            this.DIAGNOSISFIELD.CalcValue= diagnoseStr;
            
            if(p.ProcedureDoctor!=null) {
                //this.SIGNATURE.CalcValue =p.ProcedureDoctor.SignatureBlock;
                //edited by ETAGMAT 06.03.2012
                //this.SIGNATURE.CalcValue = p.ProcedureDoctor.SignatureBlockWDiplomaInfo.Replace("\r", "");//boşluklar gitsin
            }
#endregion PATIENT HEADER_Script
                }
            }
            public partial class PatientGroupFooter : TTReportSection
            {
                public OrthesisProsthesisReceptionReport MyParentReport
                {
                    get { return (OrthesisProsthesisReceptionReport)ParentReport; }
                }
                
                public TTReportShape NewLine141; 
                public PatientGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    RepeatCount = 0;
                    
                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 205, 1, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public PatientGroup Patient;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisReceptionReport MyParentReport
            {
                get { return (OrthesisProsthesisReceptionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROCEDUREOBJECTS { get {return Body().PROCEDUREOBJECTS;} }
            public TTReportField KOD { get {return Body().KOD;} }
            public TTReportField Miktar { get {return Body().Miktar;} }
            public TTReportField Taraf { get {return Body().Taraf;} }
            public TTReportField Malzeme { get {return Body().Malzeme;} }
            public TTReportShape NewLine171 { get {return Body().NewLine171;} }
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
                list[0] = new TTReportNqlData<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>("GetOrthesisProsthesisProcedureByAction", OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OrthesisProsthesisReceptionReport MyParentReport
                {
                    get { return (OrthesisProsthesisReceptionReport)ParentReport; }
                }
                
                public TTReportField PROCEDUREOBJECTS;
                public TTReportField KOD;
                public TTReportField Miktar;
                public TTReportField Taraf;
                public TTReportField Malzeme;
                public TTReportShape NewLine171; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    PROCEDUREOBJECTS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 231, 5, false);
                    PROCEDUREOBJECTS.Name = "PROCEDUREOBJECTS";
                    PROCEDUREOBJECTS.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREOBJECTS.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCEDUREOBJECTS.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTS.NoClip = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTS.TextFont.Size = 12;
                    PROCEDUREOBJECTS.TextFont.CharSet = 162;
                    PROCEDUREOBJECTS.Value = @"";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 34, 7, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.Value = @"{#PROCEDURECODE#}";

                    Miktar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 2, 171, 7, false);
                    Miktar.Name = "Miktar";
                    Miktar.FieldType = ReportFieldTypeEnum.ftVariable;
                    Miktar.MultiLine = EvetHayirEnum.ehEvet;
                    Miktar.NoClip = EvetHayirEnum.ehEvet;
                    Miktar.WordBreak = EvetHayirEnum.ehEvet;
                    Miktar.ExpandTabs = EvetHayirEnum.ehEvet;
                    Miktar.Value = @"{#PROCEDUREAMOUNT#}";

                    Taraf = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 2, 203, 7, false);
                    Taraf.Name = "Taraf";
                    Taraf.FieldType = ReportFieldTypeEnum.ftVariable;
                    Taraf.MultiLine = EvetHayirEnum.ehEvet;
                    Taraf.NoClip = EvetHayirEnum.ehEvet;
                    Taraf.WordBreak = EvetHayirEnum.ehEvet;
                    Taraf.ExpandTabs = EvetHayirEnum.ehEvet;
                    Taraf.ObjectDefName = "RightLeftEnum";
                    Taraf.DataMember = "DISPLAYTEXT";
                    Taraf.Value = @"{#SIDE#}";

                    Malzeme = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 2, 137, 7, false);
                    Malzeme.Name = "Malzeme";
                    Malzeme.FieldType = ReportFieldTypeEnum.ftVariable;
                    Malzeme.MultiLine = EvetHayirEnum.ehEvet;
                    Malzeme.NoClip = EvetHayirEnum.ehEvet;
                    Malzeme.WordBreak = EvetHayirEnum.ehEvet;
                    Malzeme.ExpandTabs = EvetHayirEnum.ehEvet;
                    Malzeme.Value = @"{#PROCEDURENAME#}";

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 205, 1, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class dataset_GetOrthesisProsthesisProcedureByAction = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>(0);
                    PROCEDUREOBJECTS.CalcValue = PROCEDUREOBJECTS.Value;
                    KOD.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedurecode) : "");
                    Miktar.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedureamount) : "");
                    Taraf.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Side) : "");
                    Taraf.PostFieldValueCalculation();
                    Malzeme.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedurename) : "");
                    return new TTReportObject[] { PROCEDUREOBJECTS,KOD,Miktar,Taraf,Malzeme};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //        string procedures = "", enumName = "";
            //int index=1;
            //TTObjectContext context = new TTObjectContext(true);
            //string sObjectID = ((OrthesisProsthesisReceptionReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //OrthesisProsthesisRequest p = (OrthesisProsthesisRequest)context.GetObject(new Guid(sObjectID), "OrthesisProsthesisRequest");

            //if (p.OrthesisProsthesisProcedures.Count > 0)
            //{
            //    foreach (var item in p.OrthesisProsthesisProcedures)
            //    {
            //        this.KOD.CalcValue = item.ProcedureObject.Code;
            //        this.Miktar.CalcValue = item.Amount.ToString();

            //        if (item.Side != null)
            //        {
            //            enumName = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(item.Side).DisplayText;
            //            this.Taraf.CalcValue = enumName;
            //        }
            //        this.Malzeme.CalcValue = item.ProcedureObject.Name;

            //        //procedures += index+"- "+ "OP" + item.ProcedureObject.Code +"," + item.Amount + " adet,\t" + enumName + ",\t" + item.ProcedureObject.Name + "\n";
            //        index++;
            //    }
            //}
            
            //this.PROCEDUREOBJECTS.CalcValue = procedures;
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

        public OrthesisProsthesisReceptionReport()
        {
            Header = new HeaderGroup(this,"Header");
            Patient = new PatientGroup(Header,"Patient");
            MAIN = new MAINGroup(Patient,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ORTHESISPROSTHESISRECEPTIONREPORT";
            Caption = "Ortez Protez Reçete";
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