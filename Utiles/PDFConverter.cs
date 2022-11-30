using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Utiles
{
    public class PDFConverter
    {
        public bool ConvertToPdf(DataGridView data)
        {
            if (data.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                string fecha = DateTime.Now.ToString("dd-MM-yy_hhmmss");
                sfd.FileName = "Informe.pdf"+"_"+fecha;
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                            return true;
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No se pudo escribir en el disco, revise sus permisos" + ex.Message);
                            return false;
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(data.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in data.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in data.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                        pdfTable.AddCell(cell.Value.ToString());
                                    else
                                        pdfTable.AddCell("S/D");
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Se exporto el PDF en la ruta que usted eligio", "Info");

                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("No hay nada para exportar", "Info");
                return false;
            }
        }
    }
}
