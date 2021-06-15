
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models.Resource;
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
        private readonly ITestingSheetRepository _testingsheetRepository;

        public DatabaseService(IunitOfWork unitOfWork, ITestingConfigurationRepository testingConfigurationRepository, ITestingSheetRepository testingMachineRepository)
        {
            _unitOfWork = unitOfWork;
            _testingConfigurationRepository = testingConfigurationRepository;
            _testingsheetRepository = testingMachineRepository;
        }


        #region TestingConfiguration
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
        public async Task<IList<TestingConfigurations>> LoadAllConfiguration()
        {
            return await _testingConfigurationRepository.LoadConfigurations();
        }

        #endregion

        #region TestingMachine
        
        public async Task<ServiceResponse> InsertReliability(TestSheet entry)
        {
            try
            {
                _testingsheetRepository.InsertReliability(entry);
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

      /*  public async Task<ServiceResponse> InsertDeformation(TestSheet entry)
        {
            try
            {
                _testingsheetRepository.InsertDeformation(entry);
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
        }*/
        public async Task<IEnumerable<TestSheet>> LoadReliability()
        {
            return await _testingsheetRepository.LoadReliability();
        }
       /* public async Task<IEnumerable<TestSheet>> LoadDeformation()
        {
            return await _testingsheetRepository.LoadDeformation();
        }*/
        public async Task<ServiceResponse> ClearReliability()
        {
            try
            {
                _testingsheetRepository.ClearReliability();
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
       /* public async Task<ServiceResponse> ClearDeformation()
        {
            try
            {
                _testingsheetRepository.ClearDeformation();
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
        }*/
        #endregion
    }
}
