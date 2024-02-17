using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtPlatform.Domain.Enums
{
    public enum Roles
    {
        [Description("Docente")]
        Teacher = 1,
        [Description("Estudiante")]
        Student = 2
    }
}
