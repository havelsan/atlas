
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
    /// Kayıt Silme Belgesi Yoketme Tutanağı
    /// </summary>
    public partial class DeleteRecordDocumentDestroyableDestroyedReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableDestroyedReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableDestroyedReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField1134311 { get {return Header().NewField1134311;} }
            public TTReportField NewField11134311 { get {return Header().NewField11134311;} }
            public TTReportField NewField11134312 { get {return Header().NewField11134312;} }
            public TTReportField NewField112421 { get {return Footer().NewField112421;} }
            public TTReportField NewField1124211 { get {return Footer().NewField1124211;} }
            public TTReportField NewField11124211 { get {return Footer().NewField11124211;} }
            public TTReportField NewField111242111 { get {return Footer().NewField111242111;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField113 { get {return Footer().NewField113;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField NewField1211 { get {return Footer().NewField1211;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField REPORTDESC { get {return Footer().REPORTDESC;} }
            public TTReportField NewField111242112 { get {return Footer().NewField111242112;} }
            public TTReportField NewField114 { get {return Footer().NewField114;} }
            public TTReportField NewField1311 { get {return Footer().NewField1311;} }
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
                public DeleteRecordDocumentDestroyableDestroyedReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableDestroyedReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField11421;
                public TTReportField NewField11431;
                public TTReportField NewField1134311;
                public TTReportField NewField11134311;
                public TTReportField NewField11134312; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 203, 32, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"TAŞINIR MAL YOKETME TUTANAĞI";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 32, 25, 48, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"
S.Nu.
";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 32, 49, 48, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Stok Nu.";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 32, 107, 48, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"
Taşınır Malın
Cins ve Özellikleri";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 32, 122, 48, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"
Miktarı
";

                    NewField1134311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 32, 149, 48, false);
                    NewField1134311.Name = "NewField1134311";
                    NewField1134311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1134311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1134311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1134311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1134311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1134311.TextFont.CharSet = 162;
                    NewField1134311.Value = @"
Ne Suretle Yok Edildiği";

                    NewField11134311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 32, 176, 48, false);
                    NewField11134311.Name = "NewField11134311";
                    NewField11134311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11134311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11134311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11134311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11134311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11134311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11134311.TextFont.CharSet = 162;
                    NewField11134311.Value = @"
Nerede 
Yok Edildiği";

                    NewField11134312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 32, 203, 48, false);
                    NewField11134312.Name = "NewField11134312";
                    NewField11134312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11134312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11134312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11134312.TextFont.CharSet = 162;
                    NewField11134312.Value = @"Açıklamalar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField1134311.CalcValue = NewField1134311.Value;
                    NewField11134311.CalcValue = NewField11134311.Value;
                    NewField11134312.CalcValue = NewField11134312.Value;
                    return new TTReportObject[] { NewField111,NewField1141,NewField11411,NewField11421,NewField11431,NewField1134311,NewField11134311,NewField11134312};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DeleteRecordDocumentDestroyableDestroyedReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableDestroyedReport)ParentReport; }
                }
                
                public TTReportField NewField112421;
                public TTReportField NewField1124211;
                public TTReportField NewField11124211;
                public TTReportField NewField111242111;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField113;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportShape NewLine1;
                public TTReportField REPORTDESC;
                public TTReportField NewField111242112;
                public TTReportField NewField114;
                public TTReportField NewField1311; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 120;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField112421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 26, 33, 46, false);
                    NewField112421.Name = "NewField112421";
                    NewField112421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112421.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112421.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112421.TextFont.CharSet = 162;
                    NewField112421.Value = @" İmza
 Adı Soyadı
 Rütbesi
 Görevi";

                    NewField1124211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 26, 76, 46, false);
                    NewField1124211.Name = "NewField1124211";
                    NewField1124211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1124211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1124211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1124211.TextFont.CharSet = 162;
                    NewField1124211.Value = @" : ..............................................
 : ..............................................
 : ..............................................
 : ..............................................";

                    NewField11124211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 26, 130, 46, false);
                    NewField11124211.Name = "NewField11124211";
                    NewField11124211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11124211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11124211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11124211.TextFont.CharSet = 162;
                    NewField11124211.Value = @"..............................................
..............................................
..............................................
..............................................";

                    NewField111242111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 26, 193, 46, false);
                    NewField111242111.Name = "NewField111242111";
                    NewField111242111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111242111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111242111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111242111.TextFont.CharSet = 162;
                    NewField111242111.Value = @"..............................................
..............................................
..............................................
..............................................";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 46, 76, 51, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.Value = @"Kurul Başkanı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 46, 130, 51, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.Value = @"Üye";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 70, 121, 77, false);
                    NewField113.Name = "NewField113";
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Size = 12;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"ONAY";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 46, 193, 51, false);
                    NewField112.Name = "NewField112";
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.Value = @"Üye";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 64, 121, 69, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.Value = @"........ / ......./ ..........";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 203, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    REPORTDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 203, 15, false);
                    REPORTDESC.Name = "REPORTDESC";
                    REPORTDESC.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTDESC.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTDESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTDESC.TextFont.CharSet = 162;
                    REPORTDESC.Value = @"Yetkili makamca onaylanmış olan EK'teki kayıt silme belgesinde yazılı taşınır malın hanelerinde yazılı yerde ve şekilde kurulumuz huzurunda yok edildiğini gösterir tutanaktır.";

                    NewField111242112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 86, 121, 101, false);
                    NewField111242112.Name = "NewField111242112";
                    NewField111242112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111242112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111242112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111242112.TextFont.CharSet = 162;
                    NewField111242112.Value = @"..............................................
