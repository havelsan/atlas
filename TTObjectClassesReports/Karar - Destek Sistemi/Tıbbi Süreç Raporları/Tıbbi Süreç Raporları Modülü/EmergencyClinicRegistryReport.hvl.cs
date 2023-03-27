
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
    /// Acil Klinik Kayıt Defteri
    /// </summary>
    public partial class EmergencyClinicRegistryReport : TTReport
    {
#region Methods
   public IList<string> episodeActionObjectIdList =  new List<string>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EmergencyClinicRegistryReport MyParentReport
            {
                get { return (EmergencyClinicRegistryReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 32;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 293, 31, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class POLIKLINIKGroup : TTReportGroup
        {
            public EmergencyClinicRegistryReport MyParentReport
            {
                get { return (EmergencyClinicRegistryReport)ParentReport; }
            }

            new public POLIKLINIKGroupHeader Header()
            {
                return (POLIKLINIKGroupHeader)_header;
            }

            new public POLIKLINIKGroupFooter Footer()
            {
                return (POLIKLINIKGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public POLIKLINIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public POLIKLINIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new POLIKLINIKGroupHeader(this);
                _footer = new POLIKLINIKGroupFooter(this);

            }

            public partial class POLIKLINIKGroupHeader : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public POLIKLINIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 293, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }

                public override void RunScript()
                {
#region POLIKLINIK HEADER_Script
                    //  EpisodeAction episodeAction = (EpisodeAction)this.ParentReport.ReportObjectContext.GetObject(new Guid(this.EPISODEACTION.CalcValue), typeof(EpisodeAction));            
              this.NewField1.CalcValue="ACİL KAYIT DEFTERİ";
#endregion POLIKLINIK HEADER_Script
                }
            }
            public partial class POLIKLINIKGroupFooter : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                 
                public POLIKLINIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public POLIKLINIKGroup POLIKLINIK;

        public partial class ARAGroup : TTReportGroup
        {
            public EmergencyClinicRegistryReport MyParentReport
            {
                get { return (EmergencyClinicRegistryReport)ParentReport; }
            }

            new public ARAGroupHeader Header()
            {
                return (ARAGroupHeader)_header;
            }

            new public ARAGroupFooter Footer()
            {
                return (ARAGroupFooter)_footer;
            }

            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public ARAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ARAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ARAGroupHeader(this);
                _footer = new ARAGroupFooter(this);

            }

            public partial class ARAGroupHeader : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportShape NewLine11; 
                public ARAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 10, 10, 291, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.ForeColor = System.Drawing.Color.White;
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }
            public partial class ARAGroupFooter : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                 
                public ARAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ARAGroup ARA;

        public partial class BASLIKGroup : TTReportGroup
        {
            public EmergencyClinicRegistryReport MyParentReport
            {
                get { return (EmergencyClinicRegistryReport)ParentReport; }
            }

            new public BASLIKGroupHeader Header()
            {
                return (BASLIKGroupHeader)_header;
            }

            new public BASLIKGroupFooter Footer()
            {
                return (BASLIKGroupFooter)_footer;
            }

            public TTReportField LBLPROTOKOLNO11 { get {return Header().LBLPROTOKOLNO11;} }
            public TTReportField LBLTARIH11 { get {return Header().LBLTARIH11;} }
            public TTReportField LblHasta11 { get {return Header().LblHasta11;} }
            public TTReportField LbTaniKarar11 { get {return Header().LbTaniKarar11;} }
            public TTReportField LblTabib11 { get {return Header().LblTabib11;} }
            public TTReportField LblOncekiBasvuru11 { get {return Header().LblOncekiBasvuru11;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportShape NewLine1111112 { get {return Header().NewLine1111112;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportShape NewLine113 { get {return Header().NewLine113;} }
            public TTReportShape NewLine114 { get {return Header().NewLine114;} }
            public TTReportShape NewLine115 { get {return Header().NewLine115;} }
            public TTReportShape NewLine117 { get {return Header().NewLine117;} }
            public TTReportShape NewLine1111111112 { get {return Footer().NewLine1111111112;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportShape NewLine15 { get {return Footer().NewLine15;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public TTReportShape NewLine17 { get {return Footer().NewLine17;} }
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
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportField LBLPROTOKOLNO11;
                public TTReportField LBLTARIH11;
                public TTReportField LblHasta11;
                public TTReportField LbTaniKarar11;
                public TTReportField LblTabib11;
                public TTReportField LblOncekiBasvuru11;
                public TTReportShape NewLine11;
                public TTReportShape NewLine1111111;
                public TTReportShape NewLine1111112;
                public TTReportShape NewLine111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine113;
                public TTReportShape NewLine114;
                public TTReportShape NewLine115;
                public TTReportShape NewLine117; 
                public BASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLPROTOKOLNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 27, 26, false);
                    LBLPROTOKOLNO11.Name = "LBLPROTOKOLNO11";
                    LBLPROTOKOLNO11.MultiLine = EvetHayirEnum.ehEvet;
                    LBLPROTOKOLNO11.WordBreak = EvetHayirEnum.ehEvet;
                    LBLPROTOKOLNO11.TextFont.Size = 11;
                    LBLPROTOKOLNO11.TextFont.Bold = true;
                    LBLPROTOKOLNO11.TextFont.CharSet = 162;
                    LBLPROTOKOLNO11.Value = @"Poliklinik
Protokol
Nu.";

                    LBLTARIH11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 47, 26, false);
                    LBLTARIH11.Name = "LBLTARIH11";
                    LBLTARIH11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBLTARIH11.MultiLine = EvetHayirEnum.ehEvet;
                    LBLTARIH11.WordBreak = EvetHayirEnum.ehEvet;
                    LBLTARIH11.TextFont.Size = 11;
                    LBLTARIH11.TextFont.Bold = true;
                    LBLTARIH11.TextFont.CharSet = 162;
                    LBLTARIH11.Value = @"Tarih";

                    LblHasta11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 2, 81, 26, false);
                    LblHasta11.Name = "LblHasta11";
                    LblHasta11.MultiLine = EvetHayirEnum.ehEvet;
                    LblHasta11.WordBreak = EvetHayirEnum.ehEvet;
                    LblHasta11.TextFont.Size = 11;
                    LblHasta11.TextFont.Bold = true;
                    LblHasta11.TextFont.CharSet = 162;
                    LblHasta11.Value = @"Hastanın;
TC Kimlik Nu,
Adı Soyadı,Birliği,
Doğum Yeri ve Tarihi";

                    LbTaniKarar11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 2, 175, 26, false);
                    LbTaniKarar11.Name = "LbTaniKarar11";
                    LbTaniKarar11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LbTaniKarar11.MultiLine = EvetHayirEnum.ehEvet;
                    LbTaniKarar11.WordBreak = EvetHayirEnum.ehEvet;
                    LbTaniKarar11.TextFont.Size = 11;
                    LbTaniKarar11.TextFont.Bold = true;
                    LbTaniKarar11.TextFont.CharSet = 162;
                    LbTaniKarar11.Value = @"Tanı, Karar, Sarf Malzemeleri ve Muayene Tipi";

                    LblTabib11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 2, 216, 26, false);
                    LblTabib11.Name = "LblTabib11";
                    LblTabib11.MultiLine = EvetHayirEnum.ehEvet;
                    LblTabib11.WordBreak = EvetHayirEnum.ehEvet;
                    LblTabib11.TextFont.Size = 11;
                    LblTabib11.TextFont.Bold = true;
                    LblTabib11.TextFont.CharSet = 162;
                    LblTabib11.Value = @"Muayene Eden Tabibin;
Adı Soyadı,Rütbesi,
Sicil Nu,Branşı";

                    LblOncekiBasvuru11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 2, 295, 26, false);
                    LblOncekiBasvuru11.Name = "LblOncekiBasvuru11";
                    LblOncekiBasvuru11.MultiLine = EvetHayirEnum.ehEvet;
                    LblOncekiBasvuru11.WordBreak = EvetHayirEnum.ehEvet;
                    LblOncekiBasvuru11.TextFont.Size = 11;
                    LblOncekiBasvuru11.TextFont.Bold = true;
                    LblOncekiBasvuru11.TextFont.CharSet = 162;
                    LblOncekiBasvuru11.Value = @"Önceki Başvuru
Tarihleri ve Poliklinik
Protokol Numaraları";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 10, 27, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 295, 2, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 26, 295, 26, false);
                    NewLine1111112.Name = "NewLine1111112";
                    NewLine1111112.Visible = EvetHayirEnum.ehHayir;
                    NewLine1111112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 27, 3, 27, 28, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 47, 3, 47, 28, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, 2, 81, 27, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 2, 175, 27, false);
                    NewLine114.Name = "NewLine114";
                    NewLine114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 2, 295, 28, false);
                    NewLine115.Name = "NewLine115";
                    NewLine115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine115.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 216, 2, 216, 27, false);
                    NewLine117.Name = "NewLine117";
                    NewLine117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine117.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLPROTOKOLNO11.CalcValue = LBLPROTOKOLNO11.Value;
                    LBLTARIH11.CalcValue = LBLTARIH11.Value;
                    LblHasta11.CalcValue = LblHasta11.Value;
                    LbTaniKarar11.CalcValue = LbTaniKarar11.Value;
                    LblTabib11.CalcValue = LblTabib11.Value;
                    LblOncekiBasvuru11.CalcValue = LblOncekiBasvuru11.Value;
                    return new TTReportObject[] { LBLPROTOKOLNO11,LBLTARIH11,LblHasta11,LbTaniKarar11,LblTabib11,LblOncekiBasvuru11};
                }
            }
            public partial class BASLIKGroupFooter : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111111112;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17; 
                public BASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 3, 295, 3, false);
                    NewLine1111111112.Name = "NewLine1111111112";
                    NewLine1111111112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 3, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 27, 0, 27, 3, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 47, 0, 47, 3, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, 0, 81, 3, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 0, 175, 3, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 216, 0, 216, 3, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 0, 295, 3, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public BASLIKGroup BASLIK;

        public partial class MAINGroup : TTReportGroup
        {
            public EmergencyClinicRegistryReport MyParentReport
            {
                get { return (EmergencyClinicRegistryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField ISTEKTARIHI { get {return Body().ISTEKTARIHI;} }
            public TTReportField Hasta { get {return Body().Hasta;} }
            public TTReportField TaniKarar { get {return Body().TaniKarar;} }
            public TTReportField Tabib { get {return Body().Tabib;} }
            public TTReportField OncekiBasvuru { get {return Body().OncekiBasvuru;} }
            public TTReportShape NewLine1171 { get {return Body().NewLine1171;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public TTReportShape NewLine1141 { get {return Body().NewLine1141;} }
            public TTReportShape NewLine1151 { get {return Body().NewLine1151;} }
            public TTReportShape NewLine1161 { get {return Body().NewLine1161;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField SikayetMuayeneBulgulariOzeti { get {return Body().SikayetMuayeneBulgulariOzeti;} }
            public TTReportField OBJECTID1 { get {return Body().OBJECTID1;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
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
                list[0] = new TTReportNqlData<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class>("GetEmergencyInterventionsByDateForReport", EmergencyIntervention.GetEmergencyInterventionsByDateForReport((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportField PROTOKOLNO;
                public TTReportField ISTEKTARIHI;
                public TTReportField Hasta;
                public TTReportField TaniKarar;
                public TTReportField Tabib;
                public TTReportField OncekiBasvuru;
                public TTReportShape NewLine1171;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine1141;
                public TTReportShape NewLine1151;
                public TTReportShape NewLine1161;
                public TTReportShape NewLine111;
                public TTReportField SikayetMuayeneBulgulariOzeti;
                public TTReportField OBJECTID1;
                public TTReportField TARIH; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 27, 19, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROTOKOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    ISTEKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 47, 19, false);
                    ISTEKTARIHI.Name = "ISTEKTARIHI";
                    ISTEKTARIHI.TextFormat = @"Short Date";
                    ISTEKTARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISTEKTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.TextFont.Size = 9;
                    ISTEKTARIHI.TextFont.CharSet = 162;
                    ISTEKTARIHI.Value = @"";

                    Hasta = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 1, 81, 19, false);
                    Hasta.Name = "Hasta";
                    Hasta.FieldType = ReportFieldTypeEnum.ftVariable;
                    Hasta.MultiLine = EvetHayirEnum.ehEvet;
                    Hasta.NoClip = EvetHayirEnum.ehEvet;
                    Hasta.WordBreak = EvetHayirEnum.ehEvet;
                    Hasta.ExpandTabs = EvetHayirEnum.ehEvet;
                    Hasta.TextFont.Size = 9;
                    Hasta.TextFont.CharSet = 162;
                    Hasta.Value = @"";

                    TaniKarar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 175, 19, false);
                    TaniKarar.Name = "TaniKarar";
                    TaniKarar.MultiLine = EvetHayirEnum.ehEvet;
                    TaniKarar.NoClip = EvetHayirEnum.ehEvet;
                    TaniKarar.WordBreak = EvetHayirEnum.ehEvet;
                    TaniKarar.ExpandTabs = EvetHayirEnum.ehEvet;
                    TaniKarar.TextFont.Size = 9;
                    TaniKarar.TextFont.CharSet = 162;
                    TaniKarar.Value = @"";

                    Tabib = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 1, 216, 19, false);
                    Tabib.Name = "Tabib";
                    Tabib.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tabib.MultiLine = EvetHayirEnum.ehEvet;
                    Tabib.NoClip = EvetHayirEnum.ehEvet;
                    Tabib.WordBreak = EvetHayirEnum.ehEvet;
                    Tabib.ExpandTabs = EvetHayirEnum.ehEvet;
                    Tabib.TextFont.Size = 9;
                    Tabib.TextFont.CharSet = 162;
                    Tabib.Value = @"";

                    OncekiBasvuru = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 1, 295, 19, false);
                    OncekiBasvuru.Name = "OncekiBasvuru";
                    OncekiBasvuru.MultiLine = EvetHayirEnum.ehEvet;
                    OncekiBasvuru.NoClip = EvetHayirEnum.ehEvet;
                    OncekiBasvuru.WordBreak = EvetHayirEnum.ehEvet;
                    OncekiBasvuru.ExpandTabs = EvetHayirEnum.ehEvet;
                    OncekiBasvuru.TextFont.Size = 9;
                    OncekiBasvuru.TextFont.CharSet = 162;
                    OncekiBasvuru.Value = @"";

                    NewLine1171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 295, 0, false);
                    NewLine1171.Name = "NewLine1171";
                    NewLine1171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 27, 1, 27, 20, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 47, 1, 47, 19, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, 1, 81, 19, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 1, 175, 19, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 216, 0, 216, 19, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1151.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 0, 295, 19, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 10, 19, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    SikayetMuayeneBulgulariOzeti = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 15, 338, 19, false);
                    SikayetMuayeneBulgulariOzeti.Name = "SikayetMuayeneBulgulariOzeti";
                    SikayetMuayeneBulgulariOzeti.Visible = EvetHayirEnum.ehHayir;
                    SikayetMuayeneBulgulariOzeti.Value = @"";

                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 3, 329, 8, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.Value = @"{#OBJECTID1#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 9, 327, 14, false);
                    TARIH.Name = "TARIH";
                    TARIH.Visible = EvetHayirEnum.ehHayir;
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.Value = @"{#REQUESTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class dataset_GetEmergencyInterventionsByDateForReport = ParentGroup.rsGroup.GetCurrentRecord<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class>(0);
                    PROTOKOLNO.CalcValue = PROTOKOLNO.Value;
                    ISTEKTARIHI.CalcValue = ISTEKTARIHI.Value;
                    Hasta.CalcValue = @"";
                    TaniKarar.CalcValue = TaniKarar.Value;
                    Tabib.CalcValue = @"";
                    OncekiBasvuru.CalcValue = OncekiBasvuru.Value;
                    SikayetMuayeneBulgulariOzeti.CalcValue = SikayetMuayeneBulgulariOzeti.Value;
                    OBJECTID1.CalcValue = (dataset_GetEmergencyInterventionsByDateForReport != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionsByDateForReport.Objectid1) : "");
                    TARIH.CalcValue = (dataset_GetEmergencyInterventionsByDateForReport != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionsByDateForReport.RequestDate) : "");
                    return new TTReportObject[] { PROTOKOLNO,ISTEKTARIHI,Hasta,TaniKarar,Tabib,OncekiBasvuru,SikayetMuayeneBulgulariOzeti,OBJECTID1,TARIH};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                            
//            String currentEpisodeObjID = this.OBJECTID1.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            bool control = true;;
//            Episode currentEpisode = (Episode)context.GetObject(new Guid(currentEpisodeObjID), "Episode");
//            if(currentEpisode != null)
//            {
//                foreach (EpisodeAction episodeAction in currentEpisode.EpisodeActions)
//                {
//                    if(episodeAction.ProcedureSpeciality != null)
//                    {
//                        if ("4400".Equals(episodeAction.ProcedureSpeciality.Code) && (episodeAction is PatientExamination || episodeAction is DentalExamination))
//                        {
//                            foreach ( string episodeActionObjectId in ((EmergencyClinicRegistryReport)ParentReport).episodeActionObjectIdList)
//                            {
//                                if(episodeActionObjectId == episodeAction.ObjectID.ToString())
//                                    control = false;
//                                else
//                                    control = true;
//                            }
//                            
//                            if(control)
//                            {
//                                this.ISTEKTARIHI.CalcValue = this.TARIH.CalcValue  ;
//                                ((EmergencyClinicRegistryReport)ParentReport).episodeActionObjectIdList.Add (episodeAction.ObjectID.ToString());
//                                
//                                this.PROTOKOLNO.CalcValue = (episodeAction is PatientExamination) ? (((PatientExamination)episodeAction).ProtocolNo != null ? ((PatientExamination)episodeAction).ProtocolNo.ToString() : "") :
//                                    (episodeAction is DentalExamination) ? (((DentalExamination)episodeAction).ProtocolNo != null ? ((DentalExamination)episodeAction).ProtocolNo.ToString() : "") : "";
//                                
//                                if (this.PROTOKOLNO == null || this.PROTOKOLNO.CalcValue == null)
//                                    this.PROTOKOLNO.CalcValue = "";
//                                
//                                try {
//                                    this.SikayetMuayeneBulgulariOzeti.CalcValue = (episodeAction is PatientExamination) ? (((PatientExamination)episodeAction).Complaint != null ? TTObjectClasses.Common.GetTextOfRTFString(((PatientExamination)episodeAction).Complaint.ToString()) : "" ) + " \r\n " +
//                                        (((PatientExamination)episodeAction).PhysicalExamination != null ? TTObjectClasses.Common.GetTextOfRTFString(((PatientExamination)episodeAction).PhysicalExamination.ToString()) : "") + " \r\n " +
//                                        (((PatientExamination)episodeAction).ExaminationSummary != null ? TTObjectClasses.Common.GetTextOfRTFString(((PatientExamination)episodeAction).ExaminationSummary.ToString())  : "" ) : "" ;
//                                    if (this.SikayetMuayeneBulgulariOzeti == null || this.SikayetMuayeneBulgulariOzeti.CalcValue == null)
//                                        this.SikayetMuayeneBulgulariOzeti.CalcValue = "";
//                                }
//                                catch(Exception e) {
//                                    this.SikayetMuayeneBulgulariOzeti.CalcValue = "";
//                                }
//                                
//
//                                TTObjectContext tto = new TTObjectContext(true);
//                                IBindingList episodeActionList = null;
//                                if (episodeAction.MasterResource != null && currentEpisode.Patient != null && episodeAction != null && this.TARIH.CalcValue != "")
//                                {
//                                    episodeActionList = EpisodeAction.GetAllExaminationsExceptCurrentExamination(tto, episodeAction.MasterResource.ObjectID, currentEpisode.Patient.ObjectID.ToString(), episodeAction.ObjectID, Convert.ToDateTime(this.TARIH.CalcValue));
//                                }
//                                if (episodeActionList != null)
//                                {
//                                    foreach (EpisodeAction examination in episodeActionList)
//                                    {
//                                        if (examination.Emergency.Value)
//                                            this.OncekiBasvuru.CalcValue += (examination is PatientExamination) ? ((PatientExamination)examination).ProtocolNo + " - " + ((PatientExamination)examination).RequestDate.Value.ToShortDateString() + "\r\n" :
//                                                (examination is DentalExamination) ? ((DentalExamination)examination).ProtocolNo + " - " + ((DentalExamination)examination).RequestDate.Value.ToShortDateString() + "\r\n" : "";
//                                        if (this.OncekiBasvuru == null || this.OncekiBasvuru.CalcValue == null)
//                                            this.OncekiBasvuru.CalcValue = "";
//                                    }
//
//                                    List<String> eklenenTanilar = new List<String>();
//                                    if (episodeAction.Episode.SecDiagnosis.Count > 0)
//                                    {
//                                        foreach (DiagnosisGrid diagnose in episodeAction.Episode.SecDiagnosis)
//                                        {
//                                            if (!eklenenTanilar.Contains(diagnose.Diagnose.Code))
//                                            {
//                                                this.TaniKarar.CalcValue += (diagnose.Diagnose != null) ? diagnose.Diagnose.Code + "-" + diagnose.Diagnose.Name + ", " : "";
//                                                if (this.TaniKarar == null || this.TaniKarar.CalcValue == null)
//                                                    this.TaniKarar.CalcValue = "";
//                                                eklenenTanilar.Add(diagnose.Diagnose.Code);
//                                            }
//                                        }
//                                        this.TaniKarar.CalcValue += "\r\n";
//
//
//                                        try
//                                        {
//                                            foreach (TreatmentDischarge treatment in episodeAction.Episode.TreatmentDischarges)
//                                                this.TaniKarar.CalcValue += (treatment != null) ? (treatment.Conclusion != null ? (TTObjectClasses.Common.GetTextOfRTFString(treatment.Conclusion.ToString()) + ", ") : "" ) : "";
//                                            this.TaniKarar.CalcValue += "\r\n";
//                                        }
//                                        catch (Exception e)
//                                        {
//
//                                        }
//
//
//
//                                        if (episodeAction.Episode.SubActionMaterials.Count > 0)
//                                        {
//                                            foreach (SubActionMaterial material in episodeAction.Episode.SubActionMaterials)
//                                            {
//                                                if (!eklenenTanilar.Contains(material.Material.Code))
//                                                {
//                                                    this.TaniKarar.CalcValue += (material.Material != null) ? material.Material.Code + "-" + material.Material.Name + "-" + material.Amount + ", " : "";
//                                                    if (this.TaniKarar == null || this.TaniKarar.CalcValue == null)
//                                                        this.TaniKarar.CalcValue = "";
//                                                    eklenenTanilar.Add(material.Material.Code);
//                                                }
//                                            }
//                                        }
//                                    }
//                                    else
//                                    {
//                                        try
//                                        {
//                                            foreach (TreatmentDischarge treatment in episodeAction.Episode.TreatmentDischarges)
//                                                this.TaniKarar.CalcValue += (treatment != null) ? (treatment.Conclusion != null ? (TTObjectClasses.Common.GetTextOfRTFString(treatment.Conclusion.ToString()) + ", ") : "" ) : "";
//                                            if (this.TaniKarar == null || this.TaniKarar.CalcValue == null)
//                                                this.TaniKarar.CalcValue = "";
//                                        }
//                                        catch (Exception e)
//                                        {
//
//                                        }
//
//
//                                        if (episodeAction.Episode.SubActionMaterials.Count > 0)
//                                        {
//                                            foreach (SubActionMaterial material in episodeAction.Episode.SubActionMaterials)
//                                            {
//                                                if (!eklenenTanilar.Contains(material.Material.Code))
//                                                {
//                                                    this.TaniKarar.CalcValue += (material.Material != null) ? material.Material.Code + "-" + material.Material.Name + "-" + material.Amount + ", " : "";
//                                                    eklenenTanilar.Add(material.Material.Code);
//                                                }
//                                            }
//                                            if (this.TaniKarar == null || this.TaniKarar.CalcValue == null)
//                                                this.TaniKarar.CalcValue = "";
//                                        }
//                                    }
//
//                                    this.Hasta.CalcValue = (currentEpisode.Patient.ForeignUniqueRefNo == null || currentEpisode.Patient.ForeignUniqueRefNo.Value == 0) ? (currentEpisode.Patient.UniqueRefNo != null ? currentEpisode.Patient.UniqueRefNo.Value.ToString() : "") : "(*)" + currentEpisode.Patient.ForeignUniqueRefNo.Value.ToString();
//                                    this.Hasta.CalcValue += "\r\n" + currentEpisode.Patient.Name + " " + currentEpisode.Patient.Surname + "\r\n";
//                                    this.Hasta.CalcValue += episodeAction.Episode.PatientAdmission.ObjectDef.Description + "\r\n";
//                                    this.Hasta.CalcValue += (currentEpisode.Patient.Rank != null && currentEpisode.Patient.Rank.Code != null && currentEpisode.Patient.Rank.Code.Value != 0) ? currentEpisode.Patient.Rank.Code.Value.ToString() + "\r\n" : "";
//                                    this.Hasta.CalcValue += (currentEpisode.Patient.MilitaryUnit != null && currentEpisode.Patient.MilitaryUnit.Code != null && currentEpisode.Patient.MilitaryUnit.Code != "") ? currentEpisode.Patient.MilitaryUnit.Code + "\r\n" : "";
//                                    this.Hasta.CalcValue += currentEpisode.Patient.CityOfBirth + " / " +  (currentEpisode.Patient.BirthDate != null ? Convert.ToDateTime(currentEpisode.Patient.BirthDate.Value).ToShortDateString() : "" );
//
//
//                                    if (this.Hasta == null || this.Hasta.CalcValue == null)
//                                        this.Hasta.CalcValue = "";
//
//                                    List<String> eklenenDoktorlar = new List<String>();
//                                    string specialtyText = "";
//                                    if (episodeAction.ProcedureDoctor != null)
//                                    {
//                                        this.Tabib.CalcValue += episodeAction.ProcedureDoctor.Rank != null ? (episodeAction.ProcedureDoctor.Rank.ShortName + " " ): null;
//                                        this.Tabib.CalcValue += episodeAction.ProcedureDoctor.Name;
//                                        if (episodeAction.ProcedureDoctor.ResourceSpecialities != null && episodeAction.ProcedureDoctor.ResourceSpecialities.Count > 0)
//                                        {
//                                            foreach (ResourceSpecialityGrid specialty in episodeAction.ProcedureDoctor.ResourceSpecialities)
//                                            {
//                                                if (specialty.MainSpeciality != null)
//                                                {
//                                                    if (specialty.MainSpeciality.Value != null && specialty.MainSpeciality.Value)
//                                                    {
//                                                        if (specialty.Speciality != null)
//                                                        {
//                                                            if (specialty.Speciality.Name != null)
//                                                            {
//                                                                if (!eklenenDoktorlar.Contains(specialty.Speciality.Name))
//                                                                {
//                                                                    this.Tabib.CalcValue += specialty.Speciality.Name;
//                                                                    this.Tabib.CalcValue += (!specialty.Speciality.Name.Contains("Uzm") && !specialty.Speciality.Name.Contains("UZM")) ? " Uzm.\r\n" : "\r\n";
//                                                                    eklenenDoktorlar.Add(specialty.Speciality.Name);
//                                                                }
//                                                            }
//                                                        }
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    if (specialty.Speciality != null)
//                                                    {
//                                                        if (specialty.Speciality.Name != null)
//                                                        {
//                                                            if (!eklenenDoktorlar.Contains(specialty.Speciality.Name))
//                                                            {
//                                                                specialtyText += specialty.Speciality.Name;
//                                                                specialtyText += (specialty.Speciality.Name.Contains("Uzm") == false && specialty.Speciality.Name.Contains("UZM") == false) ? " Uzm.\r\n" : "\r\n";
//                                                                eklenenDoktorlar.Add(specialty.Speciality.Name);
//                                                            }
//                                                        }
//                                                    }
//                                                }
//                                            }
//                                            this.Tabib.CalcValue += specialtyText;
//
//                                            if (this.Tabib == null || this.Tabib.CalcValue == null)
//                                                this.Tabib.CalcValue = "";
//                                        }
//                                    }
//                                    else this.Tabib.CalcValue += "";
//
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.FollowUpExamination)
//                                        this.TaniKarar.CalcValue += "Kontrol Muayenesi";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.PatientExamination)
//                                        this.TaniKarar.CalcValue += "Normal Muayene";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.DentalExamination)
//                                        this.TaniKarar.CalcValue += "Diş Muayenesi";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.EmergencyIntervention)
//                                        this.TaniKarar.CalcValue += "Acil Muayene";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.HealthCommitteeExamination)
//                                        this.TaniKarar.CalcValue += "Sağlık Kurulu Muayenesi";
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                    // Automatically generated part. -->
//                }
//            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ALKOLDARPGroup : TTReportGroup
        {
            public EmergencyClinicRegistryReport MyParentReport
            {
                get { return (EmergencyClinicRegistryReport)ParentReport; }
            }

            new public ALKOLDARPGroupBody Body()
            {
                return (ALKOLDARPGroupBody)_body;
            }
            public TTReportField PROTOKOLNO1 { get {return Body().PROTOKOLNO1;} }
            public TTReportField OBJECTID2 { get {return Body().OBJECTID2;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportField ISTEKTARIHI1 { get {return Body().ISTEKTARIHI1;} }
            public TTReportShape NewLine11211 { get {return Body().NewLine11211;} }
            public TTReportField Hasta1 { get {return Body().Hasta1;} }
            public TTReportShape NewLine11711 { get {return Body().NewLine11711;} }
            public TTReportField TARIH1 { get {return Body().TARIH1;} }
            public TTReportField TaniKarar1 { get {return Body().TaniKarar1;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
            public TTReportShape NewLine11411 { get {return Body().NewLine11411;} }
            public TTReportShape NewLine11412 { get {return Body().NewLine11412;} }
            public TTReportShape NewLine11413 { get {return Body().NewLine11413;} }
            public TTReportField SikayetMuayeneBulgulariOzeti1 { get {return Body().SikayetMuayeneBulgulariOzeti1;} }
            public TTReportField Tabib1 { get {return Body().Tabib1;} }
            public TTReportField OncekiBasvuru1 { get {return Body().OncekiBasvuru1;} }
            public ALKOLDARPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ALKOLDARPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class>("GetPatientExamiationsForBeatenAndAlcohol", PatientExamination.GetPatientExamiationsForBeatenAndAlcohol((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ALKOLDARPGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ALKOLDARPGroupBody : TTReportSection
            {
                public EmergencyClinicRegistryReport MyParentReport
                {
                    get { return (EmergencyClinicRegistryReport)ParentReport; }
                }
                
                public TTReportField PROTOKOLNO1;
                public TTReportField OBJECTID2;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportField ISTEKTARIHI1;
                public TTReportShape NewLine11211;
                public TTReportField Hasta1;
                public TTReportShape NewLine11711;
                public TTReportField TARIH1;
                public TTReportField TaniKarar1;
                public TTReportShape NewLine11311;
                public TTReportShape NewLine11411;
                public TTReportShape NewLine11412;
                public TTReportShape NewLine11413;
                public TTReportField SikayetMuayeneBulgulariOzeti1;
                public TTReportField Tabib1;
                public TTReportField OncekiBasvuru1; 
                public ALKOLDARPGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    PROTOKOLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 27, 19, false);
                    PROTOKOLNO1.Name = "PROTOKOLNO1";
                    PROTOKOLNO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROTOKOLNO1.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOKOLNO1.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOKOLNO1.TextFont.Size = 9;
                    PROTOKOLNO1.TextFont.CharSet = 162;
                    PROTOKOLNO1.Value = @"";

                    OBJECTID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 1, 325, 6, false);
                    OBJECTID2.Name = "OBJECTID2";
                    OBJECTID2.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID2.Value = @"{#OBJECTID1#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 18, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 27, 0, 27, 19, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    ISTEKTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 47, 19, false);
                    ISTEKTARIHI1.Name = "ISTEKTARIHI1";
                    ISTEKTARIHI1.TextFormat = @"Short Date";
                    ISTEKTARIHI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISTEKTARIHI1.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI1.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI1.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI1.TextFont.Size = 9;
                    ISTEKTARIHI1.TextFont.CharSet = 162;
                    ISTEKTARIHI1.Value = @"";

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 47, 0, 47, 18, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211.ExtendTo = ExtendToEnum.extPageHeight;

                    Hasta1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 1, 81, 19, false);
                    Hasta1.Name = "Hasta1";
                    Hasta1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Hasta1.MultiLine = EvetHayirEnum.ehEvet;
                    Hasta1.NoClip = EvetHayirEnum.ehEvet;
                    Hasta1.WordBreak = EvetHayirEnum.ehEvet;
                    Hasta1.ExpandTabs = EvetHayirEnum.ehEvet;
                    Hasta1.TextFont.Size = 9;
                    Hasta1.TextFont.CharSet = 162;
                    Hasta1.Value = @"";

                    NewLine11711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 295, 0, false);
                    NewLine11711.Name = "NewLine11711";
                    NewLine11711.DrawStyle = DrawStyleConstants.vbSolid;

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 7, 326, 12, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.Visible = EvetHayirEnum.ehHayir;
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.Value = @"{#REQUESTDATE#}";

                    TaniKarar1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 175, 19, false);
                    TaniKarar1.Name = "TaniKarar1";
                    TaniKarar1.MultiLine = EvetHayirEnum.ehEvet;
                    TaniKarar1.NoClip = EvetHayirEnum.ehEvet;
                    TaniKarar1.WordBreak = EvetHayirEnum.ehEvet;
                    TaniKarar1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TaniKarar1.TextFont.Size = 9;
                    TaniKarar1.TextFont.CharSet = 162;
                    TaniKarar1.Value = @"";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 81, 0, 81, 18, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 0, 175, 18, false);
                    NewLine11411.Name = "NewLine11411";
                    NewLine11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11411.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 216, 0, 216, 18, false);
                    NewLine11412.Name = "NewLine11412";
                    NewLine11412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11412.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11413 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 0, 295, 18, false);
                    NewLine11413.Name = "NewLine11413";
                    NewLine11413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11413.ExtendTo = ExtendToEnum.extPageHeight;

                    SikayetMuayeneBulgulariOzeti1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 13, 337, 17, false);
                    SikayetMuayeneBulgulariOzeti1.Name = "SikayetMuayeneBulgulariOzeti1";
                    SikayetMuayeneBulgulariOzeti1.Visible = EvetHayirEnum.ehHayir;
                    SikayetMuayeneBulgulariOzeti1.Value = @"";

                    Tabib1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 1, 216, 19, false);
                    Tabib1.Name = "Tabib1";
                    Tabib1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tabib1.MultiLine = EvetHayirEnum.ehEvet;
                    Tabib1.NoClip = EvetHayirEnum.ehEvet;
                    Tabib1.WordBreak = EvetHayirEnum.ehEvet;
                    Tabib1.ExpandTabs = EvetHayirEnum.ehEvet;
                    Tabib1.TextFont.Size = 9;
                    Tabib1.TextFont.CharSet = 162;
                    Tabib1.Value = @"";

                    OncekiBasvuru1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 295, 19, false);
                    OncekiBasvuru1.Name = "OncekiBasvuru1";
                    OncekiBasvuru1.MultiLine = EvetHayirEnum.ehEvet;
                    OncekiBasvuru1.NoClip = EvetHayirEnum.ehEvet;
                    OncekiBasvuru1.WordBreak = EvetHayirEnum.ehEvet;
                    OncekiBasvuru1.ExpandTabs = EvetHayirEnum.ehEvet;
                    OncekiBasvuru1.TextFont.Size = 9;
                    OncekiBasvuru1.TextFont.CharSet = 162;
                    OncekiBasvuru1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class dataset_GetPatientExamiationsForBeatenAndAlcohol = ParentGroup.rsGroup.GetCurrentRecord<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class>(0);
                    PROTOKOLNO1.CalcValue = PROTOKOLNO1.Value;
                    OBJECTID2.CalcValue = (dataset_GetPatientExamiationsForBeatenAndAlcohol != null ? Globals.ToStringCore(dataset_GetPatientExamiationsForBeatenAndAlcohol.Objectid1) : "");
                    ISTEKTARIHI1.CalcValue = ISTEKTARIHI1.Value;
                    Hasta1.CalcValue = @"";
                    TARIH1.CalcValue = (dataset_GetPatientExamiationsForBeatenAndAlcohol != null ? Globals.ToStringCore(dataset_GetPatientExamiationsForBeatenAndAlcohol.RequestDate) : "");
                    TaniKarar1.CalcValue = TaniKarar1.Value;
                    SikayetMuayeneBulgulariOzeti1.CalcValue = SikayetMuayeneBulgulariOzeti1.Value;
                    Tabib1.CalcValue = @"";
                    OncekiBasvuru1.CalcValue = OncekiBasvuru1.Value;
                    return new TTReportObject[] { PROTOKOLNO1,OBJECTID2,ISTEKTARIHI1,Hasta1,TARIH1,TaniKarar1,SikayetMuayeneBulgulariOzeti1,Tabib1,OncekiBasvuru1};
                }

                public override void RunScript()
                {
#region ALKOLDARP BODY_Script
                    //            String currentEpisodeObjID = this.OBJECTID2.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            bool control = true;;
//            Episode currentEpisode = (Episode)context.GetObject(new Guid(currentEpisodeObjID), "Episode");
//            if(currentEpisode != null)
//            {
//                foreach (EpisodeAction episodeAction in currentEpisode.EpisodeActions)
//                {
//                    if(episodeAction.ProcedureSpeciality != null)
//                    {
//                        if (episodeAction is PatientExamination || episodeAction is DentalExamination)
//                        {
//                            foreach ( string episodeActionObjectId in ((EmergencyClinicRegistryReport)ParentReport).episodeActionObjectIdList)
//                            {
//                                if(episodeActionObjectId == episodeAction.ObjectID.ToString())
//                                    control = false;
//                                else
//                                    control = true;
//                            }
//                            
//                            if(control)
//                            {
//                                this.ISTEKTARIHI1.CalcValue = this.TARIH1.CalcValue  ;
//                                ((EmergencyClinicRegistryReport)ParentReport).episodeActionObjectIdList.Add (episodeAction.ObjectID.ToString());
//                                
//                                this.PROTOKOLNO1.CalcValue = (episodeAction is PatientExamination) ? (((PatientExamination)episodeAction).ProtocolNo != null ? ((PatientExamination)episodeAction).ProtocolNo.ToString() : "") :
//                                    (episodeAction is DentalExamination) ? (((DentalExamination)episodeAction).ProtocolNo != null ? ((DentalExamination)episodeAction).ProtocolNo.ToString() : "") : "";
//                                if (this.PROTOKOLNO1 == null || this.PROTOKOLNO1.CalcValue == null)
//                                    this.PROTOKOLNO1.CalcValue = "";
//                                
//                                try {
//                                    this.SikayetMuayeneBulgulariOzeti1.CalcValue = (episodeAction is PatientExamination) ? (((PatientExamination)episodeAction).Complaint != null ? TTObjectClasses.Common.GetTextOfRTFString(((PatientExamination)episodeAction).Complaint.ToString()) : "" ) + " \r\n " +
//                                        (((PatientExamination)episodeAction).PhysicalExamination != null ? TTObjectClasses.Common.GetTextOfRTFString(((PatientExamination)episodeAction).PhysicalExamination.ToString()) : "") + " \r\n " +
//                                        (((PatientExamination)episodeAction).ExaminationSummary != null ? TTObjectClasses.Common.GetTextOfRTFString(((PatientExamination)episodeAction).ExaminationSummary.ToString())  : "" ) : "" ;
//                                    if (this.SikayetMuayeneBulgulariOzeti1 == null || this.SikayetMuayeneBulgulariOzeti1.CalcValue == null)
//                                        this.SikayetMuayeneBulgulariOzeti1.CalcValue = "";
//                                }
//                                catch(Exception e) {
//                                    this.SikayetMuayeneBulgulariOzeti1.CalcValue = "";
//                                }
//                                
//
//                                TTObjectContext tto = new TTObjectContext(true);
//                                IBindingList episodeActionList = null;
//                                if (episodeAction.MasterResource != null && currentEpisode.Patient != null && episodeAction != null && this.TARIH1.CalcValue != "")
//                                {
//                                    episodeActionList = EpisodeAction.GetAllExaminationsExceptCurrentExamination(tto, episodeAction.MasterResource.ObjectID, currentEpisode.Patient.ObjectID.ToString(), episodeAction.ObjectID, Convert.ToDateTime(this.TARIH1.CalcValue));
//                                }
//                                if (episodeActionList != null)
//                                {
//                                    foreach (EpisodeAction examination in episodeActionList)
//                                    {
//                                        if (examination.Emergency.Value)
//                                            this.OncekiBasvuru1.CalcValue += (examination is PatientExamination) ? ((PatientExamination)examination).ProtocolNo + " - " + ((PatientExamination)examination).RequestDate.Value.ToShortDateString() + "\r\n" :
//                                                (examination is DentalExamination) ? ((DentalExamination)examination).ProtocolNo + " - " + ((DentalExamination)examination).RequestDate.Value.ToShortDateString() + "\r\n" : "";
//                                        if (this.OncekiBasvuru1 == null || this.OncekiBasvuru1.CalcValue == null)
//                                            this.OncekiBasvuru1.CalcValue = "";
//                                    }
//
//                                    List<String> eklenenTanilar = new List<String>();
//                                    if (episodeAction.Episode.SecDiagnosis.Count > 0)
//                                    {
//                                        foreach (DiagnosisGrid diagnose in episodeAction.Episode.SecDiagnosis)
//                                        {
//                                            if (!eklenenTanilar.Contains(diagnose.Diagnose.Code))
//                                            {
//                                                this.TaniKarar1.CalcValue += (diagnose.Diagnose != null) ? diagnose.Diagnose.Code + "-" + diagnose.Diagnose.Name + ", " : "";
//                                                if (this.TaniKarar1 == null || this.TaniKarar1.CalcValue == null)
//                                                    this.TaniKarar1.CalcValue = "";
//                                                eklenenTanilar.Add(diagnose.Diagnose.Code);
//                                            }
//                                        }
//                                        this.TaniKarar1.CalcValue += "\r\n";
//
//
//                                        try
//                                        {
//                                            foreach (TreatmentDischarge treatment in episodeAction.Episode.TreatmentDischarges)
//                                                this.TaniKarar1.CalcValue += (treatment != null) ? (treatment.Conclusion != null ? (TTObjectClasses.Common.GetTextOfRTFString(treatment.Conclusion.ToString()) + ", ") : "" ) : "";
//                                            this.TaniKarar1.CalcValue += "\r\n";
//                                        }
//                                        catch (Exception e)
//                                        {
//
//                                        }
//
//
//
//                                        if (episodeAction.Episode.SubActionMaterials.Count > 0)
//                                        {
//                                            foreach (SubActionMaterial material in episodeAction.Episode.SubActionMaterials)
//                                            {
//                                                if (!eklenenTanilar.Contains(material.Material.Code))
//                                                {
//                                                    this.TaniKarar1.CalcValue += (material.Material != null) ? material.Material.Code + "-" + material.Material.Name + "-" + material.Amount + ", " : "";
//                                                    if (this.TaniKarar1 == null || this.TaniKarar1.CalcValue == null)
//                                                        this.TaniKarar1.CalcValue = "";
//                                                    eklenenTanilar.Add(material.Material.Code);
//                                                }
//                                            }
//                                        }
//                                    }
//                                    else
//                                    {
//                                        try
//                                        {
//                                            foreach (TreatmentDischarge treatment in episodeAction.Episode.TreatmentDischarges)
//                                                this.TaniKarar1.CalcValue += (treatment != null) ? (treatment.Conclusion != null ? (TTObjectClasses.Common.GetTextOfRTFString(treatment.Conclusion.ToString()) + ", ") : "" ) : "";
//                                            if (this.TaniKarar1 == null || this.TaniKarar1.CalcValue == null)
//                                                this.TaniKarar1.CalcValue = "";
//                                        }
//                                        catch (Exception e)
//                                        {
//
//                                        }
//
//
//                                        if (episodeAction.Episode.SubActionMaterials.Count > 0)
//                                        {
//                                            foreach (SubActionMaterial material in episodeAction.Episode.SubActionMaterials)
//                                            {
//                                                if (!eklenenTanilar.Contains(material.Material.Code))
//                                                {
//                                                    this.TaniKarar1.CalcValue += (material.Material != null) ? material.Material.Code + "-" + material.Material.Name + "-" + material.Amount + ", " : "";
//                                                    eklenenTanilar.Add(material.Material.Code);
//                                                }
//                                            }
//                                            if (this.TaniKarar1 == null || this.TaniKarar1.CalcValue == null)
//                                                this.TaniKarar1.CalcValue = "";
//                                        }
//                                    }
//
//                                    this.Hasta1.CalcValue = (currentEpisode.Patient.ForeignUniqueRefNo == null || currentEpisode.Patient.ForeignUniqueRefNo.Value == 0) ? (currentEpisode.Patient.UniqueRefNo != null ? currentEpisode.Patient.UniqueRefNo.Value.ToString() : "") : "(*)" + currentEpisode.Patient.ForeignUniqueRefNo.Value.ToString();
//                                    this.Hasta1.CalcValue += "\r\n" + currentEpisode.Patient.Name + " " + currentEpisode.Patient.Surname + "\r\n";
//                                    this.Hasta1.CalcValue += episodeAction.Episode.PatientAdmission.ObjectDef.Description + "\r\n";
//                                    this.Hasta1.CalcValue += (currentEpisode.Patient.Rank != null && currentEpisode.Patient.Rank.Code != null && currentEpisode.Patient.Rank.Code.Value != 0) ? currentEpisode.Patient.Rank.Code.Value.ToString() + "\r\n" : "";
//                                    this.Hasta1.CalcValue += (currentEpisode.Patient.MilitaryUnit != null && currentEpisode.Patient.MilitaryUnit.Code != null && currentEpisode.Patient.MilitaryUnit.Code != "") ? currentEpisode.Patient.MilitaryUnit.Code + "\r\n" : "";
//                                    this.Hasta1.CalcValue += currentEpisode.Patient.CityOfBirth + " / " +  (currentEpisode.Patient.BirthDate != null ? Convert.ToDateTime(currentEpisode.Patient.BirthDate.Value).ToShortDateString() : "" );
//
//
//                                    if (this.Hasta1 == null || this.Hasta1.CalcValue == null)
//                                        this.Hasta1.CalcValue = "";
//
//                                    List<String> eklenenDoktorlar = new List<String>();
//                                    string specialtyText = "";
//                                    if (episodeAction.ProcedureDoctor != null)
//                                    {
//                                        this.Tabib1.CalcValue += episodeAction.ProcedureDoctor.Rank != null ? (episodeAction.ProcedureDoctor.Rank.ShortName + " " ): null;
//                                        this.Tabib1.CalcValue += episodeAction.ProcedureDoctor.Name;
//                                        if (episodeAction.ProcedureDoctor.ResourceSpecialities != null && episodeAction.ProcedureDoctor.ResourceSpecialities.Count > 0)
//                                        {
//                                            foreach (ResourceSpecialityGrid specialty in episodeAction.ProcedureDoctor.ResourceSpecialities)
//                                            {
//                                                if (specialty.MainSpeciality != null)
//                                                {
//                                                    if (specialty.MainSpeciality.Value != null && specialty.MainSpeciality.Value)
//                                                    {
//                                                        if (specialty.Speciality != null)
//                                                        {
//                                                            if (specialty.Speciality.Name != null)
//                                                            {
//                                                                if (!eklenenDoktorlar.Contains(specialty.Speciality.Name))
//                                                                {
//                                                                    this.Tabib1.CalcValue += specialty.Speciality.Name;
//                                                                    this.Tabib1.CalcValue += (!specialty.Speciality.Name.Contains("Uzm") && !specialty.Speciality.Name.Contains("UZM")) ? " Uzm.\r\n" : "\r\n";
//                                                                    eklenenDoktorlar.Add(specialty.Speciality.Name);
//                                                                }
//                                                            }
//                                                        }
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    if (specialty.Speciality != null)
//                                                    {
//                                                        if (specialty.Speciality.Name != null)
//                                                        {
//                                                            if (!eklenenDoktorlar.Contains(specialty.Speciality.Name))
//                                                            {
//                                                                specialtyText += specialty.Speciality.Name;
//                                                                specialtyText += (specialty.Speciality.Name.Contains("Uzm") == false && specialty.Speciality.Name.Contains("UZM") == false) ? " Uzm.\r\n" : "\r\n";
//                                                                eklenenDoktorlar.Add(specialty.Speciality.Name);
//                                                            }
//                                                        }
//                                                    }
//                                                }
//                                            }
//                                            this.Tabib1.CalcValue += specialtyText;
//
//                                            if (this.Tabib1 == null || this.Tabib1.CalcValue == null)
//                                                this.Tabib1.CalcValue = "";
//                                        }
//                                    }
//                                    else this.Tabib1.CalcValue += "";
//
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.FollowUpExamination)
//                                        this.TaniKarar1.CalcValue += "Kontrol Muayenesi";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.PatientExamination)
//                                        this.TaniKarar1.CalcValue += "Normal Muayene";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.DentalExamination)
//                                        this.TaniKarar1.CalcValue += "Diş Muayenesi";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.EmergencyIntervention)
//                                        this.TaniKarar1.CalcValue += "Acil Muayene";
//                                    if (episodeAction.ActionType == TTObjectClasses.ActionTypeEnum.HealthCommitteeExamination)
//                                        this.TaniKarar1.CalcValue += "Sağlık Kurulu Muayenesi";
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
#endregion ALKOLDARP BODY_Script
                }
            }

        }

        public ALKOLDARPGroup ALKOLDARP;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EmergencyClinicRegistryReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            POLIKLINIK = new POLIKLINIKGroup(HEADER,"POLIKLINIK");
            ARA = new ARAGroup(POLIKLINIK,"ARA");
            BASLIK = new BASLIKGroup(ARA,"BASLIK");
            MAIN = new MAINGroup(BASLIK,"MAIN");
            ALKOLDARP = new ALKOLDARPGroup(BASLIK,"ALKOLDARP");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "EMERGENCYCLINICREGISTRYREPORT";
            Caption = "Acil Klinik Kayıt Defteri";
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