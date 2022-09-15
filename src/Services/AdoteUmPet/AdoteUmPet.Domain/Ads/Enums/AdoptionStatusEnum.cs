using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Ads.Enums
{
    public enum AdoptionStatusEnum
    {
        [Description("Available")]
        Available = 1,
        [Description("Waiting")]
        Waiting = 2,
        [Description("Adopted")]
        Adopted = 3,
    }
}
