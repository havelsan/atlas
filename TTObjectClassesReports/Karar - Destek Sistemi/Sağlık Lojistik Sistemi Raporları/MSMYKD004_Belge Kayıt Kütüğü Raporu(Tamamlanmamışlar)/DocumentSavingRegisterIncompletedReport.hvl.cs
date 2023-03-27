
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
    /// Belge Kayıt Kütüğü (Tamamlanmamışlar) Raporu
    /// </summary>
    public partial class DocumentSavingRegisterIncompletedReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DocumentSavingRegisterIncompletedReport MyParentReport
            {
                get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
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
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField PARAMETERNAME11 { get {return Header().PARAMETERNAME11;} }
            public TTReportField PARAMETERNAME12 { get {return Header().PARAMETERNAME12;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField SelectedStore { get {return Header().SelectedStore;} }
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
                public DocumentSavingRegisterIncompletedReport MyParentReport
                {
                    get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField StartDate;
                public TTReportField PARAMETERNAME11;
                public TTReportField PARAMETERNAME12;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField EndDate;
                public TTReportField SelectedStore; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"BELGE KAYIT KÜTÜĞÜ (TAMAMLANMAMIŞLAR) RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 23, 31, 28, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Name = "Arial";
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 23, 33, 28, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 23, 79, 28, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.TextFont.Name = "Arial";
                    StartDate.TextFont.CharSet = 162;
                    StartDate.Value = @"{@STARTDATE@}";

                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 28, 31, 33, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Name = "Arial";
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Bitiş Tarihi";

                    PARAMETERNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 33, 31, 38, false);
                    PARAMETERNAME12.Name = "PARAMETERNAME12";
                    PARAMETERNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME12.TextFont.Name = "Arial";
                    PARAMETERNAME12.TextFont.Bold = true;
                    PARAMETERNAME12.TextFont.CharSet = 162;
                    PARAMETERNAME12.Value = @"Depo İsmi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 28, 33, 33, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 33, 33, 38, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 28, 79, 33, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.TextFont.Name = "Arial";
                    EndDate.TextFont.CharSet = 162;
                    EndDate.Value = @"{@ENDDATE@}";

                    SelectedStore = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 33, 257, 38, false);
                    SelectedStore.Name = "SelectedStore";
                    SelectedStore.FieldType = ReportFieldTypeEnum.ftVariable;
                    SelectedStore.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SelectedStore.ObjectDefName = "Store";
                    SelectedStore.DataMember = "NAME";
                    SelectedStore.TextFont.Name = "Arial";
                    SelectedStore.TextFont.CharSet = 162;
                    SelectedStore.Value = @"{@STOREID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    PARAMETERNAME11.CalcValue = PARAMETERNAME11.Value;
                    PARAMETERNAME12.CalcValue = PARAMETERNAME12.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    SelectedStore.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    SelectedStore.PostFieldValueCalculation();
                    return new TTReportObject[] { REPORTNAME,LOGO,PARAMETERNAME1,NewField11,StartDate,PARAMETERNAME11,PARAMETERNAME12,NewField111,NewField121,EndDate,SelectedStore};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DocumentSavingRegisterIncompletedReport MyParentReport
                {
                    get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 142, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

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
            public DocumentSavingRegisterIncompletedReport MyParentReport
            {
                get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportField COLUMNNAME12 { get {return Header().COLUMNNAME12;} }
            public TTReportField COLUMNNAME13 { get {return Header().COLUMNNAME13;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                public DocumentSavingRegisterIncompletedReport MyParentReport
                {
                    get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
                }
                
                public TTReportField COLUMNNAME1;
                public TTReportField COLUMNNAME2;
                public TTReportField COLUMNNAME12;
                public TTReportField COLUMNNAME13;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 22, 6, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME1.TextFont.Name = "Arial";
                    COLUMNNAME1.TextFont.Size = 11;
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"İşlem Nu.";

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 51, 6, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME2.TextFont.Name = "Arial";
                    COLUMNNAME2.TextFont.Size = 11;
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Belge Cinsi";

                    COLUMNNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 199, 6, false);
                    COLUMNNAME12.Name = "COLUMNNAME12";
                    COLUMNNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME12.TextFont.Name = "Arial";
                    COLUMNNAME12.TextFont.Size = 11;
                    COLUMNNAME12.TextFont.Bold = true;
                    COLUMNNAME12.TextFont.CharSet = 162;
                    COLUMNNAME12.Value = @"Gönderen veya Alacak Olan Depolar";

                    COLUMNNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 257, 6, false);
                    COLUMNNAME13.Name = "COLUMNNAME13";
                    COLUMNNAME13.DrawStyle = DrawStyleConstants.vbSolid;
                    COLUMNNAME13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME13.TextFont.Name = "Arial";
                    COLUMNNAME13.TextFont.Size = 11;
                    COLUMNNAME13.TextFont.Bold = true;
                    COLUMNNAME13.TextFont.CharSet = 162;
                    COLUMNNAME13.Value = @"Durumu";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 257, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME1.CalcValue = COLUMNNAME1.Value;
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    COLUMNNAME12.CalcValue = COLUMNNAME12.Value;
                    COLUMNNAME13.CalcValue = COLUMNNAME13.Value;
                    return new TTReportObject[] { COLUMNNAME1,COLUMNNAME2,COLUMNNAME12,COLUMNNAME13};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DocumentSavingRegisterIncompletedReport MyParentReport
                {
                    get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
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
            public DocumentSavingRegisterIncompletedReport MyParentReport
            {
                get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Description { get {return Body().Description;} }
            public TTReportField StockActionID { get {return Body().StockActionID;} }
            public TTReportField ReplaceStore { get {return Body().ReplaceStore;} }
            public TTReportField ObjectState { get {return Body().ObjectState;} }
            public TTReportField DestinationStore { get {return Body().DestinationStore;} }
            public TTReportField Store { get {return Body().Store;} }
            public TTReportField DestinationStoreID { get {return Body().DestinationStoreID;} }
            public TTReportField StoreID { get {return Body().StoreID;} }
            public TTReportField SelectedStoreID { get {return Body().SelectedStoreID;} }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
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
                list[0] = new TTReportNqlData<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class>("GetDocumentSavingRegisterIncompletedReportQuery", StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
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
                public DocumentSavingRegisterIncompletedReport MyParentReport
                {
                    get { return (DocumentSavingRegisterIncompletedReport)ParentReport; }
                }
                
                public TTReportField Description;
                public TTReportField StockActionID;
                public TTReportField ReplaceStore;
                public TTReportField ObjectState;
                public TTReportField DestinationStore;
                public TTReportField Store;
                public TTReportField DestinationStoreID;
                public TTReportField StoreID;
                public TTReportField SelectedStoreID;
                public TTReportField ObjectID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    RepeatCount = 0;
                    
                    Description = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 51, 5, false);
                    Description.Name = "Description";
                    Description.DrawStyle = DrawStyleConstants.vbSolid;
                    Description.FieldType = ReportFieldTypeEnum.ftVariable;
                    Description.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Description.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Description.TextFont.Name = "Arial";
                    Description.TextFont.CharSet = 162;
                    Description.Value = @"{#SHORTDESCRIPTION#}";

                    StockActionID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 22, 5, false);
                    StockActionID.Name = "StockActionID";
                    StockActionID.DrawStyle = DrawStyleConstants.vbSolid;
                    StockActionID.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockActionID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    StockActionID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StockActionID.TextFont.Name = "Arial";
                    StockActionID.TextFont.CharSet = 162;
                    StockActionID.Value = @"{#STOCKACTIONID#}";

                    ReplaceStore = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 199, 5, false);
                    ReplaceStore.Name = "ReplaceStore";
                    ReplaceStore.DrawStyle = DrawStyleConstants.vbSolid;
                    ReplaceStore.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReplaceStore.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReplaceStore.TextFont.Name = "Arial";
                    ReplaceStore.TextFont.CharSet = 162;
                    ReplaceStore.Value = @"";

                    ObjectState = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 257, 5, false);
                    ObjectState.Name = "ObjectState";
                    ObjectState.DrawStyle = DrawStyleConstants.vbSolid;
                    ObjectState.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectState.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ObjectState.TextFont.Name = "Arial";
                    ObjectState.TextFont.CharSet = 162;
                    ObjectState.Value = @"";

                    DestinationStore = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 22, 328, 27, false);
                    DestinationStore.Name = "DestinationStore";
                    DestinationStore.Visible = EvetHayirEnum.ehHayir;
                    DestinationStore.FieldType = ReportFieldTypeEnum.ftVariable;
                    DestinationStore.TextFont.Name = "Arial";
                    DestinationStore.TextFont.CharSet = 162;
                    DestinationStore.Value = @"{#DESTINATIONSTORE#}";

                    Store = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 28, 315, 33, false);
                    Store.Name = "Store";
                    Store.Visible = EvetHayirEnum.ehHayir;
                    Store.FieldType = ReportFieldTypeEnum.ftVariable;
                    Store.TextFont.Name = "Arial";
                    Store.TextFont.CharSet = 162;
                    Store.Value = @"{#STORE#}";

                    DestinationStoreID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 8, 330, 13, false);
                    DestinationStoreID.Name = "DestinationStoreID";
                    DestinationStoreID.Visible = EvetHayirEnum.ehHayir;
                    DestinationStoreID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DestinationStoreID.TextFont.Name = "Arial";
                    DestinationStoreID.TextFont.CharSet = 162;
                    DestinationStoreID.Value = @"{#DESTINATIONSTOREID#}";

                    StoreID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 15, 328, 20, false);
                    StoreID.Name = "StoreID";
                    StoreID.Visible = EvetHayirEnum.ehHayir;
                    StoreID.FieldType = ReportFieldTypeEnum.ftVariable;
                    StoreID.TextFont.Name = "Arial";
                    StoreID.TextFont.CharSet = 162;
                    StoreID.Value = @"{#STOREID#}";

                    SelectedStoreID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 0, 323, 5, false);
                    SelectedStoreID.Name = "SelectedStoreID";
                    SelectedStoreID.Visible = EvetHayirEnum.ehHayir;
                    SelectedStoreID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SelectedStoreID.TextFont.Name = "Arial";
                    SelectedStoreID.TextFont.CharSet = 162;
                    SelectedStoreID.Value = @"{@STOREID@}";

                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 0, 335, 5, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.TextFont.Name = "Arial";
                    ObjectID.TextFont.CharSet = 162;
                    ObjectID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class dataset_GetDocumentSavingRegisterIncompletedReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetDocumentSavingRegisterIncompletedReportQuery_Class>(0);
                    Description.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.ShortDescription) : "");
                    StockActionID.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.StockActionID) : "");
                    ReplaceStore.CalcValue = @"";
                    ObjectState.CalcValue = @"";
                    DestinationStore.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.Destinationstore) : "");
                    Store.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.Store) : "");
                    DestinationStoreID.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.Destinationstoreid) : "");
                    StoreID.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.Storeid) : "");
                    SelectedStoreID.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    ObjectID.CalcValue = (dataset_GetDocumentSavingRegisterIncompletedReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentSavingRegisterIncompletedReportQuery.ObjectID) : "");
                    return new TTReportObject[] { Description,StockActionID,ReplaceStore,ObjectState,DestinationStore,Store,DestinationStoreID,StoreID,SelectedStoreID,ObjectID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if((DestinationStoreID.CalcValue == SelectedStoreID.CalcValue) || DestinationStoreID.CalcValue == "" || DestinationStoreID.CalcValue == null)
                ReplaceStore.CalcValue = " " + Store.CalcValue;
            else
                ReplaceStore.CalcValue = " " + DestinationStore.CalcValue;
            
            StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(new Guid(ObjectID.CalcValue), typeof(StockAction));
            ObjectState.CalcValue = " " + stockAction.CurrentStateDef.DisplayText;
            
//            if(stockAction is ChequeDocument)
//                Description.CalcValue = "KB";
//            else if(stockAction is InputSendingDocument)
//                Description.CalcValue = "GGB";
//            else if(stockAction is OutputSendingDocument)
//                Description.CalcValue = "ÇGB";
//            else if(stockAction is CensusFixed)
//                Description.CalcValue = "SDB";
//            else if(stockAction is DeleteRecordDocumentWaste)
//                Description.CalcValue = "KSBHS";
//            else if(stockAction is ProductionConsumptionDocument)
//                Description.CalcValue = "SİİB";
//            else if(stockAction is ForcesBetweenChequeDocument)
//                Description.CalcValue = "KAKB";
//            else if(stockAction is ReturningDocument)
//                Description.CalcValue = "İB";
//            else if(stockAction is CensusOrder)
//                Description.CalcValue = "SE";
//            else if(stockAction is SectionRequirement)
//                Description.CalcValue = "KİB";
//            else if(stockAction is ShellingProcedure)
//                Description.CalcValue = "Aİ";
//            else if(stockAction is PurchaseExamination)
//                Description.CalcValue = "MM";
//            else if(stockAction is VoucherDistributingDocument)
//                Description.CalcValue = "ESDB";
//            else if(stockAction is VoucherReturnDocument)
//                Description.CalcValue = "ESİB";
//            else if(stockAction is ProductionConsumptionInfirmaryDocument)
//                Description.CalcValue = "SİİBR";
//            else if(stockAction is ForcesBetweenInputChequeDocument)
//                Description.CalcValue = "KAGKB";
//            else if(stockAction is DeleteRecordDocumentDestroyable)
//                Description.CalcValue = "KSBYE";
//            else if(stockAction is MainStoreProductionConsumptionDocument)
//                Description.CalcValue = "ADSİİB";
//            else if(stockAction is ConsignedCensusFixed)
//                Description.CalcValue = "MSDB";
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

        public DocumentSavingRegisterIncompletedReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo İsmini Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            Name = "DOCUMENTSAVINGREGISTERINCOMPLETEDREPORT";
            Caption = "Belge Kayıt Kütüğü (Tamamlanmamışlar) Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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