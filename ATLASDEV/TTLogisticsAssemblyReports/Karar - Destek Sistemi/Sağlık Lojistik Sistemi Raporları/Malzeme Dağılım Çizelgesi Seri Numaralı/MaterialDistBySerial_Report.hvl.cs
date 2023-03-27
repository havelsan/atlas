
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
    /// Seri Numaralı Demirbaş Dağılım Çizelgesi
    /// </summary>
    public partial class MaterialDistBySerial : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? MATERIALFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public MaterialDistBySerial MyParentReport
            {
                get { return (MaterialDistBySerial)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAME1 { get {return Header().HOSPITALNAME1;} }
            public TTReportField NewField1316111 { get {return Header().NewField1316111;} }
            public TTReportField NewField11116131 { get {return Header().NewField11116131;} }
            public TTReportField NewField113161111 { get {return Header().NewField113161111;} }
            public TTReportField NewField11116132 { get {return Header().NewField11116132;} }
            public TTReportField NewField11116133 { get {return Header().NewField11116133;} }
            public TTReportField NewField113161112 { get {return Header().NewField113161112;} }
            public TTReportField NewField123161111 { get {return Header().NewField123161111;} }
            public TTReportField NewField133161111 { get {return Header().NewField133161111;} }
            public TTReportField NewField1211161311 { get {return Header().NewField1211161311;} }
            public TTReportField NewField11131611111 { get {return Header().NewField11131611111;} }
            public TTReportField NewField1111161321 { get {return Header().NewField1111161321;} }
            public TTReportField NewField111111613111 { get {return Header().NewField111111613111;} }
            public TTReportField NewField123161112 { get {return Header().NewField123161112;} }
            public TTReportField NewField1211161321 { get {return Header().NewField1211161321;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField PrintDate11111 { get {return Footer().PrintDate11111;} }
            public TTReportField PageNumber11111 { get {return Footer().PageNumber11111;} }
            public TTReportField CurrentUser11111 { get {return Footer().CurrentUser11111;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
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
                public MaterialDistBySerial MyParentReport
                {
                    get { return (MaterialDistBySerial)ParentReport; }
                }
                
                public TTReportField HOSPITALNAME1;
                public TTReportField NewField1316111;
                public TTReportField NewField11116131;
                public TTReportField NewField113161111;
                public TTReportField NewField11116132;
                public TTReportField NewField11116133;
                public TTReportField NewField113161112;
                public TTReportField NewField123161111;
                public TTReportField NewField133161111;
                public TTReportField NewField1211161311;
                public TTReportField NewField11131611111;
                public TTReportField NewField1111161321;
                public TTReportField NewField111111613111;
                public TTReportField NewField123161112;
                public TTReportField NewField1211161321;
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 80;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 9, 264, 24, false);
                    HOSPITALNAME1.Name = "HOSPITALNAME1";
                    HOSPITALNAME1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.TextFont.Name = "Arial";
                    HOSPITALNAME1.TextFont.Size = 11;
                    HOSPITALNAME1.TextFont.Bold = true;
                    HOSPITALNAME1.TextFont.CharSet = 162;
                    HOSPITALNAME1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")+"" SERİ NUMARALI DEMİRBAŞ MALZEME DAĞILIM ÇİZELGESİ """;

                    NewField1316111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 42, 228, 80, false);
                    NewField1316111.Name = "NewField1316111";
                    NewField1316111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1316111.FontAngle = 900;
                    NewField1316111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1316111.TextFont.Name = "Arial";
                    NewField1316111.TextFont.Bold = true;
                    NewField1316111.TextFont.CharSet = 162;
                    NewField1316111.Value = @"MALZEMENİN  ADI";

                    NewField11116131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 42, 236, 80, false);
                    NewField11116131.Name = "NewField11116131";
                    NewField11116131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116131.FontAngle = 900;
                    NewField11116131.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11116131.TextFont.Name = "Arial";
                    NewField11116131.TextFont.Bold = true;
                    NewField11116131.TextFont.CharSet = 162;
                    NewField11116131.Value = @"TOP.  MİK.";

                    NewField113161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 42, 246, 80, false);
                    NewField113161111.Name = "NewField113161111";
                    NewField113161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113161111.FontAngle = 900;
                    NewField113161111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField113161111.TextFont.Name = "Arial";
                    NewField113161111.TextFont.Bold = true;
                    NewField113161111.TextFont.CharSet = 162;
                    NewField113161111.Value = @"ÖLÇÜ  BRM.";

                    NewField11116132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 42, 193, 80, false);
                    NewField11116132.Name = "NewField11116132";
                    NewField11116132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116132.FontAngle = 900;
                    NewField11116132.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11116132.TextFont.Name = "Arial";
                    NewField11116132.TextFont.Bold = true;
                    NewField11116132.TextFont.CharSet = 162;
                    NewField11116132.Value = @"STOK NU.";

                    NewField11116133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 42, 38, 80, false);
                    NewField11116133.Name = "NewField11116133";
                    NewField11116133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116133.FontAngle = 900;
                    NewField11116133.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11116133.TextFont.Name = "Arial";
                    NewField11116133.TextFont.Bold = true;
                    NewField11116133.TextFont.CharSet = 162;
                    NewField11116133.Value = @"SERİ NU.";

                    NewField113161112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 42, 55, 80, false);
                    NewField113161112.Name = "NewField113161112";
                    NewField113161112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113161112.FontAngle = 900;
                    NewField113161112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField113161112.TextFont.Name = "Arial";
                    NewField113161112.TextFont.Bold = true;
                    NewField113161112.TextFont.CharSet = 162;
                    NewField113161112.Value = @"MARKA - MODEL";

                    NewField123161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 31, 19, 80, false);
                    NewField123161111.Name = "NewField123161111";
                    NewField123161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123161111.FontAngle = 900;
                    NewField123161111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField123161111.TextFont.Name = "Arial";
                    NewField123161111.TextFont.Bold = true;
                    NewField123161111.TextFont.CharSet = 162;
                    NewField123161111.Value = @"SIRA  NUMARASI";

                    NewField133161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 42, 73, 80, false);
                    NewField133161111.Name = "NewField133161111";
                    NewField133161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133161111.FontAngle = 900;
                    NewField133161111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField133161111.TextFont.Name = "Arial";
                    NewField133161111.TextFont.Bold = true;
                    NewField133161111.TextFont.CharSet = 162;
                    NewField133161111.Value = @"FREKANS";

                    NewField1211161311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 42, 82, 80, false);
                    NewField1211161311.Name = "NewField1211161311";
                    NewField1211161311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211161311.FontAngle = 900;
                    NewField1211161311.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1211161311.TextFont.Name = "Arial";
                    NewField1211161311.TextFont.Bold = true;
                    NewField1211161311.TextFont.CharSet = 162;
                    NewField1211161311.Value = @"VOLTAJ";

                    NewField11131611111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 42, 99, 80, false);
                    NewField11131611111.Name = "NewField11131611111";
                    NewField11131611111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131611111.FontAngle = 900;
                    NewField11131611111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11131611111.TextFont.Name = "Arial";
                    NewField11131611111.TextFont.Bold = true;
                    NewField11131611111.TextFont.CharSet = 162;
                    NewField11131611111.Value = @"GARNT. BAŞ.TAR.";

                    NewField1111161321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 42, 64, 80, false);
                    NewField1111161321.Name = "NewField1111161321";
                    NewField1111161321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111161321.FontAngle = 900;
                    NewField1111161321.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111161321.TextFont.Name = "Arial";
                    NewField1111161321.TextFont.Bold = true;
                    NewField1111161321.TextFont.CharSet = 162;
                    NewField1111161321.Value = @"GÜÇ";

                    NewField111111613111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 42, 116, 80, false);
                    NewField111111613111.Name = "NewField111111613111";
                    NewField111111613111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111613111.FontAngle = 900;
                    NewField111111613111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111111613111.TextFont.Name = "Arial";
                    NewField111111613111.TextFont.Bold = true;
                    NewField111111613111.TextFont.CharSet = 162;
                    NewField111111613111.Value = @"GARNT. BİT. TAR.";

                    NewField123161112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 42, 133, 80, false);
                    NewField123161112.Name = "NewField123161112";
                    NewField123161112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123161112.FontAngle = 900;
                    NewField123161112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField123161112.TextFont.Name = "Arial";
                    NewField123161112.TextFont.Bold = true;
                    NewField123161112.TextFont.CharSet = 162;
                    NewField123161112.Value = @"SON KALİB. TAR.";

                    NewField1211161321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 42, 150, 80, false);
                    NewField1211161321.Name = "NewField1211161321";
                    NewField1211161321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211161321.FontAngle = 900;
                    NewField1211161321.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1211161321.TextFont.Name = "Arial";
                    NewField1211161321.TextFont.Bold = true;
                    NewField1211161321.TextFont.CharSet = 162;
                    NewField1211161321.Value = @"SON BAKIM TAR.";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 42, 167, 80, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField0.FontAngle = 900;
                    NewField0.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField0.TextFont.Name = "Arial";
                    NewField0.TextFont.Bold = true;
                    NewField0.TextFont.CharSet = 162;
                    NewField0.Value = @"İMAL TARİHİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 31, 246, 42, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"MALZEME BİLGİLERİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 31, 288, 80, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"




