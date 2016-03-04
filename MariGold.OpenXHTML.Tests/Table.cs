﻿namespace MariGold.OpenXHTML.Tests
{
	using System;
	using NUnit.Framework;
	using MariGold.OpenXHTML;
	using System.IO;
	using DocumentFormat.OpenXml.Wordprocessing;
	using Word = DocumentFormat.OpenXml.Wordprocessing;
	using DocumentFormat.OpenXml.Validation;
	using System.Linq;
	
	[TestFixture]
	public class Table
	{
		[Test]
		public void TableBorder()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table border='1'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				
				TableStyle tableStyle = tableProperties.ChildElements[0]as TableStyle;
				Assert.IsNotNull(tableStyle);
				Assert.AreEqual("TableGrid", tableStyle.Val.Value);
				
				TableBorders tableBorders = tableProperties.ChildElements[1] as TableBorders;
				Assert.IsNotNull(tableBorders);
				Assert.AreEqual(4, tableBorders.ChildElements.Count);
				
				TopBorder topBorder = tableBorders.ChildElements[0] as TopBorder;
				Assert.IsNotNull(topBorder);
				TestUtility.TestBorder<TopBorder>(topBorder, BorderValues.Single, "auto", 4U);
				
				LeftBorder leftBorder = tableBorders.ChildElements[1] as LeftBorder;
				Assert.IsNotNull(leftBorder);
				TestUtility.TestBorder<LeftBorder>(leftBorder, BorderValues.Single, "auto", 4U);
				
				BottomBorder bottomBorder = tableBorders.ChildElements[2] as BottomBorder;
				Assert.IsNotNull(bottomBorder);
				TestUtility.TestBorder<BottomBorder>(bottomBorder, BorderValues.Single, "auto", 4U);
				
				RightBorder rightBorder = tableBorders.ChildElements[3] as RightBorder;
				Assert.IsNotNull(rightBorder);
				TestUtility.TestBorder<RightBorder>(rightBorder, BorderValues.Single, "auto", 4U);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(2, cell.ChildElements.Count);
				
				TableCellProperties cellProperties = cell.ChildElements[0] as TableCellProperties;
				Assert.IsNotNull(cellProperties);
				Assert.AreEqual(1, cellProperties.ChildElements.Count);
				
				TableCellBorders cellBorders = cellProperties.ChildElements[0] as TableCellBorders;
				Assert.IsNotNull(cellBorders);
				Assert.AreEqual(4, cellBorders.ChildElements.Count);
				
				topBorder = cellBorders.ChildElements[0] as TopBorder;
				Assert.IsNotNull(topBorder);
				TestUtility.TestBorder<TopBorder>(topBorder, BorderValues.Single, "auto", 4U);
				
				leftBorder = cellBorders.ChildElements[1] as LeftBorder;
				Assert.IsNotNull(leftBorder);
				TestUtility.TestBorder<LeftBorder>(leftBorder, BorderValues.Single, "auto", 4U);
				
				bottomBorder = cellBorders.ChildElements[2] as BottomBorder;
				Assert.IsNotNull(bottomBorder);
				TestUtility.TestBorder<BottomBorder>(bottomBorder, BorderValues.Single, "auto", 4U);
				
				rightBorder = cellBorders.ChildElements[3] as RightBorder;
				Assert.IsNotNull(rightBorder);
				TestUtility.TestBorder<RightBorder>(rightBorder, BorderValues.Single, "auto", 4U);
				
				Paragraph para = cell.ChildElements[1] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableBorderStyle()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table style='border:1px solid #000'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				
				TableStyle tableStyle = tableProperties.ChildElements[0] as TableStyle;
				Assert.IsNotNull(tableStyle);
				Assert.AreEqual("TableGrid", tableStyle.Val.Value);
				
				TableBorders tableBorders = tableProperties.ChildElements[1] as TableBorders;
				Assert.IsNotNull(tableBorders);
				Assert.AreEqual(4, tableBorders.ChildElements.Count);
				
				TopBorder topBorder = tableBorders.ChildElements[0] as TopBorder;
				Assert.IsNotNull(topBorder);
				TestUtility.TestBorder<TopBorder>(topBorder, BorderValues.Single, "000000", 1U);
				
				LeftBorder leftBorder = tableBorders.ChildElements[1] as LeftBorder;
				Assert.IsNotNull(leftBorder);
				TestUtility.TestBorder<LeftBorder>(leftBorder, BorderValues.Single, "000000", 1U);
				
				BottomBorder bottomBorder = tableBorders.ChildElements[2] as BottomBorder;
				Assert.IsNotNull(bottomBorder);
				TestUtility.TestBorder<BottomBorder>(bottomBorder, BorderValues.Single, "000000", 1U);
				
				RightBorder rightBorder = tableBorders.ChildElements[3] as RightBorder;
				Assert.IsNotNull(rightBorder);
				TestUtility.TestBorder<RightBorder>(rightBorder, BorderValues.Single, "000000", 1U);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableCellSpacing()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table cellspacing='5'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(2, row.ChildElements.Count);
				
				TableRowProperties rowProperties = row.ChildElements[0] as TableRowProperties;
				Assert.IsNotNull(rowProperties);
				Assert.AreEqual(1, rowProperties.ChildElements.Count);
				
				TableCellSpacing cellSpacing = rowProperties.ChildElements[0] as TableCellSpacing;
				Assert.IsNotNull(cellSpacing);
				Assert.AreEqual("100", cellSpacing.Width.Value);
				Assert.AreEqual(TableWidthUnitValues.Dxa, cellSpacing.Type.Value);
				
				TableCell cell = row.ChildElements[1] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableCellPadding()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table cellpadding='5'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				Assert.IsNotNull(tableProperties.TableCellMarginDefault);
				
				Assert.AreEqual(100, tableProperties.TableCellMarginDefault.TableCellLeftMargin.Width.Value);
				Assert.AreEqual(TableWidthValues.Dxa, tableProperties.TableCellMarginDefault.TableCellLeftMargin.Type.Value);
				
				Assert.AreEqual("100", tableProperties.TableCellMarginDefault.TopMargin.Width.Value);
				Assert.AreEqual(TableWidthUnitValues.Dxa, tableProperties.TableCellMarginDefault.TopMargin.Type.Value);
				
				Assert.AreEqual(100, tableProperties.TableCellMarginDefault.TableCellRightMargin.Width.Value);
				Assert.AreEqual(TableWidthValues.Dxa, tableProperties.TableCellMarginDefault.TableCellRightMargin.Type.Value);
				
				Assert.AreEqual("100", tableProperties.TableCellMarginDefault.BottomMargin.Width.Value);
				Assert.AreEqual(TableWidthUnitValues.Dxa, tableProperties.TableCellMarginDefault.BottomMargin.Type.Value);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableThCellStyles()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table><tr><th>Id</th></tr><tr><td>1</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(4, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				
				TableStyle tableStyle = tableProperties.ChildElements[0]as TableStyle;
				Assert.IsNotNull(tableStyle);
				Assert.AreEqual("TableGrid", tableStyle.Val.Value);
				
				TableGrid tableGrid = table.ChildElements[1] as TableGrid;
				Assert.IsNotNull(tableGrid);
				Assert.AreEqual(1, tableGrid.ChildElements.Count);
				
				TableRow row = table.ChildElements[2] as TableRow;
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(2, run.ChildElements.Count);
				Assert.IsNotNull(run.RunProperties);
				Bold bold = run.RunProperties.ChildElements[0] as Bold;
				Assert.IsNotNull(bold);
				
				Word.Text text = run.ChildElements[1] as Word.Text;
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("Id", text.InnerText);
				
				row = table.ChildElements[3] as TableRow;
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				cell = row.ChildElements[0] as TableCell;
				cell.TestTableCell(1, "1");
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableThColSpan()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table><tr><td>Id</td><td>Name</td></tr><tr><td colspan='2'>1</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(4, table.ChildElements.Count);
				
				TableRow row = table.ChildElements[2] as TableRow;
				Assert.IsNotNull(row);
				Assert.AreEqual(2, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				cell.TestTableCell(1, "Id");
				
				cell = row.ChildElements[1] as TableCell;
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				cell.TestTableCell(1, "Name");
				
				row = table.ChildElements[3] as TableRow;
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				cell = row.ChildElements[0] as TableCell;
				Assert.IsNotNull(cell);
				
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableThColSpanAdv()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table border='1'><tr><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td></tr><tr><td colspan='2'>one</td><td>three</td><td colspan='2'>five</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(4, table.ChildElements.Count);
				
				TableRow row = table.ChildElements[2] as TableRow;
				Assert.IsNotNull(row);
				Assert.AreEqual(5, row.ChildElements.Count);
				
				row = table.ChildElements[3] as TableRow;
				Assert.IsNotNull(row);
				Assert.AreEqual(3, row.ChildElements.Count);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableAttributeWidth()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table width='50%'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				Assert.AreEqual(2, tableProperties.ChildElements.Count);
				
				TableStyle tableStyle = tableProperties.ChildElements[0]as TableStyle;
				Assert.IsNotNull(tableStyle);
				Assert.AreEqual("TableGrid", tableStyle.Val.Value);
				
				TableWidth tableWidth = tableProperties.ChildElements[1]as TableWidth;
				Assert.IsNotNull(tableWidth);
				Assert.AreEqual("2500", tableWidth.Width.Value);
				Assert.AreEqual(TableWidthUnitValues.Pct, tableWidth.Type.Value);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableStyleWidth()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table style='width:50%'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				Assert.AreEqual(2, tableProperties.ChildElements.Count);
				
				TableStyle tableStyle = tableProperties.ChildElements[0]as TableStyle;
				Assert.IsNotNull(tableStyle);
				Assert.AreEqual("TableGrid", tableStyle.Val.Value);
				
				TableWidth tableWidth = tableProperties.ChildElements[1]as TableWidth;
				Assert.IsNotNull(tableWidth);
				Assert.AreEqual("2500", tableWidth.Width.Value);
				Assert.AreEqual(TableWidthUnitValues.Pct, tableWidth.Type.Value);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
		
		[Test]
		public void TableAttributeStyleWidth()
		{
			using (MemoryStream mem = new MemoryStream())
			{
				WordDocument doc = new WordDocument(mem);
			
				doc.Process(new HtmlParser("<table width='50%' style='width:150px'><tr><td>test</td></tr></table>"));
				
				Assert.IsNotNull(doc.Document.Body);
				Assert.AreEqual(1, doc.Document.Body.ChildElements.Count);
				
				Word.Table table = doc.Document.Body.ChildElements[0] as Word.Table;
				
				Assert.IsNotNull(table);
				Assert.AreEqual(3, table.ChildElements.Count);
				
				TableProperties tableProperties = table.ChildElements[0] as TableProperties;
				Assert.IsNotNull(tableProperties);
				Assert.AreEqual(2, tableProperties.ChildElements.Count);
				
				TableStyle tableStyle = tableProperties.ChildElements[0]as TableStyle;
				Assert.IsNotNull(tableStyle);
				Assert.AreEqual("TableGrid", tableStyle.Val.Value);
				
				TableWidth tableWidth = tableProperties.ChildElements[1]as TableWidth;
				Assert.IsNotNull(tableWidth);
				Assert.AreEqual("3000", tableWidth.Width.Value);
				Assert.AreEqual(TableWidthUnitValues.Dxa, tableWidth.Type.Value);
				
				TableRow row = table.ChildElements[2] as TableRow;
				
				Assert.IsNotNull(row);
				Assert.AreEqual(1, row.ChildElements.Count);
				
				TableCell cell = row.ChildElements[0] as TableCell;
				
				Assert.IsNotNull(cell);
				Assert.AreEqual(1, cell.ChildElements.Count);
				
				Paragraph para = cell.ChildElements[0] as Paragraph;
				
				Assert.IsNotNull(para);
				Assert.AreEqual(1, para.ChildElements.Count);
				
				Run run = para.ChildElements[0] as Run;
				
				Assert.IsNotNull(run);
				Assert.AreEqual(1, run.ChildElements.Count);
				
				Word.Text text = run.ChildElements[0] as Word.Text;
				
				Assert.IsNotNull(text);
				Assert.AreEqual(0, text.ChildElements.Count);
				Assert.AreEqual("test", text.InnerText);
				
				OpenXmlValidator validator = new OpenXmlValidator();
				var errors = validator.Validate(doc.WordprocessingDocument);
				Assert.AreEqual(0, errors.Count());
			}
		}
	}
}
