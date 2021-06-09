using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    public class DatabaseService: IDatabaseService
    {
        private readonly IunitOfWork _unitOfWork;
        private readonly ITestingConfigurationRepository _testingConfigurationRepository;
        private readonly ITestingMachineRepository _testingMachineRepository;

        public DatabaseService(IunitOfWork unitOfWork, ITestingConfigurationRepository testingConfigurationRepository, ITestingMachineRepository testingMachineRepository)
        {
            _unitOfWork = unitOfWork;
            _testingConfigurationRepository = testingConfigurationRepository;
            _testingMachineRepository = testingMachineRepository;
        }


        #region TestingConfiguration
        public async Task<ServiceResponse> UpdateConfigurationEntry(TestingConfigurations entry)
        {
            try
            {
                await _testingConfigurationRepository.Update(entry);
                await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Update",
                    Message = "Lỗi database local."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> InsertTestingConfigurations(TestingConfigurations testingConfigurations)
        {
            try
            {
                _testingConfigurationRepository.Insert(testingConfigurations);
                await _unitOfWork.SaveChangeAsync();

                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                Error error = new Error
                {
                    ErrorCode = "Database.Insert",
                    Message = "Lỗi khác."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> DeleteReportShift(TestingConfigurations testingConfigurations)
        {
            try
            {
                await _testingConfigurationRepository.Delete(testingConfigurations);
                await _unitOfWork.SaveChangeAsync();

                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                Error error = new Error
                {
                    ErrorCode = "Database.Insert",
                    Message = "Lỗi khác."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> ClearConfiguration()
        {
            try
            {
                _testingConfigurationRepository.Clear();
                await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Clear",
                    Message = "Lỗi database."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<IEnumerable<TestingConfigurations>> LoadAllConfiguration()
        {
            return await _testingConfigurationRepository.Load();
        }
        public async Task<ServiceResourceResponse<TestingConfigurations>> FindTestId(string machineId)
        {
            try
            {
                var resultFindByMachineId = await _testingConfigurationRepository.FindTestId(machineId);
                return new ServiceResourceResponse<TestingConfigurations>(resultFindByMachineId);
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.FindConfigByMachineId",
                    Message = "Lỗi database."
                };
                return new ServiceResourceResponse<TestingConfigurations>(error);
            }
        }
        #endregion

        #region TestingMachine
        public async Task<ServiceResponse> UpdateTestingMachine(TestingMachine entry)
        {
            try
            {
                //await _testingMachineRepository.Update(entry);
               // await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Update",
                    Message = "Lỗi database local."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> InsertTestingMachines(TestingMachine entry)
        {
            try
            {
                _testingMachineRepository.Insert(entry);
                await _unitOfWork.SaveChangeAsync();

                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                Error error = new Error
                {
                    ErrorCode = "Database.Insert",
                    Message = "Lỗi khác."
                };
                return ServiceResponse.Failed(error);
            }
        }

        public async Task<ServiceResourceResponse<TestingMachine>> FindTest(DateTime dateTimestart, DateTime dateTimestop)
        {
            try
            {
               var resultFind = await _testingMachineRepository.FindTest(dateTimestart,dateTimestop);

                return new ServiceResourceResponse<TestingMachine>(resultFind);
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.FindConfigByMachineId",
                    Message = "Lỗi database."
                };
                return new ServiceResourceResponse<TestingMachine>(error);
            }
        }
        #endregion
    }
}
