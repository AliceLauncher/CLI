using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    [Flags]
    public enum Codes : uint
    {
        [Description("The account doesn't have an Xbox account. Once they sign up for one (or login through minecraft.net to create one) then they can proceed with the login. This shouldn't happen with accounts that have purchased Minecraft with a Microsoft account, as they would've already gone through that Xbox signup process.")]
        AccountNoExists = 2148916233,
        [Description("The account is from a country where Xbox Live is not available/banned")]
        AccountCountryNotAvailable = 2148916235,
        [Description("The account needs adult verification on Xbox page.")]
        AccountAdultVerify = 2148916236 | 2148916237,
        [Description("The account is a child (under 18) and cannot proceed unless the account is added to a Family by an adult.")]
        AccountNotMature = 2148916238
    }
    public enum Variant
    {

    }
    public enum Alias
    {
        
    }
}
