using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public interface ICore
    {
        public void OnDying() { }
        public void OnWining(int addingPower) { }
    }
}
