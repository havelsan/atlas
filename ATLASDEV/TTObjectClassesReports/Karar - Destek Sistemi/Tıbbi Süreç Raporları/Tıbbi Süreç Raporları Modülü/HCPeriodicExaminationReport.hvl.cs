
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
    /// Sağlık Kurulu Periodik Muayene Raporu
    /// </summary>
    public partial class HCPeriodicExaminationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("FFF565B8-229C-486A-8D48-123D35C9D4D1");
        }

        public partial class ARKASAYFAGroup : TTReportGroup
        {
            public HCPeriodicExaminationReport MyParentReport
            {
                get { return (HCPeriodicExaminationReport)ParentReport; }
            }

            new public ARKASAYFAGroupHeader Header()
            {
                return (ARKASAYFAGroupHeader)_header;
            }

            new public ARKASAYFAGroupFooter Footer()
            {
                return (ARKASAYFAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportShape shape1131 { get {return Footer().shape1131;} }
            public ARKASAYFAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ARKASAYFAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ARKASAYFAGroupHeader(this);
                _footer = new ARKASAYFAGroupFooter(this);

            }

            public partial class ARKASAYFAGroupHeader : TTReportSection
            {
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField SITENAME;
                public TTReportField SITECITY; 
                public ARKASAYFAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 197, 26, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Size = 12;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%ARKASAYFA.SITENAME%} {%ARKASAYFA.SITECITY%}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 6, 242, 11, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 13, 242, 18, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER.CalcValue = MyParentReport.ARKASAYFA.SITENAME.CalcValue + @" " + MyParentReport.ARKASAYFA.SITECITY.CalcValue;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    return new TTReportObject[] { HEADER,SITENAME,SITECITY};
                }
            }
            public partial class ARKASAYFAGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                
                public TTReportShape shape1131; 
                public ARKASAYFAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 7, 196, 7, false);
                    shape1131.Name = "shape1131";
                    shape1131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public ARKASAYFAGroup ARKASAYFA;

        public partial class ANAGroup : TTReportGroup
        {
            public HCPeriodicExaminationReport MyParentReport
            {
                get { return (HCPeriodicExaminationReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField FOTOGRAF { get {return Header().FOTOGRAF;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField MAKSAD { get {return Header().MAKSAD;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField LBLSICIL { get {return Header().LBLSICIL;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField NewField33 { get {return Header().NewField33;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField DTYER { get {return Header().DTYER;} }
            public TTReportField EMIRTARIHI { get {return Header().EMIRTARIHI;} }
            public TTReportField NewField40 { get {return Header().NewField40;} }
            public TTReportField EMIRNO { get {return Header().EMIRNO;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField52 { get {return Header().NewField52;} }
            public TTReportField HEADER2 { get {return Header().HEADER2;} }
            public TTReportField FOTO { get {return Header().FOTO;} }
            public ANAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommittee", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ANAGroupHeader(this);
                _footer = new ANAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ANAGroupHeader : TTReportSection
            {
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField FOTOGRAF;
                public TTReportField NewField21;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField MAKSAD;
                public TTReportField MAKAM;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField25;
                public TTReportField LBLSICIL;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField BIRLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField SICILNO;
                public TTReportField NewField33;
                public TTReportField ADRES;
                public TTReportField DTYER;
                public TTReportField EMIRTARIHI;
                public TTReportField NewField40;
                public TTReportField EMIRNO;
                public TTReportField RAPORNO;
                public TTReportField NewField2;
                public TTReportField NewField24;
                public TTReportField NewField51;
                public TTReportField NewField52;
                public TTReportField HEADER2;
                public TTReportField FOTO; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 97;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 83, 58, 88, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"Muayeneye gönderen makam";

                    FOTOGRAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 14, 197, 68, false);
                    FOTOGRAF.Name = "FOTOGRAF";
                    FOTOGRAF.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTOGRAF.FillStyle = FillStyleConstants.vbFSTransparent;
                    FOTOGRAF.TextFont.Name = "Arial Narrow";
                    FOTOGRAF.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 55, 58, 60, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.Value = @"D. Tarihi";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 73, 58, 78, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.Value = @"Emir Tarihi          ";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 58, 22, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.Value = @"Rapor Numarası";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 68, 58, 73, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.Value = @"Ne maksatla muayene edildiği";

                    MAKSAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 68, 197, 73, false);
                    MAKSAD.Name = "MAKSAD";
                    MAKSAD.DrawStyle = DrawStyleConstants.vbSolid;
                    MAKSAD.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKSAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKSAD.MultiLine = EvetHayirEnum.ehEvet;
                    MAKSAD.WordBreak = EvetHayirEnum.ehEvet;
                    MAKSAD.TextFont.Name = "Arial Narrow";
                    MAKSAD.TextFont.Size = 8;
                    MAKSAD.Value = @"{#SKSEBEBI#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 83, 197, 88, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.DrawStyle = DrawStyleConstants.vbSolid;
                    MAKAM.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 22, 159, 27, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 58, 40, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.Value = @"Adı Soyadı";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 58, 45, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.Value = @"Baba Adı";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 58, 50, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.Value = @"Sınıf Rütbe";

                    LBLSICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 50, 58, 55, false);
                    LBLSICIL.Name = "LBLSICIL";
                    LBLSICIL.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLSICIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    LBLSICIL.MultiLine = EvetHayirEnum.ehEvet;
                    LBLSICIL.WordBreak = EvetHayirEnum.ehEvet;
                    LBLSICIL.TextFont.Name = "Arial Narrow";
                    LBLSICIL.Value = @"Sicil Nu";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 35, 159, 40, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#PNAME#} {#PSURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 40, 159, 45, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FATHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 27, 159, 35, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 45, 159, 50, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.DrawStyle = DrawStyleConstants.vbSolid;
                    SINIFRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 50, 159, 55, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 58, 68, false);
                    NewField33.Name = "NewField33";
                    NewField33.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField33.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField33.MultiLine = EvetHayirEnum.ehEvet;
                    NewField33.WordBreak = EvetHayirEnum.ehEvet;
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.Value = @"Devamlı Adresi";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 60, 159, 68, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FillStyle = FillStyleConstants.vbFSTransparent;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 8;
                    ADRES.Value = @"{#ADRES#}";

                    DTYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 55, 159, 60, false);
                    DTYER.Name = "DTYER";
                    DTYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DTYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTYER.TextFormat = @"Short Date";
                    DTYER.MultiLine = EvetHayirEnum.ehEvet;
                    DTYER.WordBreak = EvetHayirEnum.ehEvet;
                    DTYER.TextFont.Name = "Arial Narrow";
                    DTYER.TextFont.Size = 8;
                    DTYER.Value = @"{#DTARIHI#}";

                    EMIRTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 73, 197, 78, false);
                    EMIRTARIHI.Name = "EMIRTARIHI";
                    EMIRTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHI.TextFormat = @"dd\-mm\-yyyy";
                    EMIRTARIHI.TextFont.Name = "Arial Narrow";
                    EMIRTARIHI.TextFont.Size = 8;
                    EMIRTARIHI.Value = @"{#EVRAKTARIHI#}";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 78, 58, 83, false);
                    NewField40.Name = "NewField40";
                    NewField40.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField40.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField40.MultiLine = EvetHayirEnum.ehEvet;
                    NewField40.WordBreak = EvetHayirEnum.ehEvet;
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.Value = @"Emir Şube ve Nu";

                    EMIRNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 78, 197, 83, false);
                    EMIRNO.Name = "EMIRNO";
                    EMIRNO.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRNO.TextFont.Name = "Arial Narrow";
                    EMIRNO.TextFont.Size = 8;
                    EMIRNO.Value = @"{#EVRAKSAYISI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 14, 159, 22, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 58, 27, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.Value = @"Rapor Tarihi";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 58, 35, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.Value = @"Birlik";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 88, 58, 97, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.MultiLine = EvetHayirEnum.ehEvet;
                    NewField51.WordBreak = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.Value = @"Muayene ve tetkik yapan servis ve  laboratuvarlar";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 88, 197, 97, false);
                    NewField52.Name = "NewField52";
                    NewField52.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField52.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField52.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField52.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField52.TextFont.Name = "Arial Narrow";
                    NewField52.Value = @"BULGULAR";

                    HEADER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 197, 13, false);
                    HEADER2.Name = "HEADER2";
                    HEADER2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER2.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER2.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER2.TextFont.Name = "Arial Narrow";
                    HEADER2.TextFont.Bold = true;
                    HEADER2.Value = @"PERİYODİK MUAYENE RAPORU";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 39, 189, 49, false);
                    FOTO.Name = "FOTO";
                    FOTO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTO.TextFont.Name = "Arial Narrow";
                    FOTO.TextFont.Bold = true;
                    FOTO.Value = @"FOTOĞRAF";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    FOTOGRAF.CalcValue = FOTOGRAF.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    MAKSAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    MAKAM.CalcValue = @"";
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField25.CalcValue = NewField25.Value;
                    LBLSICIL.CalcValue = LBLSICIL.Value;
                    NAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    FATHERNAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    NewField33.CalcValue = NewField33.Value;
                    ADRES.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adres) : "");
                    DTYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    EMIRTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField40.CalcValue = NewField40.Value;
                    EMIRNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "");
                    RAPORNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField51.CalcValue = NewField51.Value;
                    NewField52.CalcValue = NewField52.Value;
                    HEADER2.CalcValue = HEADER2.Value;
                    FOTO.CalcValue = FOTO.Value;
                    return new TTReportObject[] { NewField3,FOTOGRAF,NewField21,NewField5,NewField6,NewField7,MAKSAD,MAKAM,RAPORTARIHI,NewField22,NewField23,NewField25,LBLSICIL,NAME,FATHERNAME,BIRLIK,SINIFRUTBE,SICILNO,NewField33,ADRES,DTYER,EMIRTARIHI,NewField40,EMIRNO,RAPORNO,NewField2,NewField24,NewField51,NewField52,HEADER2,FOTO};
                }

                public override void RunScript()
                {
#region ANA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPeriodicExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
//            
//            MilitaryClassDefinitions pMilClass = hc.Episode.MyMilitaryClass();
//            RankDefinitions pRank = hc.Episode.MyRank();
//            
//            this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
#endregion ANA HEADER_Script
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ANAGroup ANA;

        public partial class OLCUMGroup : TTReportGroup
        {
            public HCPeriodicExaminationReport MyParentReport
            {
                get { return (HCPeriodicExaminationReport)ParentReport; }
            }

            new public OLCUMGroupHeader Header()
            {
                return (OLCUMGroupHeader)_header;
            }

            new public OLCUMGroupFooter Footer()
            {
                return (OLCUMGroupFooter)_footer;
            }

            public TTReportField PATINFO { get {return Header().PATINFO;} }
            public TTReportField MADDEKARAR { get {return Footer().MADDEKARAR;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField MADDE { get {return Footer().MADDE;} }
            public TTReportField DECISIONTIME { get {return Footer().DECISIONTIME;} }
            public OLCUMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OLCUMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new OLCUMGroupHeader(this);
                _footer = new OLCUMGroupFooter(this);

            }

            public partial class OLCUMGroupHeader : TTReportSection
            {
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                
                public TTReportField PATINFO; 
                public OLCUMGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 194, 7, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATINFO.CalcValue = @"";
                    return new TTReportObject[] { PATINFO};
                }
            }
            public partial class OLCUMGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                
                public TTReportField MADDEKARAR;
                public TTReportField NewField3;
                public TTReportField MADDE;
                public TTReportField DECISIONTIME; 
                public OLCUMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MADDEKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 197, 38, false);
                    MADDEKARAR.Name = "MADDEKARAR";
                    MADDEKARAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MADDEKARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    MADDEKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEKARAR.TextFont.Name = "Arial Narrow";
                    MADDEKARAR.TextFont.Size = 9;
                    MADDEKARAR.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 197, 5, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"KARAR";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 5, 238, 10, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR/";
                    MADDE.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 11, 238, 16, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MADDEKARAR.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    MADDE.CalcValue = @"";
                    DECISIONTIME.CalcValue = @"";
                    return new TTReportObject[] { MADDEKARAR,NewField3,MADDE,DECISIONTIME};
                }

                public override void RunScript()
                {
#region OLCUM FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPeriodicExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    this.MADDE.CalcValue += "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]";
                
                this.MADDEKARAR.CalcValue = this.MADDE.CalcValue + "\r\n";
            }
            
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.MADDEKARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.MADDEKARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.MADDEKARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString());                    
            }
