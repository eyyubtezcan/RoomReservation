using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service
{
    public class ServiceResult<T>
    {
        bool _hasWarn = false;
        bool _isOk = false;

        public bool isOk
        {
            get
            {
                return _isOk;
            }
        }
        public bool hasWarn
        {
            get
            {
                return _hasWarn;
            }
        }
        public T Result { get; set; }

        public void Ok()
        {
            this._isOk = true;           
        }
        public void Fail()
        {
            this._isOk = false;
        }
    }
}
