
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
    /// Ölüm Kartı
    /// </summary>
    public partial class DeathCard : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public DeathCard MyParentReport
            {
                get { return (DeathCard)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ADISOYADILABEL { get {return Body().ADISOYADILABEL;} }
            public TTReportField SINIFIVERUTBESILABEL { get {return Body().SINIFIVERUTBESILABEL;} }
            public TTReportField OLUMNEDENILABEL { get {return Body().OLUMNEDENILABEL;} }
            public TTReportField OLUMSAATILABEL { get {return Body().OLUMSAATILABEL;} }
            public TTReportField ABDBDLABEL { get {return Body().ABDBDLABEL;} }
            public TTReportField DOKTORLABEL { get {return Body().DOKTORLABEL;} }
            public TTReportField HEMSIRELABEL { get {return Body().HEMSIRELABEL;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField ADI { get {return Body().ADI;} }
            public TTReportField SINIFIVERUTBESI { get {return Body().SINIFIVERUTBESI;} }
            public TTReportField OLUMNEDENI { get {return Body().OLUMNEDENI;} }
            public TTReportField OLUMSAATI { get {return Body().OLUMSAATI;} }
            public TTReportField ABDBD { get {return Body().ABDBD;} }
            public TTReportField DOKTOR { get {return Body().DOKTOR;} }
            public TTReportField HEMSIRE { get {return Body().HEMSIRE;} }
            public TTReportField BASLIKLABEL { get {return Body().BASLIKLABEL;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField SOYADI { get {return Body().SOYADI;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField RUTBESI { get {return Body().RUTBESI;} }
            public TTReportField SINIFI { get {return Body().SINIFI;} }
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
                public DeathCard MyParentReport
                {
                    get { return (DeathCard)ParentReport; }
                }
                
                public TTReportField ADISOYADILABEL;
                public TTReportField SINIFIVERUTBESILABEL;
                public TTReportField OLUMNEDENILABEL;
                public TTReportField OLUMSAATILABEL;
                public TTReportField ABDBDLABEL;
                public TTReportField DOKTORLABEL;
                public TTReportField HEMSIRELABEL;
                public TTReportField NewField2;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField ADI;
                public TTReportField SINIFIVERUTBESI;
                public TTReportField OLUMNEDENI;
                public TTReportField OLUMSAATI;
                public TTReportField ABDBD;
                public TTReportField DOKTOR;
                public TTReportField HEMSIRE;
                public TTReportField BASLIKLABEL;
                public TTReportField TARIH;
                public TTReportField SOYADI;
                public TTReportField ADISOYADI;
                public TTReportField RUTBESI;
                public TTReportField SINIFI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 83;
                    RepeatCount = 0;
                    
                    ADISOYADILABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 24, 43, 29, false);
                    ADISOYADILABEL.Name = "ADISOYADILABEL";
                    ADISOYADILABEL.TextFont.Name = "Arial";
                    ADISOYADILABEL.TextFont.Size = 11;
                    ADISOYADILABEL.TextFont.Bold = true;
                    ADISOYADILABEL.TextFont.CharSet = 162;
                    ADISOYADILABEL.Value = @"Adı Soyadı";

                    SINIFIVERUTBESILABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 29, 43, 34, false);
                    SINIFIVERUTBESILABEL.Name = "SINIFIVERUTBESILABEL";
                    SINIFIVERUTBESILABEL.TextFont.Name = "Arial";
                    SINIFIVERUTBESILABEL.TextFont.Size = 11;
                    SINIFIVERUTBESILABEL.TextFont.Bold = true;
                    SINIFIVERUTBESILABEL.TextFont.CharSet = 162;
                    SINIFIVERUTBESILABEL.Value = @"Sınıfı ve Rütbesi";

                    OLUMNEDENILABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 43, 39, false);
                    OLUMNEDENILABEL.Name = "OLUMNEDENILABEL";
                    OLUMNEDENILABEL.TextFont.Name = "Arial";
                    OLUMNEDENILABEL.TextFont.Size = 11;
                    OLUMNEDENILABEL.TextFont.Bold = true;
                    OLUMNEDENILABEL.TextFont.CharSet = 162;
                    OLUMNEDENILABEL.Value = @"Ölüm Nedeni";

                    OLUMSAATILABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 39, 43, 44, false);
                    OLUMSAATILABEL.Name = "OLUMSAATILABEL";
                    OLUMSAATILABEL.TextFont.Name = "Arial";
                    OLUMSAATILABEL.TextFont.Size = 11;
                    OLUMSAATILABEL.TextFont.Bold = true;
                    OLUMSAATILABEL.TextFont.CharSet = 162;
                    OLUMSAATILABEL.Value = @"Ölüm Saati";

                    ABDBDLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 44, 43, 49, false);
                    ABDBDLABEL.Name = "ABDBDLABEL";
                    ABDBDLABEL.TextFont.Name = "Arial";
                    ABDBDLABEL.TextFont.Size = 11;
                    ABDBDLABEL.TextFont.Bold = true;
                    ABDBDLABEL.TextFont.CharSet = 162;
                    ABDBDLABEL.Value = @"ABD / BD";

                    DOKTORLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 49, 43, 54, false);
                    DOKTORLABEL.Name = "DOKTORLABEL";
                    DOKTORLABEL.TextFont.Name = "Arial";
                    DOKTORLABEL.TextFont.Size = 11;
                    DOKTORLABEL.TextFont.Bold = true;
                    DOKTORLABEL.TextFont.CharSet = 162;
                    DOKTORLABEL.Value = @"Doktor";

                    HEMSIRELABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 54, 43, 59, false);
                    HEMSIRELABEL.Name = "HEMSIRELABEL";
                    HEMSIRELABEL.TextFont.Name = "Arial";
                    HEMSIRELABEL.TextFont.Size = 11;
                    HEMSIRELABEL.TextFont.Bold = true;
                    HEMSIRELABEL.TextFont.CharSet = 162;
                    HEMSIRELABEL.Value = @"Hemşire";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 24, 45, 29, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 29, 45, 34, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 34, 45, 39, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 39, 45, 44, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 44, 45, 49, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 49, 45, 54, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 11;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 54, 45, 59, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @":";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 14, 235, 19, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.ObjectDefName = "Morgue";
                    ADI.DataMember = "EPISODE.PATIENT.NAME";
                    ADI.TextFont.Size = 9;
                    ADI.TextFont.CharSet = 162;
                    ADI.Value = @"{@TTOBJECTID@}";

                    SINIFIVERUTBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 29, 104, 34, false);
                    SINIFIVERUTBESI.Name = "SINIFIVERUTBESI";
                    SINIFIVERUTBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFIVERUTBESI.TextFont.Name = "Arial";
                    SINIFIVERUTBESI.TextFont.Size = 9;
                    SINIFIVERUTBESI.TextFont.CharSet = 162;
                    SINIFIVERUTBESI.Value = @"{%SINIFI%} - {%RUTBESI%}";

                    OLUMNEDENI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 34, 104, 39, false);
                    OLUMNEDENI.Name = "OLUMNEDENI";
                    OLUMNEDENI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLUMNEDENI.ObjectDefName = "Morgue";
                    OLUMNEDENI.DataMember = "MERNISDEATHREASONS.REASONNAME";
                    OLUMNEDENI.TextFont.Name = "Arial";
                    OLUMNEDENI.TextFont.Size = 9;
                    OLUMNEDENI.TextFont.CharSet = 162;
                    OLUMNEDENI.Value = @"{@TTOBJECTID@}";

                    OLUMSAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 39, 104, 44, false);
                    OLUMSAATI.Name = "OLUMSAATI";
                    OLUMSAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLUMSAATI.TextFormat = @"Short Time";
                    OLUMSAATI.ObjectDefName = "MORGUE";
                    OLUMSAATI.DataMember = "DATETIMEOFDEATH";
                    OLUMSAATI.TextFont.Name = "Arial";
                    OLUMSAATI.TextFont.Size = 9;
                    OLUMSAATI.TextFont.CharSet = 162;
                    OLUMSAATI.Value = @"{@TTOBJECTID@}";

                    ABDBD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 44, 104, 49, false);
                    ABDBD.Name = "ABDBD";
                    ABDBD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ABDBD.ObjectDefName = "MORGUE";
                    ABDBD.DataMember = "DIEDCLINIC.NAME";
                    ABDBD.TextFont.Name = "Arial";
                    ABDBD.TextFont.Size = 9;
                    ABDBD.TextFont.CharSet = 162;
                    ABDBD.Value = @"{@TTOBJECTID@}";

                    DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 49, 104, 54, false);
                    DOKTOR.Name = "DOKTOR";
                    DOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTOR.ObjectDefName = "MORGUE";
                    DOKTOR.DataMember = "DOCTORFIXED.NAME";
                    DOKTOR.TextFont.Name = "Arial";
                    DOKTOR.TextFont.Size = 9;
                    DOKTOR.TextFont.CharSet = 162;
                    DOKTOR.Value = @"{@TTOBJECTID@}";

                    HEMSIRE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 54, 104, 59, false);
                    HEMSIRE.Name = "HEMSIRE";
                    HEMSIRE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE.ObjectDefName = "Morgue";
                    HEMSIRE.DataMember = "NURSE.NAME";
                    HEMSIRE.TextFont.Name = "Arial";
                    HEMSIRE.TextFont.Size = 9;
                    HEMSIRE.TextFont.CharSet = 162;
                    HEMSIRE.Value = @"{@TTOBJECTID@}";

                    BASLIKLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 104, 17, false);
                    BASLIKLABEL.Name = "BASLIKLABEL";
                    BASLIKLABEL.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIKLABEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIKLABEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIKLABEL.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIKLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIKLABEL.TextFont.Name = "Arial";
                    BASLIKLABEL.TextFont.Size = 9;
                    BASLIKLABEL.TextFont.Bold = true;
                    BASLIKLABEL.TextFont.CharSet = 162;
                    BASLIKLABEL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """") + ""\r\n"" + ""ÖLÜM KARTI""";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 18, 104, 23, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{@printdate@}";

                    SOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 9, 235, 14, false);
                    SOYADI.Name = "SOYADI";
                    SOYADI.Visible = EvetHayirEnum.ehHayir;
                    SOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYADI.ObjectDefName = "Morgue";
                    SOYADI.DataMember = "EPISODE.PATIENT.SURNAME";
                    SOYADI.TextFont.Size = 9;
                    SOYADI.TextFont.CharSet = 162;
                    SOYADI.Value = @"{@TTOBJECTID@}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 24, 104, 29, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.Name = "Arial";
                    ADISOYADI.TextFont.Size = 9;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{%ADI%} {%SOYADI%}";

                    RUTBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 27, 235, 32, false);
                    RUTBESI.Name = "RUTBESI";
                    RUTBESI.Visible = EvetHayirEnum.ehHayir;
                    RUTBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBESI.TextFont.Size = 9;
                    RUTBESI.TextFont.CharSet = 162;
                    RUTBESI.Value = @"";

                    SINIFI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 22, 235, 27, false);
                    SINIFI.Name = "SINIFI";
                    SINIFI.Visible = EvetHayirEnum.ehHayir;
                    SINIFI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFI.TextFont.Name = "Arial";
                    SINIFI.TextFont.Size = 9;
                    SINIFI.TextFont.CharSet = 162;
                    SINIFI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADISOYADILABEL.CalcValue = ADISOYADILABEL.Value;
                    SINIFIVERUTBESILABEL.CalcValue = SINIFIVERUTBESILABEL.Value;
                    OLUMNEDENILABEL.CalcValue = OLUMNEDENILABEL.Value;
                    OLUMSAATILABEL.CalcValue = OLUMSAATILABEL.Value;
                    ABDBDLABEL.CalcValue = ABDBDLABEL.Value;
                    DOKTORLABEL.CalcValue = DOKTORLABEL.Value;
                    HEMSIRELABEL.CalcValue = HEMSIRELABEL.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    ADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ADI.PostFieldValueCalculation();
                    SINIFI.CalcValue = @"";
                    RUTBESI.CalcValue = @"";
                    SINIFIVERUTBESI.CalcValue = MyParentReport.MAIN.SINIFI.CalcValue + @" - " + MyParentReport.MAIN.RUTBESI.CalcValue;
                    OLUMNEDENI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    OLUMNEDENI.PostFieldValueCalculation();
                    OLUMSAATI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    OLUMSAATI.PostFieldValueCalculation();
                    ABDBD.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ABDBD.PostFieldValueCalculation();
                    DOKTOR.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DOKTOR.PostFieldValueCalculation();
                    HEMSIRE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HEMSIRE.PostFieldValueCalculation();
                    TARIH.CalcValue = DateTime.Now.ToShortDateString();
                    SOYADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SOYADI.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = MyParentReport.MAIN.ADI.CalcValue + @" " + MyParentReport.MAIN.SOYADI.CalcValue;
                    BASLIKLABEL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "") + "\r\n" + "ÖLÜM KARTI";
                    return new TTReportObject[] { ADISOYADILABEL,SINIFIVERUTBESILABEL,OLUMNEDENILABEL,OLUMSAATILABEL,ABDBDLABEL,DOKTORLABEL,HEMSIRELABEL,NewField2,NewField14,NewField15,NewField16,NewField17,NewField141,NewField151,ADI,SINIFI,RUTBESI,SINIFIVERUTBESI,OLUMNEDENI,OLUMSAATI,ABDBD,DOKTOR,HEMSIRE,TARIH,SOYADI,ADISOYADI,BASLIKLABEL};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DeathCard()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Morg", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DEATHCARD";
            Caption = "Ölüm Kartı";
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