
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
    /// Yatak Durumları Raporu
    /// </summary>
    public partial class BedStatusReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public BedStatusReport MyParentReport
            {
                get { return (BedStatusReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField LOGO;
                public TTReportField NewField191;
                public TTReportField NewField1181;
                public TTReportField RDATE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 33, 158, 39, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"YATAK DURUMLARI RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 10, 158, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 43, 40, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"LOGO";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 45, 188, 50, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Tarih";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 45, 191, 50, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 45, 207, 50, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField6,LOGO,NewField191,NewField1181,RDATE,XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class KlinikGroup : TTReportGroup
        {
            public BedStatusReport MyParentReport
            {
                get { return (BedStatusReport)ParentReport; }
            }

            new public KlinikGroupHeader Header()
            {
                return (KlinikGroupHeader)_header;
            }

            new public KlinikGroupFooter Footer()
            {
                return (KlinikGroupFooter)_footer;
            }

            public TTReportField CLINIC { get {return Header().CLINIC;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public KlinikGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KlinikGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ResBed.GetBedsByClinic_Class>("GetBedsByClinic", ResBed.GetBedsByClinic((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSICALSTATECLINIC)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KlinikGroupHeader(this);
                _footer = new KlinikGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class KlinikGroupHeader : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                
                public TTReportField CLINIC; 
                public KlinikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 207, 6, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINIC.ObjectDefName = "ResWard";
                    CLINIC.DataMember = "NAME";
                    CLINIC.TextFont.Size = 11;
                    CLINIC.TextFont.Bold = true;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"{#CLINIC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetBedsByClinic_Class dataset_GetBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetBedsByClinic_Class>(0);
                    CLINIC.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Clinic) : "");
                    CLINIC.PostFieldValueCalculation();
                    return new TTReportObject[] { CLINIC};
                }
            }
            public partial class KlinikGroupFooter : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public KlinikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 208, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetBedsByClinic_Class dataset_GetBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetBedsByClinic_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public KlinikGroup Klinik;

        public partial class OdaGrubuGroup : TTReportGroup
        {
            public BedStatusReport MyParentReport
            {
                get { return (BedStatusReport)ParentReport; }
            }

            new public OdaGrubuGroupHeader Header()
            {
                return (OdaGrubuGroupHeader)_header;
            }

            new public OdaGrubuGroupFooter Footer()
            {
                return (OdaGrubuGroupFooter)_footer;
            }

            public TTReportField ROOMGROUP { get {return Header().ROOMGROUP;} }
            public TTReportField LBLTCNO { get {return Header().LBLTCNO;} }
            public TTReportField LBLHASTAADISOYADI { get {return Header().LBLHASTAADISOYADI;} }
            public TTReportField LBLODA { get {return Header().LBLODA;} }
            public TTReportField LBLYATAK { get {return Header().LBLYATAK;} }
            public TTReportField LBLKLINIKYATISTARIHI1 { get {return Header().LBLKLINIKYATISTARIHI1;} }
            public OdaGrubuGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OdaGrubuGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                ResBed.GetBedsByClinic_Class dataSet_GetBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetBedsByClinic_Class>(0);    
                return new object[] {(dataSet_GetBedsByClinic==null ? null : dataSet_GetBedsByClinic.Clinic)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new OdaGrubuGroupHeader(this);
                _footer = new OdaGrubuGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class OdaGrubuGroupHeader : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                
                public TTReportField ROOMGROUP;
                public TTReportField LBLTCNO;
                public TTReportField LBLHASTAADISOYADI;
                public TTReportField LBLODA;
                public TTReportField LBLYATAK;
                public TTReportField LBLKLINIKYATISTARIHI1; 
                public OdaGrubuGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ROOMGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 2, 207, 7, false);
                    ROOMGROUP.Name = "ROOMGROUP";
                    ROOMGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROOMGROUP.ObjectDefName = "ResRoomGroup";
                    ROOMGROUP.DataMember = "NAME";
                    ROOMGROUP.TextFont.Size = 9;
                    ROOMGROUP.TextFont.Bold = true;
                    ROOMGROUP.TextFont.CharSet = 162;
                    ROOMGROUP.Value = @"{#Klinik.ROOMGROUP#}";

                    LBLTCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 8, 143, 13, false);
                    LBLTCNO.Name = "LBLTCNO";
                    LBLTCNO.TextFont.Size = 9;
                    LBLTCNO.TextFont.Bold = true;
                    LBLTCNO.TextFont.CharSet = 162;
                    LBLTCNO.Value = @"Yatağı Kullanan Hasta";

                    LBLHASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 8, 79, 13, false);
                    LBLHASTAADISOYADI.Name = "LBLHASTAADISOYADI";
                    LBLHASTAADISOYADI.TextFont.Size = 9;
                    LBLHASTAADISOYADI.TextFont.Bold = true;
                    LBLHASTAADISOYADI.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI.Value = @"Yatağın Kullanım Durumu";

                    LBLODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 8, 29, 13, false);
                    LBLODA.Name = "LBLODA";
                    LBLODA.TextFont.Size = 9;
                    LBLODA.TextFont.Bold = true;
                    LBLODA.TextFont.CharSet = 162;
                    LBLODA.Value = @"Oda";

                    LBLYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 8, 45, 13, false);
                    LBLYATAK.Name = "LBLYATAK";
                    LBLYATAK.TextFont.Size = 9;
                    LBLYATAK.TextFont.Bold = true;
                    LBLYATAK.TextFont.CharSet = 162;
                    LBLYATAK.Value = @"Yatak";

                    LBLKLINIKYATISTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 8, 207, 13, false);
                    LBLKLINIKYATISTARIHI1.Name = "LBLKLINIKYATISTARIHI1";
                    LBLKLINIKYATISTARIHI1.TextFont.Size = 9;
                    LBLKLINIKYATISTARIHI1.TextFont.Bold = true;
                    LBLKLINIKYATISTARIHI1.TextFont.CharSet = 162;
                    LBLKLINIKYATISTARIHI1.Value = @"Tedavi Gördüğü Klinik";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetBedsByClinic_Class dataset_GetBedsByClinic = MyParentReport.Klinik.rsGroup.GetCurrentRecord<ResBed.GetBedsByClinic_Class>(0);
                    ROOMGROUP.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.RoomGroup) : "");
                    ROOMGROUP.PostFieldValueCalculation();
                    LBLTCNO.CalcValue = LBLTCNO.Value;
                    LBLHASTAADISOYADI.CalcValue = LBLHASTAADISOYADI.Value;
                    LBLODA.CalcValue = LBLODA.Value;
                    LBLYATAK.CalcValue = LBLYATAK.Value;
                    LBLKLINIKYATISTARIHI1.CalcValue = LBLKLINIKYATISTARIHI1.Value;
                    return new TTReportObject[] { ROOMGROUP,LBLTCNO,LBLHASTAADISOYADI,LBLODA,LBLYATAK,LBLKLINIKYATISTARIHI1};
                }
            }
            public partial class OdaGrubuGroupFooter : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                 
                public OdaGrubuGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public OdaGrubuGroup OdaGrubu;

        public partial class MAINGroup : TTReportGroup
        {
            public BedStatusReport MyParentReport
            {
                get { return (BedStatusReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BEDSTATUS { get {return Body().BEDSTATUS;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField ODA { get {return Body().ODA;} }
            public TTReportField YATAK { get {return Body().YATAK;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField FOREIGNUNIQUEREFNO { get {return Body().FOREIGNUNIQUEREFNO;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField USEDBYBEDPROCEDURE { get {return Body().USEDBYBEDPROCEDURE;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                ResBed.GetBedsByClinic_Class dataSet_GetBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetBedsByClinic_Class>(0);    
                return new object[] {(dataSet_GetBedsByClinic==null ? null : dataSet_GetBedsByClinic.RoomGroup)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public BedStatusReport MyParentReport
                {
                    get { return (BedStatusReport)ParentReport; }
                }
                
                public TTReportField BEDSTATUS;
                public TTReportField TCNO;
                public TTReportField HASTAADISOYADI;
                public TTReportField ODA;
                public TTReportField YATAK;
                public TTReportField KLINIK;
                public TTReportField HASTASOYADI;
                public TTReportField HASTAADI;
                public TTReportField FOREIGNUNIQUEREFNO;
                public TTReportField UNIQUEREFNO;
                public TTReportField USEDBYBEDPROCEDURE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    BEDSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 79, 6, false);
                    BEDSTATUS.Name = "BEDSTATUS";
                    BEDSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BEDSTATUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BEDSTATUS.TextFont.Size = 9;
                    BEDSTATUS.TextFont.CharSet = 162;
                    BEDSTATUS.Value = @"";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 102, 6, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Size = 9;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 143, 6, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    ODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 29, 6, false);
                    ODA.Name = "ODA";
                    ODA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODA.ObjectDefName = "ResRoom";
                    ODA.DataMember = "NAME";
                    ODA.TextFont.Size = 9;
                    ODA.TextFont.CharSet = 162;
                    ODA.Value = @"{#Klinik.ROOM#}";

                    YATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 45, 6, false);
                    YATAK.Name = "YATAK";
                    YATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATAK.ObjectDefName = "ResBed";
                    YATAK.DataMember = "NAME";
                    YATAK.TextFont.Size = 9;
                    YATAK.TextFont.CharSet = 162;
                    YATAK.Value = @"{#Klinik.BED#}";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 207, 6, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 2, 290, 7, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.TextFont.Size = 9;
                    HASTASOYADI.TextFont.CharSet = 162;
                    HASTASOYADI.Value = @"{#Klinik.USEDBYPATIENTSURNAME#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 2, 254, 7, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.TextFont.Size = 9;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#Klinik.USEDBYPATIENTNAME#}";

                    FOREIGNUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 326, 2, 362, 7, false);
                    FOREIGNUNIQUEREFNO.Name = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUEREFNO.TextFont.Size = 9;
                    FOREIGNUNIQUEREFNO.TextFont.CharSet = 162;
                    FOREIGNUNIQUEREFNO.Value = @"{#Klinik.USEDBYPATFOREIGNUNIQUEREFNO#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 290, 2, 326, 7, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#Klinik.USEDBYPATIENTUNIQUEREFNO#}";

                    USEDBYBEDPROCEDURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 362, 2, 398, 7, false);
                    USEDBYBEDPROCEDURE.Name = "USEDBYBEDPROCEDURE";
                    USEDBYBEDPROCEDURE.Visible = EvetHayirEnum.ehHayir;
                    USEDBYBEDPROCEDURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDBYBEDPROCEDURE.TextFont.Size = 9;
                    USEDBYBEDPROCEDURE.TextFont.CharSet = 162;
                    USEDBYBEDPROCEDURE.Value = @"{#Klinik.USEDBYBEDPROCEDURE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetBedsByClinic_Class dataset_GetBedsByClinic = MyParentReport.Klinik.rsGroup.GetCurrentRecord<ResBed.GetBedsByClinic_Class>(0);
                    BEDSTATUS.CalcValue = @"";
                    TCNO.CalcValue = @"";
                    HASTAADI.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Usedbypatientname) : "");
                    HASTASOYADI.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Usedbypatientsurname) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    ODA.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Room) : "");
                    ODA.PostFieldValueCalculation();
                    YATAK.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Bed) : "");
                    YATAK.PostFieldValueCalculation();
                    KLINIK.CalcValue = @"";
                    FOREIGNUNIQUEREFNO.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Usedbypatforeignuniquerefno) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.Usedbypatientuniquerefno) : "");
                    USEDBYBEDPROCEDURE.CalcValue = (dataset_GetBedsByClinic != null ? Globals.ToStringCore(dataset_GetBedsByClinic.UsedByBedProcedure) : "");
                    return new TTReportObject[] { BEDSTATUS,TCNO,HASTAADI,HASTASOYADI,HASTAADISOYADI,ODA,YATAK,KLINIK,FOREIGNUNIQUEREFNO,UNIQUEREFNO,USEDBYBEDPROCEDURE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(String.IsNullOrEmpty(this.USEDBYBEDPROCEDURE.CalcValue))
                this.BEDSTATUS.CalcValue = "BOŞ";
            else
            {
                this.BEDSTATUS.CalcValue = "DOLU";
                if(this.FOREIGNUNIQUEREFNO.CalcValue != null && this.FOREIGNUNIQUEREFNO.CalcValue != "")
                    this.TCNO.CalcValue = "(*)" + this.FOREIGNUNIQUEREFNO.CalcValue;
                else
                    this.TCNO.CalcValue = this.UNIQUEREFNO.CalcValue;
                
                TTObjectContext context = new TTObjectContext(true);
                string sObjectID = this.USEDBYBEDPROCEDURE.CalcValue;
                SubActionProcedure sa = (SubActionProcedure)context.GetObject(new Guid(sObjectID),"SubActionProcedure");
                if(sa != null)
                {
                    if(sa.EpisodeAction != null && sa.EpisodeAction is BaseInpatientAdmission)
                        this.KLINIK.CalcValue = ((BaseInpatientAdmission)sa.EpisodeAction).TreatmentClinic.Name;
                }
            }
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

        public BedStatusReport()
        {
            Header = new HeaderGroup(this,"Header");
            Klinik = new KlinikGroup(Header,"Klinik");
            OdaGrubu = new OdaGrubuGroup(Klinik,"OdaGrubu");
            MAIN = new MAINGroup(OdaGrubu,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSICALSTATECLINIC", "00000000-0000-0000-0000-000000000000", "Yattığı Klinik", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSICALSTATECLINIC"))
                _runtimeParameters.PHYSICALSTATECLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PHYSICALSTATECLINIC"]);
            Name = "BEDSTATUSREPORT";
            Caption = "Yatak Durumları Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            UserMarginTop = 10;
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