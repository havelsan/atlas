
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
    /// Sağlık Kurulu Sürücü Olur Raporu
    /// </summary>
    public partial class HCDriverLicenseReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("C7203EFB-0742-4709-9E32-6D3608F9C34F");
        }

        public partial class ANAGroup : TTReportGroup
        {
            public HCDriverLicenseReport MyParentReport
            {
                get { return (HCDriverLicenseReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField NewField53 { get {return Header().NewField53;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField MAKSAD { get {return Header().MAKSAD;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField DTYER { get {return Header().DTYER;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField52 { get {return Header().NewField52;} }
            public TTReportField ACTID { get {return Header().ACTID;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField MOTHERNAME { get {return Header().MOTHERNAME;} }
            public TTReportField YAZI { get {return Header().YAZI;} }
            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField NewField36 { get {return Header().NewField36;} }
            public TTReportField MADDEKARAR { get {return Header().MADDEKARAR;} }
            public TTReportField NewField38 { get {return Header().NewField38;} }
            public TTReportField NewField41 { get {return Header().NewField41;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField MADDE { get {return Header().MADDE;} }
            public TTReportField KARAR { get {return Header().KARAR;} }
            public TTReportField BASTABIP { get {return Header().BASTABIP;} }
            public TTReportField DECISIONTIME { get {return Header().DECISIONTIME;} }
            public TTReportShape shape6 { get {return Footer().shape6;} }
            public TTReportField BASTABIP2 { get {return Footer().BASTABIP2;} }
            public TTReportField SAGLIKMD { get {return Footer().SAGLIKMD;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
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
                public HCDriverLicenseReport MyParentReport
                {
                    get { return (HCDriverLicenseReport)ParentReport; }
                }
                
                public TTReportField NewField53;
                public TTReportField NewField4;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField MAKSAD;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField DTYER;
                public TTReportField NewField21;
                public TTReportField RAPORNO;
                public TTReportField NewField2;
                public TTReportField NewField51;
                public TTReportField NewField52;
                public TTReportField ACTID;
                public TTReportField XXXXXXBASLIK;
                public TTReportField MOTHERNAME;
                public TTReportField YAZI;
                public TTReportField TANI;
                public TTReportField NewField36;
                public TTReportField MADDEKARAR;
                public TTReportField NewField38;
                public TTReportField NewField41;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField OBJECTID;
                public TTReportField MADDE;
                public TTReportField KARAR;
                public TTReportField BASTABIP;
                public TTReportField DECISIONTIME; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 114;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 25, 196, 61, false);
                    NewField53.Name = "NewField53";
                    NewField53.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField53.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField53.DrawWidth = 2;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 48, 29, 56, false);
                    NewField4.Name = "NewField4";
                    NewField4.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.Value = @"Anne Adı            :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 63, 176, 68, false);
                    NewField6.Name = "NewField6";
                    NewField6.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.Value = @"Rapor Numarası :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 69, 196, 74, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.Value = @"Ne maksatla muayene edildiği  :";

                    MAKSAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 69, 196, 74, false);
                    MAKSAD.Name = "MAKSAD";
                    MAKSAD.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKSAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKSAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAKSAD.MultiLine = EvetHayirEnum.ehEvet;
                    MAKSAD.WordBreak = EvetHayirEnum.ehEvet;
                    MAKSAD.TextFont.Name = "Arial Narrow";
                    MAKSAD.Value = @"{#SKSEBEBI#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 63, 153, 68, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 33, 29, 40, false);
                    NewField22.Name = "NewField22";
                    NewField22.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.Value = @"Adı Soyadı         :";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 40, 29, 48, false);
                    NewField23.Name = "NewField23";
                    NewField23.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.Value = @"Baba Adı            :";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 33, 106, 40, false);
                    NAME.Name = "NAME";
                    NAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.Value = @"{#PNAME#} {#PSURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 40, 106, 48, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FATHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    DTYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 56, 106, 61, false);
                    DTYER.Name = "DTYER";
                    DTYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTYER.TextFormat = @"Short Date";
                    DTYER.MultiLine = EvetHayirEnum.ehEvet;
                    DTYER.WordBreak = EvetHayirEnum.ehEvet;
                    DTYER.TextFont.Name = "Arial Narrow";
                    DTYER.Value = @"{#DTARIHI#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 56, 29, 61, false);
                    NewField21.Name = "NewField21";
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.Value = @"D. Tarihi            :";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 63, 205, 68, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 63, 127, 68, false);
                    NewField2.Name = "NewField2";
                    NewField2.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.Value = @"Rapor Tarihi :";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 105, 38, 114, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.MultiLine = EvetHayirEnum.ehEvet;
                    NewField51.WordBreak = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.Value = @"Muayene ve tetkik yapan servis ve laboratuvarlar";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 105, 196, 114, false);
                    NewField52.Name = "NewField52";
                    NewField52.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField52.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField52.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField52.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField52.TextFont.Name = "Arial Narrow";
                    NewField52.Value = @"BULGULAR";

                    ACTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 26, 196, 30, false);
                    ACTID.Name = "ACTID";
                    ACTID.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTID.TextFont.Name = "Arial Narrow";
                    ACTID.Value = @"{#ISLEMNO#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 4, 147, 24, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.Value = @"{%ANA.SITENAME%} {%ANA.SITECITY%}";

                    MOTHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 48, 106, 56, false);
                    MOTHERNAME.Name = "MOTHERNAME";
                    MOTHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    MOTHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MOTHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MOTHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MOTHERNAME.TextFont.Name = "Arial Narrow";
                    MOTHERNAME.Value = @"{#ANAADI#}";

                    YAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 74, 196, 105, false);
                    YAZI.Name = "YAZI";
                    YAZI.DrawStyle = DrawStyleConstants.vbSolid;
                    YAZI.FillStyle = FillStyleConstants.vbFSTransparent;
                    YAZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZI.MultiLine = EvetHayirEnum.ehEvet;
                    YAZI.WordBreak = EvetHayirEnum.ehEvet;
                    YAZI.TextFont.Name = "Arial Narrow";
                    YAZI.Value = @"Yukarıda açık kimliği yazılı {#PNAME#} {#PSURNAME#} nın 2918 sayılı karayolları trafik kanununun 4199 sayılı kanunla değişik 41 nci maddesi ve 18/07/1997 ve 23053 sayılı mükerrer resmi gazetede yayınlanan karayolları trafik yönetmeliğinin 78 nci maddesi ile bu yönetmeliğe ekli 3 sayılı cetvelde belirtilen hususlara uygun olarak muayenesi yapılmış olup, kurulumuz oybirliği-oyçokluğu ile aşağıdaki karara varmıştır.";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 87, 196, 96, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 87, 22, 96, false);
                    NewField36.Name = "NewField36";
                    NewField36.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField36.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField36.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField36.TextFont.Name = "Arial Narrow";
                    NewField36.Value = @"Tanı";

                    MADDEKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 96, 196, 105, false);
                    MADDEKARAR.Name = "MADDEKARAR";
                    MADDEKARAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MADDEKARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    MADDEKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEKARAR.TextFont.Name = "Arial Narrow";
                    MADDEKARAR.TextFont.Size = 8;
                    MADDEKARAR.Value = @"{%ANA.MADDE%} {%ANA.KARAR%}";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 96, 22, 105, false);
                    NewField38.Name = "NewField38";
                    NewField38.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField38.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField38.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField38.TextFont.Name = "Arial Narrow";
                    NewField38.Value = @"Karar(*)";

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 26, 126, 33, false);
                    NewField41.Name = "NewField41";
                    NewField41.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField41.MultiLine = EvetHayirEnum.ehEvet;
                    NewField41.WordBreak = EvetHayirEnum.ehEvet;
                    NewField41.TextFont.Name = "Arial Narrow";
                    NewField41.TextFont.Size = 14;
                    NewField41.TextFont.Bold = true;
                    NewField41.Value = @"SÜRÜCÜ OLUR RAPORU";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 31, 239, 36, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 37, 239, 42, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 25, 239, 30, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{@TTOBJECTID@}";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 51, 239, 56, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 57, 239, 62, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.Value = @"";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 75, 239, 80, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.Visible = EvetHayirEnum.ehHayir;
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 86, 239, 91, false);
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
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    NewField53.CalcValue = NewField53.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    MAKSAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    FATHERNAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    DTYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    NewField21.CalcValue = NewField21.Value;
                    RAPORNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField51.CalcValue = NewField51.Value;
                    NewField52.CalcValue = NewField52.Value;
                    ACTID.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    XXXXXXBASLIK.CalcValue = MyParentReport.ANA.SITENAME.CalcValue + @" " + MyParentReport.ANA.SITECITY.CalcValue;
                    MOTHERNAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Anaadi) : "");
                    YAZI.CalcValue = @"Yukarıda açık kimliği yazılı " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "") + @" nın 2918 sayılı karayolları trafik kanununun 4199 sayılı kanunla değişik 41 nci maddesi ve 18/07/1997 ve 23053 sayılı mükerrer resmi gazetede yayınlanan karayolları trafik yönetmeliğinin 78 nci maddesi ile bu yönetmeliğe ekli 3 sayılı cetvelde belirtilen hususlara uygun olarak muayenesi yapılmış olup, kurulumuz oybirliği-oyçokluğu ile aşağıdaki karara varmıştır.";
                    TANI.CalcValue = @"";
                    NewField36.CalcValue = NewField36.Value;
                    MADDEKARAR.CalcValue = MyParentReport.ANA.MADDE.CalcValue + @" " + MyParentReport.ANA.KARAR.CalcValue;
                    NewField38.CalcValue = NewField38.Value;
                    NewField41.CalcValue = NewField41.Value;
                    OBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    MADDE.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    BASTABIP.CalcValue = @"";
                    DECISIONTIME.CalcValue = @"";
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    return new TTReportObject[] { NewField53,NewField4,NewField6,NewField7,MAKSAD,RAPORTARIHI,NewField22,NewField23,NAME,FATHERNAME,DTYER,NewField21,RAPORNO,NewField2,NewField51,NewField52,ACTID,XXXXXXBASLIK,MOTHERNAME,YAZI,TANI,NewField36,MADDEKARAR,NewField38,NewField41,OBJECTID,MADDE,KARAR,BASTABIP,DECISIONTIME,SITENAME,SITECITY};
                }

                public override void RunScript()
                {
#region ANA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCDriverLicenseReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            //Madde-Dilim-Fıkra
            string sCrLf = "\r\n";
            this.MADDE.CalcValue = "[";
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = null;
            theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
            {
                this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                this.MADDE.CalcValue += "\t";
            }
            this.MADDE.CalcValue += "]";
            
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue +=TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString());
            }
            
            
            //Baştabip
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.ChiefOfMedicine)
                {
                    string sMaster = "";
                    string sinif = member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.Name;
                    string sic = member.MemberDoctor.EmploymentRecordID;
                    string rut = member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.Name;

                    sMaster += "" + sCrLf;
                    sMaster += "" + member.MemberDoctor.Name + sCrLf;
                    sMaster += "" + sinif + " " + rut + " (" + sic + ")" + sCrLf;
                    sMaster = sMaster + "" + sCrLf;

                    this.BASTABIP.CalcValue = sMaster;
                }
            }
            
            //Tanı
            int nCount = 1;
            this.TANI.CalcValue = "";
            BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> pDiagnosis = null;
            pDiagnosis = HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID(sObjectID);
            foreach(HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class pGrid in pDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TANI.CalcValue += "\r\n";
                nCount++;
            }
