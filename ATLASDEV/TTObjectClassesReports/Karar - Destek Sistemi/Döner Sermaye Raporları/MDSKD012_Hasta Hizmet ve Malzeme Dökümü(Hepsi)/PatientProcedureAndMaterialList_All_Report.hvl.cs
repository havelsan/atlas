
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
    /// Hasta Hizmet ve Malzeme Dökümü (Hepsi)
    /// </summary>
    public partial class PatientProcedureAndMaterialList_All : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string HOSPITALPROTOCOLNO = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue("");
            public double? PROCEDURETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("");
            public double? MATERIALTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("");
            public double? DRUGTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string YEAR = TTObjectDefManager.ServerTime.Year.ToString();
        }

        public partial class PARTGGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTGGroupHeader Header()
            {
                return (PARTGGroupHeader)_header;
            }

            new public PARTGGroupFooter Footer()
            {
                return (PARTGGroupFooter)_footer;
            }

            public PARTGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTGGroupHeader(this);
                _footer = new PARTGGroupFooter(this);

            }

            public partial class PARTGGroupHeader : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                 
                public PARTGGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTG HEADER_Script
                    ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.PROCEDURETOTAL = 0;
            ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.DRUGTOTAL = 0;
            ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.MATERIALTOTAL = 0;
            
            //((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString() + " 00:00:00");
            //((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime("31.12." + DateTime.Now.Year.ToString() + " 23:59:59");
            
            ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime("01.01." + ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.YEAR + " 00:00:00");
            ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime("31.12." + ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.YEAR + " 23:59:59");