#endregion OLCUM FOOTER_Script
                }
            }

        }

        public OLCUMGroup OLCUM;

        public partial class MAINGroup : TTReportGroup
        {
            public HCPeriodicExaminationReport MyParentReport
            {
                get { return (HCPeriodicExaminationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField YENIBOLUM { get {return Body().YENIBOLUM;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportField BOLUMRAPORDR { get {return Body().BOLUMRAPORDR;} }
            public TTReportField BOLUMRAPOR1 { get {return Body().BOLUMRAPOR1;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField BOLUMRAPOR2 { get {return Body().BOLUMRAPOR2;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>("GetHCExaminationByMasterAction", HealthCommitteeExamination.GetHCExaminationByMasterAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCPeriodicExaminationReport MyParentReport
                {
                    get { return (HCPeriodicExaminationReport)ParentReport; }
                }
                
                public TTReportField YENIBOLUM;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportField BOLUMRAPOR;
                public TTReportField BOLUMRAPORDR;
                public TTReportField BOLUMRAPOR1;
                public TTReportField RAPORTARIHI;
                public TTReportField OBJECTID;
                public TTReportField BOLUMRAPOR2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    YENIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 57, 14, false);
                    YENIBOLUM.Name = "YENIBOLUM";
                    YENIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIBOLUM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YENIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YENIBOLUM.NoClip = EvetHayirEnum.ehEvet;
                    YENIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YENIBOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YENIBOLUM.TextFont.Name = "Arial Narrow";
                    YENIBOLUM.TextFont.Size = 7;
                    YENIBOLUM.Value = @"{#BOLUM#} ({#RAPORNO#} / {%RAPORTARIHI%}) Raporu";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 58, 0, 58, 15, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 0, 197, 15, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 15, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine3.ExtendTo = ExtendToEnum.extPageHeight;

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 1, 163, 14, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 7;
                    BOLUMRAPOR.Value = @"";

                    BOLUMRAPORDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 1, 196, 14, false);
                    BOLUMRAPORDR.Name = "BOLUMRAPORDR";
                    BOLUMRAPORDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPORDR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPORDR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPORDR.TextFont.Size = 7;
                    BOLUMRAPORDR.Value = @"";

                    BOLUMRAPOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 4, 320, 10, false);
                    BOLUMRAPOR1.Name = "BOLUMRAPOR1";
                    BOLUMRAPOR1.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPOR1.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR1.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR1.TextFont.Size = 7;
                    BOLUMRAPOR1.Value = @"                              {#DOKTORADI#}
                              {#DOKTORSINIFI#} {#DOKTORRUTBE#}
                              {#DOKTORUNVAN#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 4, 238, 9, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 4, 267, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    BOLUMRAPOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 324, 4, 372, 10, false);
                    BOLUMRAPOR2.Name = "BOLUMRAPOR2";
                    BOLUMRAPOR2.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPOR2.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR2.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR2.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR2.TextFont.Size = 7;
                    BOLUMRAPOR2.Value = @"{#DOKTORADI#}
{#DOKTORSINIFI#} {#DOKTORRUTBE#}
{#DOKTORUNVAN#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExaminationByMasterAction_Class dataset_GetHCExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(0);
                    RAPORTARIHI.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raportarihi) : "");
                    YENIBOLUM.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Bolum) : "") + @" (" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raporno) : "") + @" / " + MyParentReport.MAIN.RAPORTARIHI.FormattedValue + @") Raporu";
                    BOLUMRAPOR.CalcValue = @"";
                    BOLUMRAPORDR.CalcValue = @"";
                    BOLUMRAPOR1.CalcValue = @"                              " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktoradi) : "") + @"
                              " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorsinifi) : "") + @" " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorrutbe) : "") + @"
                              " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorunvan) : "");
                    OBJECTID.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.ObjectID) : "");
                    BOLUMRAPOR2.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktoradi) : "") + @"
" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorsinifi) : "") + @" " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorrutbe) : "") + @"
" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorunvan) : "");
                    return new TTReportObject[] { RAPORTARIHI,YENIBOLUM,BOLUMRAPOR,BOLUMRAPORDR,BOLUMRAPOR1,OBJECTID,BOLUMRAPOR2};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //this.BOLUMRAPOR1.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(this.BOLUMRAPOR.Value);
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            HealthCommitteeExamination hcp = (HealthCommitteeExamination)context.GetObject(new Guid(sObjectID),"HealthCommitteeExamination");

            if (hcp.MatterSliceAnectodes.Count > 0)
            {
                string maddeDilimFikra = "[";
                foreach(HealthCommitteeExamination_MatterSliceAnectodeGrid msa in hcp.MatterSliceAnectodes)
                {
                    maddeDilimFikra += msa.Matter + "/" + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(msa.Slice).DisplayText + "/" + msa.Anectode;
                    maddeDilimFikra += "  ";
                    
                }
                maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                maddeDilimFikra = maddeDilimFikra + "]";
                
                this.BOLUMRAPOR.CalcValue = maddeDilimFikra + "\r\n";
            }
            
            if (hcp.Report != null)
                this.BOLUMRAPOR.CalcValue = this.BOLUMRAPOR.CalcValue + TTObjectClasses.Common.GetTextOfRTFString(hcp.Report.ToString());
            
            this.BOLUMRAPORDR.CalcValue =  this.BOLUMRAPOR2.CalcValue;
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

        public HCPeriodicExaminationReport()
        {
            ARKASAYFA = new ARKASAYFAGroup(this,"ARKASAYFA");
            ANA = new ANAGroup(ARKASAYFA,"ANA");
            OLCUM = new OLCUMGroup(ANA,"OLCUM");
            MAIN = new MAINGroup(OLCUM,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "FFF565B8-229C-486A-8D48-123D35C9D4D1", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCPERIODICEXAMINATIONREPORT";
            Caption = "Sağlık Kurulu Periodik Muayene Raporu";
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