
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
    /// Hek Malzemeler Kayıt Defteri
    /// </summary>
    public partial class HEKMaterialsRegistryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HEKMaterialsRegistryReport MyParentReport
            {
                get { return (HEKMaterialsRegistryReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public HEKMaterialsRegistryReport MyParentReport
                {
                    get { return (HEKMaterialsRegistryReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 15, 289, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HEK MALZEMELER KAYIT DEFTERİ";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 15, 53, 35, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField1,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HEKMaterialsRegistryReport MyParentReport
                {
                    get { return (HEKMaterialsRegistryReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 38, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 160, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 289, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 0, 289, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HEKMaterialsRegistryReport MyParentReport
            {
                get { return (HEKMaterialsRegistryReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField NewField111121 { get {return Header().NewField111121;} }
            public TTReportField NewField111122 { get {return Header().NewField111122;} }
            public TTReportField NewField111123 { get {return Header().NewField111123;} }
            public TTReportField NewField111124 { get {return Header().NewField111124;} }
            public TTReportField NewField111125 { get {return Header().NewField111125;} }
            public TTReportField NewField1521111 { get {return Header().NewField1521111;} }
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
                public HEKMaterialsRegistryReport MyParentReport
                {
                    get { return (HEKMaterialsRegistryReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField12111;
                public TTReportField NewField111121;
                public TTReportField NewField111122;
                public TTReportField NewField111123;
                public TTReportField NewField111124;
                public TTReportField NewField111125;
                public TTReportField NewField1521111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 15, 123, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"KAYDI SİLİNEN MALZEMENİN";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 27, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.Value = @"SIRA NO";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 20, 45, 25, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.Value = @"SİPARİŞ NO";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 20, 76, 25, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.Value = @"STOK NO";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 20, 123, 25, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.Value = @"İSMİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 15, 168, 25, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"AYIKLANIP KURTARILAN
MALZEMELER";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 15, 273, 20, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.Value = @"HEK OLARAK ELDE EDİLEN MALZEMELER (GR.OLARAK)";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 15, 289, 25, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.Value = @"ONAY";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 20, 183, 25, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.Value = @"DEMİR";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 20, 198, 25, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111121.Value = @"ÇELİK";

                    NewField111122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 20, 213, 25, false);
                    NewField111122.Name = "NewField111122";
                    NewField111122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111122.Value = @"BAKIR";

                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 20, 228, 25, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111123.Value = @"KURŞUN";

                    NewField111124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 20, 243, 25, false);
                    NewField111124.Name = "NewField111124";
                    NewField111124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111124.TextFont.Size = 8;
                    NewField111124.TextFont.CharSet = 162;
                    NewField111124.Value = @"ALÜMİNYUM";

                    NewField111125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 20, 258, 25, false);
                    NewField111125.Name = "NewField111125";
                    NewField111125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111125.Value = @"KABLO";

                    NewField1521111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 20, 273, 25, false);
                    NewField1521111.Name = "NewField1521111";
                    NewField1521111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1521111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1521111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1521111.Value = @"VS.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField111122.CalcValue = NewField111122.Value;
                    NewField111123.CalcValue = NewField111123.Value;
                    NewField111124.CalcValue = NewField111124.Value;
                    NewField111125.CalcValue = NewField111125.Value;
                    NewField1521111.CalcValue = NewField1521111.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField1111,NewField1112,NewField12,NewField13,NewField131,NewField12111,NewField111121,NewField111122,NewField111123,NewField111124,NewField111125,NewField1521111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HEKMaterialsRegistryReport MyParentReport
                {
                    get { return (HEKMaterialsRegistryReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HEKMaterialsRegistryReport MyParentReport
            {
                get { return (HEKMaterialsRegistryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STOCKACTIONID { get {return Body().STOCKACTIONID;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField INMATERIAL { get {return Body().INMATERIAL;} }
            public TTReportField IRON { get {return Body().IRON;} }
            public TTReportField STEEL { get {return Body().STEEL;} }
            public TTReportField COPPER { get {return Body().COPPER;} }
            public TTReportField LEAD { get {return Body().LEAD;} }
            public TTReportField ALUMINUM { get {return Body().ALUMINUM;} }
            public TTReportField CABLE { get {return Body().CABLE;} }
            public TTReportField OTHER { get {return Body().OTHER;} }
            public TTReportField NewField117 { get {return Body().NewField117;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField INMATERIALID { get {return Body().INMATERIALID;} }
            public TTReportField INMATERIALAMOUNT { get {return Body().INMATERIALAMOUNT;} }
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
                list[0] = new TTReportNqlData<ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class>("GetShellingProcedureOutMaterials", ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
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
                public HEKMaterialsRegistryReport MyParentReport
                {
                    get { return (HEKMaterialsRegistryReport)ParentReport; }
                }
                
                public TTReportField STOCKACTIONID;
                public TTReportField NAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField SIRANO;
                public TTReportField INMATERIAL;
                public TTReportField IRON;
                public TTReportField STEEL;
                public TTReportField COPPER;
                public TTReportField LEAD;
                public TTReportField ALUMINUM;
                public TTReportField CABLE;
                public TTReportField OTHER;
                public TTReportField NewField117;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField INMATERIALID;
                public TTReportField INMATERIALAMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 45, 5, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOCKACTIONID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKACTIONID.Value = @"{#STOCKACTIONID#} ";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 0, 123, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.Value = @" {#NAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 76, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 27, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.Value = @"{@counter@} ";

                    INMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 168, 5, false);
                    INMATERIAL.Name = "INMATERIAL";
                    INMATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    INMATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    INMATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INMATERIAL.Value = @" {#INMATERIAL#}";

                    IRON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 183, 5, false);
                    IRON.Name = "IRON";
                    IRON.DrawStyle = DrawStyleConstants.vbSolid;
                    IRON.FieldType = ReportFieldTypeEnum.ftVariable;
                    IRON.HorzAlign = HorizontalAlignmentEnum.haRight;
                    IRON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IRON.Value = @"";

                    STEEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 198, 5, false);
                    STEEL.Name = "STEEL";
                    STEEL.DrawStyle = DrawStyleConstants.vbSolid;
                    STEEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    STEEL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STEEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STEEL.Value = @"";

                    COPPER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 0, 213, 5, false);
                    COPPER.Name = "COPPER";
                    COPPER.DrawStyle = DrawStyleConstants.vbSolid;
                    COPPER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COPPER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COPPER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COPPER.Value = @"";

                    LEAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 0, 228, 5, false);
                    LEAD.Name = "LEAD";
                    LEAD.DrawStyle = DrawStyleConstants.vbSolid;
                    LEAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    LEAD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LEAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LEAD.Value = @"";

                    ALUMINUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 243, 5, false);
                    ALUMINUM.Name = "ALUMINUM";
                    ALUMINUM.DrawStyle = DrawStyleConstants.vbSolid;
                    ALUMINUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALUMINUM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ALUMINUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ALUMINUM.Value = @"";

                    CABLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 258, 5, false);
                    CABLE.Name = "CABLE";
                    CABLE.DrawStyle = DrawStyleConstants.vbSolid;
                    CABLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CABLE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CABLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CABLE.Value = @"";

                    OTHER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 0, 273, 5, false);
                    OTHER.Name = "OTHER";
                    OTHER.DrawStyle = DrawStyleConstants.vbSolid;
                    OTHER.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTHER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OTHER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OTHER.Value = @"";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 0, 289, 5, false);
                    NewField117.Name = "NewField117";
                    NewField117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 0, 13, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    INMATERIALID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
                    INMATERIALID.Name = "INMATERIALID";
                    INMATERIALID.Visible = EvetHayirEnum.ehHayir;
                    INMATERIALID.FieldType = ReportFieldTypeEnum.ftVariable;
                    INMATERIALID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    INMATERIALID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INMATERIALID.Value = @"{#INMATERIALID#}";

                    INMATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 330, 0, 355, 5, false);
                    INMATERIALAMOUNT.Name = "INMATERIALAMOUNT";
                    INMATERIALAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    INMATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INMATERIALAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    INMATERIALAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INMATERIALAMOUNT.Value = @"{#INMATERIALAMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class dataset_GetShellingProcedureOutMaterials = ParentGroup.rsGroup.GetCurrentRecord<ShellingProcedureMaterialOut.GetShellingProcedureOutMaterials_Class>(0);
                    STOCKACTIONID.CalcValue = (dataset_GetShellingProcedureOutMaterials != null ? Globals.ToStringCore(dataset_GetShellingProcedureOutMaterials.StockActionID) : "") + @" ";
                    NAME.CalcValue = @" " + (dataset_GetShellingProcedureOutMaterials != null ? Globals.ToStringCore(dataset_GetShellingProcedureOutMaterials.Name) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetShellingProcedureOutMaterials != null ? Globals.ToStringCore(dataset_GetShellingProcedureOutMaterials.NATOStockNO) : "");
                    SIRANO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    INMATERIAL.CalcValue = @" " + (dataset_GetShellingProcedureOutMaterials != null ? Globals.ToStringCore(dataset_GetShellingProcedureOutMaterials.Inmaterial) : "");
                    IRON.CalcValue = @"";
                    STEEL.CalcValue = @"";
                    COPPER.CalcValue = @"";
                    LEAD.CalcValue = @"";
                    ALUMINUM.CalcValue = @"";
                    CABLE.CalcValue = @"";
                    OTHER.CalcValue = @"";
                    NewField117.CalcValue = NewField117.Value;
                    INMATERIALID.CalcValue = (dataset_GetShellingProcedureOutMaterials != null ? Globals.ToStringCore(dataset_GetShellingProcedureOutMaterials.Inmaterialid) : "");
                    INMATERIALAMOUNT.CalcValue = (dataset_GetShellingProcedureOutMaterials != null ? Globals.ToStringCore(dataset_GetShellingProcedureOutMaterials.Inmaterialamount) : "");
                    return new TTReportObject[] { STOCKACTIONID,NAME,NATOSTOCKNO,SIRANO,INMATERIAL,IRON,STEEL,COPPER,LEAD,ALUMINUM,CABLE,OTHER,NewField117,INMATERIALID,INMATERIALAMOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    ShellingProcedureMaterialIn materialIn = (ShellingProcedureMaterialIn)ctx.GetObject(new Guid(INMATERIALID.CalcValue), typeof(ShellingProcedureMaterialIn));
                    if (materialIn != null)
                    {
                        switch (TTObjectClasses.Common.GetEnumValueDefOfEnumValue(materialIn.HEKResult).Name.ToString())
                        {
                            case "Iron":
                                IRON.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;

                            case "Steel":
                                STEEL.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;

                            case "Copper":
                                COPPER.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;

                            case "Lead":
                                LEAD.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;

                            case "Aluminum":
                                ALUMINUM.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;

                            case "Cable":
                                CABLE.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;

                            default:
                                OTHER.CalcValue = INMATERIALAMOUNT.CalcValue + " ";
                                break;
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

        public HEKMaterialsRegistryReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemini Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            Name = "HEKMATERIALSREGISTRYREPORT";
            Caption = "Hek Malzemeler Kayıt Defteri";
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