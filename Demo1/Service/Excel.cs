using OfficeOpenXml;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Service
{
    public class Excel: IExcel
    {
        private  ExcelPackage package;
        private ExcelWorksheet worksheet;
        private async Task<ServiceResponse> ReadExcelFile(string path)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                // mở file excel
                package = new ExcelPackage(new FileInfo(path));

                // lấy ra sheet đầu tiên để thao tác
                worksheet = package.Workbook.Worksheets[0];
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "ReadExcel",
                    Message = "Lỗi Đọc"
                };
                return  ServiceResponse.Failed(error);
            }

        }

        private async Task<ServiceResponse> EditExcelFile(List<TestingMachine> testingMachine,int targettest,string nametest,string note)
        {
            try
            {
                worksheet.Cells["F5"].Value = nametest;
                worksheet.Cells["C8"].Style.Numberformat.Format = "dd-MM-yyyy";
                worksheet.Cells["C8"].Value = testingMachine[0].TimeStampStart;
                worksheet.Cells["K8"].Style.Numberformat.Format = "dd-MM-yyyy";
                worksheet.Cells["K8"].Value = testingMachine[0].TimeStampFinish;
                worksheet.Cells["K9"].Value = note;
                switch (targettest)
                {
                    case 0:
                        worksheet.Cells["E9"].Value = "X";
                        break;
                    case 1:
                        worksheet.Cells["G9"].Value = "X";
                        break;
                    case 2:
                        worksheet.Cells["I9"].Value = "X";
                        break;
                    case 3:
                        worksheet.Cells["J9"].Value = "Khác X";
                        break;
                }
                for (int i=0; i<20;i++)
                {
                    worksheet.Cells[15+i, 2].Value = testingMachine[i].TimeSmoothClosingLid;
                    worksheet.Cells[15 + i, 3].Value = testingMachine[i].StatusLidNotFall;
                    worksheet.Cells[15 + i, 4].Value = testingMachine[i].StatusLidNotLeak;
                    worksheet.Cells[15 + i, 5].Value = testingMachine[i].StatusLidResult;
                    worksheet.Cells[15 + i, 6].Value = testingMachine[i].TimeSmoothClosingPlinth;
                    worksheet.Cells[15 + i, 7].Value = testingMachine[i].StatusPlinthNotFall;
                    worksheet.Cells[15 + i, 8].Value = testingMachine[i].StatusPlinthNotLeak;
                    worksheet.Cells[15 + i, 9].Value = testingMachine[i].StatusPlinthResult;
                    worksheet.Cells[15 + i, 10].Value = testingMachine[i].TotalMistake;
                    worksheet.Cells[15 + i, 11].Value = testingMachine[i].Note;
                    worksheet.Cells[15 + i, 12].Value = testingMachine[i].StaffCheck;
                }
                
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "EditExcel",
                    Message = "Lỗi Edit"
                };
                return ServiceResponse.Failed(error);
            }
        }
        private async Task<ServiceResponse> ExportExcelFile()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
            }
            try
            {
                using (package)
                {
                    //Lưu file lại
                    Byte[] bin = package.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "ExportExcel",
                    Message = "Lỗi Export"
                };
                return ServiceResponse.Failed(error);
            }
        }

        public async Task<ServiceResponse> Exportdata(string path, List<TestingMachine> testingMachine, int targettest, string nametest, string note)
        {
            var step1 = await ReadExcelFile(path);
            var step2 = await EditExcelFile(testingMachine,targettest, nametest,note);
            var step3 = await ExportExcelFile();
            return step3;
        }

    }
}
