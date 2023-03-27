
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
    /// Tanıya Göre Hasta Listesi
    /// </summary>
    public partial class DiagnosisListByDateReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? DIAGNOSE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? DOCTOR = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class BASLIKGroup : TTReportGroup
        {
            public DiagnosisListByDateReport MyParentReport
            {
                get { return (DiagnosisListByDateReport)ParentReport; }
            }

            new public BASLIKGroupHeader Header()
            {
                return (BASLIKGroupHeader)_header;
            }

            new public BASLIKGroupFooter Footer()
            {
                return (BASLIKGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
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
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4; 
                public BASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 3, 195, 25, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 25, 176, 33, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Tanıya Göre Hasta Listesi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 33, 109, 39, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFormat = @"dd/MM/yyyy";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"{@STARTDATE@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 33, 112, 39, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"-";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 33, 133, 39, false);
                    NewField4.Name = "NewField4";
                    NewField4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField4.TextFormat = @"dd/MM/yyyy";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,XXXXXXBASLIK1};
                }
            }
            public partial class BASLIKGroupFooter : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                 
                public BASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public BASLIKGroup BASLIK;

        public partial class TANIBODYGroup : TTReportGroup
        {
            public DiagnosisListByDateReport MyParentReport
            {
                get { return (DiagnosisListByDateReport)ParentReport; }
            }

            new public TANIBODYGroupHeader Header()
            {
                return (TANIBODYGroupHeader)_header;
            }

            new public TANIBODYGroupFooter Footer()
            {
                return (TANIBODYGroupFooter)_footer;
            }

            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField DIAGNOSECODE { get {return Header().DIAGNOSECODE;} }
            public TTReportField TANIACIKLAMASI { get {return Header().TANIACIKLAMASI;} }
            public TANIBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnoseByDate_Class>("GetDiagnoseByDate", DiagnosisGrid.GetDiagnoseByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.DIAGNOSE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.DOCTOR),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERRESOURCE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANIBODYGroupHeader(this);
                _footer = new TANIBODYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANIBODYGroupHeader : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField DIAGNOSECODE;
                public TTReportField TANIACIKLAMASI; 
                public TANIBODYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 5, 34, 11, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANI.TextFont.Size = 11;
                    TANI.TextFont.Bold = true;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"TANI:";

                    DIAGNOSECODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 5, 54, 11, false);
                    DIAGNOSECODE.Name = "DIAGNOSECODE";
                    DIAGNOSECODE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSECODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSECODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSECODE.TextFont.Size = 11;
                    DIAGNOSECODE.TextFont.CharSet = 162;
                    DIAGNOSECODE.Value = @"{#DIAGNOSECODE#}";

                    TANIACIKLAMASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 5, 195, 11, false);
                    TANIACIKLAMASI.Name = "TANIACIKLAMASI";
                    TANIACIKLAMASI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANIACIKLAMASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANIACIKLAMASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANIACIKLAMASI.TextFont.Size = 11;
                    TANIACIKLAMASI.TextFont.CharSet = 162;
                    TANIACIKLAMASI.Value = @"{#DIAGNOSENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnoseByDate_Class dataset_GetDiagnoseByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);
                    TANI.CalcValue = TANI.Value;
                    DIAGNOSECODE.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Diagnosecode) : "");
                    TANIACIKLAMASI.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Diagnosename) : "");
                    return new TTReportObject[] { TANI,DIAGNOSECODE,TANIACIKLAMASI};
                }
            }
            public partial class TANIBODYGroupFooter : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                 
                public TANIBODYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TANIBODYGroup TANIBODY;

        public partial class POLIKLINIKBODYGroup : TTReportGroup
        {
            public DiagnosisListByDateReport MyParentReport
            {
                get { return (DiagnosisListByDateReport)ParentReport; }
            }

            new public POLIKLINIKBODYGroupHeader Header()
            {
                return (POLIKLINIKBODYGroupHeader)_header;
            }

            new public POLIKLINIKBODYGroupFooter Footer()
            {
                return (POLIKLINIKBODYGroupFooter)_footer;
            }

            public TTReportField BOLUM { get {return Header().BOLUM;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public POLIKLINIKBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public POLIKLINIKBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                DiagnosisGrid.GetDiagnoseByDate_Class dataSet_GetDiagnoseByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);    
                return new object[] {(dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Diagnosecode)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new POLIKLINIKBODYGroupHeader(this);
                _footer = new POLIKLINIKBODYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class POLIKLINIKBODYGroupHeader : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                
                public TTReportField BOLUM;
                public TTReportField NAME; 
                public POLIKLINIKBODYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 51, 6, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.DrawStyle = DrawStyleConstants.vbSolid;
                    BOLUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BOLUM.TextFont.Size = 11;
                    BOLUM.TextFont.Bold = true;
                    BOLUM.TextFont.CharSet = 162;
                    BOLUM.Value = @"BÖLÜM:";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 194, 6, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.TextFont.Size = 11;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#TANIBODY.NAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnoseByDate_Class dataset_GetDiagnoseByDate = MyParentReport.TANIBODY.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);
                    BOLUM.CalcValue = BOLUM.Value;
                    NAME.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Name) : "");
                    return new TTReportObject[] { BOLUM,NAME};
                }
            }
            public partial class POLIKLINIKBODYGroupFooter : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                 
                public POLIKLINIKBODYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public POLIKLINIKBODYGroup POLIKLINIKBODY;

        public partial class DOKTORBODYGroup : TTReportGroup
        {
            public DiagnosisListByDateReport MyParentReport
            {
                get { return (DiagnosisListByDateReport)ParentReport; }
            }

            new public DOKTORBODYGroupHeader Header()
            {
                return (DOKTORBODYGroupHeader)_header;
            }

            new public DOKTORBODYGroupFooter Footer()
            {
                return (DOKTORBODYGroupFooter)_footer;
            }

            public TTReportField DOKTOR { get {return Header().DOKTOR;} }
            public TTReportField DOCTORNAME { get {return Header().DOCTORNAME;} }
            public TTReportField HASTATC11 { get {return Header().HASTATC11;} }
            public TTReportField TANITARIHI1 { get {return Header().TANITARIHI1;} }
            public TTReportField HASTAADI111 { get {return Header().HASTAADI111;} }
            public TTReportField HASTATELEFON11 { get {return Header().HASTATELEFON11;} }
            public DOKTORBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DOKTORBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                DiagnosisGrid.GetDiagnoseByDate_Class dataSet_GetDiagnoseByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);    
                return new object[] {(dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Diagnosecode), (dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Name)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new DOKTORBODYGroupHeader(this);
                _footer = new DOKTORBODYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class DOKTORBODYGroupHeader : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                
                public TTReportField DOKTOR;
                public TTReportField DOCTORNAME;
                public TTReportField HASTATC11;
                public TTReportField TANITARIHI1;
                public TTReportField HASTAADI111;
                public TTReportField HASTATELEFON11; 
                public DOKTORBODYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 60, 6, false);
                    DOKTOR.Name = "DOKTOR";
                    DOKTOR.DrawStyle = DrawStyleConstants.vbSolid;
                    DOKTOR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOKTOR.TextFont.Size = 11;
                    DOKTOR.TextFont.Bold = true;
                    DOKTOR.TextFont.CharSet = 162;
                    DOKTOR.Value = @"DOKTOR:";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 195, 6, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCTORNAME.TextFont.Size = 11;
                    DOCTORNAME.TextFont.CharSet = 162;
                    DOCTORNAME.Value = @"{#TANIBODY.DOCTORNAME#}";

                    HASTATC11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 6, 75, 12, false);
                    HASTATC11.Name = "HASTATC11";
                    HASTATC11.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTATC11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTATC11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTATC11.TextFont.Size = 11;
                    HASTATC11.TextFont.Bold = true;
                    HASTATC11.TextFont.CharSet = 162;
                    HASTATC11.Value = @"TC KİMLİK NU";

                    TANITARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 6, 195, 12, false);
                    TANITARIHI1.Name = "TANITARIHI1";
                    TANITARIHI1.DrawStyle = DrawStyleConstants.vbSolid;
                    TANITARIHI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TANITARIHI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANITARIHI1.TextFont.Size = 11;
                    TANITARIHI1.TextFont.Bold = true;
                    TANITARIHI1.TextFont.CharSet = 162;
                    TANITARIHI1.Value = @"TANI TARİHİ";

                    HASTAADI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 6, 132, 12, false);
                    HASTAADI111.Name = "HASTAADI111";
                    HASTAADI111.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTAADI111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAADI111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAADI111.TextFont.Size = 11;
                    HASTAADI111.TextFont.Bold = true;
                    HASTAADI111.TextFont.CharSet = 162;
                    HASTAADI111.Value = @"ADI-SOYADI";

                    HASTATELEFON11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 6, 165, 12, false);
                    HASTATELEFON11.Name = "HASTATELEFON11";
                    HASTATELEFON11.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTATELEFON11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTATELEFON11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTATELEFON11.TextFont.Size = 11;
                    HASTATELEFON11.TextFont.Bold = true;
                    HASTATELEFON11.TextFont.CharSet = 162;
                    HASTATELEFON11.Value = @"TELEFON NU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnoseByDate_Class dataset_GetDiagnoseByDate = MyParentReport.TANIBODY.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);
                    DOKTOR.CalcValue = DOKTOR.Value;
                    DOCTORNAME.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Doctorname) : "");
                    HASTATC11.CalcValue = HASTATC11.Value;
                    TANITARIHI1.CalcValue = TANITARIHI1.Value;
                    HASTAADI111.CalcValue = HASTAADI111.Value;
                    HASTATELEFON11.CalcValue = HASTATELEFON11.Value;
                    return new TTReportObject[] { DOKTOR,DOCTORNAME,HASTATC11,TANITARIHI1,HASTAADI111,HASTATELEFON11};
                }
            }
            public partial class DOKTORBODYGroupFooter : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                 
                public DOKTORBODYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public DOKTORBODYGroup DOKTORBODY;

        public partial class EPISODEGroup : TTReportGroup
        {
            public DiagnosisListByDateReport MyParentReport
            {
                get { return (DiagnosisListByDateReport)ParentReport; }
            }

            new public EPISODEGroupHeader Header()
            {
                return (EPISODEGroupHeader)_header;
            }

            new public EPISODEGroupFooter Footer()
            {
                return (EPISODEGroupFooter)_footer;
            }

            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public EPISODEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public EPISODEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                DiagnosisGrid.GetDiagnoseByDate_Class dataSet_GetDiagnoseByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);    
                return new object[] {(dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Diagnosecode), (dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Name), (dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Doctorname)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new EPISODEGroupHeader(this);
                _footer = new EPISODEGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class EPISODEGroupHeader : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                
                public TTReportField EPISODEID; 
                public EPISODEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 65, 5, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.Value = @"{#TANIBODY.EPISODEID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnoseByDate_Class dataset_GetDiagnoseByDate = MyParentReport.TANIBODY.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);
                    EPISODEID.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Episodeid) : "");
                    return new TTReportObject[] { EPISODEID};
                }
            }
            public partial class EPISODEGroupFooter : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                 
                public EPISODEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public EPISODEGroup EPISODE;

        public partial class HASTAGroup : TTReportGroup
        {
            public DiagnosisListByDateReport MyParentReport
            {
                get { return (DiagnosisListByDateReport)ParentReport; }
            }

            new public HASTAGroupBody Body()
            {
                return (HASTAGroupBody)_body;
            }
            public TTReportField HASTATCNU { get {return Body().HASTATCNU;} }
            public TTReportField DIAGNOSEDATE { get {return Body().DIAGNOSEDATE;} }
            public TTReportField HASTAADI11 { get {return Body().HASTAADI11;} }
            public TTReportField HASTATELEFON1 { get {return Body().HASTATELEFON1;} }
            public TTReportField FKIMLIKNO { get {return Body().FKIMLIKNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public HASTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HASTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                DiagnosisGrid.GetDiagnoseByDate_Class dataSet_GetDiagnoseByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);    
                return new object[] {(dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Diagnosecode), (dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Name), (dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Doctorname), (dataSet_GetDiagnoseByDate==null ? null : dataSet_GetDiagnoseByDate.Episodeid)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new HASTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class HASTAGroupBody : TTReportSection
            {
                public DiagnosisListByDateReport MyParentReport
                {
                    get { return (DiagnosisListByDateReport)ParentReport; }
                }
                
                public TTReportField HASTATCNU;
                public TTReportField DIAGNOSEDATE;
                public TTReportField HASTAADI11;
                public TTReportField HASTATELEFON1;
                public TTReportField FKIMLIKNO;
                public TTReportField TCKIMLIKNO; 
                public HASTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    HASTATCNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 75, 6, false);
                    HASTATCNU.Name = "HASTATCNU";
                    HASTATCNU.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTATCNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTATCNU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTATCNU.TextFont.Size = 11;
                    HASTATCNU.TextFont.CharSet = 162;
                    HASTATCNU.Value = @"";

                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 195, 6, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.TextFormat = @"dd/MM/yyyy";
                    DIAGNOSEDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIAGNOSEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSEDATE.TextFont.Size = 11;
                    DIAGNOSEDATE.TextFont.CharSet = 162;
                    DIAGNOSEDATE.Value = @"{#TANIBODY.DIAGNOSEDATE#}";

                    HASTAADI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 132, 6, false);
                    HASTAADI11.Name = "HASTAADI11";
                    HASTAADI11.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTAADI11.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAADI11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAADI11.TextFont.Size = 11;
                    HASTAADI11.TextFont.CharSet = 162;
                    HASTAADI11.Value = @"{#TANIBODY.PATIENTNAME#}  {#TANIBODY.PATIENTSURNAME#}";

                    HASTATELEFON1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 165, 6, false);
                    HASTATELEFON1.Name = "HASTATELEFON1";
                    HASTATELEFON1.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTATELEFON1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATELEFON1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTATELEFON1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTATELEFON1.TextFont.Size = 11;
                    HASTATELEFON1.TextFont.CharSet = 162;
                    HASTATELEFON1.Value = @"{#TANIBODY.PATIENTPHONE#}";

                    FKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 3, 264, 8, false);
                    FKIMLIKNO.Name = "FKIMLIKNO";
                    FKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    FKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FKIMLIKNO.Value = @"{#TANIBODY.FKIMLIKNO#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 3, 237, 8, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"{#TANIBODY.TCKIMLIKNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnoseByDate_Class dataset_GetDiagnoseByDate = MyParentReport.TANIBODY.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnoseByDate_Class>(0);
                    HASTATCNU.CalcValue = @"";
                    DIAGNOSEDATE.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.DiagnoseDate) : "");
                    HASTAADI11.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Patientname) : "") + @"  " + (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Patientsurname) : "");
                    HASTATELEFON1.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Patientphone) : "");
                    FKIMLIKNO.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Fkimlikno) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetDiagnoseByDate != null ? Globals.ToStringCore(dataset_GetDiagnoseByDate.Tckimlikno) : "");
                    return new TTReportObject[] { HASTATCNU,DIAGNOSEDATE,HASTAADI11,HASTATELEFON1,FKIMLIKNO,TCKIMLIKNO};
                }

                public override void RunScript()
                {
#region HASTA BODY_Script
                    if(this.FKIMLIKNO.CalcValue != null && this.FKIMLIKNO.CalcValue != "")
                    this.HASTATCNU.CalcValue = "(*)" + this.FKIMLIKNO.CalcValue;
                else
                    this.HASTATCNU.CalcValue = this.TCKIMLIKNO.CalcValue;
#endregion HASTA BODY_Script
                }
            }

        }

        public HASTAGroup HASTA;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DiagnosisListByDateReport()
        {
            BASLIK = new BASLIKGroup(this,"BASLIK");
            TANIBODY = new TANIBODYGroup(BASLIK,"TANIBODY");
            POLIKLINIKBODY = new POLIKLINIKBODYGroup(TANIBODY,"POLIKLINIKBODY");
            DOKTORBODY = new DOKTORBODYGroup(POLIKLINIKBODY,"DOKTORBODY");
            EPISODE = new EPISODEGroup(DOKTORBODY,"EPISODE");
            HASTA = new HASTAGroup(EPISODE,"HASTA");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DIAGNOSE", "00000000-0000-0000-0000-000000000000", "Tani", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f438d7e5-bd84-472a-92ef-5b63f94cc57e");
            reportParameter = Parameters.Add("DOCTOR", "00000000-0000-0000-0000-000000000000", "Doktor", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter = Parameters.Add("MASTERRESOURCE", "00000000-0000-0000-0000-000000000000", "Bölüm", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("b19b0592-19c0-454f-9227-d6f92152b2ba");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DIAGNOSE"))
                _runtimeParameters.DIAGNOSE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["DIAGNOSE"]);
            if (parameters.ContainsKey("DOCTOR"))
                _runtimeParameters.DOCTOR = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["DOCTOR"]);
            if (parameters.ContainsKey("MASTERRESOURCE"))
                _runtimeParameters.MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MASTERRESOURCE"]);
            Name = "DIAGNOSISLISTBYDATEREPORT";
            Caption = "Tanıya Göre Hasta Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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