#endregion PARTG HEADER_Script
                }
            }
            public partial class PARTGGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                 
                public PARTGGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTGGroup PARTG;

        public partial class PARTBGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField HPROTOCOLNO { get {return Header().HPROTOCOLNO;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField NewField121211 { get {return Header().NewField121211;} }
            public TTReportField NewField1511121 { get {return Header().NewField1511121;} }
            public TTReportField NewField1611121 { get {return Header().NewField1611121;} }
            public TTReportField ICD10KOD { get {return Header().ICD10KOD;} }
            public TTReportField ICD10 { get {return Header().ICD10;} }
            public TTReportField NewField1112121 { get {return Header().NewField1112121;} }
            public TTReportField NewField1112122 { get {return Header().NewField1112122;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField HPROTOCOLNO;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField UNIQUEREFNO;
                public TTReportField NAME;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField11212;
                public TTReportField NewField123;
                public TTReportField OPENINGDATE;
                public TTReportField NewField121211;
                public TTReportField NewField1511121;
                public TTReportField NewField1611121;
                public TTReportField ICD10KOD;
                public TTReportField ICD10;
                public TTReportField NewField1112121;
                public TTReportField NewField1112122; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 15, 206, 20, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"HASTA HİZMET VE MALZEME DÖKÜMÜ (HEPSİ)";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 29, 27, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"H.Protokol No";

                    HPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 29, 76, 33, false);
                    HPROTOCOLNO.Name = "HPROTOCOLNO";
                    HPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOCOLNO.TextFont.Size = 8;
                    HPROTOCOLNO.TextFont.CharSet = 162;
                    HPROTOCOLNO.Value = @"{@HOSPITALPROTOCOLNO@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 21, 27, 25, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"TC Kimlik No";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 25, 27, 29, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Size = 8;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Adı Soyadı";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 21, 76, 25, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Size = 8;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 25, 153, 29, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Size = 8;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 21, 29, 25, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 25, 29, 29, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 29, 29, 33, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.TextFont.Size = 8;
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @":";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 33, 27, 37, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Size = 8;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"Açılış Tarihi";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 33, 76, 37, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFont.Size = 8;
                    OPENINGDATE.TextFont.CharSet = 162;
                    OPENINGDATE.Value = @"";

                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 33, 29, 37, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.TextFont.Size = 8;
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @":";

                    NewField1511121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 37, 27, 41, false);
                    NewField1511121.Name = "NewField1511121";
                    NewField1511121.TextFont.Size = 8;
                    NewField1511121.TextFont.Bold = true;
                    NewField1511121.TextFont.CharSet = 162;
                    NewField1511121.Value = @"ICD10 Kodu";

                    NewField1611121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 41, 27, 45, false);
                    NewField1611121.Name = "NewField1611121";
                    NewField1611121.TextFont.Size = 8;
                    NewField1611121.TextFont.Bold = true;
                    NewField1611121.TextFont.CharSet = 162;
                    NewField1611121.Value = @"ICD10 Açıklama";

                    ICD10KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 37, 191, 41, false);
                    ICD10KOD.Name = "ICD10KOD";
                    ICD10KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10KOD.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ICD10KOD.TextFont.Size = 8;
                    ICD10KOD.TextFont.CharSet = 162;
                    ICD10KOD.Value = @"";

                    ICD10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 41, 191, 51, false);
                    ICD10.Name = "ICD10";
                    ICD10.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10.TextFont.Size = 8;
                    ICD10.TextFont.CharSet = 162;
                    ICD10.Value = @"";

                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 37, 29, 41, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.TextFont.Size = 8;
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @":";

                    NewField1112122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 41, 29, 45, false);
                    NewField1112122.Name = "NewField1112122";
                    NewField1112122.TextFont.Size = 8;
                    NewField1112122.TextFont.Bold = true;
                    NewField1112122.TextFont.CharSet = 162;
                    NewField1112122.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    HPROTOCOLNO.CalcValue = MyParentReport.RuntimeParameters.HOSPITALPROTOCOLNO.ToString();
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    NAME.CalcValue = @"";
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField123.CalcValue = NewField123.Value;
                    OPENINGDATE.CalcValue = @"";
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField1511121.CalcValue = NewField1511121.Value;
                    NewField1611121.CalcValue = NewField1611121.Value;
                    ICD10KOD.CalcValue = @"";
                    ICD10.CalcValue = @"";
                    NewField1112121.CalcValue = NewField1112121.Value;
                    NewField1112122.CalcValue = NewField1112122.Value;
                    return new TTReportObject[] { NewField11,NewField12,HPROTOCOLNO,NewField121,NewField122,UNIQUEREFNO,NAME,NewField1121,NewField11211,NewField11212,NewField123,OPENINGDATE,NewField121211,NewField1511121,NewField1611121,ICD10KOD,ICD10,NewField1112121,NewField1112122};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    //TTObjectContext context = new TTObjectContext(true);
            string ICDKod = string.Empty;
            string ICD = string.Empty;
            IList diagnosisCodeList = new List<string>();
            
            BindingList<Episode> episodeList = Episode.GetByHospitalProtocolNo(this.ParentReport.ReportObjectContext, ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.HOSPITALPROTOCOLNO, (DateTime)((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.ENDDATE);
            foreach (Episode episode in episodeList)
            {
                if(episode.Patient != null)
                {
                    if(episode.Patient.UniqueRefNo != null)
                        this.UNIQUEREFNO.CalcValue = episode.Patient.UniqueRefNo.ToString();
                    
                    if(episode.OpeningDate != null)
                        this.OPENINGDATE.CalcValue = episode.OpeningDate.ToString().Substring(0,10);
                    
                    this.NAME.CalcValue = episode.Patient.FullName;
                }
                
                foreach(DiagnosisGrid dg in episode.Diagnosis)
                {
                    if(!diagnosisCodeList.Contains(dg.Diagnose.Code))
                    {
                        ICDKod = ICDKod + dg.Diagnose.Code + ", ";
                        ICD = ICD + dg.Diagnose.Name + ", ";
                        diagnosisCodeList.Add(dg.Diagnose.Code);
                    }
                }
                
                if(!string.IsNullOrEmpty(ICDKod))
                    ICDKod = ICDKod.Substring(0, ICDKod.Length - 2);
                
                if(!string.IsNullOrEmpty(ICD))
                    ICD = ICD.Substring(0, ICD.Length - 2);
                
                this.ICD10KOD.CalcValue = ICDKod;
                this.ICD10.CalcValue = ICD;
                break;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportShape NewLine111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 2, 120, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"Short Date";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CURRENTUSER};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTEGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTEGroupHeader(this);
                _footer = new PARTEGroupFooter(this);

            }

            public partial class PARTEGroupHeader : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField11231; 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 22, 6, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Size = 8;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.Underline = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"HİZMETLER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11231.CalcValue = NewField11231.Value;
                    return new TTReportObject[] { NewField11231};
                }
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTAGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField12221 { get {return Header().NewField12221;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField NewField112221 { get {return Header().NewField112221;} }
            public TTReportField NewField1122211 { get {return Header().NewField1122211;} }
            public TTReportField NewField112222 { get {return Header().NewField112222;} }
            public TTReportField NewField1112111 { get {return Footer().NewField1112111;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField PROCEDURETOTAL { get {return Footer().PROCEDURETOTAL;} }
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
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField NewField1221;
                public TTReportField NewField12221;
                public TTReportField NewField111211;
                public TTReportShape NewLine11;
                public TTReportField NewField121;
                public TTReportField NewField1321;
                public TTReportField NewField112221;
                public TTReportField NewField1122211;
                public TTReportField NewField112222; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 1, 118, 5, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Açıklama";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 33, 5, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1221.NoClip = EvetHayirEnum.ehEvet;
                    NewField1221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1221.TextFont.Size = 8;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Tarih";

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 191, 5, false);
                    NewField12221.Name = "NewField12221";
                    NewField12221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12221.NoClip = EvetHayirEnum.ehEvet;
                    NewField12221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12221.TextFont.Size = 8;
                    NewField12221.TextFont.Bold = true;
                    NewField12221.TextFont.CharSet = 162;
                    NewField12221.Value = @"Durum";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 142, 5, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Birim Fiyat";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 206, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 47, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Kod";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Size = 8;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Sıra No";

                    NewField112221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 1, 127, 5, false);
                    NewField112221.Name = "NewField112221";
                    NewField112221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112221.NoClip = EvetHayirEnum.ehEvet;
                    NewField112221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112221.TextFont.Size = 8;
                    NewField112221.TextFont.Bold = true;
                    NewField112221.TextFont.CharSet = 162;
                    NewField112221.Value = @"Miktar";

                    NewField1122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 160, 5, false);
                    NewField1122211.Name = "NewField1122211";
                    NewField1122211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1122211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122211.NoClip = EvetHayirEnum.ehEvet;
                    NewField1122211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1122211.TextFont.Size = 8;
                    NewField1122211.TextFont.Bold = true;
                    NewField1122211.TextFont.CharSet = 162;
                    NewField1122211.Value = @"Toplam Fiyat";

                    NewField112222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 1, 206, 5, false);
                    NewField112222.Name = "NewField112222";
                    NewField112222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112222.NoClip = EvetHayirEnum.ehEvet;
                    NewField112222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112222.TextFont.Size = 8;
                    NewField112222.TextFont.Bold = true;
                    NewField112222.TextFont.CharSet = 162;
                    NewField112222.Value = @"İşlem No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField12221.CalcValue = NewField12221.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField112221.CalcValue = NewField112221.Value;
                    NewField1122211.CalcValue = NewField1122211.Value;
                    NewField112222.CalcValue = NewField112222.Value;
                    return new TTReportObject[] { NewField1121,NewField1221,NewField12221,NewField111211,NewField121,NewField1321,NewField112221,NewField1122211,NewField112222};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField1112111;
                public TTReportShape NewLine111;
                public TTReportField PROCEDURETOTAL; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 2, 137, 7, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1112111.TextFont.Size = 8;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Hizmet Toplam Fiyat :";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    PROCEDURETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 2, 160, 7, false);
                    PROCEDURETOTAL.Name = "PROCEDURETOTAL";
                    PROCEDURETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURETOTAL.TextFormat = @"#,##0.#0";
                    PROCEDURETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PROCEDURETOTAL.TextFont.Size = 8;
                    PROCEDURETOTAL.TextFont.CharSet = 162;
                    PROCEDURETOTAL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1112111.CalcValue = NewField1112111.Value;
                    PROCEDURETOTAL.CalcValue = @"";
                    return new TTReportObject[] { NewField1112111,PROCEDURETOTAL};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.PROCEDURETOTAL.CalcValue = (((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.PROCEDURETOTAL).ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
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
                list[0] = new TTReportNqlData<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class>("GetProcedureTrxsByHospitalProtocolNo", AccountTransaction.GetProcedureTrxsByHospitalProtocolNo((string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(MyParentReport.RuntimeParameters.HOSPITALPROTOCOLNO),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATE;
                public TTReportField STATUS;
                public TTReportField UNITPRICE;
                public TTReportField SIRANO;
                public TTReportField TOTALPRICE;
                public TTReportField AMOUNT;
                public TTReportField ACTIONID;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 47, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Size = 8;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 118, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 33, 5, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.TextFont.Size = 8;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{#TRANSACTIONDATE#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 191, 5, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.TextFont.Size = 8;
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 142, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 17, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 160, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 127, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 206, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Size = 8;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 240, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class dataset_GetProcedureTrxsByHospitalProtocolNo = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class>(0);
                    CODE.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.Description) : "");
                    DATE.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.TransactionDate) : "");
                    STATUS.CalcValue = @"";
                    UNITPRICE.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.UnitPrice) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TOTALPRICE.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.Amount) : "");
                    ACTIONID.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.Actionid) : "");
                    OBJECTID.CalcValue = (dataset_GetProcedureTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetProcedureTrxsByHospitalProtocolNo.ObjectID) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,DATE,STATUS,UNITPRICE,SIRANO,TOTALPRICE,AMOUNT,ACTIONID,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            AccountTransaction AccTrx = (AccountTransaction)context.GetObject(new Guid(sObjectID),"AccountTransaction");

            if(AccTrx != null)
            {
                this.STATUS.CalcValue = AccTrx.CurrentStateDef.DisplayText;
                
                if (this.AMOUNT.CalcValue.Trim() != "" && this.UNITPRICE.CalcValue.Trim() != null)
                    this.TOTALPRICE.CalcValue = Convert.ToString(Convert.ToDouble(this.AMOUNT.FormattedValue) * Convert.ToDouble(this.UNITPRICE.FormattedValue));
                else
                    this.TOTALPRICE.CalcValue = "0";
                
                if (AccTrx.PackageDefinition == null)
                    ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.PROCEDURETOTAL = ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.PROCEDURETOTAL + Convert.ToDouble(this.TOTALPRICE.FormattedValue);
                else
                    this.DESCRIPTION.CalcValue += " (Paket İçi)";
                
                if(this.ACTIONID.CalcValue == "")
                {
                    if(AccTrx.SubActionProcedure != null)
                    {
                        if(AccTrx.SubActionProcedure.MasterSubActionProcedure != null)
                        {
                            if(AccTrx.SubActionProcedure.MasterSubActionProcedure is SubactionProcedureFlowable)
                            {
                                if(((SubactionProcedureFlowable)AccTrx.SubActionProcedure.MasterSubActionProcedure).ID != null)
                                    this.ACTIONID.CalcValue = ((SubactionProcedureFlowable)AccTrx.SubActionProcedure.MasterSubActionProcedure).ID.ToString();
                            }
                        }
                    }
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTFGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField113211; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 38, 9, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Size = 8;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.Underline = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"İLAÇLAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField113211.CalcValue = NewField113211.Value;
                    return new TTReportObject[] { NewField113211};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTDGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField112221 { get {return Header().NewField112221;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField NewField1122211 { get {return Header().NewField1122211;} }
            public TTReportField NewField11122211 { get {return Header().NewField11122211;} }
            public TTReportField NewField1222211 { get {return Header().NewField1222211;} }
            public TTReportField NewField11112111 { get {return Footer().NewField11112111;} }
            public TTReportField DRUGTOTAL { get {return Footer().DRUGTOTAL;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField11211;
                public TTReportField NewField11221;
                public TTReportField NewField112221;
                public TTReportField NewField1112111;
                public TTReportShape NewLine111;
                public TTReportField NewField1121;
                public TTReportField NewField11231;
                public TTReportField NewField1122211;
                public TTReportField NewField11122211;
                public TTReportField NewField1222211; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 1, 118, 5, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Açıklama";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 33, 5, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221.NoClip = EvetHayirEnum.ehEvet;
                    NewField11221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11221.TextFont.Size = 8;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Tarih";

                    NewField112221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 191, 5, false);
                    NewField112221.Name = "NewField112221";
                    NewField112221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112221.NoClip = EvetHayirEnum.ehEvet;
                    NewField112221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112221.TextFont.Size = 8;
                    NewField112221.TextFont.Bold = true;
                    NewField112221.TextFont.CharSet = 162;
                    NewField112221.Value = @"Durum";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 142, 5, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1112111.TextFont.Size = 8;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Birim Fiyat";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 206, 6, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 52, 5, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Kod";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Size = 8;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"Sıra No";

                    NewField1122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 1, 127, 5, false);
                    NewField1122211.Name = "NewField1122211";
                    NewField1122211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122211.NoClip = EvetHayirEnum.ehEvet;
                    NewField1122211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1122211.TextFont.Size = 8;
                    NewField1122211.TextFont.Bold = true;
                    NewField1122211.TextFont.CharSet = 162;
                    NewField1122211.Value = @"Miktar";

                    NewField11122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 160, 5, false);
                    NewField11122211.Name = "NewField11122211";
                    NewField11122211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11122211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11122211.NoClip = EvetHayirEnum.ehEvet;
                    NewField11122211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11122211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11122211.TextFont.Size = 8;
                    NewField11122211.TextFont.Bold = true;
                    NewField11122211.TextFont.CharSet = 162;
                    NewField11122211.Value = @"Toplam Fiyat";

                    NewField1222211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 1, 206, 5, false);
                    NewField1222211.Name = "NewField1222211";
                    NewField1222211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1222211.NoClip = EvetHayirEnum.ehEvet;
                    NewField1222211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1222211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1222211.TextFont.Size = 8;
                    NewField1222211.TextFont.Bold = true;
                    NewField1222211.TextFont.CharSet = 162;
                    NewField1222211.Value = @"İşlem No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField112221.CalcValue = NewField112221.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField1122211.CalcValue = NewField1122211.Value;
                    NewField11122211.CalcValue = NewField11122211.Value;
                    NewField1222211.CalcValue = NewField1222211.Value;
                    return new TTReportObject[] { NewField11211,NewField11221,NewField112221,NewField1112111,NewField1121,NewField11231,NewField1122211,NewField11122211,NewField1222211};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField11112111;
                public TTReportField DRUGTOTAL;
                public TTReportShape NewLine1111; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 2, 137, 7, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11112111.TextFont.Size = 8;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"İlaç Toplam Fiyat :";

                    DRUGTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 2, 160, 7, false);
                    DRUGTOTAL.Name = "DRUGTOTAL";
                    DRUGTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGTOTAL.TextFormat = @"#,##0.#0";
                    DRUGTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DRUGTOTAL.TextFont.Size = 8;
                    DRUGTOTAL.TextFont.CharSet = 162;
                    DRUGTOTAL.Value = @"";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11112111.CalcValue = NewField11112111.Value;
                    DRUGTOTAL.CalcValue = @"";
                    return new TTReportObject[] { NewField11112111,DRUGTOTAL};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    this.DRUGTOTAL.CalcValue = (((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.DRUGTOTAL).ToString();
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class>("GetDrugTrxsByHospitalProtocolNo", AccountTransaction.GetDrugTrxsByHospitalProtocolNo((string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(MyParentReport.RuntimeParameters.HOSPITALPROTOCOLNO),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATE;
                public TTReportField STATUS;
                public TTReportField UNITPRICE;
                public TTReportField SIRANO;
                public TTReportField TOTALPRICE;
                public TTReportField AMOUNT;
                public TTReportField ACTIONID;
                public TTReportField OBJECTID; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 52, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Size = 8;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 118, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 33, 5, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.TextFont.Size = 8;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{#TRANSACTIONDATE#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 191, 5, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.TextFont.Size = 8;
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 142, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 17, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 160, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 127, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 206, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Size = 8;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 240, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class dataset_GetDrugTrxsByHospitalProtocolNo = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class>(0);
                    CODE.CalcValue = (dataset_GetDrugTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetDrugTrxsByHospitalProtocolNo.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_GetDrugTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetDrugTrxsByHospitalProtocolNo.Description) : "");
                    DATE.CalcValue = (dataset_GetDrugTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetDrugTrxsByHospitalProtocolNo.TransactionDate) : "");
                    STATUS.CalcValue = @"";
                    UNITPRICE.CalcValue = (dataset_GetDrugTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetDrugTrxsByHospitalProtocolNo.UnitPrice) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TOTALPRICE.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_GetDrugTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetDrugTrxsByHospitalProtocolNo.Amount) : "");
                    ACTIONID.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetDrugTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetDrugTrxsByHospitalProtocolNo.ObjectID) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,DATE,STATUS,UNITPRICE,SIRANO,TOTALPRICE,AMOUNT,ACTIONID,OBJECTID};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            AccountTransaction AccTrx = (AccountTransaction)context.GetObject(new Guid(sObjectID),"AccountTransaction");

            if(AccTrx != null)
            {
                this.STATUS.CalcValue = AccTrx.CurrentStateDef.DisplayText;
                
                if(AccTrx.SubActionMaterial != null)
                {
                    if(AccTrx.SubActionMaterial is BaseTreatmentMaterial)
                    {
                        BaseTreatmentMaterial btm = (BaseTreatmentMaterial)AccTrx.SubActionMaterial;
                        if(btm != null)
                        {
                            if(btm.EpisodeAction != null)
                            {
                                if(btm.EpisodeAction.ID != null)
                                    this.ACTIONID.CalcValue = btm.EpisodeAction.ID.ToString();
                            }
                            else if(btm.SubactionProcedureFlowable != null)
                            {
                                if(btm.SubactionProcedureFlowable.ID != null)
                                    this.ACTIONID.CalcValue = btm.SubactionProcedureFlowable.ID.ToString();
                            }
                        }
                    }
                }
                
                
                if(this.AMOUNT.CalcValue.Trim() != "" && this.UNITPRICE.CalcValue.Trim() != "")
                    this.TOTALPRICE.CalcValue = Convert.ToString(Convert.ToDouble(this.AMOUNT.FormattedValue) * Convert.ToDouble(this.UNITPRICE.FormattedValue));
                else
                    this.TOTALPRICE.CalcValue = "0";
                
                if(AccTrx.PackageDefinition == null)
                    ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.DRUGTOTAL = ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.DRUGTOTAL + Convert.ToDouble(this.TOTALPRICE.FormattedValue);
                else
                    this.DESCRIPTION.CalcValue += " (Paket İçi)";
            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTOGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTOGroupHeader Header()
            {
                return (PARTOGroupHeader)_header;
            }

            new public PARTOGroupFooter Footer()
            {
                return (PARTOGroupFooter)_footer;
            }

            public TTReportField NewField1112311 { get {return Header().NewField1112311;} }
            public TTReportField NewField1111121111 { get {return Footer().NewField1111121111;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public PARTOGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTOGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTOGroupHeader(this);
                _footer = new PARTOGroupFooter(this);

            }

            public partial class PARTOGroupHeader : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField1112311; 
                public PARTOGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 38, 9, false);
                    NewField1112311.Name = "NewField1112311";
                    NewField1112311.TextFont.Size = 8;
                    NewField1112311.TextFont.Bold = true;
                    NewField1112311.TextFont.Underline = true;
                    NewField1112311.TextFont.CharSet = 162;
                    NewField1112311.Value = @"MALZEMELER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1112311.CalcValue = NewField1112311.Value;
                    return new TTReportObject[] { NewField1112311};
                }
            }
            public partial class PARTOGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField1111121111;
                public TTReportField TOTAL; 
                public PARTOGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 3, 137, 8, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111121111.TextFont.Size = 8;
                    NewField1111121111.TextFont.Bold = true;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @"Genel Toplam Fiyat :";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 3, 160, 8, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.Size = 8;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    TOTAL.CalcValue = @"";
                    return new TTReportObject[] { NewField1111121111,TOTAL};
                }

                public override void RunScript()
                {
#region PARTO FOOTER_Script
                    this.TOTAL.CalcValue = Convert.ToString(Convert.ToDouble(((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.PROCEDURETOTAL) + Convert.ToDouble(((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.DRUGTOTAL) + Convert.ToDouble(((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.MATERIALTOTAL));
#endregion PARTO FOOTER_Script
                }
            }

        }

        public PARTOGroup PARTO;

        public partial class PARTNGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTNGroupHeader Header()
            {
                return (PARTNGroupHeader)_header;
            }

            new public PARTNGroupFooter Footer()
            {
                return (PARTNGroupFooter)_footer;
            }

            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField1122211 { get {return Header().NewField1122211;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public TTReportField NewField11122211 { get {return Header().NewField11122211;} }
            public TTReportField NewField111222111 { get {return Header().NewField111222111;} }
            public TTReportField NewField11122221 { get {return Header().NewField11122221;} }
            public TTReportField NewField111121111 { get {return Footer().NewField111121111;} }
            public TTReportField MATERIALTOTAL { get {return Footer().MATERIALTOTAL;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public PARTNGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTNGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTNGroupHeader(this);
                _footer = new PARTNGroupFooter(this);

            }

            public partial class PARTNGroupHeader : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportField NewField112211;
                public TTReportField NewField1122211;
                public TTReportField NewField11112111;
                public TTReportShape NewLine1111;
                public TTReportField NewField11211;
                public TTReportField NewField113211;
                public TTReportField NewField11122211;
                public TTReportField NewField111222111;
                public TTReportField NewField11122221; 
                public PARTNGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 1, 118, 5, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Açıklama";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 33, 5, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112211.NoClip = EvetHayirEnum.ehEvet;
                    NewField112211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112211.TextFont.Size = 8;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"Tarih";

                    NewField1122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 191, 5, false);
                    NewField1122211.Name = "NewField1122211";
                    NewField1122211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122211.NoClip = EvetHayirEnum.ehEvet;
                    NewField1122211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1122211.TextFont.Size = 8;
                    NewField1122211.TextFont.Bold = true;
                    NewField1122211.TextFont.CharSet = 162;
                    NewField1122211.Value = @"Durum";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 142, 5, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11112111.TextFont.Size = 8;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Birim Fiyat";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 206, 6, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 52, 5, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Kod";

                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Size = 8;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"Sıra No";

                    NewField11122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 1, 127, 5, false);
                    NewField11122211.Name = "NewField11122211";
                    NewField11122211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11122211.NoClip = EvetHayirEnum.ehEvet;
                    NewField11122211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11122211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11122211.TextFont.Size = 8;
                    NewField11122211.TextFont.Bold = true;
                    NewField11122211.TextFont.CharSet = 162;
                    NewField11122211.Value = @"Miktar";

                    NewField111222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 160, 5, false);
                    NewField111222111.Name = "NewField111222111";
                    NewField111222111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111222111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111222111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111222111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111222111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111222111.TextFont.Size = 8;
                    NewField111222111.TextFont.Bold = true;
                    NewField111222111.TextFont.CharSet = 162;
                    NewField111222111.Value = @"Toplam Fiyat";

                    NewField11122221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 1, 206, 5, false);
                    NewField11122221.Name = "NewField11122221";
                    NewField11122221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11122221.NoClip = EvetHayirEnum.ehEvet;
                    NewField11122221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11122221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11122221.TextFont.Size = 8;
                    NewField11122221.TextFont.Bold = true;
                    NewField11122221.TextFont.CharSet = 162;
                    NewField11122221.Value = @"İşlem No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1122211.CalcValue = NewField1122211.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField113211.CalcValue = NewField113211.Value;
                    NewField11122211.CalcValue = NewField11122211.Value;
                    NewField111222111.CalcValue = NewField111222111.Value;
                    NewField11122221.CalcValue = NewField11122221.Value;
                    return new TTReportObject[] { NewField111211,NewField112211,NewField1122211,NewField11112111,NewField11211,NewField113211,NewField11122211,NewField111222111,NewField11122221};
                }
            }
            public partial class PARTNGroupFooter : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField NewField111121111;
                public TTReportField MATERIALTOTAL;
                public TTReportShape NewLine11111; 
                public PARTNGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 2, 137, 7, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111121111.TextFont.Size = 8;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"Malzeme Toplam Fiyat :";

                    MATERIALTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 2, 160, 7, false);
                    MATERIALTOTAL.Name = "MATERIALTOTAL";
                    MATERIALTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTOTAL.TextFormat = @"#,##0.#0";
                    MATERIALTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALTOTAL.TextFont.Size = 8;
                    MATERIALTOTAL.TextFont.CharSet = 162;
                    MATERIALTOTAL.Value = @"";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111121111.CalcValue = NewField111121111.Value;
                    MATERIALTOTAL.CalcValue = @"";
                    return new TTReportObject[] { NewField111121111,MATERIALTOTAL};
                }

                public override void RunScript()
                {
#region PARTN FOOTER_Script
                    this.MATERIALTOTAL.CalcValue = (((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.MATERIALTOTAL).ToString();
#endregion PARTN FOOTER_Script
                }
            }

        }

        public PARTNGroup PARTN;

        public partial class PARTMGroup : TTReportGroup
        {
            public PatientProcedureAndMaterialList_All MyParentReport
            {
                get { return (PatientProcedureAndMaterialList_All)ParentReport; }
            }

            new public PARTMGroupBody Body()
            {
                return (PARTMGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public PARTMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class>("GetMaterialTrxsByHospitalProtocolNo", AccountTransaction.GetMaterialTrxsByHospitalProtocolNo((string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(MyParentReport.RuntimeParameters.HOSPITALPROTOCOLNO),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTMGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTMGroupBody : TTReportSection
            {
                public PatientProcedureAndMaterialList_All MyParentReport
                {
                    get { return (PatientProcedureAndMaterialList_All)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATE;
                public TTReportField STATUS;
                public TTReportField UNITPRICE;
                public TTReportField SIRANO;
                public TTReportField TOTALPRICE;
                public TTReportField AMOUNT;
                public TTReportField ACTIONID;
                public TTReportField OBJECTID; 
                public PARTMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 52, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Size = 8;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 118, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 33, 5, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.TextFont.Size = 8;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{#TRANSACTIONDATE#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 191, 5, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.TextFont.Size = 8;
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 142, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 17, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 160, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 127, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 206, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Size = 8;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 240, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class dataset_GetMaterialTrxsByHospitalProtocolNo = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class>(0);
                    CODE.CalcValue = (dataset_GetMaterialTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetMaterialTrxsByHospitalProtocolNo.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_GetMaterialTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetMaterialTrxsByHospitalProtocolNo.Description) : "");
                    DATE.CalcValue = (dataset_GetMaterialTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetMaterialTrxsByHospitalProtocolNo.TransactionDate) : "");
                    STATUS.CalcValue = @"";
                    UNITPRICE.CalcValue = (dataset_GetMaterialTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetMaterialTrxsByHospitalProtocolNo.UnitPrice) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TOTALPRICE.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_GetMaterialTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetMaterialTrxsByHospitalProtocolNo.Amount) : "");
                    ACTIONID.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetMaterialTrxsByHospitalProtocolNo != null ? Globals.ToStringCore(dataset_GetMaterialTrxsByHospitalProtocolNo.ObjectID) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,DATE,STATUS,UNITPRICE,SIRANO,TOTALPRICE,AMOUNT,ACTIONID,OBJECTID};
                }

                public override void RunScript()
                {
#region PARTM BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            AccountTransaction AccTrx = (AccountTransaction)context.GetObject(new Guid(sObjectID),"AccountTransaction");

            if(AccTrx != null)
            {
                this.STATUS.CalcValue = AccTrx.CurrentStateDef.DisplayText;
                
                if(AccTrx.SubActionMaterial != null)
                {
                    if(AccTrx.SubActionMaterial is BaseTreatmentMaterial)
                    {
                        BaseTreatmentMaterial btm = (BaseTreatmentMaterial)AccTrx.SubActionMaterial;
                        if(btm != null)
                        {
                            if(btm.EpisodeAction != null)
                            {
                                if(btm.EpisodeAction.ID != null)
                                    this.ACTIONID.CalcValue = btm.EpisodeAction.ID.ToString();
                            }
                            else if(btm.SubactionProcedureFlowable != null)
                            {
                                if(btm.SubactionProcedureFlowable.ID != null)
                                    this.ACTIONID.CalcValue = btm.SubactionProcedureFlowable.ID.ToString();
                            }
                        }
                    }
                }
                
                
                if(this.AMOUNT.CalcValue.Trim() != "" && this.UNITPRICE.CalcValue.Trim() != "")
                    this.TOTALPRICE.CalcValue = Convert.ToString(Convert.ToDouble(this.AMOUNT.FormattedValue) * Convert.ToDouble(this.UNITPRICE.FormattedValue));
                else
                    this.TOTALPRICE.CalcValue = "0";
                
                if(AccTrx.PackageDefinition == null)
                    ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.MATERIALTOTAL = ((PatientProcedureAndMaterialList_All)ParentReport).RuntimeParameters.MATERIALTOTAL + Convert.ToDouble(this.TOTALPRICE.FormattedValue);
                else
                    this.DESCRIPTION.CalcValue += " (Paket İçi)";
            }
#endregion PARTM BODY_Script
                }
            }

        }

        public PARTMGroup PARTM;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PatientProcedureAndMaterialList_All()
        {
            PARTG = new PARTGGroup(this,"PARTG");
            PARTB = new PARTBGroup(PARTG,"PARTB");
            PARTE = new PARTEGroup(PARTB,"PARTE");
            PARTA = new PARTAGroup(PARTE,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            PARTF = new PARTFGroup(PARTB,"PARTF");
            PARTD = new PARTDGroup(PARTF,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            PARTO = new PARTOGroup(PARTB,"PARTO");
            PARTN = new PARTNGroup(PARTO,"PARTN");
            PARTM = new PARTMGroup(PARTN,"PARTM");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("HOSPITALPROTOCOLNO", "", "H.Protokol No", @"", true, true, false, new Guid("5dcf77fd-4b8d-479a-9e5e-e5e7414cf8b6"));
            reportParameter = Parameters.Add("PROCEDURETOTAL", "", "Hizmet Toplamı", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("MATERIALTOTAL", "", "Malzeme Toplamı", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("DRUGTOTAL", "", "İlaç Toplamı", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("YEAR", TTObjectDefManager.ServerTime.Year.ToString(), "Yıl", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("HOSPITALPROTOCOLNO"))
                _runtimeParameters.HOSPITALPROTOCOLNO = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue(parameters["HOSPITALPROTOCOLNO"]);
            if (parameters.ContainsKey("PROCEDURETOTAL"))
                _runtimeParameters.PROCEDURETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["PROCEDURETOTAL"]);
            if (parameters.ContainsKey("MATERIALTOTAL"))
                _runtimeParameters.MATERIALTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["MATERIALTOTAL"]);
            if (parameters.ContainsKey("DRUGTOTAL"))
                _runtimeParameters.DRUGTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["DRUGTOTAL"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["YEAR"]);
            Name = "PATIENTPROCEDUREANDMATERIALLIST_ALL";
            Caption = "Hasta Hizmet ve Malzeme Dökümü (Hepsi)";
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