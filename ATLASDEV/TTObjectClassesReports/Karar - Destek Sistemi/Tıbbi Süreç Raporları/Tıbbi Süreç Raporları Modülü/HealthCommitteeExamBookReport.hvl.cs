
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
    /// Sağlık Kurulu Defteri - Klinikler
    /// </summary>
    public partial class HealthCommitteeExamBookReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string MRES = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> RESOURCE = new List<string>();
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public HealthCommitteeExamBookReport MyParentReport
            {
                get { return (HealthCommitteeExamBookReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            List<String> resourceList = new List<String>();
            String objectid = ((HealthCommitteeExamBookReport)ParentReport).RuntimeParameters.MRES.ToString();
            ResSection section = (ResSection)objectContext.GetObject(new Guid(objectid), "ResSection"); 
            resourceList.Add(objectid); 
            if (section is ResDepartment)
            {
                ResDepartment resDep = (ResDepartment)section;
                foreach (ResPoliclinic resPol in resDep.Policlinics)
                    resourceList.Add(resPol.ObjectID.ToString());
                foreach (ResClinic resCli in resDep.Clinics)
                    resourceList.Add(resCli.ObjectID.ToString());
                foreach (ResObservationUnit resObs in resDep.ObservationUnits)
                    resourceList.Add(resObs.ObjectID.ToString());
                foreach (ResTreatmentDiagnosisUnit resTre in resDep.TreatmentDiagnosisUnits)
                    resourceList.Add(resTre.ObjectID.ToString());
            }
            
            ((HealthCommitteeExamBookReport)ParentReport).RuntimeParameters.RESOURCE = resourceList;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class CAPTIONGroup : TTReportGroup
        {
            public HealthCommitteeExamBookReport MyParentReport
            {
                get { return (HealthCommitteeExamBookReport)ParentReport; }
            }

            new public CAPTIONGroupHeader Header()
            {
                return (CAPTIONGroupHeader)_header;
            }

            new public CAPTIONGroupFooter Footer()
            {
                return (CAPTIONGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField CLINIC { get {return Header().CLINIC;} }
            public TTReportField COUNT { get {return Footer().COUNT;} }
            public TTReportField NewField1113111 { get {return Footer().NewField1113111;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public CAPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CAPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new CAPTIONGroupHeader(this);
                _footer = new CAPTIONGroupFooter(this);

            }

            public partial class CAPTIONGroupHeader : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField2;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField151;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField141;
                public TTReportField NewField1151;
                public TTReportField CLINIC; 
                public CAPTIONGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 13, 192, 21, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SAĞLIK KURULU DEFTERİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 23, 38, 28, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Başlangıç Tarihi";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 28, 38, 33, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Bitiş Tarihi";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 23, 39, 28, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 39, 33, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 23, 80, 28, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 28, 80, 33, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 33, 38, 38, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Birim";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 33, 39, 38, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @":";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 33, 135, 38, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINIC.TextFormat = @"Short Date";
                    CLINIC.ObjectDefName = "Resource";
                    CLINIC.DataMember = "NAME";
                    CLINIC.Value = @"{@MRES@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField151.CalcValue = NewField151.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField141.CalcValue = NewField141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    CLINIC.CalcValue = MyParentReport.RuntimeParameters.MRES.ToString();
                    CLINIC.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField11,NewField2,NewField14,NewField15,NewField151,STARTDATE,ENDDATE,NewField141,NewField1151,CLINIC};
                }
            }
            public partial class CAPTIONGroupFooter : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField NewField1113111;
                public TTReportShape NewLine1; 
                public CAPTIONGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 2, 284, 7, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COUNT.Value = @"";

                    NewField1113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 2, 258, 7, false);
                    NewField1113111.Name = "NewField1113111";
                    NewField1113111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1113111.TextFont.Size = 8;
                    NewField1113111.TextFont.Bold = true;
                    NewField1113111.TextFont.CharSet = 162;
                    NewField1113111.Value = @"Toplam Sağlık Kurulu İşlem Sayısı :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 214, 1, 284, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COUNT.CalcValue = @"";
                    NewField1113111.CalcValue = NewField1113111.Value;
                    return new TTReportObject[] { COUNT,NewField1113111};
                }

                public override void RunScript()
                {
#region CAPTION FOOTER_Script
                    if(((HealthCommitteeExamBookReport)ParentReport).MAIN.GroupCounter == 0)
                this.COUNT.CalcValue = "0";
            else if(((HealthCommitteeExamBookReport)ParentReport).MAIN.GroupCounter > 0)
                this.COUNT.CalcValue = (((HealthCommitteeExamBookReport)ParentReport).MAIN.GroupCounter -1).ToString();
#endregion CAPTION FOOTER_Script
                }
            }

        }

        public CAPTIONGroup CAPTION;

        public partial class BASLIKGroup : TTReportGroup
        {
            public HealthCommitteeExamBookReport MyParentReport
            {
                get { return (HealthCommitteeExamBookReport)ParentReport; }
            }

            new public BASLIKGroupHeader Header()
            {
                return (BASLIKGroupHeader)_header;
            }

            new public BASLIKGroupFooter Footer()
            {
                return (BASLIKGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField NewField1431 { get {return Header().NewField1431;} }
            public TTReportShape NewLine111211111111111 { get {return Footer().NewLine111211111111111;} }
            public BASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new BASLIKGroupHeader(this);
                _footer = new BASLIKGroupFooter(this);

            }

            public partial class BASLIKGroupHeader : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField1231;
                public TTReportField NewField1331;
                public TTReportField NewField1431; 
                public BASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 29, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Rapor Nu ve Tarihi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 2, 65, 13, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Muayeneye Gönderen Makam Tarih ve Nu";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 2, 103, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"AÇIK KÜNYESİ";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 2, 168, 13, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"RAPOR";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 2, 204, 13, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1231.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1231.TextFont.Bold = true;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"TEŞHİS";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 2, 249, 13, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1331.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1331.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"KARAR";

                    NewField1431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 2, 284, 13, false);
                    NewField1431.Name = "NewField1431";
                    NewField1431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1431.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1431.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1431.TextFont.Bold = true;
                    NewField1431.TextFont.CharSet = 162;
                    NewField1431.Value = @"FOTOĞRAF";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField1431.CalcValue = NewField1431.Value;
                    return new TTReportObject[] { NewField11,NewField121,NewField131,NewField1131,NewField1231,NewField1331,NewField1431};
                }
            }
            public partial class BASLIKGroupFooter : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                
                public TTReportShape NewLine111211111111111; 
                public BASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine111211111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 16, 10, 286, 10, false);
                    NewLine111211111111111.Name = "NewLine111211111111111";
                    NewLine111211111111111.ForeColor = System.Drawing.Color.White;
                    NewLine111211111111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public BASLIKGroup BASLIK;

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeExamBookReport MyParentReport
            {
                get { return (HealthCommitteeExamBookReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportShape NewLine11111111111211 { get {return Footer().NewLine11111111111211;} }
            public TTReportShape NewLine111211 { get {return Footer().NewLine111211;} }
            public TTReportShape NewLine111311 { get {return Footer().NewLine111311;} }
            public TTReportShape NewLine111411 { get {return Footer().NewLine111411;} }
            public TTReportShape NewLine111511 { get {return Footer().NewLine111511;} }
            public TTReportShape NewLine111611 { get {return Footer().NewLine111611;} }
            public TTReportShape NewLine111711 { get {return Footer().NewLine111711;} }
            public TTReportShape NewLine1116111 { get {return Footer().NewLine1116111;} }
            public TTReportShape NewLine1126111 { get {return Footer().NewLine1126111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111111111211;
                public TTReportShape NewLine111211;
                public TTReportShape NewLine111311;
                public TTReportShape NewLine111411;
                public TTReportShape NewLine111511;
                public TTReportShape NewLine111611;
                public TTReportShape NewLine111711;
                public TTReportShape NewLine1116111;
                public TTReportShape NewLine1126111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11111111111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 3, 284, 3, false);
                    NewLine11111111111211.Name = "NewLine11111111111211";
                    NewLine11111111111211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 29, 0, 29, 3, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 3, false);
                    NewLine111311.Name = "NewLine111311";
                    NewLine111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 0, 65, 3, false);
                    NewLine111411.Name = "NewLine111411";
                    NewLine111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111411.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 0, 103, 3, false);
                    NewLine111511.Name = "NewLine111511";
                    NewLine111511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111511.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111611 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 0, 204, 3, false);
                    NewLine111611.Name = "NewLine111611";
                    NewLine111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111611.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 0, 168, 3, false);
                    NewLine111711.Name = "NewLine111711";
                    NewLine111711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111711.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1116111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 249, 0, 249, 3, false);
                    NewLine1116111.Name = "NewLine1116111";
                    NewLine1116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1116111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1126111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 284, 0, 284, 3, false);
                    NewLine1126111.Name = "NewLine1126111";
                    NewLine1126111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1126111.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeExamBookReport MyParentReport
            {
                get { return (HealthCommitteeExamBookReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REPORTNODATE { get {return Body().REPORTNODATE;} }
            public TTReportField SENDERDATENO { get {return Body().SENDERDATENO;} }
            public TTReportField INFOS { get {return Body().INFOS;} }
            public TTReportField RAPOR { get {return Body().RAPOR;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField FOTO { get {return Body().FOTO;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField AGIRLIK { get {return Body().AGIRLIK;} }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetHCExamsByMResource_Class>("GetHCExamsByMResource", HealthCommitteeExamination.GetHCExamsByMResource((List<string>) MyParentReport.RuntimeParameters.RESOURCE,(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public HealthCommitteeExamBookReport MyParentReport
                {
                    get { return (HealthCommitteeExamBookReport)ParentReport; }
                }
                
                public TTReportField REPORTNODATE;
                public TTReportField SENDERDATENO;
                public TTReportField INFOS;
                public TTReportField RAPOR;
                public TTReportField TESHIS;
                public TTReportField KARAR;
                public TTReportField FOTO;
                public TTReportField OBJECTID;
                public TTReportField NAMESURNAME;
                public TTReportField FATHERNAME;
                public TTReportField TCNO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportField BOY;
                public TTReportField AGIRLIK;
                public TTReportField COUNTER; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    REPORTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 29, 25, false);
                    REPORTNODATE.Name = "REPORTNODATE";
                    REPORTNODATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNODATE.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNODATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNODATE.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNODATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTNODATE.TextFont.Size = 9;
                    REPORTNODATE.TextFont.CharSet = 162;
                    REPORTNODATE.Value = @"{#RAPORNO#} - {#RAPORTARIHI#}";

                    SENDERDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 65, 25, false);
                    SENDERDATENO.Name = "SENDERDATENO";
                    SENDERDATENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERDATENO.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERDATENO.NoClip = EvetHayirEnum.ehEvet;
                    SENDERDATENO.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERDATENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SENDERDATENO.TextFont.Size = 9;
                    SENDERDATENO.TextFont.CharSet = 162;
                    SENDERDATENO.Value = @"";

                    INFOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 103, 25, false);
                    INFOS.Name = "INFOS";
                    INFOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOS.MultiLine = EvetHayirEnum.ehEvet;
                    INFOS.NoClip = EvetHayirEnum.ehEvet;
                    INFOS.WordBreak = EvetHayirEnum.ehEvet;
                    INFOS.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFOS.TextFont.Size = 9;
                    INFOS.TextFont.CharSet = 162;
                    INFOS.Value = @"{%NAMESURNAME%} T.C. No: {%TCNO%} Baba Adı: {%FATHERNAME%}";

                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 0, 168, 25, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    RAPOR.NoClip = EvetHayirEnum.ehEvet;
                    RAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    RAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPOR.TextFont.Size = 8;
                    RAPOR.TextFont.CharSet = 162;
                    RAPOR.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 204, 25, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.NoClip = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Size = 9;
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 0, 249, 25, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"{#KARAR#}";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 0, 284, 25, false);
                    FOTO.Name = "FOTO";
                    FOTO.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOTO.TextFont.Size = 9;
                    FOTO.TextFont.CharSet = 162;
                    FOTO.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 8, 326, 13, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECT_ID#}";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 14, 326, 19, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.Visible = EvetHayirEnum.ehHayir;
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.ObjectDefName = "Patient";
                    NAMESURNAME.DataMember = "FullName";
                    NAMESURNAME.Value = @"{#PATIENTOBJECTID#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 20, 326, 25, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.Visible = EvetHayirEnum.ehHayir;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.ObjectDefName = "Patient";
                    FATHERNAME.DataMember = "FATHERNAME";
                    FATHERNAME.Value = @"{#PATIENTOBJECTID#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 26, 326, 31, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.ObjectDefName = "Patient";
                    TCNO.DataMember = "UNIQUEREFNO";
                    TCNO.Value = @"{#PATIENTOBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 35, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 29, 0, 29, 35, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 0, 65, 35, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, -1, 103, 34, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 0, 168, 35, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 0, 204, 35, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 249, 0, 249, 35, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 284, 0, 284, 35, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 284, 0, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 333, 17, 344, 24, false);
                    BOY.Name = "BOY";
                    BOY.Visible = EvetHayirEnum.ehHayir;
                    BOY.DrawStyle = DrawStyleConstants.vbSolid;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.TextFont.Size = 9;
                    BOY.TextFont.CharSet = 162;
                    BOY.Value = @"{#BOY#}";

                    AGIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 344, 17, 355, 24, false);
                    AGIRLIK.Name = "AGIRLIK";
                    AGIRLIK.Visible = EvetHayirEnum.ehHayir;
                    AGIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    AGIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGIRLIK.TextFont.Size = 9;
                    AGIRLIK.TextFont.CharSet = 162;
                    AGIRLIK.Value = @"{#KILO#}";

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 332, 11, 357, 16, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.Visible = EvetHayirEnum.ehHayir;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExamsByMResource_Class dataset_GetHCExamsByMResource = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExamsByMResource_Class>(0);
                    REPORTNODATE.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Raporno) : "") + @" - " + (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Raportarihi) : "");
                    SENDERDATENO.CalcValue = @"";
                    NAMESURNAME.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Patientobjectid) : "");
                    NAMESURNAME.PostFieldValueCalculation();
                    TCNO.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Patientobjectid) : "");
                    TCNO.PostFieldValueCalculation();
                    FATHERNAME.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Patientobjectid) : "");
                    FATHERNAME.PostFieldValueCalculation();
                    INFOS.CalcValue = MyParentReport.MAIN.NAMESURNAME.CalcValue + @" T.C. No: " + MyParentReport.MAIN.TCNO.CalcValue + @" Baba Adı: " + MyParentReport.MAIN.FATHERNAME.CalcValue;
                    RAPOR.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    KARAR.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Karar) : "");
                    FOTO.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Object_id) : "");
                    BOY.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Boy) : "");
                    AGIRLIK.CalcValue = (dataset_GetHCExamsByMResource != null ? Globals.ToStringCore(dataset_GetHCExamsByMResource.Kilo) : "");
                    COUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { REPORTNODATE,SENDERDATENO,NAMESURNAME,TCNO,FATHERNAME,INFOS,RAPOR,TESHIS,KARAR,FOTO,OBJECTID,BOY,AGIRLIK,COUNTER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sObjectID = this.OBJECTID.CalcValue.ToString();
            //Tanı
            int nCount = 1;
            this.TESHIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetDiagnosisByParent_Class> pDiagnosis = DiagnosisGrid.GetDiagnosisByParent(sObjectID);
            foreach(DiagnosisGrid.GetDiagnosisByParent_Class pGrid in pDiagnosis)
            {
                this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TESHIS.CalcValue += "\r\n";
                nCount++;
            }
           
             this.INFOS.CalcValue = this.NAMESURNAME.CalcValue + " " + "\r\n";
             this.INFOS.CalcValue += "T.C. No: " + this.TCNO.CalcValue + "\r\n";
             this.INFOS.CalcValue += "Baba Adı: " + this.FATHERNAME.CalcValue + "\r\n";
             this.INFOS.CalcValue += "Boyu: " +  this.BOY.CalcValue + "\r\n";
             this.INFOS.CalcValue += "Kilosu: " +  this.AGIRLIK.CalcValue + "\r\n";
             
             HealthCommitteeExamination hce = (HealthCommitteeExamination) MyParentReport.ReportObjectContext.GetObject(new Guid(sObjectID),"HealthCommitteeExamination");
             if(hce.Report != null)
                this.RAPOR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hce.Report.ToString());
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

        public HealthCommitteeExamBookReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            CAPTION = new CAPTIONGroup(PARTB,"CAPTION");
            BASLIK = new BASLIKGroup(CAPTION,"BASLIK");
            PARTA = new PARTAGroup(BASLIK,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MRES", "", "Birim", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter.ListFilterExpression = "OBJECTDEFNAME = 'RESDEPARTMENT' or OBJECTDEFNAME = 'RESLABORATORYDEPARTMENT' or OBJECTDEFNAME = 'RESRADIOLOGYDEPARTMENT' or OBJECTDEFNAME = 'RESNUCLEARMEDICINEDEP' or OBJECTDEFNAME = 'RESTREATMENTDIAGNOSISUNIT' OR OBJECTDEFNAME = 'RESOBSERVATIONUNIT'";
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("RESOURCE", "", "Birimler", @"", false, false, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MRES"))
                _runtimeParameters.MRES = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MRES"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (List<string>)parameters["RESOURCE"];
            Name = "HEALTHCOMMITTEEEXAMBOOKREPORT";
            Caption = "Sağlık Kurulu Defteri - Klinikler";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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