
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
    public partial class DocumentSavingRegisterReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? ACCOUNTINGTERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public long? REGISTRATIONNO = (long?)TTObjectDefManager.Instance.DataTypes["RegistrationNumberSequence"].ConvertValue("0");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DocumentSavingRegisterReport MyParentReport
            {
                get { return (DocumentSavingRegisterReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public DocumentSavingRegisterReport MyParentReport
                {
                    get { return (DocumentSavingRegisterReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 15, 287, 35, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"BELGE KAYIT KÜTÜĞÜ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 60, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = @"BELGE KAYIT KÜTÜĞÜ";
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { REPORTNAME,NewField1};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.ACCOUNTINGTERMID.HasValue)
                    {
                        AccountingTerm accountingTerm = (AccountingTerm)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.ACCOUNTINGTERMID.Value, typeof(AccountingTerm));
                        REPORTNAME.Value = accountingTerm.Accountancy.Name + "'in Stok Kayıt Kartı Hesabına ait\r\nBELGE KAYIT KÜTÜĞÜ";
                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DocumentSavingRegisterReport MyParentReport
                {
                    get { return (DocumentSavingRegisterReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 45, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 167, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 287, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 287, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

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
            public DocumentSavingRegisterReport MyParentReport
            {
                get { return (DocumentSavingRegisterReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportField COLUMNNAME12 { get {return Header().COLUMNNAME12;} }
            public TTReportField COLUMNNAME13 { get {return Header().COLUMNNAME13;} }
            public TTReportField COLUMNNAME14 { get {return Header().COLUMNNAME14;} }
            public TTReportField COLUMNNAME15 { get {return Header().COLUMNNAME15;} }
            public TTReportField COLUMNNAME151 { get {return Header().COLUMNNAME151;} }
            public TTReportField COLUMNNAME141 { get {return Header().COLUMNNAME141;} }
            public TTReportField COLUMNNAME1141 { get {return Header().COLUMNNAME1141;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField COLUMNNAME16 { get {return Header().COLUMNNAME16;} }
            public TTReportField COLUMNNAME161 { get {return Header().COLUMNNAME161;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
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
                public DocumentSavingRegisterReport MyParentReport
                {
                    get { return (DocumentSavingRegisterReport)ParentReport; }
                }
                
                public TTReportShape NewRect1;
                public TTReportField COLUMNNAME2;
                public TTReportField COLUMNNAME12;
                public TTReportField COLUMNNAME13;
                public TTReportField COLUMNNAME14;
                public TTReportField COLUMNNAME15;
                public TTReportField COLUMNNAME151;
                public TTReportField COLUMNNAME141;
                public TTReportField COLUMNNAME1141;
                public TTReportShape NewLine1;
                public TTReportField COLUMNNAME16;
                public TTReportField COLUMNNAME161;
                public TTReportShape NewLine2;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 32;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 15, 35, 32, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 15, 51, 32, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME2.MultiLine = EvetHayirEnum.ehEvet;
                    COLUMNNAME2.TextFont.Name = "Arial";
                    COLUMNNAME2.TextFont.Size = 11;
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Belge
Kayıt
Nu.";

                    COLUMNNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 15, 70, 32, false);
                    COLUMNNAME12.Name = "COLUMNNAME12";
                    COLUMNNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME12.MultiLine = EvetHayirEnum.ehEvet;
                    COLUMNNAME12.TextFont.Name = "Arial";
                    COLUMNNAME12.TextFont.Size = 11;
                    COLUMNNAME12.TextFont.Bold = true;
                    COLUMNNAME12.TextFont.CharSet = 162;
                    COLUMNNAME12.Value = @"Kayıt
Tarihi";

                    COLUMNNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 15, 83, 32, false);
                    COLUMNNAME13.Name = "COLUMNNAME13";
                    COLUMNNAME13.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME13.MultiLine = EvetHayirEnum.ehEvet;
                    COLUMNNAME13.WordBreak = EvetHayirEnum.ehEvet;
                    COLUMNNAME13.TextFont.Name = "Arial";
                    COLUMNNAME13.TextFont.Size = 11;
                    COLUMNNAME13.TextFont.Bold = true;
                    COLUMNNAME13.TextFont.CharSet = 162;
                    COLUMNNAME13.Value = @"Belge Nu.";

                    COLUMNNAME14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 15, 99, 32, false);
                    COLUMNNAME14.Name = "COLUMNNAME14";
                    COLUMNNAME14.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME14.MultiLine = EvetHayirEnum.ehEvet;
                    COLUMNNAME14.TextFont.Name = "Arial";
                    COLUMNNAME14.TextFont.Size = 11;
                    COLUMNNAME14.TextFont.Bold = true;
                    COLUMNNAME14.TextFont.CharSet = 162;
                    COLUMNNAME14.Value = @"Belge
Cinsi
Nev'i";

                    COLUMNNAME15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 15, 169, 32, false);
                    COLUMNNAME15.Name = "COLUMNNAME15";
                    COLUMNNAME15.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME15.TextFont.Name = "Arial";
                    COLUMNNAME15.TextFont.Size = 11;
                    COLUMNNAME15.TextFont.Bold = true;
                    COLUMNNAME15.TextFont.CharSet = 162;
                    COLUMNNAME15.Value = @"Gönderen veya Alacak Olan";

                    COLUMNNAME151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 15, 243, 32, false);
                    COLUMNNAME151.Name = "COLUMNNAME151";
                    COLUMNNAME151.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME151.TextFont.Name = "Arial";
                    COLUMNNAME151.TextFont.Size = 11;
                    COLUMNNAME151.TextFont.Bold = true;
                    COLUMNNAME151.TextFont.CharSet = 162;
                    COLUMNNAME151.Value = @"Belgenin Üzerindeki Birinci Kalem Mal";

                    COLUMNNAME141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 15, 263, 32, false);
                    COLUMNNAME141.Name = "COLUMNNAME141";
                    COLUMNNAME141.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME141.TextFont.Name = "Arial";
                    COLUMNNAME141.TextFont.Size = 11;
                    COLUMNNAME141.TextFont.Bold = true;
                    COLUMNNAME141.TextFont.CharSet = 162;
                    COLUMNNAME141.Value = @"Kontrol";

                    COLUMNNAME1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 15, 287, 32, false);
                    COLUMNNAME1141.Name = "COLUMNNAME1141";
                    COLUMNNAME1141.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME1141.TextFont.Name = "Arial";
                    COLUMNNAME1141.TextFont.Size = 11;
                    COLUMNNAME1141.TextFont.Bold = true;
                    COLUMNNAME1141.TextFont.CharSet = 162;
                    COLUMNNAME1141.Value = @"Düşünceler";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 32, 287, 32, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    COLUMNNAME16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 21, 25, 34, false);
                    COLUMNNAME16.Name = "COLUMNNAME16";
                    COLUMNNAME16.FillStyle = FillStyleConstants.vbFSTransparent;
                    COLUMNNAME16.FontAngle = 900;
                    COLUMNNAME16.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME16.TextFont.Name = "Arial";
                    COLUMNNAME16.TextFont.Size = 7;
                    COLUMNNAME16.TextFont.CharSet = 162;
                    COLUMNNAME16.Value = @"Posta";

                    COLUMNNAME161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 18, 28, 34, false);
                    COLUMNNAME161.Name = "COLUMNNAME161";
                    COLUMNNAME161.FillStyle = FillStyleConstants.vbFSTransparent;
                    COLUMNNAME161.FontAngle = 900;
                    COLUMNNAME161.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME161.TextFont.Name = "Arial";
                    COLUMNNAME161.TextFont.Size = 7;
                    COLUMNNAME161.TextFont.CharSet = 162;
                    COLUMNNAME161.Value = @"Kayıt";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 15, 35, 32, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 12, 33, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.FontAngle = 900;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 7;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sipariş";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 11, 36, 26, false);
                    NewField11.Name = "NewField11";
                    NewField11.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField11.FontAngle = 900;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 7;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 19, 32, 34, false);
                    NewField111.Name = "NewField111";
                    NewField111.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField111.FontAngle = 900;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 7;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Nu.";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 15, 20, 32, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 15, 287, 32, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    COLUMNNAME12.CalcValue = COLUMNNAME12.Value;
                    COLUMNNAME13.CalcValue = COLUMNNAME13.Value;
                    COLUMNNAME14.CalcValue = COLUMNNAME14.Value;
                    COLUMNNAME15.CalcValue = COLUMNNAME15.Value;
                    COLUMNNAME151.CalcValue = COLUMNNAME151.Value;
                    COLUMNNAME141.CalcValue = COLUMNNAME141.Value;
                    COLUMNNAME1141.CalcValue = COLUMNNAME1141.Value;
                    COLUMNNAME16.CalcValue = COLUMNNAME16.Value;
                    COLUMNNAME161.CalcValue = COLUMNNAME161.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { COLUMNNAME2,COLUMNNAME12,COLUMNNAME13,COLUMNNAME14,COLUMNNAME15,COLUMNNAME151,COLUMNNAME141,COLUMNNAME1141,COLUMNNAME16,COLUMNNAME161,NewField1,NewField11,NewField111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DocumentSavingRegisterReport MyParentReport
                {
                    get { return (DocumentSavingRegisterReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DocumentSavingRegisterReport MyParentReport
            {
                get { return (DocumentSavingRegisterReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField ReplaceStore { get {return Body().ReplaceStore;} }
            public TTReportField Count { get {return Body().Count;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public TTReportField REGISTRATIONNUMBER { get {return Body().REGISTRATIONNUMBER;} }
            public TTReportField SEQUENCENUMBER { get {return Body().SEQUENCENUMBER;} }
            public TTReportField STOCKACTIONID { get {return Body().STOCKACTIONID;} }
            public TTReportField DESTINATIONSTOREOBJECTID { get {return Body().DESTINATIONSTOREOBJECTID;} }
            public TTReportField STOREOBJECTID { get {return Body().STOREOBJECTID;} }
            public TTReportField CONTROLCOUNT { get {return Body().CONTROLCOUNT;} }
            public TTReportField FIRSTMATERIALNAME { get {return Body().FIRSTMATERIALNAME;} }
            public TTReportField TRANSACTIONDEF { get {return Body().TRANSACTIONDEF;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
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
                list[0] = new TTReportNqlData<StockAction.GetDocumentSavingRegisterReportQuery_Class>("GetDocumentSavingRegisterReportQuery", StockAction.GetDocumentSavingRegisterReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTINGTERMID),(long)TTObjectDefManager.Instance.DataTypes["RegistrationNumberSequence"].ConvertValue(MyParentReport.RuntimeParameters.REGISTRATIONNO)));
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
                public DocumentSavingRegisterReport MyParentReport
                {
                    get { return (DocumentSavingRegisterReport)ParentReport; }
                }
                
                public TTReportShape NewRect1;
                public TTReportShape NewLine1;
                public TTReportField ReplaceStore;
                public TTReportField Count;
                public TTReportField OBJECTID;
                public TTReportField TRANSACTIONDATE;
                public TTReportField REGISTRATIONNUMBER;
                public TTReportField SEQUENCENUMBER;
                public TTReportField STOCKACTIONID;
                public TTReportField DESTINATIONSTOREOBJECTID;
                public TTReportField STOREOBJECTID;
                public TTReportField CONTROLCOUNT;
                public TTReportField FIRSTMATERIALNAME;
                public TTReportField TRANSACTIONDEF;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 20, 0, 35, 5, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 35, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    ReplaceStore = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 0, 169, 5, false);
                    ReplaceStore.Name = "ReplaceStore";
                    ReplaceStore.DrawStyle = DrawStyleConstants.vbSolid;
                    ReplaceStore.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReplaceStore.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReplaceStore.TextFont.Name = "Arial";
                    ReplaceStore.TextFont.CharSet = 162;
                    ReplaceStore.Value = @"";

                    Count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 287, 5, false);
                    Count.Name = "Count";
                    Count.DrawStyle = DrawStyleConstants.vbSolid;
                    Count.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Count.TextFont.Name = "Arial";
                    Count.TextFont.CharSet = 162;
                    Count.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 0, 334, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 70, 5, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"Short Date";
                    TRANSACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TRANSACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDATE.TextFont.Name = "Arial";
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{#TRANSACTIONDATE#}";

                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 51, 5, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.TextFont.Name = "Arial";
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"{#REGISTRATIONNUMBER#}";

                    SEQUENCENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 83, 5, false);
                    SEQUENCENUMBER.Name = "SEQUENCENUMBER";
                    SEQUENCENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    SEQUENCENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEQUENCENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SEQUENCENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SEQUENCENUMBER.TextFont.Name = "Arial";
                    SEQUENCENUMBER.TextFont.CharSet = 162;
                    SEQUENCENUMBER.Value = @"{#SEQUENCENUMBER#}";

                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 20, 335, 25, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.Value = @"{#STOCKACTIONID#}";

                    DESTINATIONSTOREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 8, 336, 13, false);
                    DESTINATIONSTOREOBJECTID.Name = "DESTINATIONSTOREOBJECTID";
                    DESTINATIONSTOREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DESTINATIONSTOREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESTINATIONSTOREOBJECTID.Value = @"{#DESTINATIONSTOREOBJECTID#}";

                    STOREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 14, 334, 19, false);
                    STOREOBJECTID.Name = "STOREOBJECTID";
                    STOREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOREOBJECTID.Value = @"{#STOREOBJECTID#}";

                    CONTROLCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 263, 5, false);
                    CONTROLCOUNT.Name = "CONTROLCOUNT";
                    CONTROLCOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CONTROLCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTROLCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONTROLCOUNT.TextFont.Name = "Arial";
                    CONTROLCOUNT.TextFont.CharSet = 162;
                    CONTROLCOUNT.Value = @" {#CONTROLCOUNT#} Kalemdir.";

                    FIRSTMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 243, 5, false);
                    FIRSTMATERIALNAME.Name = "FIRSTMATERIALNAME";
                    FIRSTMATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRSTMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTMATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRSTMATERIALNAME.TextFont.Name = "Arial";
                    FIRSTMATERIALNAME.TextFont.CharSet = 162;
                    FIRSTMATERIALNAME.Value = @"";

                    TRANSACTIONDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 99, 5, false);
                    TRANSACTIONDEF.Name = "TRANSACTIONDEF";
                    TRANSACTIONDEF.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDEF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TRANSACTIONDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDEF.TextFont.Name = "Arial";
                    TRANSACTIONDEF.TextFont.CharSet = 162;
                    TRANSACTIONDEF.Value = @"";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 20, 5, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.GetDocumentSavingRegisterReportQuery_Class dataset_GetDocumentSavingRegisterReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.GetDocumentSavingRegisterReportQuery_Class>(0);
                    ReplaceStore.CalcValue = @"";
                    Count.CalcValue = Count.Value;
                    OBJECTID.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.ObjectID) : "");
                    TRANSACTIONDATE.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.TransactionDate) : "");
                    REGISTRATIONNUMBER.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.RegistrationNumber) : "");
                    SEQUENCENUMBER.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.SequenceNumber) : "");
                    STOCKACTIONID.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.StockActionID) : "");
                    DESTINATIONSTOREOBJECTID.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.Destinationstoreobjectid) : "");
                    STOREOBJECTID.CalcValue = (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.Storeobjectid) : "");
                    CONTROLCOUNT.CalcValue = @" " + (dataset_GetDocumentSavingRegisterReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterReportQuery.Controlcount) : "") + @" Kalemdir.";
                    FIRSTMATERIALNAME.CalcValue = @"";
                    TRANSACTIONDEF.CalcValue = @"";
                    return new TTReportObject[] { ReplaceStore,Count,OBJECTID,TRANSACTIONDATE,REGISTRATIONNUMBER,SEQUENCENUMBER,STOCKACTIONID,DESTINATIONSTOREOBJECTID,STOREOBJECTID,CONTROLCOUNT,FIRSTMATERIALNAME,TRANSACTIONDEF};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    /// <summary>Nesneye ait olan objectid alınıp "Gönderecek veya Alacak Depo" alanı, belgeye ait ilk kalem malın adı alanı ve belge cinsi alanı doldururuluyor.</summary>
            
            if (TTUtils.Globals.IsGuid(OBJECTID.CalcValue))
            {
                StockAction stockAction = (StockAction)this.MyParentReport.ReportObjectContext.GetObject(new Guid(OBJECTID.CalcValue), typeof(StockAction));
                
                if (stockAction.Store != null && stockAction.DestinationStore == null)
                    this.ReplaceStore.CalcValue = " " + stockAction.Store.Name;

                if (stockAction.Store != null && stockAction.DestinationStore != null)
                {
                    if (stockAction.Store is MainStoreDefinition)
                        this.ReplaceStore.CalcValue = " " + stockAction.DestinationStore.Name;
                    else
                        this.ReplaceStore.CalcValue = " " + stockAction.Store.Name;
                }
                
                if(stockAction.StockActionDetails.Count > 0)
                    FIRSTMATERIALNAME.CalcValue = " " + stockAction.StockActionDetails[0].Material.Name;
                
                
                if(stockAction is CensusFixed)
                    TRANSACTIONDEF.CalcValue = "SDB";
                else if(stockAction is DeleteRecordDocumentWaste)
                    TRANSACTIONDEF.CalcValue = "KSBHS";
                else if(stockAction is ProductionConsumptionDocument)
                    TRANSACTIONDEF.CalcValue = "SİİB";
                else if(stockAction is DistributionDocument)
                    TRANSACTIONDEF.CalcValue = "DB";
                else if(stockAction is ReturningDocument)
                    TRANSACTIONDEF.CalcValue = "İB";
                else if(stockAction is CensusOrder)
                    TRANSACTIONDEF.CalcValue = "SE";
                else if(stockAction is SectionRequirement)
                    TRANSACTIONDEF.CalcValue = "KİB";
                else if(stockAction is PurchaseExamination)
                    TRANSACTIONDEF.CalcValue = "MM";
                else if(stockAction is VoucherDistributingDocument)
                    TRANSACTIONDEF.CalcValue = "ESDB";
                else if(stockAction is VoucherReturnDocument)
                    TRANSACTIONDEF.CalcValue = "ESİB";
                else if(stockAction is ProductionConsumptionInfirmaryDocument)
                    TRANSACTIONDEF.CalcValue = "SİİBR";
                else if(stockAction is DeleteRecordDocumentDestroyable)
                    TRANSACTIONDEF.CalcValue = "KSBYE";
                else if(stockAction is MainStoreProductionConsumptionDocument)
                    TRANSACTIONDEF.CalcValue = "ADSİİB";
                else if(stockAction is ConsignedCensusFixed)
                    TRANSACTIONDEF.CalcValue = "MSDBS";
                else
                    TRANSACTIONDEF.CalcValue = "---";
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

        public DocumentSavingRegisterReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ACCOUNTINGTERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("REGISTRATIONNO", "0", "Belge Kayıt Numarasını Giriniz", @"", false, true, false, new Guid("d33fdf78-36ad-4cb8-af86-d96dfe33f285"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ACCOUNTINGTERMID"))
                _runtimeParameters.ACCOUNTINGTERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ACCOUNTINGTERMID"]);
            if (parameters.ContainsKey("REGISTRATIONNO"))
                _runtimeParameters.REGISTRATIONNO = (long?)TTObjectDefManager.Instance.DataTypes["RegistrationNumberSequence"].ConvertValue(parameters["REGISTRATIONNO"]);
            Name = "DOCUMENTSAVINGREGISTERREPORT";
            Caption = "Belge Kayıt Kütüğü Raporu Belgelere Göre";
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