..............................................
..............................................";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 96, 162, 101, false);
                    NewField114.Name = "NewField114";
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.Value = @"XXXXXXı";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 78, 121, 85, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Size = 12;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @"(                               )";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112421.CalcValue = NewField112421.Value;
                    NewField1124211.CalcValue = NewField1124211.Value;
                    NewField11124211.CalcValue = NewField11124211.Value;
                    NewField111242111.CalcValue = NewField111242111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    REPORTDESC.CalcValue = REPORTDESC.Value;
                    NewField111242112.CalcValue = NewField111242112.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    return new TTReportObject[] { NewField112421,NewField1124211,NewField11124211,NewField111242111,NewField1,NewField11,NewField113,NewField112,NewField1211,REPORTDESC,NewField111242112,NewField114,NewField1311};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableDestroyedReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableDestroyedReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField KAYITSILMENEDENI { get {return Body().KAYITSILMENEDENI;} }
            public TTReportShape NewLine111111 { get {return Body().NewLine111111;} }
            public TTReportShape NewLine1111111 { get {return Body().NewLine1111111;} }
            public TTReportShape NewLine1111121 { get {return Body().NewLine1111121;} }
            public TTReportShape NewLine11211111 { get {return Body().NewLine11211111;} }
            public TTReportShape NewLine11211121 { get {return Body().NewLine11211121;} }
            public TTReportShape NewLine11211151 { get {return Body().NewLine11211151;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField NEREDEYOKEDILDIGI { get {return Body().NEREDEYOKEDILDIGI;} }
            public TTReportField DUSUNCELER { get {return Body().DUSUNCELER;} }
            public TTReportShape NewLine115111211 { get {return Body().NewLine115111211;} }
            public TTReportShape NewLine115111212 { get {return Body().NewLine115111212;} }
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
                list[0] = new TTReportNqlData<DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ_Class>("DeleteRecordDocumentDestroyableDestroyedReportRQ", DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DeleteRecordDocumentDestroyableDestroyedReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableDestroyedReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField MATERIALNAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField AMOUNT;
                public TTReportField KAYITSILMENEDENI;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine1111111;
                public TTReportShape NewLine1111121;
                public TTReportShape NewLine11211111;
                public TTReportShape NewLine11211121;
                public TTReportShape NewLine11211151;
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField NEREDEYOKEDILDIGI;
                public TTReportField DUSUNCELER;
                public TTReportShape NewLine115111211;
                public TTReportShape NewLine115111212; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 25, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@} ";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 106, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 1, 49, 6, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 121, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    KAYITSILMENEDENI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 1, 149, 6, false);
                    KAYITSILMENEDENI.Name = "KAYITSILMENEDENI";
                    KAYITSILMENEDENI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAYITSILMENEDENI.ObjectDefName = "DeleteRecordReasonEnum";
                    KAYITSILMENEDENI.DataMember = "DISPLAYTEXT";
                    KAYITSILMENEDENI.Value = @"{#DELETERECORDREASON#}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 6, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 0, 25, 6, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 0, 49, 6, false);
                    NewLine1111121.Name = "NewLine1111121";
                    NewLine1111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11211111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 107, 6, false);
                    NewLine11211111.Name = "NewLine11211111";
                    NewLine11211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11211121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 122, 0, 122, 6, false);
                    NewLine11211121.Name = "NewLine11211121";
                    NewLine11211121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11211151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 0, 149, 6, false);
                    NewLine11211151.Name = "NewLine11211151";
                    NewLine11211151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211151.ExtendTo = ExtendToEnum.extPageHeight;

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 1, 243, 6, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    NEREDEYOKEDILDIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 1, 176, 6, false);
                    NEREDEYOKEDILDIGI.Name = "NEREDEYOKEDILDIGI";
                    NEREDEYOKEDILDIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEREDEYOKEDILDIGI.Value = @"{#DESTROYLOCATION#}";

                    DUSUNCELER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 1, 203, 6, false);
                    DUSUNCELER.Name = "DUSUNCELER";
                    DUSUNCELER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUSUNCELER.Value = @"{#OPINIONS#}";

                    NewLine115111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 0, 176, 6, false);
                    NewLine115111211.Name = "NewLine115111211";
                    NewLine115111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine115111211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine115111212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 6, false);
                    NewLine115111212.Name = "NewLine115111212";
                    NewLine115111212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine115111212.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ_Class dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ = ParentGroup.rsGroup.GetCurrentRecord<DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    MATERIALNAME.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.Materialname) : "");
                    NATOSTOCKNO.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.NATOStockNO) : "");
                    AMOUNT.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.Amount) : "");
                    KAYITSILMENEDENI.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.DeleteRecordReason) : "");
                    KAYITSILMENEDENI.PostFieldValueCalculation();
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.Stockactiondetailobjectid) : "");
                    NEREDEYOKEDILDIGI.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.DestroyLocation) : "");
                    DUSUNCELER.CalcValue = (dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ != null ? Globals.ToStringCore(dataset_DeleteRecordDocumentDestroyableDestroyedReportRQ.Opinions) : "");
                    return new TTReportObject[] { COUNTER,MATERIALNAME,NATOSTOCKNO,AMOUNT,KAYITSILMENEDENI,STOCKACTIONDETAILOBJECTID,NEREDEYOKEDILDIGI,DUSUNCELER};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DeleteRecordDocumentDestroyableDestroyedReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DELETERECORDDOCUMENTDESTROYABLEDESTROYEDREPORT";
            Caption = "Kayıt Silme Belgesi Yoketme Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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