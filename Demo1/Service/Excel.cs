using OfficeOpenXml;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.Models.Resource;
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
                    Message = "Lỗi Đọc File Nguồn"
                };
                return  ServiceResponse.Failed(error);
            }

        }

        private async Task<ServiceResponse> EditExcelFile(TestingMachine testingMachine)
        {
            try
            {
                worksheet.Cells["F5"].Value = testingMachine.ProductId;
                worksheet.Cells["C8"].Style.Numberformat.Format = "dd-MM-yyyy";
                worksheet.Cells["C8"].Value =testingMachine.StartTime;
                worksheet.Cells["K8"].Style.Numberformat.Format = "dd-MM-yyyy";
                worksheet.Cells["K8"].Value = testingMachine.StopTime;
                worksheet.Cells["K9"].Value = testingMachine.Note;
                switch (testingMachine.Target)
                {
                    case "dinhky":
                        worksheet.Cells["E9"].Value = "X";
                        break;
                    case "bathuong":
                        worksheet.Cells["G9"].Value = "X";
                        break;
                    case "SPmoi":
                        worksheet.Cells["I9"].Value = "X";
                        break;
                    case "khac":
                        worksheet.Cells["J9"].Value = "Khác X";
                        break;
                }
                int i = 0;
                foreach(var sheet in testingMachine.Testsheet)
                {
                    worksheet.Cells[15 + i, 2].Value = sheet.TimeSmoothClosingLid;
                    worksheet.Cells[15 + i, 3].Value = sheet.StatusLidNotFall;
                    worksheet.Cells[15 + i, 4].Value = sheet.StatusLidNotLeak;
                    worksheet.Cells[15 + i, 5].Value = sheet.StatusLidResult;
                    worksheet.Cells[15 + i, 6].Value = sheet.TimeSmoothClosingPlinth;
                    worksheet.Cells[15 + i, 7].Value = sheet.StatusPlinthNotFall;
                    worksheet.Cells[15 + i, 8].Value = sheet.StatusPlinthNotLeak;
                    worksheet.Cells[15 + i, 9].Value = sheet.StatusPlinthResult;
                    worksheet.Cells[15 + i, 10].Value = sheet.TotalMistake;
                    worksheet.Cells[15 + i, 11].Value = sheet.Note;
                    worksheet.Cells[15 + i, 12].Value = sheet.StaffCheck;
                    i++;
                }
                
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "EditExcel",
                    Message = "Lỗi Thêm dữ liệu"
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
            else
            {
                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    Error error = new Error
                    {
                        ErrorCode = "ExportExcel",
                        Message = "Đường dẫn không hợp lệ"
                    };
                    return ServiceResponse.Failed(error);
                }
                else
                {
                    Error error = new Error
                    {
                        ErrorCode = "ExportExcel",
                        Message = "Lỗi Lưu file"
                    };
                    return ServiceResponse.Failed(error);
                }
            }
           
        }

        public async Task<ServiceResponse> Exportdata(string path, TestingMachine testingMachine)
        {
            var step1 = await ReadExcelFile(path);
            var step2 = await EditExcelFile(testingMachine);
            var step3 = await ExportExcelFile();
            if (step1.Success != true)
            {
                return step1;
            }
            else
            {
                if (step2.Success != true)
                {
                    return step2;
                }
                else
                {
                    if (step3.Success != true)
                    {
                        return step3;
                    }
                    else
                    {
                        return ServiceResponse.Successful();
                    }    
                }    
            }
        }

    }
}
