using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Ads.Enums
{
    public enum AdStatusEnum
    {
        [Description("Draft")]
        Draft = 1,

        [Description("Visible")]
        Visible = 2,

        [Description("Invisible")]
        Invisible = 3,

        [Description("Closed")]
        Closed = 4
    }
}
