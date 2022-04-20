using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class XboxFactory : RemoteFactory
    {
        private bool _wired;
        private bool _batteries;
        private string _company;

        public XboxFactory(bool wired, bool batteries, string company)
        {
            _wired = wired;
            _batteries = batteries;
            _company = company;
        }

        public override Remote GetRemote()
        {
            return new XBRemote(_wired, _batteries, _company);
        }
    }
}
