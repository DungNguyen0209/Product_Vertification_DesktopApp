using ProductVertificationDesktopApp.Service.Interfaces;
using ProductVertificationDesktopApp.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SettingPresenter
{
    
    public class SettingReliabilityPresenter
    {
        private readonly IViewSettingReliability _viewSettingReliability;
        private readonly IModelingMachine _modelingMachine;

        public SettingReliabilityPresenter(IViewSettingReliability viewSettingReliability, IModelingMachine modelingMachine)
        {
            _viewSettingReliability = viewSettingReliability;
            _modelingMachine = modelingMachine;
            _viewSettingReliability.Confirm += ConfirmSend;
            _modelingMachine.UpdateData.Add(UpdateView);
        }
        private  void ConfirmSend(object sender, EventArgs args)
        {
            var TimeClose = _viewSettingReliability.TimeClose;
            var TimeStart = _viewSettingReliability.TimeStart;
            var TimeNumber = _viewSettingReliability.TimeNumber;
            _modelingMachine.Send2Bytes(TimeClose, 0);
            _modelingMachine.Send2Bytes(TimeStart, 4);
            _modelingMachine.Send4byte(TimeNumber, 14);
        }
        private void UpdateView(bool data)
        {
            _viewSettingReliability.TimeClose = _modelingMachine.TimeStop;
            _viewSettingReliability.TimeStart = _modelingMachine.TimeStart;
            _viewSettingReliability.TimeNumber = _modelingMachine.TimeNumber;
        }

    }

}