MALZEMENİN
BULUNDUĞU DEPOLAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1316111.CalcValue = NewField1316111.Value;
                    NewField11116131.CalcValue = NewField11116131.Value;
                    NewField113161111.CalcValue = NewField113161111.Value;
                    NewField11116132.CalcValue = NewField11116132.Value;
                    NewField11116133.CalcValue = NewField11116133.Value;
                    NewField113161112.CalcValue = NewField113161112.Value;
                    NewField123161111.CalcValue = NewField123161111.Value;
                    NewField133161111.CalcValue = NewField133161111.Value;
                    NewField1211161311.CalcValue = NewField1211161311.Value;
                    NewField11131611111.CalcValue = NewField11131611111.Value;
                    NewField1111161321.CalcValue = NewField1111161321.Value;
                    NewField111111613111.CalcValue = NewField111111613111.Value;
                    NewField123161112.CalcValue = NewField123161112.Value;
                    NewField1211161321.CalcValue = NewField1211161321.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    HOSPITALNAME1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")+" SERİ NUMARALI DEMİRBAŞ MALZEME DAĞILIM ÇİZELGESİ ";
                    return new TTReportObject[] { NewField1316111,NewField11116131,NewField113161111,NewField11116132,NewField11116133,NewField113161112,NewField123161111,NewField133161111,NewField1211161311,NewField11131611111,NewField1111161321,NewField111111613111,NewField123161112,NewField1211161321,NewField0,NewField1,NewField2,HOSPITALNAME1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    if(((MaterialDistBySerial)ParentReport).RuntimeParameters.STORE == Guid.Empty)
                ((MaterialDistBySerial)ParentReport).RuntimeParameters.STOREFLAG = 1;
            else
                ((MaterialDistBySerial)ParentReport).RuntimeParameters.STOREFLAG = 0;
             
            if(((MaterialDistBySerial)ParentReport).RuntimeParameters.MATERIAL == Guid.Empty)
                ((MaterialDistBySerial)ParentReport).RuntimeParameters.MATERIALFLAG = 1;
            else
                ((MaterialDistBySerial)ParentReport).RuntimeParameters.MATERIALFLAG = 0;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public MaterialDistBySerial MyParentReport
                {
                    get { return (MaterialDistBySerial)ParentReport; }
                }
                
                public TTReportField PrintDate11111;
                public TTReportField PageNumber11111;
                public TTReportField CurrentUser11111;
                public TTReportShape NewLine1111111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 37, 6, false);
                    PrintDate11111.Name = "PrintDate11111";
                    PrintDate11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate11111.TextFont.Size = 8;
                    PrintDate11111.TextFont.CharSet = 162;
                    PrintDate11111.Value = @"{@printdate@}";

                    PageNumber11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 1, 288, 6, false);
                    PageNumber11111.Name = "PageNumber11111";
                    PageNumber11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber11111.TextFont.Size = 8;
                    PageNumber11111.TextFont.CharSet = 162;
                    PageNumber11111.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 1, 156, 6, false);
                    CurrentUser11111.Name = "CurrentUser11111";
                    CurrentUser11111.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser11111.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser11111.TextFont.Size = 8;
                    CurrentUser11111.TextFont.CharSet = 162;
                    CurrentUser11111.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 288, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate11111.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber11111.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser11111.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate11111,PageNumber11111,CurrentUser11111};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialDistBySerial MyParentReport
            {
                get { return (MaterialDistBySerial)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SERIALNUMBER { get {return Body().SERIALNUMBER;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField POWER { get {return Body().POWER;} }
            public TTReportField FREQUENCY { get {return Body().FREQUENCY;} }
            public TTReportField VOLTAGE { get {return Body().VOLTAGE;} }
            public TTReportField GUARANTYSTARTDATE { get {return Body().GUARANTYSTARTDATE;} }
            public TTReportField GUARANTYENDDATE { get {return Body().GUARANTYENDDATE;} }
            public TTReportField LASTCALIBRATIONDATE { get {return Body().LASTCALIBRATIONDATE;} }
            public TTReportField LASTMAINTENANCEDATE { get {return Body().LASTMAINTENANCEDATE;} }
            public TTReportField PRODUCTIONDATE { get {return Body().PRODUCTIONDATE;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField OLCUBIRIM { get {return Body().OLCUBIRIM;} }
            public TTReportField STORENAME { get {return Body().STORENAME;} }
            public TTReportField FREQUENCY1 { get {return Body().FREQUENCY1;} }
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
                list[0] = new TTReportNqlData<FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class>("GetFixedAssetMaterialDistBySerialReportQuery2", FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALFLAG),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREFLAG)));
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
                public MaterialDistBySerial MyParentReport
                {
                    get { return (MaterialDistBySerial)ParentReport; }
                }
                
                public TTReportField SERIALNUMBER;
                public TTReportField MARK;
                public TTReportField POWER;
                public TTReportField FREQUENCY;
                public TTReportField VOLTAGE;
                public TTReportField GUARANTYSTARTDATE;
                public TTReportField GUARANTYENDDATE;
                public TTReportField LASTCALIBRATIONDATE;
                public TTReportField LASTMAINTENANCEDATE;
                public TTReportField PRODUCTIONDATE;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALNAME;
                public TTReportField MIKTAR;
                public TTReportField OLCUBIRIM;
                public TTReportField STORENAME;
                public TTReportField FREQUENCY1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    SERIALNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 38, 18, false);
                    SERIALNUMBER.Name = "SERIALNUMBER";
                    SERIALNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERIALNUMBER.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNUMBER.ExpandTabs = EvetHayirEnum.ehEvet;
                    SERIALNUMBER.TextFont.Size = 8;
                    SERIALNUMBER.TextFont.CharSet = 162;
                    SERIALNUMBER.Value = @"{#SERIALNUMBER#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 55, 18, false);
                    MARK.Name = "MARK";
                    MARK.DrawStyle = DrawStyleConstants.vbSolid;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.MultiLine = EvetHayirEnum.ehEvet;
                    MARK.WordBreak = EvetHayirEnum.ehEvet;
                    MARK.TextFont.Size = 8;
                    MARK.TextFont.CharSet = 162;
                    MARK.Value = @"{#MARK#} - {#MODEL#}";

                    POWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 64, 18, false);
                    POWER.Name = "POWER";
                    POWER.DrawStyle = DrawStyleConstants.vbSolid;
                    POWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    POWER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    POWER.MultiLine = EvetHayirEnum.ehEvet;
                    POWER.ExpandTabs = EvetHayirEnum.ehEvet;
                    POWER.TextFont.Size = 8;
                    POWER.TextFont.CharSet = 162;
                    POWER.Value = @"{#POWER#}";

                    FREQUENCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 73, 18, false);
                    FREQUENCY.Name = "FREQUENCY";
                    FREQUENCY.DrawStyle = DrawStyleConstants.vbSolid;
                    FREQUENCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FREQUENCY.MultiLine = EvetHayirEnum.ehEvet;
                    FREQUENCY.ExpandTabs = EvetHayirEnum.ehEvet;
                    FREQUENCY.TextFont.Size = 8;
                    FREQUENCY.TextFont.CharSet = 162;
                    FREQUENCY.Value = @"{#FREQUENCY#}";

                    VOLTAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 0, 82, 18, false);
                    VOLTAGE.Name = "VOLTAGE";
                    VOLTAGE.DrawStyle = DrawStyleConstants.vbSolid;
                    VOLTAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VOLTAGE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    VOLTAGE.MultiLine = EvetHayirEnum.ehEvet;
                    VOLTAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    VOLTAGE.TextFont.Size = 8;
                    VOLTAGE.TextFont.CharSet = 162;
                    VOLTAGE.Value = @"{#VOLTAGE#}";

                    GUARANTYSTARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 99, 18, false);
                    GUARANTYSTARTDATE.Name = "GUARANTYSTARTDATE";
                    GUARANTYSTARTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTYSTARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTYSTARTDATE.TextFormat = @"Short Date";
                    GUARANTYSTARTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GUARANTYSTARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTYSTARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTYSTARTDATE.TextFont.Size = 8;
                    GUARANTYSTARTDATE.TextFont.CharSet = 162;
                    GUARANTYSTARTDATE.Value = @"{#GUARANTYSTARTDATE#}";

                    GUARANTYENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 0, 116, 18, false);
                    GUARANTYENDDATE.Name = "GUARANTYENDDATE";
                    GUARANTYENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTYENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTYENDDATE.TextFormat = @"Short Date";
                    GUARANTYENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GUARANTYENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTYENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTYENDDATE.TextFont.Size = 8;
                    GUARANTYENDDATE.TextFont.CharSet = 162;
                    GUARANTYENDDATE.Value = @"{#GUARANTYENDDATE#}";

                    LASTCALIBRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 133, 18, false);
                    LASTCALIBRATIONDATE.Name = "LASTCALIBRATIONDATE";
                    LASTCALIBRATIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    LASTCALIBRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTCALIBRATIONDATE.TextFormat = @"Short Date";
                    LASTCALIBRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTCALIBRATIONDATE.MultiLine = EvetHayirEnum.ehEvet;
                    LASTCALIBRATIONDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    LASTCALIBRATIONDATE.TextFont.Size = 8;
                    LASTCALIBRATIONDATE.TextFont.CharSet = 162;
                    LASTCALIBRATIONDATE.Value = @"{#LASTCALIBRATIONDATE#}";

                    LASTMAINTENANCEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 150, 18, false);
                    LASTMAINTENANCEDATE.Name = "LASTMAINTENANCEDATE";
                    LASTMAINTENANCEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    LASTMAINTENANCEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTMAINTENANCEDATE.TextFormat = @"Short Date";
                    LASTMAINTENANCEDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTMAINTENANCEDATE.MultiLine = EvetHayirEnum.ehEvet;
                    LASTMAINTENANCEDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    LASTMAINTENANCEDATE.TextFont.Size = 8;
                    LASTMAINTENANCEDATE.TextFont.CharSet = 162;
                    LASTMAINTENANCEDATE.Value = @"{#LASTMAINTENANCEDATE#}";

                    PRODUCTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 167, 18, false);
                    PRODUCTIONDATE.Name = "PRODUCTIONDATE";
                    PRODUCTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTIONDATE.TextFormat = @"Short Date";
                    PRODUCTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRODUCTIONDATE.MultiLine = EvetHayirEnum.ehEvet;
                    PRODUCTIONDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRODUCTIONDATE.TextFont.Size = 8;
                    PRODUCTIONDATE.TextFont.CharSet = 162;
                    PRODUCTIONDATE.Value = @"{#PRODUCTIONDATE#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 193, 18, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 0, 228, 18, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Size = 8;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 236, 18, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#MIKTAR#}";

                    OLCUBIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 0, 246, 18, false);
                    OLCUBIRIM.Name = "OLCUBIRIM";
                    OLCUBIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIM.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUBIRIM.ObjectDefName = "DistributionTypeDefinition";
                    OLCUBIRIM.DataMember = "QREF";
                    OLCUBIRIM.TextFont.Size = 8;
                    OLCUBIRIM.TextFont.CharSet = 162;
                    OLCUBIRIM.Value = @"{#OLCUBIRIM#}";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 288, 18, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.MultiLine = EvetHayirEnum.ehEvet;
                    STORENAME.WordBreak = EvetHayirEnum.ehEvet;
                    STORENAME.TextFont.Size = 8;
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{#STORENAME#}";

                    FREQUENCY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 19, 18, false);
                    FREQUENCY1.Name = "FREQUENCY1";
                    FREQUENCY1.DrawStyle = DrawStyleConstants.vbSolid;
                    FREQUENCY1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FREQUENCY1.MultiLine = EvetHayirEnum.ehEvet;
                    FREQUENCY1.ExpandTabs = EvetHayirEnum.ehEvet;
                    FREQUENCY1.TextFont.Size = 8;
                    FREQUENCY1.TextFont.CharSet = 162;
                    FREQUENCY1.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class dataset_GetFixedAssetMaterialDistBySerialReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class>(0);
                    SERIALNUMBER.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.SerialNumber) : "");
                    MARK.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Mark) : "") + @" - " + (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Model) : "");
                    POWER.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Power) : "");
                    FREQUENCY.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Frequency) : "");
                    VOLTAGE.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Voltage) : "");
                    GUARANTYSTARTDATE.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.GuarantyStartDate) : "");
                    GUARANTYENDDATE.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.GuarantyEndDate) : "");
                    LASTCALIBRATIONDATE.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.LastCalibrationDate) : "");
                    LASTMAINTENANCEDATE.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.LastMaintenanceDate) : "");
                    PRODUCTIONDATE.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.ProductionDate) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.NATOStockNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Materialname) : "");
                    MIKTAR.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Miktar) : "");
                    OLCUBIRIM.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Olcubirim) : "");
                    OLCUBIRIM.PostFieldValueCalculation();
                    STORENAME.CalcValue = (dataset_GetFixedAssetMaterialDistBySerialReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialDistBySerialReportQuery2.Storename) : "");
                    FREQUENCY1.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { SERIALNUMBER,MARK,POWER,FREQUENCY,VOLTAGE,GUARANTYSTARTDATE,GUARANTYENDDATE,LASTCALIBRATIONDATE,LASTMAINTENANCEDATE,PRODUCTIONDATE,NATOSTOCKNO,MATERIALNAME,MIKTAR,OLCUBIRIM,STORENAME,FREQUENCY1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialDistBySerial()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Seri Numaralı Malzeme ", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("a45073d2-3e80-4264-b596-1d4962072c8e");
            reportParameter = Parameters.Add("MATERIALFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("STOREFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            if (parameters.ContainsKey("MATERIALFLAG"))
                _runtimeParameters.MATERIALFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["MATERIALFLAG"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("STOREFLAG"))
                _runtimeParameters.STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREFLAG"]);
            Name = "MATERIALDISTBYSERIAL";
            Caption = "Seri Numaralı Demirbaş Dağılım Çizelgesi";
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