#endregion ANA HEADER_Script
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public HCDriverLicenseReport MyParentReport
                {
                    get { return (HCDriverLicenseReport)ParentReport; }
                }
                
                public TTReportShape shape6;
                public TTReportField BASTABIP2;
                public TTReportField SAGLIKMD;
                public TTReportField NewField3; 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 32;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 196, 0, false);
                    shape6.Name = "shape6";
                    shape6.DrawStyle = DrawStyleConstants.vbSolid;

                    BASTABIP2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 8, 90, 25, false);
                    BASTABIP2.Name = "BASTABIP2";
                    BASTABIP2.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASTABIP2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP2.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP2.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP2.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP2.TextFont.Name = "Arial Narrow";
                    BASTABIP2.Value = @"{%ANA.BASTABIP%}";

                    SAGLIKMD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 2, 177, 7, false);
                    SAGLIKMD.Name = "SAGLIKMD";
                    SAGLIKMD.FillStyle = FillStyleConstants.vbFSTransparent;
                    SAGLIKMD.DrawWidth = 2;
                    SAGLIKMD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAGLIKMD.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKMD.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKMD.TextFont.Name = "Arial Narrow";
                    SAGLIKMD.TextFont.Bold = true;
                    SAGLIKMD.Value = @"SAĞLIK MD. ONAYI";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 64, 7, false);
                    NewField3.Name = "NewField3";
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.DrawWidth = 2;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"BAŞTABİPLİK ONAYI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    BASTABIP2.CalcValue = MyParentReport.ANA.BASTABIP.CalcValue;
                    SAGLIKMD.CalcValue = SAGLIKMD.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { BASTABIP2,SAGLIKMD,NewField3};
                }
            }

        }

        public ANAGroup ANA;

        public partial class OLCUMGroup : TTReportGroup
        {
            public HCDriverLicenseReport MyParentReport
            {
                get { return (HCDriverLicenseReport)ParentReport; }
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
            public TTReportShape shape3 { get {return Footer().shape3;} }
            public TTReportShape shape5 { get {return Footer().shape5;} }
            public TTReportField OLCUMLER { get {return Footer().OLCUMLER;} }
            public TTReportField BOY { get {return Footer().BOY;} }
            public TTReportField KILO { get {return Footer().KILO;} }
            public TTReportShape shape13 { get {return Footer().shape13;} }
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
                public HCDriverLicenseReport MyParentReport
                {
                    get { return (HCDriverLicenseReport)ParentReport; }
                }
                
                public TTReportField PATINFO; 
                public OLCUMGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 195, 5, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"{#ANA.PNAME#} ({#ANA.DTARIHI#}) {#ANA.ISLEMNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ANA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    PATINFO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" (" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "") + @") " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    return new TTReportObject[] { PATINFO};
                }
            }
            public partial class OLCUMGroupFooter : TTReportSection
            {
                public HCDriverLicenseReport MyParentReport
                {
                    get { return (HCDriverLicenseReport)ParentReport; }
                }
                
                public TTReportShape shape3;
                public TTReportShape shape5;
                public TTReportField OLCUMLER;
                public TTReportField BOY;
                public TTReportField KILO;
                public TTReportShape shape13; 
                public OLCUMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 5, 10, false);
                    shape3.Name = "shape3";
                    shape3.DrawStyle = DrawStyleConstants.vbSolid;
                    shape3.ExtendTo = ExtendToEnum.extPageHeight;

                    shape5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 0, 196, 10, false);
                    shape5.Name = "shape5";
                    shape5.DrawStyle = DrawStyleConstants.vbSolid;
                    shape5.ExtendTo = ExtendToEnum.extPageHeight;

                    OLCUMLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 2, 184, 7, false);
                    OLCUMLER.Name = "OLCUMLER";
                    OLCUMLER.FillStyle = FillStyleConstants.vbFSTransparent;
                    OLCUMLER.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUMLER.TextFont.Name = "Arial Narrow";
                    OLCUMLER.Value = @"";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 239, 5, false);
                    BOY.Name = "BOY";
                    BOY.Visible = EvetHayirEnum.ehHayir;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.Value = @"{#ANA.BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 5, 239, 10, false);
                    KILO.Name = "KILO";
                    KILO.Visible = EvetHayirEnum.ehHayir;
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.Value = @"{#ANA.KILO#}";

                    shape13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 38, 0, 38, 10, false);
                    shape13.Name = "shape13";
                    shape13.DrawStyle = DrawStyleConstants.vbSolid;
                    shape13.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ANA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    OLCUMLER.CalcValue = @"";
                    BOY.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Boy) : "");
                    KILO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kilo) : "");
                    return new TTReportObject[] { OLCUMLER,BOY,KILO};
                }

                public override void RunScript()
                {
#region OLCUM FOOTER_Script
                    string sMeasure = "";
            if(this.BOY.CalcValue != "" || this.KILO.CalcValue != "")
            {
                sMeasure = "Sağlık Kurulu Huzurunda Ölçülmüştür:";
                if(this.BOY.CalcValue != "") sMeasure += " Boy:" + this.BOY.CalcValue+" cm.";
                if(this.KILO.CalcValue != "") sMeasure += " Ağırlık:" + this.KILO.CalcValue +" kg.";
                
                this.OLCUMLER.CalcValue = sMeasure;
            }
#endregion OLCUM FOOTER_Script
                }
            }

        }

        public OLCUMGroup OLCUM;

        public partial class MAINGroup : TTReportGroup
        {
            public HCDriverLicenseReport MyParentReport
            {
                get { return (HCDriverLicenseReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportShape shape1 { get {return Body().shape1;} }
            public TTReportShape shape7 { get {return Body().shape7;} }
            public TTReportShape shape2 { get {return Body().shape2;} }
            public TTReportField NOTARIH { get {return Body().NOTARIH;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportField USERNAME { get {return Body().USERNAME;} }
            public TTReportField RAPOR { get {return Body().RAPOR;} }
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
                public HCDriverLicenseReport MyParentReport
                {
                    get { return (HCDriverLicenseReport)ParentReport; }
                }
                
                public TTReportField BOLUM;
                public TTReportShape shape1;
                public TTReportShape shape7;
                public TTReportShape shape2;
                public TTReportField NOTARIH;
                public TTReportField BOLUMRAPOR;
                public TTReportField USERNAME;
                public TTReportField RAPOR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 125, 5, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.TextFont.Name = "Arial Narrow";
                    BOLUM.TextFont.Size = 9;
                    BOLUM.Value = @"{#BOLUM#} Raporu";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 5, 19, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;
                    shape1.ExtendTo = ExtendToEnum.extPageHeight;

                    shape7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 38, 0, 38, 19, false);
                    shape7.Name = "shape7";
                    shape7.DrawStyle = DrawStyleConstants.vbSolid;
                    shape7.ExtendTo = ExtendToEnum.extPageHeight;

                    shape2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 0, 196, 19, false);
                    shape2.Name = "shape2";
                    shape2.DrawStyle = DrawStyleConstants.vbSolid;
                    shape2.ExtendTo = ExtendToEnum.extPageHeight;

                    NOTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 6, 37, 11, false);
                    NOTARIH.Name = "NOTARIH";
                    NOTARIH.FillStyle = FillStyleConstants.vbFSTransparent;
                    NOTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTARIH.TextFont.Name = "Arial Narrow";
                    NOTARIH.TextFont.Size = 9;
                    NOTARIH.Value = @"({#RAPORNO#}/{#RAPORTARIHI#})";

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 6, 195, 19, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 9;
                    BOLUMRAPOR.Value = @"";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, -99, 233, -95, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.TextFont.Name = "Arial Narrow";
                    USERNAME.Value = @"";

                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 1, 235, 6, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.Visible = EvetHayirEnum.ehHayir;
                    RAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExaminationByMasterAction_Class dataset_GetHCExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(0);
                    BOLUM.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Bolum) : "") + @" Raporu";
                    NOTARIH.CalcValue = @"(" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raporno) : "") + @"/" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raportarihi) : "") + @")";
                    BOLUMRAPOR.CalcValue = @"";
                    USERNAME.CalcValue = @"";
                    RAPOR.CalcValue = @"";
                    return new TTReportObject[] { BOLUM,NOTARIH,BOLUMRAPOR,USERNAME,RAPOR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sDepReport = "";
            
            sDepReport += this.RAPOR.CalcValue;
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCDriverLicenseReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");

            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            this.RAPOR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hc.Report.ToString());
            if(TTObjectClasses.Common.CurrentResource != null)
            {
                for(int i=0;i<100;i++)
                    sDepReport += " ";
                sDepReport += TTObjectClasses.Common.CurrentResource.Name + "\r\n";
                
                for(int i=0;i<100;i++)
                    sDepReport += " ";
                sDepReport += TTObjectClasses.Common.CurrentResource.MilitaryClass == null ? "" : TTObjectClasses.Common.CurrentResource.MilitaryClass.Name + " ";
                
                //for(int i=0;i<100;i++)
                //    sDepReport += " ";
                sDepReport += TTObjectClasses.Common.CurrentResource.Rank == null ? "\r\n" : TTObjectClasses.Common.CurrentResource.Rank.Name + "\r\n";
                
                sDepReport += " (" + TTObjectClasses.Common.CurrentResource.EmploymentRecordID + ")";
            }
            
            this.BOLUMRAPOR.CalcValue = sDepReport;
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

        public HCDriverLicenseReport()
        {
            ANA = new ANAGroup(this,"ANA");
            OLCUM = new OLCUMGroup(ANA,"OLCUM");
            MAIN = new MAINGroup(OLCUM,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "C7203EFB-0742-4709-9E32-6D3608F9C34F", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCDRIVERLICENSEREPORT";
            Caption = "Sağlık Kurulu Sürücü Olur Raporu";
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