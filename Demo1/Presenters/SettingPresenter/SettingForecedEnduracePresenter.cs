using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SettingPresenter
{
    public class SettingForecedEnduracePresenter
    {
        private readonly IViewSettingForcedEndurance _viewSettingForcedEndurance;
        private readonly IModelingMachine _modelingMachine;

        public SettingForecedEnduracePresenter(IViewSettingForcedEndurance viewSettingForcedEndurance, IModelingMachine modelingMachine)
        {
            _viewSettingForcedEndurance = viewSettingForcedEndurance;
            _modelingMachine = modelingMachine;
            _viewSettingForcedEndurance.Confirm += SendData;
            _modelingMachine.UpdateData.Add(UpdateView);
        }
        private void SendData(object sender, EventArgs args)
        {
            var TimeStopDown = _viewSettingForcedEndurance.TimeStopDown;
            var TimeStopUp = _viewSettingForcedEndurance.TimeStopUp;
            var TimeNumber = _viewSettingForcedEndurance.TimeNumber;
            _modelingMachine.Send2Bytes(TimeStopDown, 0);
            _modelingMachine.Send2Bytes(TimeStopUp, 4);
            _modelingMachine.Send4byte(TimeNumber, 14);
        }
        private void UpdateView(bool data)
        {
            _viewSettingForcedEndurance.TimeStopDown = _modelingMachine.TimeStop;
            _viewSettingForcedEndurance.TimeStopUp = _modelingMachine.TimeStart;
            _viewSettingForcedEndurance.TimeNumber = _modelingMachine.TimeNumber;
        }
    }
}
